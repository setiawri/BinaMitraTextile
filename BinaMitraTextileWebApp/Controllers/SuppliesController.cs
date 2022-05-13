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

        [HttpGet]
        public ActionResult Index(int? rss, string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            //if (!UserAccountsController.getUserAccess(Session).Supplies_View)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                List<SuppliesModel> models = get(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
                return View(models);
            }
        }

        [HttpPost]
        public ActionResult Index(string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            setViewBag(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            List<SuppliesModel> models = get(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(models);
        }

        /* CREATE *********************************************************************************************************************************************/

        public ActionResult Create(string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            //if (!UserAccountsController.getUserAccess(Session).Supplies_Add)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliesModel model, string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (ModelState.IsValid)
            {
                model.Timestamp = DateTime.Now;
                add(model);
                ActivityLogsController.Add(db, Session, model.SupplyItems_Id, String.Format("Qty: {0:N0}", model.Qty));
                db.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword });
            }

            setViewBag(FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(model);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_IsLastOnly = FILTER_IsLastOnly;
            ViewBag.FILTER_chkDateFrom = FILTER_chkDateFrom;
            ViewBag.FILTER_DateFrom = FILTER_DateFrom;
            ViewBag.FILTER_chkDateTo = FILTER_chkDateTo;
            ViewBag.FILTER_DateTo = FILTER_DateTo;

            SupplyItemsController.setDropDownListViewBag(this);
        }

        public JsonResult Ajax_Add(string param)
        {
            string[] parameters = param.Split('|');

            SuppliesModel model = new SuppliesModel();
            model.SupplyItems_Id = new Guid(parameters[0]);
            model.Qty = Int32.Parse(parameters[1]);
            model.Notes = parameters[2];
            model.Timestamp = DateTime.Now;
            add(model);
            ActivityLogsController.Add(db, Session, model.SupplyItems_Id, String.Format("Qty: {0:N0}", model.Qty));
            db.SaveChanges();
            return Json(new { Message = "" });
        }

        public JsonResult Ajax_Get_Balance(Guid id)
        {
            return Json(new { content = getLast(id).Balance }, JsonRequestBehavior.AllowGet);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public SuppliesModel getLast(Guid SupplyItems_Id) { return get(null, SupplyItems_Id, null, true, null, null, null, null).FirstOrDefault(); }
        public List<SuppliesModel> get(string FILTER_Keyword, bool? FILTER_IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        { return get(null, null, FILTER_Keyword, FILTER_IsLastOnly, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo); }
        public SuppliesModel get(Guid Id) { return get(Id, null, null, false, null, null, null, null).FirstOrDefault(); }
        public static List<SuppliesModel> get() { return get(null, null, null, false, null, null, null, null); }
        public static List<SuppliesModel> get(Guid? Id, Guid? SupplyItems_Id, string FILTER_Keyword, bool? IsLastOnly,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (FILTER_chkDateFrom == null || !(bool)FILTER_chkDateFrom)
                FILTER_DateFrom = null;

            if (FILTER_chkDateTo == null || !(bool)FILTER_chkDateTo)
                FILTER_DateTo = null;

            string sql = string.Format(@"
	                    -- drop table if already exists
	                    IF(SELECT object_id('TempDB..#TEMP_TABLE')) IS NOT NULL
		                    DROP TABLE #TEMP_TABLE		

                        SELECT * INTO #TEMP_TABLE FROM (
                            SELECT Supplies.*,
                                IIF((Supplies.MinimumQty - Supplies.Balance) > 0, Supplies.MinimumQty - Supplies.Balance, NULL) AS OrderQty
                            FROM (
                                SELECT Supplies.*,
                                    SupplyItems.Name AS SupplyItems_Name,
                                    SupplyItems.MinimumQty AS MinimumQty,
                                    Units.Id AS Units_Id,
                                    Units.Name AS Units_Name,
                                    InitialBalance.Qty + (SUM(Supplies.Qty) OVER(PARTITION BY Supplies.SupplyItems_Id ORDER BY Supplies.Timestamp ASC)) AS Balance
                                FROM Supplies
                                    LEFT JOIN SupplyItems ON SupplyItems.Id = Supplies.SupplyItems_Id
                                    LEFT JOIN Units ON Units.Id = SupplyItems.Units_Id
                                    LEFT JOIN (
                                            SELECT 1 AS Id, ISNULL(SUM(Supplies.Qty),0) AS Qty
                                            FROM Supplies
                                            WHERE 1=1
                                                AND Supplies.Timestamp < @FILTER_DateFrom
                                        ) InitialBalance ON InitialBalance.Id = 1
                                WHERE 1=1
							        AND (@Id IS NULL OR Supplies.Id = @Id)
							        AND (@Id IS NOT NULL OR (
    							        (@FILTER_Keyword IS NULL OR (SupplyItems.Name LIKE '%'+@FILTER_Keyword+'%'))
    							        AND (@SupplyItems_Id IS NULL OR Supplies.SupplyItems_Id = @SupplyItems_Id)
                                        AND (@FILTER_DateFrom IS NULL OR Supplies.Timestamp >= @FILTER_DateFrom)
                                        AND (@FILTER_DateTo IS NULL OR Supplies.Timestamp <= @FILTER_DateTo)
                                    ))
                            ) Supplies
                        ) AS X

                        IF @IsLastOnly = 0
                            SELECT * FROM #TEMP_TABLE ORDER BY #TEMP_TABLE.Timestamp DESC
                        ELSE
                            SELECT #TEMP_TABLE.*
                            FROM (
                                    SELECT #TEMP_TABLE.SupplyItems_Id, MAX(#TEMP_TABLE.Timestamp) AS Timestamp 
                                    FROM #TEMP_TABLE
                                    GROUP BY #TEMP_TABLE.SupplyItems_Id
                                ) LastSupplies
                                LEFT JOIN #TEMP_TABLE ON #TEMP_TABLE.SupplyItems_Id = LastSupplies.SupplyItems_Id AND #TEMP_TABLE.Timestamp = LastSupplies.Timestamp
                            ORDER BY #TEMP_TABLE.SupplyItems_Name ASC

	                    -- clean up
	                    DROP TABLE #TEMP_TABLE
                    ");

            return new DBContext().Database.SqlQuery<SuppliesModel>(sql,
                    DBConnection.getSqlParameter(SuppliesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(SuppliesModel.COL_SupplyItems_Id.Name, SupplyItems_Id),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword),
                    DBConnection.getSqlParameter("IsLastOnly", IsLastOnly),
                    DBConnection.getSqlParameter("FILTER_DateFrom", FILTER_DateFrom),
                    DBConnection.getSqlParameter("FILTER_DateTo", Util.getAsEndDate(FILTER_DateTo))
                ).ToList();
        }

        public void add(SuppliesModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "Supplies",
                DBConnection.getSqlParameter(SuppliesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(SuppliesModel.COL_SupplyItems_Id.Name, model.SupplyItems_Id),
                DBConnection.getSqlParameter(SuppliesModel.COL_Timestamp.Name, model.Timestamp),
                DBConnection.getSqlParameter(SuppliesModel.COL_Qty.Name, model.Qty),
                DBConnection.getSqlParameter(SuppliesModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}