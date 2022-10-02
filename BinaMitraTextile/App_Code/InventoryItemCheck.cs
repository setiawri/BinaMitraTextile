using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LIBUtil;

namespace BinaMitraTextile
{
    public class InventoryItemCheck
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public const string COL_DB_ID = "id";
        public const string COL_DB_INVENTORYITEMID = "inventory_item_id";
        public const string COL_DB_IgnoreSold = "IgnoreSold";
        public const string COL_DB_MANUALINPUT = "manual_input";
        public const string COL_DB_ItemLocation = "ItemLocation";

        public const string COL_TIMESTAMP = "time_stamp";
        public const string COL_TAGPRICE = "sell_price";
        public const string COL_OPNAMEMARKER = Inventory.COL_DB_OpnameMarker;

        public const string COL_COUNT_QTY = "qty";
        public const string COL_COUNT_ITEMLENGTH = "item_length";
        public const string COL_INVENTORYID = "inventory_id";

        public const string COL_COUNT_DIFF_QTY = "diff_qty";
        public const string COL_COUNT_DIFF_LENGTH = "diff_length";

        public const string COL_COUNT_AVAILABLE_QTY = "available_qty";
        public const string COL_COUNT_AVAILABLE_ITEM_LENGTH = "available_item_length";

        public const string COL_SUMMARY_TOTALLENGTH = "";
        public const string COL_SUMMARY_TOTALQTY = "";

        public const string COL_BARCODE = "barcode";

        public const string FILTER_IncludeIgnoreSold = "IncludeIgnoreSold";
        public const string FILTER_RescanToday = "RescanToday";
        public const string FILTER_TimestampStart = "FILTER_TimestampStart";
        public const string FILTER_TimestampEnd = "FILTER_TimestampEnd";
        public const string FILTER_DateStart = "date_start";
        public const string FILTER_DateEnd = "date_end";

        public const string ARRAY_Grades_Id = "ARRAY_Grades_Id";

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS
        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static bool isSubmittedToday(string barcodeWithoutPrefix)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "inventoryitemcheck_isExistToday",
                new SqlQueryParameter(COL_BARCODE, SqlDbType.VarChar, barcodeWithoutPrefix)
                );
            return result.ValueBoolean;
        }

        public static string submitNew(string barcodeWithoutPrefix, bool isManualInput, bool rescanToday, bool ignoreSold, string itemLocation)
        {
            if (barcodeWithoutPrefix.Length != Settings.itemBarcodeLength && barcodeWithoutPrefix.Length != Settings.itemBarcodeLength+3)
                return barcodeWithoutPrefix + " is not a valid item barcode";

            try
            {
                using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_new", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    cmd.Parameters.Add("@BarcodeWithoutPrefix", SqlDbType.VarChar).Value = barcodeWithoutPrefix;
                    cmd.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                    cmd.Parameters.Add("@" + COL_DB_MANUALINPUT, SqlDbType.Bit).Value = isManualInput;
                    cmd.Parameters.Add("@" + FILTER_RescanToday, SqlDbType.Bit).Value = rescanToday;
                    cmd.Parameters.Add("@" + COL_DB_IgnoreSold, SqlDbType.Bit).Value = ignoreSold;
                    cmd.Parameters.Add("@" + COL_DB_ItemLocation, SqlDbType.VarChar).Value = itemLocation;
                    SqlParameter InventoryItems_id = cmd.Parameters.Add("@InventoryItems_id", SqlDbType.UniqueIdentifier);
                    InventoryItems_id.Direction = ParameterDirection.Output;
                    SqlParameter opnameMarker = cmd.Parameters.Add("@opnameMarker", SqlDbType.Bit);
                    opnameMarker.Direction = ParameterDirection.Output;
                    SqlParameter inventoryCode = cmd.Parameters.Add("@inventory_code", SqlDbType.VarChar, 10);
                    inventoryCode.Direction = ParameterDirection.Output;
                    SqlParameter itemLength = cmd.Parameters.Add("@item_length", SqlDbType.Int);
                    itemLength.Direction = ParameterDirection.Output;
                    SqlParameter errorcodevalue = cmd.Parameters.Add("@errorcode", SqlDbType.TinyInt);
                    errorcodevalue.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int errorcode = Convert.ToInt32(errorcodevalue.Value);
                    if (errorcode > 0)
                    {
                        if (errorcode == 1)
                            return barcodeWithoutPrefix + " is not found in database";
                        if (errorcode == 2)
                            return barcodeWithoutPrefix + " is already scanned today";
                        if (errorcode == 3 && !ignoreSold)
                            return barcodeWithoutPrefix + " is already sold";
                    }

                    ActivityLog.submit(new Guid(InventoryItems_id.Value.ToString()), "Opname");

                    Tools.displayForm(new SharedForms.Verify_Form(inventoryCode.Value.ToString(), itemLength.Value.ToString(), (decimal)(.5)));
                    if (Convert.ToBoolean(opnameMarker.Value))
                        Settings.opnameMarkerSound.Play();
                    else
                        Settings.notificationSound.Play();
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static DataTable getAll(DateTime? dateStart, DateTime? dateEnd, bool isAllUsers, bool includeIgnoreSold)
        {
            Guid? userfilter = GlobalData.UserAccount.id;
            if (isAllUsers)
                userfilter = null;

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "inventoryitemcheck_getall",
                new SqlQueryParameter(FILTER_DateStart, SqlDbType.DateTime, Util.wrapNullable(dateStart)),
                new SqlQueryParameter(FILTER_DateEnd, SqlDbType.DateTime, Util.wrapNullable(dateEnd)),
                new SqlQueryParameter(FILTER_IncludeIgnoreSold, SqlDbType.Bit, includeIgnoreSold),
                new SqlQueryParameter("Users_Id", SqlDbType.UniqueIdentifier, Util.wrapNullable(userfilter))
            );
            return result.Datatable;
        }

        public static DataTable getSummary(DateTime? dateStart, DateTime? dateEnd, bool isAllUsers)
        {
            Guid? userfilter = GlobalData.UserAccount.id;
            if (isAllUsers)
                userfilter = null;

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "inventoryitemcheck_get_summary",
                new SqlQueryParameter(FILTER_DateStart, SqlDbType.DateTime, Util.wrapNullable(dateStart)),
                new SqlQueryParameter(FILTER_DateEnd, SqlDbType.DateTime, Util.wrapNullable(dateEnd)),
                new SqlQueryParameter("Users_Id", SqlDbType.UniqueIdentifier, Util.wrapNullable(userfilter))
            );
            return result.Datatable;
        }

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtCompilation = Sale.compileSummaryData(dt);

            foreach (DataRow dr in dtCompilation.Rows)
            {
                dr[COL_COUNT_DIFF_QTY] = Convert.ToInt16(dr[InventoryItem.COL_SALE_QTY]) - Convert.ToInt16(dr[COL_COUNT_AVAILABLE_QTY]);
                dr[COL_COUNT_DIFF_LENGTH] = Convert.ToDecimal(dr[InventoryItem.COL_DB_LENGTH]) - Convert.ToDecimal(dr[COL_COUNT_AVAILABLE_ITEM_LENGTH]);
            }

            return dtCompilation;
        }

        public static DataTable compileCompleteData(DataTable dtDetail)
        {
            string col_sold = "sold";
            Tools.addColumn<bool>(dtDetail, col_sold, 0);
            Tools.setDataTablePrimaryKey(dtDetail, InventoryItemCheck.COL_DB_INVENTORYITEMID);

            DataTable dtCompilation = Inventory.getAll(false);
            Tools.addColumn<int>(dtCompilation, COL_COUNT_DIFF_QTY, 0);
            Tools.addColumn<decimal>(dtCompilation, COL_COUNT_DIFF_LENGTH, 0);
            
            foreach (DataRow dr in dtCompilation.Rows)
            {
                dr[Inventory.COL_QTY] = dtDetail.Compute(string.Format("COUNT({0})", COL_COUNT_ITEMLENGTH), string.Format("inventory_id = '{0}' AND {1} = false", dr[Inventory.COL_DB_ID], col_sold));
                dr[Inventory.COL_ITEMLENGTH] = dtDetail.Compute(string.Format("SUM({0})", COL_COUNT_ITEMLENGTH), string.Format("inventory_id = '{0}' AND {1} = false", dr[Inventory.COL_DB_ID], col_sold));

                //DataRow drSold = dtSoldItems.Rows.Find(dr[Inventory.COL_DB_ID]);
                //if (drSold != null)
                //{
                //    dr[Inventory.COL_QTY] = Convert.ToInt32(dr[Inventory.COL_QTY]) - Convert.ToInt32(drSold[Inventory.COL_QTY]);
                //    dr[Inventory.COL_ITEMLENGTH] = Convert.ToInt32(Tools.zeroNonNumericString(dr[Inventory.COL_ITEMLENGTH])) - Convert.ToInt32(drSold[Inventory.COL_ITEMLENGTH]);
                //}

                dr[COL_COUNT_DIFF_QTY] = Convert.ToInt16(dr[Inventory.COL_QTY]) - Convert.ToInt16(dr[COL_COUNT_AVAILABLE_QTY]);
                dr[COL_COUNT_DIFF_LENGTH] = Convert.ToDecimal(Tools.zeroNonNumericString(dr[Inventory.COL_ITEMLENGTH])) - Convert.ToDecimal(Tools.zeroNonNumericString(dr[COL_COUNT_AVAILABLE_ITEM_LENGTH]));
            }

            return dtCompilation;
        }

        public static void deleteTodayData()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "inventoryitemcheck_deletetodaydata"
            );
        }

        public static void deleteIgnoreSold()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "inventoryitemcheck_deleteignoresold"
            );
        }

        /// <summary><para></para></summary>
        public static void CheckCleanup()
        {
            if(lastCleanupDate == null)
            {
                lastCleanupDate = Settings.LastOpnameCleanupDate;
                if(((DateTime)lastCleanupDate).Date != DateTime.Today.Date)
                {
                    Settings.LastOpnameCleanupDate = DateTime.Now;
                    lastCleanupDate = DateTime.Now;
                    cleanup();
                }
            }
        }
        private static DateTime? lastCleanupDate = null;

        public static void cleanup()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "inventoryitemcheck_cleanup"
            );
        }

        public static DataTable getMissing(DateTime? timestampStart, DataTable dtGrades)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "InventoryItemCheck_getMissing",
                DBConnection.createTableParameters(
                    new SqlQueryTableParameterGuid(ARRAY_Grades_Id, dtGrades)
                    ),
                new SqlQueryParameter(FILTER_TimestampStart, SqlDbType.DateTime, timestampStart)
            );
            return result.Datatable;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/

    }
}
