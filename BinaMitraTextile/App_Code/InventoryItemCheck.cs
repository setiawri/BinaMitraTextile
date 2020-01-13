using System;
using System.Data;
using System.Data.SqlClient;
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
        public const string FILTER_TimestampStart = "FILTER_TimestampStart";
        public const string FILTER_TimestampEnd = "FILTER_TimestampEnd";

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
            using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_isExistToday", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcodeWithoutPrefix;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;
                
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static string submitNew(string barcodeWithoutPrefix, bool isManualInput, bool ignoreSold, string itemLocation)
        {
            if (barcodeWithoutPrefix.Length != Settings.itemBarcodeLength)
                return barcodeWithoutPrefix + " is not a valid item barcode";

            try
            {
                using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    cmd.Parameters.Add("@BarcodeWithoutPrefix", SqlDbType.VarChar).Value = barcodeWithoutPrefix;
                    cmd.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                    cmd.Parameters.Add("@" + COL_DB_MANUALINPUT, SqlDbType.Bit).Value = isManualInput;
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
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_getall", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = (object)dateEnd ?? DBNull.Value;
                cmd.Parameters.Add("@" + FILTER_IncludeIgnoreSold, SqlDbType.Bit).Value = includeIgnoreSold;
                if (!isAllUsers)
                    cmd.Parameters.Add("@Users_Id", SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getSummary(DateTime? dateStart, DateTime? dateEnd, bool isAllUsers)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_get_summary", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = (object)dateEnd ?? DBNull.Value;
                if (!isAllUsers)
                    cmd.Parameters.Add("@Users_Id", SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtCompilation = Sale.compileSummaryData(dt);

            foreach (DataRow dr in dtCompilation.Rows)
            {
                dr[COL_COUNT_DIFF_QTY] = Convert.ToInt16(dr[InventoryItem.COL_SALE_QTY]) - Convert.ToInt16(dr[COL_COUNT_AVAILABLE_QTY]);
                dr[COL_COUNT_DIFF_LENGTH] = Convert.ToDecimal(dr[InventoryItem.COL_LENGTH]) - Convert.ToDecimal(dr[COL_COUNT_AVAILABLE_ITEM_LENGTH]);
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
            try
            {
                using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_deletetodaydata", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        public static void deleteIgnoreSold()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_deleteignoresold", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
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
            using (SqlCommand cmd = new SqlCommand("inventoryitemcheck_cleanup", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable getMissing(DateTime? timestampStart)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "InventoryItemCheck_getMissing",
                    new SqlQueryParameter(FILTER_TimestampStart, SqlDbType.DateTime, timestampStart)
                );
            return result.Datatable;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/

    }
}
