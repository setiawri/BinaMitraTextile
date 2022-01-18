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
        public const string COL_BUYVALUE = "buy_value";
        public const string COL_SELLVALUE = "sell_value";
        public const string COL_AVAILABLEQTY = "available_qty";
        public const string COL_POITEMDESCRIPTION = "po_item_description";
        public const string COL_PONo = "po_no";
        public const string COL_VENDORINVOICENO = "vendorinvoice_no";
        public const string COL_FakturPajaks_No = "FakturPajaks_No";

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
        public string FakturPajaks_No = "";

        public Inventory() { }

        public Inventory(Guid ID)
        {
            id = ID;
            DataRow row = getRow(ID).Rows[0];
            code = Util.wrapNullable<int>(row, COL_DB_CODE);
            qty = Util.wrapNullable<int>(row, COL_QTY);
            item_length = Util.wrapNullable<decimal>(row, COL_QTY);
            buy_price = Util.wrapNullable<decimal>(row, COL_DB_BUYPRICE);
            product_id = Util.wrapNullable<Guid>(row, COL_DB_PRODUCTID);
            product_width_id = Util.wrapNullable<Guid>(row, COL_DB_PRODUCTWIDTHID);
            grade_name = Util.wrapNullable<string>(row, COL_GRADE_NAME);
            length_unit_name = Util.wrapNullable<string>(row, COL_LENGTH_UNIT_NAME);
            product_width_name = Util.wrapNullable<string>(row, COL_PRODUCT_WIDTH_NAME);
            color_name = Util.wrapNullable<string>(row, COL_COLOR_NAME);
            product_store_name_id = Util.wrapNullable<Guid>(row, COL_PRODUCTSTORENAMEID);
            product_store_name = Util.wrapNullable<string>(row, COL_PRODUCTSTORENAME);
            product_name_vendor = Util.wrapNullable<string>(row, COL_PRODUCTNAMEVENDOR);
            grade_id = Util.wrapNullable<Guid>(row, COL_DB_GRADEID);
            length_unit_id = Util.wrapNullable<Guid>(row, COL_DB_LENGTHUNITID);
            color_id = Util.wrapNullable<Guid>(row, COL_DB_COLORID);
            active = Util.wrapNullable<bool>(row, COL_DB_ACTIVE);
            isConsignment = Util.wrapNullable<bool>(row, COL_DB_IsConsignment);
            OpnameMarker = Util.wrapNullable<bool>(row, COL_DB_OpnameMarker);
            notes = Util.wrapNullable<string>(row, COL_DB_NOTES);
            receive_date = Util.wrapNullable<DateTime>(row, COL_DB_RECEIVEDATE);
            POItemID = Util.wrapNullable<Guid>(row, COL_DB_POITEMID);
            POItemDescription = Util.wrapNullable<string>(row, COL_POITEMDESCRIPTION);
            PONo = Util.wrapNullable<string>(row, COL_PONo);
            PackingListNo = Util.wrapNullable<string>(row, COL_DB_PACKINGLISTNO);
            VendorInvoiceID = Util.wrapNullable<Guid>(row, COL_DB_VENDORINVOICEID);
            VendorInvoiceNo = Util.wrapNullable<string>(row, COL_VENDORINVOICENO);
            VendorID = Util.wrapNullable<Guid>(row, COL_VENDORID);

            FakturPajaks_No = Util.wrapNullable<string>(row, COL_FakturPajaks_No);
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

            DataRow row = getInfo().Rows[0];
            grade_name = Util.wrapNullable<string>(row, COL_GRADE_NAME);
            length_unit_name = Util.wrapNullable<string>(row, COL_LENGTH_UNIT_NAME);
            product_width_name = Util.wrapNullable<string>(row, COL_PRODUCT_WIDTH_NAME);
            color_name = Util.wrapNullable<string>(row, COL_COLOR_NAME);
            product_store_name = Util.wrapNullable<string>(row, COL_PRODUCTSTORENAME);
            product_store_name_id = Util.wrapNullable<Guid>(row, COL_PRODUCTSTORENAMEID);
            product_name_vendor = Util.wrapNullable<string>(row, COL_PRODUCTNAMEVENDOR);
            VendorInvoiceNo = Util.wrapNullable<string>(row, COL_VENDORINVOICENO);
            PONo = Util.wrapNullable<string>(row, COL_PONo);
        }

        public Guid? submitNew()
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "inventory_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_BUYPRICE, SqlDbType.Decimal, buy_price),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, grade_id),
                new SqlQueryParameter(COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier, product_id),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, product_width_id),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, length_unit_id),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, color_id),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes)),
                new SqlQueryParameter(COL_DB_POITEMID, SqlDbType.UniqueIdentifier, Util.wrapNullable(POItemID)),
                new SqlQueryParameter(COL_DB_PACKINGLISTNO, SqlDbType.VarChar, PackingListNo),
                new SqlQueryParameter(COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(VendorInvoiceID))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static bool isCodeExist(string Code, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "inventory_isCodeExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_CODE, SqlDbType.SmallInt, Code)
                );
            return result.ValueBoolean;
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("inventory_get", ID);
        }

        public DataTable getInfo()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "inventory_get_info",
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, grade_id),
                new SqlQueryParameter(COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier, product_id),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, product_width_id),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, length_unit_id),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, color_id),
                new SqlQueryParameter(COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier, VendorInvoiceID),
                new SqlQueryParameter(COL_DB_POITEMID, SqlDbType.UniqueIdentifier, POItemID)
            );
            return result.Datatable;
        }

        public static DataTable getAll(bool includeInactive)
        {
            return getAll(includeInactive, false, null, null, null, null, null, null, null, null, false, null);
        }

        public static DataTable getAll(bool includeInactive, Guid? vendorID)
        {
            return getAll(includeInactive, false, null, null, null, null, null, null, vendorID, null, false, null);
        }

        public static DataTable getAll(bool includeInactive, bool last3Months, int? code, Guid? productID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? colorID, 
            Guid? vendorID, Guid? vendorInvoiceID, bool showNotBookedOnly, string keyword)
        {
            return get(includeInactive, last3Months, code, Tools.copyValuesToArrayTable(productID), Tools.copyValuesToArrayTable(gradeID), Tools.copyValuesToArrayTable(productWidthID), 
                Tools.copyValuesToArrayTable(lengthUnitID), Tools.copyValuesToArrayTable(colorID), vendorID, vendorInvoiceID, showNotBookedOnly, keyword);
        }

        public static DataTable get(bool includeInactive, bool last3Months, int? code, DataTable dtProductStoreNameID, DataTable dtGradeID, DataTable dtProductWidthID, DataTable dtLengthUnitID, 
            DataTable dtColorID, Guid? vendorID, Guid? vendorInvoiceID, bool showNotBookedOnly, string keyword)
        {

            //ERROR INVALID ARRAY SIZE
            //SqlQueryResult result = DBConnection.query(
            //    true,
            //    DBConnection.ActiveSqlConnection,
            //    QueryTypes.FillByAdapter,
            //    "inventory_getall",
            //        DBConnection.createTableParameters(
            //            new SqlQueryTableParameterGuid("grade_id_list", dtGradeID),
            //            new SqlQueryTableParameterGuid("productstorename_id_list", dtProductStoreNameID),
            //            new SqlQueryTableParameterGuid("productwidth_id_list", dtProductWidthID),
            //            new SqlQueryTableParameterGuid("lengthunit_id_list", dtLengthUnitID),
            //            new SqlQueryTableParameterGuid("color_id_list", dtColorID)
            //        ),
            //    new SqlQueryParameter("include_inactive", SqlDbType.Bit, includeInactive),
            //    new SqlQueryParameter("last3Months", SqlDbType.Bit, last3Months),
            //    new SqlQueryParameter("code", SqlDbType.VarChar, code),
            //    new SqlQueryParameter("FILTER_ShowNotBookedOnly", SqlDbType.Bit, showNotBookedOnly),
            //    new SqlQueryParameter(COL_VENDORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID)),
            //    new SqlQueryParameter(COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorInvoiceID))
            //    );
            //return result.Datatable;

            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("inventory_getall", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@last3Months", SqlDbType.Bit).Value = last3Months;
                cmd.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                cmd.Parameters.Add("@FILTER_ShowNotBookedOnly", SqlDbType.Bit).Value = showNotBookedOnly;
                cmd.Parameters.Add("@FILTER_Keyword", SqlDbType.VarChar).Value = keyword;
                cmd.Parameters.Add("@" + COL_VENDORID, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(vendorID);
                cmd.Parameters.Add("@" + COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(vendorInvoiceID);

                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@productstorename_id_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@productwidth_id_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@lengthunit_id_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@color_id_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable get_by_SaleOrderItems_Id(Guid? saleOrderItems_Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Inventory_get_by_SaleOrderItems_Id",
                    new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(saleOrderItems_Id))
                );
            return result.Datatable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("inventory_update_active", id, activeStatus);
        }
        
        public static void updateIsConsignment(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Inventory_update_isConsignment",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_IsConsignment, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Consignment Status to " + value);
        }

        public static void updateOpnameMarker(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Inventory_update_OpnameMarker",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_OpnameMarker, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Opname Marker Status to " + value);
        }

        public static void updateBuyPrice(Guid id, decimal value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Inventory_update_BuyPrice",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_BUYPRICE, SqlDbType.Decimal, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Buy Price updated to: " + value);
        }

        public static void deactivateQtyZeroes()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Inventory_update_DeactivateQtyZeroes",
                new SqlQueryParameter(ActivityLog.COL_DB_UserId, SqlDbType.UniqueIdentifier, GlobalData.UserAccount.id)
            );
        }

        public bool update()
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
            logDescription = ActivityLog.appendChange(logDescription, objOld.PONo, PONo, "PO Item: '{0}' to '{1}'");
            logDescription = ActivityLog.appendChange(logDescription, objOld.PackingListNo, PackingListNo, "Packing List No: '{0}' to '{1}'");
            logDescription = ActivityLog.appendChange(logDescription, objOld.VendorInvoiceNo, VendorInvoiceNo, "Vendor Invoice No: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "inventory_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_CODE, SqlDbType.VarChar, code),
                    new SqlQueryParameter(COL_DB_BUYPRICE, SqlDbType.Decimal, buy_price),
                    new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, grade_id),
                    new SqlQueryParameter(COL_DB_PRODUCTID, SqlDbType.UniqueIdentifier, product_id),
                    new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, product_width_id),
                    new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, length_unit_id),
                    new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, color_id),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes)),
                    new SqlQueryParameter(COL_DB_POITEMID, SqlDbType.UniqueIdentifier, Util.wrapNullable(POItemID)),
                    new SqlQueryParameter(COL_DB_PACKINGLISTNO, SqlDbType.VarChar, PackingListNo),
                    new SqlQueryParameter(COL_DB_VENDORINVOICEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(VendorInvoiceID))
                );

                if (result.IsSuccessful)
                {
                    ActivityLog.submitUpdate(id, logDescription);
                    return true;
                }
            }

            return false;
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
        
        public static DataTable compileSummaryData(DataTable dt, bool showColor)
        {
            DataTable dtSummary = dt.Clone(); //copy table structure without rows of data
            Tools.setDataTablePrimaryKey(dtSummary, Inventory.COL_DB_ID);

            DataRow tempRow;
            decimal totalLength = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tempRow = findCombination(dtSummary, dr, showColor);
                if (tempRow != null)
                {
                    totalLength = Tools.zeroNonNumericString(tempRow[Inventory.COL_AVAILABLEITEMLENGTH]) + Tools.zeroNonNumericString(dr[Inventory.COL_AVAILABLEITEMLENGTH]);
                    if (totalLength > 0)
                    {
                        tempRow[Inventory.COL_DB_BUYPRICE] = 
                            ((Tools.zeroNonNumericString(tempRow[Inventory.COL_DB_BUYPRICE]) * Tools.zeroNonNumericString(tempRow[Inventory.COL_AVAILABLEITEMLENGTH]))
                            + (Tools.zeroNonNumericString(dr[Inventory.COL_DB_BUYPRICE]) * Tools.zeroNonNumericString(dr[Inventory.COL_AVAILABLEITEMLENGTH])))
                            / totalLength; //calculate average buy price
                        tempRow[Inventory.COL_BUYVALUE] = Tools.zeroNonNumericString(tempRow[Inventory.COL_DB_BUYPRICE]) * totalLength; //calculate buy value
                        tempRow[Inventory.COL_SELLVALUE] = Tools.zeroNonNumericString(tempRow[Inventory.COL_SELLVALUE]) + (Tools.zeroNonNumericString(dr[Inventory.COL_SELLPRICE]) * Tools.zeroNonNumericString(dr[Inventory.COL_AVAILABLEITEMLENGTH])); //calculate buy value
                        tempRow[Inventory.COL_AVAILABLEITEMLENGTH] = totalLength;
                        tempRow[Inventory.COL_AVAILABLEQTY] = Tools.zeroNonNumericString(tempRow[Inventory.COL_AVAILABLEQTY]) + Tools.zeroNonNumericString(dr[Inventory.COL_AVAILABLEQTY]);
                    }
                    dtSummary.AcceptChanges();
                }
                else
                {
                    tempRow = dtSummary.Rows.Add(dr.ItemArray);
                    tempRow[Inventory.COL_BUYVALUE] = Tools.zeroNonNumericString(tempRow[Inventory.COL_DB_BUYPRICE]) * Tools.zeroNonNumericString(tempRow[Inventory.COL_AVAILABLEITEMLENGTH]); //calculate buy value
                    tempRow[Inventory.COL_SELLVALUE] = Tools.zeroNonNumericString(tempRow[Inventory.COL_SELLPRICE]) * Tools.zeroNonNumericString(tempRow[Inventory.COL_AVAILABLEITEMLENGTH]); //calculate sell value
                    dtSummary.AcceptChanges();
                }
            }

            return dtSummary;
        }

        public static DataRow findCombination(DataTable datatable, DataRow datarow, bool showColor)
        {
            foreach(DataRow row in datatable.Rows)
            {
                if(showColor)
                {
                    if (row[Inventory.COL_PRODUCTSTORENAME].ToString() == datarow[Inventory.COL_PRODUCTSTORENAME].ToString()
                        && row[Inventory.COL_GRADE_NAME].ToString() == datarow[Inventory.COL_GRADE_NAME].ToString()
                        && row[Inventory.COL_PRODUCT_WIDTH_NAME].ToString() == datarow[Inventory.COL_PRODUCT_WIDTH_NAME].ToString()
                        && row[Inventory.COL_LENGTH_UNIT_NAME].ToString() == datarow[Inventory.COL_LENGTH_UNIT_NAME].ToString()
                        && row[Inventory.COL_DB_COLORID].ToString() == datarow[Inventory.COL_DB_COLORID].ToString())

                        return row;
                }
                else
                {
                    if (row[Inventory.COL_PRODUCTSTORENAME].ToString() == datarow[Inventory.COL_PRODUCTSTORENAME].ToString()
                        && row[Inventory.COL_GRADE_NAME].ToString() == datarow[Inventory.COL_GRADE_NAME].ToString()
                        && row[Inventory.COL_PRODUCT_WIDTH_NAME].ToString() == datarow[Inventory.COL_PRODUCT_WIDTH_NAME].ToString()
                        && row[Inventory.COL_LENGTH_UNIT_NAME].ToString() == datarow[Inventory.COL_LENGTH_UNIT_NAME].ToString())

                        return row;
                }
            }

            return null;
        }
    }
}
