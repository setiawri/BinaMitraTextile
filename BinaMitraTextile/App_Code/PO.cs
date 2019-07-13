using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    public class PO
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES

        public Guid ID;
        public DateTime Timestamp;
        public Guid VendorID;
        public string VendorInfo;
        public string Notes;
        public DateTime TargetDate;
        public string PONo;
        public Guid UserID;

        public DataTable Items;
        public decimal Amount;

        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES        
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_ID = "id";
        public const string COL_DB_TIMESTAMP = "time_stamp";
        public const string COL_DB_VENDORID = "vendor_id";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_TARGETDATE = "target_date";
        public const string COL_DB_PONO = "po_no";
        public const string COL_DB_VENDORINFO = "vendor_info";
        public const string COL_DB_USERID = "user_id";

        public const string COL_AMOUNT = "amount"; 
        public const string COL_VENDORNAME = "vendor_name";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public PO(Guid id)
        {
            ID = id;
            DataRow row = get(ID).Rows[0];
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_TIMESTAMP);
            TargetDate = DBUtil.parseData<DateTime>(row, COL_DB_TARGETDATE);
            UserID = DBUtil.parseData<Guid>(row, COL_DB_USERID);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
            VendorID = DBUtil.parseData<Guid>(row, COL_DB_VENDORID);
            VendorInfo = DBUtil.parseData<string>(row, COL_DB_VENDORINFO);
            PONo = DBUtil.parseData<string>(row, COL_DB_PONO);

            Items = POItem.getItems(ID);
            Amount = Convert.ToDecimal(Items.Compute(String.Format("SUM({0})", POItem.COL_SUBTOTAL), ""));
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static bool isPONoExist(string poNo)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("po_isPONoExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_PONO, SqlDbType.VarChar).Value = poNo;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static string getNextPONo()
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("po_get_nextpono", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return return_value.Value.ToString();
            }
        }

        public static DataTable get(Guid ID)
        {
            return get(ID, null, null,null,null,null,null,null, false);
        }

        public static DataTable get(Guid? id, string poNo, Guid? vendorID, DateTime? dtStart, DateTime? dtEnd, Guid? productStoreNameID, string invoiceNo, string packingListNo, bool showIncompleteOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("po_get_by_filter", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrEmpty(poNo)) cmd.Parameters.Add("@" + COL_DB_PONO, SqlDbType.VarChar).Value = poNo;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dtStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dtEnd);
                cmd.Parameters.Add("@productstorename_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                cmd.Parameters.Add("@vendorinvoice_no", SqlDbType.VarChar).Value = invoiceNo;
                cmd.Parameters.Add("@packinglist_no", SqlDbType.VarChar).Value = packingListNo;
                cmd.Parameters.Add("@po_status_completed", SqlDbType.TinyInt).Value = POItemStatus.Completed;
                cmd.Parameters.Add("@po_status_cancelled", SqlDbType.TinyInt).Value = POItemStatus.Cancelled;
                cmd.Parameters.Add("@show_incomplete_only", SqlDbType.Bit).Value = showIncompleteOnly;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static string submitNew(Guid id, Guid vendorID, string vendorInfo, List<POItem> items, string notes, DateTime targetDate, string poNo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                {
                    //submit new sale record
                    using (SqlCommand cmd = new SqlCommand("po_new", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                        cmd.Parameters.Add("@" + COL_DB_VENDORINFO, SqlDbType.VarChar).Value = vendorInfo;
                        cmd.Parameters.Add("@" + COL_DB_TARGETDATE, SqlDbType.Date).Value = targetDate;
                        cmd.Parameters.Add("@" + COL_DB_PONO, SqlDbType.VarChar).Value = poNo;
                        cmd.Parameters.Add("@" + COL_DB_USERID, SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                        if(!string.IsNullOrEmpty(notes)) cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = string.Format("{0:MM/dd/yy HH:mm} - {1}: {2}", DateTime.Now, GlobalData.UserAccount.name, notes);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(conn, id, "Item created");
                    }

                    //submit items
                    POItem.submitItems(conn, items);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static List<POItem> generateItemList(DataTable dt)
        {
            List<POItem> items = new List<POItem>();


            return items;
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
