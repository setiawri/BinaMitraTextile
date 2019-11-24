using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile
{
    public class SaleOrder
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES

        public Guid Id;
        public DateTime Timestamp;
        public Guid Customers_Id;
        public string CustomerInfo;
        public string CustomerPONo;
        public DateTime TargetDate;
        public string Notes;

        public decimal Amount;
        public string Customers_Name;

        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES        
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_Customers_Id = "Customers_Id";
        public const string COL_DB_CustomerInfo = "CustomerInfo";
        public const string COL_DB_CustomerPONo = "CustomerPONo";
        public const string COL_DB_TargetDate = "TargetDate";
        public const string COL_DB_Notes = "Notes";

        public const string COL_Amount = "Amount"; 
        public const string COL_Customers_Name = "Customers_customer_name";

        public const string FILTER_DateStart = "FILTER_DateStart";
        public const string FILTER_DateEnd = "FILTER_DateEnd";
        public const string FILTER_StatusCompleted = "FILTER_StatusCompleted";
        public const string FILTER_StatusCancelled = "FILTER_StatusCancelled";
        public const string FILTER_ShowIncompleteOnly = "FILTER_ShowIncompleteOnly";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public SaleOrder(Guid id)
        {
            Id = id;
            DataRow row = get(Id).Rows[0];
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_Timestamp);
            Customers_Id = DBUtil.parseData<Guid>(row, COL_DB_Customers_Id);
            CustomerInfo = DBUtil.parseData<string>(row, COL_DB_CustomerInfo);
            TargetDate = DBUtil.parseData<DateTime>(row, COL_DB_TargetDate);
            CustomerPONo = DBUtil.parseData<string>(row, COL_DB_CustomerPONo);
            Notes = DBUtil.parseData<string>(row, COL_DB_Notes);

            Amount = DBUtil.parseData<decimal>(row, COL_Amount);
            Customers_Name = DBUtil.parseData<string>(row, COL_Customers_Name);
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS
            
        public static DataTable get(Guid id)
        {
            return get(id, null, null,null,null,false);
        }

        public static DataTable get(Guid? id, Guid? Customers_Id, string customerPONo, DateTime? dateStart, DateTime? dateEnd, bool showIncompleteOnly)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "SaleOrders_get",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                    new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                    new SqlQueryParameter(COL_DB_CustomerPONo, SqlDbType.VarChar, customerPONo),
                    new SqlQueryParameter(FILTER_DateStart, SqlDbType.DateTime, dateStart),
                    new SqlQueryParameter(FILTER_DateEnd, SqlDbType.DateTime, dateEnd),
                    new SqlQueryParameter(FILTER_StatusCompleted, SqlDbType.TinyInt, SaleOrderItemStatus.Completed),
                    new SqlQueryParameter(FILTER_StatusCancelled, SqlDbType.TinyInt, SaleOrderItemStatus.Cancelled),
                    new SqlQueryParameter(FILTER_ShowIncompleteOnly, SqlDbType.Bit, showIncompleteOnly)
                );
            return result.Datatable;
        }
        
        public static bool add(Guid id, Guid customerId, string customerInfo, List<SaleOrderItem> items, string notes, DateTime targetDate, string customerPONo)
        {
            bool isSuccess = false;
                SqlQueryResult result = DBConnection.query(
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "SaleOrders_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, customerId),
                new SqlQueryParameter(COL_DB_CustomerInfo, SqlDbType.VarChar, customerInfo),
                new SqlQueryParameter(COL_DB_TargetDate, SqlDbType.DateTime, targetDate),
                new SqlQueryParameter(COL_DB_CustomerPONo, SqlDbType.VarChar, customerPONo),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(notes))
            );

            if (result.IsSuccessful)
            {
                //ActivityLog.submit(id, "Added");

                //submit items
                if(SaleOrderItem.add(items))
                    isSuccess = true;
            }

            return isSuccess;
        }

        public static void updateTargetDate(Guid id, DateTime value)
        {
            SqlQueryResult result = DBConnection.query(
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "SaleOrders_update_TargetDate",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_TargetDate, SqlDbType.DateTime, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Due date updated to: " + value.ToString("dd/MM/yy"));
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
