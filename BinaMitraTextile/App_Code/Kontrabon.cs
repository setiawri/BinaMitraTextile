using System;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile
{
    public class Kontrabon
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid Id;
        public string No;
        public DateTime Timestamp;
        public Guid? Customers_Id;
        public decimal Amount;
        public DateTime? ReturnDate;
        public bool Approved;
        public string Notes = "";

        public string Customers_Name;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_No = "No";
        public const string COL_DB_Timestamp = "Timestamp";
        public const string COL_DB_Customers_Id = "Customers_Id";
        public const string COL_DB_Amount = "Amount";
        public const string COL_DB_ReturnDate = "ReturnDate";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Approved = "Approved";

        public const string COL_Customers_Name = "Customers_Name";
        public const string COL_AssignedAmount = "AssignedAmount";
        public const string COL_AmountDifference = "AmountDifference";

        public const string FILTER_StartDate = "FILTER_StartDate";
        public const string FILTER_EndDate = "FILTER_EndDate";
        public const string FILTER_ShowOnlyApproved = "FILTER_ShowOnlyApproved";
        public const string FILTER_ShowOnlyReminder = "FILTER_ShowOnlyReminder";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Kontrabon(Guid? id)
        {
            if(id != null)
            {
                Id = (Guid)id;
                DataRow row = get(Id);
                No = Util.wrapNullable<string>(row, COL_DB_No);
                Timestamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
                Customers_Id = Util.wrapNullable<Guid?>(row, COL_DB_Customers_Id);
                Amount = Util.wrapNullable<decimal>(row, COL_DB_Amount);
                ReturnDate = Util.wrapNullable<DateTime?>(row, COL_DB_ReturnDate);
                Approved = Util.wrapNullable<bool>(row, COL_DB_Approved);
                Notes = Util.wrapNullable<string>(row, COL_DB_Notes);

                Customers_Name = Util.wrapNullable<string>(row, COL_Customers_Name);
            }
        }

        public Kontrabon() { }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public static Guid add(DateTime Timestamp, Guid Customers_Id, string No, decimal Amount, DateTime? ReturnDate, string Notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Kontrabons_add",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Util.getAsStartDate(Timestamp)),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Customers_Id),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No),
                new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, Amount),
                new SqlQueryParameter(COL_DB_ReturnDate, SqlDbType.DateTime, Util.wrapNullable(Util.getAsStartDate(ReturnDate))),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.NVarChar, Util.wrapNullable(Notes))
            );

            if (result.IsSuccessful)
                ActivityLog.submitCreate(Id);

            return Id;
        }

        public static DataTable get_Reminder()
        {
            return get(null, null, null, null, null, false, true);
        }
        public static DataRow get(Guid Id)
        {
            return Util.getFirstRow(get(Id, null, null, null, null, false, false));
        }
        public static DataTable get()
        {
            return get(null, null, null, null, null, false, false);
        }
        public static DataTable get(Guid? Id, string No, Guid? Customers_Id, DateTime? StartDate, DateTime? EndDate, bool showOnlyApproved, bool showOnlyReminder)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Kontrabons_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, Util.wrapNullable(No)),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                new SqlQueryParameter(FILTER_StartDate, SqlDbType.DateTime, Util.wrapNullable(StartDate)),
                new SqlQueryParameter(FILTER_EndDate, SqlDbType.DateTime, Util.wrapNullable(EndDate)),
                new SqlQueryParameter(FILTER_ShowOnlyApproved, SqlDbType.Bit, showOnlyApproved),
                new SqlQueryParameter(FILTER_ShowOnlyReminder, SqlDbType.Bit, showOnlyReminder)
                );
            return result.Datatable;
        }

        public static void update_Approved(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "Kontrabons_update_Approved",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Approved, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Approved changed to: {0}", Value));
        }

        public static bool update(Guid Id, DateTime Timestamp, Guid Customers_Id, string No, decimal Amount, DateTime? ReturnDate, string Notes)
        {
            Kontrabon objOld = new Kontrabon(Id);
            string log = "";
            log = Util.appendChange(log, objOld.No, No, "No: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Timestamp, Timestamp, "Date: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.Amount, Amount, "Amount: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.ReturnDate, ReturnDate, "Return Date: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            string newCustomerName = new Customer(Customers_Id).Name;
            if (objOld.Customers_Name != newCustomerName)
            {
                log = Util.appendChange(log, objOld.Customers_Name, newCustomerName, "Customer: '{0}' to '{1}'");
                if (!Util.displayMessageBoxYesNo("Sale Invoices and Returns will be removed because customer is changed"))
                    return false;
            }

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "Kontrabons_update",
                    new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, Timestamp),
                    new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Customers_Id),
                    new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No),
                    new SqlQueryParameter(COL_DB_Amount, SqlDbType.Decimal, Amount),
                    new SqlQueryParameter(COL_DB_ReturnDate, SqlDbType.DateTime, Util.wrapNullable(Util.getAsStartDate(ReturnDate))),
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
                "Kontrabons_isExist_No",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, No)
                );
            return result.ValueBoolean;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

