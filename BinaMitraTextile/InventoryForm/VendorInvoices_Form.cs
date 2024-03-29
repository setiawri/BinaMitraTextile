﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile.InventoryForm
{
    public partial class VendorInvoices_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        FormModes _startingMode = FormModes.Normal;
        Guid? _BrowsingForFakturPajak_Vendors_Id = null;
        public Guid BrowsedItemSelectionId;

        private bool isFormShown = false;
        private bool _createVendorInvoicePayment = false;
        private Guid _clickedInventoryID;

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public VendorInvoices_Form()
        {
            InitializeComponent();
        }

        public VendorInvoices_Form(string quickSearchText) : this()
        {
            itxt_QuickSearch.ValueText = quickSearchText.Trim();
            if(itxt_QuickSearch.ValueText != "")
                chkShowOnlyIncomplete.Checked = false;
            
        }

        public VendorInvoices_Form(FormModes startingMode, Guid BrowsingForFakturPajak_Vendors_Id) : this()
        {
            _startingMode = startingMode;
            _BrowsingForFakturPajak_Vendors_Id = BrowsingForFakturPajak_Vendors_Id;

            if (_startingMode == FormModes.Browse)
            {
                pnlFilterAndButtons.Visible = false;
                chkShowOnlyIncomplete.Visible = false;
                chkShowOnlyVendorUsesFakturPajak.Visible = false;
            }
        }
        
        #endregion
        /*******************************************************************************************************/
        #region FORM METHODS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            setupControlsBasedOnRoles();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            isFormShown = true;
            populateGridVendorInvoices();
        }

        public void setupControls()
        {
            Settings.setGeneralSettings(this);

            Vendor.populateInputControlDropDownList(iddl_Vendors, true);
            idtp_Timestamp_Start.Value = Util.getFirstDayOfSelectedMonth(DateTime.Now.AddMonths(-6));

            createVendorInvoicePaymentMode(false);
            lblVendorInvoicePayment.Text = "0";
            idtp_VendorInvoicePaymentDate.Value = DateTime.Now;
            calculateDueAmount();
            calculatePayableAmount();

            gridvendorinvoice.AutoGenerateColumns = false;
            gridvendorinvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridvendorinvoice_id.DataPropertyName = VendorInvoice.COL_DB_Id;
            col_gridvendorinvoice_timestamp.DataPropertyName = VendorInvoice.COL_DB_Timestamp;
            col_gridvendorinvoice_invoiceno.DataPropertyName = VendorInvoice.COL_DB_InvoiceNo;
            col_gridvendorinvoice_Vendors_Id.DataPropertyName = VendorInvoice.COL_DB_Vendors_Id;
            col_gridvendorinvoice_vendorname.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridvendorinvoice_ReturnedValue.DataPropertyName = VendorInvoice.COL_ReturnedValue;
            col_gridvendorinvoice_CalculatedAmount.DataPropertyName = VendorInvoice.COL_CalculatedAmount;
            col_gridvendorinvoice_AmountDifferenceFromCalculated.DataPropertyName = VendorInvoice.COL_AmountDifferenceFromCalculated;
            col_gridVendorInvoices_Approved.DataPropertyName = VendorInvoice.COL_DB_Approved;
            col_gridvendorinvoice_top.DataPropertyName = VendorInvoice.COL_DB_TOP;
            col_gridVendorInvoice_DaysPastDue.DataPropertyName = VendorInvoice.COL_DaysPastDue;
            col_gridvendorinvoice_isdue.DataPropertyName = VendorInvoice.COL_IsDue;
            col_gridVendorInvoice_PaidAmount.DataPropertyName = VendorInvoice.COL_PaidAmount;
            col_gridvendorinvoice_PayableAmount.DataPropertyName = VendorInvoice.COL_PayableAmount;
            col_gridVendorInvoice_PaymentAmount.DataPropertyName = VendorInvoice.COL_PaymentAmount;
            col_gridvendorinvoice_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
            col_gridVendorInvoice_FakturPajaks_Id.DataPropertyName = VendorInvoice.COL_DB_FakturPajaks_Id;
            col_gridVendorInvoice_FakturPajaks_No.DataPropertyName = VendorInvoice.COL_FakturPajaks_No;
            col_gridvendorinvoice_timestamp2.DataPropertyName = VendorInvoice.COL_DB_Timestamp; col_gridvendorinvoice_timestamp2.Visible = false;
            col_gridvendorinvoice_DPP.DataPropertyName = VendorInvoice.COL_FakturPajaks_DPP; col_gridvendorinvoice_DPP.Visible = false;
            col_gridvendorinvoice_FakturPajaks_Amount.DataPropertyName = VendorInvoice.COL_FakturPajaks_Amount;
            col_gridvendorinvoice_AmountDifferenceFromFakturPajaksAmount.DataPropertyName = VendorInvoice.COL_AmountDifferenceFromFakturPajaksAmount;
            col_gridvendorinvoice_notes.DataPropertyName = VendorInvoice.COL_DB_Notes;
            col_gridvendorinvoice_notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gridInventory.AutoGenerateColumns = false;
            gridInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridinventory_id.DataPropertyName = Inventory.COL_DB_ID;
            col_gridinventory_receivedate.DataPropertyName = Inventory.COL_DB_RECEIVEDATE;
            col_gridinventory_code.DataPropertyName = Inventory.COL_DB_CODE;
            col_gridinventory_gradename.DataPropertyName = Inventory.COL_GRADE_NAME;
            col_gridinventory_productname.DataPropertyName = Inventory.COL_PRODUCTSTORENAME;
            col_gridinventory_productwidthname.DataPropertyName = Inventory.COL_PRODUCT_WIDTH_NAME;
            col_gridinventory_colorname.DataPropertyName = Inventory.COL_COLOR_NAME;
            col_gridInventory_ItemLength.DataPropertyName = Inventory.COL_ITEMLENGTH;
            col_gridinventory_buyprice.DataPropertyName = Inventory.COL_DB_BUYPRICE;
            col_gridinventory_unitname.DataPropertyName = Inventory.COL_LENGTH_UNIT_NAME;
            col_gridInventory_BuyValue.DataPropertyName = Inventory.COL_BUYVALUE;
            col_gridinventory_packinglistno.DataPropertyName = Inventory.COL_DB_PACKINGLISTNO;
            col_gridInventory_Notes.DataPropertyName = Inventory.COL_DB_NOTES;
            col_gridInventory_Notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col_gridinventory_POItems_PricePerUnit.DataPropertyName = Inventory.COL_POItems_PricePerUnit;

            gridSaleInvoices.AutoGenerateColumns = false;
            gridSaleInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSaleInvoices_NonReturnedAmount.DataPropertyName = Sale.COL_NonReturnedAmount;
            col_gridSaleInvoices_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;
            col_gridSaleInvoices_FakturPajaks_Id.DataPropertyName = Sale.COL_DB_FakturPajaks_Id;
            col_gridSaleInvoices_FakturPajaks_No.DataPropertyName = Sale.COL_FakturPajaks_No;

        }

        protected void setupControlsBasedOnRoles()
        {
            if(GlobalData.UserAccount.role != Roles.Super && GlobalData.UserAccount.role != Roles.Assistant)
            {
                col_gridinventory_POItems_PricePerUnit.Visible = false;
            }
        }

        public void populateGridVendorInvoices()
        {
            DataView dvw;

            gridvendorinvoice.AutoGenerateColumns = false; //the line in setupControls() is not working??
            if (_startingMode == FormModes.Browse)
                dvw = VendorInvoice.get_by_BrowsingForFakturPajak_Vendors_Id((Guid)_BrowsingForFakturPajak_Vendors_Id, idtp_Timestamp_Start.ValueAsStartDateFilter, idtp_Timestamp_End.ValueAsEndDateFilter).DefaultView;
            else if(_createVendorInvoicePayment)
                dvw = VendorInvoice.get(null, null, (Guid)iddl_Vendors.SelectedValue, chkShowOnlyIncomplete.Checked, chkShowOnlyVendorUsesFakturPajak.Checked, idtp_Timestamp_Start.ValueAsStartDateFilter, idtp_Timestamp_End.ValueAsEndDateFilter, null, null, false).DefaultView;
            else
                dvw = VendorInvoice.get(null, null, null, chkShowOnlyIncomplete.Checked, chkShowOnlyVendorUsesFakturPajak.Checked, idtp_Timestamp_Start.ValueAsStartDateFilter, idtp_Timestamp_End.ValueAsEndDateFilter, null, null, false).DefaultView;

            string[] fieldNames = { VendorInvoice.COL_VendorName, VendorInvoice.COL_DB_InvoiceNo, VendorInvoice.COL_FakturPajaks_No };
            dvw.RowFilter = Util.compileQuickSearchFilter(itxt_QuickSearch.ValueText, fieldNames);
            Util.setGridviewDataSource(gridvendorinvoice, dvw);

            createVendorInvoicePaymentMode(_createVendorInvoicePayment);
            calculateGrandTotalPayableAmount();

            pbLog.Enabled = gridvendorinvoice.Rows.Count > 0;
        }

        private void populateGridInventory()
        {
            DataTable data = Inventory.getAll(true, false, null, null, null, null, null, null, null, Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id), false, null);
            data = Util.sortData(data, Inventory.COL_DB_CODE, SortOrder.Ascending, null, null);
            Tools.setGridviewDataSource(gridInventory, false, false, data);
            lblSaleInvoices.Text = string.Format("Sale Invoices: {0:N2}", Util.compute(data, "SUM", Inventory.COL_BUYVALUE, ""));
        }

        private void createVendorInvoicePaymentMode(bool value)
        {
            _createVendorInvoicePayment = value;
            iddl_Vendors.Enabled = !value;
            btnStartVendorPayments.Enabled = !value;
            gbVendorInvoicePayment.Enabled = value;
            col_gridVendorInvoice_PaymentAmount.Visible = value;
            col_gridVendorInvoice_TogglePayment.Visible = value;

            if(_createVendorInvoicePayment)
            {
                chkShowOnlyIncomplete.Checked = true;
                chkShowOnlyVendorUsesFakturPajak.Checked = false;
            }

            if (value)
                in_AvailableFund.focus();
            else
            {
                iddl_Vendors.reset();
                iddl_Vendors.focus();
            }

            calculateVendorInvoicePaymentAmount();
        }

        private void calculateVendorInvoicePaymentAmount()
        {
            decimal paymentAmount = 0;
            if (_createVendorInvoicePayment)
            {
                foreach (DataGridViewRow row in gridvendorinvoice.Rows)
                    paymentAmount += Util.wrapNullable<decimal>(Util.getRowValue(row, col_gridVendorInvoice_PaymentAmount));
            }

            lblVendorInvoicePayment.Text = string.Format("{0:N2}", paymentAmount);
            if (in_AvailableFund.Value > 0)
                lblAvailableFund.Text = string.Format("available: {0:N2}", in_AvailableFund.Value - paymentAmount);
            else
                lblAvailableFund.Text = "";
        }

        private void showEditBuyPriceForm()
        {
            Util.displayForm(new VendorInvoices_Edit_Form(Util.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
            populateGridVendorInvoices();
        }

        private void calculateDueAmount()
        {
            lblDueAmount.Text = "";
            if (isFormShown && iddl_Vendors.hasSelectedValue())
            {
                string filter = string.Format("{0} = '{1}' AND {2}=1", VendorInvoice.COL_DB_Vendors_Id, iddl_Vendors.SelectedValue, VendorInvoice.COL_IsDue);
                lblDueAmount.Text = string.Format("due:{0:N0}",
                    Util.compute(Util.getDataTable(gridvendorinvoice.DataSource), "SUM", VendorInvoice.COL_PayableAmount, filter));
            }
        }

        private void calculatePayableAmount()
        {
            lblPayableAmount.Text = "";
            if (isFormShown && iddl_Vendors.hasSelectedValue())
            {
                string filter = string.Format("{0} = '{1}'", VendorInvoice.COL_DB_Vendors_Id, iddl_Vendors.SelectedValue);
                lblPayableAmount.Text = string.Format("payable:{0:N0}", Util.compute(Util.getDataTable(gridvendorinvoice.DataSource), "SUM", VendorInvoice.COL_PayableAmount, filter));
            }
        }

        private void calculateGrandTotalPayableAmount()
        {
            if (isFormShown)
                lblGrandTotalPayable.Text = string.Format("Total Payable:{0:N0}", Util.compute(Util.getDataTable(gridvendorinvoice.DataSource), "SUM", VendorInvoice.COL_PayableAmount, ""));
        }

        private void hideColumns(bool hide)
        {
            col_gridvendorinvoice_CalculatedAmount.Visible = !hide;
            col_gridvendorinvoice_AmountDifferenceFromCalculated.Visible = !hide;
            col_gridvendorinvoice_ReturnedValue.Visible = !hide;
            col_gridVendorInvoice_PaidAmount.Visible = !hide;
            col_gridvendorinvoice_top.Visible = !hide;
            col_gridVendorInvoice_DaysPastDue.Visible = !hide;
            col_gridvendorinvoice_isdue.Visible = !hide;
            col_gridVendorInvoice_FakturPajaks_No.Visible = !hide;
            col_gridvendorinvoice_FakturPajaks_Amount.Visible = !hide;
            col_gridvendorinvoice_AmountDifferenceFromFakturPajaksAmount.Visible = !hide;
            col_gridvendorinvoice_notes.Visible = !hide;
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void gridvendorinvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (isFormShown && gridvendorinvoice.SelectedRows.Count > 0 && ptRowInfo.isPanelOpen)
            {
                populateGridInventory();

                DataTable data = Sale.get_by_VendorInvoices_Id(Util.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id));
                Util.setGridviewDataSource(gridSaleInvoices, false, false, data);
                lblReturns.Text = string.Format("Returns: {0:N2}", Util.compute(data, "SUM", Sale.COL_SALEAMOUNT, ""));
            }
        }

        private void btnSupplierDebits_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Invoices.VendorDebits_Form());
        }

        private void gridvendorinvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridvendorinvoice_PayableAmount.Name))
            {
                var form = new Invoices.Payment_Form(typeof(VendorInvoice), new Guid(gridvendorinvoice.Rows[e.RowIndex].Cells[col_gridvendorinvoice_id.Name].Value.ToString()));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populateGridVendorInvoices();
                }
            }
            else if(Util.isColumnMatch(sender, e, col_gridVendorInvoice_TogglePayment))
            {
                decimal value = Util.wrapNullable<decimal>(Util.getClickedRowValue(sender, e, col_gridVendorInvoice_PaymentAmount));
                if (value != 0)
                    value = 0;
                else
                    value = Util.wrapNullable<decimal>(Util.getClickedRowValue(sender, e, col_gridvendorinvoice_PayableAmount));
                Util.setRowValue(sender, e, col_gridVendorInvoice_PaymentAmount, value);
            }
            else if (Util.isColumnMatch(sender, e, col_gridVendorInvoice_PaidAmount))
            {
                VendorInvoicePayments_Form form = (VendorInvoicePayments_Form)Util.displayMDIChild(new VendorInvoicePayments_Form());
                form.searchVendorInvoiceNo(Util.getClickedRowValue(sender, e, col_gridvendorinvoice_invoiceno).ToString());
            }
            else if (Util.isColumnMatch(sender, e, col_gridVendorInvoices_Approved))
            {
                VendorInvoice.update_Approved(Util.getClickedRowValue<Guid>(sender, e, col_gridvendorinvoice_id), !Util.getCheckboxValue(sender, e));
                populateGridVendorInvoices();
            }
        }

        private void GridSaleInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_hexbarcode))
                Util.displayForm(new Sales.Invoice_Form((Guid)Util.getClickedRowValue(sender, e, col_gridSaleInvoices_Sales_id)));
        }

        private void GridInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridinventory_code))
                Util.displayForm(new InventoryForm.Items_Form((Guid)Util.getClickedRowValue(sender, e, col_gridinventory_id)));
        }

        private void Gridvendorinvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //header row

            if (_startingMode == FormModes.Browse)
            {
                BrowsedItemSelectionId = (Guid)Util.getSelectedRowValue(sender, col_gridvendorinvoice_id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                showEditBuyPriceForm();
            }
        }

        private void ChkShowOnlyIncomplete_CheckedChanged(object sender, EventArgs e)
        {
            if (!_createVendorInvoicePayment)
                populateGridVendorInvoices();
        }

        private void ChkShowOnlyVendorUsesFakturPajak_CheckedChanged(object sender, EventArgs e)
        {
            if (!_createVendorInvoicePayment)
                populateGridVendorInvoices();
        }

        private void ChkShowOnlyLast6Months_CheckedChanged(object sender, EventArgs e)
        {
            if (!_createVendorInvoicePayment)
                populateGridVendorInvoices();
        }

        private void BtnStartVendorPayments_Click(object sender, EventArgs e)
        {
            if (!iddl_Vendors.hasSelectedValue())
                iddl_Vendors.SelectedValueError("Select a vendor");
            else
            {
                autoSetPaymentBasedOnSelectedVendor();
                createVendorInvoicePaymentMode(true);
            }
        }

        private void autoSetPaymentBasedOnSelectedVendor()
        {
            //detach event handler
            this.gridvendorinvoice.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridvendorinvoice_CellValueChanged);

            string VendorId = iddl_Vendors.SelectedValue.ToString();
            foreach (DataGridViewRow row in gridvendorinvoice.Rows)
            {
                if (Util.getRowValue(row, col_gridvendorinvoice_Vendors_Id).ToString() != VendorId)
                    Util.setRowValue(row, col_gridVendorInvoice_PaymentAmount, 0);
                else if((bool)Util.getRowValue(row, col_gridvendorinvoice_isdue))
                    Util.setRowValue(row, col_gridVendorInvoice_PaymentAmount, Util.getRowValue(row, col_gridvendorinvoice_PayableAmount));
            }

            //reattach event handler
            this.gridvendorinvoice.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridvendorinvoice_CellValueChanged);
        }

        private void BtnSubmitVendorPayments_Click(object sender, EventArgs e)
        {
            decimal paymentAmount;
            Dictionary<Guid, decimal> paymentData = new Dictionary<Guid, decimal>();
            string VendorId = iddl_Vendors.SelectedValue.ToString();
            foreach (DataGridViewRow row in gridvendorinvoice.Rows)
            {
                if (Util.getRowValue(row, col_gridvendorinvoice_Vendors_Id).ToString() == VendorId)
                {
                    paymentAmount = Util.wrapNullable<decimal>(Util.getRowValue(row, col_gridVendorInvoice_PaymentAmount));
                    if (paymentAmount != 0)
                        paymentData.Add(Util.wrapNullable<Guid>(Util.getRowValue(row, col_gridvendorinvoice_id)), paymentAmount);
                }
            }
            VendorInvoicePayment.add((DateTime)idtp_VendorInvoicePaymentDate.ValueAsStartDateFilter, (Guid)iddl_Vendors.SelectedValue, null, paymentData);

            createVendorInvoicePaymentMode(false);
            populateGridVendorInvoices();
        }

        private void BtnCancelVendorPayments_Click(object sender, EventArgs e)
        {
            createVendorInvoicePaymentMode(false);
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            populateGridVendorInvoices();
        }

        private void PbLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
        }

        private void Gridvendorinvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_gridVendorInvoice_PaymentAmount))
            {
                calculateVendorInvoicePaymentAmount();
            }
        }

        private void Gridvendorinvoice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && Util.isColumnMatch(sender, e, col_gridVendorInvoice_PaymentAmount))
            {
                Util.displayMessageBoxError("Invalid payment value");
            }
        }

        private void BtnClearVendorInvoicePayment_Click(object sender, EventArgs e)
        {
            if (_createVendorInvoicePayment)
            {
                this.gridvendorinvoice.CellValueChanged -= new DataGridViewCellEventHandler(Gridvendorinvoice_CellValueChanged);

                foreach (DataGridViewRow row in gridvendorinvoice.Rows)
                    Util.setRowValue(row, col_gridVendorInvoice_PaymentAmount, 0);

                this.gridvendorinvoice.CellValueChanged += new DataGridViewCellEventHandler(Gridvendorinvoice_CellValueChanged);
                calculateVendorInvoicePaymentAmount();
            }
        }

        private void BtnApplyMaxPayment_Click(object sender, EventArgs e)
        {
        }

        private void GridInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridinventory_buyprice) && GlobalData.UserAccount.role == Roles.Super)
            {
                pnlUpdateBuyPrice.Visible = true;
                _clickedInventoryID = (Guid)Util.getClickedRowValue(sender, e, col_gridinventory_id);
                Inventory obj = new Inventory(_clickedInventoryID);
                in_BuyPrice.Value = obj.buy_price;
                in_BuyPrice.focus();
            }
        }

        private void BtnCancelUpdateBuyPrice_Click(object sender, EventArgs e)
        {
            in_BuyPrice.Value = 0;
            pnlUpdateBuyPrice.Visible = false;
        }

        private void BtnUpdateBuyPrice_Click(object sender, EventArgs e)
        {
            Inventory.updateBuyPrice(_clickedInventoryID, in_BuyPrice.ValueDecimal);
            in_BuyPrice.Value = 0;
            pnlUpdateBuyPrice.Visible = false;
            populateGridInventory();
            populateGridVendorInvoices();
        }

        private void In_BuyPrice_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnUpdateBuyPrice.PerformClick();
        }

        private void Iddl_Vendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateDueAmount();
            calculatePayableAmount();
        }

        private void In_AvailableFund_ValueChanged(object sender, EventArgs e)
        {
            calculateVendorInvoicePaymentAmount();
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

        private void itxt_QuickSearch_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                populateGridVendorInvoices();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            populateGridVendorInvoices();
        }

        private void chkHideColumns_CheckedChanged(object sender, EventArgs e)
        {
            hideColumns(chkHideColumns.Checked); 
        }

        #endregion
        /*******************************************************************************************************/
    }
}
