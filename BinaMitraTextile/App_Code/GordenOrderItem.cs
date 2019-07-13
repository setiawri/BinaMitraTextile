using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class GordenOrderItem
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public Guid GordenOrderID;
        public int LineNo = 0;
        public string Description = "";
        public decimal SellAmountPerUnit = 0;
        public decimal Qty = 0;
        public string Notes = "";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string FILTER_EMPTYTABLE = "is_emptytable";

        public const string COL_DB_ID = "id";
        public const string COL_DB_GORDENORDERID = "gordenorder_id";
        public const string COL_DB_LINENO = "line_no";
        public const string COL_DB_DESCRIPTION = "description";
        public const string COL_DB_SELLAMOUNTPERUNIT = "sell_amount_perunit";
        public const string COL_DB_QTY = "qty";
        public const string COL_DB_NOTES = "notes";

        public const string COL_SUBTOTAL = "subtotal";

        #endregion DATABASE FIELDS
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public GordenOrderItem() { }
        public GordenOrderItem(Guid id)
        {
            DataRow row = get(id);
            ID = id;
            GordenOrderID = DBUtil.parseData<Guid>(row, COL_DB_GORDENORDERID);
            LineNo = DBUtil.parseData<int>(row, COL_DB_LINENO);
            Description = DBUtil.parseData<string>(row, COL_DB_DESCRIPTION);
            SellAmountPerUnit = DBUtil.parseData<decimal>(row, COL_DB_SELLAMOUNTPERUNIT);
            Qty = DBUtil.parseData<int>(row, COL_DB_QTY);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static void addItems(SqlConnection conn, DataTable datatable)
        {
            try
            {
                foreach (DataRow row in datatable.Rows)
                    add(conn, 
                        DBUtil.parseData<Guid>(row, COL_DB_GORDENORDERID),
                        DBUtil.parseData<int>(row, COL_DB_LINENO),
                        DBUtil.parseData<string>(row, COL_DB_DESCRIPTION),
                        DBUtil.parseData<decimal>(row, COL_DB_SELLAMOUNTPERUNIT),
                        DBUtil.parseData<int>(row, COL_DB_QTY),
                        DBUtil.parseData<string>(row, COL_DB_NOTES));
            }
            catch { }
        }

        public static void add(SqlConnection conn, Guid gordenOrderID, int lineNo, string description, decimal sellAmountPerUnit, int qty, string notes)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("gordenorderitem_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    Guid id = Guid.NewGuid();
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_GORDENORDERID, SqlDbType.UniqueIdentifier).Value = gordenOrderID;
                    cmd.Parameters.Add("@" + COL_DB_LINENO, SqlDbType.TinyInt).Value = lineNo;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_SELLAMOUNTPERUNIT, SqlDbType.Decimal).Value = sellAmountPerUnit;
                    cmd.Parameters.Add("@" + COL_DB_QTY, SqlDbType.Int).Value = qty;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    if(conn.State != ConnectionState.Open) conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "Item added");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataTable get() { return get(true, null, null, null, null); }

        public static DataRow get(Guid ID) { return Tools.getFirstRow(get(false, ID, null, null, null)); }

        public static DataTable getItems(Guid gordenOrderID) { return get(false, null, gordenOrderID, null, null); }

        public static DataTable get(bool isEmptyTable, Guid? id, Guid? gordenOrderID, string description, string notes)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("gordenorderitem_get", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + FILTER_EMPTYTABLE, SqlDbType.Bit).Value = isEmptyTable;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_GORDENORDERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(gordenOrderID);
                cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = Tools.wrapNullable(description);
                cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                adapter.SelectCommand = cmd;
                adapter.Fill(datatable);
            }
            return datatable;
        }

        public static void update(Guid id, string description, decimal sellAmountPerUnit, int qty, string notes)
        {
            try
            {
                string log = "";
                GordenOrderItem objOld = new GordenOrderItem(id);
                log = ActivityLog.appendChange(log, objOld.Description, description, "Description: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.SellAmountPerUnit, sellAmountPerUnit, "Sell Amount Per Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Qty, qty, "Qty: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("gordenorderitem_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_SELLAMOUNTPERUNIT, SqlDbType.Decimal).Value = sellAmountPerUnit;
                    cmd.Parameters.Add("@" + COL_DB_QTY, SqlDbType.Int).Value = qty;
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
                using (SqlCommand cmd = new SqlCommand("gordenorderitem_delete", conn))
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
