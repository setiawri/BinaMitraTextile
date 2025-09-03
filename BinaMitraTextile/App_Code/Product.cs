using LIBUtil;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BinaMitraTextile
{
    public class Product
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_STORENAMEID = "store_name_id";
        public const string COL_DB_NAMEVENDOR = "name_vendor";
        public const string COL_DB_VENDORID = "vendor_id";
		public const string COL_DB_COMPANYENUMID = "company_enum_id";
		public const string COL_DB_PercentageOfPercentCommission = "PercentageOfPercentCommission";
        public const string COL_DB_MaxCommissionAmount = "MaxCommissionAmount";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";
        public const string COL_NAMEFULL = "name_full";
        public const string COL_VENDORNAME = "vendor_name";
        public const string COL_STORENAME = "store_name";
		public const string COL_COMPANYNAME = "company_name";

		public const string FILTER_IncludeInactive = "include_inactive";

        public Guid ID;
        public Guid StoreNameID;
        public string NameVendor = "";
        public Guid VendorID;
        public Companies Company = Companies.CV;
        public Boolean Active = true;
        public string Notes = "";
        public string VendorName = "";
        public string StoreName = "";
        public decimal PercentageOfPercentCommission = 100;
        public int? MaxCommissionAmount;
		public string CompanyName = "";

		public Product(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            DataRow row = dt.Rows[0];
            if (dt.Rows[0][COL_DB_STORENAMEID] != DBNull.Value) StoreNameID = (Guid)dt.Rows[0][COL_DB_STORENAMEID];
            NameVendor = dt.Rows[0][COL_DB_NAMEVENDOR].ToString();
            VendorID = (Guid)dt.Rows[0][COL_DB_VENDORID];
			Company = Tools.parseEnum<Companies>(DBUtil.parseData<Int32>(row, COL_DB_COMPANYENUMID));
			Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
            Notes = dt.Rows[0][COL_DB_NOTES].ToString();
            PercentageOfPercentCommission = LIBUtil.Util.wrapNullable<decimal>(row, COL_DB_PercentageOfPercentCommission);
            MaxCommissionAmount = LIBUtil.Util.wrapNullable<int?>(row, COL_DB_MaxCommissionAmount);

            VendorName = dt.Rows[0][COL_VENDORNAME].ToString();
            StoreName = dt.Rows[0][COL_STORENAME].ToString();
			CompanyName = dt.Rows[0][COL_COMPANYNAME].ToString();
		}

        public static Guid? add(Guid storeNameID, string nameVendor, Guid vendorID, Companies companyEnumID, decimal percentageOfPercentCommission, decimal? maxCommissionAmount, string notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "product_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier, storeNameID),
                new SqlQueryParameter(COL_DB_NAMEVENDOR, SqlDbType.VarChar, nameVendor),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, vendorID),
				new SqlQueryParameter(COL_DB_COMPANYENUMID, SqlDbType.Int, companyEnumID),
				new SqlQueryParameter(COL_DB_PercentageOfPercentCommission, SqlDbType.Decimal, percentageOfPercentCommission),
                new SqlQueryParameter(COL_DB_MaxCommissionAmount, SqlDbType.Decimal, Util.wrapNullable(maxCommissionAmount)),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static bool isNameCombinationExist(Guid storeNameID, string nameVendor, Guid vendorID, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "product_isNameCombinationExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier, storeNameID),
                new SqlQueryParameter(COL_DB_NAMEVENDOR, SqlDbType.VarChar, nameVendor),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, vendorID)
                );
            return result.ValueBoolean;
        }

        public static DataTable getRow(Guid ID)
        {
            DataTable result = DBUtil.getRows("product_get", ID);
			Tools.parseEnum<Companies>(result, COL_COMPANYNAME, COL_DB_COMPANYENUMID);

			return result;
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return get(includeInactive, null, null, null);
        }

        public static DataTable get(bool includeInactive, Guid? storeNameID, string nameVendor, Guid? vendorID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "product_get_byFilter",
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(storeNameID)),
                new SqlQueryParameter(COL_DB_NAMEVENDOR, SqlDbType.VarChar, Util.wrapNullable(nameVendor)),
                new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(vendorID))
            );

			Tools.parseEnum<Companies>(result.Datatable, COL_COMPANYNAME, COL_DB_COMPANYENUMID);

			return result.Datatable;
        }

        public static void update(Guid id, Guid storeNameID, string nameVendor, Guid vendorID, Companies CompanyEnumID, decimal percentageOfPercentCommission, decimal? maxCommissionAmount, string notes)
        {
            Product objOld = new Product(id);

            //generate log description
            string logDescription = "";
            if (objOld.NameVendor != nameVendor) logDescription = Tools.append(logDescription, String.Format("Name - Vendor: '{0}' to '{1}'", objOld.NameVendor, nameVendor), ",");
            if (objOld.StoreNameID != storeNameID) logDescription = Tools.append(logDescription, String.Format("Name - Store: '{0}' to '{1}'", objOld.StoreName, new ProductStoreName(storeNameID).Name), ",");
			if (objOld.VendorID != vendorID) logDescription = Tools.append(logDescription, String.Format("Vendor ID: '{0}' to '{1}'", objOld.VendorName, new Vendor(vendorID).Name), ",");
			if (objOld.Company != CompanyEnumID) logDescription = Tools.append(logDescription, String.Format("Company ID: '{0}' to '{1}'", objOld.Company.ToString(), CompanyEnumID.ToString()), ",");
            logDescription = LIBUtil.Util.appendChange(logDescription, objOld.PercentageOfPercentCommission, percentageOfPercentCommission, "Percentage of Percent Comission: {0:N2} to {1:N2}");
            logDescription = LIBUtil.Util.appendChange(logDescription, objOld.MaxCommissionAmount, maxCommissionAmount, "Max Comission: {0:N0} to {1:N0}");
            logDescription = Util.appendChange(logDescription, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "product_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_STORENAMEID, SqlDbType.UniqueIdentifier, storeNameID),
                    new SqlQueryParameter(COL_DB_NAMEVENDOR, SqlDbType.VarChar, nameVendor),
                    new SqlQueryParameter(COL_DB_VENDORID, SqlDbType.UniqueIdentifier, vendorID),
				    new SqlQueryParameter(COL_DB_COMPANYENUMID, SqlDbType.Int, CompanyEnumID),
					new SqlQueryParameter(COL_DB_PercentageOfPercentCommission, SqlDbType.Decimal, percentageOfPercentCommission),
                    new SqlQueryParameter(COL_DB_MaxCommissionAmount, SqlDbType.Decimal, Util.wrapNullable(maxCommissionAmount)),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(id, logDescription);
            }
        }
        
        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("product_update_active", id, activeStatus);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault, Guid? vendorID)
        {
            Tools.populateDropDownList(dropdownlist, get(includeInactive, null, null, vendorID).DefaultView, COL_NAMEFULL, COL_DB_ID, showDefault);
        }

        public static void populateCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool includeInactive)
        {
            checkedlistbox.populate(get(includeInactive, null, null, null).DefaultView, COL_STORENAME, COL_DB_ID);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(getByFilter(includeInactive).DefaultView, COL_STORENAME, COL_DB_ID, null);
        }

    }
}
