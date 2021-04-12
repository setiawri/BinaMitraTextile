using System;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using LIBUtil;

namespace BinaMitraTextile
{
    public class VendorInvoice
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public DateTime Timestamp;
        public string InvoiceNo;
        public decimal Amount;
        public string Notes;
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
        public const string COL_DB_Approved = "Approved";

        public const string COL_StatusName = "status_name";
        public const string COL_CalculatedAmount = "CalculatedAmount";
        public const string COL_ReturnedValue = "ReturnedValue";
        public const string COL_AmountDifferenceFromCalculated = "AmountDifferenceFromCalculated";
        public const string COL_IsDue = "is_due";
        public const string COL_DaysPastDue = "DaysPastDue";
        public const string COL_PaidAmount = "PaidAmount";
        public const string COL_PayableAmount = "PayableAmount";
        public const string COL_PaymentAmount = "PaymentAmount";
        public const string COL_VendorName = "VendorName";
        public const string COL_FakturPajaks_No = "FakturPajaks_No";
        public const string COL_FakturPajaks_DPP = "FakturPajaks_DPP";
        public const string COL_FakturPajaks_Amount = "FakturPajaks_Amount";
        public const string COL_AmountDifferenceFromFakturPajaksAmount = "AmountDifferenceFromFakturPajaksAmount";

        public const string FILTER_BrowsingForFakturPajak_Vendors_Id = "FILTER_BrowsingForFakturPajak_Vendors_Id";
        public const string FILTER_ShowOnlyIncomplete = "FILTER_ShowOnlyIncomplete";
        public const string FILTER_ShowOnlyVendorUsesFakturPajak = "FILTER_ShowOnlyVendorUsesFakturPajak";
        public const string FILTER_showOnlyLast6Months = "FILTER_showOnlyLast6Months";
        public const string FILTER_ShowOnlyReminder = "FILTER_ShowOnlyReminder";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public VendorInvoice(Guid id)
        {
            DataRow row = get(id).Rows[0];
            ID = id;
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_Timestamp);
            InvoiceNo = DBUtil.parseData<string>(row, COL_DB_InvoiceNo);
            Amount = DBUtil.parseData<decimal>(row, COL_DB_Amount);
            Notes = DBUtil.parseData<string>(row, COL_DB_Notes);
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
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "VendorInvoices_isExist_InvoiceNo",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_InvoiceNo, SqlDbType.VarChar, invoiceNo)
                );
            return result.ValueBoolean;
        }

        public static DataTable get()
        {
            return get(null, null, null, false, false, false, null, null, false);
        }

        public static DataTable get(Guid ID)
        {
            return get(ID, null, null, true, false, false, null, null, false);
        }

        public static DataTable get(bool showOnlyIncomplete)
        {
            return get(null, null, null, showOnlyIncomplete, false, false, null, null, false);
        }

        public static DataTable get_Reminder()
        {
            return get(null, null, null, false, false, false, null, null, true);
        }

        public static DataTable get_by_FakturPajaks_Id(Guid FakturPajaks_Id)
        {
            return get(null, null, null, true, false, false, FakturPajaks_Id, null, false);
        }

        public static DataTable get_by_BrowsingForFakturPajak_Vendors_Id(Guid BrowsingForFakturPajak_Customers_Id, bool showOnlyLast6Months)
        {
            return get(null, null, null, false, false, showOnlyLast6Months, null, BrowsingForFakturPajak_Customers_Id, false);
        }

        public static DataTable get(Guid? Id, string invoiceNumber, Guid? Vendors_Id, bool showOnlyIncomplete, bool showOnlyVendorUsesFakturPajak, 
            bool showOnlyLast6Months, Guid? FakturPajaks_Id, Guid? BrowsingForFakturPajak_Vendors_Id, bool showOnlyReminder)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorInvoices_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_InvoiceNo, SqlDbType.VarChar, Util.wrapNullable(invoiceNumber)),
                new SqlQueryParameter(COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(FakturPajaks_Id)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(FILTER_BrowsingForFakturPajak_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(BrowsingForFakturPajak_Vendors_Id)),
                new SqlQueryParameter(FILTER_ShowOnlyIncomplete, SqlDbType.Bit, showOnlyIncomplete),
                new SqlQueryParameter(FILTER_showOnlyLast6Months, SqlDbType.Bit, showOnlyLast6Months),
                new SqlQueryParameter(FILTER_ShowOnlyVendorUsesFakturPajak, SqlDbType.Bit, showOnlyVendorUsesFakturPajak),
                new SqlQueryParameter(FILTER_ShowOnlyReminder, SqlDbType.Bit, showOnlyReminder)
                );
            return result.Datatable;
        }

        public static Guid? add(string invoiceNo, Guid Vendors_Id)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoices_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_InvoiceNo, SqlDbType.VarChar, invoiceNo),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Vendors_Id)
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static void update_Approved(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoices_update_Approved",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Approved changed to: {0}", Value));
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

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoices_update",
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
                DBConnection.ActiveSqlConnection,
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

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool showOnlyIncomplete)
        {
            Tools.populateDropDownList(dropdownlist, get(showOnlyIncomplete).DefaultView, COL_DB_InvoiceNo, COL_DB_Id, false);
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
