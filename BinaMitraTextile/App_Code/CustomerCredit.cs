using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    class CustomerCredit
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES
        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_ID = "id";
        public const string COL_DB_TIMESTAMP = "time_stamp";
        public const string COL_DB_CUSTOMERID = "customer_id";
        public const string COL_DB_AMOUNT = "amount";
        public const string COL_DB_SALEPAYMENTID = "sale_payment_id";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_USERID = "user_id";
        public const string COL_DB_METHODENUMID = "method_enumid";
        public const string COL_DB_Confirmed = "Confirmed";

        public const string COL_SALEID = "sale_id";
        public const string COL_SALEBARCODE = "sale_barcode";
        public const string COL_BALANCE = "balance";

        public const string COL_SUMMARY_CUSTOMERID = "customer_id";
        public const string COL_SUMMARY_CUSTOMERNAME = "customer_name"; 
        public const string COL_SUMMARY_BALANCE = "balance";

        public const string COL_PAYMENT_METHODENUMID = "payment_method_enumid";
        public const string COL_PAYMENT_METHODNAME = "payment_method_name";

        public const string FILTER_onlyHasActivityLast3Months = "FILTER_onlyHasActivityLast3Months";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS
        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static Guid? submitNew(Guid customerID, decimal creditAmount, Guid? salePaymentID, string notes, PaymentMethod? paymentMethod)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "customercredit_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier, customerID),
                new SqlQueryParameter(COL_DB_AMOUNT, SqlDbType.Decimal, creditAmount),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, notes),
                new SqlQueryParameter(COL_DB_SALEPAYMENTID, SqlDbType.UniqueIdentifier, Util.wrapNullable(salePaymentID)),
                new SqlQueryParameter(COL_DB_USERID, SqlDbType.UniqueIdentifier, GlobalData.UserAccount.id),
                new SqlQueryParameter(COL_DB_METHODENUMID, SqlDbType.TinyInt, Util.wrapNullable(paymentMethod))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
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

        public static DataTable getAll(Guid customerID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "customercredit_get_by_customer_id",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, customerID),
                new SqlQueryParameter("hex_length", SqlDbType.TinyInt, Settings.saleBarcodeLength)
                );

            DataTable datatable = result.Datatable;
            Tools.parseEnum<PaymentMethod>(datatable, COL_PAYMENT_METHODNAME, COL_PAYMENT_METHODENUMID);
            datatable = computeBalances(datatable);

            return datatable;
        }

        public static DataTable getSummary(bool onlyHasActivityLast3Months)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "customercredit_get_summary",
                new SqlQueryParameter(FILTER_onlyHasActivityLast3Months, SqlDbType.Bit, onlyHasActivityLast3Months)
                );
            return result.Datatable;
        }

        private static DataTable computeBalances(DataTable dataTable)
        {
            decimal balance = 0;

            //calculation from bottom to top
            for(int i= dataTable.Rows.Count-1; i>=0; i--)
            {
                balance += Convert.ToDecimal(dataTable.Rows[i][COL_DB_AMOUNT]);
                dataTable.Rows[i][COL_BALANCE] = balance;
            }

            return dataTable;
        }

        public static decimal getBalance(Guid customerID)
        {
            Object obj;
            using (SqlCommand cmd = new SqlCommand("customercredit_get_balance", DBConnection.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;

                obj = cmd.ExecuteScalar();
            }
            return Convert.ToDecimal(obj);
        }

        public static void updateConfirmedStatus(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "customercredit_update_Confirmed",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Confirmed, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, "Confirmed status changed to: " + Value.ToString().ToLower());
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
