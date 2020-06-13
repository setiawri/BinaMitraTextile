using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    public struct POItemToOrder
    {
        public Guid InventoryID;
        public int Qty;
        public string PONotes;
    }

    public class InventoryStockLevel
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_CODE = "code";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_PONOTES = "po_notes";
        public const string COL_DB_PRODUCTWIDTHID = "product_width_id";
        public const string COL_DB_LENGTHUNITID = "length_unit_id";
        public const string COL_DB_COLORID = "color_id";
        public const string COL_DB_PRODUCTID = "product_id";
        public const string COL_DB_GRADEID = "grade_id";
        public const string COL_DB_QTY = "qty";
        public const string COL_DB_ORDERLOTQTY = "order_lot_qty";

        public const string COL_GRADE_NAME = "grade_name";
        public const string COL_PRODUCTSTORENAMEID = "store_name_id";
        public const string COL_PRODUCTSTORENAME = "store_name";
        public const string COL_VENDORNAME = "vendor_name";
        public const string COL_LENGTH_UNIT_NAME = "length_unit_name";
        public const string COL_PRODUCT_WIDTH_NAME = "width_name";
        public const string COL_COLOR_NAME = "color_name";
        public const string COL_VENDORID = "vendor_id";
        public const string COL_REMAININGSTOCKQTY = "remainingstock_qty";
        public const string COL_PENDINGDELIVERYQTY = "pendingdelivery_qty";
        public const string COL_BOOKEDQTY = "booked_qty";
        public const string COL_LASTORDERINVENTORYID = "last_order_inventory_id";
        public const string COL_LASTORDERTIMESTAMP = "last_order_timestamp";
        public const string COL_NEWORDER_QTY = "new_order_qty";

        public Guid ID;
        public string GradeName = "";
        public string LengthUnitName = "";
        public string ColorName = "";
        public string ProductStoreName = "";
        public string VendorName = "";
        public Guid VendorID;
        public string ProductWidthName = "";
        public Guid ProductStoreNameID;
        public Guid GradeID;
        public Guid ProductID;
        public Guid ProductWidthID;
        public Guid LengthUnitID;
        public Guid ColorID;
        public int OrderLotQty = 0;
        public int Qty = 0;
        public string PONotes = "";
        public string Notes = "";

        public InventoryStockLevel() { }

        public InventoryStockLevel(Guid id)
        {
            ID = id;
            DataRow row = getRow(ID).Rows[0];
            ProductID = DBUtil.parseData<Guid>(row, COL_DB_PRODUCTID);
            ProductWidthID = DBUtil.parseData<Guid>(row, COL_DB_PRODUCTWIDTHID);
            GradeID = DBUtil.parseData<Guid>(row, COL_DB_GRADEID);
            LengthUnitID = DBUtil.parseData<Guid>(row, COL_DB_LENGTHUNITID);
            ColorID = DBUtil.parseData<Guid>(row, COL_DB_COLORID);
            OrderLotQty = DBUtil.parseData<int>(row, COL_DB_ORDERLOTQTY);
            Qty = DBUtil.parseData<int>(row, COL_DB_QTY);
            PONotes = DBUtil.parseData<string>(row, COL_DB_PONOTES);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);

            ProductStoreNameID = DBUtil.parseData<Guid>(row, COL_PRODUCTSTORENAMEID);
            ProductStoreName = DBUtil.parseData<string>(row, COL_PRODUCTSTORENAME);
            VendorName = DBUtil.parseData<string>(row, COL_VENDORNAME);
            VendorID = DBUtil.parseData<Guid>(row, COL_VENDORID);
            GradeName = DBUtil.parseData<string>(row, COL_GRADE_NAME);
            LengthUnitName = DBUtil.parseData<string>(row, COL_LENGTH_UNIT_NAME);
            ProductWidthName = DBUtil.parseData<string>(row, COL_PRODUCT_WIDTH_NAME);
            ColorName = DBUtil.parseData<string>(row, COL_COLOR_NAME);
        }

        public static void add(Guid gradeID, Guid productID, Guid productWidthID, Guid lengthUnitID, Guid colorID, int qty, int orderLotQty, string poNotes, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("inventorystocklevel_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier).Value = productID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = colorID;
                    cmd.Parameters.Add("@" + COL_DB_ORDERLOTQTY, SqlDbType.Int).Value = orderLotQty;
                    cmd.Parameters.Add("@" + COL_DB_QTY, SqlDbType.Int).Value = qty;
                    cmd.Parameters.Add("@" + COL_DB_PONOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(poNotes);
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isCombinationExist(Guid? id, Guid gradeID, Guid productID, Guid productWidthID, Guid lengthUnitID, Guid colorID)
        {
            using (SqlCommand cmd = new SqlCommand("inventorystocklevel_isCombinationExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                cmd.Parameters.Add("@" + COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier).Value = productID;
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = colorID;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static void update(Guid id, Guid gradeID, Guid productID, Guid productWidthID, Guid lengthUnitID, Guid colorID, int qty, int orderLotQty, string poNotes, string notes)
        {
            try
            {
                InventoryStockLevel objOld = new InventoryStockLevel(id);

                //generate log description
                string logDescription = "";
                Product product = new Product(productID);
                if (objOld.ProductStoreNameID != product.StoreNameID) logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}' to '{1}'", objOld.ProductStoreName, product.StoreName), ",");
                if (objOld.GradeID != gradeID) logDescription = Tools.append(logDescription, String.Format("Grade: '{0}' to '{1}'", objOld.GradeID, new Grade(gradeID).Name), ",");
                if (objOld.ProductWidthID != productWidthID) logDescription = Tools.append(logDescription, String.Format("Product Width: '{0}' to '{1}'", objOld.ProductWidthName, new ProductWidth(productWidthID).Name), ",");
                if (objOld.LengthUnitID != lengthUnitID) logDescription = Tools.append(logDescription, String.Format("Length Unit: '{0}' to '{1}'", objOld.LengthUnitID, new LengthUnit(lengthUnitID).Name), ",");
                if (objOld.VendorName != product.VendorName) logDescription = Tools.append(logDescription, String.Format("Vendor: '{0}' to '{1}'", objOld.VendorName, product.VendorName), ",");
                if (objOld.OrderLotQty != orderLotQty) logDescription = Tools.append(logDescription, String.Format("Lot qty: '{0}' to '{1}'", objOld.OrderLotQty, orderLotQty), ",");
                if (objOld.Qty != qty) logDescription = Tools.append(logDescription, String.Format("Qty: '{0}' to '{1}'", objOld.Qty, qty), ",");
                if (objOld.PONotes != poNotes) logDescription = Tools.append(logDescription, String.Format("PO Notes: '{0}' to '{1}'", objOld.PONotes, poNotes), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

                using (SqlCommand cmd = new SqlCommand("inventorystocklevel_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier).Value = productID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = colorID;
                    cmd.Parameters.Add("@" + COL_DB_ORDERLOTQTY, SqlDbType.Int).Value = orderLotQty;
                    cmd.Parameters.Add("@" + COL_DB_QTY, SqlDbType.Int).Value = qty;
                    cmd.Parameters.Add("@" + COL_DB_PONOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(poNotes);
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", logDescription));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static string delete(Guid id)
        {
            try
            {
                InventoryStockLevel obj = new InventoryStockLevel(id);

                //generate log description
                string logDescription = "";
                logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}'", obj.ProductStoreName), ",");
                logDescription = Tools.append(logDescription, String.Format("Grade: '{0}'", obj.GradeName), ",");
                logDescription = Tools.append(logDescription, String.Format("Product Width: '{0}'", obj.ProductWidthName), ",");
                logDescription = Tools.append(logDescription, String.Format("Length Unit: '{0}'", obj.LengthUnitName), ",");
                logDescription = Tools.append(logDescription, String.Format("Vendor: '{0}'", obj.VendorName), ",");
                logDescription = Tools.append(logDescription, String.Format("Qty: '{0}'", obj.Qty), ",");
                logDescription = Tools.append(logDescription, String.Format("PO Notes: '{0}'", obj.PONotes), ",");
                logDescription = Tools.append(logDescription, String.Format("Notes: '{0}'", obj.Notes), ",");

                using (SqlCommand cmd = new SqlCommand("inventorystocklevel_delete", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item deleted: {0}", logDescription));
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("inventorystocklevel_get", ID);
        }

        public static DataTable getAll(Guid? gradeID, Guid? productID, Guid? productWidthID, Guid? lengthUnitID, Guid? colorID, Guid? vendorID, bool hasNewOrderQtyOnly)
        {
            //Tools.startProgressDisplay("Donwloading data...");

            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("inventorystocklevel_get_byFilter", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = (object)gradeID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier).Value = (object)productID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = (object)productWidthID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = (object)lengthUnitID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = (object)colorID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                cmd.Parameters.Add("@status_completed", SqlDbType.TinyInt).Value = POItemStatus.Completed;
                cmd.Parameters.Add("@status_cancelled", SqlDbType.TinyInt).Value = POItemStatus.Cancelled;
                cmd.Parameters.Add("@has_neworderqty_only", SqlDbType.Bit).Value = hasNewOrderQtyOnly;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            //Tools.stopProgressDisplay();

            return dataTable;
        }
    }
}
