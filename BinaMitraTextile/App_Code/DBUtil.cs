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
        public static Timer SqlConnectionTimer;

        public static string ServerName = "";

        public static bool isServerEnvironment { get { return Util.isMachineNameEqualConfigVariable("serverComputerName"); } }
        public static bool isDevEnvironment { get { return Util.isMachineNameEqualConfigVariable("devComputerName"); } }
        public static bool isSalesEnvironment {
            get
            {
                return Util.isMachineNameEqualConfigVariable("salesComputerName") 
                    || Util.isMachineNameEqualConfigVariable("tabComputerName")
                    || Util.isMachineNameEqualConfigVariable("salesComputerName2");
            }
        }

        public static string ServerName_Live { get { return Util.getConfigVariable("serverName_Live"); } }
        public static string ServerName_LiveLocal { get { return Util.getConfigVariable("serverName_LiveLocal"); } }
        public static string ServerName_LiveForServer { get { return Util.getConfigVariable("serverName_LiveForServer"); } }
        public static string ServerName_DEV { get { return Util.getConfigVariable("serverName_DEV"); } }

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
            return DBConnection.isDBConnectionAvailable(Properties.Resources.handshake_512_white, true, true);
        }

        public static DataTable getData(string sql)
        {
            return getData(new SqlCommand(sql, DBConnection.ActiveSqlConnection));
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
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                foreach (Guid id in IDArray)
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, DBConnection.ActiveSqlConnection))
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

        public static void updateActiveStatus(string storedProcedure, Guid id, Boolean activeStatus)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                storedProcedure,
                new SqlQueryParameter("id", SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter("new_active", SqlDbType.Bit, activeStatus)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Active status changed to: " + activeStatus.ToString().ToLower());
        }
        
        public static void updateDefaultRow(string storedProcedure, Guid id, string logDescription)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                storedProcedure,
                new SqlQueryParameter("id", SqlDbType.UniqueIdentifier, id)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, logDescription);
        }

        public static T parseData<T>(object value)
        {
            return Util.wrapNullable<T>(value);
        }

        public static T parseData<T>(DataRow row, string columnName)
        {
            object obj = null;
            if(row != null)
                obj = row[columnName];
            return Util.wrapNullable<T>(obj);
            //if (obj == DBNull.Value)
            //    return default(T);

            ////types that need specific casts
            //if (typeof(T) == typeof(Int16))
            //    obj = Convert.ToInt16(obj);
            //else if (typeof(T) == typeof(String))
            //    obj = obj.ToString();

            //return (T)obj;
        }

        public static void addNotes(string storedProcedure, Guid id, string notes)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                storedProcedure,
                new SqlQueryParameter("id", SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter("timestamp", SqlDbType.VarChar, string.Format("{0:dd/MM/yy}", DateTime.Now)),
                new SqlQueryParameter("username", SqlDbType.VarChar, GlobalData.UserAccount.name),
                new SqlQueryParameter("notes", SqlDbType.VarChar, notes)
            );
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

    }
}
