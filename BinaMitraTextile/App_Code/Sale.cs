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
        public const string COL_SALEAMOUNT = "sale_amount";
        public const string COL_CUSTOMERNAME = "customer_name";
        public const string COL_RECEIVABLEAMOUNT = "receivable_amount";
        public const string COL_RECEIVABLEDUEDATE = "receivable_due_date";
        public const string COL_DAYSELAPSED = "days_elapsed";
        public const string COL_DB_TRANSPORTID = "transport_id";
        public const string COL_DB_SPECIALUSERONLY = "special_user_only";
        public const string COL_DB_RETURNEDTOSUPPLIER = "returned_to_supplier";
        public const string COL_DB_SHIPPINGCOST = "shipping_cost";
        public const string COL_DB_ISREPORTED = "is_reported";
        public const string COL_DB_TAXNO = "tax_no";
        public const string COL_DB_Notes = "notes";
        public const string COL_DB_SaleCommission_Users_Id = "SaleCommission_Users_Id";

        public const string COL_TRANSPORTNAME = "transport_name";
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

        public const string FILTER_OnlyNotCompleted = "FILTER_OnlyNotCompleted";
        public const string FILTER_Inventory_Code = "FILTER_Inventory_Code";
        public const string FILTER_OnlyManualAdjustment = "FILTER_OnlyManualAdjustment";

        public const string FILTER_SaleOrderItems_Id = "FILTER_SaleOrderItems_Id";

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
        public Guid customer_id;
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

        public string TransportName = "";

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
                DataRow row = datatable.Rows[0];
                id = DBUtil.parseData<Guid>(row, COL_ID);
                time_stamp = Convert.ToDateTime(row["time_stamp"]);
                customer_id = (Guid)row[COL_CUSTOMER_ID];
                voided = (Boolean)row["voided"];
                user_id = (Guid)row["user_id"];
                notes = row["notes"].ToString();
                customer_info = row["customer_info"].ToString();
                barcode = Tools.getHex(Convert.ToInt32(row["barcode"]), Settings.saleBarcodeLength);
                TransportID = DBUtil.parseData<Guid?>(row, COL_DB_TRANSPORTID);
                ShippingCost = DBUtil.parseData<decimal>(row, COL_DB_SHIPPINGCOST);
                TaxNo = DBUtil.parseData<string>(row, COL_DB_TAXNO);
                ReturnedToSupplier = LIBUtil.Util.wrapNullable<bool>(row, COL_DB_RETURNEDTOSUPPLIER);
                SaleCommission_Users_Id = DBUtil.parseData<Guid?>(row, COL_DB_SaleCommission_Users_Id);

                TransportName = DBUtil.parseData<string>(row, COL_TRANSPORTNAME);

                sale_items = SaleItem.getItems(id);
            }
        }

        public Sale(Guid CustomerID, Guid? transportID, decimal shippingCost, string Notes)
        {
            id = Guid.NewGuid();
            time_stamp = DateTime.Now;
            customer_id = CustomerID;
            voided = false;
            user_id = GlobalData.UserAccount.id;
            customer_info = new Customer(CustomerID).compileData();
            notes = Notes;
            TransportID = transportID;
            if(transportID != null)
                TransportName = (new Transport((Guid)transportID)).Name;
            ShippingCost = shippingCost;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public string submitNew(DataTable SaleItems)
        {
            try
            {
                //submit new sale record
                using (SqlCommand cmd = new SqlCommand("sale_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@time_stamp", SqlDbType.DateTime).Value = time_stamp;
                    cmd.Parameters.Add("@voided", SqlDbType.Bit).Value = voided;
                    cmd.Parameters.Add("@customer_id", SqlDbType.UniqueIdentifier).Value = customer_id;
                    cmd.Parameters.Add("@customer_info", SqlDbType.VarChar).Value = customer_info;
                    cmd.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
                    if (notes != null) cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = string.Format("{0:MM/dd/yy HH:mm} - {1}: {2}", DateTime.Now, GlobalData.UserAccount.name, notes);
                    cmd.Parameters.Add("@" + COL_DB_TRANSPORTID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(TransportID);
                    cmd.Parameters.Add("@" + COL_DB_SHIPPINGCOST, SqlDbType.Decimal).Value = ShippingCost;
                    SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                    return_value.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    barcode = Tools.getHex(Convert.ToInt32(return_value.Value), Settings.saleBarcodeLength);

                    ActivityLog.submit(id, "New item added");
                }

                //submit sale items
                SaleItem.submitItems(getListOfSaleItems(SaleItems), barcode);
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }


        public static string update(Guid saleID, DataTable saleItems, Guid? transportID, decimal shippingCost, string notes)
        {
            Sale objOld = new Sale(saleID);
            DataTable objOldItems = Tools.setDataTablePrimaryKey(SaleItem.getItems(saleID), SaleItem.COL_ID);

            //generate log description
            string logDescription = "";
            logDescription = ActivityLog.appendChange(logDescription, objOld.TransportName, new Transport(transportID).Name, "Angkutan: '{0}' to '{1}'");
            logDescription = ActivityLog.appendChange(logDescription, objOld.ShippingCost.ToString("N2"), shippingCost.ToString("N2"), "Shipping: '{0}' to '{1}'");
            logDescription = ActivityLog.appendChange(logDescription, objOld.notes, notes, "Notes: '{0}' to '{1}'");

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
                    logDescription = ActivityLog.appendChange(logDescription, oldAdjustment, newAdjustment, "Inventory Item " + DBUtil.parseData<string>(row, SaleItem.COL_BARCODE) + " adjustment: {0:N2} to {1:N2}");
                    row[SaleItem.COL_ADJUSTMENT] = newAdjustment;
                }
                else
                {
                    //remove if has no change
                    saleItems.Rows.RemoveAt(i);
                }
            }

            if (string.IsNullOrEmpty(logDescription))
            {
                return "No information has been changed";
            }
            else
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sale_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = saleID;
                        if (notes != null) 
                            cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = string.Format("{0:MM/dd/yy HH:mm} - {1}: {2}", DateTime.Now, GlobalData.UserAccount.FirstName, notes);
                        cmd.Parameters.Add("@" + COL_DB_TRANSPORTID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(transportID);
                        cmd.Parameters.Add("@" + COL_DB_SHIPPINGCOST, SqlDbType.Decimal).Value = shippingCost;
                            
                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(saleID, "Update: " + logDescription);
                    }

                    //update sale items
                    if(saleItems.Rows.Count > 0)
                        SaleItem.updateItems(getListOfSaleItemsForUpdate(saleID, saleItems));

                    Tools.hasMessage("Item updated");
                }
                catch (Exception ex) { return ex.Message; }
            }

            return string.Empty;
        }

        private List<SaleItem> getListOfSaleItems(DataTable dt)
        {
            return dt.AsEnumerable()
                   .Select(row => new SaleItem
                   {
                       id = Guid.NewGuid(),
                       sale_id = id,
                       inventory_item_id = row.Field<Guid>(InventoryItem.COL_ID),
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
                       inventory_item_id = row.Field<Guid>(InventoryItem.COL_ID),
                       sell_price = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_SELLPRICE)),
                       adjustment = Tools.zeroNonNumericString(row.Field<decimal?>(InventoryItem.COL_SALE_ADJUSTMENT)),
                       isManualAdjustment = row.Field<bool>(InventoryItem.COL_SALE_isManualAdjustment)
                   }).ToList();
        }

        public static Guid getIDByBarcode(string barcode)
        {
            using (SqlCommand cmd = new SqlCommand("sale_get_id_by_barcode", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@barcode", SqlDbType.Int).Value = Tools.getInt(barcode);

                return new Guid(cmd.ExecuteScalar().ToString());
            }
        }

        public static DataTable getAll(DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? saleID, 
            bool onlyHasReceivable, bool onlyLossProfit, bool onlyReturnedToSupplier, bool onlyWithCommission, Guid? salesUserAccountID, 
            DataTable dtProductStoreNameID, DataTable dtColorID, bool onlyNotCompleted, bool onlyManualAdjustment, string inventoryCode)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_getall", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = (object)dateEnd ?? DBNull.Value;
                cmd.Parameters.Add("@inventory_item_id", SqlDbType.UniqueIdentifier).Value = (object)inventoryID ?? DBNull.Value;
                cmd.Parameters.Add("@customer_id", SqlDbType.UniqueIdentifier).Value = (object)customerID ?? DBNull.Value;
                cmd.Parameters.Add("@sale_id", SqlDbType.UniqueIdentifier).Value = (object)saleID ?? DBNull.Value;
                cmd.Parameters.Add("@only_has_receivable", SqlDbType.Bit).Value = onlyHasReceivable;
                cmd.Parameters.Add("@only_loss_profit", SqlDbType.Bit).Value = onlyLossProfit;
                cmd.Parameters.Add("@include_special_user_only", SqlDbType.Bit).Value = GlobalData.UserAccount.role == Roles.Super;
                cmd.Parameters.Add("@" + Sale.COL_DB_RETURNEDTOSUPPLIER, SqlDbType.Bit).Value = onlyReturnedToSupplier;
                cmd.Parameters.Add("@" + FILTER_OnlyNotCompleted, SqlDbType.Bit).Value = onlyNotCompleted;
                cmd.Parameters.Add("@" + FILTER_Inventory_Code, SqlDbType.VarChar).Value = LIBUtil.Util.wrapNullable<string>(inventoryCode);
                cmd.Parameters.Add("@" + FILTER_OnlyManualAdjustment, SqlDbType.Bit).Value = onlyManualAdjustment;
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

                //Tools.addColumn<string>(dataTable, COL_HEXBARCODE, "");
                //foreach (DataRow dr in dataTable.Rows)
                //{
                //    dr[COL_HEXBARCODE] = Tools.getHex((int)dr[COL_BARCODE], Settings.saleBarcodeLength);
                //}
            }

            return dataTable;
        }

        public static string updateCompleted(Guid id, bool completed)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sale_update_completed", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@completed", SqlDbType.Bit).Value = completed;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update completed to: " + completed);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static string updateSpecialUserOnly(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sale_update_specialuseronly_by_id", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_SPECIALUSERONLY, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update special user only marker to: " + value);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static string updateTaxNo(Guid id, string value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sale_update_taxno", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_TAXNO, SqlDbType.VarChar).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update tax no to: " + value);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static string updateIsReported(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sale_update_isreported", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_ISREPORTED, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update report to tax to: " + value);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static string updateReturnedToSupplier(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sale_update_returnedtosupplier_by_id", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_RETURNEDTOSUPPLIER, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update returned to supplier marker to: " + value);
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("sale_get", ID);
        }

        public static DataTable getChartDataByMonths(DateTime? dateStart, DateTime? dateEnd, Guid? excludeCustomerID, DataTable dtCustomersID, DataTable dtGradeID, 
            DataTable dtProductStoreNameID, DataTable dtProductWidthID, DataTable dtLengthUnitID, DataTable dtColorID, bool isReportedOnly)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sale_charting", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(excludeCustomerID);
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
            using (SqlCommand cmd = new SqlCommand("sale_charting_bycustomers", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(excludeCustomerID);
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
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbysales", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(excludeCustomerID);
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
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbyproducts", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(excludeCustomerID);
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
            using (SqlCommand cmd = new SqlCommand("sale_charting_detailbycustomers", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = Tools.wrapNullable(dateStart);
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = Tools.wrapNullable(dateEnd);
                cmd.Parameters.Add("@exclude_customer_id", SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(excludeCustomerID);
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
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "Sale_get_by_SaleOrderItems_Id",
                    new SqlQueryParameter(FILTER_SaleOrderItems_Id, SqlDbType.UniqueIdentifier, Tools.wrapNullable(saleOrderItems_Id))
                );
            return result.Datatable;
        }

        public static DataTable get(string hexbarcode)
        {
            SqlQueryResult result = new SqlQueryResult();
            result = DBConnection.query(
                false,
                DBUtil.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "sale_get",
                    new SqlQueryParameter(COL_HEXBARCODE, SqlDbType.VarChar, Tools.wrapNullable(hexbarcode))
                );
            return result.Datatable;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtSummary = dt.Clone();
            Tools.setDataTablePrimaryKey(dtSummary, InventoryItem.COL_INVENTORY_ID);

            DataRow tempRow;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dtSummary.Rows.Contains(dr[InventoryItem.COL_INVENTORY_ID]))
                {
                    tempRow = dtSummary.Rows.Find(dr[InventoryItem.COL_INVENTORY_ID]);
                    tempRow[InventoryItem.COL_SALE_QTY] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_QTY]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_QTY]);
                    tempRow[InventoryItem.COL_LENGTH] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_LENGTH]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_LENGTH]);
                    tempRow[InventoryItem.COL_SALE_SUBTOTAL] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_SUBTOTAL]) + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_SUBTOTAL]);
                    tempRow[InventoryItem.COL_SALE_ADJUSTEDPRICE] = Tools.zeroNonNumericString(tempRow[InventoryItem.COL_SALE_SUBTOTAL]) / Tools.zeroNonNumericString(tempRow[InventoryItem.COL_LENGTH]);
                    dtSummary.AcceptChanges();
                }
                else
                {
                    if (!string.IsNullOrEmpty(dr[InventoryItem.COL_INVENTORY_ID].ToString()))
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
