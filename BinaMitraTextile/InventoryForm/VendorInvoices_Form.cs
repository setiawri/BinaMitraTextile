using System;
using System.Windows.Forms;
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

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public VendorInvoices_Form()
        {
            InitializeComponent();
        }

        public VendorInvoices_Form(string quickSearchText) : this()
        {
            itxt_QuickSearch.ValueText = quickSearchText;
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

            lblVendorInvoicePayment.Text = "0";

            gridvendorinvoice.AutoGenerateColumns = false;
            gridvendorinvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridvendorinvoice_id.DataPropertyName = VendorInvoice.COL_DB_Id;
            col_gridvendorinvoice_timestamp.DataPropertyName = VendorInvoice.COL_DB_Timestamp;
            col_gridvendorinvoice_invoiceno.DataPropertyName = VendorInvoice.COL_DB_InvoiceNo;
            col_gridvendorinvoice_vendorname.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridvendorinvoice_ReturnedValue.DataPropertyName = VendorInvoice.COL_ReturnedValue;
            col_gridvendorinvoice_CalculatedAmount.DataPropertyName = VendorInvoice.COL_CalculatedAmount;
            col_gridvendorinvoice_AmountDifferenceFromCalculated.DataPropertyName = VendorInvoice.COL_AmountDifferenceFromCalculated;
            col_gridvendorinvoice_statusenumid.DataPropertyName = VendorInvoice.COL_DB_StatusEnumID;
            col_gridvendorinvoice_statusname.DataPropertyName = VendorInvoice.COL_StatusName;
            col_gridvendorinvoice_top.DataPropertyName = VendorInvoice.COL_DB_TOP;
            col_gridvendorinvoice_isdue.DataPropertyName = VendorInvoice.COL_IsDue;
            col_gridvendorinvoice_PayableAmount.DataPropertyName = VendorInvoice.COL_PayableAmount;
            col_gridVendorInvoice_PaymentAmount.DataPropertyName = VendorInvoice.COL_PaymentAmount;
            col_gridvendorinvoice_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
            col_gridVendorInvoice_FakturPajaks_Id.DataPropertyName = VendorInvoice.COL_DB_FakturPajaks_Id;
            col_gridVendorInvoice_FakturPajaks_No.DataPropertyName = VendorInvoice.COL_FakturPajaks_No;
            col_gridvendorinvoice_FakturPajaks_Amount.DataPropertyName = VendorInvoice.COL_FakturPajaks_Amount;
            col_gridvendorinvoice_AmountDifferenceFromFakturPajaksAmount.DataPropertyName = VendorInvoice.COL_AmountDifferenceFromFakturPajaksAmount;
            col_gridvendorinvoice_notes.DataPropertyName = VendorInvoice.COL_DB_Notes;
            col_gridvendorinvoice_notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            addStatusContextMenu(col_gridvendorinvoice_statusname);

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

            gridSaleInvoices.AutoGenerateColumns = false;
            gridSaleInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSaleInvoices_SaleAmount.DataPropertyName = Sale.COL_SALEAMOUNT;
            col_gridSaleInvoices_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;
            col_gridSaleInvoices_FakturPajaks_Id.DataPropertyName = Sale.COL_DB_FakturPajaks_Id;
            col_gridSaleInvoices_FakturPajaks_No.DataPropertyName = Sale.COL_FakturPajaks_No;

        }

        public void populateGridVendorInvoices()
        {
            if (_startingMode == FormModes.Browse)
                Util.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get_by_BrowsingForFakturPajak_Vendors_Id((Guid)_BrowsingForFakturPajak_Vendors_Id, chkShowOnlyLast3Months.Checked));
            else if(_createVendorInvoicePayment)
                Util.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get(null, null, (Guid)iddl_Vendors.SelectedValue, chkShowOnlyIncomplete.Checked, chkShowOnlyVendorUsesFakturPajak.Checked, chkShowOnlyLast3Months.Checked, null, null));
            else
                Util.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get(null, null, null, chkShowOnlyIncomplete.Checked, chkShowOnlyVendorUsesFakturPajak.Checked, chkShowOnlyLast3Months.Checked, null, null));

            if (gridvendorinvoice.Rows.Count > 0)
            {
                pbLog.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                pbLog.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void createVendorInvoicePaymentMode(bool value)
        {
            _createVendorInvoicePayment = value;
            chkShowOnlyIncomplete.Checked = true;
            chkShowOnlyLast3Months.Checked = false;
            chkShowOnlyVendorUsesFakturPajak.Checked = false;
            col_gridVendorInvoice_PaymentAmount.Visible = value;

            if (value)
                populateGridVendorInvoices();
            else
                iddl_Vendors.reset();
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Util.displayForm(new VendorInvoices_Edit_Form(Util.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
            populateGridVendorInvoices();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
        }

        private void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.displayContextMenu(sender, e);
        }

        public void addStatusContextMenu(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (VendorInvoiceStatus status in Tools.GetEnumItems<VendorInvoiceStatus>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, changeStatus_Click));
        }

        public void changeStatus_Click(object sender, EventArgs args)
        {
            VendorInvoice.updateStatus(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id), Tools.parseEnum<VendorInvoiceStatus>(sender.ToString()));
            populateGridVendorInvoices();
        }

        private void gridvendorinvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (isFormShown && gridvendorinvoice.SelectedRows.Count > 0)
            {
                DataTable data = Inventory.getAll(true, false, null, null, null, null, null, null, null, Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id), false);
                Tools.setGridviewDataSource(gridInventory, false, false, data);
                lblSaleInvoices.Text = string.Format("Sale Invoices: {0:N2}", Util.compute(data, "SUM", Inventory.COL_BUYVALUE, ""));

                data = Sale.get_by_VendorInvoices_Id(Util.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id));
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

        private void ChkShowOnlyLast3Months_CheckedChanged(object sender, EventArgs e)
        {
            if (!_createVendorInvoicePayment)
                populateGridVendorInvoices();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
        }

        private void BtnStartVendorPayments_Click(object sender, EventArgs e)
        {
            if (!iddl_Vendors.hasSelectedValue())
                iddl_Vendors.SelectedValueError("Select a vendor");
            else
                createVendorInvoicePaymentMode(true);
        }

        private void BtnSubmitVendorPayments_Click(object sender, EventArgs e)
        {
            createVendorInvoicePaymentMode(false);
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

        #endregion
        /*******************************************************************************************************/
    }
}
