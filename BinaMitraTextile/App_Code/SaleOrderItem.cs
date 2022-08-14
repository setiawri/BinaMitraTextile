using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using LIBUtil;

namespace BinaMitraTextile
{
    public enum SaleOrderItemStatus
    {
        New,
        Pending,
        Cancelled,
        [Description("In Production")]
        InProduction,
        [Description("Partial Shipment")]
        PartialShipment,
        Completed,
    };

    public class SaleOrderItem
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES

        public Guid Id;
        public Guid SaleOrders_Id;
        public Guid? Ref_Inventory_Id = null;
        public decimal PricePerUnit;
        public string ProductDescription;
        public decimal Qty;
        public string UnitName;
        public int LineNo;
        public SaleOrderItemStatus Status;
        public int PriorityNo;
        public DateTime? ExpectedDeliveryDate;
        public string Notes = null;

        public decimal Subtotal;
        public Guid Customers_Id;
        public string CustomerName;
        public string SaleOrders_No;

        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_SaleOrders_Id = "SaleOrders_Id";
        public const string COL_DB_Ref_Inventory_Id = "Ref_Inventory_Id";
        public const string COL_DB_PricePerUnit = "PricePerUnit";
        public const string COL_DB_ProductDescription = "ProductDescription";
        public const string COL_DB_Qty = "Qty";
        public const string COL_DB_UnitName = "UnitName";
        public const string COL_DB_LineNo = "LineNo";
        public const string COL_DB_Status_enum_id = "Status_enum_id";
        public const string COL_DB_PriorityNo = "PriorityNo";
        public const string COL_DB_ExpectedDeliveryDate = "ExpectedDeliveryDate";
        public const string COL_DB_Notes = "Notes";

        public const string COL_Subtotal = "subtotal";
        public const string COL_StatusName = "StatusName";
        public const string COL_CustomerPONo = "CustomerPONo";
        public const string COL_POQty = "POQty";
        public const string COL_POPendingQty = "POPendingQty";
        public const string COL_ShippedQty = "ShippedQty";
        public const string COL_BookedQty = "BookedQty";
        public const string COL_RemainingQty = "RemainingQty";
        public const string COL_Customers_Id = "Customers_Id";
        public const string COL_CustomerName = "CustomerName";
        public const string COL_SaleOrders_No = "SaleOrders_No";

        public const string FILTER_Customers_Id = "FILTER_Customers_Id";
        public const string FILTER_StatusCompleted = "FILTER_StatusCompleted";
        public const string FILTER_StatusCancelled = "FILTER_StatusCancelled";
        public const string FILTER_ShowIncompleteOnly = "FILTER_ShowIncompleteOnly";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public SaleOrderItem(Guid id)
        {
            Id = id;
            DataTable dt = get(Id, null, null, false);
            DataRow row = dt.Rows[0];
            SaleOrders_Id = (Guid)row[COL_DB_SaleOrders_Id];
            if (row[COL_DB_Ref_Inventory_Id] != DBNull.Value) Ref_Inventory_Id = (Guid)row[COL_DB_Ref_Inventory_Id];
            PricePerUnit = Convert.ToDecimal(row[COL_DB_PricePerUnit]);
            ProductDescription = row[COL_DB_ProductDescription].ToString();
            Qty = Convert.ToInt16(row[COL_DB_Qty]);
            UnitName = row[COL_DB_UnitName].ToString();
            LineNo = Convert.ToInt16(row[COL_DB_LineNo]);
            PriorityNo = DBUtil.parseData<int>(row, COL_DB_PriorityNo);
            ExpectedDeliveryDate = DBUtil.parseData<DateTime?>(row, COL_DB_ExpectedDeliveryDate);
            Notes = row[COL_DB_Notes].ToString();

            Subtotal = DBUtil.parseData<decimal>(row, COL_Subtotal);
            Status = Util.parseEnum<SaleOrderItemStatus>(DBUtil.parseData<object>(row, COL_DB_Status_enum_id));
            Customers_Id = DBUtil.parseData<Guid>(row, COL_Customers_Id);
            CustomerName = DBUtil.parseData<string>(row, COL_CustomerName);
            SaleOrders_No = Util.wrapNullable<string>(row, COL_SaleOrders_No);
        }

        public SaleOrderItem(Guid id, Guid saleOrders_Id, int lineNo, string productDescription, decimal qty, string unitName, decimal pricePerUnit, string notes, Guid? referencedInventoryID)
        {
            Id = id;
            SaleOrders_Id = saleOrders_Id;
            Ref_Inventory_Id = referencedInventoryID;
            PricePerUnit = pricePerUnit;
            ProductDescription = productDescription;
            Qty = qty;
            UnitName = unitName;
            LineNo = lineNo;
            Notes = notes;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region STATIC DATABASE METHODS

        public static bool add(List<SaleOrderItem> items)
        {
            foreach (SaleOrderItem item in items)
            {
                SqlQueryResult result = DBConnection.query(
                   false,
                   DBConnection.ActiveSqlConnection,
                   QueryTypes.ExecuteNonQuery,
                   "SaleOrderItems_add",
                   new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, item.Id),
                   new SqlQueryParameter(COL_DB_SaleOrders_Id, SqlDbType.UniqueIdentifier, item.SaleOrders_Id),
                   new SqlQueryParameter(COL_DB_Ref_Inventory_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(item.Ref_Inventory_Id)),
                   new SqlQueryParameter(COL_DB_PricePerUnit, SqlDbType.Decimal, item.PricePerUnit),
                   new SqlQueryParameter(COL_DB_ProductDescription, SqlDbType.VarChar, item.ProductDescription),
                   new SqlQueryParameter(COL_DB_Qty, SqlDbType.Decimal, item.Qty),
                   new SqlQueryParameter(COL_DB_UnitName, SqlDbType.VarChar, item.UnitName),
                   new SqlQueryParameter(COL_DB_LineNo, SqlDbType.TinyInt, item.LineNo),
                   new SqlQueryParameter(COL_DB_Status_enum_id, SqlDbType.TinyInt, SaleOrderItemStatus.New),
                   new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(item.Notes))
                );

                if (!result.IsSuccessful)
                    return false;
            }
            return true;
        }

        public static DataTable get(Guid? id, Guid? saleOrders_Id, Guid? Customers_Id, bool showIncompleteOnly)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                true,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "SaleOrderItems_get",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                    new SqlQueryParameter(COL_DB_SaleOrders_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(saleOrders_Id)),
                    new SqlQueryParameter(FILTER_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                    new SqlQueryParameter(FILTER_StatusCompleted, SqlDbType.TinyInt, SaleOrderItemStatus.Completed),
                    new SqlQueryParameter(FILTER_StatusCancelled, SqlDbType.TinyInt, SaleOrderItemStatus.Cancelled),
                    new SqlQueryParameter(FILTER_ShowIncompleteOnly, SqlDbType.Bit, showIncompleteOnly)
                );
            DataTable datatable = result.Datatable;
            Tools.parseEnum<SaleOrderItemStatus>(datatable, COL_StatusName, COL_DB_Status_enum_id);
            return datatable;
        }

        public static void updateQty(Guid id, decimal Qty, decimal PricePerUnit)
        {
            SaleOrderItem objOld = new SaleOrderItem(id);

            string log = "";
            log = Util.appendChange(log, objOld.Qty, Qty, "Qty: '{0:N2}' to '{1:N2}'");
            log = Util.appendChange(log, objOld.PricePerUnit, PricePerUnit, "Price Per Unit: '{0:N2}' to '{1:N2}'");

            if (!string.IsNullOrWhiteSpace(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "SaleOrderItems_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_Qty, SqlDbType.Decimal, Qty),
                    new SqlQueryParameter(COL_DB_PricePerUnit, SqlDbType.Decimal, PricePerUnit)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(id, log);
            }
        }

        #endregion STATIC DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void updateStatus(Guid id, SaleOrderItemStatus statusEnumID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SaleOrderItems_update_Status_enum_id", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Status_enum_id, SqlDbType.TinyInt).Value = statusEnumID;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Status changed to: " + statusEnumID.ToString());
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }
        
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
