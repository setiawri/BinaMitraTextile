using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

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

        public static DataTable getAll(Guid AssociatedID)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("activitylog_getall", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@associated_id", SqlDbType.UniqueIdentifier).Value = AssociatedID;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static string submit(Guid associatedID, string description)
        {
            return submit(associatedID, description, null);
        }

        public static string submit(Guid associatedID, string description, int? notifyRoleEnum)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("activity_log_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    cmd.Parameters.Add("@time_stamp", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@associated_id", SqlDbType.UniqueIdentifier).Value = associatedID;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@userID", SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                    cmd.Parameters.Add("@notify_role_enum_id", SqlDbType.SmallInt).Value = Tools.wrapNullable(notifyRoleEnum);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
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
