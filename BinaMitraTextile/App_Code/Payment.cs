using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public enum PaymentMethod
    {
        Cash,
        EDC,
        Transfer,
        Credit,
        Giro,
        Hutang
    };

    public class Payment
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public DateTime Timestamp;
        public Guid ReferenceId;
        public PaymentMethod PaymentMethod;
        public decimal Amount;
        public string Notes;

        public decimal Balance;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_ReferenceId = "ReferenceId";
        public const string COL_DB_PaymentMethod_enumid = "PaymentMethod_enumid";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Checked = "Checked";

        public const string COL_PaymentMethod_enumname = "PaymentMethod_enumname";
        public const string COL_Balance = "Balance";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static Guid add(Guid referenceId, PaymentMethod paymentMethod, decimal amount, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("Payments_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_ReferenceId, SqlDbType.UniqueIdentifier).Value = referenceId;
                    cmd.Parameters.Add("@" + COL_DB_PaymentMethod_enumid, SqlDbType.TinyInt).Value = paymentMethod;
                    cmd.Parameters.Add("@" + COL_DB_Amount, SqlDbType.Decimal).Value = amount;
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(referenceId, "New Payment: Rp." + amount.ToString("N2"));
                }
            }
            catch (Exception ex) { LIBUtil.Util.displayMessageBoxError(ex.Message); }

            return id;
        }

        public static DataTable get(Guid referenceId, decimal startingBalance)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Payments_getby_ReferenceId", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ReferenceId, SqlDbType.UniqueIdentifier).Value = referenceId;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            Tools.parseEnum<PaymentMethod>(dataTable, COL_PaymentMethod_enumname, COL_DB_PaymentMethod_enumid);
            
            dataTable = computeBalances(dataTable, startingBalance);

            return dataTable;
        }

        public static string updateCheckedStatus(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Payments_update_Checked", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Checked, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Checked status changed to: " + value.ToString().ToLower());
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        private static DataTable computeBalances(DataTable dataTable, decimal saleStartingBalance)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                saleStartingBalance -= Convert.ToDecimal(dr[COL_DB_Amount]);
                dr[COL_Balance] = saleStartingBalance;
            }

            return dataTable;
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
