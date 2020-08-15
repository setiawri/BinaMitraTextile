using System;

using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class CustomerTerm
    {
        public const string COL_DB_ID = "Id";
        public const string COL_DB_CUSTOMERS_ID = "Customers_Id";
        public const string COL_DB_DEBTLIMIT = "DebtLimit";
        public const string COL_DB_TERMDAYS = "TermDays";
        public const string COL_DB_NOTES = "Notes";
        public const string COL_DB_ACTIVE = "Active";
        public const string COL_DB_Checked = "Checked";

        public const string COL_CUSTOMERS_NAME = "Customers_Name";

        public const string FILTER_OnlyNotChecked = "FILTER_OnlyNotChecked";
        public const string FILTER_IncludeInactive = "include_inactive";

        public Guid Id;
        public Guid Customers_Id;
        public decimal DebtLimit;
        public int TermDays;
        public string Notes;
        public bool Active;

        public string Customers_Name;

        public CustomerTerm() { }

        public CustomerTerm(Guid id)
        {
            Id = id;
            DataRow row = getRow(Id).Rows[0];
            Customers_Id = DBUtil.parseData<Guid>(row, COL_DB_CUSTOMERS_ID);
            DebtLimit = DBUtil.parseData<decimal>(row, COL_DB_DEBTLIMIT);
            TermDays = DBUtil.parseData<int>(row, COL_DB_TERMDAYS);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
            Active = DBUtil.parseData<bool>(row, COL_DB_ACTIVE);

            Customers_Name = DBUtil.parseData<string>(row, COL_CUSTOMERS_NAME);
        }

        public static Guid? add(Guid customerID, decimal debtLimit, int termDays, string notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "CustomerTerms_add",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier, customerID),
                new SqlQueryParameter(COL_DB_DEBTLIMIT, SqlDbType.Decimal, debtLimit),
                new SqlQueryParameter(COL_DB_TERMDAYS, SqlDbType.Int, termDays),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static void update(Guid Id, decimal debtLimit, int termDays, string notes)
        {
            CustomerTerm objOld = new CustomerTerm(Id);

            //generate log description
            string logDescription = "";
            if (objOld.DebtLimit != debtLimit) logDescription = Tools.append(logDescription, String.Format("Limit: '{0}' to '{1}'", objOld.DebtLimit, debtLimit), ",");
            if (objOld.TermDays != termDays) logDescription = Tools.append(logDescription, String.Format("Term days: '{0}' to '{1}'", objOld.TermDays, termDays), ",");
            if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "CustomerTerms_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_DEBTLIMIT, SqlDbType.Decimal, debtLimit),
                    new SqlQueryParameter(COL_DB_TERMDAYS, SqlDbType.Int, termDays),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.NVarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, "Update: " + logDescription);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("CustomerTerms_get", ID);
        }

        public static DataTable get(Guid? Id, Guid? customerID, bool includeInactive, bool onlyNotChecked)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "CustomerTerms_get",
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(customerID)),
                new SqlQueryParameter(FILTER_OnlyNotChecked, SqlDbType.Bit, onlyNotChecked)
            );
            return result.Datatable;
        }

        public static void updateActive(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "CustomerTerms_update_Active",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_ACTIVE, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, "Active changed to: " + Value);
        }

        public static void updateCheckedStatus(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "CustomerTerms_update_Checked",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Checked, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Checked Status to " + value);
        }

        public static bool isExist_CustomersId(Guid? id, Guid customerId)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "CustomerTerms_isExist_Customers_Id",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier, customerId)
                );
            return result.ValueBoolean;
        }
    }
}
