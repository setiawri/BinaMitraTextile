using System;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile
{
    public class ActivityLog
    {
        public const string COL_DB_Id = "id";
        public const string COL_DB_Timestamp = "time_stamp";
        public const string COL_DB_AssociatedId = "associated_id";
        public const string COL_DB_Description = "description";
        public const string COL_DB_UserId = "userID";
        public const string COL_DB_NotifyRoleEnumId = "notify_role_enum_id";

        public const string COL_Username = "username";

        public static DataTable getAll(Guid AssociatedID)
        {
            SqlQueryResult result = DBConnection.query(
                false, 
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "activitylog_getall",
                new SqlQueryParameter(COL_DB_AssociatedId, SqlDbType.UniqueIdentifier, AssociatedID)
            );
            return result.Datatable;
        }

        public static void submit(Guid associatedID, string description)
        {
            submit(associatedID, description, null);
        }

        public static void submit(Guid associatedID, string description, int? notifyRoleEnum)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "activity_log_new",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Guid.NewGuid()),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, DateTime.Now),
                new SqlQueryParameter(COL_DB_AssociatedId, SqlDbType.UniqueIdentifier, associatedID),
                new SqlQueryParameter(COL_DB_Description, SqlDbType.VarChar, description),
                new SqlQueryParameter(COL_DB_UserId, SqlDbType.UniqueIdentifier, GlobalData.UserAccount.id),
                new SqlQueryParameter(COL_DB_NotifyRoleEnumId, SqlDbType.SmallInt, Util.wrapNullable(notifyRoleEnum))
            );
        }

        public static string appendChange(string log, object oldValue, object newValue, string logFormat)
        {
            string oldV = "";
            string newV = "";
            if(oldValue != null) oldV = oldValue.ToString();
            if(newValue != null) newV = newValue.ToString();

            if (oldV != newV) return Tools.append(log, String.Format(logFormat, oldV, newV), ",");
            return log;
        }
    }
}
