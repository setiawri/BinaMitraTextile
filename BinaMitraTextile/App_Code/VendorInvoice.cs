using System;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using LIBUtil;

namespace BinaMitraTextile
{
    public enum VendorInvoiceStatus
    {
        New,
        Cancelled,
        [Description("Paid Partial")]
        PaidPartial,
        [Description("Paid Full")]
        PaidFull
    };

    public class VendorInvoice
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public DateTime Timestamp;
        public string InvoiceNo;
        public decimal Amount;
        public string Notes;
        public VendorInvoiceStatus Status;
        public int TOP;
        public Guid? FakturPajaks_Id;
        public Guid? Vendors_Id;

        public decimal CalculatedAmount;
        public string VendorName;
        public string FakturPajaks_No;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "id";
        public const string COL_DB_Timestamp = "timestamp";
        public const string COL_DB_StatusEnumID = "status_enum_id";
        public const string COL_DB_InvoiceNo = "invoice_no";
        public const string COL_DB_Notes = "notes";
        public const string COL_DB_TOP = "top";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_FakturPajaks_Id = "FakturPajaks_Id";
        public const string COL_DB_Vendors_Id = "Vendors_Id";

        public const string COL_StatusName = "status_name";
        public const string COL_CalculatedAmount = "CalculatedAmount";
        public const string COL_ReturnedValue = "ReturnedValue";
        public const string COL_AmountDifferenceFromCalculated = "AmountDifferenceFromCalculated";
        public const string COL_IsDue = "is_due";
        public const string COL_PastDue = "pastdue";
        public const string COL_PayableAmount = "PayableAmount";
        public const string COL_VendorName = "VendorName";
        public const string COL_FakturPajaks_No = "FakturPajaks_No";

        public const string FILTER_BrowsingForFakturPajak_Vendors_Id = "FILTER_BrowsingForFakturPajak_Vendors_Id";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public VendorInvoice(Guid id)
        {
            DataRow row = get(id, null, true, null, null).Rows[0];
            ID = id;
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_Timestamp);
            InvoiceNo = DBUtil.parseData<string>(row, COL_DB_InvoiceNo);
            Amount = DBUtil.parseData<decimal>(row, COL_DB_Amount);
            Notes = DBUtil.parseData<string>(row, COL_DB_Notes);
            Status = Tools.parseEnum<VendorInvoiceStatus>(DBUtil.parseData<Int16>(row, COL_DB_StatusEnumID));
            TOP = DBUtil.parseData<int>(row, COL_DB_TOP);
            FakturPajaks_Id = Util.wrapNullable<Guid?>(row, COL_DB_FakturPajaks_Id);
            Vendors_Id = Util.wrapNullable<Guid?>(row, COL_DB_Vendors_Id);

            CalculatedAmount = DBUtil.parseData<decimal>(row, COL_CalculatedAmount);
            VendorName = DBUtil.parseData<string>(row, COL_VendorName);
            FakturPajaks_No = Util.wrapNullable<string>(row, COL_FakturPajaks_No);
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static bool isInvoiceNoExist(Guid? id, string invoiceNo)
        {
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_isInvoiceNoExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_InvoiceNo, SqlDbType.VarChar).Value = invoiceNo;
                cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static Guid? get(string invoiceNumber)
        {
            Guid? id;
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_get_by_invoiceNo", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_InvoiceNo, SqlDbType.VarChar).Value = invoiceNumber;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.UniqueIdentifier);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                id = (Guid?)return_value.Value;
            }
            return id;
        }

        public static DataTable get(Guid ID)
        {
            return get(ID, null, true, null, null);
        }

        public static DataTable get_by_FakturPajaks_Id(Guid FakturPajaks_Id)
        {
            return get(null, null, true, FakturPajaks_Id, null);
        }

        public static DataTable get_by_BrowsingForFakturPajak_Vendors_Id(Guid BrowsingForFakturPajak_Customers_Id)
        {
            return get(null, null, false, null,  BrowsingForFakturPajak_Customers_Id);
        }

        public static DataTable get(Guid? id, string invoiceNumber, bool includeCompleted, Guid? FakturPajaks_Id, Guid? BrowsingForFakturPajak_Vendors_Id)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_get", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_InvoiceNo, SqlDbType.VarChar).Value = Tools.wrapNullable(invoiceNumber);
                cmd.Parameters.Add("@" + COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(FakturPajaks_Id);
                cmd.Parameters.Add("@" + FILTER_BrowsingForFakturPajak_Vendors_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(BrowsingForFakturPajak_Vendors_Id);
                cmd.Parameters.Add("@include_completed", SqlDbType.Bit).Value = includeCompleted;
                cmd.Parameters.Add("@status_completed", SqlDbType.TinyInt).Value = VendorInvoiceStatus.PaidFull;
                cmd.Parameters.Add("@status_cancelled", SqlDbType.TinyInt).Value = VendorInvoiceStatus.Cancelled;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return Tools.parseEnum<VendorInvoiceStatus>(dataTable, COL_StatusName, COL_DB_StatusEnumID);
        }

        public static Guid add(string invoiceNo, Guid Vendors_Id)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("vendorinvoice_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_InvoiceNo, SqlDbType.VarChar).Value = invoiceNo;
                    cmd.Parameters.Add("@" + COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier).Value = Vendors_Id;
                    cmd.Parameters.Add("@" + COL_DB_StatusEnumID, SqlDbType.TinyInt).Value = VendorInvoiceStatus.New;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Created");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }

            return id;
        }

        public static void updateStatus(Guid id, VendorInvoiceStatus statusEnumID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("vendorinvoice_update_status", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_StatusEnumID, SqlDbType.TinyInt).Value = statusEnumID;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Status changed to: " + statusEnumID.ToString());
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid Id, DateTime Timestamp, string InvoiceNo, decimal Amount, int TOP, string Notes)
        {
            VendorInvoice objOld = new VendorInvoice(Id);

            //generate log description
            string log = "";
            log = ActivityLog.appendChange(log, objOld.InvoiceNo, InvoiceNo, "Invoice No: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.Timestamp, Timestamp, "Timestamp: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.Amount, Amount, "Amount: '{0:N2}' to '{1:N2}'");
            log = ActivityLog.appendChange(log, objOld.TOP, TOP, "TOP: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (string.IsNullOrEmpty(log))
            {
                Util.displayMessageBoxError("No changes to record");
            }
            else
            {
                SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "vendorinvoice_update",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Timestamp),
                new SqlQueryParameter(COL_DB_InvoiceNo, SqlDbType.VarChar, InvoiceNo),
                new SqlQueryParameter(COL_DB_TOP, SqlDbType.Int, TOP),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, Amount),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
            );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));
            }
        }

        public static void update_FakturPajaks_Id(Guid Id, Guid? FakturPajaks_Id)
        {
            VendorInvoice objOld = new VendorInvoice(Id);

            //generate log description
            string log = "";
            log = ActivityLog.appendChange(log, objOld.FakturPajaks_No, new FakturPajak(FakturPajaks_Id).No, "Faktur Pajak: '{0}' to '{1}'");

            if (string.IsNullOrEmpty(log))
            {
                Util.displayMessageBoxError("No changes to record");
            }
            else
            {
                SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoices_update_FakturPajaks_Id",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier, FakturPajaks_Id)
            );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));
            }
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist)
        {
            Tools.populateDropDownList(dropdownlist, get(null, null, false, null, null).DefaultView, COL_DB_InvoiceNo, COL_DB_Id, false);
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
