using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using BinaMitraTextileWebApp.Models;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class MoneyAccountsController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!UsersController.getUserAccess(Session).MoneyAccounts_View)
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
            if (!UsersController.getUserAccess(Session).MoneyAccounts_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyAccountsModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.Name))
                    ModelState.AddModelError(MoneyAccountsModel.COL_Name.Name, $"{model.Name} exists. Please change.");
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
            if (!UsersController.getUserAccess(Session).MoneyAccounts_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoneyAccountsModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.Name))
                    ModelState.AddModelError(MoneyAccountsModel.COL_Name.Name, $"{modifiedModel.Name} exists. Please change.");
                else
                {
                    MoneyAccountsModel originalModel = get(modifiedModel.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, modifiedModel.Name, MoneyAccountsModel.COL_Name.LogDisplay);
                    log = Helper.append(log, originalModel.Default, modifiedModel.Default, MoneyAccountsModel.COL_Default.LogDisplay);
                    log = Helper.append(log, originalModel.UserRoleRestriction, modifiedModel.UserRoleRestriction, MoneyAccountsModel.COL_UserRoleRestriction.LogDisplay);
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, MoneyAccountsModel.COL_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, MoneyAccountsModel.COL_Active.LogDisplay);

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
            controller.ViewBag.MoneyAccounts = new SelectList(get(), MoneyAccountsModel.COL_Id.Name, MoneyAccountsModel.COL_Name.Name);
        }

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Name)
        {
            return LIBWebMVC.WebDBConnection.IsExist(db.Database, "MoneyAccounts",
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Id.Name, Id),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Name.Name, Name)
            );
        }

        public List<MoneyAccountsModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword); }
        public MoneyAccountsModel get(Guid Id) { return get(Id, null, null).FirstOrDefault(); }
        public static List<MoneyAccountsModel> get() { return get(null, null, null); }
        public static List<MoneyAccountsModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword)
        {
            return new DBContext().Database.SqlQuery<MoneyAccountsModel>(@"
                        SELECT MoneyAccounts.*
                        FROM MoneyAccounts
                        WHERE 1=1
							AND (@Id IS NULL OR MoneyAccounts.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR MoneyAccounts.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (MoneyAccounts.Name LIKE '%'+@FILTER_Keyword+'%'))
                            ))
						ORDER BY MoneyAccounts.Name ASC
                    ",
                    DBConnection.getSqlParameter(MoneyAccountsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(MoneyAccountsModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword)
                ).ToList();
        }

        public void add(MoneyAccountsModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "MoneyAccounts",
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Default.Name, model.Default),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_UserRoleRestriction.Name, model.UserRoleRestriction),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Notes.Name, model.Notes)
            );
        }

        public void update(MoneyAccountsModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "MoneyAccounts",
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Default.Name, model.Default),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_UserRoleRestriction.Name, model.UserRoleRestriction),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountsModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}