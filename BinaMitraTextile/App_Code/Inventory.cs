using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile
{
    public class Inventory
    {
        public static string connectionString = DBUtil.connectionString;

        public const string COL_DB_ID = "id";
        public const string COL_DB_CODE = "code";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_BUYPRICE = "buy_price";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_PRODUCTWIDTHID = "product_width_id";
        public const string COL_DB_LENGTHUNITID = "length_unit_id";
        public const string COL_DB_COLORID = "color_id";
        public const string COL_DB_PRODUCTID = "product_id";
        public const string COL_DB_GRADEID = "grade_id";
        public const string COL_DB_RECEIVEDATE = "receive_date";
        public const string COL_DB_POITEMID = "po_item_id";
        public const string COL_DB_INVOICEID = "invoice_id";
        public const string COL_DB_PACKINGLISTNO = "packinglist_no";
        public const string COL_DB_VENDORINVOICEID = "vendorinvoice_id";
        public const string COL_DB_IsConsignment = "isConsignment";
        public const string COL_DB_OpnameMarker = "OpnameMarker";

        public const string COL_GRADE_NAME = "grade_name";
        public const string COL_PRODUCTSTORENAMEID = "product_store_name_id";
        public const string COL_PRODUCTSTORENAME = "product_store_name";
        public const string COL_PRODUCTNAMEVENDOR = "product_name_vendor";
        public const string COL_LENGTH_UNIT_NAME = "length_unit_name";
        public const string COL_PRODUCT_WIDTH_NAME = "product_width_name";
        public const string COL_COLOR_NAME = "color_name";
        public const string COL_VENDORID = "vendor_id";
        public const string COL_QTY = "qty";
        public const string COL_ITEMLENGTH = "item_length";
        public const string COL_SUBTOTAL = "subtotal";
        public const string COL_SELLPRICE = "sell_price";
        public const string COL_AVAILABLEITEMLENGTH = "available_item_length";
        public const string COL_AVAILABLEQTY = "available_qty";
        public const string COL_POITEMDESCRIPTION = "po_item_description";
        public const string COL_PONo = "po_no";
        public const string COL_VENDORINVOICENO = "vendorinvoice_no";
        public const string COL_PRODUCTID = "vendor_id";

        public const string FILTER_SaleOrderItems_Id = "FILTER_SaleOrderItems_Id";

        public Guid id;
        public int code = 0;
        public int qty = 0;
        public decimal item_length = 0;
        public decimal buy_price = 0;
        public decimal sell_price = 0;
        public string grade_name = "";
        public string length_unit_name = "";
        public string color_name = "";
        public string product_store_name = "";
        public string product_name_vendor = "";
        public string product_width_name = "";
        public Guid product_store_name_id;
        public Guid grade_id;
        public Guid product_id;
        public Guid product_width_id;
        public Guid length_unit_id;
        public Guid color_id;
        public string notes = "";
        public bool active = true;
        public DateTime receive_date;
        public Guid? POItemID = null;
        public string POItemDescription = "";
        public string PONo = "";
        public string PackingListNo = "";
        public Guid? VendorInvoiceID = null;
        public string VendorInvoiceNo = "";
        public Guid VendorID;
        public bool isConsignment = false;
        public bool OpnameMarker = false;

        public Inventory() { }

        public Inventory(Guid ID)
        {
            id = ID;
            DataTable dt = getRow(ID);
            code = Convert.ToInt16(dt.Rows[0][COL_DB_CODE]);
            qty = Convert.ToInt16(dt.Rows[0][COL_QTY]);
            item_length = Convert.ToDecimal(dt.Rows[0][COL_ITEMLENGTH]);
            buy_price = Convert.ToDecimal(dt.Rows[0][COL_DB_BUYPRICE]);
            product_id = (Guid)dt.Rows[0][COL_DB_PRODUCTID];
            product_width_id = (Guid)dt.Rows[0][COL_DB_PRODUCTWIDTHID];
            grade_name = dt.Rows[0][COL_GRADE_NAME].ToString();
            length_unit_name = dt.Rows[0][COL_LENGTH_UNIT_NAME].ToString();
            product_width_name = dt.Rows[0][COL_PRODUCT_WIDTH_NAME].ToString();
            color_name = dt.Rows[0][COL_COLOR_NAME].ToString();
            product_store_name_id = (Guid)dt.Rows[0][COL_PRODUCTSTORENAMEID];
            product_store_name = dt.Rows[0][COL_PRODUCTSTORENAME].ToString();
            product_name_vendor = DBUtil.parseData<string>(dt.Rows[0], COL_PRODUCTNAMEVENDOR);
            grade_id = (Guid)dt.Rows[0][COL_DB_GRADEID];
            length_unit_id = (Guid)dt.Rows[0][COL_DB_LENGTHUNITID];
            color_id = (Guid)dt.Rows[0][COL_DB_COLORID];
            active = Convert.ToBoolean(dt.Rows[0][COL_DB_ACTIVE]);
            isConsignment = Convert.ToBoolean(dt.Rows[0][COL_DB_IsConsignment]);
            OpnameMarker = Convert.ToBoolean(dt.Rows[0][COL_DB_OpnameMarker]);
            notes = dt.Rows[0][COL_DB_NOTES].ToString();
            if (dt.Rows[0][COL_DB_RECEIVEDATE] != DBNull.Value) receive_date = Convert.ToDateTime(dt.Rows[0][COL_DB_RECEIVEDATE]);
            if (dt.Rows[0][COL_DB_POITEMID] != DBNull.Value) POItemID = (Guid)dt.Rows[0][COL_DB_POITEMID];
            POItemDescription = dt.Rows[0][COL_POITEMDESCRIPTION].ToString();
            PONo = dt.Rows[0][COL_PONo].ToString();
            PackingListNo = dt.Rows[0][COL_DB_PACKINGLISTNO].ToString();
            if (dt.Rows[0][COL_DB_VENDORINVOICEID] != DBNull.Value) VendorInvoiceID = (Guid)dt.Rows[0][COL_DB_VENDORINVOICEID];
            VendorInvoiceNo = dt.Rows[0][COL_VENDORINVOICENO].ToString();
            VendorID = DBUtil.parseData<Guid>(dt.Rows[0], COL_VENDORID);
        }

        public Inventory(decimal BuyPrice, Guid GradeID, Guid ProductID, Guid ProductWidthID, Guid LengthUnitID, Guid ColorID, string Notes, Guid? poItemID, string packingListNo, Guid? vendorInvoiceID, int Code)
        {
            id = Guid.NewGuid();
            qty = 0;
            item_length = 0;
            buy_price = BuyPrice;
            product_id = ProductID;
            product_width_id = ProductWidthID;
            grade_id = GradeID;
            length_unit_id = LengthUnitID;
            color_id = ColorID;
            active = true;
            notes = Notes;
            POItemID = poItemID;
            PackingListNo = packingListNo;
            VendorInvoiceID = vendorInvoiceID;
            code = Code;

            DataTable dt = getInfo();
            grade_name = dt.Rows[0][COL_GRADE_NAME].ToString();
            length_unit_name = dt.Rows[0][COL_LENGTH_UNIT_NAME].ToString();
            product_width_name = dt.Rows[0][COL_PRODUCT_WIDTH_NAME].ToString();
            color_name = dt.Rows[0][COL_COLOR_NAME].ToString();
            product_store_name = dt.Rows[0][COL_PRODUCTSTORENAME].ToString();
            product_store_name_id = (Guid)dt.Rows[0][COL_PRODUCTSTORENAMEID];
            VendorInvoiceNo = DBUtil.parseData<string>(dt.Rows[0], COL_VENDORINVOICENO);
        }

        public string submitNew()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("inventory_new", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@buy_price", SqlDbType.Decimal).Value = buy_price;
                    cmd.Parameters.Add("@grade_id", SqlDbType.UniqueIdentifier).Value = grade_id;
                    cmd.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = product_id;
                    cmd.Parameters.Add("@product_width_id", SqlDbType.UniqueIdentifier).Value = product_width_id;
                    cmd.Parameters.Add("@length_unit_id", SqlDbType.UniqueIdentifier).Value = length_unit_id;
                    cmd.Parameters.Add("@color_id", SqlDbType.UniqueIdentifier).Value = color_id;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes;
                    cmd.Parameters.Add("@" + COL_DB_POITEMID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(POItemID);
                    cmd.Parameters.Add("@" + COL_DB_PACKINGLISTNO, SqlDbType.VarChar).Value = PackingListNo;
                    cmd.Parameters.Add("@" + COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(VendorInvoiceID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "New Inventory added");
                }
            } catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static bool isCodeExist(string Code, Guid? id)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventory_isCodeExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@code", SqlDbType.SmallInt).Value = Code;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("inventory_get", ID);
        }

        public DataTable getInfo()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventory_get_info", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@grade_id", SqlDbType.UniqueIdentifier).Value = grade_id;
                cmd.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = product_id;
                cmd.Parameters.Add("@product_width_id", SqlDbType.UniqueIdentifier).Value = product_width_id;
                cmd.Parameters.Add("@length_unit_id", SqlDbType.UniqueIdentifier).Value = length_unit_id;
                cmd.Parameters.Add("@color_id", SqlDbType.UniqueIdentifier).Value = color_id; ;
                cmd.Parameters.Add("@" + COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier).Value = VendorInvoiceID;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getAll(bool includeInactive)
        {
            return getAll(includeInactive, false, null, null, null, null, null, null, null, null);
        }

        public static DataTable getAll(bool includeInactive, Guid? vendorID)
        {
            return getAll(includeInactive, false, null, null, null, null, null, null, vendorID, null);
        }

        public static DataTable getAll(bool includeInactive, bool last3Months, int? code, Guid? productID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? colorID, 
            Guid? vendorID, Guid? vendorInvoiceID)
        {
            return get(includeInactive, last3Months, code, Tools.copyValuesToArrayTable(productID), Tools.copyValuesToArrayTable(gradeID), Tools.copyValuesToArrayTable(productWidthID), 
                Tools.copyValuesToArrayTable(lengthUnitID), Tools.copyValuesToArrayTable(colorID), vendorID, vendorInvoiceID);
        }

        public static DataTable get(bool includeInactive, bool last3Months, int? code, DataTable dtProductStoreNameID, DataTable dtGradeID, DataTable dtProductWidthID, DataTable dtLengthUnitID, 
            DataTable dtColorID, Guid? vendorID, Guid? vendorInvoiceID)
        {
            //Tools.startProgressDisplay("Donwloading data...");

            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("inventory_getall", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@last3Months", SqlDbType.Bit).Value = last3Months;
                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;

                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@productstorename_id_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@productwidth_id_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@lengthunit_id_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@color_id_list", dtColorID);

                //cmd.Parameters.Add("@grade_id", SqlDbType.UniqueIdentifier).Value = (object)gradeID ?? DBNull.Value;
                //cmd.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = (object)productID ?? DBNull.Value;
                //cmd.Parameters.Add("@product_width_id", SqlDbType.UniqueIdentifier).Value = (object)productWidthID ?? DBNull.Value;
                //cmd.Parameters.Add("@length_unit_id", SqlDbType.UniqueIdentifier).Value = (object)lengthUnitID ?? DBNull.Value;
                //cmd.Parameters.Add("@color_id", SqlDbType.UniqueIdentifier).Value = (object)colorID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                cmd.Parameters.Add("@" + COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorInvoiceID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            //Tools.stopProgressDisplay();

            return dataTable;
        }

        public static DataTable get_by_SaleOrderItems_Id(Guid? saleOrderItems_Id)
        {
            SqlQueryResult result = new SqlQueryResult();
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.FillByAdapter,
                    "Inventory_get_by_SaleOrderItems_Id",
                        new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Tools.wrapNullable(saleOrderItems_Id))
                    );
            }
            return result.Datatable;
        }

        public static string updateActiveStatus(Guid id, Boolean activeStatus)
        {
            return DBUtil.updateActiveStatus("inventory_update_active", id, activeStatus);
        }
        
        public static void updateIsConsignment(Guid id, bool value)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                SqlQueryResult result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Inventory_update_isConsignment",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_IsConsignment, SqlDbType.Bit, value)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(sqlConnection, id, "Consignment Status to " + value);
            }
        }

        public static void updateOpnameMarker(Guid id, bool value)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                SqlQueryResult result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Inventory_update_OpnameMarker",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_OpnameMarker, SqlDbType.Bit, value)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(sqlConnection, id, "Opname Marker Status to " + value);
            }
        }

        public static void updateBuyPrice(Guid id, decimal value)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                SqlQueryResult result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Inventory_update_BuyPrice",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_BUYPRICE, SqlDbType.Decimal, value)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(sqlConnection, id, "Buy Price updated to: " + value);
            }
        }

        public static void deactivateQtyZeroes()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DBUtil.connectionString))
            {
                SqlQueryResult result = DBConnection.query(
                    sqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Inventory_update_DeactivateQtyZeroes",
                    new SqlQueryParameter(ActivityLog.COL_DB_UserId, SqlDbType.UniqueIdentifier, GlobalData.UserAccount.id)
                );
            }
        }

        public string update()
        {
            try
            {
                Inventory objOld = new Inventory(id);

                //generate log description
                string logDescription = "";
                logDescription = ActivityLog.appendChange(logDescription, objOld.code, code, "Code: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.buy_price, buy_price, "Buy Price: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.sell_price, sell_price, "Tag Price: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.grade_name, grade_name, "Grade: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.product_store_name, product_store_name, "Product Store Name: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.product_name_vendor, product_name_vendor, "Product Vendor Name: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.product_width_name, product_width_name, "Width: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.length_unit_name, length_unit_name, "Length Unit: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.color_name, color_name, "Color: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.notes, notes, "Notes: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.POItemID, POItemID, "PO Item: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.PackingListNo, PackingListNo, "Packing List No: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.VendorInvoiceNo, VendorInvoiceNo, "Vendor Invoice No: '{0}' to '{1}'");

                if (string.IsNullOrEmpty(logDescription))
                {
                    return "No information has been changed";
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                    using (SqlCommand cmd = new SqlCommand("inventory_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                        cmd.Parameters.Add("@buy_price", SqlDbType.Decimal).Value = buy_price;
                        cmd.Parameters.Add("@grade_id", SqlDbType.UniqueIdentifier).Value = grade_id;
                        cmd.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = product_id;
                        cmd.Parameters.Add("@product_width_id", SqlDbType.UniqueIdentifier).Value = product_width_id;
                        cmd.Parameters.Add("@length_unit_id", SqlDbType.UniqueIdentifier).Value = length_unit_id;
                        cmd.Parameters.Add("@color_id", SqlDbType.UniqueIdentifier).Value = color_id;
                        cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes;
                        cmd.Parameters.Add("@" + COL_DB_POITEMID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(POItemID);
                        cmd.Parameters.Add("@" + COL_DB_PACKINGLISTNO, SqlDbType.VarChar).Value = PackingListNo;
                        cmd.Parameters.Add("@" + COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(VendorInvoiceID);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        //submit log
                        logDescription = "Inventory update: " + logDescription;
                        ActivityLog.submit(conn, id, logDescription);
                    }
                }
            } catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static void setAmount(Label lbl, string total)
        {
            lbl.Text = String.Format("Rp. {0:N2}", Tools.zeroNonNumericString(total));
        }
        
        public static void setCount(Label lbl, string qty, string length)
        {
            lbl.Text = String.Format("{0:N0} pcs / {1:N2}", qty, Tools.zeroNonNumericString(length));
        }

        public static void setCountAndAmount(Label lbl, string qty, string length, string total)
        {
            lbl.Text = String.Format("{0} pcs / {1:N2} ({2:N2})", qty, Tools.zeroNonNumericString(length), Tools.zeroNonNumericString(total));
        }
    }
}
