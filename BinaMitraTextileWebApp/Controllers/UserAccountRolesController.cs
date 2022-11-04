using BinaMitraTextileWebApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Web.Mvc;
using LIBUtil;

/*
 * To add new user access:
 * - add items in UserAccountRolesModel
 * - add items to database table UserAccountRoles
 * - add items in UserAccountRoles > Edit.cshtml
 * - add items in Post UserAccountRolesController.Edit() 
 * - add items in UserAccountRolesController.getAccesses() 
 * - update views that use the items including main layout file
 */

namespace BinaMitraTextileWebApp.Controllers
{
    public class UserAccountRolesController : Controller
    {
        public const string NAME = "UserAccountRoles";
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        // GET: UserAccountRoles
        public ActionResult Index(int? rss)
        {
            if (!UsersController.getUserAccess(Session).UserAccountRoles_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            ViewBag.RemoveDatatablesStateSave = rss;

            return View(get());
        }

        /* CREATE *********************************************************************************************************************************************/

        // GET: UserAccountRoles/Create
        public ActionResult Create()
        {
            if (!UsersController.getUserAccess(Session).UserAccountRoles_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            return View(new UserAccountRolesModel());
        }

        // POST: UserAccountRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccountRolesModel model)
        {
            if (ModelState.IsValid)
            {
                if (isExists(EnumActions.Create, null, model.Name))
                    ModelState.AddModelError(UserAccountRolesModel.COL_Name.Name, $"{model.Name} sudah terdaftar");
                else
                {
                    model.Id = Guid.NewGuid();
                    db.UserAccountRoles.Add(model);
                    ActivityLogsController.AddCreateLog(db, Session, model.Id);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Edit), new { id = model.Id });
                }
            }

            return View(model);
        }

        /* EDIT ***********************************************************************************************************************************************/

        // GET: UserAccountRoles/Edit/{id}
        public ActionResult Edit(Guid? id)
        {
            if (!UsersController.getUserAccess(Session).UserAccountRoles_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            var model = get(id);
            return View(model);
        }

        // POST: UserAccountRoles/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAccountRolesModel model)
        {
            if (ModelState.IsValid)
            {
                if (isExists(EnumActions.Edit, model.Id, model.Name))
                    ModelState.AddModelError(UserAccountRolesModel.COL_Name.Name, $"{model.Name} sudah terdaftar");
                else
                {
                    UserAccountRolesModel originalModel = get(model.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, model.Name, UserAccountRolesModel.COL_Name.LogDisplay);

                    //User Account Roles
                    log = Helper.append(log, originalModel.UserAccountRoles_Notes, model.UserAccountRoles_Notes, UserAccountRolesModel.COL_UserAccountRoles_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccountRoles_Add, model.UserAccountRoles_Add, UserAccountRolesModel.COL_UserAccountRoles_Add.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccountRoles_Edit, model.UserAccountRoles_Edit, UserAccountRolesModel.COL_UserAccountRoles_Edit.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccountRoles_View, model.UserAccountRoles_View, UserAccountRolesModel.COL_UserAccountRoles_View.LogDisplay);

                    //UserAccounts
                    log = Helper.append(log, originalModel.UserAccounts_Notes, model.UserAccounts_Notes, UserAccountRolesModel.COL_UserAccounts_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccounts_Add, model.UserAccounts_Add, UserAccountRolesModel.COL_UserAccounts_Add.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccounts_Edit, model.UserAccounts_Edit, UserAccountRolesModel.COL_UserAccounts_Edit.LogDisplay);
                    log = Helper.append(log, originalModel.UserAccounts_View, model.UserAccounts_View, UserAccountRolesModel.COL_UserAccounts_View.LogDisplay);

                    //FinancialReports
                    log = Helper.append(log, originalModel.FinancialReports_Notes, model.FinancialReports_Notes, UserAccountRolesModel.COL_FinancialReports_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.FinancialReports_Add, model.FinancialReports_Add, UserAccountRolesModel.COL_FinancialReports_Add.LogDisplay);
                    log = Helper.append(log, originalModel.FinancialReports_Edit, model.FinancialReports_Edit, UserAccountRolesModel.COL_FinancialReports_Edit.LogDisplay);
                    log = Helper.append(log, originalModel.FinancialReports_View, model.FinancialReports_View, UserAccountRolesModel.COL_FinancialReports_View.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                    {
                        db.Entry(model).State = EntityState.Modified;
                        ActivityLogsController.AddEditLog(db, Session, model.Id, log);
                        db.SaveChanges();
                    }

                    UsersController.updateLoginSession(Session);

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        /* METHODS ********************************************************************************************************************************************/

        public static void setDropDownListViewBag(Controller controller) { setDropDownListViewBag(controller, true); }
        public static void setDropDownListViewBag(Controller controller, bool UserAccounts_EditRoles)
        {
            List<UserAccountRolesModel> models = new List<UserAccountRolesModel>();
            if (!UserAccounts_EditRoles)
            {

            }
            else
                models = get();

            controller.ViewBag.UserAccountRoles = new SelectList(models, UserAccountRolesModel.COL_Id.Name, UserAccountRolesModel.COL_Name.Name);
        }

        public static void setViewBag(Controller controller)
        {
            controller.ViewBag.UserAccountRolesModels = get();
        }

        public static UserAccountRolesModel getAccesses(UsersModel UserAccount)
        {
            UserAccountRolesModel model = new UserAccountRolesModel();
            foreach (UserAccountRolesModel item in get(null, UserAccount))
            {
                //UserAccountRoles
                if (item.UserAccountRoles_Add) model.UserAccountRoles_Add = true;
                if (item.UserAccountRoles_Edit) model.UserAccountRoles_Edit = true;
                if (item.UserAccountRoles_View) model.UserAccountRoles_View = true;

                //UserAccounts
                if (item.UserAccounts_Add) model.UserAccounts_Add = true;
                if (item.UserAccounts_Edit) model.UserAccounts_Edit = true;
                if (item.UserAccounts_View) model.UserAccounts_View = true;

                //FinancialReports
                if (item.FinancialReports_Add) model.FinancialReports_Add = true;
                if (item.FinancialReports_Edit) model.FinancialReports_Edit = true;
                if (item.FinancialReports_View) model.FinancialReports_View = true;

            }

            return model;
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(EnumActions action, Guid? id, object value)
        {
            var result = action == EnumActions.Create
                ? db.UserAccountRoles.AsNoTracking().Where(x => x.Name.ToLower() == value.ToString().ToLower()).FirstOrDefault()
                : db.UserAccountRoles.AsNoTracking().Where(x => x.Name.ToLower() == value.ToString().ToLower() && x.Id != id).FirstOrDefault();
            return result != null;
        }

        public static List<UserAccountRolesModel> get() { return get(null, null); }
        public static UserAccountRolesModel get(Guid? Id) { return get(Id, null).FirstOrDefault(); }
        public static List<UserAccountRolesModel> get(Guid? Id, UsersModel UserAccount)
        {
            string UserAccountRolesClause = "";
            if (UserAccount != null && !string.IsNullOrEmpty(UserAccount.Roles))
                UserAccountRolesClause = string.Format(" AND UserAccountRoles.Id IN ({0}) ", LIBWebMVC.UtilWebMVC.convertToSqlIdList(UserAccount.Roles));

            string sql = string.Format(@"
                        SELECT UserAccountRoles.*
                        FROM UserAccountRoles
                        WHERE 1=1
							AND (@Id IS NULL OR UserAccountRoles.Id = @Id)
                            AND (@Id IS NOT NULL OR (
                                1=1
                                {0}
                            ))
						ORDER BY UserAccountRoles.Name ASC
                    ", UserAccountRolesClause);

            return new DBContext().Database.SqlQuery<UserAccountRolesModel>(sql,
                    DBConnection.getSqlParameter(UserAccountRolesModel.COL_Id.Name, Id)
                ).ToList();
        }

        /******************************************************************************************************************************************************/
    }
}