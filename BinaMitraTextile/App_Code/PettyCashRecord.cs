using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class PettyCashRecord
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public string No;
        public DateTime Timestamp;
        public Guid PettyCashRecordsCategories_Id;
        public string Notes = "";
        public decimal Amount;

        public string PettyCashRecordsCategories_Name;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_No = "No";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_PettyCashRecordsCategories_Id = "PettyCashRecordsCategories_Id";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_IsChecked = "IsChecked";

        public const string COL_FILTER_Timestamp_Start = "Timestamp_Start";
        public const string COL_FILTER_Timestamp_End = "Timestamp_End";
        public const string FILTER_OnlyNotChecked = "FILTER_OnlyNotChecked";

        public const string COL_PettyCashRecordsCategories_Name = "PettyCashRecordsCategories_Name";
        public const string COL_Balance = "Balance";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public PettyCashRecord() { }
        public PettyCashRecord(Guid id)
        {
            DataRow row = get(id);
            Id = id;
            No = DBUtil.parseData<string>(row, COL_DB_No);
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_Timestamp);
            PettyCashRecordsCategories_Id = DBUtil.parseData<Guid>(row, COL_DB_PettyCashRecordsCategories_Id);
            Amount = DBUtil.parseData<decimal>(row, COL_DB_Amount);
            Notes = DBUtil.parseData<string>(row, COL_DB_Notes);

            PettyCashRecordsCategories_Name = DBUtil.parseData<string>(row, COL_PettyCashRecordsCategories_Name);
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static Guid add(Guid pettyCashRecordsCategories_Id, decimal amount, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("PettyCashRecords_add", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier).Value = pettyCashRecordsCategories_Id;
                    cmd.Parameters.Add("@" + COL_DB_Amount, SqlDbType.Decimal).Value = amount;
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(sqlConnection, id, "Item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
            return id;
        }

        public static DataRow get(Guid id) { return Tools.getFirstRow(get(id, null, null, null, null, false)); }

        public static DataTable get(Guid? id, DateTime? timestamp_Start, DateTime? timestamp_End, Guid? pettyCashRecordsCategories_Id, string notes, bool chkOnlyNotChecked)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("PettyCashRecords_get", sqlConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                    cmd.Parameters.Add("@" + COL_FILTER_Timestamp_Start, SqlDbType.DateTime).Value = Tools.wrapNullable(timestamp_Start);
                    cmd.Parameters.Add("@" + COL_FILTER_Timestamp_End, SqlDbType.DateTime).Value = Tools.wrapNullable(timestamp_End);
                    cmd.Parameters.Add("@" + COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(pettyCashRecordsCategories_Id);
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);
                    cmd.Parameters.Add("@" + FILTER_OnlyNotChecked, SqlDbType.Bit).Value = chkOnlyNotChecked;
                    SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Decimal);
                    return_value.Direction = ParameterDirection.Output;

                    adapter.SelectCommand = cmd;
                    adapter.Fill(datatable);

                    //calculate balance only if records are not filtered by fields other than start/end time
                    if(pettyCashRecordsCategories_Id == null)
                    {
                        decimal startingBalance = Convert.ToDecimal(return_value.Value);
                        for (int i = datatable.Rows.Count - 1; i >= 0; i--)
                        {
                            startingBalance += DBUtil.parseData<decimal>(datatable.Rows[i], COL_DB_Amount);
                            datatable.Rows[i][COL_Balance] = startingBalance;
                        }
                    }
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }

            return datatable;
        }

        public static void update(Guid id, Guid pettyCashRecordsCategories_Id, decimal amount, string notes)
        {
            try
            {
                PettyCashRecord objOld = new PettyCashRecord(id);
                string log = "";
                log = ActivityLog.appendChange(log, objOld.PettyCashRecordsCategories_Name, new PettyCashRecordsCategory(pettyCashRecordsCategories_Id).Name, "Category: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Amount, amount, "Amount: '{0:N2}' to '{1:N2}'");
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("PettyCashRecords_update", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier).Value = pettyCashRecordsCategories_Id;
                    cmd.Parameters.Add("@" + COL_DB_Amount, SqlDbType.Decimal).Value = amount;
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    if(GlobalData.UserAccount.role != Roles.Super)
                        ActivityLog.submit(sqlConnection, id, "Update: " + log, (int)Roles.Super);
                    else
                        ActivityLog.submit(sqlConnection, id, "Update: " + log);
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static string updateCheckedStatus(Guid id, bool? isChecked)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("PettyCashRecords_update_IsChecked", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_IsChecked, SqlDbType.Bit).Value = isChecked ?? false;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "Update Is Checked to: " + isChecked);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

