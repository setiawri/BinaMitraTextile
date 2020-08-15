using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    class VendorDebit
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES
        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_Vendors_Id = "Vendors_Id";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_sale_payment_id = "sale_payment_id";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Type_enumid = "Type_enumid";

        public const string COL_VendorInvoices_id = "VendorInvoices_id";
        public const string COL_VendorInvoices_invoice_no = "VendorInvoices_invoice_no";
        public const string COL_Balance = "Balance";

        public const string COL_SUMMARY_Vendors_Id = "Vendors_Id";
        public const string COL_SUMMARY_Vendors_Name = "Vendors_Name";
        public const string COL_SUMMARY_Balance = "Balance";

        public const string COL_PaymentType_enumid = "PaymentType_enumid";
        public const string COL_PaymentType_name = "PaymentType_name";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS
        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static Guid? add(Guid vendorId, decimal amount, Guid? salePaymentID, string notes, PaymentMethod? paymentMethod)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorDebits_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, vendorId),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, amount),
                new SqlQueryParameter(COL_DB_sale_payment_id, SqlDbType.UniqueIdentifier, Util.wrapNullable(salePaymentID)),
                new SqlQueryParameter(COL_DB_Type_enumid, SqlDbType.TinyInt, Util.wrapNullable(paymentMethod)),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(vendorId, "Debit: Rp." + amount.ToString("N2"));
                return Id;
            }
        }

        public static DataTable getAll(Guid? customerID)
        {
            if (customerID == null)
                return null;
            else
                return getAll((Guid)customerID);
        }

        public static DataTable getAll(Guid vendorId)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorDebits_get",
                new SqlQueryParameter(COL_SUMMARY_Vendors_Id, SqlDbType.UniqueIdentifier, vendorId)
            );

            Tools.parseEnum<PaymentMethod>(result.Datatable, COL_PaymentType_name, COL_PaymentType_enumid);
            return computeBalances(result.Datatable);
        }

        public static DataTable getSummary()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorDebits_get_summary"
            );
            return result.Datatable;
        }

        private static DataTable computeBalances(DataTable dataTable)
        {
            decimal balance = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                balance += Convert.ToDecimal(dr[COL_DB_Amount]);
                dr[COL_Balance] = balance;
            }

            return dataTable;
        }

        public static decimal getBalance(Guid? vendorId)
        {
            if (vendorId == null)
                return 0;

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, true, false, false,
                "VendorDebits_get_balance",
                new SqlQueryParameter(COL_SUMMARY_Vendors_Id, SqlDbType.UniqueIdentifier, vendorId)
                );
            return result.ValueDecimal;
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
