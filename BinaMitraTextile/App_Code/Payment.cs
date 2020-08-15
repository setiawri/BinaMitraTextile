using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

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

        public static Guid? add(Guid referenceId, PaymentMethod paymentMethod, decimal amount, string notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Payments_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_ReferenceId, SqlDbType.UniqueIdentifier, referenceId),
                new SqlQueryParameter(COL_DB_PaymentMethod_enumid, SqlDbType.TinyInt, paymentMethod),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, amount),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static DataTable get(Guid referenceId, decimal startingBalance)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Payments_getby_ReferenceId", DBConnection.ActiveSqlConnection))
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

        public static void updateCheckedStatus(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Payments_update_Checked",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Checked, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Checked Status to " + value);
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
