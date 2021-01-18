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
        public const string COL_DB_BuyPrice = "BuyPrice";

        public const string COL_Grades_Name = "grade_name";
        public const string COL_PRODUCTSTORENAME = "product_store_name";
        public const string COL_COLORNAME = "color_name";
        public const string COL_ProductWidths_Name = "width_name";
        public const string COL_LengthUnits_Name = "length_unit_name";
        public const string COL_Inventory_Code = "inventory_code";

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
        public decimal? BuyPrice;

        public string ColorName = "";
        public int? Inventory_Code;

        public ProductPrice(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, decimal tagPrice, string notes, 
            Guid? inventoryID, Guid? colorID, decimal? buyPrice)
        {
            ID = Guid.NewGuid();
            ProductStoreNameID = productStoreNameID;
            GradeID = gradeID;
            ProductWidthID = productWidthID;
            LengthUnitID = lengthUnitID;
            TagPrice = tagPrice;
            BuyPrice = buyPrice;
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
            DataRow row = get(ID);
            ProductStoreNameID = Util.wrapNullable<Guid>(row, COL_DB_PRODUCTSTORENAMEID);
            GradeID = Util.wrapNullable<Guid?>(row, COL_DB_GRADEID);
            ProductWidthID = Util.wrapNullable<Guid?>(row, COL_DB_PRODUCTWIDTHID);
            LengthUnitID = Util.wrapNullable<Guid?>(row, COL_DB_LENGTHUNITID);
            InventoryID = Util.wrapNullable<Guid?>(row, COL_DB_INVENTORYID);
            ColorID = Util.wrapNullable<Guid?>(row, COL_DB_COLORID);
            TagPrice = Util.wrapNullable<decimal>(row, COL_DB_SELLPRICE);
            Notes = Util.wrapNullable<string>(row, COL_DB_NOTES);
            StoreName = Util.wrapNullable<string>(row, COL_PRODUCTSTORENAME);
            Checked = Util.wrapNullable<bool>(row, COL_DB_Checked);
            BuyPrice = Util.wrapNullable<decimal?>(row, COL_DB_BuyPrice);

            ColorName = Util.wrapNullable<string>(row, COL_COLORNAME);
            Inventory_Code = Util.wrapNullable<int?>(row, COL_Inventory_Code);
        }

        public Guid? submitNew()
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productprice_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductStoreNameID)),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(GradeID)),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductWidthID)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(LengthUnitID)),
                new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(InventoryID)),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ColorID)),
                new SqlQueryParameter(COL_DB_SELLPRICE, SqlDbType.Decimal, TagPrice),
                new SqlQueryParameter(COL_DB_BuyPrice, SqlDbType.Decimal, Util.wrapNullable(BuyPrice)),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(Notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static Guid? add(Guid? ProductStoreNameID, Guid? GradeID, Guid? ProductWidthID, Guid? LengthUnitID, decimal TagPrice, string Notes,
            Guid? InventoryID, Guid? ColorID, decimal? BuyPrice)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productprice_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductStoreNameID)),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(GradeID)),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductWidthID)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(LengthUnitID)),
                new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(InventoryID)),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ColorID)),
                new SqlQueryParameter(COL_DB_SELLPRICE, SqlDbType.Decimal, TagPrice),
                new SqlQueryParameter(COL_DB_BuyPrice, SqlDbType.Decimal, Util.wrapNullable(BuyPrice)),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(Notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public void delete() { delete(ID); }
        public static void delete(Guid Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productprice_delete",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id)
            );
        }

        public static bool isCombinationExist(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? id, Guid? inventoryID, Guid? colorID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "productprice_isCombinationExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(inventoryID)),
                new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productStoreNameID)),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(gradeID)),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productWidthID)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(lengthUnitID)),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(colorID))
                );
            return result.ValueBoolean;
        }

        public static DataTable get(bool onlyNotChecked) { return get(null, null, null, null, null, null, null, onlyNotChecked); }
        public static DataRow get(Guid ID) { return Util.getFirstRow(get(ID, null, null, null, null, null, null, false)); }
        public static DataTable get(Guid? ID, Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? inventoryID, Guid? ColorID, bool onlyNotChecked)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "productprice_get",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ID)),
                new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(inventoryID)),
                new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productStoreNameID)),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(gradeID)),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productWidthID)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(lengthUnitID)),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ColorID)),
                new SqlQueryParameter(FILTER_OnlyNotChecked, SqlDbType.Bit, onlyNotChecked)
            );
            return result.Datatable;
        }

        public static Guid? getByCombination(Guid? productStoreNameID, Guid? gradeID, Guid? productWidthID, Guid? lengthUnitID, Guid? inventoryID, Guid? ColorID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, false, true,
                "productprice_get_by_combination",
                new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(inventoryID)),
                new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productStoreNameID)),
                new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(gradeID)),
                new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(productWidthID)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(lengthUnitID)),
                new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ColorID))
                );
            return Util.wrapNullable<Guid?>(result.ValueGuid);
        }

        public static void update(Guid ID, Guid? ProductStoreNameID, Guid? GradeID, Guid? ProductWidthID, Guid? LengthUnitID, decimal TagPrice, string Notes,
            Guid? InventoryID, Guid? ColorID, decimal? BuyPrice)
        {
            ProductPrice objOld = new ProductPrice(ID);

            //generate log description
            string logDescription = "";
            if (objOld.ProductStoreNameID != ProductStoreNameID) logDescription = Tools.append(logDescription, String.Format("Product Store Name: '{0}' to '{1}'", objOld.StoreName, new ProductStoreName((Guid)ProductStoreNameID).Name), ",");
            if (objOld.GradeID != GradeID) logDescription = Tools.append(logDescription, String.Format("Grade ID: '{0}' to '{1}'", objOld.GradeID, GradeID), ",");
            if (objOld.ProductWidthID != ProductWidthID) logDescription = Tools.append(logDescription, String.Format("Product Width ID: '{0}' to '{1}'", objOld.ProductWidthID, ProductWidthID), ",");
            if (objOld.LengthUnitID != LengthUnitID) logDescription = Tools.append(logDescription, String.Format("Length Unit ID: '{0}' to '{1}'", objOld.LengthUnitID, LengthUnitID), ",");
            logDescription = ActivityLog.appendChange(logDescription, objOld.Inventory_Code, new Inventory((Guid)InventoryID).code, "Inventory Code: '{0}' to '{1}'");
            if (objOld.TagPrice != TagPrice) logDescription = Tools.append(logDescription, String.Format("Tag Price: '{0}' to '{1}'", objOld.TagPrice, TagPrice), ",");
            logDescription = Util.appendChange(logDescription, objOld.BuyPrice, BuyPrice, "Buy Price: {0} to {1}");
            logDescription = ActivityLog.appendChange(logDescription, objOld.ColorName, new FabricColor(ColorID).Name, "Color: '{0}' to '{1}'");
            logDescription = ActivityLog.appendChange(logDescription, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "productprice_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, ID),
                    new SqlQueryParameter(COL_DB_PRODUCTSTORENAMEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductStoreNameID)),
                    new SqlQueryParameter(COL_DB_GRADEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(GradeID)),
                    new SqlQueryParameter(COL_DB_PRODUCTWIDTHID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ProductWidthID)),
                    new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(LengthUnitID)),
                    new SqlQueryParameter(COL_DB_INVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(InventoryID)),
                    new SqlQueryParameter(COL_DB_COLORID, SqlDbType.UniqueIdentifier, Util.wrapNullable(ColorID)),
                    new SqlQueryParameter(COL_DB_SELLPRICE, SqlDbType.Decimal, TagPrice),
                    new SqlQueryParameter(COL_DB_BuyPrice, SqlDbType.Decimal, Util.wrapNullable(BuyPrice)),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(Notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(ID, "Update: " + logDescription);
            }
        }

        public static void update(List<Guid?> ProductPrices_Ids, decimal sellPrice)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
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
                DBConnection.ActiveSqlConnection,
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
