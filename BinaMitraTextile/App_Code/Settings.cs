﻿using System;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    class Settings
    {
        public static string autologinusername = "";

        public static string bypass_password1 = "qef";
        public static string autologinusername1 = "ricky";
        public static string bypass_password2 = "adf";
        public static string autologinusername2 = "lixia";
        public static string bypass_password3 = "zcv";
        public static string autologinusername3 = "userricky";

        public const bool SQLCONNECTION_MULTIPLEUSE = true;

        /*******************************************************************************************************/
        #region APP VERSION

        public const string APPVERSION = "v220516";
        private static Guid GUID_LatestAppVersion = new Guid("C1552CB9-E157-4925-897E-904180379BFE");

        public static string LatestAppVersion { 
            get { return getStringValue(GUID_LatestAppVersion); } 
            set { update(GUID_LatestAppVersion, value); } 
        }

        public static bool hasLatestAppVersion()
        {
            return true; //disable so sales pc doesn't need to have the latest version

            //string latestVersion = LatestAppVersion;
            //if (latestVersion == APPVERSION)
            //    return true;
            //else if (String.Compare(LatestAppVersion, APPVERSION) < 0)
            //{
            //    LatestAppVersion = APPVERSION;
            //    return true;
            //}
            //else
            //    return Util.displayMessageBoxError("Please update app version to " + latestVersion);
        }

        #endregion APP VERSION
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //barcode printing
        private static Guid GUID_LastSheetNo = new Guid("0ce05420-c0ab-4cce-86e8-cb9aad787276");
        private static Guid GUID_LastStartHexNo = new Guid("d1ae33ec-4ae5-465a-b896-bd454559ab9f");
        private static Guid GUID_OffsetX = new Guid("6BA57BBD-DC44-4295-88C0-47292C1D8B26");
        private static Guid GUID_OffsetY = new Guid("9630BE8A-01A3-4363-9E63-2DF17DB2339C");

        //Sale Payment
        private static Guid GUID_SalePayment_MoneyAccounts_Id = new Guid("388DD793-937D-44E6-AB53-F7ED79B264BC");
        private static Guid GUID_SalePayment_MoneyAccountCategoryAssignments_Id_Cash = new Guid("C17F446E-0DD6-4A55-B4E2-43235182E590");
        private static Guid GUID_SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe = new Guid("8493D84B-F1CA-4155-BF31-31A692C42BF7");
        private static Guid GUID_MoneyAccountCategories_Id_PenjualanTunai = new Guid("4507866B-48B7-4C14-9FD5-2F17E08F8221");

        //sql connection
        private static Guid GUID_LastConnectedPortNo = new Guid("06AFBB4E-F66B-42A0-96A7-0B5705629248");

        #endregion
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public static Guid GUID_LastOpnameCleanupDate = new Guid("AB6E91C0-1744-4101-BDFA-4F5CC362E04B");

        public const string APPSETTINGSKEY_LiveConnectionPort = "LiveConnectionPort";

        public static string CONNECTIONSTRING_DEFAULTPARAMS = "Integrated Security=False;Persist Security Info=False;";
        public const string SQL_USERNAME = "binamitra";
        public const string SQL_PASSWORD = "binamitra";
        public const string SQL_DATABASENAME = "BinaMitraTextile";

        public static System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(Properties.Resources.Notification01);
        public static System.Media.SoundPlayer nonBarcodeScannerSound = new System.Media.SoundPlayer(Properties.Resources.Notification02);
        public static System.Media.SoundPlayer opnameMarkerSound = new System.Media.SoundPlayer(Properties.Resources.Notification03);

        public static System.Drawing.Icon taskbarIcon = Properties.Resources.handshake_512_white;
        //public static System.Drawing.Icon headerIcon = Properties.Resources.handshake_512_black;

        public const int GRIDVIEW_MINIMUM_RIGHT_MARGIN_TO_CONTAINER = 10;

        public static string itemBarcodeMandatoryPrefix = ConfigurationManager.AppSettings["itemBarcodeMandatoryPrefix"].ToUpper();
        public static int itemBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["itemBarcodeLength"]);
        public static int itemBarcodeTotalLength = itemBarcodeMandatoryPrefix.Length + itemBarcodeLength;
        public static int saleBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["saleBarcodeLength"]);
        public static int gordenOrderBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["gordenOrderBarcodeLength"]);
        public static int barcodeScannerDelay = Convert.ToInt16(ConfigurationManager.AppSettings["barcodeScannerDelay"]);

        public const int BUTTON_GAP = 5;
        public const int GRIDVIEW_VSCROLLBAR_SPACE = 18;

        public const string localFileFolderName = "DownloadedServerFiles";
        public static string getUploadStoragePath()
        {
            return ConfigurationManager.AppSettings["uploadStorage"];
        }
                
        public static string LastSheetNo
        {
            get { return getStringValue(GUID_LastSheetNo); }
            set { update(GUID_LastSheetNo, value); }
        }
                
        public static string LastStartHexNo
        {
            get { return getStringValue(GUID_LastStartHexNo); }
            set { update(GUID_LastStartHexNo, value); }
        }
                
        public static int OffsetX
        {
            get { return getIntValue(GUID_OffsetX, 0); }
            set { update(GUID_OffsetX, value); }
        }
                
        public static int OffsetY
        {
            get { return getIntValue(GUID_OffsetY, 0); }
            set { update(GUID_OffsetY, value); }
        }
                
        public static DateTime LastOpnameCleanupDate
        {
            get {
                string value = getStringValue(GUID_LastOpnameCleanupDate);
                if (string.IsNullOrEmpty(value))
                    return DateTime.Now.AddDays(-1);
                else
                {
                    //System.Globalization.DateTimeFormatInfo usCinfo = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name, false).DateTimeFormat;
                    //DateTime fromDate = Convert.ToDateTime(value, usCinfo);


                    return Convert.ToDateTime(value);
                }
            }
            set { update(GUID_LastOpnameCleanupDate, value); }
        }
                
        public static ConnectionPorts? LastConnectedPortNo
        {
            get {
                string lastConnectedPortNo = Util.getAppData(GUID_LastConnectedPortNo.ToString());
                if (string.IsNullOrEmpty(lastConnectedPortNo))
                    return null;
                else
                    return (ConnectionPorts)Enum.Parse(typeof(ConnectionPorts), lastConnectedPortNo);
            }
            set { Util.saveAppData(GUID_LastConnectedPortNo.ToString(), value.ToString()); }
        }

        /*******************************************************************************************************
         * SALE PAYMENT
         *******************************************************************************************************/
                
        public static Guid? SalePayment_MoneyAccounts_Id
        {
            get { return getGuidValue(GUID_SalePayment_MoneyAccounts_Id); }
            set { update(GUID_SalePayment_MoneyAccounts_Id, value); }
        }
                
        public static Guid? SalePayment_MoneyAccountCategoryAssignments_Id_Cash
        {
            get { return getGuidValue(GUID_SalePayment_MoneyAccountCategoryAssignments_Id_Cash); }
            set { update(GUID_SalePayment_MoneyAccountCategoryAssignments_Id_Cash, value); }
        }
        
        public static Guid? SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe
        {
            get { return getGuidValue(GUID_SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe); }
            set { update(GUID_SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe, value); }
        }

        public static Guid? MoneyAccountCategories_Id_PenjualanTunai
        {
            get { return getGuidValue(GUID_MoneyAccountCategories_Id_PenjualanTunai); }
            set { update(GUID_MoneyAccountCategories_Id_PenjualanTunai, value); }
        }

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region METHODS

        public static void setGeneralSettings(Form form)
        {
            form.Icon = taskbarIcon;
        }

        public static int getIntValue(Guid GUID, int defaultValue)
        {
            DataRow row = get(GUID);
            if (row == null)
                return defaultValue;
            else
                return Convert.ToInt32(row[COL_DB_Value_Int]);
        }

        public static string getStringValue(Guid GUID)
        {
            DataRow row = get(GUID);
            if (row == null)
                return "";
            else
                return row[COL_DB_Value_String].ToString();
        }

        public static Guid? getGuidValue(Guid GUID)
        {
            string value = getStringValue(GUID);
            if (string.IsNullOrEmpty(value))
                return null;
            else
                return new Guid(value);
        }

        public static bool getBoolValue(Guid GUID)
        {
            if (getIntValue(GUID, 0) == 0)
                return false;
            else
                return true;
        }

        public static DateTime? getDateTimeValue(Guid GUID)
        {
            DataRow row = get(GUID);
            if (row == null)
                return null;
            else
                return Util.wrapNullable<DateTime?>(row[COL_DB_Value_DateTime]);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Value_Int = "Value_Int";
        public const string COL_DB_Value_String = "Value_String";
        public const string COL_DB_Value_DateTime = "Value_DateTime";

        #endregion DATABASE FIELDS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static DataRow get(Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Settings_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(id))
                );
            return Util.getFirstRow(result.Datatable);
        }

        public static void update(Guid id, int value) { update(id, value, null, null, null); }
        public static void update(Guid id, string value) { update(id, null, value, null, null); }
        public static void update(Guid id, Guid? value) { update(id, null, value.ToString(), null, null); }
        public static void update(Guid id, bool value) { update(id, null, null, value, null); }
        public static void update(Guid id, DateTime? value) { update(id, null, null, null, value); }
        public static void update(Guid id, int? intValue, string stringValue, bool? boolValue, DateTime? datetimeValue)
        {
            if (boolValue != null)
                intValue = Util.convertToInt((bool)boolValue);

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Settings_update",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Value_Int, SqlDbType.Int, Util.wrapNullable(intValue)),
                new SqlQueryParameter(COL_DB_Value_String, SqlDbType.VarChar, Util.wrapNullable(stringValue)),
                new SqlQueryParameter(COL_DB_Value_DateTime, SqlDbType.DateTime, Util.wrapNullable(datetimeValue))
            );
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
    }
}
