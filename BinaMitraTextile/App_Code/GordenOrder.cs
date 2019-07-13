using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class GordenOrder
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public int No;
        public DateTime Timestamp;
        public Guid CustomerID;
        public string CustomerInfo = "";
        public decimal DiscountAmount = 0;
        public decimal OtherCharges = 0;
        public string Notes = "";

        public string NoHex = "";
        public decimal OrderAmount = 0;
        public string CustomerName = "";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_ID = "id";
        public const string COL_DB_NO = "no";
        public const string COL_DB_TIMESTAMP = "timestamp";
        public const string COL_DB_CUSTOMERID = "customer_id";
        public const string COL_DB_CUSTOMERINFO = "customer_info";
        public const string COL_DB_DISCOUNTAMOUNT = "discount_amount";
        public const string COL_DB_OTHERCHARGES = "other_charges";
        public const string COL_DB_NOTES = "notes";

        public const string COL_NOHEX = "no_hex";
        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_ORDERAMOUNT = "order_amount";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public GordenOrder() { }
        public GordenOrder(Guid id)
        {
            DataRow row = get(id);
            ID = id;
            No = DBUtil.parseData<int>(row, COL_DB_NO);
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_TIMESTAMP);
            CustomerID = DBUtil.parseData<Guid>(row, COL_DB_CUSTOMERID);
            CustomerInfo = DBUtil.parseData<string>(row, COL_DB_CUSTOMERINFO);
            DiscountAmount = DBUtil.parseData<decimal>(row, COL_DB_DISCOUNTAMOUNT);
            OtherCharges = DBUtil.parseData<decimal>(row, COL_DB_OTHERCHARGES);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);

            NoHex = DBUtil.parseData<string>(row, COL_NOHEX);
            CustomerName = DBUtil.parseData<string>(row, COL_CUSTOMERNAME);
            OrderAmount = DBUtil.parseData<decimal>(row, COL_ORDERAMOUNT);
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static string add(Guid id, Guid customerID, string customerInfo, decimal discountAmount, decimal otherCharges, string notes, 
            DataTable gordenOrderItems, List<GordenOrderItemMaterial> materials)
        {
            string no = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("gordenorder_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERINFO, SqlDbType.VarChar).Value = customerInfo;
                    cmd.Parameters.Add("@" + COL_DB_DISCOUNTAMOUNT, SqlDbType.Decimal).Value = discountAmount;
                    cmd.Parameters.Add("@" + COL_DB_OTHERCHARGES, SqlDbType.Decimal).Value = otherCharges;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);
                    SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                    return_value.Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    no = Convert.ToInt32(return_value.Value).ToString();

                    ActivityLog.submit(conn, id, "Item added");

                    GordenOrderItem.addItems(conn, gordenOrderItems);
                    GordenOrderItemMaterial.addItems(conn, materials);
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }

            return no;
        }

        public static DataRow get(Guid ID) { return Tools.getFirstRow(get(ID, null, null, null)); }

        public static DataTable get(Guid? ID, int? no, Guid? customerID, string notes)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("gordenorder_get", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ID);
                cmd.Parameters.Add("@" + COL_DB_NO, SqlDbType.Int).Value = Tools.wrapNullable(no);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);
                cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                adapter.SelectCommand = cmd;
                adapter.Fill(datatable);
            }
            return datatable;
        }

        public static void update(Guid id, string notes)
        {
            try
            {
                string log = "";
                GordenOrderItem objOld = new GordenOrderItem(id);
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("gordenorder_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, String.Format("Item updated: {0}", log));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static string delete(Guid id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("gordenorder_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "Item deleted");
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
