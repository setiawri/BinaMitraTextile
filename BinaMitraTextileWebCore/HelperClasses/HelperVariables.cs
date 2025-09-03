using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BinaMitraTextileWebCore.Controllers;
using BinaMitraTextileWebCore.Models;
using LibCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;

namespace BinaMitraTextileWebCore
{
	public class HelperVariables
	{
		public static string[] badgeColors = {
			"badge-primary",				"badge-info",				"badge-success",				"badge-dark",				"badge-warning",				"badge-danger",
            "badge-primary badge-outline",	"badge-info badge-outline", "badge-success badge-outline",	"badge-dark badge-outline", "badge-warning badge-outline",	"badge-danger badge-outline",
            "badge-light-primary",			"badge-light-info",			"badge-light-success",			"badge-light-dark",			"badge-light-warning",			"badge-light-danger",
        };

		/* PUBLIC PROPERTIES **********************************************************************************************************************************/

		public const string APP_VERSION = "v2506291";
		public const bool UPDATE_JS_FILES = true;

		public const string COMPANYNAME_SHORT = "iSpeak";
		public const string COMPANYNAME = "Bina Mitra Textile";
		public const string WEBSITEURL = "http://www.ispeakgroup.com";

		public const string IMAGEFOLDERURL = "/appresources/images/";
		public const string IMAGEFOLDERPATH = "~" + IMAGEFOLDERURL;
		public const string NOIMAGEFILE = "no-image.jpg";

		public const string IMAGEUPLOADFOLDER = "/appresources/images/uploads/";
		public const string IMAGEUPLOADPATH = "~" + IMAGEUPLOADFOLDER;

		public const string filepath_Logo_I = IMAGEFOLDERPATH + "iLogoOutlined.ico";
		public const string filepath_Logo_I_Thin = IMAGEFOLDERPATH + "iLogoOutlinedThin.png";
		public const string filepath_Logo = IMAGEFOLDERPATH + "Logo 1025x440.png";
		public const string filepath_LogoOutlined = IMAGEFOLDERPATH + "Logo-Outlined 1025x440.png";

		/* TEXTS **********************************************************************************************************************************************/

		public const string BUTTONTEXT_SIGNIN = "Sign In";
        public const string BUTTONTID_LOAD = "LoadButton";
        public const string BUTTONTEXT_LOAD = "Load";
        public const string BUTTONTEXT_OPENMODULE = "OPEN MODULE";
        public const string BUTTONTEXT_FILTERAPPLY = "Apply";
        public const string BUTTONTEXT_CREATE = "Create";
		public const string BUTTONTEXT_SAVE = "Save";
        public const string BUTTONTEXT_SUBMIT = "Submit";
        public const string BUTTONTEXT_CANCEL = "Cancel";
		public const string BUTTONTEXT_PAYMENT = "Payment";
        public const string BUTTONTEXT_PAY = "Pay";
        public const string BUTTONTEXT_AddNewAccount = "Add new account";
        public const string BUTTONTEXT_AddItemToList = "Add item to list";
		public const string BUTTONTEXT_AddToList = "Add to list";
        public const string BUTTONTEXT_GenerateFullTimePayroll = "Generate Fulltime Payroll";
        public const string BUTTONTEXT_AddManual = "Add Manual";

        public const string FILTERPLACEHOLDER_DROPDOWNLIST_PleaseSelect = "Please Select";

        public const string NAVIGATION_MENU_Home = "Home";
        public const string NAVIGATION_MENU_Settings = "Settings";
        public const string NAVIGATION_MENU_Internal = "Internal";
        public const string NAVIGATION_MENU_Sales = "Sales";

        public const string NAVIGATION_SUBMENU_Reports = "Reports";

        public const string USERPROFILE_SignOut = "Sign Out";
        public const string USERPROFILE_ChangePassword = "Change Password";

        public const string TABLEITEMSTATUS_Active = "ACTIVE";
        public const string TABLEITEMSTATUS_Inactive = "INACTIVE";
        public const string TABLEITEMSTATUS_Cancelled = "CANCELLED";
        public const string TABLEITEMSTATUS_DEFAULT = "DEFAULT";
        public const string TABLEITEMSTATUS_Yes = "YES";
        public const string TABLEITEMSTATUS_No = "NO";

        public const string TABLEACTIONMENU_Edit = "Edit";
        public const string TABLEACTIONMENU_Log = "Log";
        public const string TABLEACTIONMENU_Details = "Details";
        public const string TABLEACTIONMENU_Payment = "Payment";
        public const string TABLEACTIONMENU_Print = "Print";
        public const string TABLEACTIONMENU_Cancel = "Cancel";
        public const string TABLEACTIONMENU_ResetPassword = "Reset Password";

		public const string FILTER_Branches_Id = "Branches_Id";
		public const string FILTER_DatePeriod = "FILTER_DatePeriod";

		public const string FILTERTITLE = "Filter";
        public const string FILTER_EmptyValueText_All = "All";
        public const string FILTER_EmptyValueText_Incomplete = "Incomplete";
        public const string FILTER_CheckboxText_All = "All";
        public const string FILTERTITLE_Months = "Months";
        public const string FILTER_Months = "FILTER_Months";

        public const string FILTER_ReferenceId = "FILTER_ReferenceId";

		public const string FILTER_Keyword = "FILTER_Keyword";
        public const string FILTERPLACEHOLDER_FILTER_Keyword = "keyword";

        public const string FILTER_Active = "FILTER_Active";
        public const string FILTERTITLE_FILTER_Active = "Active";

        public const string FILTER_Status = "FILTER_Status";
        public const string FILTERTITLE_FILTER_Status = "Status";
        public const string FILTER_AllStatus = "FILTER_AllStatus";

        public const string FILTER_Cancelled = "FILTER_Cancelled";
        public const string FILTERTITLE_FILTER_Cancelled = "Cancelled";

        public const string FILTER_Approved = "FILTER_Approved";
        public const string FILTERTITLE_FILTER_Approved = "Approved";

        public const string FILTER_HasDueAmount = "FILTER_HasDueAmount";
        public const string FILTERTITLE_FILTER_HasDueAmount = "Has Due";

        public const string FILTERTITLE_DateRange = "Date range";
        public const string FILTER_DateFrom = "FILTER_DateFrom";
        public const string FILTERPLACEHOLDER_FILTER_DateFrom = "start date";
        public const string FILTER_DateTo = "FILTER_DateTo";
        public const string FILTERPLACEHOLDER_FILTER_DateTo = "end date";

        /* DATABASE INFORMATION *******************************************************************************************************************************/

        protected const string DBNAME = "BinaMitraTextile";

		protected const string SERVERNAME_LIVE = "192.168.100.100"; // "43.255.152.25"; //182.50.132.53
		protected const string USERID_LIVE = "binamitra";
		protected const string PASSWORD_LIVE = "B1naMitra";

		public const string DEVCOMPUTERNAME = "RQ";
		protected const string SERVERNAME_DEV = @".";
		protected const string USERID_DEV = "WebApp";
		protected const string PASSWORD_DEV = "q1w2e3";

        public static int SQLCOMMANDTIMEOUT = 300;

        protected const bool ConnectToLiveDB = false;
		public static string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(DBConnection.ConnectionString))
				{
                    DBConnection.ConnectionString = DBConnection.BuildConnectionString(
                            DBNAME,
                            Environment.MachineName == DEVCOMPUTERNAME && !ConnectToLiveDB ? SERVERNAME_DEV : SERVERNAME_LIVE,
                            Environment.MachineName == DEVCOMPUTERNAME ? USERID_DEV : PASSWORD_LIVE,
                            Environment.MachineName == DEVCOMPUTERNAME ? PASSWORD_DEV : PASSWORD_LIVE,
                            "Integrated Security=False;Persist Security Info=False;Trust Server Certificate=True;",
                            SQLCOMMANDTIMEOUT
                        );
                }

                return DBConnection.ConnectionString;
			}
		}

		/******************************************************************************************************************************************************/
	}
}
