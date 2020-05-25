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

namespace BinaMitraTextile.Sales
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES
            
        int _lastSelectedRow = -1;
        Color _defaultMasterRowBackColor;

        FormModes _startingMode = FormModes.Normal;
        Guid? _BrowsingForFakturPajak_Customers_Id = null;
        Guid? _BrowsingForFakturPajak_Vendors_Id = null;
        public Guid BrowsedItemSelectionId;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form()
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);

            //initialize filter fields
            dtStart.ShowCheckBox = true;
            dtEnd.ShowCheckBox = true;
            Customer.populateInputControlDropDownList(iddl_Customers, true);
            Vendor.populateInputControlDropDownList(iddl_Vendors, true);
            UserAccount.populateInputControlDropDownList(iddl_UserAccounts, true);
            ProductStoreName.populateInputControlCheckedListBox(iclb_ProductStoreNames, true);
            FabricColor.populateInputControlCheckedListBox(iclb_Colors, true);

            clearFilter();
            txtSaleBarcode.MaxLength = Settings.saleBarcodeLength;
            txtInventoryItemBarcode.MaxLength = Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length;

            gridMaster.AutoGenerateColumns = false;
            gridMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMaster.Sort(col_gridmaster_timestamp, ListSortDirection.Descending);
            col_gridmaster_completed.DataPropertyName = Sale.COL_COMPLETED;
            col_gridmaster_profit.DataPropertyName = Sale.COL_PROFIT;
            col_gridmaster_profitpercent.DataPropertyName = Sale.COL_PROFITPERCENT;
            col_gridmaster_specialuseronly.DataPropertyName = Sale.COL_DB_SPECIALUSERONLY;
            col_gridmaster_shippingcost.DataPropertyName = Sale.COL_DB_SHIPPINGCOST;
            col_gridmaster_taxno.DataPropertyName = Sale.COL_DB_TAXNO;
            col_gridmaster_returnedamount.DataPropertyName = Sale.COL_RETURNEDAMOUNT;
            col_gridmaster_taxno.DataPropertyName = Sale.COL_DB_TAXNO;
            col_gridMaster_isManualAdjustment.DataPropertyName = Sale.COL_isManualAdjustment;
            col_gridmaster_SaleCommission_Users_Name.DataPropertyName = Sale.COL_SaleCommission_Users_Name;
            col_gridMaster_Vendors_Name.DataPropertyName = Sale.COL_Vendors_Name;
            col_gridMaster_FakturPajaks_No.DataPropertyName = Sale.COL_FakturPajaks_No;
            col_gridmaster_isReported.DataPropertyName = Sale.COL_DB_ISREPORTED;
            col_gridmaster_isReported.Visible = false;

            gridDetail.AutoGenerateColumns = false;
            col_gridDetail_id.DataPropertyName = SaleItem.COL_INVENTORY_ITEM_ID;

            gridSummary.AutoGenerateColumns = false;
            col_gridsummary_priceperunit.DataPropertyName = SaleItem.COL_SALE_ADJUSTEDPRICE;
            col_gridsummary_buyprice.DataPropertyName = SaleItem.COL_BUYPRICE;
            col_gridSummary_profit.DataPropertyName = SaleItem.COL_PROFIT;
            col_gridSummary_profitpercent.DataPropertyName = SaleItem.COL_PROFITPERCENT;
            col_gridSummary_isManualAdjustment.DataPropertyName = SaleItem.COL_DB_isManualAdjustment;
            col_gridSummary_CommissionAmount.DataPropertyName = SaleItem.COL_TotalCommissionAmount;
            col_gridSummary_CommissionPercent.DataPropertyName = SaleItem.COL_DB_CommissionPercent;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_gridmaster_specialuseronly.Visible = false;
                col_gridmaster_completed.Visible = false;
                col_gridmaster_isReported.Visible = false;
                col_gridmaster_taxno.Visible = false;
                col_gridMaster_isManualAdjustment.Visible = false;
                col_gridmaster_SaleCommission_Users_Name.Visible = false;
                
                col_gridSummary_isManualAdjustment.Visible = false;

                chkOnlyLossProfit.Visible = false;
                btnShowHidden.Visible = false;
                iddl_UserAccounts.Visible = false;

                chkOnlyNotCompleted.Visible = false;

                //Tools.clearWhenSelected(gridMaster);
            }

        }
        public Main_Form(bool hasReceivablesOnly) : this()
        {
            chkOnlyHasReceivable.Checked = true;
            dtStart.Checked = false;
            dtEnd.Checked = false;
        }

        public Main_Form(FormModes startingMode, Guid? BrowsingForFakturPajak_Customers_Id, Guid? BrowsingForFakturPajak_Vendors_Id) : this()
        {
            _startingMode = startingMode;
            _BrowsingForFakturPajak_Customers_Id = BrowsingForFakturPajak_Customers_Id;
            _BrowsingForFakturPajak_Vendors_Id = BrowsingForFakturPajak_Vendors_Id;

            if (_startingMode == FormModes.Browse)
            {
                scMain.Panel1Collapsed = true;
                ptFilterAndButtons.Visible = false;

            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            populateMasterGrid();
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region FILTER CONTROLS

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _lastSelectedRow = -1;
            populateMasterGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFilter();
        }

        private void clearFilter()
        {
            txtSaleBarcode.Text = "";
            txtInventoryItemBarcode.Text = "";
            iddl_Customers.reset();
            iddl_UserAccounts.reset();
            chkOnlyWithCommission.Checked = false;
            chkOnlyHasReceivable.Checked = false;
            chkOnlyManualAdjustment.Checked = false;
            chkOnlyNotCompleted.Checked = false;
            chkOnlyLossProfit.Checked = false;
            iclb_ProductStoreNames.reset();
            iclb_Colors.reset();

            //set default date range
            dtEnd.Value = DateTime.Now;
            dtStart.Value = dtEnd.Value.AddDays(-30);
            dtStart.Checked = true;
            dtEnd.Checked = false;
        }

        #endregion FILTER CONTROLS
        /*******************************************************************************************************/
        #region LIST

        private void populateMasterGrid()
        {
            //sale barcode
            Guid? saleID = null;
            txtSaleBarcode.Text = txtSaleBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(txtSaleBarcode.Text))
            {
                if (!Tools.isHexNumber(txtSaleBarcode.Text))
                {
                    Tools.hasMessage(String.Format("{0} is an invalid invoice barcode", txtSaleBarcode.Text));
                    txtSaleBarcode.Focus();
                }
                else
                {
                    try
                    {
                        saleID = Sale.getIDByBarcode(txtSaleBarcode.Text);
                    }
                    catch (Exception ex)
                    {
                        Tools.hasMessage(String.Format("{0} does not exist in database", txtSaleBarcode.Text));
                        return;
                    }
                }
            }

            //item barcode
            Guid? inventoryItemID = null;
            txtInventoryItemBarcode.Text = txtInventoryItemBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(txtInventoryItemBarcode.Text))
            {
                if (!InventoryItem.isValidBarcode(txtInventoryItemBarcode.Text))
                {
                    txtInventoryItemBarcode.Focus();
                }
                else
                {
                    try
                    {
                        inventoryItemID = InventoryItem.getIDByBarcode(InventoryItem.getBarcodeWithoutPrefix(txtInventoryItemBarcode.Text));
                    }
                    catch (Exception ex)
                    {
                        Tools.hasMessage(String.Format("{0} does not exist in database", txtSaleBarcode.Text));
                        return;
                    }
                }
            }

            if(!string.IsNullOrWhiteSpace(itxt_InventoryCode.ValueText))
            {
                if (!itxt_InventoryCode.isNumeric())
                {
                    itxt_InventoryCode.isValueError("Invalid Inventory Code");
                    return;
                }
            }

            if (_startingMode == FormModes.Browse)
            {
                Tools.setGridviewDataSource(gridMaster, true, true, Sale.get_by_BrowsingForFakturPajak((Guid?)_BrowsingForFakturPajak_Customers_Id, (Guid?)_BrowsingForFakturPajak_Vendors_Id));
            }
            else
            {
                Tools.setGridviewDataSource(gridMaster, true, true,
                    Sale.get(
                        Tools.getDate(dtStart, false),
                        Tools.getDate(dtEnd, true),
                        inventoryItemID,
                        (Guid?)iddl_Customers.SelectedValue,
                        (Guid?)iddl_Vendors.SelectedValue,
                        saleID,
                        chkOnlyHasReceivable.Checked,
                        false,
                        chkOnlyLossProfit.Checked,
                        chkReturnedToSupplier.Checked,
                        chkOnlyWithCommission.Checked,
                        (Guid?)iddl_UserAccounts.SelectedValue,
                        iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                        iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                        chkOnlyNotCompleted.Checked,
                        chkOnlyManualAdjustment.Checked,
                        itxt_InventoryCode.ValueText,
                        null,
                        null,
                        null,
                        null,
                        false,
                        false)
                    );
            }

            showCommissionInfo();

            if (gridMaster.Rows.Count > 0 && GlobalData.UserAccount.role != Roles.User)
            {
                btnLog.Enabled = true;
                btnUpdate.Enabled = true;
                lblTaxInfo.Visible = true;
                lblTaxInfo.Text = string.Format("Reported: {0:N2}", Tools.getSum((DataTable)gridMaster.DataSource, Sale.COL_SALEAMOUNT, Sale.COL_DB_ISREPORTED + "=true"));
            }
            else
            {
                btnLog.Enabled = false;
                btnUpdate.Enabled = true;
                lblTaxInfo.Visible = false;
            }

            gridDetail.DataSource = null;
            gridSummary.DataSource = null;
        }

        private void showCommissionInfo()
        {
            if (chkOnlyWithCommission.Checked)
            {
                string info = "";

                decimal sales = Tools.getSum((DataTable)gridMaster.DataSource, Sale.COL_SALEAMOUNT, "");
                decimal returns = Tools.getSum((DataTable)gridMaster.DataSource, Sale.COL_RETURNEDAMOUNT, "");
                decimal commission = Tools.getSum((DataTable)gridMaster.DataSource, Sale.COL_CommissionAmount, "");

                if (iddl_UserAccounts.hasSelectedValue())
                    info = LIBUtil.Util.append(info, string.Format("Sales: {0}", iddl_UserAccounts.getSelectedValue<string>(UserAccount.COL_DB_NAME)), Environment.NewLine);
                info = LIBUtil.Util.append(info, string.Format("Total Sales: {0:N2}", sales), Environment.NewLine);
                info = LIBUtil.Util.append(info, string.Format("Returns: {0:N2}", returns), Environment.NewLine);
                info = LIBUtil.Util.append(info, string.Format("Komisi: {0:N2}", commission), Environment.NewLine);

                LIBUtil.Util.displayMessageBox("", info);
            }
        }

        private void populateDetails(Guid SaleID)
        {
            gridSummary.DataSource = SaleItem.getItemSummary(SaleID);
            gridSummary.Sort(col_gridsummary_code, ListSortDirection.Ascending);

            gridDetail.DataSource = SaleItem.getItems(SaleID);
            gridDetail.Sort(gridDetail.Columns[col_gridDetail_barcode.Name], ListSortDirection.Ascending);
        }

        private void gridMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), Sale.COL_HEXBARCODE))
            {
                Sale sale = new Sale(new Guid(gridMaster.Rows[e.RowIndex].Cells[col_gridmaster_saleid.Name].Value.ToString()));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populateMasterGrid();
                }
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), gridMasterSaleAmount.Name))
            {
                var form = new Invoices.Payment_Form(typeof(Sale), new Guid(gridMaster.Rows[e.RowIndex].Cells[col_gridmaster_saleid.Name].Value.ToString()));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populateMasterGrid();
                }
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_gridmaster_completed.Name))
            {
                DataGridViewRow row = gridMaster.Rows[e.RowIndex];
                Sale.updateCompleted((Guid)row.Cells[col_gridmaster_saleid.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                populateMasterGrid();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_gridmaster_specialuseronly.Name))
            {
                DataGridViewRow row = gridMaster.Rows[e.RowIndex];
                Sale.updateSpecialUserOnly((Guid)row.Cells[col_gridmaster_saleid.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                populateMasterGrid();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_gridmaster_isReported.Name))
            {
                DataGridViewRow row = gridMaster.Rows[e.RowIndex];
                Sale.updateIsReported((Guid)row.Cells[col_gridmaster_saleid.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                populateMasterGrid();
            }
        }

        private void gridMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridmaster_taxno.Name))
            {
                DataGridViewRow row = gridMaster.Rows[e.RowIndex];
                Tools.displayForm(new Sales.TaxNo_Edit_Form((Guid)row.Cells[col_gridmaster_saleid.Name].Value));
                populateMasterGrid();
            }
        }

        private void gridMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //header row

            if(_startingMode == FormModes.Browse)
            {
                BrowsedItemSelectionId = (Guid)Util.getSelectedRowValue(sender, col_gridmaster_saleid);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //reset previous row back color
                if (_lastSelectedRow > -1)
                    gridMaster.Rows[_lastSelectedRow].DefaultCellStyle.BackColor = _defaultMasterRowBackColor;

                //show details and summary
                if (!pnlSummaryAndDetails.Visible)
                    ptSummaryAndDetails.toggle();
                populateDetails(new Guid(gridMaster.Rows[e.RowIndex].Cells[col_gridmaster_saleid.Name].Value.ToString()));

                _lastSelectedRow = e.RowIndex; //save current row index for resetting the row back color later
                _defaultMasterRowBackColor = gridMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor; //save original row back color
                gridMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue; //change row back color
            }
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridDetail_barcode.Name))
            {
                Tools.displayForm(new Logs.Main_Form(new Guid(gridDetail.Rows[e.RowIndex].Cells[col_gridDetail_id.Name].Value.ToString())));
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region FORM METHODS

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Sales.Add_Edit_Form());
            populateMasterGrid();
        }

        private void btnShowHidden_Click(object sender, EventArgs e)
        {
            col_gridmaster_specialuseronly.Visible = !col_gridmaster_specialuseronly.Visible;
            col_gridmaster_profit.Visible = !col_gridmaster_profit.Visible;
            col_gridmaster_profitpercent.Visible = !col_gridmaster_profitpercent.Visible;

            col_gridsummary_buyprice.Visible = !col_gridsummary_buyprice.Visible;
            col_gridSummary_profitpercent.Visible = !col_gridSummary_profitpercent.Visible;
            col_gridSummary_profit.Visible = !col_gridSummary_profit.Visible;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Sales.Add_Edit_Form((Guid)gridMaster.SelectedRows[0].Cells[col_gridmaster_saleid.Name].Value));
            populateMasterGrid();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(selectedRowID()));
        }

        protected Guid selectedRowID()
        {
            return (Guid)gridMaster.SelectedRows[0].Cells[col_gridmaster_saleid.Name].Value;
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            ptSummaryAndDetails.toggle();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                if (Util.copyContentToClipboardIfGridview(this))
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/

    }
}
