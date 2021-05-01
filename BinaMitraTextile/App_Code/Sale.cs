using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class Sale
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public static string PROC_ADDNOTES = "sale_add_notes";

        public const string COL_ID = "id";
        public const string COL_DB_Timestamp = "time_stamp";        
        public const string COL_BARCODE = "barcode";
        public const string COL_HEXBARCODE = "hexbarcode";
        public const string COL_CUSTOMER_ID = "customer_id";
        public const string COL_DB_Vendors_Id = "Vendors_Id";
        public const string COL_SALEAMOUNT = "sale_amount";
        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_RECEIVABLEAMOUNT = "receivable_amount";
        public const string COL_RECEIVABLEDUEDATE = "receivable_due_date";
        public const string COL_DAYSELAPSED = "days_elapsed";
        public const string COL_DB_CUSTOMERINFO = "customer_info";
        public const string COL_DB_TRANSPORTID = "transport_id";
        public const string COL_DB_SPECIALUSERONLY = "special_user_only";
        public const string COL_DB_SHIPPINGCOST = "shipping_cost";
        public const string COL_DB_ISREPORTED = "is_reported";
        public const string COL_DB_TAXNO = "tax_no";
        public const string COL_DB_Notes = "notes";
        public const string COL_DB_SaleCommission_Users_Id = "SaleCommission_Users_Id";
        public const string COL_DB_FakturPajaks_Id = "FakturPajaks_Id";
        public const string COL_DB_Kontrabons_Id = "Kontrabons_Id";
        public const string COL_DB_ShippingExpense = "ShippingExpense";
        public const string COL_DB_Voided = "voided";
        public const string COL_DB_UserId = "user_id";

        public const string COL_TRANSPORTNAME = "transport_name";
        public const string COL_Vendors_Name = "Vendors_Name";
        public const string COL_FakturPajaks_No = "FakturPajaks_No";
        public const string COL_Kontrabons_No = "Kontrabons_No";
        public const string COL_COMPLETED = "completed";
        public const string COL_PROFIT = "profit";
        public const string COL_PROFITPERCENT = "profit_percent";
        public const string COL_SaleCommission_Users_Name = "SaleCommission_Users_Name";
        public const string COL_CommissionAmount = "CommissionAmount";
        public const string COL_RETURNEDAMOUNT = "returned_amount";
        public const string COL_isManualAdjustment = "isManualAdjustment";

        public const string COL_CustomerTerms_DebtLimit = "CustomerTerms_DebtLimit";
        public const string COL_CustomerTerms_TermDays = "CustomerTerms_TermDays";
        public const string COL_RemainingTermDays = "RemainingTermDays";
        public const string COL_RemainingDebtLimit = "RemainingDebtLimit";

        public const string COL_totalQty = "totalQty";
        public const string COL_SALEQTY = "sale_qty";
        public const string COL_SALELENGTH = "sale_length";
        public const string COL_NonReturnedAmount = "NonReturnedAmount";

        public const string FILTER_OnlyNoFakturPajak = "FILTER_OnlyNoFakturPajak";
        public const string FILTER_OnlyReturnedToSupplier = "FILTER_OnlyReturnedToSupplier";
        public const string FILTER_OnlyNotCompleted = "FILTER_OnlyNotCompleted";
        public const string FILTER_Inventory_Code = "FILTER_Inventory_Code";
        public const string FILTER_OnlyManualAdjustment = "FILTER_OnlyManualAdjustment";

        public const string FILTER_SaleOrderItems_Id = "FILTER_SaleOrderItems_Id";
        public const string FILTER_BrowsingForFakturPajak_Customers_Id = "FILTER_BrowsingForFakturPajak_Customers_Id";
        public const string FILTER_BrowsingForFakturPajak_Vendors_Id = "FILTER_BrowsingForFakturPajak_Vendors_Id";

        public const string FILTER_VendorInvoices_Id = "FILTER_VendorInvoices_Id";
        public const string @FILTER_ShowOnlyReminder_MasukanRetur = "FILTER_ShowOnlyReminder_MasukanRetur";
        public const string FILTER_ShowOnlyReminder_Keluaran = "FILTER_ShowOnlyReminder_Keluaran";

        //Charting ****************************************************************
        public const string COL_CHART_SALEYEARMONTH = "sale_year_month";
        public const string COL_CHART_QTY = "sale_qty";
        public const string COL_CHART_TOTAL = "sale_total";
        public const string COL_CHART_PROFIT = "profit";
        public const string COL_CHART_PERCENT = "sale_profit_percent";

        public const string COL_CHARTSUMMARYBYCUSTOMERS_CUSTOMERID = "customer_id";
        public const string COL_CHARTSUMMARYBYCUSTOMERS_CUSTOMERNAME = "customer_name";
        public const string COL_CHARTSUMMARYBYCUSTOMERS_SALEQTY = "sale_length";
        public const string COL_CHARTSUMMARYBYCUSTOMERS_SALEAMOUNT = "sale_amount";
        public const string COL_CHARTSUMMARYBYCUSTOMERS_PROFITAMOUNT = "profit_amount";
        public const string COL_CHARTSUMMARYBYCUSTOMERS_PROFITPERCENT = "profit_percent";

        public const string COL_CHARTDETAILBYSALES_SALEID = "sale_id";
        public const string COL_CHARTDETAILBYSALES_TIMESTAMP = "time_stamp";
        public const string COL_CHARTDETAILBYSALES_SALEBARCODE = "barcode";
        public const string COL_CHARTDETAILBYSALES_CUSTOMERNAME = "customer_name";
        public const string COL_CHARTDETAILBYSALES_SALEPCS = "sale_pcs";
        public const string COL_CHARTDETAILBYSALES_SALEQTY = "sale_length";
        public const string COL_CHARTDETAILBYSALES_SALEAMOUNT = "sale_amount";
        public const string COL_CHARTDETAILBYSALES_PROFITAMOUNT = "profit";
        public const string COL_CHARTDETAILBYSALES_PROFITPERCENT = "profit_percent";

        public const string COL_CHARTDETAILBYPRODUCTS_PRODUCTID = "product_id";
        public const string COL_CHARTDETAILBYPRODUCTS_PRODUCTNAME = "product_name";
        public const string COL_CHARTDETAILBYPRODUCTS_SALEPCS = "sale_pcs";
        public const string COL_CHARTDETAILBYPRODUCTS_SALEQTY = "sale_length";
        public const string COL_CHARTDETAILBYPRODUCTS_SALEAMOUNT = "sale_amount";
        public const string COL_CHARTDETAILBYPRODUCTS_PROFITAMOUNT = "profit_amount";
        public const string COL_CHARTDETAILBYPRODUCTS_PROFITPERCENT = "profit_percent";
        public const string COL_CHARTDETAILBYPRODUCTS_GRADE = "grade_name";

        public const string COL_CHARTDETAILBYCUSTOMERS_CUSTOMERID = "customer_id";
        public const string COL_CHARTDETAILBYCUSTOMERS_CUSTOMERNAME = "customer_name";
        public const string COL_CHARTDETAILBYCUSTOMERS_SALEPCS = "sale_pcs";
        public const string COL_CHARTDETAILBYCUSTOMERS_SALEQTY = "sale_length";
        public const string COL_CHARTDETAILBYCUSTOMERS_SALEAMOUNT = "sale_amount";
        public const string COL_CHARTDETAILBYCUSTOMERS_PROFITAMOUNT = "profit_amount";
        public const string COL_CHARTDETAILBYCUSTOMERS_PROFITPERCENT = "profit_percent";

        //*************************************************************************

        public Guid id;
        public DateTime time_stamp;
        public Guid? customer_id;
        public Guid? Vendors_Id;
        public bool voided;
        public Guid user_id;
        public string notes = "";
        public DataTable temporaryDataTable;
        public string barcode = "";
        public string customer_info = "";
        public Guid? TransportID;
        public decimal ShippingCost = 0;
        public string TaxNo;
        public bool ReturnedToSupplier = false;
        public Guid? SaleCommission_Users_Id;
        public Guid? FakturPajaks_Id;
        public Guid? Kontrabons_Id;
        public int ShippingExpense;

        public string TransportName = "";
        public string FakturPajaks_No;
        public string Kontrabons_No;
        public string Vendors_Name = "";
        public string Customers_Name = "";
        public string PettyCashRecords_No;

        public DataTable sale_items;
        public DataTable datatable;
        
        public decimal SaleAmount
        {
            get { 
                if(sale_items == null)
                    return 0;
                else
                    return Convert.ToDecimal(sale_items.Compute(String.Format("SUM({0})", InventoryItem.COL_SALE_SUBTOTAL), "")); ; 
            }
        }

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public Sale(string hexbarcode) : this(get(hexbarcode)) { }

        public Sale(Guid ID) : this(getRow(ID)) { }

        public Sale(DataTable dt)
        {
            if(dt != null && dt.Rows.Count > 0)
            {
                datatable = dt;
                DataRow row = Util.getFirstRow(datatable);
                id = DBUtil.parseData<Guid>(row, COL_ID);
                time_stamp = Convert.ToDateTime(row["time_stamp"]);
                customer_id = Util.wrapNullable<Guid?>(row, COL_CUSTOMER_ID);
                Vendors_Id = Util.wrapNullable<Guid?>(row, COL_DB_Vendors_Id);
                voided = (Boolean)row["voided"];
                user_id = (Guid)row["user_id"];
                notes = row["notes"].ToString();
                customer_info = row["customer_info"].ToString();
                barcode = Util.wrapNullable<string>(row["hexbarcode"]);
                TransportID = DBUtil.parseData<Guid?>(row, COL_DB_TRANSPORTID);
                ShippingCost = DBUtil.parseData<decimal>(row, COL_DB_SHIPPINGCOST);
                TaxNo = DBUtil.parseData<string>(row, COL_DB_TAXNO);
                SaleCommission_Users_Id = DBUtil.parseData<Guid?>(row, COL_DB_SaleCommission_Users_Id);
                FakturPajaks_Id = DBUtil.parseData<Guid?>(row, COL_DB_FakturPajaks_Id);
                Kontrabons_Id = DBUtil.parseData<Guid?>(row, COL_DB_Kontrabons_Id);
                ShippingExpense = DBUtil.parseData<int>(row, COL_DB_ShippingExpense);

                ReturnedToSupplier = (Vendors_Id != null);
                TransportName = DBUtil.parseData<string>(row, COL_TRANSPORTNAME);
                FakturPajaks_No = DBUtil.parseData<string>(row, COL_FakturPajaks_No);
                Kontrabons_No = DBUtil.parseData<string>(row, COL_Kontrabons_No);

                Customers_Name = Util.wrapNullable<string>(row, COL_CUSTOMERNAME);
                Vendors_Name = Util.wrapNullable<string>(row, COL_Vendors_Name);

                sale_items = SaleItem.getItems(id);
            }
        }

        public Sale(Guid? CustomerID, Guid? vendors_Id, Guid? transportID, decimal shippingCost, bool returnedToSupplier, string Notes)
        {
            id = Guid.NewGuid();
            time_stamp = DateTime.Now;
            voided = false;
            user_id = GlobalData.UserAccount.id;
            customer_id = CustomerID;
            Vendors_Id = vendors_Id;
            if(customer_id != null)
                customer_info = new Customer(CustomerID).Info;
            else
                customer_info = new Vendor(Vendors_Id).Info;
            notes = Notes;
            TransportID = transportID;
            if(transportID != null)
                TransportName = (new Transport((Guid)transportID)).Name;
            ShippingCost = shippingCost;
            ReturnedToSupplier = returnedToSupplier;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public Guid? submitNew(DataTable SaleItems)
        {
            //format notes
            if (string.IsNullOrWhiteSpace(notes))
                notes = null;
            else
                notes = string.Format("{0:MM/dd/yy}-{1}: {2}", DateTime.Now, GlobalData.UserAccount.name, notes);

            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                true, false, false, false, false,
                "sale_new",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_Timestamp, SqlDbType.DateTime, time_stamp),
                new SqlQueryParameter(COL_DB_Voided, SqlDbType.Bit, voided),
                new SqlQueryParameter(COL_CUSTOMER_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(customer_id)),
                new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                new SqlQueryParameter(COL_DB_CUSTOMERINFO, SqlDbType.VarChar, customer_info),
                new SqlQueryParameter(COL_DB_UserId, SqlDbType.UniqueIdentifier, user_id),
                new SqlQueryParameter(COL_DB_TRANSPORTID, SqlDbType.UniqueIdentifier, Util.wrapNullable(TransportID)),
                new SqlQueryParameter(COL_DB_SHIPPINGCOST, SqlDbType.Decimal, ShippingCost),
                new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(id);

                barcode = result.ValueString;
                SaleItem.submitItems(getListOfSaleItems(SaleItems), barcode, customer_id);

                return id;
            }
        }


        public static void update_FakturPajaks_Id(Guid Id, Guid? FakturPajaks_Id)
        {
            Sale objOld = new Sale(Id);
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
                    "sale_update_FakturPajaks_Id",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(FakturPajaks_Id))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                //update faktur pajak log
                if (FakturPajaks_Id == null)
                    ActivityLog.submit((Guid)objOld.FakturPajaks_Id, String.Format("Removed Sale Invoice: {0}", objOld.barcode));
                else
                    ActivityLog.submit((Guid)FakturPajaks_Id, String.Format("Added Sale Invoice: {0}", objOld.barcode));
            }
        }

        public static void update_Kontrabons_Id(Guid Id, Guid? Kontrabons_Id)
        {
            Sale objOld = new Sale(Id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.Kontrabons_No, new Kontrabon(Kontrabons_Id).No, "Kontrabon: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "sale_update_Kontrabons_Id",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Kontrabons_Id))
                );

                if (result.IsSuccessful)
                {
                    ActivityLog.submit(Id, String.Format("Updated: {0}", log));

                    //update faktur pajak log
                    if (Kontrabons_Id == null)
                        ActivityLog.submit((Guid)objOld.Kontrabons_Id, String.Format("Removed Sale Invoice: {0}", objOld.barcode));
                    else
                        ActivityLog.submit((Guid)Kontrabons_Id, String.Format("Added Sale Invoice: {0}", objOld.barcode));

                    //remove faktur pajak and all items related to it
                    Guid? FakturPajaks_Id = new Sale(Id).FakturPajaks_Id;
                    if (FakturPajaks_Id != null)
                        FakturPajak.update_Kontrabons_Id((Guid)FakturPajaks_Id, Kontrabons_Id);
                }
            }
        }

        public static void update_ShippingExpense(Guid Id, Guid PettyCashRecordsCategories_Id, int Amount, string Notes)
        {
            Sale objOld = new Sale(Id);
            string log = "";
            log = ActivityLog.appendChange(log, objOld.ShippingExpense, Amount, "Shipping Expense: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(log))
            {
                int PettyCashRecords_Amount = -1 * Amount;
                string PettyCashRecords_Notes = string.Format("Expense for Invoice {0}", objOld.barcode);

                //if there is previous amount value, adjust amount so petty cash is still correct.
                if (objOld.ShippingExpense > 0)
                {
                    PettyCashRecords_Amount += objOld.ShippingExpense;
                    PettyCashRecords_Notes += string.Format(" (Update {0:N0} to {1:N0})", objOld.ShippingExpense, Amount);
                }

                //transport information
                if(objOld.TransportName != null)
                    PettyCashRecords_Notes += string.Format(", Angkutan {0}", objOld.TransportName);

                if (!string.IsNullOrWhiteSpace(Notes))
                    PettyCashRecords_Notes += ", " + Notes;

                Guid? PettyCashRecords_Id = PettyCashRecord.add(PettyCashRecordsCategories_Id, PettyCashRecords_Amount, PettyCashRecords_Notes);
                if(PettyCashRecords_Id != null)
                {
                    log += string.Format(", Petty Cash {0} Amount: {1:N0}", new PettyCashRecord((Guid)PettyCashRecords_Id).No, PettyCashRecords_Amount);

                    SqlQueryResult result = DBConnection.query(
                        false,
                        DBConnection.ActiveSqlConnection,
                        QueryTypes.ExecuteNonQuery,
                        "Sales_update_ShippingExpense",
                        new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, Id),
                        new SqlQueryParameter(COL_DB_ShippingExpense, SqlDbType.Int, Amount)
                    );

                    if (result.IsSuccessful)
                        ActivityLog.submit(Id, String.Format("Updated: {0}", log));
                }
            }
        }

        public static bool update(Guid saleID, Guid? Customers_Id, Guid? Vendors_Id, DataTable saleItems, Guid? transportID, decimal shippingCost, string notes)
        {
            Sale objOld = new Sale(saleID);
            DataTable objOldItems = Tools.setDataTablePrimaryKey(SaleItem.getItems(saleID), SaleItem.COL_ID);
            string customerInfo = objOld.customer_info;

            //generate log description
            string log = "";

            //update customer/vendor info
            Customer newCustomer = new Customer(Customers_Id);
            if (objOld.customer_id != newCustomer.ID)
            {
                log = Util.appendChange(log, objOld.Customers_Name, newCustomer.Name, "Customer: '{0}' to '{1}'");
                log = Util.appendChange(log, objOld.customer_info, newCustomer.Info, "Info: '{0}' to '{1}'");
            }
            Vendor newVendor = new Vendor(Vendors_Id);
            if(objOld.Vendors_Id != Vendors_Id)
            {
                log = Util.appendChange(log, objOld.Vendors_Name, newVendor.Name, "Vendor: '{0}' to '{1}'");
                log = Util.appendChange(log, objOld.customer_info, newVendor.Info, "Info: '{0}' to '{1}'");
            }
            if(Customers_Id != null)
                customerInfo = newCustomer.Info;
            else
                customerInfo = newVendor.Info;

            log = ActivityLog.appendChange(log, objOld.TransportName, new Transport(transportID).Name, "Angkutan: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.ShippingCost.ToString("N2"), shippingCost.ToString("N2"), "Shipping: '{0}' to '{1}'");
            log = ActivityLog.appendChange(log, objOld.notes, notes, "Notes: '{0}' to '{1}'");

            DataRow row;
            Guid id;
            decimal oldAdjustment, newAdjustment;
            for (int i = saleItems.Rows.Count-1; i >=0; i--)
            {
                row = saleItems.Rows[i];
                id = DBUtil.parseData<Guid>(row, SaleItem.COL_ID);
                newAdjustment = DBUtil.parseData<decimal>(row, SaleItem.COL_ADJUSTMENT);
                oldAdjustment = DBUtil.parseData<decimal>(objOldItems.Rows.Find(id), SaleItem.COL_ADJUSTMENT);
                if (oldAdjustment != newAdjustment)
                {
                    log = ActivityLog.appendChange(log, oldAdjustment, newAdjustment, "Inventory Item " + DBUtil.parseData<string>(row, SaleItem.COL_BARCODE) + " adjustment: {0:N2} to {1:N2}");
                    row[SaleItem.COL_ADJUSTMENT] = newAdjustment;
                }
                else
                {
                    //remove if has no change
                    saleItems.Rows.RemoveAt(i);
                }
            }

            if (!string.IsNullOrEmpty(log))
            {
                //format notes
                if (string.IsNullOrWhiteSpace(notes))
                    notes = null;
                else
                    notes = string.Format("{0:MM/dd/yy}-{1}: {2}", DateTime.Now, GlobalData.UserAccount.name, notes);

                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "sale_update",
                    new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, saleID),
                    new SqlQueryParameter(COL_CUSTOMER_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(Customers_Id)),
                    new SqlQueryParameter(COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(Vendors_Id)),
                    new SqlQueryParameter(COL_DB_CUSTOMERINFO, SqlDbType.VarChar, Util.wrapNullable(customerInfo)),
                    new SqlQueryParameter(COL_DB_TRANSPORTID, SqlDbType.UniqueIdentifier, Util.wrapNullable(transportID)),
                    new SqlQueryParameter(COL_DB_SHIPPINGCOST, SqlDbType.Decimal, shippingCost),
                    new SqlQueryParameter(COL_DB_Notes, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (!result.IsSuccessful)
                    return false;
                else
                {
                    ActivityLog.submit(saleID, "Update: " + log);

                    if (saleItems.Rows.Count > 0)
                        SaleItem.updateItems(getListOfSaleItemsForUpdate(saleID, saleItems));
                }
            }

            return true;
        }

        private List<SaleItem> getListOfSaleItems(DataTable dt)
        {
            return dt.AsEnumerable()
                   .Select(row => new SaleItem
                   {
                       id = Guid.NewGuid(),
                       sale_id = id,
                       inventory_item_id = row.Field<Guid>(InventoryItem.COL_DB_ID),
                       sell_price = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_SELLPRICE)),
                       adjustment = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_ADJUSTMENT)),
                       isManualAdjustment = row.Field<bool>(InventoryItem.COL_SALE_isManualAdjustment)
                   }).ToList();
        }

        private static List<SaleItem> getListOfSaleItemsForUpdate(Guid SaleID, DataTable dt)
        {
            return dt.AsEnumerable()
                   .Select(row => new SaleItem
                   {
                       id = row.Field<Guid>(SaleItem.COL_ID),
                       sale_id = SaleID,
                       inventory_item_id = row.Field<Guid>(InventoryItem.COL_DB_ID),
                       sell_price = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_SELLPRICE)),
                       adjustment = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_ADJUSTMENT)),
                       isManualAdjustment = row.Field<bool>(InventoryItem.COL_SALE_isManualAdjustment)
                   }).ToList();
        }

        public static Guid getIDByBarcode(string barcode)
        {
            using (SqlCommand cmd = new SqlCommand("sale_get_id_by_barcode", DBConnection.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.Int).Value = Tools.getInt(barcode);

                return new Guid(cmd.ExecuteScalar().ToString());
            }
        }

        public static DataTable get_by_Kontrabons_Id(Guid Kontrabons_Id)
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, null, null, null, false, false, Kontrabons_Id);
        }
        public static DataTable get_ReceivablesOnly(bool OnlyNoFakturPajak)
        {
            return get(null, null, null, null, null, null, true, OnlyNoFakturPajak, false, false, false, null, null, null, false, false, null, null, null, null, null, false, false, null);
        }
        public static DataTable get_by_FakturPajaks_Id(Guid FakturPajaks_Id)
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, FakturPajaks_Id, null, null, null, false, false, null);
        }
        public static DataTable get_by_BrowsingForFakturPajak(Guid? BrowsingForFakturPajak_Customers_Id, Guid? BrowsingForFakturPajak_Vendors_Id)
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, BrowsingForFakturPajak_Customers_Id, BrowsingForFakturPajak_Vendors_Id, null, false, false, null);
        }
        public static DataTable get_by_VendorInvoices_Id(Guid VendorInvoices_Id)
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, null, null, VendorInvoices_Id, false, false, null);
        }
        public static DataTable get_Reminder_MasukanRetur()
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, null, null, null, true, false, null);
        }
        public static DataTable get_Reminder_Keluaran()
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, null, null, null, false, true, null);
        }
        public static DataTable get(DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? Vendors_Id, Guid? saleID,
           bool onlyHasReceivable, bool OnlyNoFakturPajak, bool onlyLossProfit, bool onlyReturnedToSupplier, bool onlyWithCommission, Guid? salesUserAccountID,
           DataTable dtProductStoreNameID, DataTable dtColorID, bool onlyNotCompleted, bool onlyManualAdjustment, string inventoryCode)
        {
            return get(dateStart, dateEnd, inventoryID, customerID, Vendors_Id, saleID, onlyHasReceivable, OnlyNoFakturPajak, onlyLossProfit, onlyReturnedToSupplier,
                onlyWithCommission, salesUserAccountID, dtProductStoreNameID, dtColorID, onlyNotCompleted, onlyManualAdjustment, inventoryCode, 
                null, null, null, null, false, false, null);
        }
        public static DataTable get()
        {
            return get(null, null, null, null, null, null, false, false, false, false, false, null, null, null, false, false, null, null, null, null, null, false, false, null);
        }
        public static DataTable get(DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? Vendors_Id, Guid? saleID, 
            bool onlyHasReceivable, bool OnlyNoFakturPajak, bool onlyLossProfit, bool onlyReturnedToSupplier, bool onlyWithCommission, Guid? salesUserAccountID, 
            DataTable dtProductStoreNameID, DataTable dtColorID, bool onlyNotCompleted, bool onlyManualAdjustment, string inventoryCode,
            Guid? FakturPajaks_Id, Guid? BrowsingForFakturPajak_Customers_Id, Guid? BrowsingForFakturPajak_Vendors_Id, Guid? VendorInvoices_Id, 
            bool showOnlyReminder_MasukanRetur, bool showOnlyReminder_Keluaran, Guid? Kontrabons_Id)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Sales_get", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = (object)dateEnd ?? DBNull.Value;
                cmd.Parameters.Add("@inventory_item_id", SqlDbType.UniqueIdentifier).Value = (object)inventoryID ?? DBNull.Value;
                cmd.Parameters.Add("@customer_id", SqlDbType.UniqueIdentifier).Value = (object)customerID ?? DBNull.Value;
                cmd.Parameters.Add("@" + COL_DB_Vendors_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(Vendors_Id);
                cmd.Parameters.Add("@sale_id", SqlDbType.UniqueIdentifier).Value = (object)saleID ?? DBNull.Value;
                cmd.Parameters.Add("@only_has_receivable", SqlDbType.Bit).Value = onlyHasReceivable;
                cmd.Parameters.Add("@only_loss_profit", SqlDbType.Bit).Value = onlyLossProfit;
                cmd.Parameters.Add("@include_special_user_only", SqlDbType.Bit).Value = GlobalData.UserAccount.role == Roles.Super;
                cmd.Parameters.Add("@" + FILTER_OnlyNoFakturPajak, SqlDbType.Bit).Value = OnlyNoFakturPajak;
                cmd.Parameters.Add("@" + FILTER_OnlyReturnedToSupplier, SqlDbType.Bit).Value = onlyReturnedToSupplier;
                cmd.Parameters.Add("@" + FILTER_OnlyNotCompleted, SqlDbType.Bit).Value = onlyNotCompleted;
                cmd.Parameters.Add("@" + FILTER_Inventory_Code, SqlDbType.VarChar).Value = Util.wrapNullable<string>(inventoryCode);
                cmd.Parameters.Add("@" + FILTER_OnlyManualAdjustment, SqlDbType.Bit).Value = onlyManualAdjustment;
                cmd.Parameters.Add("@" + COL_DB_FakturPajaks_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(FakturPajaks_Id);
                cmd.Parameters.Add("@" + COL_DB_Kontrabons_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(Kontrabons_Id);
                cmd.Parameters.Add("@" + FILTER_BrowsingForFakturPajak_Customers_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(BrowsingForFakturPajak_Customers_Id);
                cmd.Parameters.Add("@" + FILTER_BrowsingForFakturPajak_Vendors_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(BrowsingForFakturPajak_Vendors_Id);
                cmd.Parameters.Add("@" + FILTER_VendorInvoices_Id, SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(VendorInvoices_Id);
                cmd.Parameters.Add("@" + FILTER_ShowOnlyReminder_MasukanRetur, SqlDbType.Bit).Value = showOnlyReminder_MasukanRetur;
                cmd.Parameters.Add("@" + FILTER_ShowOnlyReminder_Keluaran, SqlDbType.Bit).Value = showOnlyReminder_Keluaran;
                if (onlyWithCommission)
                {
                    if (salesUserAccountID == null)
                        cmd.Parameters.Add("@" + Sale.COL_DB_SaleCommission_Users_Id, SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;
                    else
                        cmd.Parameters.Add("@" + Sale.COL_DB_SaleCommission_Users_Id, SqlDbType.UniqueIdentifier).Value = salesUserAccountID;
                }
                DBUtil.addListParameter(cmd, "@productstorename_id_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@color_id_list", dtColorID);






                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void updateCompleted(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "sale_update_completed",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_COMPLETED, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update Completed to " + value);
        }

        public static void updateSpecialUserOnly(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "sale_update_specialuseronly_by_id",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_SPECIALUSERONLY, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update special user only marker to: " + value);
        }

        public static void updateTaxNo(Guid id, string value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "sale_update_taxno",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_TAXNO, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update tax no to: " + value);
        }

        public static void updateIsReported(Guid id, bool value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "sale_update_isreported",
                new SqlQueryParameter(COL_ID, SqlDbType.UniqueIdentifier, id),
                new SqlQueryParameter(COL_DB_ISREPORTED, SqlDbType.Bit, value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(id, "Update report to tax to: " + value);
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("sale_get", ID);
        }

        public static DataTable getChartDataByMonths(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID, 
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Util.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Util.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(excludeCustomerID);
                cmd.Parameters.Add("@is_reported_only", SqlDbType.Bit).Value = isReportedOnly;
                DBUtil.addListParameter(cmd, "@customer_id_list", dtCustomersID);
                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@product_storenameid_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@product_widthid_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@length_unitid_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@colorid_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getChartDataByCustomers(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID,
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting_bycustomers", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Util.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Util.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(excludeCustomerID);
                cmd.Parameters.Add("@is_reported_only", SqlDbType.Bit).Value = isReportedOnly;
                DBUtil.addListParameter(cmd, "@customer_id_list", dtCustomersID);
                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@product_storenameid_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@product_widthid_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@length_unitid_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@colorid_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getChartDataDetailBySales(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID, 
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbysales", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Util.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Util.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(excludeCustomerID);
                cmd.Parameters.Add("@is_reported_only", SqlDbType.Bit).Value = isReportedOnly;
                DBUtil.addListParameter(cmd, "@customer_id_list", dtCustomersID);
                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@product_storenameid_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@product_widthid_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@length_unitid_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@colorid_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getChartDataDetailByProducts(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID,
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbyproducts", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Util.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Util.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(excludeCustomerID);
                cmd.Parameters.Add("@is_reported_only", SqlDbType.Bit).Value = isReportedOnly;
                DBUtil.addListParameter(cmd, "@customer_id_list", dtCustomersID);
                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@product_storenameid_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@product_widthid_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@length_unitid_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@colorid_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable getChartDataDetailByCustomers(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID,
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbycustomers", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Util.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Util.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Util.wrapNullable(excludeCustomerID);
                cmd.Parameters.Add("@is_reported_only", SqlDbType.Bit).Value = isReportedOnly;
                DBUtil.addListParameter(cmd, "@customer_id_list", dtCustomersID);
                DBUtil.addListParameter(cmd, "@grade_id_list", dtGradeID);
                DBUtil.addListParameter(cmd, "@product_storenameid_list", dtProductStoreNameID);
                DBUtil.addListParameter(cmd, "@product_widthid_list", dtProductWidthID);
                DBUtil.addListParameter(cmd, "@length_unitid_list", dtLengthUnitID);
                DBUtil.addListParameter(cmd, "@colorid_list", dtColorID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static DataTable get_by_SaleOrderItems_Id(Guid? saleOrderItems_Id)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Sale_get_by_SaleOrderItems_Id",
                    new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Util.wrapNullable(saleOrderItems_Id))
                );
            return result.Datatable;
        }

        public static DataTable get(string hexbarcode)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "sale_get",
                    new SqlQueryParameter(COL_HEXBARCODE, SqlDbType.VarChar, Util.wrapNullable(hexbarcode))
                );
            return result.Datatable;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtSummary = dt.Clone();
            Tools.setDataTablePrimaryKey(dtSummary, InventoryItem.COL_DB_INVENTORY_ID);

            DataRow tempRow;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dtSummary.Rows.Contains(dr[InventoryItem.COL_DB_INVENTORY_ID]))
                {
                    tempRow = dtSummary.Rows.Find(dr[InventoryItem.COL_DB_INVENTORY_ID]);
                    tempRow[InventoryItem.COL_SALE_QTY] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_QTY]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_QTY]);
                    tempRow[InventoryItem.COL_DB_LENGTH] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_DB_LENGTH]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_DB_LENGTH]);
                    tempRow[InventoryItem.COL_SALE_SUBTOTAL] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_SUBTOTAL]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_SUBTOTAL]);
                    tempRow[InventoryItem.COL_SALE_ADJUSTEDPRICE] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_SUBTOTAL]) / Tools.zeroNonNumericString(tempRow[InventoryItem.COL_DB_LENGTH]);
                    dtSummary.AcceptChanges();
                }
                else
                {
                    if (!string.IsNullOrEmpty(dr[InventoryItem.COL_DB_INVENTORY_ID].ToString()))
                        dtSummary.Rows.Add(dr.ItemArray);
                }
                i++;
            }

            return dtSummary;
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
