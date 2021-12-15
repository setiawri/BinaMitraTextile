using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class MoneyAccountCategoryAssignment
    {
        public const string COL_DB_Id = "Id";
        public const string COL_DB_MoneyAccountCategories_Id = "MoneyAccountCategories_Id";
        public const string COL_DB_MoneyAccounts_Id = "MoneyAccounts_Id";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Default = "Default";
        public const string COL_DB_Active = "Active";

        public const string COL_MoneyAccounts_Name = "MoneyAccounts_Name";
        public const string COL_MoneyAccountCategories_Name = "MoneyAccountCategories_Name";

        public Guid Id;
        public Guid MoneyAccountCategories_Id;
        public Guid MoneyAccounts_Id;
        public string Notes = "";
        public bool Default = false;
        public bool Active = true;

        public string MoneyAccounts_Name;
        public string MoneyAccountCategories_Name;

        public MoneyAccountCategoryAssignment(Guid id)
        {
            Id = id;
            DataRow row = get(Id);
            MoneyAccountCategories_Id = Util.wrapNullable<Guid>(row, COL_DB_MoneyAccountCategories_Id);
            MoneyAccounts_Id = Util.wrapNullable<Guid>(row, COL_DB_MoneyAccounts_Id);
            Notes = Util.wrapNullable<string>(row, COL_DB_Notes);
            Default = Util.wrapNullable<bool>(row, COL_DB_Default);
            Active = Util.wrapNullable<bool>(row, COL_DB_Active);

            MoneyAccounts_Name = Util.wrapNullable<string>(row, COL_MoneyAccounts_Name);
            MoneyAccountCategories_Name = Util.wrapNullable<string>(row, COL_MoneyAccountCategories_Name);
        }
        public static Guid? getDefaultItem()
        {
            DataRow row = Util.getFirstRow(get(null, null, MoneyAccount.getDefaultItem(), true));
            if (row == null)
                return null;
            else
                return Util.wrapNullable<Guid>(row, COL_DB_Id);
        }

        public static Guid? add(Guid MoneyAccountCategories_Id, Guid MoneyAccounts_Id, string Notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccountCategoryAssignments_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(Notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, null, null, null)); }
        public static Guid? get(Guid? MoneyAccountCategories_Id, Guid? MoneyAccounts_Id) 
        {
            DataTable datatable = get(null, MoneyAccountCategories_Id, MoneyAccounts_Id, null);
            if (datatable.Rows.Count == 0)
                return null;
            else
                return Util.wrapNullable<Guid>(Util.getFirstRow(get(null, MoneyAccountCategories_Id, MoneyAccounts_Id, null)), COL_DB_Id); 
        }
        public static DataTable get(Guid? Id, Guid? MoneyAccountCategories_Id, Guid? MoneyAccounts_Id, bool? Active)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "MoneyAccountCategoryAssignments_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                new SqlQueryParameter(COL_DB_Active, SqlDbType.Bit, Util.wrapNullable(Active))
            );
            return result.Datatable;
        }

        public static void update(Guid Id, Guid MoneyAccountCategories_Id, Guid MoneyAccounts_Id, string Notes)
        {
            MoneyAccountCategoryAssignment objOld = new MoneyAccountCategoryAssignment(Id);

            //generate log description
            string log = "";
            log = Util.appendChange(log, objOld.MoneyAccountCategories_Name, new MoneyAccountCategory(MoneyAccountCategories_Id).Name, "Category: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.MoneyAccounts_Name, new MoneyAccount(MoneyAccounts_Id).Name, "Account: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "MoneyAccountCategoryAssignments_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id)),
                    new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(Notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(Id, log);
            }
        }

        public static void update_Active(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccountCategoryAssignments_update_Active",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Active, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Active changed to: {0}", Value));
        }

        public static void update_Default(Guid Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccountCategoryAssignments_update_Default",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Set as default"));
        }

        public static bool isExist(Guid? Id, Guid MoneyAccountCategories_Id, Guid MoneyAccounts_Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "MoneyAccountCategoryAssignments_isExist",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_MoneyAccounts_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccounts_Id)),
                new SqlQueryParameter(COL_DB_MoneyAccountCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(MoneyAccountCategories_Id))
                );
            return result.ValueBoolean;
        }

        public static void populateCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, Guid MoneyAccounts_Id, bool? Active)
        {
            checkedlistbox.populate(get(null, null, MoneyAccounts_Id, Active).DefaultView, COL_MoneyAccountCategories_Name, COL_DB_Id);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, Guid MoneyAccounts_Id, bool? Active)
        {
            control.populate(get(null, null, MoneyAccounts_Id, Active).DefaultView, COL_MoneyAccountCategories_Name, COL_DB_Id, COL_DB_Default);
        }

    }
}
