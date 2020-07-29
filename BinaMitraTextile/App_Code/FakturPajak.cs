using System;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile
{
    public class FakturPajak
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public string No;
        public DateTime Timestamp;
        public Guid? Customers_Id;
        public Guid? Vendors_Id;
        public decimal DPP;
        public decimal PPN;
        public string Notes = "";
        public Guid? Kontrabons_Id;

        public string Customers_Name;
        public string Vendors_Name;
        public string Kontrabons_No;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_No = "No";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_Customers_Id = "Customers_Id";
        public const string COL_DB_Vendors_Id = "Vendors_Id";
        public const string COL_DB_DPP = "DPP";
        public const string COL_DB_PPN = "PPN";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Completed = "Completed";
        public const string COL_DB_Kontrabons_Id = "Kontrabons_Id";

        public const string COL_Customers_Name = "Customers_Name";
        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_TotalAmount = "TotalAmount";
        public const string COL_AssignedAmount = "AssignedAmount";
        public const string COL_AmountDifference = "AmountDifference";
        public const string COL_Kontrabons_No = "Kontrabons_No";

        public const string FILTER_StartDate = "FILTER_StartDate";
        public const string FILTER_EndDate = "FILTER_EndDate";
        public const string FILTER_ShowCompleted = "FILTER_ShowCompleted";
        public const string FILTER_ShowOnlyReminder = "FILTER_ShowOnlyReminder";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public FakturPajak(Guid? id)
        {
            if(id != null)
            {
                Id = (Guid)id;
                DataRow row = get(Id);
                No = Util.wrapNullable<string>(row, COL_DB_No);
                Timestamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
                Customers_Id = Util.wrapNullable<Guid?>(row, COL_DB_Customers_Id);
                Vendors_Id = Util.wrapNullable<Guid?>(row, COL_DB_Vendors_Id);
                DPP = Util.wrapNullable<decimal>(row, COL_DB_DPP);
                PPN = Util.wrapNullable<decimal>(row, COL_DB_PPN);
                Notes = Util.wrapNullable<string>(row, COL_DB_Notes);
                Kontrabons_Id = DBUtil.parseData<Guid?>(row, COL_DB_Kontrabons_Id);

                Customers_Name = Util.wrapNullable<string>(row, COL_Customers_Name);
                Vendors_Name = Util.wrapNullable<string>(row, COL_Vendors_Name);
                Kontrabons_No = DBUtil.parseData<string>(row, COL_Kontrabons_No);
            }
        }

        public FakturPajak() { }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static Guid add(DateTime Timestamp, Guid? Customers_Id, Guid? Vendors_Id, string No, decimal DPP, decimal PPN, string Notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "FakturPajaks_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Util.getAsStartDate(Timestamp)),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No),
                new SqlQueryParameter(COL_DB_DPP, SqlDbType.Decimal, DPP),
                new SqlQueryParameter(COL_DB_PPN, SqlDbType.Decimal, PPN),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, "Added");

            return Id;
        }

        public static DataTable get_by_Kontrabons_Id(Guid Kontrabons_Id) { return get(null, null, null, null, null, null, false, false, Kontrabons_Id); }
        public static DataTable get_Reminder() { return get(null, null, null, null, null, null, false, true, null); }
        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, null, null, null, null, null, false, false, null)); }
        public static DataTable get() { return get(null, null, null, null, null, null, false, false, null); }
        public static DataTable get(string No, Guid? Customers_Id, Guid? Vendors_Id, DateTime? StartDate, DateTime? EndDate, bool showCompleted)
        { return get(null, No, Customers_Id, Vendors_Id, StartDate, EndDate, showCompleted, false, null); }
        public static DataTable get(Guid? Id, string No, Guid? Customers_Id, Guid? Vendors_Id, DateTime? StartDate, DateTime? EndDate, bool showCompleted, bool showOnlyReminder, Guid? Kontrabons_Id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "FakturPajaks_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, Util.wrapNullable(No)),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Kontrabons_Id)),
                new SqlQueryParameter(FILTER_StartDate, SqlDbType.DateTime, Util.wrapNullable(StartDate)),
                new SqlQueryParameter(FILTER_EndDate, SqlDbType.DateTime, Util.wrapNullable(EndDate)),
                new SqlQueryParameter(FILTER_ShowCompleted, SqlDbType.Bit, showCompleted),
                new SqlQueryParameter(FILTER_ShowOnlyReminder, SqlDbType.Bit, showOnlyReminder)
                );
            return result.Datatable;
        }

        public static void updateCompleted(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "FakturPajaks_update_Completed",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Completed, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Completed changed to: {0}", Value));
        }

        public static bool update(Guid Id, DateTime Timestamp, Guid? Customers_Id, Guid? Vendors_Id, string No, decimal DPP, decimal PPN, string Notes)
        {
            FakturPajak objOld = new FakturPajak(Id);
            string log = "";
            log = Util.appendChange(log, objOld.No, No, "No: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Timestamp, Timestamp, "Date: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.DPP, DPP, "DPP: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.PPN, PPN, "PPN: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            string newCustomerName = new Customer(Customers_Id).Name;
            if (objOld.Customers_Name != newCustomerName)
            {
                log = Util.appendChange(log, objOld.Customers_Name, newCustomerName, "Customer: '{0}' to '{1}'");
                if (!Util.displayMessageBoxYesNo("Sale Invoices and Returns will be removed because customer is changed"))
                    return false;
            }

            string newVendorName = new Vendor(Vendors_Id).Name;
            if (objOld.Vendors_Name != newVendorName)
            {
                log = Util.appendChange(log, objOld.Vendors_Name, newVendorName, "Vendor: '{0}' to '{1}'");
                if (!Util.displayMessageBoxYesNo("Vendor Invoices and Returns will be removed because vendor is changed"))
                    return false;
            }

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "FakturPajaks_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Timestamp),
                    new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                    new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                    new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No),
                    new SqlQueryParameter(COL_DB_DPP, SqlDbType.Decimal, DPP),
                    new SqlQueryParameter(COL_DB_PPN, SqlDbType.Decimal, PPN),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                return result.IsSuccessful;
            }

            return true;
        }

        public static bool isNoExist(Guid? Id, string No)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "FakturPajaks_isExist_No",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No)
                );
            return result.ValueBoolean;
        }

        public static void update_Kontrabons_Id(Guid Id, Guid? Kontrabons_Id)
        {
            FakturPajak objOld = new FakturPajak(Id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.Kontrabons_No, new Kontrabon(Kontrabons_Id).No, "Kontrabon: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "FakturPajaks_update_Kontrabons_Id",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Kontrabons_Id))
                );

                if (result.IsSuccessful)
                {
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                    //update faktur pajak log
                    if (Kontrabons_Id == null)
                        ActivityLog.submit((Guid)objOld.Kontrabons_Id, String.Format("Removed FP: {0}", objOld.No));
                    else
                        ActivityLog.submit((Guid)Kontrabons_Id, String.Format("Added FP: {0}", objOld.No));

                    //remove sale invoices
                    DataTable saleInvoices = Sale.get_by_FakturPajaks_Id(Id);
                    foreach (DataRow row in saleInvoices.Rows)
                        Sale.update_Kontrabons_Id(Util.wrapNullable<Guid>(row, Sale.COL_ID), Kontrabons_Id);

                    //remove sale returns
                    DataTable saleReturns = SaleReturn.get_by_FakturPajaks_Id(Id);
                    foreach (DataRow row in saleReturns.Rows)
                        SaleReturn.update_Kontrabons_Id(Util.wrapNullable<Guid>(row, SaleReturn.COL_ID), Kontrabons_Id);
                }
            }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

