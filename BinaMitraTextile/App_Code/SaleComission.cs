using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class SaleComission
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public Guid Users_Id;
        public DateTime Period;
        public decimal GlobalPercentComission;
        public int Amount;
        public int CorrectionAmount;
        public string CorrectionNotes;
        public DateTime? PaymentDate;

        public string Users_Name;
        public int TotalAmount;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Period = "Period";
        public const string COL_DB_Users_Id = "Users_Id";
        public const string COL_DB_GlobalPercentComission = "GlobalPercentComission";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_CorrectionAmount = "CorrectionAmount";
        public const string COL_DB_CorrectionNotes = "CorrectionNotes";
        public const string COL_DB_PaymentDate = "PaymentDate";

        public const string COL_Users_Username = "Users_Username";
        public const string COL_DB_TotalAmount = "TotalAmount";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public SaleComission(Guid id)
        {
            DataRow row = get(id);
            if(row != null)
            {
                Id = id;
                Users_Id = Util.wrapNullable<Guid>(row, COL_DB_Users_Id);
                Period = Util.wrapNullable<DateTime>(row, COL_DB_Period);
                GlobalPercentComission = Util.wrapNullable<decimal>(row, COL_DB_GlobalPercentComission);
                Amount = Util.wrapNullable<int>(row, COL_DB_Amount);
                CorrectionAmount = Util.wrapNullable<int>(row, COL_DB_CorrectionAmount);
                CorrectionNotes = Util.wrapNullable<string>(row, COL_DB_CorrectionNotes);
                PaymentDate = Util.wrapNullable<DateTime?>(row, COL_DB_PaymentDate);

                Users_Name = Util.wrapNullable<string>(row, COL_Users_Username);
                TotalAmount = Util.wrapNullable<int>(row, COL_DB_TotalAmount);
            }
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static Guid add(Guid Users_Id, DateTime Period, decimal GlobalPercentComission, int Amount, int CorrectionAmount, string CorrectionNotes, DateTime PaymentDate)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "SaleComissions_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Users_Id, SqlDbType.UniqueIdentifier, Users_Id),
                new SqlQueryParameter(COL_DB_Period, SqlDbType.DateTime, Period),
                new SqlQueryParameter(COL_DB_GlobalPercentComission, SqlDbType.Decimal, GlobalPercentComission),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Int, Amount),
                new SqlQueryParameter(COL_DB_CorrectionAmount, SqlDbType.Int, CorrectionAmount),
                new SqlQueryParameter(COL_DB_CorrectionNotes, SqlDbType.VarChar, CorrectionNotes),
                new SqlQueryParameter(COL_DB_PaymentDate, SqlDbType.DateTime, PaymentDate)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, "Added");

            return Id;
        }

        public static DataRow get(Guid? Id) { return Util.getFirstRow(get(Id, null, null)); }
        public static DataTable get(DateTime? Period) { return get(null, null, Period); }
        public static DataTable get(Guid Users_Id, DateTime? Period) { return get(null, Users_Id, Period); }
        public static DataTable get(Guid? Id, Guid? Users_Id, DateTime? Period)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "SaleComissions_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_Users_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Users_Id)),
                new SqlQueryParameter(COL_DB_Period, SqlDbType.DateTime, Util.wrapNullable(Period))
                );
            return result.Datatable;
        }

        public static bool update(Guid Id, int CorrectionAmount, string CorrectionNotes, DateTime? PaymentDate)
        {
            SaleComission objOld = new SaleComission(Id);
            string log = "";
            log = Util.appendChange(log, objOld.CorrectionAmount, CorrectionAmount, "Correction Amount: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.CorrectionNotes, CorrectionNotes, "Correction Notes: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.PaymentDate, PaymentDate, "Payment Date: '{0:dd/MM/yyyy}' to '{1:dd/MM/yyyy}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "SaleComissions_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_CorrectionAmount, SqlDbType.Int, CorrectionAmount),
                    new SqlQueryParameter(COL_DB_CorrectionNotes, SqlDbType.VarChar, Util.wrapNullable(CorrectionNotes)),
                    new SqlQueryParameter(COL_DB_PaymentDate, SqlDbType.DateTime, Util.wrapNullable(PaymentDate))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                return result.IsSuccessful;
            }

            return false;
        }

        public static void generate(DateTime Period)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "SaleComissions_generate",
                new SqlQueryParameter(COL_DB_Period, SqlDbType.DateTime, Period)
            );
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

