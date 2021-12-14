using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

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

        public static Guid? add(DateTime timestamp, Guid activityLogs_Id, int roles_EnumId)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Notifications_add",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, timestamp),
                new SqlQueryParameter(COL_DB_ActivityLogs_Id, SqlDbType.UniqueIdentifier, activityLogs_Id),
                new SqlQueryParameter(COL_DB_Roles_EnumId, SqlDbType.TinyInt, roles_EnumId)
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static DataRow get(Guid id) { return Tools.getFirstRow(get(id, null, null, null, null)); }

        public static DataTable get(Guid? id, DateTime? timestamp_Start, DateTime? timestamp_End, int? roles_EnumId, bool active)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Notifications_get",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_FILTER_Timestamp_Start, SqlDbType.DateTime, Util.wrapNullable(timestamp_Start)),
                new SqlQueryParameter(COL_FILTER_Timestamp_End, SqlDbType.DateTime, Util.wrapNullable(timestamp_End)),
                //new SqlQueryParameter(COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(pettyCashRecordsCategories_Id)),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            return Tools.parseEnum<Roles>(result.Datatable, COL_Roles_Name, COL_Roles_Name);
        }

        public static void update(Guid id, DateTime timestamp, Guid pettyCashRecordsCategories_Id, decimal amount, string notes)
        {
            //PettyCashRecord objOld = new PettyCashRecord(id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.Timestamp, timestamp, "Timestamp: '{0}' to '{1}'");
            //log = ActivityLog.appendChange(log, objOld.PettyCashRecordsCategories_Name, new PettyCashRecordsCategory(pettyCashRecordsCategories_Id).Name, "Category: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.Amount, amount, "Amount: '{0:N2}' to '{1:N2}'");
            log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Notifications_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, timestamp),
                    //new SqlQueryParameter(COL_DB_PettyCashRecordsCategories_Id, SqlDbType.UniqueIdentifier, pettyCashRecordsCategories_Id),
                    new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, amount),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                {
                    if (GlobalData.UserAccount.role != Roles.Super)
                        ActivityLog.submit(sqlConnection, id, "Update: " + log, (int)Roles.Super);
                    else
                        ActivityLog.submit(sqlConnection, id, "Update: " + log);
                }
            }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

