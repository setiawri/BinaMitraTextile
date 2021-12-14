using System;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile
{
    public class MoneyAccountItem
    {
        public const string COL_DB_Id = "Id";
        public const string COL_DB_MoneyAccounts_Id = "MoneyAccounts_Id";
        public const string COL_DB_MoneyAccountCategories_Id = "MoneyAccountCategories_Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_No = "No";
        public const string COL_DB_Description = "Description";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_Approved = "Approved";
        public const string COL_DB_ReferenceId = "ReferenceId";
        public const string COL_DB_ReferenceEnumId = "ReferenceEnumId";

        public const string COL_MoneyAccounts_Name = "MoneyAccounts_Name";
        public const string COL_MoneyAccountCategories_Name = "MoneyAccountCategories_Name";
        public const string COL_Balance = "Balance";

        public const string FILTER_Timestamp_Start = "FILTER_Timestamp_Start";
        public const string FILTER_Timestamp_End = "FILTER_Timestamp_End";

        public Guid Id;
        public Guid MoneyAccounts_Id;
        public Guid MoneyAccountCategories_Id;
        public DateTime Timestamp;
        public string No = "";
        public string Description = "";
        public int Amount = 0;
        public bool Approved = false;
        public Guid? ReferenceId = null;
        public int? ReferenceEnumId = null;

        public string MoneyAccounts_Name = "";
        public string MoneyAccountCategories_Name = "";
        public int Balance = 0;

        public MoneyAccountItem(Guid id)
        {
            Id = id;
            DataRow row = get(Id);
            MoneyAccounts_Id = Util.wrapNullable<Guid>(row, COL_DB_MoneyAccounts_Id);
            MoneyAccountCategories_Id = Util.wrapNullable<Guid>(row, COL_DB_MoneyAccountCategories_Id);
            Timestamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
            No = Util.wrapNullable<string>(row, COL_DB_No);
            Description = Util.wrapNullable<string>(row, COL_DB_Description);
            Amount = Util.wrapNullable<int>(row, COL_DB_Amount);
            Approved = Util.wrapNullable<bool>(row, COL_DB_Approved);
            ReferenceId = Util.wrapNullable<Guid?>(row, COL_DB_ReferenceId);
            ReferenceEnumId = Util.wrapNullable<int?>(row, COL_DB_ReferenceEnumId);

            MoneyAccounts_Name = Util.wrapNullable<string>(row, COL_MoneyAccounts_Name);
            MoneyAccountCategories_Name = Util.wrapNullable<string>(row, COL_MoneyAccountCategories_Name);
            Balance = Util.wrapNullable<int>(row, COL_Balance);
        }

        public static Guid? add(Guid MoneyAccountCategories_Id, string Description, int Amount) { return add(MoneyAccountCategories_Id, Description, Amount, false, null, null); }
        public static Guid? add(Guid MoneyAccountCategories_Id, string Description, 
            int Amount, bool Approved, Guid? ReferenceId, int? ReferenceEnumId)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccountItems_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                new SqlQueryParameter(COL_DB_Description, SqlDbType.VarChar, Util.wrapNullable(Description)),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Int, Util.wrapNullable(Amount)),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Util.wrapNullable(Approved)),
                new SqlQueryParameter(COL_DB_ReferenceId, SqlDbType.UniqueIdentifier, Util.wrapNullable(ReferenceId)),
                new SqlQueryParameter(COL_DB_ReferenceEnumId, SqlDbType.Int, Util.wrapNullable(ReferenceEnumId))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, null, null, null, null, null)); }
        public static DataTable get(Guid? Id, Guid? MoneyAccounts_Id, Guid? MoneyAccountCategories_Id, bool? Approved, DateTime? Timestamp_Start, DateTime? Timestamp_End)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "MoneyAccountItems_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Util.wrapNullable(Approved)),
                new SqlQueryParameter(FILTER_Timestamp_Start, SqlDbType.DateTime, Util.wrapNullable(Timestamp_Start)),
                new SqlQueryParameter(FILTER_Timestamp_End, SqlDbType.DateTime, Util.wrapNullable(Timestamp_End))
            );
            return result.Datatable;
        }

        public static void update(Guid Id, Guid MoneyAccounts_Id, Guid MoneyAccountCategories_Id, string Description, int Amount)
        {
            MoneyAccountItem objOld = new MoneyAccountItem(Id);

            string log = "";
            log = Util.appendChange(log, objOld.MoneyAccounts_Name, new MoneyAccountCategory(MoneyAccounts_Id).Name, "Account: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.MoneyAccountCategories_Name, new MoneyAccountCategory(MoneyAccountCategories_Id).Name, "Category: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Description, Description, "Description: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Amount, Amount, "Amount: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "MoneyAccountItems_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                    new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                    new SqlQueryParameter(COL_DB_Description, SqlDbType.VarChar, Util.wrapNullable(Description)),
                    new SqlQueryParameter(COL_DB_Amount, SqlDbType.Int, Util.wrapNullable(Amount))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(Id, log);
            }
        }

        public static void update_Approved(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccountItems_update_Approved",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Approved: {0}", Value));
        }

    }
}
