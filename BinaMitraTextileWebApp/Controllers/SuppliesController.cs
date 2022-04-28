using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using BinaMitraTextileWebApp.Models;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword)
        {
            //if (!UserAccountsController.getUserAccess(Session).Supplies_View)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                return View(get(FILTER_Keyword));
            }
        }

        [HttpPost]
        public ActionResult Index(string FILTER_Keyword)
        {
            setViewBag(FILTER_Keyword);
            return View(get(FILTER_Keyword));
        }

        /* CREATE *********************************************************************************************************************************************/

        public ActionResult Create(string FILTER_Keyword)
        {
            //if (!UserAccountsController.getUserAccess(Session).Supplies_Add)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliesModel model, string FILTER_Keyword)
        {
            if (ModelState.IsValid)
            {
                model.Timestamp = DateTime.Now;
                add(model);
                ActivityLogsController.Add(db, Session, model.SupplyItems_Id, String.Format("Qty: {0:N0}", model.Qty));
                db.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword });
            }

            setViewBag(FILTER_Keyword);
            return View(model);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;

            SupplyItemsController.setDropDownListViewBag(this);
        }

        public JsonResult Ajax_Add(Guid id, int value)
        {
            SuppliesModel model = new SuppliesModel();
            model.SupplyItems_Id = id;
            model.Qty = value;
            model.Timestamp = DateTime.Now;
            add(model);
            ActivityLogsController.Add(db, Session, model.SupplyItems_Id, String.Format("Qty: {0:N0}", model.Qty));
            db.SaveChanges();
            return Json(new { Message = "" });
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public List<SuppliesModel> get(string FILTER_Keyword) { return get(null, FILTER_Keyword); }
        public SuppliesModel get(Guid Id) { return get(Id, null).FirstOrDefault(); }
        public static List<SuppliesModel> get() { return get(null, null); }
        public static List<SuppliesModel> get(Guid? Id, string FILTER_Keyword)
        {
            string sql = string.Format(@"
                        SELECT Supplies.*,
                            SupplyItems.Id AS SupplyItems_Id,
                            SupplyItems.Name AS SupplyItems_Name,
                            Units.Id AS Units_Id,
                            Units.Name AS Units_Name
                        FROM (                        
                                SELECT Supplies.SupplyItems_Id, MAX(Supplies.Timestamp) AS Timestamp
                                FROM Supplies
                                WHERE (@Id IS NULL OR Supplies.Id = @Id)
                                GROUP BY Supplies.SupplyItems_Id
                            ) LastSupplies
                            LEFT JOIN Supplies ON Supplies.SupplyItems_Id = LastSupplies.SupplyItems_Id AND Supplies.Timestamp = LastSupplies.Timestamp
                            LEFT JOIN SupplyItems ON SupplyItems.Id = Supplies.SupplyItems_Id
                            LEFT JOIN Units ON Units.Id = SupplyItems.Units_Id
                        WHERE 1=1
							AND (@Id IS NULL OR Supplies.Id = @Id)
							AND (@Id IS NOT NULL OR (
    							@FILTER_Keyword IS NULL OR (SupplyItems.Name LIKE '%'+@FILTER_Keyword+'%')
                            ))
						ORDER BY SupplyItems.Name ASC
                    ");

            return new DBContext().Database.SqlQuery<SuppliesModel>(sql,
                    DBConnection.getSqlParameter(SuppliesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword)
                ).ToList();
        }

        public void add(SuppliesModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "Supplies",
                DBConnection.getSqlParameter(SuppliesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(SuppliesModel.COL_SupplyItems_Id.Name, model.SupplyItems_Id),
                DBConnection.getSqlParameter(SuppliesModel.COL_Timestamp.Name, model.Timestamp),
                DBConnection.getSqlParameter(SuppliesModel.COL_Qty.Name, model.Qty)
            );
        }

        /******************************************************************************************************************************************************/
    }
}