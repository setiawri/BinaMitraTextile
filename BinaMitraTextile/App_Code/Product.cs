using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class Product
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_STORENAMEID = "store_name_id";
        public const string COL_DB_NAMEVENDOR = "name_vendor";
        public const string COL_DB_VENDORID = "vendor_id";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";
        public const string COL_NAMEFULL = "name_full";
        public const string COL_VENDORNAME = "vendor_name";
        public const string COL_STORENAME = "store_name";

        public Guid ID;
        public Guid StoreNameID;
        public string NameVendor = "";
        public Guid VendorID;
        public Boolean Active = true;
        public string Notes = "";
        public string VendorName = "";
        public string StoreName = "";

        public Product(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            if (dt.Rows[0][COL_DB_STORENAMEID] != DBNull.Value) StoreNameID = (Guid)dt.Rows[0][COL_DB_STORENAMEID];
            NameVendor = dt.Rows[0][COL_DB_NAMEVENDOR].ToString();
            VendorID = (Guid)dt.Rows[0][COL_DB_VENDORID];
            Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
            Notes = dt.Rows[0][COL_DB_NOTES].ToString();

            VendorName = dt.Rows[0][COL_VENDORNAME].ToString();
            StoreName = dt.Rows[0][COL_STORENAME].ToString();
        }

        public static void add(Guid storeNameID, string nameVendor, Guid vendorID, string notes)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("product_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier).Value = storeNameID;
                    cmd.Parameters.Add("@" + COL_DB_NAMEVENDOR, SqlDbType.VarChar).Value = nameVendor;
                    cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isNameCombinationExist(Guid storeNameID, string nameVendor, Guid vendorID, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("product_isNameCombinationExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier).Value = storeNameID;
                cmd.Parameters.Add("@" + COL_DB_NAMEVENDOR, SqlDbType.VarChar).Value = nameVendor;
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;
                
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("product_get", ID);
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null, null, null);
        }

        public static DataTable getByFilter(bool includeInactive, Guid? storeNameID, string nameVendorFilter, Guid? vendorID)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("product_get_byFilter", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@" + COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(storeNameID);
                cmd.Parameters.Add("@" + COL_DB_NAMEVENDOR, SqlDbType.VarChar).Value = Tools.wrapNullable(nameVendorFilter);
                cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(vendorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void update(Guid id, Guid storeNameID, string nameVendor, Guid vendorID, string notes)
        {
            try
            {
                Product objOld = new Product(id);

                //generate log description
                string logDescription = "";
                if (objOld.NameVendor != nameVendor) logDescription = Tools.append(logDescription, String.Format("Name - Vendor: '{0}' to '{1}'", objOld.NameVendor, nameVendor), ",");
                if (objOld.StoreNameID != storeNameID) logDescription = Tools.append(logDescription, String.Format("Name - Store: '{0}' to '{1}'", objOld.StoreName, new ProductStoreName(storeNameID).Name), ",");
                if (objOld.VendorID != vendorID) logDescription = Tools.append(logDescription, String.Format("Vendor ID: '{0}' to '{1}'", objOld.VendorName, new Vendor(vendorID).Name), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("product_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier).Value = storeNameID;
                        cmd.Parameters.Add("@" + COL_DB_NAMEVENDOR, SqlDbType.VarChar).Value = nameVendor;
                        cmd.Parameters.Add("@" + COL_DB_VENDORID, SqlDbType.UniqueIdentifier).Value = vendorID;
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }
        
        public static string updateActiveStatus(Guid id, Boolean activeStatus)
        {
            return DBUtil.updateActiveStatus("product_update_active", id, activeStatus);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault, Guid? vendorID)
        {
            Tools.populateDropDownList(dropdownlist, getByFilter(includeInactive, null, null, vendorID).DefaultView, COL_NAMEFULL, COL_DB_ID, showDefault);
        }

        public static void populateCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool includeInactive)
        {
            checkedlistbox.populate(getByFilter(includeInactive, null, null, null).DefaultView, COL_STORENAME, COL_DB_ID);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(getByFilter(includeInactive).DefaultView, COL_STORENAME, COL_DB_ID, null);
        }

    }
}
