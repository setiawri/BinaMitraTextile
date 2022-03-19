using BinaMitraTextileWebApp.Models;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using LIBUtil;

using System.Web.Mvc;

namespace BinaMitraTextileWebApp.Controllers
{
    public class UsersController : Controller
    {
        public const string ACTIONNAME_Login = "Login";
        public const string CONTROLLERNAME = "Users";
        
        public const string SESSION_UserAccount = "UserAccount";
        public const string SESSION_ConnectToLiveDatabase = "ConnectToLiveDatabase";

        private const int SALT_LENGTH = 10;

        private readonly DBContext db = new DBContext();

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

        public static void setLoginSession(HttpSessionStateBase Session, UsersModel model) { setLoginSession(Session, model, false); }
        public static void setLoginSession(HttpSessionStateBase Session, UsersModel model, bool? ConnectToLiveDatabase)
        {
            if (model != null)
            {
                Session[SESSION_UserAccount] = model;
                Session[SESSION_ConnectToLiveDatabase] = ConnectToLiveDatabase;
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

        public string generateUsername(string Fullname, DateTime Birthday)
        {
            string Username;
            int charCount = 3;

            List<string> nameArray = Fullname.Split().ToList();
            if (nameArray.Count == 1)
                nameArray.Add(nameArray[0]); //name must consist of 2 words. duplicate first name as last name

            Username = generateUsername(nameArray, Birthday, charCount);

            //verify username doesn't exist
            while (isExists(null, Username) && charCount <= nameArray[0].Length)
            {
                Username = generateUsername(nameArray, Birthday, charCount++);
            }

            return Username;
        }

        public string generateUsername(List<string> nameArray, DateTime Birthday, int charCount)
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

            return string.Format("{0}{1}{2:##00}{3:##00}", first, last, Birthday.Day, Birthday.Month);
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

        public UsersModel get(Guid Id) { return get(Id, null, null, null).FirstOrDefault(); }
        public UsersModel get(string username) { return get(null, username, null, null).FirstOrDefault(); }
        public List<UsersModel> get(Guid? Id, string Username, string Password, int? Active)
        {
            string sql = string.Format(@"
                        SELECT Users.*
                        FROM Users
                        WHERE 1=1
							AND (@id IS NULL OR Users.id = @id)
                            AND (@id IS NOT NULL OR (
                                @username IS NULL OR Users.username = @username)
							    AND (@hashed_password IS NULL OR Users.hashed_password = @hashed_password)
                            )
						ORDER BY Users.username ASC
                    "
                );

            List<UsersModel> models = db.Database.SqlQuery<UsersModel>(sql,
                    DBConnection.getSqlParameter(UsersModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(UsersModel.COL_Username.Name, Username),
                    DBConnection.getSqlParameter(UsersModel.COL_Password.Name, Password),
                    DBConnection.getSqlParameter(UsersModel.COL_Active.Name, Active)
                ).ToList();

            return models;
        }

        /******************************************************************************************************************************************************/
    }
}