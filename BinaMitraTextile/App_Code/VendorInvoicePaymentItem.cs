using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class VendorInvoicePaymentItem
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public Guid VendorInvoicePayments_Id;
        public Guid VendorInvoices_Id;
        public decimal Amount;
        public string Notes;

        public string VendorInvoices_No;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_VendorInvoicePayments_Id = "VendorInvoicePayments_Id";
        public const string COL_DB_VendorInvoices_Id = "VendorInvoices_Id";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_Notes = "Notes";

        public const string COL_VendorInvoices_No = "VendorInvoices_No";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static void add(Guid VendorInvoicePayments_Id, Dictionary<Guid, decimal> paymentData)
        {
            foreach(KeyValuePair<Guid, decimal> item in paymentData)
            {
                DBConnection.query(
                    false,
                    DBUtil.ActiveSqlConnection,
                    QueryTypes.FillByAdapter,
                    "VendorInvoicePaymentItems_add",
                    new SqlQueryParameter(COL_DB_VendorInvoicePayments_Id, SqlDbType.UniqueIdentifier, VendorInvoicePayments_Id),
                    new SqlQueryParameter(COL_DB_VendorInvoices_Id, SqlDbType.UniqueIdentifier, item.Key),
                    new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, item.Value)
                );
            }
        }

        public static DataTable get(Guid? Id, Guid? VendorInvoicePayments_Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorInvoicePaymentItems_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_VendorInvoicePayments_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(VendorInvoicePayments_Id))
                );
            return result.Datatable;
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
