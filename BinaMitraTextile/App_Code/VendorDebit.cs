using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

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

        public static void add(Guid vendorId, decimal amount, Guid? salePaymentID, string notes, PaymentMethod? paymentMethod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("VendorDebits_add", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                        cmd.Parameters.Add("@" + COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier).Value = vendorId;
                        cmd.Parameters.Add("@" + COL_DB_Amount, SqlDbType.Decimal).Value = amount;
                        cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = notes;
                        cmd.Parameters.Add("@" + COL_DB_sale_payment_id, SqlDbType.UniqueIdentifier).Value = (object)salePaymentID ?? DBNull.Value;
                        cmd.Parameters.Add("@" + COL_DB_Type_enumid, SqlDbType.TinyInt).Value = Tools.wrapNullable(paymentMethod);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(conn, vendorId, "Debit: Rp." + amount.ToString("N2"));
                    }
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

        public static DataTable getAll(Guid vendorId)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("VendorDebits_get", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_SUMMARY_Vendors_Id, SqlDbType.UniqueIdentifier).Value = vendorId;

                adapter.SelectCommand = cmd;
                adapter.Fill(datatable);
            }

            Tools.parseEnum<PaymentMethod>(datatable, COL_PaymentType_name, COL_PaymentType_enumid);
            datatable = computeBalances(datatable);

            return datatable;
        }

        public static DataTable getSummary()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("VendorDebits_get_summary", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
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

            Object obj;
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("VendorDebits_get_balance", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_SUMMARY_Vendors_Id, SqlDbType.UniqueIdentifier).Value = vendorId;

                conn.Open();
                obj = cmd.ExecuteScalar();
                conn.Close();
            }
            return Convert.ToDecimal(obj);
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
