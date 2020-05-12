using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class VendorInvoicePayment
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public DateTime Timestamp;
        public string No;
        public Guid? Vendors_Id;
        public bool Cancelled;
        public bool Approved;
        public string Notes;

        public string VendorName;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_No = "No";
        public const string COL_DB_Vendors_Id = "Vendors_Id";
        public const string COL_DB_Cancelled = "Cancelled";
        public const string COL_DB_Approved = "Approved";
        public const string COL_DB_Notes = "Notes";

        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_Amount = "Amount";

        public const string FILTER_VendorInvoices_No = "FILTER_VendorInvoices_No";
        public const string FILTER_ShowOnlyLast3Months = "FILTER_ShowOnlyLast3Months";
        public const string FILTER_ShowOnlyUnapproved = "FILTER_ShowOnlyUnapproved";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public VendorInvoicePayment(Guid? id)
        {
            if(id != null)
            {
                DataRow row = get((Guid)id);
                Id = Util.wrapNullable<Guid>(row, COL_DB_Id);
                Timestamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
                No = Util.wrapNullable<string>(row, COL_DB_No);
                Vendors_Id = Util.wrapNullable<Guid>(row, COL_DB_Vendors_Id);
                Cancelled = Util.wrapNullable<bool>(row, COL_DB_Cancelled);
                Approved = Util.wrapNullable<bool>(row, COL_DB_Approved);
                Notes = Util.wrapNullable<string>(row, COL_DB_Notes);

                VendorName = Util.wrapNullable<string>(row, COL_Vendors_Name);
            }
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static Guid add(DateTime Timestamp, Guid Vendors_Id, string Notes, Dictionary<Guid, decimal> paymentData)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoicePayments_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Util.getAsStartDate(Timestamp)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
            );

            if (result.IsSuccessful)
            {
                ActivityLog.submit(Id, "Created");
                VendorInvoicePaymentItem.add(Id, paymentData);
            }

            return Id;
        }

        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, null, null, false, false)); }

        public static DataTable get(Guid? Id, string No, string VendorInvoices_No, bool showOnlyLast3Months, bool showOnlyUnapproved)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "VendorInvoicePayments_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, Util.wrapNullable(No)),
                new SqlQueryParameter(FILTER_VendorInvoices_No, SqlDbType.VarChar, Util.wrapNullable(VendorInvoices_No)),
                new SqlQueryParameter(FILTER_ShowOnlyLast3Months, SqlDbType.Bit, showOnlyLast3Months),
                new SqlQueryParameter(FILTER_ShowOnlyUnapproved, SqlDbType.Bit, showOnlyUnapproved)
                );
            return result.Datatable;
        }

        public static bool update(Guid Id, DateTime Timestamp, string Notes)
        {
            VendorInvoicePayment objOld = new VendorInvoicePayment(Id);
            string log = "";
            log = Util.appendChange(log, objOld.Timestamp, Timestamp, "Date: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if(string.IsNullOrEmpty(log))
                return Util.displayMessageBoxError("No changes to record");
            else
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBUtil.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "VendorInvoicePayments_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Timestamp),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                return result.IsSuccessful;
            }
        }

        public static void update_Approved(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoicePayments_update_Approved",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Approved changed to: {0}", Value));
        }

        public static void update_Cancelled(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "VendorInvoicePayments_update_Cancelled",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Cancelled changed to: {0}", Value));
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
