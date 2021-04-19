using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class SaleItem
    {
        /*******************************************************************************************************/

        #region CLASS VARIABLES

        public const string COL_ID = "id";
        public const string COL_INVENTORY_ID = "inventory_id";
        public const string COL_INVENTORY_ITEM_ID = "inventory_item_id";
        public const string COL_BARCODE = "barcode";
        public const string COL_SELLPRICE = "sell_price";
        public const string COL_ADJUSTMENT = "adjustment";
        public const string COL_LENGTH = "item_length";
        public const string COL_CUSTOMERID = "customer_id";
        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_DB_Vendors_Id = "Vendors_Id";
        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_DB_isManualAdjustment = "isManualAdjustment";
        public const string COL_DB_sale_id = "sale_id";
        public const string COL_DB_CommissionPercent = "CommissionPercent";
        public const string COL_DB_CommissionAmount = "CommissionAmount";

        public const string COL_QTY = "qty";
        public const string COL_SUBTOTAL = "subtotal";
        public const string COL_INVENTORYCODE = "inventory_code";
        public const string COL_BUYPRICE = "buy_price";
        public const string COL_PROFIT = "profit";
        public const string COL_PROFITPERCENT = "profit_percent";
        public const string COL_SALE_ADJUSTEDPRICE = "adjusted_price";
        public const string COL_PRODUCTSTORENAME = "product_store_name";
        public const string COL_PRODUCTWIDTHNAME = "product_width_name";
        public const string COL_INVENTORYCOLORNAME = "inventory_color_name";
        public const string COL_INVENTORYITEMCOLORNAME = "inventoryitem_color_name";
        public const string COL_SELECTED = "selected";
        public const string COL_SaleOrderItemDescription = "SaleOrderItemDescription";
        public const string COL_SaleOrderItems_Id = "SaleOrderItems_Id";
        public const string COL_Sales_Barcode = "Sales_Barcode";
        public const string COL_Sales_Timestamp = "Sales_Timestamp";
        public const string COL_TotalCommissionAmount = "TotalCommissionAmount";

        public Guid id;
        public Guid sale_id;
        public Guid inventory_item_id;
        public Decimal sell_price;
        public Decimal adjustment;
        public bool isManualAdjustment;

        #endregion CLASS VARIABLES

        /*******************************************************************************************************/

        #region CONSTRUCTORS
        
        public SaleItem()
        {

        }

        public SaleItem(string Barcode)
        {

        }

        #endregion CONSTRUCTORS

        /*******************************************************************************************************/
        #region METHODS

        public static DataTable getItemForReturn(string InventoryItemBarcode)
        {
            DataTable dataTable = getItem(InventoryItemBarcode, true);

            Tools.addColumn<int>(dataTable, COL_QTY, 1);

            return dataTable;
        }

        #endregion METHODS
        /*******************************************************************************************************/

        #region DATABASE METHODS
        
        public static void submitItems(List<SaleItem> SaleItems, string SaleBarcode, Guid? Customers_Id)
        {
            foreach (SaleItem item in SaleItems)
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "saleitem_new",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, item.id),
                    new SqlQueryParameter(COL_DB_sale_id, SqlDbType.UniqueIdentifier, item.sale_id),
                    new SqlQueryParameter(COL_INVENTORY_ITEM_ID, SqlDbType.UniqueIdentifier, item.inventory_item_id),
                    new SqlQueryParameter(COL_SELLPRICE, SqlDbType.Decimal, item.sell_price),
                    new SqlQueryParameter(COL_ADJUSTMENT, SqlDbType.Decimal, item.adjustment),
                    new SqlQueryParameter(COL_DB_isManualAdjustment, SqlDbType.Bit, item.isManualAdjustment),
                    new SqlQueryParameter(COL_CUSTOMERID, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(item.inventory_item_id, "Sale ID: " + SaleBarcode);
            }
        }

        public static void updateItems(List<SaleItem> SaleItems)
        {
            foreach (SaleItem item in SaleItems)
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "saleitem_update",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, item.id),
                    new SqlQueryParameter(COL_ADJUSTMENT, SqlDbType.Decimal, item.adjustment)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(item.id, "Updated");
            }
        }
        
        public static DataTable getItem(string InventoryItemBarcode, bool isForReturn)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("saleitem_get_by_inventory_item_barcode", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@inventory_item_barcode", SqlDbType.VarChar).Value = InventoryItemBarcode;
                if(isForReturn)
                    cmd.Parameters.Add("@is_for_return", SqlDbType.Bit).Value = true;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getItems(Guid SaleID)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("saleitem_get_by_sale_id", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sale_id", SqlDbType.UniqueIdentifier).Value = SaleID;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            Tools.addColumn<bool>(dataTable, COL_SELECTED, 0);
            Tools.addColumn<bool>(dataTable, COL_DB_isManualAdjustment, 0);

            return dataTable;
        }

        public static DataTable getItemSummary(Guid SaleID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "saleitem_get_summary_by_sale_id",
                new SqlQueryParameter(COL_DB_sale_id, SqlDbType.UniqueIdentifier, SaleID)
            );
            return result.Datatable;
        }

        public static DataTable getReturnedItemSummary(Guid SaleReturnID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "saleitem_get_summary_by_salereturn_id",
                new SqlQueryParameter("salereturn_id", SqlDbType.UniqueIdentifier, SaleReturnID)
            );
            return result.Datatable;
        }

        public static DataTable getReturnedItems(Guid SaleReturnID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "saleitem_get_by_salereturn_id",
                new SqlQueryParameter("salereturn_id", SqlDbType.UniqueIdentifier, SaleReturnID)
            );
            return result.Datatable;
        }

        #endregion DATABASE METHODS

        /*******************************************************************************************************/

    }
}
