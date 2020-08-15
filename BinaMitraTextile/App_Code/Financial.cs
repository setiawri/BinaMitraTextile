﻿using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

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
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "financial_get_overview"
            );            
            DataRow row = Util.getFirstRow(result.Datatable);

            return new FinancialOverview()
            {
                InventoryBuyValue = Util.wrapNullable<decimal>(row, COL_INVENTORYBUYVALUE),
                ReceivableAmount = Util.wrapNullable<decimal>(row, COL_RECEIVABLEAMOUNT)
            };
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
