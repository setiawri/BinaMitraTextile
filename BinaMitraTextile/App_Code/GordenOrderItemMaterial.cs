using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class GordenOrderItemMaterial
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public Guid GordenOrderItemID;
        public Guid GordenItemID;
        public string Description = "";
        public decimal BuyAmountPerUnit = 0;
        public decimal Qty = 0;
        public string Notes = "";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_ID = "id";
        public const string COL_DB_GORDENORDERITEMID = "gordenorderitem_id";
        public const string COL_DB_GORDENITEMID = "gordenitem_id";
        public const string COL_DB_DESCRIPTION = "description";
        public const string COL_DB_BUYAMOUNTPERUNIT = "buy_amount_perunit";
        public const string COL_DB_QTY = "qty";
        public const string COL_DB_NOTES = "notes";

        #endregion DATABASE FIELDS
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public GordenOrderItemMaterial() { }
        public GordenOrderItemMaterial(Guid id)
        {
            DataRow row = get(id);
            ID = id;
            GordenOrderItemID = DBUtil.parseData<Guid>(row, COL_DB_GORDENORDERITEMID);
            GordenItemID = DBUtil.parseData<Guid>(row, COL_DB_GORDENITEMID);
            Description = DBUtil.parseData<string>(row, COL_DB_DESCRIPTION);
            BuyAmountPerUnit = DBUtil.parseData<decimal>(row, COL_DB_BUYAMOUNTPERUNIT);
            Qty = DBUtil.parseData<int>(row, COL_DB_QTY);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
        }
        public GordenOrderItemMaterial(Guid? gordenOrderItemID, Guid gordenItemID, decimal qty, string notes)
        {
            ID = Guid.NewGuid();
            if(gordenOrderItemID != null) GordenOrderItemID = (Guid)gordenOrderItemID;
            Qty = qty;
            Notes = notes;

            GordenItem item = new GordenItem(GordenItemID);
            GordenItemID = item.ID;
            Description = item.Name;
            BuyAmountPerUnit = item.SellRetailPricePerUnit;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        //public static void add(string notes)
        //{
        //    Guid id = Guid.NewGuid();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
        //        using (SqlCommand cmd = new SqlCommand("gordenorderitemmaterial_add", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
        //            cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();

        //            ActivityLog.submit(conn, id, "Item added");
        //        }
        //    }
        //    catch (Exception ex) { Tools.showError(ex.Message); }
        //}

        public static void addItems(List<GordenOrderItemMaterial> materials)
        {
            try
            {
                foreach(GordenOrderItemMaterial material in materials)
                using (SqlCommand cmd = new SqlCommand("gordenorderitemmaterial_add", DBUtil.ActiveSqlConnection))
                {
                    Guid id = Guid.NewGuid();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_GORDENORDERITEMID, SqlDbType.UniqueIdentifier).Value = material.GordenOrderItemID;
                    cmd.Parameters.Add("@" + COL_DB_GORDENITEMID, SqlDbType.UniqueIdentifier).Value = material.GordenItemID;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.UniqueIdentifier).Value = material.Description;
                    cmd.Parameters.Add("@" + COL_DB_BUYAMOUNTPERUNIT, SqlDbType.UniqueIdentifier).Value = material.BuyAmountPerUnit;
                    cmd.Parameters.Add("@" + COL_DB_QTY, SqlDbType.UniqueIdentifier).Value = material.Qty;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(material.Notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item added");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataRow get(Guid ID) { return Tools.getFirstRow(get(ID, null)); }

        public static DataTable get(Guid? ID, string notes)
        {
            DataTable datatable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("gordenorderitemmaterial_get", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ID);
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

                using (SqlCommand cmd = new SqlCommand("gordenorderitemmaterial_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", log));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static string delete(Guid id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("gordenorderitemmaterial_delete", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item deleted");
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
