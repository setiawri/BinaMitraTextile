using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using LIBUtil;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp.Controllers
{
    public class RevenueAndExpenseCategoriesController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!UsersController.getUserAccess(Session).RevenueAndExpenseCategories_View)
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
            if (!UsersController.getUserAccess(Session).RevenueAndExpenseCategories_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RevenueAndExpenseCategoriesModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.Name))
                    ModelState.AddModelError(RevenueAndExpenseCategoriesModel.COL_Name.Name, $"{model.Name} exists. Please change.");
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
            if (!UsersController.getUserAccess(Session).RevenueAndExpenseCategories_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RevenueAndExpenseCategoriesModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.Name))
                    ModelState.AddModelError(RevenueAndExpenseCategoriesModel.COL_Name.Name, $"{modifiedModel.Name} exists. Please change.");
                else
                {
                    RevenueAndExpenseCategoriesModel originalModel = get(modifiedModel.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, modifiedModel.Name, RevenueAndExpenseCategoriesModel.COL_Name.LogDisplay);
                    log = Helper.append(log, originalModel.Personal, modifiedModel.Active, RevenueAndExpenseCategoriesModel.COL_Personal.LogDisplay);
                    log = Helper.append(log, originalModel.Company, modifiedModel.Active, RevenueAndExpenseCategoriesModel.COL_Company.LogDisplay);
                    log = Helper.append(log, originalModel.Revenue, modifiedModel.Active, RevenueAndExpenseCategoriesModel.COL_Revenue.LogDisplay);
                    log = Helper.append(log, originalModel.Expense, modifiedModel.Active, RevenueAndExpenseCategoriesModel.COL_Expense.LogDisplay);
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, RevenueAndExpenseCategoriesModel.COL_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, RevenueAndExpenseCategoriesModel.COL_Active.LogDisplay);

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

        public static void setDropDownListViewBag(ControllerBase controller)
        {
            controller.ViewBag.RevenueAndExpenseCategories = new SelectList(get(), RevenueAndExpenseCategoriesModel.COL_Id.Name, RevenueAndExpenseCategoriesModel.COL_Name.Name);
        }

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Name)
        {
            return LIBWebMVC.WebDBConnection.IsExist(db.Database, "RevenueAndExpenseCategories",
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Id.Name, Id),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Name.Name, Name)
            );
        }

        public List<RevenueAndExpenseCategoriesModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword); }
        public RevenueAndExpenseCategoriesModel get(Guid Id) { return get(Id, null, null).FirstOrDefault(); }
        public static List<RevenueAndExpenseCategoriesModel> get() { return get(null, null, null); }
        public static List<RevenueAndExpenseCategoriesModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword)
        {
            return new DBContext().Database.SqlQuery<RevenueAndExpenseCategoriesModel>(@"
                        SELECT RevenueAndExpenseCategories.*
                        FROM RevenueAndExpenseCategories
                        WHERE 1=1
							AND (@Id IS NULL OR RevenueAndExpenseCategories.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR RevenueAndExpenseCategories.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (RevenueAndExpenseCategories.Name LIKE '%'+@FILTER_Keyword+'%'))
                            ))
						ORDER BY RevenueAndExpenseCategories.Name ASC
                    ",
                    DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword)
                ).ToList();
        }

        public void add(RevenueAndExpenseCategoriesModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "RevenueAndExpenseCategories",
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Revenue.Name, model.Revenue),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Expense.Name, model.Expense),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Personal.Name, model.Personal),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Company.Name, model.Company),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Notes.Name, model.Notes)
            );
        }

        public void update(RevenueAndExpenseCategoriesModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "RevenueAndExpenseCategories",
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Revenue.Name, model.Revenue),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Expense.Name, model.Expense),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Personal.Name, model.Personal),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Company.Name, model.Company),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(RevenueAndExpenseCategoriesModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}