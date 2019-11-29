using System;

using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class CustomerSaleAdjustment
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_CODE = "code";
        public const string COL_DB_CUSTOMERID = "customer_id";
        public const string COL_DB_PRODUCTWIDTHID = "product_width_id";
        public const string COL_DB_LENGTHUNITID = "length_unit_id";
        public const string COL_DB_COLORID = "color_id";
        public const string COL_DB_PRODUCSTORENAMEID = "product_store_name_id";
        public const string COL_DB_GRADEID = "grade_id";
        public const string COL_DB_ADJUSTMENTPERUNIT = "adjustment_per_unit";
        public const string COL_DB_Checked = "Checked";
        public const string COL_DB_NOTES = "notes";

        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_GRADE_NAME = "grade_name";
        public const string COL_PRODUCTSTORENAME = "store_name";
        public const string COL_LENGTH_UNIT_NAME = "length_unit_name";
        public const string COL_PRODUCT_WIDTH_NAME = "width_name";
        public const string COL_COLOR_NAME = "color_name";

        public const string FILTER_OnlyNotChecked = "FILTER_OnlyNotChecked";

        public Guid ID;
        public Guid CustomerID;
        public Guid ProductStoreNameID;
        public Guid GradeID;
        public Guid ProductWidthID;
        public Guid LengthUnitID;
        public Guid? ColorID;
        public decimal AdjustmentPerUnit;
        public bool Checked;
        public string Notes = "";

        public string CustomerName = "";
        public string GradeName = "";
        public string LengthUnitName = "";
        public string ColorName = "";
        public string ProductStoreName = "";
        public string ProductWidthName = "";

        public CustomerSaleAdjustment() { }

        public CustomerSaleAdjustment(Guid id)
        {
            ID = id;
            DataRow row = getRow(ID).Rows[0];
            CustomerID = DBUtil.parseData<Guid>(row, COL_DB_CUSTOMERID);
            ProductStoreNameID = DBUtil.parseData<Guid>(row, COL_DB_PRODUCSTORENAMEID);
            ProductWidthID = DBUtil.parseData<Guid>(row, COL_DB_PRODUCTWIDTHID);
            GradeID = DBUtil.parseData<Guid>(row, COL_DB_GRADEID);
            LengthUnitID = DBUtil.parseData<Guid>(row, COL_DB_LENGTHUNITID);
            ColorID = DBUtil.parseData<Guid?>(row, COL_DB_COLORID);
            AdjustmentPerUnit = DBUtil.parseData<decimal>(row, COL_DB_ADJUSTMENTPERUNIT);
            Checked = DBUtil.parseData<bool>(row, COL_DB_Checked);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);

            CustomerName = DBUtil.parseData<string>(row, COL_CUSTOMERNAME);
            ProductStoreName = DBUtil.parseData<string>(row, COL_PRODUCTSTORENAME);
            GradeName = DBUtil.parseData<string>(row, COL_GRADE_NAME);
            LengthUnitName = DBUtil.parseData<string>(row, COL_LENGTH_UNIT_NAME);
            ProductWidthName = DBUtil.parseData<string>(row, COL_PRODUCT_WIDTH_NAME);
            ColorName = DBUtil.parseData<string>(row, COL_COLOR_NAME);
        }

        public static void add(Guid customerID, Guid gradeID, Guid productStoreNameID, Guid productWidthID, Guid lengthUnitID, Guid? colorID, decimal adjustmentPerUnit, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("customersaleadjustment_add", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                    cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCSTORENAMEID, SqlDbType.UniqueIdentifier).Value = productStoreNameID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(colorID);
                    cmd.Parameters.Add("@" + COL_DB_ADJUSTMENTPERUNIT, SqlDbType.Decimal).Value = adjustmentPerUnit;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isCombinationExist(Guid? id, Guid customerID, Guid gradeID, Guid productStoreNameID, Guid productWidthID, Guid lengthUnitID, Guid? colorID)
        {
            using (SqlCommand cmd = new SqlCommand("customersaleadjustment_isCombinationExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                cmd.Parameters.Add("@" + COL_DB_PRODUCSTORENAMEID, SqlDbType.UniqueIdentifier).Value = productStoreNameID;
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(colorID);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static void update(Guid id, Guid customerID, Guid gradeID, Guid productStoreNameID, Guid productWidthID, Guid lengthUnitID, Guid? colorID, decimal adjustmentPerUnit, string notes)
        {
            try
            {
                CustomerSaleAdjustment objOld = new CustomerSaleAdjustment(id);

                //generate log description
                string logDescription = "";
                if (objOld.CustomerID != customerID) { Customer customer = new Customer(customerID); logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}' to '{1}'", objOld.CustomerName, customer.Name), ","); }
                if (objOld.ProductStoreNameID != productStoreNameID) logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}' to '{1}'", objOld.ProductStoreName, new ProductStoreName(productStoreNameID).Name), ",");
                if (objOld.GradeID != gradeID) logDescription = Tools.append(logDescription, String.Format("Grade: '{0}' to '{1}'", objOld.GradeID, new Grade(gradeID).Name), ",");
                if (objOld.ProductWidthID != productWidthID) logDescription = Tools.append(logDescription, String.Format("Product Width: '{0}' to '{1}'", objOld.ProductWidthName, new ProductWidth(productWidthID).Name), ",");
                if (objOld.LengthUnitID != lengthUnitID) logDescription = Tools.append(logDescription, String.Format("Length Unit: '{0}' to '{1}'", objOld.LengthUnitID, new LengthUnit(lengthUnitID).Name), ",");
                if (objOld.AdjustmentPerUnit != adjustmentPerUnit) logDescription = Tools.append(logDescription, String.Format("Adjustment: '{0}' to '{1}'", objOld.AdjustmentPerUnit, adjustmentPerUnit), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

                using (SqlCommand cmd = new SqlCommand("customersaleadjustment_update", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = customerID;
                    cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = gradeID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCSTORENAMEID, SqlDbType.UniqueIdentifier).Value = productStoreNameID;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = productWidthID;
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = lengthUnitID;
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(colorID);
                    cmd.Parameters.Add("@" + COL_DB_ADJUSTMENTPERUNIT, SqlDbType.Decimal).Value = adjustmentPerUnit;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", logDescription));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void updateCheckedStatus(Guid userAccountID, Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "customersaleadjustment_update_Checked",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Checked, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Checked Status to " + value);
        }

        public static string delete(Guid id)
        {
            try
            {
                CustomerSaleAdjustment obj = new CustomerSaleAdjustment(id);

                //generate log description
                string logDescription = "";
                logDescription = Tools.append(logDescription, String.Format("Customer Name: '{0}'", obj.CustomerName), ","); 
                logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}'", obj.ProductStoreName), ",");
                logDescription = Tools.append(logDescription, String.Format("Grade: '{0}'", obj.GradeName), ",");
                logDescription = Tools.append(logDescription, String.Format("Product Width: '{0}'", obj.ProductWidthName), ",");
                logDescription = Tools.append(logDescription, String.Format("Unit: '{0}'", obj.LengthUnitName), ",");
                logDescription = Tools.append(logDescription, String.Format("Adjustment: '{0}'", obj.AdjustmentPerUnit), ",");
                logDescription = Tools.append(logDescription, String.Format("Notes: '{0}'", obj.Notes), ",");

                using (SqlCommand cmd = new SqlCommand("customersaleadjustment_delete", DBUtil.ActiveSqlConnection))
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
            return DBUtil.getRows("customersaleadjustment_get", ID);
        }

        public static DataTable getAll(Guid? customerID, Guid? gradeID, Guid? productID, Guid? productWidthID, Guid? lengthUnitID, Guid? colorID, bool onlyNotChecked)
        {
            //Tools.startProgressDisplay("Donwloading data...");

            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("customersaleadjustment_get_byFilter", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_CUSTOMERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(customerID);
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(gradeID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCSTORENAMEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(lengthUnitID);
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(colorID);
                cmd.Parameters.Add("@" + FILTER_OnlyNotChecked, SqlDbType.Bit).Value = onlyNotChecked;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            //Tools.stopProgressDisplay();

            return dataTable;
        }
    }
}
