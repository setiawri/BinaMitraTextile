using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;

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

        public static void add(string description, Guid? customerID, Guid? vendorID)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("todo_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);
                    cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);

                    cmd.ExecuteNonQuery();

                    //ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid id, string description, Guid? customerID, Guid? vendorID)
        {
            try
            {
                ToDo objOld = new ToDo(id);

                //generate log description
                string logDescription = "";
                if (objOld.Description != description) logDescription = Tools.append(logDescription, String.Format("Description: '{0}' to '{1}'", objOld.Description, description), ",");
                if (objOld.CustomerID != customerID) { logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}' to '{1}'", objOld.CustomerName, new Customer(customerID).Name), ","); }
                if (objOld.VendorID != vendorID) { logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}' to '{1}'", objOld.VendorName, new Vendor(vendorID).Name), ","); }

                using (SqlCommand cmd = new SqlCommand("todo_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);
                    cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", logDescription));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("todo_get", ID);
        }

        public static DataTable get(string description, Guid? customerID, Guid? vendorID, bool includeCompleted)
        {
            //Tools.startProgressDisplay("Donwloading data...");

            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("todo_get_byFilter", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = Tools.wrapNullable(description);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                if(!includeCompleted)
                    cmd.Parameters.Add("@" + FILTER_ExcludeCompletedStatusEnumId, SqlDbType.TinyInt).Value = (int)ToDoStatus.Completed;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            Tools.parseEnum<ToDoStatus>(dataTable, COL_STATUSNAME, COL_DB_STATUSENUMID);

            //Tools.stopProgressDisplay();

            return dataTable;
        }

        public static void updateStatus(Guid id, ToDoStatus statusEnumID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("todo_update_status", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STATUSENUMID, SqlDbType.TinyInt).Value = statusEnumID;
                    
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Status changed to: " + statusEnumID.ToString());
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }
        
    }
}
