using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

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
        #region DATABASE STATIC METHODS

        public static bool isPONoExist(string poNo)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "po_isPONoExist",
                new SqlQueryParameter(COL_DB_PONO, SqlDbType.VarChar, poNo)
                );
            return result.ValueBoolean;
        }

        public static string getNextPONo()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                true, false, false, false, false,
                "po_get_nextpono"
                );
            return result.ValueString;
        }

        public static DataTable get(Guid ID)
        {
            return get(ID, null, null,null,null,null,null,null, false);
        }

        public static DataTable get(Guid? id, string poNo, Guid? vendorID, DateTime? dtStart, DateTime? dtEnd, Guid? productStoreNameID, string invoiceNo, string packingListNo, bool showIncompleteOnly)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "po_get_by_filter",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_PONO, SqlDbType.VarChar, Util.wrapNullable(poNo)),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID)),
                new SqlQueryParameter("date_start", SqlDbType.DateTime, Util.wrapNullable(dtStart)),
                new SqlQueryParameter("date_end", SqlDbType.DateTime, Util.wrapNullable(dtEnd)),
                new SqlQueryParameter("productstorename_id", SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID)),
                new SqlQueryParameter("vendorinvoice_no", SqlDbType.VarChar, invoiceNo),
                new SqlQueryParameter("packinglist_no", SqlDbType.VarChar, packingListNo),
                new SqlQueryParameter("po_status_completed", SqlDbType.TinyInt, POItemStatus.Completed),
                new SqlQueryParameter("po_status_cancelled", SqlDbType.TinyInt, POItemStatus.Cancelled),
                new SqlQueryParameter("show_incomplete_only", SqlDbType.Bit, showIncompleteOnly)
            );
            return result.Datatable;
        }

        public static Guid? submitNew(Guid id, Guid vendorID, string vendorInfo, List<POItem> items, string notes, DateTime targetDate, string poNo)
        {
            //format notes
            if (string.IsNullOrWhiteSpace(notes))
                notes = null;
            else
                notes = string.Format("{0:MM/dd/yy}-{1}: {2}", DateTime.Now, GlobalData.UserAccount.name, notes);

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "po_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, vendorID),
                new SqlQueryParameter(COL_DB_VENDORINFO, SqlDbType.VarChar, vendorInfo),
                new SqlQueryParameter(COL_DB_TARGETDATE, SqlDbType.Date, targetDate),
                new SqlQueryParameter(COL_DB_PONO, SqlDbType.VarChar, poNo),
                new SqlQueryParameter(COL_DB_USERID, SqlDbType.UniqueIdentifier, GlobalData.UserAccount.id),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes)
            ));

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(id, "Added");

                //submit items
                POItem.submitItems(items);

                return id;
            }
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
