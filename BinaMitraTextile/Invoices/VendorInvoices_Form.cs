﻿using System;
using System.Windows.Forms;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile.Invoices
{
    public partial class VendorInvoices_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        FormModes _startingMode = FormModes.Normal;
        Guid? _BrowsingForFakturPajak_Vendors_Id = null;
        public Guid BrowsedItemSelectionId;

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public VendorInvoices_Form()
        {
            InitializeComponent();
        }

        public VendorInvoices_Form(FormModes startingMode, Guid BrowsingForFakturPajak_Vendors_Id) : this()
        {
            _startingMode = startingMode;
            _BrowsingForFakturPajak_Vendors_Id = BrowsingForFakturPajak_Vendors_Id;

            if (_startingMode == FormModes.Browse)
            {
                pnlFilterAndButtons.Visible = false;
            }
        }
        
        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Util.displayForm(new VendorInvoices_Edit_Form(Util.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
            populatePageData();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
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
            populateGridVendorInvoice();
        }

        private void gridvendorinvoice_SelectionChanged(object sender, EventArgs e)
        {
            if(gridvendorinvoice.SelectedRows.Count > 0)
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
                    populatePageData();
                }
            }
        }

        #endregion
        /*******************************************************************************************************/
        #region FORM METHODS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        public void setupControls()
        {
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
            col_gridvendorinvoice_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
            col_gridVendorInvoice_FakturPajaks_Id.DataPropertyName = VendorInvoice.COL_DB_FakturPajaks_Id;
            col_gridVendorInvoice_FakturPajaks_No.DataPropertyName = VendorInvoice.COL_FakturPajaks_No;
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

        public void populatePageData()
        {
            populateGridVendorInvoice();

            if (gridvendorinvoice.Rows.Count > 0)
            {
                btnLog.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnLog.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void populateGridVendorInvoice()
        {
            if (_startingMode == FormModes.Browse)
                Util.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get_by_BrowsingForFakturPajak_Vendors_Id((Guid)_BrowsingForFakturPajak_Vendors_Id));
            else
                Util.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get(null, null, true, null, null));
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

        #endregion
        /*******************************************************************************************************/
    }
}
