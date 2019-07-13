using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES


        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form()
        {
            InitializeComponent();

            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            this.Text += DBUtil.appendTitleWithInfo();

            if (GlobalData.UserAccount.role == Roles.User)
            {
                col_gridPOItems_statusname.Visible = false;

                menu_users.Visible = false;

                menu_test.Visible = false;

                menu_inventory_printbarcodes.Visible = false;
                menu_inventory_po.Visible = false;
                menu_inventory_invoices.Visible = false;

                menu_reports_financial.Visible = false;
                menu_reports_tax.Visible = false;
                
                menu_admin_vendorinvoices.Visible = false;
                btnInvoices.Visible = false;

                btnShowHidden.Visible = false;
            }

            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPOItems_productDescription.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col_gridPOItems_id.DataPropertyName = POItem.COL_DB_ID;
            col_gridPOItems_pono.DataPropertyName = POItem.COL_PONO;
            col_gridPOItems_timestamp.DataPropertyName = POItem.COL_TIMESTAMP;
            col_gridPOItems_productDescription.DataPropertyName = POItem.COL_DB_PRODUCTDESCRIPTION;
            col_gridPOItems_notes.DataPropertyName = POItem.COL_DB_NOTES;
            col_gridPOItems_qty.DataPropertyName = POItem.COL_DB_QTY;
            col_gridPOItems_unitName.DataPropertyName = POItem.COL_DB_UNITNAME;
            col_gridPOItems_receivedQty.DataPropertyName = POItem.COL_RECEIVEDQTY;
            col_gridPOItems_poid.DataPropertyName = POItem.COL_DB_POID;
            col_gridPOItems_statusenumid.DataPropertyName = POItem.COL_DB_STATUSENUMID;
            col_gridPOItems_statusname.DataPropertyName = POItem.COL_STATUSNAME;
            col_gridPOItems_PricePerUnit.DataPropertyName = POItem.COL_DB_PRICEPERUNIT;
            col_gridPOItems_Age.DataPropertyName = POItem.COL_AGE;
            col_gridPOItems_PendingQtyValue.DataPropertyName = POItem.COL_PENDINGQTYVALUE;

            addStatusContextMenu(col_gridPOItems_statusname);

            gridReceivables.AutoGenerateColumns = false;
            gridReceivables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridReceivables_saleID.DataPropertyName = Sale.COL_ID;
            col_gridReceivables_saleBarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridReceivables_customerName.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_gridReceivables_amount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridReceivables_daysElapsed.DataPropertyName = Sale.COL_DAYSELAPSED;
            col_gridReceivables_CustomerTerms_TermDays.DataPropertyName = Sale.COL_CustomerTerms_TermDays;
            col_gridReceivables_RemainingTermDays.DataPropertyName = Sale.COL_RemainingTermDays;

            dgvReceivablesSummary.AutoGenerateColumns = false;
            dgvReceivablesSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_dgvReceivables_CustomerName.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_dgvReceivables_Amount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_dgvReceivablesSummary_CustomerTerms_DebtLimit.DataPropertyName = Sale.COL_CustomerTerms_DebtLimit;
            col_dgvReceivablesSummary_RemainingDebtLimit.DataPropertyName = Sale.COL_RemainingDebtLimit;

            gridStockLevel.AutoGenerateColumns = false;
            gridStockLevel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridstocklevel_id.DataPropertyName = InventoryStockLevel.COL_DB_ID;
            col_gridstocklevel_vendorname.DataPropertyName = InventoryStockLevel.COL_VENDORNAME;
            col_gridstocklevel_productstorename.DataPropertyName = InventoryStockLevel.COL_PRODUCTSTORENAME;
            col_gridstocklevel_gradename.DataPropertyName = InventoryStockLevel.COL_GRADE_NAME;
            col_gridstocklevel_productwidthname.DataPropertyName = InventoryStockLevel.COL_PRODUCT_WIDTH_NAME;
            col_gridstocklevel_colorname.DataPropertyName = InventoryStockLevel.COL_COLOR_NAME;
            col_gridstocklevel_lengthunitname.DataPropertyName = InventoryStockLevel.COL_LENGTH_UNIT_NAME;
            col_gridstocklevel_stockqty.DataPropertyName = InventoryStockLevel.COL_REMAININGSTOCKQTY;
            col_gridstocklevel_pendingqty.DataPropertyName = InventoryStockLevel.COL_PENDINGDELIVERYQTY;
            col_gridstocklevel_newqty.DataPropertyName = InventoryStockLevel.COL_NEWORDER_QTY;
        }

        private void populatePageData()
        {
            DataTable dtReceivables = Sale.getAll(null, null, null, null, null, true, false, false, false, null, null, null, false, false, null);
            gridReceivables.DataSource = dtReceivables;
            gridReceivables.Sort(col_gridReceivables_daysElapsed, ListSortDirection.Descending);
            lblTotalDaftarPiutang.Text = string.Format("{0:N0}", LIBUtil.Util.compute(dtReceivables, "SUM", Sale.COL_RECEIVABLEAMOUNT, ""));
            
            populateReceivablesSummary(dtReceivables);

            DataTable dtPOItems = new DataTable();
            LIBUtil.Util.setGridviewDataSource(gridPOItems, true, true, dtPOItems = POItem.getIncompleteItems());
            lblTotalIncompletePO.Text = string.Format("{0:N0}", LIBUtil.Util.compute(dtPOItems, "SUM", POItem.COL_PENDINGQTYVALUE, ""));
            
            gridStockLevel.DataSource = InventoryStockLevel.getAll(null, null, null, null, null, null, true);
        }

        private void populateReceivablesSummary(DataTable dtReceivables)
        {
            DataTable dtReceivablesSummary = new DataTable();
            Util.addColumnToTable<string>(dtReceivablesSummary, Sale.COL_CUSTOMERNAME, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_CustomerTerms_DebtLimit, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_RECEIVABLEAMOUNT, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_RemainingDebtLimit, null);
            Util.setDataTablePrimaryKey(dtReceivablesSummary, Sale.COL_CUSTOMERNAME);

            DataRow existing;
            object remainingDebtLimit;
            foreach(DataRow row in dtReceivables.Rows)
            {
                existing = dtReceivablesSummary.Rows.Find(Util.wrapNullable<string>(row, Sale.COL_CUSTOMERNAME));
                if (existing == null)
                {
                    remainingDebtLimit = row[Sale.COL_CustomerTerms_DebtLimit];
                    if (remainingDebtLimit != DBNull.Value)
                        remainingDebtLimit = Util.zeroNonNumericString(remainingDebtLimit) - Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);

                    dtReceivablesSummary.Rows.Add(row[Sale.COL_CUSTOMERNAME].ToString(), row[Sale.COL_CustomerTerms_DebtLimit], row[Sale.COL_RECEIVABLEAMOUNT], remainingDebtLimit);
                }
                else
                {
                    existing[Sale.COL_RECEIVABLEAMOUNT] = Util.zeroNonNumericString(existing[Sale.COL_RECEIVABLEAMOUNT]) + Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);
                    if(existing[Sale.COL_RemainingDebtLimit] != DBNull.Value)
                        existing[Sale.COL_RemainingDebtLimit] = Util.zeroNonNumericString(existing[Sale.COL_RemainingDebtLimit]) - Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);
                }
            }

            dgvReceivablesSummary.DataSource = dtReceivablesSummary;
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region MENU - SALES

        private void menu_sales_Click_1(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Sales.Main_Form());
        }

        #endregion MENU - SALES
        /*******************************************************************************************************/
        #region MENU - INVENTORY

        private void menu_inventory_samples_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.Samples1_Form(FormMode.New));
        }

        private void menu_inventory_stock_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new InventoryForm.Main_Form());
        }

        private void menu_inventory_opname_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new InventoryForm.ItemCheck_Form());
        }

        private void printBarcodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new InventoryForm.BarcodePrint_Form());
        }

        private void menu_inventory_po_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new POs.Main_Form());
        }

        private void menu_inventory_stocklevel_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Admin.StockLevel_Form(FormMode.New));
        }

        private void menu_inventory_invoices_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Invoices.VendorInvoices_Form());
        }

        #endregion MENU - INVENTORY
        /*******************************************************************************************************/
        #region RETURNS

        private void menu_returns_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Returns.Main_Form());
        }

        #endregion RETURNS
        /*******************************************************************************************************/
        #region MENU - CUSTOMER CREDIT

        private void menu_customercredit_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new CustomerCredits.Main_Form());
        }

        #endregion MENU - CUSTOMER CREDIT
        /*******************************************************************************************************/
        #region MENU - ADMIN
        
        private void menu_admin_vendorinvoices_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Invoices.VendorInvoices_Form());
        }

        private void menu_admin_vendors_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.Vendors_Form(FormMode.Search));
        }

        private void menu_admin_length_units_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.LengthUnits_Form(FormMode.Search));
        }

        private void menu_admin_customers_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.Customers_Form(FormMode.Search));
        }

        private void menu_admin_cities_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Cities_Form(FormMode.Search));
        }

        private void menu_admin_products_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.Products_Form(FormMode.Search));
        }

        private void menu_admin_prices_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Admin.ProductPrices_Form());
        }

        private void menu_admin_widths_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.ProductWidths_Form(FormMode.Search));
        }

        private void menu_admin_colors_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.FabricColors_Form(FormMode.Search));
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Grades_Form(FormMode.Search));
        }

        private void statesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new MasterData.States_Form(FormMode.Search));
        }

        private void menu_admin_productstorenames_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.ProductStoreNames_Form(FormMode.Search));
        }

        private void angkutanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Transports_Form(FormMode.Search));
        }

        private void menu_admin_customersaleadjustments_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_CustomerSaleAdjustments(FormModes.Add));
        }

        private void menu_admin_pettycash_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new FinancialRecords.PettyCash_Form());
        }

        private void menu_admin_pettycashcategories_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.PettyCashRecordsCategories_Form(FormMode.New));
        }

        #endregion MENU - ADMIN
        /*******************************************************************************************************/
        #region MENU - USERS

        private void menu_users_Click_1(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Users.Main_Form());
        }

        #endregion MENU - USERS
        /*******************************************************************************************************/
        #region MENU - TEST

        private void menu_test_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Test.Main_Form());
        }

        #endregion MENU - TEST
        /*******************************************************************************************************/
        #region MENU - QUIT
        
        private void menu_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion MENU - QUIT
        /*******************************************************************************************************/
        #region MENU - REPORTS

        private void menu_reports_financial_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Reports.Financial_Overview_Form());
        }

        private void menu_reports_sales_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Reports.Sales_Form());
        }

        #endregion MENU - REPORTS
        /*******************************************************************************************************/
        #region MENU - REPORTS

        private void menu_samples_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.Samples1_Form(FormMode.New));
        }

        private void menu_reports_tax_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Reports.Taxes_Form());
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - ACCOUNT


        private void menu_account_password_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Users.PasswordChange_Form());
        }

        private void menu_account_salescomission_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Users.SalesComission_Form());
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - TO DO LIST

        private void menu_todolist_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_ToDoList_Form(LIBUtil.FormModes.Add));
        }

        #endregion
        /*******************************************************************************************************/
        #region BUTTONS

        private void btnReceiveShipment_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new InventoryForm.Main_Form());
        }

        private void btnGorden_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Gorden.GordenOrders_Form());
        }

        #endregion BUTTONS
        /*******************************************************************************************************/
        #region CLASS METHODS

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Sales.Add_Edit_Form());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populatePageData();
        }

        private void gridPOItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && GlobalData.UserAccount.role != Roles.User)
                Tools.displayForm(new POs.Print_Form((Guid)gridPOItems.Rows[e.RowIndex].Cells[col_gridPOItems_poid.Name].Value));
        }

        private void gridReceivables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridReceivables_saleBarcode.Name))
            {
                Tools.displayForm(new Sales.Invoice_Form((Guid)gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value));
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridReceivables_amount.Name))
            {
                //var form = new Sales.Payment_Form(new Guid(gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value.ToString()));
                var form = new Invoices.Payment_Form(typeof(Sale), new Guid(gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value.ToString()));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populatePageData();
                }
            }
        }

        private void gridReceivables_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        public void addStatusContextMenu(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (POItemStatus status in Tools.GetEnumItems<POItemStatus>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, changeStatus_Click));
        }

        public void changeStatus_Click(object sender, EventArgs args)
        {
            POItem.updateStatus(selectedPOItemsRowID(), Tools.parseEnum<POItemStatus>(sender.ToString()));
            populatePageData();
        }

        protected Guid selectedPOItemsRowID()
        {
            return (Guid)gridPOItems.SelectedRows[0].Cells[col_gridPOItems_id.Name].Value;
        }

        private void gridPOItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                    gridPOItems.Rows[e.RowIndex].Selected = true;
            }
        }

        private void gridStockLevel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Tools.displayForm(this, new Admin.StockLevel_Form(FormMode.New));
        }

        private void btnSamples_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Admin.Samples1_Form(FormMode.New));
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Invoices.VendorInvoices_Form());
        }

        private void menu_account_log_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(GlobalData.UserAccount.id));
        }

        private void btnShowHidden_Click(object sender, EventArgs e)
        {
            bool value = !col_gridPOItems_PricePerUnit.Visible;
            col_gridPOItems_PricePerUnit.Visible = value;
            col_gridPOItems_PendingQtyValue.Visible = value;
            lblTotalDaftarPiutang.Visible = value;
            lblTotalIncompletePO.Visible = value;
        }

        private void lnkIncompletePO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayForm(null, new POs.MasterData_v1_Status_Form(), false);
        }

        private void menu_admin_customerterms_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Admin.MasterData_v1_CustomerTerms_Form());
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region ----

        #endregion
        /*******************************************************************************************************/
    }
}
