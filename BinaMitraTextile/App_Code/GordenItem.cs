using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace BinaMitraTextile
{
    public enum GordenItemCategories
    {
        Gorden,
        Vitrage,
        Rel,
        Cup,
        Tasel,
        Hook,
        Ring,
        [Description("Smoke Ring")]
        SmokeRing,
        [Description("Stick Spiral")]
        StickSpiral,
        Bracket,
        [Description("Kawat & Roda")]
        KawatRoda,
        [Description("Kaki Rel")]
        KakiRel
    }

    public class GordenItem
    {
        public const string FILTER_INCLUDEINACTIVE = "include_inactive";
        public const string FILTER_CATEGORYENUMIDLIST = "category_enumid_list";

        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "name";
        public const string COL_DB_CATEGORYENUMID = "category_enumid";
        public const string COL_DB_VENDORID = "vendor_id";
        public const string COL_DB_PRODUCTWIDTHID = "productwidth_id";
        public const string COL_DB_RETAILLENGTHUNITID = "retail_lengthunit_id";
        public const string COL_DB_BULKLENGTHUNITID = "bulk_lengthunit_id";
        public const string COL_DB_BUYRETAILPRICEPERUNIT = "buy_retail_priceperunit";
        public const string COL_DB_BUYBULKPRICEPERUNIT = "buy_bulk_priceperunit";
        public const string COL_DB_SELLRETAILPRICEPERUNIT = "sell_retail_priceperunit";
        public const string COL_DB_SELLBULKPRICEPERUNIT = "sell_bulk_priceperunit";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";

        public const string COL_CATEGORYNAME = "category_name";
        public const string COL_VENDORNAME = "vendor_name";
        public const string COL_RETAILLENGTHUNITNAME = "retail_lengthunit_name";
        public const string COL_BULKLENGTHUNITNAME = "bulk_lengthunit_name";
        public const string COL_PRODUCTWIDTHNAME = "productwidth_name";
        public const string COL_PRODUCTWIDTHINMETER = "productwidth_inmeter";

        public Guid ID;
        public string Name = "";
        public GordenItemCategories CategoryEnumID;
        public Guid VendorID;
        public Guid? ProductWidthID;
        public Guid RetailLengthUnitID;
        public Guid BulkLengthUnitID;
        public decimal BuyRetailPricePerUnit;
        public decimal BuyBulkPricePerUnit;
        public decimal SellRetailPricePerUnit;
        public decimal SellBulkPricePerUnit;
        public bool Active = true;
        public string Notes = "";

        public string CategoryName;
        public string VendorName;
        public string RetailLengthUnitName;
        public string BulkLengthUnitName;
        public string ProductWidthName;
        public decimal ProductWidthInMeter;

        public GordenItem(Guid id)
        {
            ID = id;
            DataRow row = get(ID);
            Name = DBUtil.parseData<string>(row, COL_DB_NAME);
            CategoryEnumID = Tools.parseEnum<GordenItemCategories>(DBUtil.parseData<int>(row, COL_DB_CATEGORYENUMID));
            VendorID = DBUtil.parseData<Guid>(row, COL_DB_VENDORID);
            ProductWidthID = DBUtil.parseData<Guid?>(row, COL_DB_PRODUCTWIDTHID);
            RetailLengthUnitID = DBUtil.parseData<Guid>(row, COL_DB_RETAILLENGTHUNITID);
            BulkLengthUnitID = DBUtil.parseData<Guid>(row, COL_DB_BULKLENGTHUNITID);
            BuyRetailPricePerUnit = DBUtil.parseData<decimal>(row, COL_DB_BUYRETAILPRICEPERUNIT);
            BuyBulkPricePerUnit = DBUtil.parseData<decimal>(row, COL_DB_BUYBULKPRICEPERUNIT);
            SellRetailPricePerUnit = DBUtil.parseData<decimal>(row, COL_DB_SELLRETAILPRICEPERUNIT);
            SellBulkPricePerUnit = DBUtil.parseData<decimal>(row, COL_DB_SELLBULKPRICEPERUNIT);
            Active = DBUtil.parseData<bool>(row, COL_DB_ACTIVE);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);

            CategoryName = DBUtil.parseData<string>(row, COL_CATEGORYNAME);
            VendorName = DBUtil.parseData<string>(row, COL_VENDORNAME);
            RetailLengthUnitName = DBUtil.parseData<string>(row, COL_RETAILLENGTHUNITNAME);
            BulkLengthUnitName = DBUtil.parseData<string>(row, COL_BULKLENGTHUNITNAME);
            ProductWidthName = DBUtil.parseData<string>(row, COL_PRODUCTWIDTHNAME);
            ProductWidthInMeter = DBUtil.parseData<decimal>(row, COL_PRODUCTWIDTHINMETER);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
        }

        public static void add(string name, GordenItemCategories category, Guid vendorID, Guid retailLengthUnitID, Guid bulkLengthUnitID, Guid? productWidthID, decimal buyRetailPricePerUnit, decimal buyBulkPricePerUnit, 
            decimal sellRetailPricePerUnit, decimal sellBulkPricePerUnit, string notes)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("gordenitem_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@" + COL_DB_CATEGORYENUMID, SqlDbType.TinyInt).Value = category;
                    cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);
                    cmd.Parameters.Add("@" + COL_DB_RETAILLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = retailLengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_BULKLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = bulkLengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_BUYRETAILPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(buyRetailPricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_BUYBULKPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(buyBulkPricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_SELLRETAILPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellRetailPricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_SELLBULKPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellBulkPricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();


                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("gordenitem_isNameExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;
                
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataRow get(Guid ID)
        {
            return Tools.getFirstRow(get(true, ID, null, null, null, null, null, null));
        }
        
        public static DataTable get(bool includeInactive, Guid? ID, string nameFilter, Guid? vendorID, Guid? retailLengthUnitID, Guid? bulkLengthUnitID, Guid? productWidthID, GordenItemCategories? category)
        {
            if(category == null)
                return get(true, Tools.copyIntToArrayTable(null), ID, null, null, null, null, null);
            else
                return get(true, Tools.copyIntToArrayTable((int)category), ID, null, null, null, null, null);
        }

        public static DataTable get(bool includeInactive, DataTable categoryEnumIDList, Guid? ID, string nameFilter, Guid? vendorID, Guid? retailLengthUnitID, Guid? bulkLengthUnitID, Guid? productWidthID)
        {
            DataTable datatable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("gordenitem_get", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + FILTER_INCLUDEINACTIVE, SqlDbType.Bit).Value = includeInactive;
                DBUtil.addListParameter(cmd, "@" + FILTER_CATEGORYENUMIDLIST, categoryEnumIDList);
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ID);
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = Tools.wrapNullable(nameFilter);
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);
                cmd.Parameters.Add("@" + COL_DB_RETAILLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(retailLengthUnitID);
                cmd.Parameters.Add("@" + COL_DB_BULKLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(bulkLengthUnitID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);

                adapter.SelectCommand = cmd;
                adapter.Fill(datatable);
            }
            Tools.parseEnum<GordenItemCategories>(datatable, COL_CATEGORYNAME, COL_DB_CATEGORYENUMID);

            return datatable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("gordenitem_update_active", id, activeStatus);
        }

        public static void update(Guid id, string name, GordenItemCategories category, Guid vendorID, Guid retailLengthUnitID, Guid bulkLengthUnitID,
            Guid? productWidthID, decimal? buyRetailPricePerUnit, decimal? buyBulkPricePerUnit, decimal? sellRetailPricePerUnit, decimal? sellBulkPricePerUnit, string notes)
        {
            try
            {
                GordenItem objOld = new GordenItem(id);

                //generate log description
                string log = "";
                log = ActivityLog.appendChange(log, objOld.Name, name, "Name: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.CategoryName, category, "Category: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.VendorID, new Vendor(vendorID).Name, "Vendor: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.ProductWidthID, new ProductWidth(productWidthID).Name, "Width: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.RetailLengthUnitID, new LengthUnit(retailLengthUnitID).Name, "Retail Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.BulkLengthUnitID, new LengthUnit(bulkLengthUnitID).Name, "Bulk Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.BuyRetailPricePerUnit, buyRetailPricePerUnit, "Buy Retail Price/Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.BuyBulkPricePerUnit, buyBulkPricePerUnit, "Buy Bulk Price/Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.SellRetailPricePerUnit, sellRetailPricePerUnit, "Sell Retail Price/Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.SellBulkPricePerUnit, sellBulkPricePerUnit, "Sell Bulk Price/Unit: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                if (string.IsNullOrEmpty(log))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("gordenitem_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@" + COL_DB_CATEGORYENUMID, SqlDbType.TinyInt).Value = category;
                        cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                        cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);
                        cmd.Parameters.Add("@" + COL_DB_RETAILLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = retailLengthUnitID;
                        cmd.Parameters.Add("@" + COL_DB_BULKLENGTHUNITID, SqlDbType.UniqueIdentifier).Value = bulkLengthUnitID;
                        cmd.Parameters.Add("@" + COL_DB_BUYRETAILPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(buyRetailPricePerUnit);
                        cmd.Parameters.Add("@" + COL_DB_BUYBULKPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(buyBulkPricePerUnit);
                        cmd.Parameters.Add("@" + COL_DB_SELLRETAILPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellRetailPricePerUnit);
                        cmd.Parameters.Add("@" + COL_DB_SELLBULKPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellBulkPricePerUnit);
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + log);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static int[] convertToIntArray(params GordenItemCategories?[] categoryEnumIDList)
        {
            List<int> intList = new List<int>();
            foreach (GordenItemCategories? item in categoryEnumIDList)
            {
                if (item != null) intList.Add((int)item);
            }
            return intList.ToArray();
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, params GordenItemCategories?[] categoryEnumIDList)
        {
            Tools.populateDropDownList(dropdownlist, get(includeInactive, Tools.copyIntToArrayTable(convertToIntArray(categoryEnumIDList)), null, null, null, null, null, null).DefaultView, COL_DB_NAME, COL_DB_ID, false);
        }

        public static void populateCheckedListBox(System.Windows.Forms.CheckedListBox checkedlistbox, bool includeInactive, GordenItemCategories? category)
        {
            Tools.populateCheckedListBox(checkedlistbox, get(includeInactive, null, null, null, null, null, null, category).DefaultView, COL_DB_NAME, COL_DB_ID);
        }
    }
}
