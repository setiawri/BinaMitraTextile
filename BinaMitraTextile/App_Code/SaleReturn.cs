using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class SaleReturn
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public const string COL_ID = "id";
        public const string COL_BARCODE = "barcode";
        public const string COL_HEXBARCODE = "hexbarcode";
        public const string COL_PRICEPERUNIT = "price_per_unit";
        public const string COL_INVENTORYCODE = "inventory_code";
        public const string COL_Checked = "Checked";
        public const string COL_DB_FakturPajaks_Id = "FakturPajaks_Id";
        public const string COL_DB_Kontrabons_Id = "Kontrabons_Id";
        public const string COL_DB_Timestamp = "time_stamp";
        public const string COL_DB_Users_Id = "user_id";
        public const string COL_DB_Notes = "notes";

        public const string COL_FakturPajaks_No = "FakturPajaks_No";
        public const string COL_Kontrabons_No = "Kontrabons_No";
        public const string COL_RETURNAMOUNT = "sale_amount";
        public const string COL_SaleQty = "sale_qty";
        public const string COL_SaleLength = "sale_length";
        public const string COL_Customers_Id = "customer_id";
        public const string COL_Customers_Name = "customer_name";
        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_SALESMANID = "salesman_id";
        public const string COL_SALESMANNAME = "salesman_name";

        public const string FILTER_BrowsingForFakturPajak_Customers_Id = "FILTER_BrowsingForFakturPajak_Customers_Id";
        public const string FILTER_ShowOnlyReminder = "FILTER_ShowOnlyReminder";

        public Guid id;
        public DateTime time_stamp;
        public bool voided;
        public Guid user_id;
        public Guid customer_id;
        public string notes = "";
        public string barcode = "";
        private DataTable saleReturnItems;
        public string customer_info = "";
        public Guid? FakturPajaks_Id;
        public Guid? Kontrabons_Id;

        public string FakturPajaks_No;
        public string Kontrabons_No;
        public decimal ReturnAmount = 0;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public SaleReturn(Guid ID)
        {
            id = ID;
            DataRow row = get(ID);
            time_stamp = Util.wrapNullable<DateTime>(row, COL_DB_Timestamp);
            voided = Util.wrapNullable<bool>(row, "voided");
            user_id = Util.wrapNullable<Guid>(row, COL_DB_Users_Id);
            customer_id = Util.wrapNullable<Guid>(row, COL_Customers_Id);
            notes = Util.wrapNullable<string>(row, COL_DB_Notes);
            customer_info = Util.wrapNullable<string>(row, "customer_info");
            barcode = Util.wrapNullable<string>(row, "barcode");
            FakturPajaks_Id = Util.wrapNullable<Guid?>(row, COL_DB_FakturPajaks_Id);
            Kontrabons_Id = Util.wrapNullable<Guid?>(row, COL_DB_Kontrabons_Id);

            FakturPajaks_No = Util.wrapNullable<string>(row, COL_FakturPajaks_No);
            Kontrabons_No = Util.wrapNullable<string>(row, COL_Kontrabons_No);

            //ReturnAmount = DBUtil.parseData<decimal>(dt.Rows[0], COL_RETURNAMOUNT);
        }

        public SaleReturn(string Notes, DataTable SaleReturnItems)
        {
            id = Guid.NewGuid();
            time_stamp = DateTime.Now;
            voided = false;
            user_id = GlobalData.UserAccount.id;
            notes = Notes;
            saleReturnItems = SaleReturnItems;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtSummary = dt.Clone();
            Tools.setDataTablePrimaryKey(dtSummary, SaleItem.COL_INVENTORY_ID);

            DataRow tempRow;
            foreach (DataRow dr in dt.Rows)
            {
                if (dtSummary.Rows.Contains(dr[SaleItem.COL_INVENTORY_ID]))
                {
                    tempRow = dtSummary.Rows.Find(dr[SaleItem.COL_INVENTORY_ID]);
                    tempRow[SaleItem.COL_QTY] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_QTY]) + Tools.zeroNonNumericString(dr[SaleItem.COL_QTY]);
                    tempRow[SaleItem.COL_LENGTH] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_LENGTH]) + Tools.zeroNonNumericString(dr[SaleItem.COL_LENGTH]);
                    tempRow[SaleItem.COL_SUBTOTAL] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_SUBTOTAL]) + Tools.zeroNonNumericString(dr[SaleItem.COL_SUBTOTAL]);
                    dtSummary.AcceptChanges();
                }
                else
                {
                    dtSummary.Rows.Add(dr.ItemArray);
                }
            }

            return dtSummary;
        }


        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public Guid? submitNew()
        {
            //submit new sale record
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, true, false, false, false,
                "salereturn_new",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, time_stamp),
                new SqlQueryParameter(COL_DB_Users_Id, SqlDbType.UniqueIdentifier, user_id),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(id);
                barcode = Tools.getHex(result.ValueInt, Settings.saleBarcodeLength);
            }

            //mark sale items as returned
            foreach (DataRow row in saleReturnItems.Rows)
            {
                result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "saleitem_return",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable<Guid>(row, SaleItem.COL_ID)),
                    new SqlQueryParameter("return_id", SqlDbType.UniqueIdentifier, id)
                );

                if (!result.IsSuccessful)
                    return null;
                else
                {
                    ActivityLog.submit((Guid)row[SaleItem.COL_ID], "Sale Item returned in sale return ID: " + id.ToString());
                    ActivityLog.submit((Guid)row[SaleItem.COL_INVENTORY_ITEM_ID], "Returned in sale return ID: " + barcode);
                }
            }

            return id;
        }

        public static DataTable get_by_Kontrabons_Id(Guid Kontrabons_Id)
        {
            return get(null, null, null, null, null, null, false, null, null, false, Kontrabons_Id);
        }
        public static DataTable get_by_FakturPajaks_Id(Guid FakturPajaks_Id)
        {
            return get(null, null, null, null, null, null, false, FakturPajaks_Id, null, false, null);
        }
        public static DataTable get_by_BrowsingForFakturPajak_Customers_Id(Guid BrowsingForFakturPajak_Customers_Id)
        {
            return get(null, null, null, null, null, null, false, null, BrowsingForFakturPajak_Customers_Id, false, null);
        }
        public static DataTable get_Reminder()
        {
            return get(null, null, null, null, null, null, false, null, null, true, null);
        }
        public static DataTable get(DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? saleReturnID)
        {
            return get(null, dateStart, dateEnd, inventoryID, customerID, saleReturnID, false, null, null, false, null);
        }
        public static DataRow get(Guid Id)
        {
            return Util.getFirstRow(get(Id, null, null, null, null, null, false, null, null, false, null));
        }
        public static DataTable get(Guid? Id, DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? saleReturnID, 
            bool onlyWithCommission, Guid? FakturPajaks_Id, Guid? BrowsingForFakturPajak_Customers_Id, bool showOnlyReminder, Guid? Kontrabons_Id)
        {
            Guid? salesUserId = null;
            if (onlyWithCommission)
                salesUserId = GlobalData.UserAccount.id;

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "SaleReturns_get",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter("date_start", SqlDbType.DateTime, Util.wrapNullable(dateStart)),
                new SqlQueryParameter("date_end", SqlDbType.DateTime, Util.wrapNullable(dateEnd)),
                new SqlQueryParameter("inventory_item_id", SqlDbType.UniqueIdentifier, Util.wrapNullable(inventoryID)),
                new SqlQueryParameter(COL_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(customerID)),
                new SqlQueryParameter("salereturn_id", SqlDbType.UniqueIdentifier, Util.wrapNullable(saleReturnID)),
                new SqlQueryParameter(COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(FakturPajaks_Id)),
                new SqlQueryParameter(COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Kontrabons_Id)),
                new SqlQueryParameter(FILTER_BrowsingForFakturPajak_Customers_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(BrowsingForFakturPajak_Customers_Id)),
                new SqlQueryParameter(FILTER_ShowOnlyReminder, SqlDbType.Bit, showOnlyReminder),
                new SqlQueryParameter(COL_SALESMANID, SqlDbType.UniqueIdentifier, Util.wrapNullable(salesUserId))
            );
            return result.Datatable;
        }

        public static void updateCheckedStatus(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "SaleReturns_update_Checked",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_Checked, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Checked Status to " + value);
        }

        public static void update_FakturPajaks_Id(Guid Id, Guid? FakturPajaks_Id)
        {
            SaleReturn objOld = new SaleReturn(Id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.FakturPajaks_No, new FakturPajak(FakturPajaks_Id).No, "Faktur Pajak: '{0}' to '{1}'");

            if (string.IsNullOrEmpty(log))
                Util.displayMessageBoxError("No changes to record");
            else
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "salereturn_update_FakturPajaks_Id",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(FakturPajaks_Id))
                );

                if (result.IsSuccessful)
                {
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                    //update faktur pajak log
                    if (FakturPajaks_Id == null)
                        ActivityLog.submit((Guid)objOld.FakturPajaks_Id, String.Format("Removed Sale Return: {0}", objOld.barcode));
                    else
                        ActivityLog.submit((Guid)FakturPajaks_Id, String.Format("Added Sale Return: {0}", objOld.barcode));
                }
            }
        }

        public static void update_Kontrabons_Id(Guid Id, Guid? Kontrabons_Id)
        {
            SaleReturn objOld = new SaleReturn(Id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.Kontrabons_No, new Kontrabon(Kontrabons_Id).No, "Kontrabon: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "salereturn_update_Kontrabons_Id",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Kontrabons_Id))
                );

                if (result.IsSuccessful)
                {
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                    //update faktur pajak log
                    if (Kontrabons_Id == null)
                        ActivityLog.submit((Guid)objOld.Kontrabons_Id, String.Format("Removed: {0}", objOld.barcode));
                    else
                        ActivityLog.submit((Guid)Kontrabons_Id, String.Format("Added: {0}", objOld.barcode));

                    //remove faktur pajak and all items related to it
                    Guid? FakturPajaks_Id = new SaleReturn(Id).FakturPajaks_Id;
                    if (FakturPajaks_Id != null)
                        FakturPajak.update_Kontrabons_Id((Guid)FakturPajaks_Id, Kontrabons_Id);
                }
            }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/

    }
}
