using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using LIBUtil;

namespace BinaMitraTextile
{
    public enum POItemStatus
    {
        New,
        Sent,
        Cancelled,
        [Description("Received Partial")]
        ReceivedPartial,
        Completed,
        [Description("In Planning")]
        InPlanning,
        [Description("In Production")]
        InProduction,
        [Description("Perbaikan")]
        Reprocessing,
        Pending,
        [Description("Celup Ulang")]
        Reproduce
    };

    public class POItem
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES

        public Guid ID;
        public Guid POID;
        public int LineNo;
        public string ProductDescription;
        public decimal Qty;
        public string UnitName;
        public decimal PricePerUnit;
        public string Notes = null;
        public Guid? ReferencedInventoryID = null;
        public DateTime Timestamp;
        public POItemStatus Status;
        public string PONo;
        public int Age;
        public decimal PendingQty;
        public decimal PendingQtyValue;
        public int PriorityNo;
        public int PriorityQty;
        public DateTime? ExpectedDeliveryDate;
        public int? ExpectedDeliveryDayCount;

        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_ID = "id";
        public const string COL_DB_POID = "po_id";
        public const string COL_DB_LINENO = "line_no";
        public const string COL_DB_PRODUCTDESCRIPTION = "product_description";
        public const string COL_DB_QTY = "qty";
        public const string COL_DB_UNITNAME = "unit_name";
        public const string COL_DB_PRICEPERUNIT = "price_per_unit";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_REFERENCEDINVENTORYID = "referenced_inventory_id";
        public const string COL_DB_STATUSENUMID = "status_enum_id";
        public const string COL_DB_PriorityNo = "PriorityNo";
        public const string COL_DB_PriorityQty = "PriorityQty";
        public const string COL_DB_ExpectedDeliveryDate = "ExpectedDeliveryDate";
        public const string COL_DB_SaleOrderItems_Id = "SaleOrderItems_Id";

        public const string COL_SUBTOTAL = "subtotal";
        public const string COL_RECEIVEDQTY = "received_qty";
        public const string COL_TIMESTAMP = "timestamp";
        public const string COL_STATUSNAME = "status_name";
        public const string COL_PONO = "po_no";
        public const string COL_DB_ExpectedDeliveryDayCount = "ExpectedDeliveryDayCount";
        public const string COL_SaleOrderItems_CustomerPONo = "CustomerPONo";
        public const string COL_SaleOrderItems_Customers_Name = "Customers_Name";

        public const string COL_PENDINGQTY = "pendingqty";
        public const string COL_PENDINGQTYVALUE = "pendingqtyvalue";
        public const string COL_AGE = "age";

        public const string FILTER_SaleOrderItems_Id = "FILTER_SaleOrderItems_Id";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public POItem(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            POID = (Guid)dt.Rows[0][COL_DB_POID];
            LineNo = Convert.ToInt16(dt.Rows[0][COL_DB_LINENO]);
            ProductDescription = dt.Rows[0][COL_DB_PRODUCTDESCRIPTION].ToString();
            Qty = Convert.ToInt16(dt.Rows[0][COL_DB_QTY]);
            UnitName = dt.Rows[0][COL_DB_UNITNAME].ToString(); 
            Notes = dt.Rows[0][COL_DB_NOTES].ToString();
            PricePerUnit = Convert.ToDecimal(dt.Rows[0][COL_DB_PRICEPERUNIT]);
            if(dt.Rows[0][COL_DB_REFERENCEDINVENTORYID] != DBNull.Value) ReferencedInventoryID = (Guid)dt.Rows[0][COL_DB_REFERENCEDINVENTORYID];
            Timestamp = DBUtil.parseData<DateTime>(dt.Rows[0], COL_TIMESTAMP);
            ExpectedDeliveryDate = DBUtil.parseData<DateTime?>(dt.Rows[0], COL_DB_ExpectedDeliveryDate);
            ExpectedDeliveryDayCount = DBUtil.parseData<int?>(dt.Rows[0], COL_DB_ExpectedDeliveryDayCount);
            Status = Tools.parseEnum<POItemStatus>(DBUtil.parseData<Int16>(dt.Rows[0], COL_DB_STATUSENUMID));
            PONo = DBUtil.parseData<string>(dt.Rows[0], COL_PONO);
            PendingQty = DBUtil.parseData<decimal>(dt.Rows[0], COL_PENDINGQTY);
            PendingQtyValue = DBUtil.parseData<decimal>(dt.Rows[0], COL_PENDINGQTYVALUE);
            PriorityNo = DBUtil.parseData<int>(dt.Rows[0], COL_DB_PriorityNo);
            PriorityQty = DBUtil.parseData<int>(dt.Rows[0], COL_DB_PriorityQty);
        }

        public POItem(Guid id, Guid poID, int lineNo, string productDescription, decimal qty, string unitName, decimal pricePerUnit, string notes, Guid? referencedInventoryID)
        {
            ID = id;
            POID = poID;
            LineNo = lineNo;
            ProductDescription = productDescription;
            Qty = qty;
            UnitName = unitName;
            Notes = notes;
            PricePerUnit = pricePerUnit;
            ReferencedInventoryID = referencedInventoryID;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region NON-STATIC DATABASE METHODS

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region STATIC DATABASE METHODS

        public static void submitItems(List<POItem> items)
        {
            foreach (POItem item in items)
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "poitem_new",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, item.ID),
                    new SqlQueryParameter(COL_DB_POID, SqlDbType.UniqueIdentifier, item.POID),
                    new SqlQueryParameter(COL_DB_LINENO, SqlDbType.TinyInt, item.LineNo),
                    new SqlQueryParameter(COL_DB_PRODUCTDESCRIPTION, SqlDbType.VarChar, item.ProductDescription),
                    new SqlQueryParameter(COL_DB_QTY, SqlDbType.Decimal, item.Qty),
                    new SqlQueryParameter(COL_DB_UNITNAME, SqlDbType.VarChar, item.UnitName),
                    new SqlQueryParameter(COL_DB_PRICEPERUNIT, SqlDbType.Decimal, item.PricePerUnit),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(item.Notes)),
                    new SqlQueryParameter(COL_DB_REFERENCEDINVENTORYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(item.ReferencedInventoryID)),
                    new SqlQueryParameter(COL_DB_STATUSENUMID, SqlDbType.TinyInt, POItemStatus.New)
                );
            }
        }

        public static DataTable getItems(Guid POID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "poitem_get_by_poid",
                    new SqlQueryParameter(COL_DB_POID, SqlDbType.UniqueIdentifier, POID),
                    new SqlQueryParameter("status_completed", SqlDbType.TinyInt, POItemStatus.Completed),
                    new SqlQueryParameter("status_cancelled", SqlDbType.TinyInt, POItemStatus.Cancelled)
            );
            return Tools.parseEnum<POItemStatus>(result.Datatable, COL_STATUSNAME, COL_DB_STATUSENUMID);
        }

        public static DataTable getIncompleteItems()
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "poitem_get_incomplete",
                new SqlQueryParameter("status_completed", SqlDbType.TinyInt, POItemStatus.Completed),
                new SqlQueryParameter("status_cancelled", SqlDbType.TinyInt, POItemStatus.Cancelled)
            );
            return Tools.parseEnum<POItemStatus>(result.Datatable, COL_STATUSNAME, COL_DB_STATUSENUMID);
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("poitem_get_byID", ID);
        }

        public static bool updateSaleOrderItem(Guid id, Guid? SaleOrderItems_Id, string description)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "poitem_update_SaleOrderItems_Id",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(SaleOrderItems_Id))
            );

            if (!result.IsSuccessful)
                return false;
            else if (SaleOrderItems_Id == null)
                ActivityLog.submit(id, "Sale Order Item removed");
            else
                ActivityLog.submit(id, "Sale Order Item Updated to: " + description);
            
            return true;
        }

        public static DataTable get_by_SaleOrderItems_Id(Guid? saleOrderItems_Id)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "poitem_get_by_SaleOrderItems_Id",
                    new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(saleOrderItems_Id))
                );
            return result.Datatable;
        }

        #endregion STATIC DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void updateStatus(Guid id, POItemStatus statusEnumID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("poitem_update_status", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STATUSENUMID, SqlDbType.TinyInt).Value = statusEnumID;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Status changed to: " + statusEnumID.ToString());
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid userAccountID, Guid id, int priorityNo, int priorityQty, DateTime? expectedDeliveryDate)
        {
            POItem objOld = new POItem(id);

            //generate log description
            string log = "";
            log = ActivityLog.appendChange(log, objOld.ExpectedDeliveryDate, expectedDeliveryDate, "Expected Delivery: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.PriorityNo, priorityNo, "Priority No: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.PriorityQty, priorityQty, "Priority Qty: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "poitem_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_PriorityNo, SqlDbType.SmallInt, Util.wrapNullable(priorityNo)),
                    new SqlQueryParameter(COL_DB_PriorityQty, SqlDbType.Int, Util.wrapNullable(priorityQty)),
                    new SqlQueryParameter(COL_DB_ExpectedDeliveryDate, SqlDbType.Date, Util.wrapNullable(expectedDeliveryDate))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(id, log);
            }
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
