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

        public VendorInvoicePaymentItem(Guid? id)
        {
            if (id != null)
            {
                DataRow row = get((Guid)id);
                Id = (Guid)id;
                VendorInvoicePayments_Id = Util.wrapNullable<Guid>(row, COL_DB_VendorInvoicePayments_Id);
                VendorInvoices_Id = Util.wrapNullable<Guid>(row, COL_DB_VendorInvoices_Id);
                Amount = Util.wrapNullable<decimal>(row, COL_DB_Amount);
                Notes = Util.wrapNullable<string>(row, COL_DB_Notes);

                VendorInvoices_No = Util.wrapNullable<string>(row, COL_VendorInvoices_No);
            }
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static void add(Guid VendorInvoicePayments_Id, Dictionary<Guid, decimal> paymentData)
        {
            foreach(KeyValuePair<Guid, decimal> item in paymentData)
            {
                DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.FillByAdapter,
                    "VendorInvoicePaymentItems_add",
                    new SqlQueryParameter(COL_DB_VendorInvoicePayments_Id, SqlDbType.UniqueIdentifier, VendorInvoicePayments_Id),
                    new SqlQueryParameter(COL_DB_VendorInvoices_Id, SqlDbType.UniqueIdentifier, item.Key),
                    new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, item.Value)
                );
            }
        }

        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, null)); }
        public static DataTable get(Guid? Id, Guid? VendorInvoicePayments_Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorInvoicePaymentItems_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_VendorInvoicePayments_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(VendorInvoicePayments_Id))
                );
            return result.Datatable;
        }

        public static bool update(Guid Id, string Notes)
        {
            VendorInvoicePaymentItem objOld = new VendorInvoicePaymentItem(Id);
            string log = "";
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (string.IsNullOrEmpty(log))
                return Util.displayMessageBoxError("No changes to record");
            else
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "VendorInvoicePaymentItems_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                return result.IsSuccessful;
            }
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
