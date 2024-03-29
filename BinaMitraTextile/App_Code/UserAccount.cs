﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using LIBUtil;

namespace BinaMitraTextile
{
    public enum Roles
    {
        User,
        Admin,
        Super,
        Assistant
    };

    public class UserAccount
    {
        /*******************************************************************************************************/

        #region CLASS VARIABLES

        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "username";
        public const string COL_ROLENAME = "rolename";
        public const string COL_ROLE = "role";
        public const string COL_DB_PercentCommission = "PercentCommission";
        public const string COL_DB_GlobalPercentComission = "GlobalPercentComission";
        public const string COL_DB_HashedPassword = "hashed_password";
        public const string COL_DB_Notes = "notes";

        public const string FILTER_IncludeInactive = "FILTER_IncludeInactive";

        private const int SALT_LENGTH = 10;

        public const string PASSWORD_REQUIREMENTS = "Password must be at least 6 characters";
        public const int PASSWORD_MIN_LENGTH = 4;

        public Guid id;
        public string name = "";
        public Roles role;
        public decimal percentCommission = 0;
        public decimal GlobalPercentComission = 0;
        public string notes = "";

        private string _hashed_password = null;
        public string HashedPassword
        {
            get { return _hashed_password; }
            set { _hashed_password = hashPassword(value); }
        }

        public string FirstName { get { return name.Split(' ')[0]; } }

        #endregion CLASS VARIABLES

        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public UserAccount(Guid? ID) : this(ID, null) { }
        public UserAccount(string username) : this(null, username) { }

        public UserAccount(Guid? ID, string username)
        {
            if (ID != null || username != null) //to return null value for new UserAccount(null)
            {
                DataRow row = Util.getFirstRow(get(ID, username, true));
                if (row != null)
                {
                    id = (Guid)row[COL_DB_ID];
                    name = row[COL_DB_NAME].ToString();
                    _hashed_password = row["hashed_password"].ToString();
                    role = Tools.parseEnum<Roles>(row[COL_ROLE]);
                    percentCommission = Util.wrapNullable<decimal>(row, COL_DB_PercentCommission);
                    GlobalPercentComission = Util.wrapNullable<decimal>(row, COL_DB_GlobalPercentComission);
                    notes = row["notes"].ToString();
                }
            }
        }

        public UserAccount(string Name, string Password, Roles Role, decimal PercentComission, decimal globalPercentComission, string Notes)
        {
            id = Guid.NewGuid();
            name = Name;
            if (!string.IsNullOrEmpty(Password)) HashedPassword = Password;
            role = Role;
            percentCommission = PercentComission;
            GlobalPercentComission = globalPercentComission;
            notes = Notes;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public Guid? submitNew()
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "users_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                new SqlQueryParameter(COL_DB_HashedPassword, SqlDbType.VarChar, _hashed_password),
                new SqlQueryParameter(COL_ROLE, SqlDbType.TinyInt, (int)role),
                new SqlQueryParameter(COL_DB_PercentCommission, SqlDbType.Decimal, percentCommission),
                new SqlQueryParameter(COL_DB_GlobalPercentComission, SqlDbType.Decimal, GlobalPercentComission),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static bool isNameExist(string Name)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "users_isNameExist",
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Name)
                );
            return result.ValueBoolean;
        }

        public static DataTable get(Guid? id, string username, bool includeInactive)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "users_get",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(username)),
                    new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive)
                );

            return Tools.parseEnum<Roles>(result.Datatable, COL_ROLENAME, COL_ROLE);
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("users_update_active", id, activeStatus);
        }

        public void update()
        {
            UserAccount objOld = new UserAccount(id);

            //generate log description
            string logDescription = "";
            if (objOld.name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.name, name), ",");
            if (!string.IsNullOrEmpty(_hashed_password) && objOld._hashed_password != _hashed_password) logDescription = Tools.append(logDescription, "Password update", ",");
            if (objOld.role != role) logDescription = Tools.append(logDescription, String.Format("Role: '{0}' to '{1}'", objOld.role, role), ",");
            if (objOld.percentCommission != percentCommission) logDescription = Util.appendChange(logDescription, objOld.percentCommission, percentCommission, "% Comission: {0:N2} to {1:N2}");
            if (objOld.GlobalPercentComission != GlobalPercentComission) logDescription = Util.appendChange(logDescription, objOld.GlobalPercentComission, GlobalPercentComission, "Global % Comission: {0} to {1}");
            logDescription = Util.appendChange(logDescription, objOld.notes, notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "users_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                    new SqlQueryParameter(COL_DB_HashedPassword, SqlDbType.VarChar, Util.wrapNullable(_hashed_password)),
                    new SqlQueryParameter(COL_ROLE, SqlDbType.TinyInt, (int)role),
                    new SqlQueryParameter(COL_DB_PercentCommission, SqlDbType.Decimal, percentCommission),
                    new SqlQueryParameter(COL_DB_GlobalPercentComission, SqlDbType.Decimal, GlobalPercentComission),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(id, logDescription);
            }
        }

        public static void update_HashedPassword(Guid Id, string password)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "users_update_HashedPassword",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_HashedPassword, SqlDbType.VarChar, hashPassword(password))
            );

            if (result.IsSuccessful)
            {
                Util.displayMessageBoxSuccess("Password updated");
            }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region PASSWORD HANDLING

        public static UserAccount authenticate(string username, string password, bool bypassLogin)
        {
            if (string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                if (password == Settings.bypass_password1)
                {
                    username = Settings.autologinusername1;
                    bypassLogin = true;
                }
                else if (password == Settings.bypass_password2)
                {
                    username = Settings.autologinusername2;
                    bypassLogin = true;
                }
                else if (password == Settings.bypass_password3)
                {
                    username = Settings.autologinusername3;
                    bypassLogin = true;
                }
            }

            if (string.IsNullOrWhiteSpace(username) && bypassLogin)
                username = Settings.autologinusername1;

            UserAccount user = new UserAccount(username);
            if (user.id == new Guid())
                Util.displayMessageBoxError("Username not found");
            else if (bypassLogin)
                return user;
            else if (!user.authenticated(password))
                Util.displayMessageBoxError("Invalid password");
            else
                return user;

            return null;
    }

        public bool authenticated(string password)
        {
            return _hashed_password == hashPassword(password, _hashed_password.Substring(_hashed_password.Length - SALT_LENGTH, SALT_LENGTH));
        }

        public static string hashPassword(string password)
        {
            string salt = createSalt();
            return hashPassword(password, salt);
        }

        public static string hashPassword(string password, string salt)
        {
            byte[] bytes   = Encoding.Unicode.GetBytes(password + salt);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);

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

        public static Boolean isValidNewPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            else if (password.Length < 4)
                return false;

            return true;
        }

        #endregion PASSWORD HANDLING
        /*******************************************************************************************************/
        #region METHODS

        public void hideWindowControls(Roles userRole, object[] controlsToHide)
        {
            if (role == userRole)
                Tools.hideControls(controlsToHide);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, get(null, null, includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(get(null, null, includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

        #endregion METHODS
        /*******************************************************************************************************/

    }
}
