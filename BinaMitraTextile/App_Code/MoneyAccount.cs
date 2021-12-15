using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class MoneyAccount
    {
        public const string COL_DB_Id = "Id";
        public const string COL_DB_Name = "Name";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Default = "Default";
        public const string COL_DB_Active = "Active";

        public Guid Id;
        public string Name = "";
        public string Notes = "";
        public bool Default = false;
        public bool Active = true;

        public MoneyAccount(Guid id)
        {
            Id = id;
            DataRow row = get(Id);
            Name = Util.wrapNullable<string>(row, COL_DB_Name);
            Notes = Util.wrapNullable<string>(row, COL_DB_Notes);
            Default = Util.wrapNullable<bool>(row, COL_DB_Default);
            Active = Util.wrapNullable<bool>(row, COL_DB_Active);
        }

        public static Guid getDefaultItem()
        {
            DataRow row = Util.getFirstRow(get(null, null, null, true));
            if (row != null)
                return Util.wrapNullable<Guid>(row, COL_DB_Id);
            else
            {
                Util.displayMessageBoxError("Please set default money account");
                return Guid.Empty;
            }
        }

        public static Guid? add(string Name, string Notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "MoneyAccounts_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Name, SqlDbType.VarChar, Util.wrapNullable(Name)),
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
        public static DataTable get(Guid? Id, string Name, bool? Active, bool? Default)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "MoneyAccounts_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_Name, SqlDbType.VarChar, Util.wrapNullable(Name)),
                new SqlQueryParameter(COL_DB_Active, SqlDbType.Bit, Util.wrapNullable(Active)),
                new SqlQueryParameter(COL_DB_Default, SqlDbType.Bit, Util.wrapNullable(Default))
            );
            return result.Datatable;
        }

        public static void update(Guid Id, string Name, string Notes)
        {
            MoneyAccount objOld = new MoneyAccount(Id);

            //generate log description
            string log = "";
            log = Util.appendChange(log, objOld.Name, Name, "Name: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "MoneyAccounts_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Name, SqlDbType.VarChar, Util.wrapNullable(Name)),
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
                "MoneyAccounts_update_Active",
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
                "MoneyAccounts_update_Default",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Set as default"));
        }

        public static bool isExist(Guid? Id, string Name)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "MoneyAccounts_isExist",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_Name, SqlDbType.VarChar, Util.wrapNullable(Name))
                );
            return result.ValueBoolean;
        }

        public static void populateCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool? Active)
        {
            checkedlistbox.populate(get(null, null, Active, null).DefaultView, COL_DB_Name, COL_DB_Id);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool? Active)
        {
            control.populate(get(null, null, Active, null).DefaultView, COL_DB_Name, COL_DB_Id, COL_DB_Default);
        }

    }
}
