﻿using System;
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

        public string Customers_Name;
        public string Vendors_Name;

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

        public const string COL_Customers_Name = "Customers_Name";
        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_TotalAmount = "TotalAmount";
        public const string COL_AssignedAmount = "AssignedAmount";
        public const string COL_AmountDifference = "AmountDifference";

        public const string FILTER_StartDate = "FILTER_StartDate";
        public const string FILTER_EndDate = "FILTER_EndDate";
        public const string FILTER_ShowCompleted = "FILTER_ShowCompleted";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public FakturPajak(Guid? id)
        {
            if(id != null)
            {
                Id = (Guid)id;
                DataRow row = Util.getFirstRow(get(Id, null, null, null, null, null, false));
                No = Util.wrapNullable<string>(row, COL_DB_No);
                Timestamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
                Customers_Id = Util.wrapNullable<Guid?>(row, COL_DB_Customers_Id);
                Vendors_Id = Util.wrapNullable<Guid?>(row, COL_DB_Vendors_Id);
                DPP = Util.wrapNullable<decimal>(row, COL_DB_DPP);
                PPN = Util.wrapNullable<decimal>(row, COL_DB_PPN);
                Notes = Util.wrapNullable<string>(row, COL_DB_Notes);

                Customers_Name = Util.wrapNullable<string>(row, COL_Customers_Name);
                Vendors_Name = Util.wrapNullable<string>(row, COL_Vendors_Name);
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
                DBUtil.ActiveSqlConnection,
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

        public static DataTable get(Guid? Id, string No, Guid? Customers_Id, Guid? Vendors_Id, DateTime? StartDate, DateTime? EndDate, bool showCompleted)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "FakturPajaks_get",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(COL_DB_No, SqlDbType.VarChar, Util.wrapNullable(No)),
                new SqlQueryParameter(COL_DB_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(FILTER_StartDate, SqlDbType.DateTime, Util.wrapNullable(StartDate)),
                new SqlQueryParameter(FILTER_EndDate, SqlDbType.DateTime, Util.wrapNullable(EndDate)),
                new SqlQueryParameter(FILTER_ShowCompleted, SqlDbType.Bit, showCompleted)
                );
            return result.Datatable;
        }

        public static void updateCompleted(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "FakturPajaks_update_Completed",
                new SqlQueryParameter(COL_DB_Id, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_Completed, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Completed changed to: {0}", Value));
        }

        public static void update(Guid Id, DateTime Timestamp, Guid? Customers_Id, Guid? Vendors_Id, string No, decimal DPP, decimal PPN, string Notes)
        {
            FakturPajak objOld = new FakturPajak(Id);
            string log = "";
            log = Util.appendChange(log, objOld.No, No, "No: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Timestamp, Timestamp, "Date: '{0:dd/MM/yy}' to '{1:dd/MM/yy}'");
            log = Util.appendChange(log, objOld.Customers_Name, new Customer(Customers_Id).Name, "Customer: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Vendors_Name, new Vendor(Vendors_Id).Name, "Vendor: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.DPP, DPP, "DPP: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.PPN, PPN, "PPN: '{0}' to '{1}'");
            log = Util.appendChange(log, objOld.Notes, Notes, "Notes: '{0}' to '{1}'");

            if (string.IsNullOrEmpty(log))
                Util.displayMessageBoxError("No changes to record");
            else
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBUtil.ActiveSqlConnection,
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

                //notify supervisor role
                //if (new UserAccount(userAccountID).UserRole != UserAccountRoles.Supervisor)
                //  add row to Notifications table
            }
        }

        public static bool isNoExist(Guid? Id, string No)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "FakturPajaks_isExist_No",
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
