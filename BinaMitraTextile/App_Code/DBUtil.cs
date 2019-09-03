using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LIBUtil;

namespace BinaMitraTextile
{
    public class DBUtil
    {
        public const string COL_DEFAULT_ROW = "default_row";
        public const string COL_ACTIVE = "active";

        public const string TYPE_ARRAY_NAME = "dbo.Array";
        public const string TYPE_ARRAY_STR = "value_str";
        public const string TYPE_ARRAY_INT = "value_int";

        public static bool ConnectionTestCompleted;

        public static bool isServerEnvironment { get { return Util.isMachineNameEqualConfigVariable("serverComputerName"); } }
        public static bool isDevEnvironment { get { return Util.isMachineNameEqualConfigVariable("devComputerName"); } }
        public static bool isSalesEnvironment {
            get { return Util.isMachineNameEqualConfigVariable("salesComputerName") || Util.isMachineNameEqualConfigVariable("tabComputerName"); }
        }

        public static string connectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                    setConnectionString();
                return _connectionString;
            }
        }
        private static string _connectionString = "";

        public static string setConnectionString()
        {
            if (GlobalData.ConnectToLocalLiveDB)
                _connectionString = ConfigurationManager.ConnectionStrings["connDBLiveLocal"].ConnectionString;
            else if (GlobalData.ConnectToDevDB)
                _connectionString = ConfigurationManager.ConnectionStrings["connDBDev"].ConnectionString;
            else if (GlobalData.ConnectAsServer)
                _connectionString = ConfigurationManager.ConnectionStrings["connDBLiveForServer"].ConnectionString;
            else
                _connectionString = ConfigurationManager.ConnectionStrings["connDBLive"].ConnectionString;
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_connectionString);
            string servername = builder.DataSource;
            if(servername.IndexOf(',') > -1)
            {
                servername = servername.Substring(0, servername.IndexOf(','));
            }

            if(!string.IsNullOrEmpty(GlobalData.LiveConnectionPort))
            {
                builder.DataSource = servername + ',' + GlobalData.LiveConnectionPort;
                _connectionString = builder.ConnectionString;
            }

            return _connectionString;
        }

        public static string connectionInfo()
        {
            string connectionInfo = connectionString;
            if (connectionInfo.IndexOf(';') > 0)
                connectionInfo = connectionInfo.Substring(0, connectionInfo.IndexOf(';'));
            return connectionInfo;
        }

        public static string appendTitleWithInfo()
        {
            string info = "";

            if (GlobalData.UserAccount != null)
                info += " - " + GlobalData.UserAccount.name;

            if (GlobalData.ConnectToLiveDB)
                info += string.Format(" (LIVE DB)");
            else if (GlobalData.ConnectToLocalLiveDB)
                info += string.Format(" (LOCAL LIVE DB)");
            else if (GlobalData.ConnectToDevDB)
                info += string.Format(" (DEV DB)");
            else if (GlobalData.ConnectAsServer)
                info += string.Format(" (AS SERVER)");

            return info;
        }

        public static bool isDBConnectionAvailable()
        {
            var form = new SharedForms.CheckDBConnection();
            form.ShowDialog();
            if (form.isDBConnectionAvailable)
                return true;
            else
                return false;
        }

        public static void testDBConnection()
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.setConnectionString()))
            {
                conn.Open();
            }
        }

        public static Object getValue(string storedProcedure)
        {
            Object obj;
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
            {
                conn.Open();
                obj = cmd.ExecuteScalar();
                conn.Close();
            }
            return obj;
        }

        public static DataTable getDataUsingStoredProcedure(string storedProcedureName)
        {
            DataTable datatable = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(datatable);
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }

            return datatable;
        }

        public static DataTable getData(string sql)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            {
                datatable = getData(new SqlCommand(sql, conn));
            }
            return datatable;
        }

        public static DataTable getData(string sql, SqlConnection conn)
        {
            return getData(new SqlCommand(sql, conn));
        }

        public static DataTable getData(SqlCommand cmd)
        {
            DataTable datatable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(datatable);
            }
            return datatable;
        }

        public static DataTable getRows(string storedProcedure, Guid[] IDArray)
        {
            DataTable masterTable = new DataTable();
            DataTable dataTable;
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                foreach (Guid id in IDArray)
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

                        adapter.SelectCommand = cmd;
                        if (masterTable.Rows.Count == 0)
                            adapter.Fill(masterTable);
                        else
                        {
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            foreach (DataRow dr in dataTable.Rows)
                                masterTable.Rows.Add(dr.ItemArray);
                        }
                    }
                }
            }
            return masterTable;
        }

        public static DataTable getRows(string storedProcedure, Guid ID)
        {
            return getRows(storedProcedure, new Guid[] { ID });
        }

        public static string sanitize(string str)
        {
            return (str ?? string.Empty).Replace(";", "").Trim(); //sanitize input in case of sql injection
        }

        public static string sanitize(params TextBox[] textboxes)
        {
            foreach (TextBox textbox in textboxes)
                textbox.Text = sanitize(textbox.Text);

            if (textboxes.Length == 1)
                return textboxes[0].Text;
            else
                return null;
        }

        public static string sanitizeAndNullifyIfEmpty(TextBox textbox)
        {
            string text = sanitize(textbox);
            if (string.IsNullOrEmpty(text))
                return null;
            else
                return text;
        }

        public static void updateDB(string sql, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static string updateActiveStatus(string storedProcedure, Guid id, Boolean activeStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@new_active", SqlDbType.Bit).Value = activeStatus;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "Active status changed to: " + activeStatus.ToString().ToLower());
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }
        
        public static string updateDefaultRow(string storedProcedure, Guid id, string logDescription)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, logDescription);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static T parseData<T>(object value)
        {
            return Tools.wrapDBNullValue<T>(value);
        }

        public static T parseData<T>(DataRow row, string columnName)
        {
            object obj = null;
            if(row != null)
                obj = row[columnName];
            return Tools.wrapDBNullValue<T>(obj);
            //if (obj == DBNull.Value)
            //    return default(T);

            ////types that need specific casts
            //if (typeof(T) == typeof(Int16))
            //    obj = Convert.ToInt16(obj);
            //else if (typeof(T) == typeof(String))
            //    obj = obj.ToString();

            //return (T)obj;
        }

        public static string addNotes(string storedProcedure, Guid id, string notes)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                {
                    //submit new sale record
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@timestamp", SqlDbType.VarChar).Value = string.Format("{0:dd/MM/yy}", DateTime.Now);
                        cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = GlobalData.UserAccount.name;
                        cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static void addListParameter(SqlCommand cmd, string name, DataTable data)
        {
            SqlParameter param = cmd.Parameters.Add(name, SqlDbType.Structured);
            param.Value = data;
            param.TypeName = DBUtil.TYPE_ARRAY_NAME;


            //SqlParameter param = new SqlParameter();
            //param.SqlDbType = SqlDbType.Structured;
            //param.TypeName = DBUtil.TYPE_ARRAY_NAME;
            //param.ParameterName = name;
            //param.Value = data;
            //cmd.Parameters.Add(param);
        }

        public static DateTime getServerTime()
        {
            DateTime timestamp = new DateTime();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("server_get_timestamp", sqlConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter return_value = cmd.Parameters.Add("@timestamp", SqlDbType.DateTime);
                    return_value.Direction = ParameterDirection.Output;

                    if (sqlConnection.State != ConnectionState.Open) sqlConnection.Open();
                    cmd.ExecuteNonQuery();

                    timestamp = Convert.ToDateTime(return_value.Value);
                }
            }
            catch { }

            return timestamp;
        }

    }
}
