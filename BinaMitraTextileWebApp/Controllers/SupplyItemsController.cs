using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using BinaMitraTextileWebApp.Models;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class SupplyItemsController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).SupplyItems_View)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                return View(get(FILTER_Keyword, FILTER_Active));
            }
        }

        [HttpPost]
        public ActionResult Index(string FILTER_Keyword, int? FILTER_Active)
        {
            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get(FILTER_Keyword, FILTER_Active));
        }

        /* CREATE *********************************************************************************************************************************************/

        public ActionResult Create(string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).SupplyItems_Add)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplyItemsModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.Name))
                    ModelState.AddModelError(SupplyItemsModel.COL_Name.Name, $"{model.Name} sudah terdaftar");
                else
                {
                    add(model);
                    ActivityLogsController.AddCreateLog(db, Session, model.Id);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(model);
        }

        /* EDIT ***********************************************************************************************************************************************/

        public ActionResult Edit(Guid? id, string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).SupplyItems_Edit)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplyItemsModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.Name))
                    ModelState.AddModelError(SupplyItemsModel.COL_Name.Name, $"{modifiedModel.Name} sudah terdaftar");
                else
                {
                    SupplyItemsModel originalModel = get(modifiedModel.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, modifiedModel.Name, SupplyItemsModel.COL_Name.LogDisplay);
                    log = Helper.append<UnitsModel>(log, originalModel.Units_Id, modifiedModel.Units_Id, SupplyItemsModel.COL_Name.LogDisplay);
                    log = Helper.append(log, originalModel.MinimumQty, modifiedModel.MinimumQty, SupplyItemsModel.COL_MinimumQty.LogDisplay);
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, SupplyItemsModel.COL_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, SupplyItemsModel.COL_Active.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                    {
                        update(modifiedModel, log);
                        ActivityLogsController.AddEditLog(db, Session, modifiedModel.Id, log);
                        db.SaveChanges();
                    }

                    return RedirectToAction(nameof(Index), new { FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(modifiedModel);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;

            UnitsController.setDropDownListViewBag(this);
        }

        public static void setDropDownListViewBag(ControllerBase controller)
        {
            controller.ViewBag.SupplyItems = new SelectList(get(), SupplyItemsModel.COL_Id.Name, SupplyItemsModel.COL_Name.Name);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Name)
        {
            return db.Database.SqlQuery<SupplyItemsModel>(@"
                        SELECT SupplyItems.*
                        FROM SupplyItems
                        WHERE 1=1 
							AND (@Id IS NOT NULL OR SupplyItems.Name = @Name)
							AND (@Id IS NULL OR (SupplyItems.Name = @Name AND SupplyItems.Id <> @Id))
                    ",
                    DBConnection.getSqlParameter(SupplyItemsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(SupplyItemsModel.COL_Name.Name, Name)
                ).Count() > 0;
        }

        public static List<SupplyItemsModel> get(int? FILTER_Active, string IdList) { return get(null, FILTER_Active, null, IdList); }
        public List<SupplyItemsModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword, null); }
        public SupplyItemsModel get(Guid Id) { return get(Id, null, null, null).FirstOrDefault(); }
        public static List<SupplyItemsModel> get() { return get(null, null, null, null); }
        public static List<SupplyItemsModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword, string IdList)
        {
            string IdListClause = "";
            if (!string.IsNullOrEmpty(IdList))
                IdListClause = string.Format(" AND SupplyItems.Id IN ({0}) ", LIBWebMVC.UtilWebMVC.convertToSqlIdList(IdList));

            string sql = string.Format(@"
                        SELECT SupplyItems.*,
                            Units.Name AS Units_Name
                        FROM SupplyItems
                            LEFT JOIN Units ON Units.Id = SupplyItems.Units_Id
                        WHERE 1=1
							AND (@Id IS NULL OR SupplyItems.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR SupplyItems.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (SupplyItems.Name LIKE '%'+@FILTER_Keyword+'%'))
                                {0}
                            ))
						ORDER BY SupplyItems.Name ASC
                    ", IdListClause);

            return new DBContext().Database.SqlQuery<SupplyItemsModel>(sql,
                    DBConnection.getSqlParameter(SupplyItemsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(SupplyItemsModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword),
                    DBConnection.getSqlParameter("IdList", IdList)
                ).ToList();
        }

        public void update(SupplyItemsModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "SupplyItems",
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Units_Id.Name, model.Units_Id),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_MinimumQty.Name, model.MinimumQty),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Notes.Name, model.Notes)
            );
        }

        public void add(SupplyItemsModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "SupplyItems",
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Units_Id.Name, model.Units_Id),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_MinimumQty.Name, model.MinimumQty),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(SupplyItemsModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}