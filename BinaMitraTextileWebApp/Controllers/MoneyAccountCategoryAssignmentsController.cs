using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using LIBUtil;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp.Controllers
{
    public class MoneyAccountCategoryAssignmentsController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!UsersController.getUserAccess(Session).MoneyAccountCategoryAssignments_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

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
            if (!UsersController.getUserAccess(Session).MoneyAccountCategoryAssignments_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyAccountCategoryAssignmentsModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.MoneyAccounts_Id, model.MoneyAccountCategories_Id))
                    ModelState.AddModelError(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.Name, $"Combination of {model.MoneyAccounts_Name} and {model.MoneyAccountCategories_Name} exists. Please change.");
                else
                {
                    add(model);
                    ActivityLogsController.AddCreateLog(db, Session, model.Id);
                    return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(model);
        }

        /* EDIT ***********************************************************************************************************************************************/

        public ActionResult Edit(Guid? id, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!UsersController.getUserAccess(Session).MoneyAccountCategoryAssignments_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoneyAccountCategoryAssignmentsModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.MoneyAccounts_Id, modifiedModel.MoneyAccountCategories_Id))
                    ModelState.AddModelError(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.Name, $"Combination of {modifiedModel.MoneyAccounts_Name} and {modifiedModel.MoneyAccountCategories_Name} exists. Please change.");
                else
                {
                    MoneyAccountCategoryAssignmentsModel originalModel = get(modifiedModel.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, MoneyAccountCategoryAssignmentsModel.COL_Notes.LogDisplay);
                    log = Helper.append<MoneyAccountsModel>(log, originalModel.MoneyAccounts_Id, modifiedModel.MoneyAccounts_Id, MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.LogDisplay);
                    log = Helper.append<MoneyAccountCategoriesModel>(log, originalModel.MoneyAccountCategories_Id, modifiedModel.MoneyAccountCategories_Id, MoneyAccountCategoryAssignmentsModel.COL_MoneyAccountCategories_Id.LogDisplay);
                    log = Helper.append(log, originalModel.Expense, modifiedModel.Expense, MoneyAccountCategoryAssignmentsModel.COL_Expense.LogDisplay);
                    log = Helper.append(log, originalModel.BankCashDeposit, modifiedModel.BankCashDeposit, MoneyAccountCategoryAssignmentsModel.COL_BankCashDeposit.LogDisplay);
                    log = Helper.append(log, originalModel.ReceivedCash, modifiedModel.ReceivedCash, MoneyAccountCategoryAssignmentsModel.COL_ReceivedCash.LogDisplay);
                    log = Helper.append(log, originalModel.Default, modifiedModel.Default, MoneyAccountCategoryAssignmentsModel.COL_Default.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, MoneyAccountCategoryAssignmentsModel.COL_Active.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                    {
                        update(modifiedModel, log);
                        ActivityLogsController.AddEditLog(db, Session, modifiedModel.Id, log);
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

            MoneyAccountsController.setDropDownListViewBag(this);
            MoneyAccountCategoriesController.setDropDownListViewBag(this);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, Guid? MoneyAccounts_Id, Guid? MoneyAccountCategories_Id)
        {
            return LIBWebMVC.WebDBConnection.IsExist(db.Database, "MoneyAccountCategoryAssignments",
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Id.Name, Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.Name, MoneyAccounts_Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccountCategories_Id.Name, MoneyAccountCategories_Id)
            );
        }

        public List<MoneyAccountCategoryAssignmentsModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword); }
        public MoneyAccountCategoryAssignmentsModel get(Guid Id) { return get(Id, null, null).FirstOrDefault(); }
        public static List<MoneyAccountCategoryAssignmentsModel> get() { return get(null, null, null); }
        public static List<MoneyAccountCategoryAssignmentsModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword)
        {
            return new DBContext().Database.SqlQuery<MoneyAccountCategoryAssignmentsModel>(@"
                        SELECT MoneyAccountCategoryAssignments.*,
                            MoneyAccounts.Name AS MoneyAccounts_Name,
                            MoneyAccountCategories.Name AS MoneyAccountCategories_Name
                        FROM MoneyAccountCategoryAssignments
                            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountCategoryAssignments.MoneyAccounts_Id
                            LEFT JOIN MoneyAccountCategories ON MoneyAccountCategories.Id = MoneyAccountCategoryAssignments.MoneyAccountCategories_Id
                        WHERE 1=1
							AND (@Id IS NULL OR MoneyAccountCategoryAssignments.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR MoneyAccountCategoryAssignments.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (
                                        MoneyAccounts.Name LIKE '%'+@FILTER_Keyword+'%'
                                        AND MoneyAccountCategories.Name LIKE '%'+@FILTER_Keyword+'%'
                                    ))
                            ))
						ORDER BY MoneyAccounts.Name ASC, MoneyAccountCategories.Name ASC
                    ",
                    DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword)
                ).ToList();
        }

        public void add(MoneyAccountCategoryAssignmentsModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "MoneyAccountCategoryAssignments",
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.Name, model.MoneyAccounts_Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccountCategories_Id.Name, model.MoneyAccountCategories_Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Expense.Name, model.Expense),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_BankCashDeposit.Name, model.BankCashDeposit),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_ReceivedCash.Name, model.ReceivedCash),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Default.Name, model.Default),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Notes.Name, model.Notes)
            );
        }

        public void update(MoneyAccountCategoryAssignmentsModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "MoneyAccountCategoryAssignments",
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccounts_Id.Name, model.MoneyAccounts_Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_MoneyAccountCategories_Id.Name, model.MoneyAccountCategories_Id),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Expense.Name, model.Expense),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_BankCashDeposit.Name, model.BankCashDeposit),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_ReceivedCash.Name, model.ReceivedCash),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Default.Name, model.Default),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountCategoryAssignmentsModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}