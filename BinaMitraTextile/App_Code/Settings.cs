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
        public static string autologinusername = "ricky";

        /*******************************************************************************************************/
        #region APP VERSION

        public const string APPVERSION = "v200508";
        private static Guid GUID_LatestAppVersion = new Guid("C1552CB9-E157-4925-897E-904180379BFE");

        public static string LatestAppVersion { get { return getStringValue(GUID_LatestAppVersion); }set { update(GUID_LatestAppVersion, null, value); } }

        public static bool hasLatestAppVersion()
        {
            if (LatestAppVersion == APPVERSION)
                return true;
            else if (String.Compare(LatestAppVersion, APPVERSION) < 0)
            {
                LatestAppVersion = APPVERSION;
                return true;
            }
            else
                return false;
        }

        #endregion APP VERSION
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //barcode printing
        private static Guid GUID_LastSheetNo = new Guid("0ce05420-c0ab-4cce-86e8-cb9aad787276");
        private static Guid GUID_LastStartHexNo = new Guid("d1ae33ec-4ae5-465a-b896-bd454559ab9f");
        private static Guid GUID_OffsetX = new Guid("6BA57BBD-DC44-4295-88C0-47292C1D8B26");
        private static Guid GUID_OffsetY = new Guid("9630BE8A-01A3-4363-9E63-2DF17DB2339C");

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

        public static System.Media.SoundPlayer notificationSound = new System.Media.SoundPlayer(Properties.Resources.Notification01);
        public static System.Media.SoundPlayer nonBarcodeScannerSound = new System.Media.SoundPlayer(Properties.Resources.Notification02);
        public static System.Media.SoundPlayer opnameMarkerSound = new System.Media.SoundPlayer(Properties.Resources.Notification03);

        public static System.Drawing.Icon taskbarIcon = Properties.Resources.handshake_512_white;

        public const int GRIDVIEW_MINIMUM_RIGHT_MARGIN_TO_CONTAINER = 10;

        public static string itemBarcodeMandatoryPrefix = ConfigurationManager.AppSettings["itemBarcodeMandatoryPrefix"].ToUpper();
        public static int itemBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["itemBarcodeLength"]);
        public static int itemBarcodeTotalLength = itemBarcodeMandatoryPrefix.Length + itemBarcodeLength;
        public static int saleBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["saleBarcodeLength"]);
        public static int gordenOrderBarcodeLength = Convert.ToInt16(ConfigurationManager.AppSettings["gordenOrderBarcodeLength"]);
        public static int pettyCashNoLength = Convert.ToInt16(ConfigurationManager.AppSettings["pettyCashNoLength"]);
        public static int barcodeScannerDelay = Convert.ToInt16(ConfigurationManager.AppSettings["barcodeScannerDelay"]);

        public const int BUTTON_GAP = 5;
        public const int GRIDVIEW_VSCROLLBAR_SPACE = 18;

        public const string localFileFolderName = "DownloadedServerFiles";
        public static string getUploadStoragePath()
        {
            return ConfigurationManager.AppSettings["uploadStorage"];
        }

        /// <summary><para></para></summary>
        public static string LastSheetNo
        {
            get { return getStringValue(GUID_LastSheetNo); }
            set { update(GUID_LastSheetNo, null, value); }
        }

        /// <summary><para></para></summary>
        public static string LastStartHexNo
        {
            get { return getStringValue(GUID_LastStartHexNo); }
            set { update(GUID_LastStartHexNo, null, value); }
        }

        /// <summary><para></para></summary>
        public static int OffsetX
        {
            get { return getIntValue(GUID_OffsetX, 0); }
            set { update(GUID_OffsetX, value, null); }
        }

        /// <summary><para></para></summary>
        public static int OffsetY
        {
            get { return getIntValue(GUID_OffsetY, 0); }
            set { update(GUID_OffsetY, value, null); }
        }

        /// <summary><para></para></summary>
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
            set { update(GUID_LastOpnameCleanupDate, null, value.ToString()); }
        }

        /// <summary><para></para></summary>
        public static ConnectionPorts LastConnectedPortNo
        {
            get { return (ConnectionPorts)Enum.Parse(typeof(ConnectionPorts), Util.getAppData(GUID_LastConnectedPortNo.ToString())); }
            set { Util.saveAppData(GUID_LastConnectedPortNo.ToString(), value.ToString()); }
        }

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Value_Int = "Value_Int";
        public const string COL_DB_Value_String = "Value_String";

        #endregion DATABASE FIELDS
        /*******************************************************************************************************/
        #region METHODS

        private static int getIntValue(Guid GUID, int defaultValue)
        {
            DataRow row = get(GUID);
            if (row == null)
                return defaultValue;
            else
                return Convert.ToInt32(row[COL_DB_Value_Int]);
        }

        private static string getStringValue(Guid GUID)
        {
            DataRow row = get(GUID);
            if (row == null)
                return "";
            else
                return row[COL_DB_Value_String].ToString();
        }

        public static void setGeneralSettings(Form form)
        {
            form.Icon = taskbarIcon;
        }

        #endregion
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static DataRow get(Guid? id)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("Settings_get", DBUtil.ActiveSqlConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = LIBUtil.Util.wrapNullable(id);

                    adapter.SelectCommand = cmd;
                    adapter.Fill(datatable);
                }
            }
            catch (Exception ex) { LIBUtil.Util.displayMessageBoxError(ex.Message); }

            return LIBUtil.Util.getFirstRow(datatable);
        }

        public static void update(Guid id, int? intValue, string stringValue)
        {
            //Settings objOld = new Settings(connectionString, id);
            //string log = "";
            //if (intValue != null)
            //    log = Util.appendChange(log, objOld.Notes, intValue.ToString(), "Notes: '{0}' to '{1}'");
            //else
            //    log = Util.appendChange(log, objOld.Notes, intValue.ToString(), "Notes: '{0}' to '{1}'");            

            //if (string.IsNullOrEmpty(log))
            //{
            //    Util.displayMessageBoxError("No changes to record");
            //}
            //else
            //{
            try
            {
                using (SqlCommand cmd = new SqlCommand("Settings_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Value_Int, SqlDbType.Int).Value = LIBUtil.Util.wrapNullable(intValue);
                    cmd.Parameters.Add("@" + COL_DB_Value_String, SqlDbType.NVarChar).Value = LIBUtil.Util.wrapNullable(stringValue);

                    cmd.ExecuteNonQuery();

                    //ActivityLog.add(sqlConnection, userAccountID, id, String.Format("Updated: {0}", log));
                }
                //Util.displayMessageBoxSuccess("Changes updated");
            }
            catch (Exception ex) { LIBUtil.Util.displayMessageBoxError(ex.Message); }
            //}
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
    }
}
