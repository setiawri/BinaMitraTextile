using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{

    public struct FinancialOverview 
    {
        public decimal InventoryBuyValue;
        public decimal ReceivableAmount;
    }

    class Financial
    {
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_INVENTORYBUYVALUE = "inventory_buy_value";
        public const string COL_RECEIVABLEAMOUNT = "receivable_amount";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES
        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS
        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static FinancialOverview getOverview()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("financial_get_overview", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return new FinancialOverview() {
                InventoryBuyValue = Convert.ToDecimal(dataTable.Rows[0][COL_INVENTORYBUYVALUE]),
                ReceivableAmount = Convert.ToDecimal(dataTable.Rows[0][COL_RECEIVABLEAMOUNT])
            };
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
