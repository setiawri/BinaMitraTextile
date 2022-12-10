using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using LIBUtil;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp.Controllers
{
    public class RevenuesAndExpensesController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (!UsersController.getUserAccess(Session).RevenuesAndExpenses_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (FILTER_DateFrom == null)
            {
                FILTER_chkDateFrom = true;
                FILTER_DateFrom = Util.getFirstDayOfSelectedMonth(DateTime.Now.Date);
            }

            if (FILTER_DateTo == null)
                FILTER_DateTo = DateTime.Now.Date;

            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                return View(get(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo));
            }
        }

        [HttpPost]
        public ActionResult Index(string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(get(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo));
        }

        /* CREATE *********************************************************************************************************************************************/

        public ActionResult Create(string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (!UsersController.getUserAccess(Session).RevenuesAndExpenses_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(new RevenuesAndExpensesModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevenuesAndExpensesModel model, string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (ModelState.IsValid)
            {
                add(model);
                ActivityLogsController.AddCreateLog(db, Session, model.Id);
                if (Request.Form["SubmitAndAddMoreButton"] == null)
                    return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword, FILTER_chkDateFrom = FILTER_chkDateFrom, FILTER_DateFrom = FILTER_DateFrom, FILTER_chkDateTo = FILTER_chkDateTo, FILTER_DateTo = FILTER_DateTo });
                else
                {
                    model.Description = "";
                    model.Amount = 0;
                }
            }

            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(model);
        }

        /* EDIT ***********************************************************************************************************************************************/

        public ActionResult Edit(Guid? id, string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (!UsersController.getUserAccess(Session).RevenuesAndExpenses_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RevenuesAndExpensesModel modifiedModel, string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (ModelState.IsValid)
            {
                RevenuesAndExpensesModel originalModel = get(modifiedModel.Id);

                string log = string.Empty;
                log = Helper.append(log, originalModel.Timestamp, modifiedModel.Timestamp, RevenuesAndExpensesModel.COL_Timestamp.LogDisplay);
                log = Helper.append<RevenueAndExpenseCategoriesModel>(log, originalModel.RevenueAndExpenseCategories_Id, modifiedModel.RevenueAndExpenseCategories_Id, RevenuesAndExpensesModel.COL_RevenueAndExpenseCategories_Id.LogDisplay);
                log = Helper.append(log, originalModel.Description, modifiedModel.Description, RevenuesAndExpensesModel.COL_Description.LogDisplay);
                log = Helper.append(log, originalModel.Amount, modifiedModel.Amount, RevenuesAndExpensesModel.COL_Amount.LogDisplay);

                if (!string.IsNullOrEmpty(log))
                {
                    update(modifiedModel, log);
                    ActivityLogsController.AddEditLog(db, Session, modifiedModel.Id, log);
                }

                return RedirectToAction(nameof(Index), new { FILTER_Keyword = FILTER_Keyword });
            }

            setViewBag(FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(modifiedModel);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_chkDateFrom = FILTER_chkDateFrom;
            ViewBag.FILTER_DateFrom = FILTER_DateFrom;
            ViewBag.FILTER_chkDateTo = FILTER_chkDateTo;
            ViewBag.FILTER_DateTo = FILTER_DateTo;

            RevenueAndExpenseCategoriesController.setDropDownListViewBag(this);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public List<RevenuesAndExpensesModel> get(string FILTER_Keyword, bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo) { return get(null, FILTER_Keyword, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo); }
        public RevenuesAndExpensesModel get(Guid Id) { return get(Id, null, null, null, null, null).FirstOrDefault(); }
        public static List<RevenuesAndExpensesModel> get() { return get(null, null, null, null, null, null); }
        public static List<RevenuesAndExpensesModel> get(Guid? Id, string FILTER_Keyword,
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (FILTER_chkDateFrom == null || !(bool)FILTER_chkDateFrom)
                FILTER_DateFrom = null;

            if (FILTER_chkDateTo == null || !(bool)FILTER_chkDateTo)
                FILTER_DateTo = null;

            return new DBContext().Database.SqlQuery<RevenuesAndExpensesModel>(@"
                        SELECT RevenuesAndExpenses.*,
                            RevenueAndExpenseCategories.Name AS RevenueAndExpenseCategories_Name
                        FROM RevenuesAndExpenses
                            LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                        WHERE 1=1
							AND (@Id IS NULL OR RevenuesAndExpenses.Id = @Id)
							AND (@Id IS NOT NULL OR (
    							(@FILTER_Keyword IS NULL OR (RevenuesAndExpenses.Description LIKE '%'+@FILTER_Keyword+'%'))
                                AND (@FILTER_DateFrom IS NULL OR RevenuesAndExpenses.Timestamp >= @FILTER_DateFrom)
                                AND (@FILTER_DateTo IS NULL OR RevenuesAndExpenses.Timestamp <= @FILTER_DateTo)
                            ))
						ORDER BY RevenuesAndExpenses.Timestamp DESC
                    ",
                    DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword),
                    DBConnection.getSqlParameter("FILTER_DateFrom", FILTER_DateFrom),
                    DBConnection.getSqlParameter("FILTER_DateTo", Util.getAsEndDate(FILTER_DateTo))
                ).ToList();
        }

        public void add(RevenuesAndExpensesModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "RevenuesAndExpenses",
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Timestamp.Name, model.Timestamp),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_RevenueAndExpenseCategories_Id.Name, model.RevenueAndExpenseCategories_Id),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Description.Name, model.Description),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Amount.Name, model.Amount)
            );
        }

        public void update(RevenuesAndExpensesModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "RevenuesAndExpenses",
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Timestamp.Name, model.Timestamp),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_RevenueAndExpenseCategories_Id.Name, model.RevenueAndExpenseCategories_Id),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Description.Name, model.Description),
                DBConnection.getSqlParameter(RevenuesAndExpensesModel.COL_Amount.Name, model.Amount)
            );
        }

        /******************************************************************************************************************************************************/
    }
}