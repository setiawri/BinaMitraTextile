using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class InventoryItem
    {
        public static string connectionString = DBUtil.connectionString;

        public const string COL_ID = "id";
        public const string COL_INVENTORY_ID = "inventory_id";
        public const string COL_LENGTH = "item_length";
        public const string COL_BARCODE = "barcode";
        public const string COL_INVENTORY_CODE = "inventory_code";
        public const string COL_IS_SOLD = "isSold";
        public const string COL_DB_COLORID = "color_id";
        public const string COL_DB_Grades_Id = "Grades_Id";
        public const string COL_DB_SaleOrderItems_Id = "SaleOrderItems_Id";
        public const string COL_NOTES = "notes";

        public const string COL_INVENTORYCOLORNAME = "inventory_color_name";
        public const string COL_INVENTORYITEMCOLORNAME = "inventoryitem_color_name";
        public const string COL_Grades_Name = "grade_name";
        public const string COL_ProductWidths_Name = "product_width_name";
        public const string COL_ProductStoreName = "product_store_name";
        public const string COL_SaleOrderItemDescription = "SaleOrderItemDescription";
        public const string COL_SaleOrderItemCustomerName = "SaleOrderItemCustomerName";
        public const string COL_SaleOrders_Customers_Id = "SaleOrders_Customers_Id";

        public const string COL_SALE_SELLPRICE = "sell_price";
        public const string COL_SALE_SELECTED = "selected";
        public const string COL_SALE_ADJUSTMENT = "adjustment";
        public const string COL_SALE_ADJUSTEDPRICE = "adjusted_price";
        public const string COL_SALE_SUBTOTAL = "subtotal";
        public const string COL_SALE_QTY = "qty";
        public const string COL_LENGTHUNITNAME = "length_unit_name";
        public const string COL_SALE_isManualAdjustment = "isManualAdjustment";

        public const string COL_LASTOPNAME = "last_opname";
        public const string COL_OpnameMarker = Inventory.COL_DB_OpnameMarker;

        public const string FILTER_Sales_Id = "FILTER_Sales_Id";
        public const string FILTER_SaleOrderItems_Id = "FILTER_SaleOrderItems_Id";
        public const string FILTER_Customers_Id = "customer_id";
        public const string FILTER_Inventory_Id = "FILTER_Inventory_Id";

        public Guid id;
        public Guid inventory_id;
        public decimal item_length = 0;
        public string code = "";
        public string barcode;
        public Guid? ColorID;
        public Guid Grades_Id;
        public Guid? SaleOrderItems_Id;
        public string notes;

        public string ColorName = "";
        public string InventoryColorName = "";
        public string LengthUnitName = "";
        public string Grades_Name = "";
        public string ProductWidths_Name = "";
        public string ProductStoreName = "";
        public bool OpnameMarker;
        public string SaleOrderItemDescription;
        public string SaleOrderItemCustomerName;
        public Guid? SaleOrders_Customers_Id;
        public bool isSold;

        public InventoryItem(Guid ID)
        {
            DataTable data = getRow(ID);
            if(data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                id = (Guid)row[COL_ID];
                code = row[COL_INVENTORY_CODE].ToString();
                inventory_id = (Guid)row[COL_INVENTORY_ID];
                item_length = Convert.ToDecimal(row[COL_LENGTH]);
                barcode = row[COL_BARCODE].ToString();
                ColorID = DBUtil.parseData<Guid?>(row, COL_DB_COLORID);
                SaleOrderItems_Id = DBUtil.parseData<Guid?>(row, COL_DB_SaleOrderItems_Id);
                notes = row[COL_NOTES].ToString();

                ColorName = DBUtil.parseData<string>(row, COL_INVENTORYITEMCOLORNAME);
                InventoryColorName = DBUtil.parseData<string>(row, COL_INVENTORYCOLORNAME);
                LengthUnitName = DBUtil.parseData<string>(row, COL_LENGTHUNITNAME);
                ProductStoreName = DBUtil.parseData<string>(row, COL_ProductStoreName);
                SaleOrderItemDescription = DBUtil.parseData<string>(row, COL_SaleOrderItemDescription);
                SaleOrderItemCustomerName = DBUtil.parseData<string>(row, COL_SaleOrderItemCustomerName);
                isSold = Util.wrapNullable<bool>(row, COL_IS_SOLD);
                SaleOrders_Customers_Id = Util.wrapNullable<Guid?>(row, COL_SaleOrders_Customers_Id);

                Grades_Id = Util.wrapNullable<Guid>(row, COL_DB_Grades_Id);
                Grades_Name = Util.wrapNullable<string>(row, COL_Grades_Name);
                ProductWidths_Name = Util.wrapNullable<string>(row, COL_ProductWidths_Name);
                OpnameMarker = Util.wrapNullable<bool>(row, COL_OpnameMarker);
            }
        }

        public InventoryItem(string barcodeWithoutPrefix) : this(getIDByBarcode(barcodeWithoutPrefix)) { }

        public InventoryItem(Guid ID, Guid InventoryID, decimal ItemLength, string BarcodeWithoutPrefix, Guid? colorID, string Notes)
        {
            id = ID;
            inventory_id = InventoryID;
            item_length = ItemLength;
            barcode = BarcodeWithoutPrefix;
            ColorID = colorID;
            notes = Notes;
        }

        public string submitNew()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("inventoryitem_new", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@inventory_id", SqlDbType.UniqueIdentifier).Value = inventory_id;
                    cmd.Parameters.Add("@item_length", SqlDbType.Decimal).Value = item_length;
                    cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcode.ToUpper();
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ColorID);
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "New Inventory Item added");
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }
        
        public static DataTable getRow(string barcodeWithoutPrefix)
        {
            return getRow(getIDByBarcode(barcodeWithoutPrefix));
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("inventoryitem_get", ID);
        }

        public static Guid getIDByBarcode(string barcodeWithoutPrefix)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventoryitem_get_id_by_barcode", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcodeWithoutPrefix;

                conn.Open();
                return DBUtil.parseData<Guid>(cmd.ExecuteScalar());
            }
        }

        public static DataTable getRowForSale(string barcode, Guid? customerID)
        {
            return getRowForSale(getIDByBarcode(barcode), customerID);
        }

        public static DataTable getRowForSale(Guid ID, Guid? customerID)
        {
            return getRowsForSale(new Guid[] { ID }, customerID);
        }

        public static DataTable getRowsForSale(Guid[] IDList, Guid? customerID)
        {
            DataTable dt = getRows("inventoryitem_get", IDList, customerID);

            Tools.addColumn<bool>(dt, COL_SALE_SELECTED, 0);
            return dt;
        }

        public static DataTable getRows(string storedProcedure, Guid[] IDArray, Guid? customerID)
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
                        cmd.Parameters.Add("@customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);

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

        public static DataTable getItems(Guid inventoryID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventoryitem_get_by_inventory_id", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@inventory_id", SqlDbType.UniqueIdentifier).Value = inventoryID;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable get(Guid? id, Guid? customers_Id, Guid? saleOrderItems_Id, Guid? sales_Id, Guid? inventory_Id)
        {
            SqlQueryResult result = new SqlQueryResult();
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.FillByAdapter,
                    "inventoryitem_get",
                        new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, LIBUtil.Util.wrapNullable(id)),
                        new SqlQueryParameter(FILTER_Customers_Id, SqlDbType.UniqueIdentifier, LIBUtil.Util.wrapNullable(customers_Id)),
                        new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, LIBUtil.Util.wrapNullable(saleOrderItems_Id)),
                        new SqlQueryParameter(FILTER_Sales_Id, SqlDbType.UniqueIdentifier, LIBUtil.Util.wrapNullable(sales_Id)),
                        new SqlQueryParameter(FILTER_Inventory_Id, SqlDbType.UniqueIdentifier, LIBUtil.Util.wrapNullable(inventory_Id))
                    );
            }
            return result.Datatable;
        }

        public static DataTable get_Booked(Guid saleOrders_Id)
        {
            SqlQueryResult result = new SqlQueryResult();
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.FillByAdapter,
                    "InventoryItems_get_Booked",
                        new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, saleOrders_Id)
                    );
            }
            return result.Datatable;
        }
        
        public string update()
        {
            try
            {
                InventoryItem objOld = new InventoryItem(id);

                //generate log description
                string logDescription = "";
                if (objOld.inventory_id != inventory_id) logDescription = Tools.append(logDescription, String.Format("Inventory ID: '{0}' to '{1}'", objOld.inventory_id, inventory_id), ",");
                if (objOld.item_length != item_length) logDescription = Tools.append(logDescription, String.Format("Length: '{0}' to '{1}'", objOld.item_length, item_length), ",");
                logDescription = Util.appendChange(logDescription, objOld.ColorName, new FabricColor(ColorID).Name, "Color: '{0}' to '{1}'");
                if (objOld.notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.notes, notes), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    return "No information has been changed";
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                    using (SqlCommand cmd = new SqlCommand("inventoryitem_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@inventory_id", SqlDbType.UniqueIdentifier).Value = inventory_id;
                        cmd.Parameters.Add("@item_length", SqlDbType.Decimal).Value = item_length;
                        cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcode;
                        cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ColorID);
                        cmd.Parameters.Add("@notes", SqlDbType.VarChar, -1).Value = notes;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        //submit log
                        logDescription = "Inventory Item update: " + logDescription;
                        ActivityLog.submit(conn, id, logDescription);
                    }
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public InventoryItem split(decimal splitQty)
        {
            decimal originalItemQty = item_length;
            decimal originalItemNewQty = item_length - splitQty;

            InventoryItem newInventoryItem = new InventoryItem(id);

            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("inventoryitem_get_nextsplitbarcode", conn))
                {
                    //get generated split item count
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_BARCODE, SqlDbType.VarChar).Value = barcode;
                    SqlParameter return_value = cmd.Parameters.Add("@nextsplitbarcode", SqlDbType.Int);
                    return_value.Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    //update current item
                    item_length = originalItemNewQty;
                    update();

                    //update data in new item
                    newInventoryItem.id = Guid.NewGuid();
                    newInventoryItem.item_length = splitQty;
                    newInventoryItem.barcode = string.Format("{0}.{1:##00}", barcode, Convert.ToInt32(return_value.Value));
                    newInventoryItem.submitNew();

                    ActivityLog.submit(conn, id, string.Format("Item is split to a new item with barcode: {0} with qty: {1}. Original item qty is split from {2} to {3}",
                        newInventoryItem.barcode,
                        splitQty,
                        originalItemQty,
                        originalItemNewQty));
                    ActivityLog.submit(conn, newInventoryItem.id, string.Format("Item created. This is a split from {0}. Original item qty is split from {1} to {2}", barcode, originalItemQty, originalItemNewQty));
                }
            }
            catch (Exception ex) { throw ex; }

            return newInventoryItem;
        }

        /* STATIC METHODS **************************************************************************************/

        public static bool isValidNewBarcode(string barcodeWithPrefix)
        {
            string hex = barcodeWithPrefix.Substring(Settings.itemBarcodeMandatoryPrefix.Length);

            if (!isValidBarcode(barcodeWithPrefix))
                return false;

            if (isBarcodeExist(hex))
            {
                Tools.hasMessage(String.Format("{0} already exists in database", barcodeWithPrefix));
                return false;
            }

            return true;
        }

        public static bool isValidBarcode(string barcodeWithPrefix)
        {
            string prefix = barcodeWithPrefix.Substring(0, Settings.itemBarcodeMandatoryPrefix.Length);
            string hex = barcodeWithPrefix.Substring(Settings.itemBarcodeMandatoryPrefix.Length);

            if (prefix.ToUpper() != Settings.itemBarcodeMandatoryPrefix.ToUpper())
            {
                Tools.hasMessage(String.Format("{0} is not a valid prefix", barcodeWithPrefix.Substring(0, Settings.itemBarcodeMandatoryPrefix.Length)));
                return false;
            }
            if (hex.Length != Settings.itemBarcodeLength)
            {
                Tools.hasMessage(String.Format("{0} is not a valid barcode: must be {1} digits", barcodeWithPrefix, Settings.itemBarcodeLength));
                return false;
            }
            if (!Tools.isHexNumber(hex))
            {
                Tools.hasMessage(String.Format("{0} is not a valid barcode", barcodeWithPrefix));
                return false;
            }

            return true;
        }

        public static bool isBarcodeValidForSale(string barcode)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventoryitem_isBarcodeValidForSale", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcode;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static bool isBarcodeExist(string Barcode)
        {
            if (string.IsNullOrEmpty(Barcode))
                return false;

            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventoryitem_isBarcodeExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = Barcode;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static string getBarcodeWithoutPrefix(string Barcode)
        {
            if (Barcode.Length == 0)
                return null;
            else
                return Barcode.Substring(Settings.itemBarcodeMandatoryPrefix.Length);
        }

        public static string getBarcodePrefix(string Barcode)
        {
            return Barcode.Substring(0, Settings.itemBarcodeMandatoryPrefix.Length);
        }

        public static DataTable getExistingBarcodesForReprinting(DateTime? dtStartReceive, DateTime? dtEndReceive)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventoryitem_get_forBarcodeReprint", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@receive_start_date", SqlDbType.DateTime).Value = Tools.wrapNullable(dtStartReceive);
                if(dtEndReceive != null) cmd.Parameters.Add("@receive_end_date", SqlDbType.DateTime).Value = Tools.wrapNullable(dtEndReceive.Value.Date.AddDays(1));

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static bool updateSaleOrderItem(List<Guid> IdList, Guid? SaleOrderItems_Id, string description)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                foreach (Guid id in IdList)
                {
                    SqlQueryResult result = DBConnection.query(
                       sqlConnection,
                       QueryTypes.ExecuteNonQuery,
                       "InventoryItems_update_SaleOrderItems_Id",
                       new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                       new SqlQueryParameter(COL_DB_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(SaleOrderItems_Id))
                    );

                    if (!result.IsSuccessful)
                        return false;
                    else if(SaleOrderItems_Id == null)
                        ActivityLog.submit(sqlConnection, id, "Sale Order Item removed");
                    else
                        ActivityLog.submit(sqlConnection, id, "Sale Order Item Updated to: " + description);
                }
            }
            return true;
        }
    }
}
