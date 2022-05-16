using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

using LIBUtil;

namespace BinaMitraTextile.SharedForms
{
    public partial class MasterData_v1_FakturPajaks_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private DataGridViewColumn col_dgv_No;
        private DataGridViewColumn col_dgv_Timestamp;
        private DataGridViewColumn col_dgv_Customers_Id;
        private DataGridViewColumn col_dgv_Customers_Name;
        private DataGridViewColumn col_dgv_Vendors_Id;
        private DataGridViewColumn col_dgv_Vendors_Name;
        private DataGridViewColumn col_dgv_DPP;
        private DataGridViewColumn col_dgv_PPN;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_TotalAmount;
        private DataGridViewColumn col_dgv_AssignedAmount;
        private DataGridViewColumn col_dgv_AmountDifference;

        private Guid? _lastSelectedFakturPajaks_Id = null;

        private const string TABTITLE_SaleInvoices = "Sale Invoices";
        private const string TABTITLE_VendorInvoices = "Vendor Invoices";
        private const string TABTITLE_SaleReturns = "Sale Returns";

        FormModes _startingMode = FormModes.Normal;
        Guid? _BrowsingForFakturPajak_Customers_Id = null;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_FakturPajaks_Form() : this(FormModes.Add) { }
        public MasterData_v1_FakturPajaks_Form(FormModes startingMode, Guid BrowsingForFakturPajak_Customers_Id) : this(startingMode)
        {
            _startingMode = startingMode;
            _BrowsingForFakturPajak_Customers_Id = BrowsingForFakturPajak_Customers_Id;
            if (_startingMode == FormModes.Browse)
            {
                scMain.Panel1Collapsed = true;
            }
        }
        public MasterData_v1_FakturPajaks_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void populateGridSaleInvoices(bool repopulateGridFakturPajak)
        {
            DataTable data = Sale.get_by_FakturPajaks_Id(selectedRowID());
            Util.setGridviewDataSource(gridSaleInvoices, false, false, data);

            tpSaleInvoices.Text = string.Format("{0}: {1:N2}", TABTITLE_SaleInvoices, Util.compute(data, "SUM", Sale.COL_SALEAMOUNT, ""));
            if(repopulateGridFakturPajak)
                populateGridViewDataSource(true);
        }

        private void populateGridReturns(bool repopulateGridFakturPajak)
        {
            DataTable data = SaleReturn.get_by_FakturPajaks_Id(selectedRowID());
            Util.setGridviewDataSource(gridReturns, false, false, data);
            tpSaleReturns.Text = string.Format("{0}: {1:N2}", TABTITLE_SaleReturns, -1*Util.compute(data, "SUM", SaleReturn.COL_RETURNAMOUNT, ""));
            if (repopulateGridFakturPajak)
                populateGridViewDataSource(true);
        }

        private void populateGridVendorInvoices(bool repopulateGridFakturPajak)
        {
            DataTable data = VendorInvoice.get_by_FakturPajaks_Id(selectedRowID());
            Util.setGridviewDataSource(gridVendorInvoices, false, false, data);
            tpVendorInvoices.Text = string.Format("{0}: {1:N2}", TABTITLE_VendorInvoices, Util.compute(data, "SUM", VendorInvoice.COL_DB_Amount, ""));
            if (repopulateGridFakturPajak)
                populateGridViewDataSource(true);
        }

        #endregion
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            FieldnamesForQuickSearch.Add(FakturPajak.COL_DB_No);
            setColumnsDataPropertyNames(FakturPajak.COL_DB_Id, null, null, null, null, FakturPajak.COL_DB_Completed) ;
            col_dgv_Checkbox1.HeaderText = "Lock";

            col_dgv_No = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_No", "No", FakturPajak.COL_DB_No, true, true, "", true, false, 20, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Timestamp = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Timestamp", idtp_Timestamp.LabelText, FakturPajak.COL_DB_Timestamp, true, true, "dd/MM/yy", false, false, 40, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Vendors_Id = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Vendors_Id", "Vendors_Id", FakturPajak.COL_DB_Vendors_Id, true, false, "", false, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Vendors_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Vendors_Name", iddl_Vendors.LabelText, FakturPajak.COL_Vendors_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Customers_Id = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Id", "Customers_Id", FakturPajak.COL_DB_Customers_Id, true, false, "", false, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Customers_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Name", iddl_Customers.LabelText, FakturPajak.COL_Customers_Name, true, true, "", true, false, 55, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_DPP = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_DPP", in_DPP.LabelText, FakturPajak.COL_DB_DPP, true, true, "N2", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_dgv_PPN = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_PPN", in_PPN.LabelText, FakturPajak.COL_DB_PPN, true, true, "N2", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_dgv_TotalAmount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_TotalAmount", "Total", FakturPajak.COL_TotalAmount, true, true, "N2", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_dgv_AssignedAmount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_AssignedAmount", "Assigned", FakturPajak.COL_AssignedAmount, true, true, "N2", false, false, 50, DataGridViewContentAlignment.MiddleRight);
            col_dgv_AmountDifference = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MissingAmount", "Diff", FakturPajak.COL_AmountDifference, true, true, "N2", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            Util.updateForeColor(col_dgv_AmountDifference, Color.Red);
            Util.updateFontStyle(col_dgv_AmountDifference, FontStyle.Bold);

            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, FakturPajak.COL_DB_Notes, true, true, "", true, false, 30, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            gridSaleInvoices.AutoGenerateColumns = false;
            gridSaleInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSaleInvoices_ReceivableAmount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridSaleInvoices_returnedamount.DataPropertyName = Sale.COL_RETURNEDAMOUNT;
            col_gridSaleInvoices_SaleAmount.DataPropertyName = Sale.COL_SALEAMOUNT;
            col_gridSaleInvoices_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_shippingcost.DataPropertyName = Sale.COL_DB_SHIPPINGCOST;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;

            gridReturns.AutoGenerateColumns = false;
            gridReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridReturns_customer_name.DataPropertyName = SaleReturn.COL_Customers_Name;
            col_gridReturns_hexbarcode.DataPropertyName = SaleReturn.COL_HEXBARCODE;
            col_gridReturns_id.DataPropertyName = SaleReturn.COL_ID;
            col_gridReturns_sale_amount.DataPropertyName = SaleReturn.COL_RETURNAMOUNT;
            col_gridReturns_sale_length.DataPropertyName = SaleReturn.COL_SaleLength;
            col_gridReturns_sale_qty.DataPropertyName = SaleReturn.COL_SaleQty;
            col_gridReturns_Timestamp.DataPropertyName = SaleReturn.COL_DB_Timestamp;
            
            gridVendorInvoices.AutoGenerateColumns = false;
            gridVendorInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridvendorinvoice_id.DataPropertyName = VendorInvoice.COL_DB_Id;
            col_gridvendorinvoice_timestamp.DataPropertyName = VendorInvoice.COL_DB_Timestamp;
            col_gridvendorinvoice_invoiceno.DataPropertyName = VendorInvoice.COL_DB_InvoiceNo;
            col_gridvendorinvoice_vendorname.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridvendorinvoice_statusenumid.DataPropertyName = VendorInvoice.COL_DB_StatusEnumID;
            col_gridvendorinvoice_statusname.DataPropertyName = VendorInvoice.COL_StatusName;
            col_gridvendorinvoice_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
            col_gridvendorinvoice_notes.DataPropertyName = VendorInvoice.COL_DB_Notes;
            col_gridvendorinvoice_notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            idtp_Timestamp.Value = DateTime.Now;
            Customer.populateInputControlDropDownList(iddl_Customers, true);
            Vendor.populateInputControlDropDownList(iddl_Vendors, true);

            idtp_MonthFilter.ResetValue = idtp_MonthFilter.getFirstDateOfLastMonth();
            idtp_MonthFilter.Checked = false;
            idtp_MonthFilter.reset();

            rbVendor.Checked = true;
            setRadioButtonEnability(rbVendor);

            tcRowInfo.TabPages.Clear();

            InputToDisableOnAdd.Add(idtp_MonthFilter);

            InputToDisableOnUpdate.Add(idtp_MonthFilter);

            InputToDisableOnSearch.Add(idtp_Timestamp);
            InputToDisableOnSearch.Add(in_PPN);
            InputToDisableOnSearch.Add(in_DPP);
            InputToDisableOnSearch.Add(itxt_Notes);
        }

        protected override void setupControlsBasedOnRoles()
        {
            //Helper.hideIfNoAccess(GlobalData.FakturPajak, btnRoles, FakturPajakAccessEnum.FakturPajakRoles_AddUpdate);
        }

        protected override void additionalSettings()
        {
        }

        protected override void clearInputFields()
        {
            itxt_No.reset();
            idtp_Timestamp.Value = DateTime.Now;
            iddl_Customers.reset();
            iddl_Vendors.reset();
            in_DPP.Value = 0;
            in_PPN.Value = 0;
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override DataView loadGridviewDataSource()
        {
            return FakturPajak.get(itxt_No.ValueText, (Guid?)iddl_Customers.SelectedValue, (Guid?)iddl_Vendors.SelectedValue, 
                idtp_MonthFilter.getFirstDayOfSelectedMonth(), idtp_MonthFilter.getLastDayOfSelectedMonth(), chkShowCompleted.Checked).DefaultView;
        }

        protected override void populateGridViewDataSource(bool reloadFromDB)
        {
            base.populateGridViewDataSource(reloadFromDB);

            lblGridInfo.Text = string.Format("Rows: {0}, DPP: {1:N0}", dgv.Rows.Count, Util.compute(Util.getDataTable(dgv.DataSource), "SUM", FakturPajak.COL_DB_DPP, ""));
        }

        protected override void populateInputFields()
        {
            FakturPajak obj = new FakturPajak(selectedRowID());
            idtp_Timestamp.Value = obj.Timestamp;
            itxt_No.ValueText = obj.No;
            in_DPP.Value = obj.DPP;
            in_PPN.Value = obj.PPN;
            itxt_Notes.ValueText = obj.Notes;

            iddl_Customers.SelectedValue = obj.Customers_Id;
            iddl_Vendors.SelectedValue = obj.Vendors_Id;
            rbVendor.Checked = (obj.Vendors_Id != null);
            setRadioButtonEnability(rbVendor);
        }

        protected override void add()
        {
            Guid? Customers_Id = null;
            Guid? Vendors_Id = null;
            if (rbVendor.Checked)
                Vendors_Id = (Guid?)iddl_Vendors.SelectedValue;
            else
                Customers_Id = (Guid?)iddl_Customers.SelectedValue;
            FakturPajak.add((DateTime)idtp_Timestamp.ValueAsStartDateFilter, Customers_Id, Vendors_Id, itxt_No.ValueText, in_DPP.ValueDecimal, in_PPN.ValueDecimal, itxt_Notes.ValueText);
        }

        protected override void update()
        {
            Guid? Customers_Id = null;
            Guid? Vendors_Id = null;
            if (rbVendor.Checked)
                Vendors_Id = (Guid?)iddl_Vendors.SelectedValue;
            else
                Customers_Id = (Guid?)iddl_Customers.SelectedValue;

            FakturPajak.update(selectedRowID(), (DateTime)idtp_Timestamp.ValueAsStartDateFilter, Customers_Id, Vendors_Id, itxt_No.ValueText, in_DPP.ValueDecimal, in_PPN.ValueDecimal, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (itxt_No.isEmpty())
                return itxt_No.isValueError("Please provide No");
            else if (rbCustomer.Checked && !iddl_Customers.hasSelectedValue())
                return iddl_Customers.SelectedValueError("Please select Customer");
            else if (rbVendor.Checked && !iddl_Vendors.hasSelectedValue())
                return iddl_Vendors.SelectedValueError("Please select Vendor");
            else if ((Mode != FormModes.Update && FakturPajak.isNoExist(null, itxt_No.ValueText))
                || (Mode == FormModes.Update && FakturPajak.isNoExist(selectedRowID(), itxt_No.ValueText)))
                return itxt_No.isValueError("No is already in the list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
        }

        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form(selectedRowID()));
            itxt_QuickSearch.Focus();
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue)
        {
            FakturPajak.updateCompleted(id, newValue);
            setButtonsVisibility(!newValue);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(_lastSelectedFakturPajaks_Id != (Guid?)Util.getSelectedRowValue(sender, col_dgv_Id))
                resetRowInfo();
        }

        protected override void dgv_CellDoubleClick()
        {
            if (_startingMode == FormModes.Browse)
            {
                BrowsedItemSelectionId = (Guid)Util.getSelectedRowValue(dgv, col_dgv_Id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _lastSelectedFakturPajaks_Id = (Guid)Util.getSelectedRowValue(dgv, col_dgv_Id);
                lblRowInfoHeader.Text = string.Format("Faktur Pajak No: {0}", Util.getSelectedRowValue(dgv, col_dgv_No));

                if (Util.selectedItemIsNotNull(dgv, col_dgv_Vendors_Id))
                {
                    tcRowInfo.TabPages.Clear();
                    tcRowInfo.TabPages.Add(tpVendorInvoices);
                    tcRowInfo.TabPages.Add(tpSaleInvoices);
                    populateGridSaleInvoices(false);
                    populateGridVendorInvoices(false);
                }
                else
                {
                    tcRowInfo.TabPages.Clear();
                    tcRowInfo.TabPages.Add(tpSaleInvoices);
                    tcRowInfo.TabPages.Add(tpSaleReturns);
                    populateGridSaleInvoices(false);
                    populateGridReturns(false);
                }

                if (!ptRowInfo.isPanelVisible())
                    ptRowInfo.PerformClick();

                setButtonsVisibility(!(bool)Util.getSelectedRowValue(dgv, col_dgv_Checkbox1));
            }
        }

        private void setButtonsVisibility(bool value)
        {
            btnAddSales.Enabled =
                btnAddReturns.Enabled =
                btnAddVendorInvoices.Enabled =
                col_gridReturns_removeFakturPajaks_Id.Visible =
                col_gridSaleInvoices_removeFakturPajaks_Id.Visible = 
                col_gridVendorInvoices_removeFakturPajaks_Id.Visible = value;
        }

        private void resetRowInfo()
        {
            lblRowInfoHeader.Text = "";
            Util.setGridviewDataSource(gridSaleInvoices, false, false, null);
            Util.setGridviewDataSource(gridReturns, false, false, null);
            Util.setGridviewDataSource(gridVendorInvoices, false, false, null);
            tpSaleInvoices.Text = TABTITLE_SaleInvoices;
            tpVendorInvoices.Text = TABTITLE_VendorInvoices;
            tpSaleReturns.Text = TABTITLE_SaleReturns;
            setButtonsVisibility(false);
        }

        private void setRadioButtonEnability(object sender)
        {
            if (sender == rbVendor)
                rbCustomer.Checked = iddl_Customers.Enabled = !((RadioButton)sender).Checked;
            else
                rbVendor.Checked = iddl_Vendors.Enabled = !((RadioButton)sender).Checked;
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void In_DPP_ValueChanged(object sender, EventArgs e)
        {
            in_PPN.Value = Math.Floor(in_DPP.ValueDecimal * (decimal)0.11);
        }

        private void MasterData_v1_FakturPajaks_Form_Shown(object sender, EventArgs e)
        {
            if(_startingMode != FormModes.Browse)
            {
                ptInputPanel.PerformClick();
                pnlRowInfo.Visible = true;
            }
        }

        private void BtnAddSales_Click(object sender, EventArgs e)
        {
            if (_lastSelectedFakturPajaks_Id == null)
                Util.displayMessageBoxError("Double click faktur pajak");
            else
            {
                Sales.Main_Form form = new Sales.Main_Form(FormModes.Browse, Util.wrapNullable<Guid?>(Util.getSelectedRowValue(dgv, col_dgv_Customers_Id)), Util.wrapNullable<Guid?>(Util.getSelectedRowValue(dgv, col_dgv_Vendors_Id)));
                Util.displayForm(null, form);
                if (form.DialogResult == DialogResult.OK)
                {
                    Sale.update_FakturPajaks_Id(form.BrowsedItemSelectionId, (Guid)_lastSelectedFakturPajaks_Id);
                    populateGridSaleInvoices(true);
                }
            }
        }

        private void BtnAddReturns_Click(object sender, EventArgs e)
        {
            if (_lastSelectedFakturPajaks_Id == null)
                Util.displayMessageBoxError("Double click faktur pajak");
            else
            {
                if (!Util.selectedItemIsNotNull(dgv, col_dgv_Customers_Id))
                    Util.displayMessageBoxError("Invalid Customer");
                else
                {
                    Returns.Main_Form form = new Returns.Main_Form(FormModes.Browse, (Guid)Util.getSelectedRowValue(dgv, col_dgv_Customers_Id));
                    Util.displayForm(null, form);
                    if (form.DialogResult == DialogResult.OK)
                    {
                        SaleReturn.update_FakturPajaks_Id(form.BrowsedItemSelectionId, (Guid)_lastSelectedFakturPajaks_Id);
                        populateGridReturns(true);
                    }
                }
            }
        }

        private void BtnAddVendorInvoices_Click(object sender, EventArgs e)
        {
            if (_lastSelectedFakturPajaks_Id == null)
                Util.displayMessageBoxError("Double click faktur pajak");
            else
            {
                if (!Util.selectedItemIsNotNull(dgv, col_dgv_Vendors_Id))
                    Util.displayMessageBoxError("Invalid Vendor");
                else
                {
                    InventoryForm.VendorInvoices_Form form = new InventoryForm.VendorInvoices_Form(FormModes.Browse, (Guid)Util.getSelectedRowValue(dgv, col_dgv_Vendors_Id));
                    Util.displayForm(null, form);
                    if (form.DialogResult == DialogResult.OK)
                    {
                        VendorInvoice.update_FakturPajaks_Id(form.BrowsedItemSelectionId, _lastSelectedFakturPajaks_Id);
                        populateGridVendorInvoices(true);
                    }
                }
            }
        }

        private void GridSaleInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_removeFakturPajaks_Id))
            {
                Sale.update_FakturPajaks_Id((Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id), null);
                populateGridSaleInvoices(true);
            }
            else if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_hexbarcode))
            {
                Sale sale = new Sale((Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
            }
            else if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_SaleAmount))
            {
                var form = new Invoices.Payment_Form(typeof(Sale), (Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populateGridSaleInvoices(true);
                }
            }
        }

        private void GridReturns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridReturns_hexbarcode))
            {
                Util.displayForm(null, new Returns.Print_Form(Util.getSelectedRowID(sender, col_gridReturns_id)));
            }
            else if (Util.isColumnMatch(sender, e, col_gridReturns_removeFakturPajaks_Id))
            {
                SaleReturn.update_FakturPajaks_Id((Guid)Util.getSelectedRowValue(sender, col_gridReturns_id), null);
                populateGridReturns(true);
            }
        }

        private void GridVendorInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridVendorInvoices_removeFakturPajaks_Id))
            {
                VendorInvoice.update_FakturPajaks_Id((Guid)Util.getSelectedRowValue(sender, col_gridvendorinvoice_id), null);
                populateGridVendorInvoices(true);
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        private void ChkShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            setRadioButtonEnability(sender);
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

        private void idtp_StartDate_ValueChanged(object sender, EventArgs e)
        {
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
