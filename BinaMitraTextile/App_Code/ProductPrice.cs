using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using LIBUtil;

namespace BinaMitraTextile
{
    public class ProductPrice
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_PRODUCTSTORENAMEID = "product_store_name_id";
        public const string COL_DB_GRADEID = "grade_id";
        public const string COL_DB_PRODUCTWIDTHID = "product_width_id";
        public const string COL_DB_LENGTHUNITID = "length_unit_id";
        public const string COL_DB_COLORID = "color_id";
        public const string COL_DB_SELLPRICE = "sell_price";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_INVENTORYID = "inventory_id";
        public const string COL_DB_Checked = "Checked";

        public const string COL_PRODUCTSTORENAME = "product_store_name";
        public const string COL_COLORNAME = "color_name";

        public const string FILTER_OnlyNotChecked = "FILTER_OnlyNotChecked";
        public const string ARRAY_ProductPrices_Id = "ARRAY_ProductPrices_Id";

        public Guid ID;
        public Guid? ProductStoreNameID;
        public Guid? GradeID;
        public Guid? ProductWidthID;
        public Guid? LengthUnitID;
        public Guid? ColorID;
        public decimal TagPrice;
        public string Notes = "";
        public string StoreName;
        public Guid? InventoryID;
        public bool Checked;

        public string ColorName = "";

        public ProductPrice(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, decimal tagPrice, string notes, Guid? inventoryID, Guid? colorID)
        {
            ID = Guid.NewGuid();
            ProductStoreNameID = productStoreNameID;
            GradeID = gradeID;
            ProductWidthID = productWidthID;
            LengthUnitID = lengthUnitID;
            TagPrice = tagPrice;
            Notes = notes;
            if(productStoreNameID != null) 
                StoreName = new ProductStoreName((Guid)productStoreNameID).Name;
            else
                StoreName = new Inventory((Guid)inventoryID).product_store_name;
            InventoryID = inventoryID;
            ColorID = colorID;
            if (colorID != null)
                ColorName = new FabricColor((Guid)colorID).Name;
            else
                ColorName = "";
        }

        public ProductPrice(Guid id)
        {
            ID = id;
            DataRow row = getRow(ID).Rows[0];
            ProductStoreNameID = DBUtil.parseData<Guid>(row, COL_DB_PRODUCTSTORENAMEID);
            GradeID = DBUtil.parseData<Guid?>(row, COL_DB_GRADEID);
            ProductWidthID = DBUtil.parseData<Guid?>(row, COL_DB_PRODUCTWIDTHID);
            LengthUnitID = DBUtil.parseData<Guid?>(row, COL_DB_LENGTHUNITID);
            InventoryID = DBUtil.parseData<Guid?>(row, COL_DB_INVENTORYID);
            ColorID = DBUtil.parseData<Guid?>(row, COL_DB_COLORID);
            TagPrice = Tools.zeroNonNumericString(DBUtil.parseData<Decimal>(row, COL_DB_SELLPRICE));
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
            StoreName = DBUtil.parseData<string>(row, COL_PRODUCTSTORENAME);
            Checked = DBUtil.parseData<bool>(row, COL_DB_Checked);

            ColorName = DBUtil.parseData<string>(row, COL_COLORNAME);
        }

        public string submitNew()
        {
            try 
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("productprice_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ProductStoreNameID);
                    cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(GradeID);
                    cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ProductWidthID);
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(LengthUnitID);
                    cmd.Parameters.Add("@" + COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(InventoryID);
                    cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ColorID);
                    cmd.Parameters.Add("@" + COL_DB_SELLPRICE, SqlDbType.Decimal).Value = TagPrice;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Notes;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public string delete()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("productprice_delete", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = ID;

                    cmd.ExecuteNonQuery();

                    //generate log description
                    string logDescription = "";
                    logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}'", StoreName), ",");
                    logDescription = Tools.append(logDescription, String.Format("Grade ID: '{0}'", GradeID), ",");
                    logDescription = Tools.append(logDescription, String.Format("Product Width ID: '{0}'", ProductWidthID), ",");
                    logDescription = Tools.append(logDescription, String.Format("Length Unit ID: '{0}'", LengthUnitID), ",");
                    logDescription = Tools.append(logDescription, String.Format("Tag Price: '{0}'", TagPrice), ",");
                    logDescription = Tools.append(logDescription, String.Format("Inventory ID: '{0}'", InventoryID), ",");
                    logDescription = Tools.append(logDescription, String.Format("Color: '{0}'", ColorName), ",");
                    logDescription = Tools.append(logDescription, String.Format("Notes: '{0}'", Notes), ",");

                    ActivityLog.submit(ID, String.Format("Product Price deleted: {0}", logDescription));
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static Guid? getByCombination(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? inventoryID, Guid? ColorID)
        {
            using (SqlCommand cmd = new SqlCommand("productprice_get_by_combination", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(inventoryID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productStoreNameID);
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(gradeID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(lengthUnitID);
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ColorID);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.UniqueIdentifier);
                return_value.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (return_value.Value == DBNull.Value)
                    return null;
                else
                    return (Guid?)return_value.Value;
            }
        }

        public static bool isCombinationExist(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? id, Guid? inventoryID, Guid? colorID)
        {
            using (SqlCommand cmd = new SqlCommand("productprice_isCombinationExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(inventoryID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productStoreNameID);
                cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(gradeID);
                cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(productWidthID);
                cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(lengthUnitID);
                cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(colorID);
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;
                
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("productprice_get", ID);
        }

        public static DataTable getAll(bool onlyNotChecked)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("productprice_getall", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + FILTER_OnlyNotChecked, SqlDbType.Bit).Value = onlyNotChecked;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public string update()
        {
            try
            {
                ProductPrice objOld = new ProductPrice(ID);

                //generate log description
                string logDescription = "";
                if (objOld.ProductStoreNameID != ProductStoreNameID) logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}' to '{1}'", objOld.StoreName, StoreName), ",");
                if (objOld.GradeID != GradeID) logDescription = Tools.append(logDescription, String.Format("Grade ID: '{0}' to '{1}'", objOld.GradeID, GradeID), ",");
                if (objOld.ProductWidthID != ProductWidthID) logDescription = Tools.append(logDescription, String.Format("Product Width ID: '{0}' to '{1}'", objOld.ProductWidthID, ProductWidthID), ",");
                if (objOld.LengthUnitID != LengthUnitID) logDescription = Tools.append(logDescription, String.Format("Length Unit ID: '{0}' to '{1}'", objOld.LengthUnitID, LengthUnitID), ",");
                if (objOld.InventoryID != InventoryID) logDescription = Tools.append(logDescription, String.Format("Inventory ID: '{0}' to '{1}'", objOld.InventoryID, InventoryID), ",");
                if (objOld.TagPrice != TagPrice) logDescription = Tools.append(logDescription, String.Format("Tag Price: '{0}' to '{1}'", objOld.TagPrice, TagPrice), ",");
                logDescription = ActivityLog.appendChange(logDescription, objOld.ColorName, ColorName, "Color: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

                if (string.IsNullOrEmpty(logDescription))
                {
                    return "No information has been changed";
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("productprice_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = ID;
                        cmd.Parameters.Add("@" + COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier).Value = ProductStoreNameID;
                        cmd.Parameters.Add("@" + COL_DB_GRADEID, SqlDbType.UniqueIdentifier).Value = GradeID;
                        cmd.Parameters.Add("@" + COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier).Value = ProductWidthID;
                        cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = LengthUnitID;
                        cmd.Parameters.Add("@" + COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(InventoryID);
                        cmd.Parameters.Add("@" + COL_DB_COLORID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(ColorID);
                        cmd.Parameters.Add("@" + COL_DB_SELLPRICE, SqlDbType.Decimal).Value = TagPrice;
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Notes;

                        cmd.ExecuteNonQuery();

                        //submit log
                        logDescription = "Product Price update: " + logDescription;
                        ActivityLog.submit(ID, logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            } catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static void update(List<Guid?> ProductPrices_Ids, decimal sellPrice)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productprice_update_sell_price",
                DBConnection.createTableParameters(
                    new SqlQueryTableParameterGuid(ARRAY_ProductPrices_Id, ProductPrices_Ids.ToArray())
                    ),
                new SqlQueryParameter(COL_DB_SELLPRICE, SqlDbType.Decimal, sellPrice)
            );

            if (result.IsSuccessful)
                foreach(Guid? id in ProductPrices_Ids)
                    ActivityLog.submit((Guid)id, String.Format("Updated Price: {0:c2}", sellPrice));
        }


        public static void update_Checked(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productprice_update_Checked",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Checked, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Checked Status to " + value);
        }
    }
}
