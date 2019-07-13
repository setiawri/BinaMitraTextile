using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class Notification
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public DateTime Timestamp;
        public Guid ActivityLogs_Id;
        public int Roles_EnumId;
        public bool Active;

        public Roles Role;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_ActivityLogs_Id = "ActivityLogs_Id";
        public const string COL_DB_Roles_EnumId = "Roles_EnumId";
        public const string COL_DB_Active = "Active";

        public const string COL_Roles_Name = "Roles_Name";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Notification() { }
        public Notification(Guid id)
        {
            DataRow row = get(id);
            Id = id;
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_Timestamp);
            ActivityLogs_Id = DBUtil.parseData<Guid>(row, COL_DB_ActivityLogs_Id);
            Roles_EnumId = DBUtil.parseData<int>(row, COL_DB_Roles_EnumId);
            Active = DBUtil.parseData<bool>(row, COL_DB_Active);

            Role = Tools.parseEnum<Roles>(Roles_EnumId);
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static void add(DateTime timestamp, Guid activityLogs_Id, int roles_EnumId)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("Notifications_add", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Timestamp, SqlDbType.DateTime).Value = timestamp;
                    cmd.Parameters.Add("@" + COL_DB_ActivityLogs_Id, SqlDbType.UniqueIdentifier).Value = activityLogs_Id;
                    cmd.Parameters.Add("@" + COL_DB_Roles_EnumId, SqlDbType.TinyInt).Value = roles_EnumId;

                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(sqlConnection, id, "Item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataRow get(Guid id) { return Tools.getFirstRow(get(id, null, null, null, null)); }

        public static DataTable get(Guid? id, DateTime? timestamp_Start, DateTime? timestamp_End, int? roles_EnumId, bool active)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("Notifications_get", sqlConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                    cmd.Parameters.Add("@" + COL_FILTER_Timestamp_Start, SqlDbType.DateTime).Value = Tools.wrapNullable(timestamp_Start);
                    cmd.Parameters.Add("@" + COL_FILTER_Timestamp_End, SqlDbType.DateTime).Value = Tools.wrapNullable(timestamp_End);
                    cmd.Parameters.Add("@" + COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(pettyCashRecordsCategories_Id);
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    adapter.SelectCommand = cmd;
                    adapter.Fill(datatable);

                    Tools.parseEnum<Roles>(datatable, COL_Roles_Name, COL_Roles_Name);
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }

            return datatable;
        }

        public static void update(Guid id, DateTime timestamp, Guid pettyCashRecordsCategories_Id, decimal amount, string notes)
        {
            try
            {
                PettyCashRecord objOld = new PettyCashRecord(id);
                string log = "";
                log = ActivityLog.appendChange(log, objOld.Timestamp, timestamp, "Timestamp: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.PettyCashRecordsCategories_Name, new PettyCashRecordsCategory(pettyCashRecordsCategories_Id).Name, "Category: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Amount, amount, "Amount: '{0:N2}' to '{1:N2}'");
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("Notifications_update", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Timestamp, SqlDbType.DateTime).Value = timestamp;
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

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

