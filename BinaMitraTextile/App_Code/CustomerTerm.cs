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

        public static void add(Guid customerID, decimal debtLimit, int termDays, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("CustomerTerms_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier).Value = customerID;
                    cmd.Parameters.Add("@" + COL_DB_DEBTLIMIT, SqlDbType.Decimal).Value = debtLimit;
                    cmd.Parameters.Add("@" + COL_DB_TERMDAYS, SqlDbType.Int).Value = termDays;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.NVarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid id, decimal debtLimit, int termDays, string notes)
        {
            try
            {
                CustomerTerm objOld = new CustomerTerm(id);

                //generate log description
                string logDescription = "";
                if (objOld.DebtLimit != debtLimit) logDescription = Tools.append(logDescription, String.Format("Limit: '{0}' to '{1}'", objOld.DebtLimit, debtLimit), ",");
                if (objOld.TermDays != termDays) logDescription = Tools.append(logDescription, String.Format("Term days: '{0}' to '{1}'", objOld.TermDays, termDays), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

                using (SqlCommand cmd = new SqlCommand("CustomerTerms_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_DEBTLIMIT, SqlDbType.Decimal).Value = debtLimit;
                    cmd.Parameters.Add("@" + COL_DB_TERMDAYS, SqlDbType.Int).Value = termDays;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.NVarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", logDescription));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("CustomerTerms_get", ID);
        }

        public static DataTable get(Guid? id, Guid? customerID, bool includeInactive, bool onlyNotChecked)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("CustomerTerms_get", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = LIBUtil.Util.wrapNullable<Guid?>(id);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier).Value = LIBUtil.Util.wrapNullable<Guid?>(customerID);
                cmd.Parameters.Add("@" + FILTER_OnlyNotChecked, SqlDbType.Bit).Value = onlyNotChecked;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void updateActive(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("CustomerTerms_update_Active", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_ACTIVE, SqlDbType.TinyInt).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Active changed to: " + value);
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void updateCheckedStatus(Guid userAccountID, Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
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
            using (SqlCommand cmd = new SqlCommand("CustomerTerms_isExist_Customers_Id", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERS_ID, SqlDbType.UniqueIdentifier).Value = customerId;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }
    }
}
