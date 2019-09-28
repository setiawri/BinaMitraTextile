using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static void submitNew(Guid customerID, decimal creditAmount, Guid? salePaymentID, string notes, PaymentMethod? paymentMethod)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("customercredit_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                    cmd.Parameters.Add("@" + COL_DB_AMOUNT, SqlDbType.Decimal).Value = creditAmount;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;
                    cmd.Parameters.Add("@" + COL_DB_SALEPAYMENTID, SqlDbType.UniqueIdentifier).Value = (object)salePaymentID ?? DBNull.Value;
                    cmd.Parameters.Add("@" + COL_DB_USERID, SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                    cmd.Parameters.Add("@" + COL_DB_METHODENUMID, SqlDbType.TinyInt).Value = Tools.wrapNullable(paymentMethod);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(customerID, "Credit: Rp." + creditAmount.ToString("N2"));
                }
            }
            catch (Exception ex) { Tools.hasMessage(ex.Message); }
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
            DataTable datatable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("customercredit_get_by_customer_id", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                cmd.Parameters.Add("@hex_length", SqlDbType.TinyInt).Value = Settings.saleBarcodeLength;

                adapter.SelectCommand = cmd;
                adapter.Fill(datatable);
            }

            Tools.parseEnum<PaymentMethod>(datatable, COL_PAYMENT_METHODNAME, COL_PAYMENT_METHODENUMID);
            datatable = computeBalances(datatable);

            return datatable;
        }

        public static DataTable getSummary(bool onlyHasActivityLast3Months)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("customercredit_get_summary", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + FILTER_onlyHasActivityLast3Months, SqlDbType.Bit).Value = onlyHasActivityLast3Months;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
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

            //calculation from top to bottom
            //foreach (DataRow dr in dataTable.Rows)
            //{
            //    balance += Convert.ToDecimal(dr[COL_DB_AMOUNT]);
            //    dr[COL_BALANCE] = balance;
            //}

            return dataTable;
        }

        public static decimal getBalance(Guid customerID)
        {
            Object obj;
            using (SqlCommand cmd = new SqlCommand("customercredit_get_balance", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;

                obj = cmd.ExecuteScalar();
            }
            return Convert.ToDecimal(obj);
        }

        public static string updateConfirmedStatus(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("customercredit_update_Confirmed", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Confirmed, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Confirmed status changed to: " + value.ToString().ToLower());
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
