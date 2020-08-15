using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using LIBUtil;

namespace BinaMitraTextile
{
    public enum ToDoStatus
    {
        New,
        [Description("In Progress")]
        InProgress,
        [Description("On Hold")]
        OnHold,
        [Description("Waiting")]
        Waiting,
        Completed
    };

    public class ToDo
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_TIMESTAMP = "timestamp";
        public const string COL_DB_DESCRIPTION = "description";
        public const string COL_DB_STATUSENUMID = "status_enum_id";
        public const string COL_DB_CUSTOMERID = "customer_id";
        public const string COL_DB_VENDORID = "vendor_id";

        public const string COL_STATUSNAME = "status_name";
        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_VENDORNAME = "vendor_name";

        public const string FILTER_ExcludeCompletedStatusEnumId = "FILTER_ExcludeCompletedStatusEnumId";

        public Guid ID;
        public DateTime Timestamp;
        public string Description;
        public ToDoStatus Status;
        public Guid? CustomerID;
        public Guid? VendorID;

        public string CustomerName;
        public string VendorName;

        public ToDo() { }

        public ToDo(Guid id)
        {
            ID = id;
            DataRow row = getRow(ID).Rows[0];
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_TIMESTAMP);
            Description = DBUtil.parseData<string>(row, COL_DB_DESCRIPTION);
            Status = Tools.parseEnum<ToDoStatus>(DBUtil.parseData<Int16>(row, COL_DB_STATUSENUMID));
            CustomerID = DBUtil.parseData<Guid?>(row, COL_DB_CUSTOMERID);
            VendorID = DBUtil.parseData<Guid?>(row, COL_DB_VENDORID);

            CustomerName = DBUtil.parseData<string>(row, COL_CUSTOMERNAME);
            VendorName = DBUtil.parseData<string>(row, COL_VENDORNAME);
        }

        public static Guid? add(string description, Guid? customerID, Guid? vendorID)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "todo_add",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_DESCRIPTION, SqlDbType.VarChar, description),
                new SqlQueryParameter(COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier, Util.wrapNullable(customerID)),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static void update(Guid id, string description, Guid? customerID, Guid? vendorID)
        {
            ToDo objOld = new ToDo(id);

            //generate log description
            string logDescription = "";
            if (objOld.Description != description) logDescription = Tools.append(logDescription, String.Format("Description: '{0}' to '{1}'", objOld.Description, description), ",");
            if (objOld.CustomerID != customerID) { logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}' to '{1}'", objOld.CustomerName, new Customer(customerID).Name), ","); }
            if (objOld.VendorID != vendorID) { logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}' to '{1}'", objOld.VendorName, new Vendor(vendorID).Name), ","); }

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "todo_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_DESCRIPTION, SqlDbType.VarChar, description),
                    new SqlQueryParameter(COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier, Util.wrapNullable(customerID)),
                    new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(id, "Update: " + logDescription);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("todo_get", ID);
        }

        public static DataTable get(string description, Guid? customerID, Guid? vendorID, bool includeCompleted)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("todo_get_byFilter", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = Util.wrapNullable(description);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(customerID);
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(vendorID);
                if(!includeCompleted)
                    cmd.Parameters.Add("@" + FILTER_ExcludeCompletedStatusEnumId, SqlDbType.TinyInt).Value = (int)ToDoStatus.Completed;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            Tools.parseEnum<ToDoStatus>(dataTable, COL_STATUSNAME, COL_DB_STATUSENUMID);

            return dataTable;
        }

        public static void updateStatus(Guid id, ToDoStatus statusEnumID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "todo_update_status",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_STATUSENUMID, SqlDbType.TinyInt, statusEnumID)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Status to " + statusEnumID.ToString());
        }
        
    }
}
