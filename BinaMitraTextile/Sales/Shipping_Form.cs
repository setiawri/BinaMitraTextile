using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class Shipping_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region PROPERTIES

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        List<string> _InvoiceBarcodeList = new List<string>();

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Shipping_Form() : this(null) { }
        public Shipping_Form(Guid? id) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControls()
        {
            this.ShowIcon = false;
            setupControlsBasedOnRoles();

            lblSaleItems.Text = "Items";
            lblRemaining.Text = "Remaining";

            gridSaleInvoices.AutoGenerateColumns = false;
            gridSaleInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_customer_name.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSaleInvoices_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;

            gridSaleItems.AutoGenerateColumns = false;
            gridSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleItems_id.DataPropertyName = SaleItem.COL_ID;
            col_gridSaleItems_InventoryItems_barcode.DataPropertyName = SaleItem.COL_BARCODE;
            col_gridSaleItems_Inventory_Code.DataPropertyName = SaleItem.COL_INVENTORYCODE;
            col_gridSaleItems_InventoryItems_Length.DataPropertyName = SaleItem.COL_LENGTH;

            gridRemaining.AutoGenerateColumns = false;
            gridRemaining.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridRemaining_id.DataPropertyName = SaleItem.COL_ID;
            col_gridRemaining_InventoryItems_barcode.DataPropertyName = SaleItem.COL_BARCODE;
            col_gridRemaining_Inventory_Code.DataPropertyName = SaleItem.COL_INVENTORYCODE;
            col_gridRemaining_InventoryItems_Length.DataPropertyName = SaleItem.COL_LENGTH;

            gridSummary.AutoGenerateColumns = false;
            gridSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSummary_GradeName.DataPropertyName = InventoryItem.COL_Grades_Name;
            col_gridSummary_Color.DataPropertyName = InventoryItem.COL_INVENTORYCOLORNAME;
            col_gridSummary_length.DataPropertyName = InventoryItem.COL_LENGTH;
            col_gridSummary_length_unit_name.DataPropertyName = InventoryItem.COL_LENGTHUNITNAME;
            col_gridSummary_product_name_store.DataPropertyName = InventoryItem.COL_ProductStoreName;
            col_gridSummary_product_width_name.DataPropertyName = InventoryItem.COL_ProductWidths_Name;
            col_gridSummary_qty.DataPropertyName = InventoryItem.COL_SALE_QTY;
            col_gridSummary_code.DataPropertyName = InventoryItem.COL_INVENTORY_CODE;
        }

        private void setupControlsBasedOnRoles()
        {

        }

        private void populateData()
        {
            if (isValidToPopulateData())
            {
            }
        }

        private bool isValidToPopulateData()
        {
            return true;
        }

        private void resetData()
        {

        }

        private void populateGridSaleInvoices(Sale sale)
        {
            DataTable table = (DataTable)gridSaleInvoices.DataSource;
            if (table == null)
                table = sale.datatable;
            else
                table.Merge(sale.datatable);
            gridSaleInvoices.DataSource = table;

            populateGridSaleItems(sale.sale_items);

            gridSummary.DataSource = Sale.compileSummaryData((DataTable)gridSaleItems.DataSource);
        }

        private void populateGridSaleItems(DataTable datatable)
        {
            DataTable table = (DataTable)gridSaleItems.DataSource;
            if (table == null)
                table = datatable;
            else
                table.Merge(datatable);
            gridSaleItems.DataSource = table;

            lblSaleItems.Text = string.Format("Items: {0}/{1}",
                LIBUtil.Util.compute(table, "COUNT", SaleItem.COL_LENGTH, ""),
                LIBUtil.Util.compute(table, "SUM", SaleItem.COL_LENGTH, ""));

            gridRemaining.DataSource = table.Copy();
            recalculateGridRemaining();
        }

        private void recalculateGridRemaining()
        {
            DataTable table = (DataTable)gridRemaining.DataSource;
            lblRemaining.Text = string.Format("Items: {0}/{1}",
                LIBUtil.Util.compute(table, "COUNT", SaleItem.COL_LENGTH, ""),
                LIBUtil.Util.compute(table, "SUM", SaleItem.COL_LENGTH, ""));
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateData();
            itxt_SaleInvoices.focus();
        }

        private void Itxt_SaleInvoices_onKeyDown(object sender, KeyEventArgs e)
        {
            string invoiceBarcode = itxt_SaleInvoices.ValueText.ToUpper();
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(invoiceBarcode))
            {
                if(_InvoiceBarcodeList.Contains(invoiceBarcode))
                    LIBUtil.Util.displayMessageBoxError("Invoice " + invoiceBarcode + " sudah ditambahkan sebelumnya");
                else
                {
                    //get invoice
                    Sale sale = new Sale(invoiceBarcode);

                    //insert into inventory items gridview
                    if (sale.sale_items == null)
                        LIBUtil.Util.displayMessageBoxError("Invoice " + invoiceBarcode + " tidak ditemukan");
                    else if (sale.sale_items.Rows.Count == 0)
                        LIBUtil.Util.displayMessageBoxError("Tidak ada data");
                    else
                    {
                        _InvoiceBarcodeList.Add(invoiceBarcode);
                        populateGridSaleInvoices(sale);
                    }
                }

                itxt_SaleInvoices.reset();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            gridRemaining.DataSource = ((DataTable)gridSaleItems.DataSource).Copy();
            recalculateGridRemaining();
        }

        private void TxtScanBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            string itemBarcode = txtScanBarcode.Text.ToUpper();
            bool isFound = false;
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(itemBarcode))
            {
                itemBarcode = itemBarcode.Substring(1);
                isFound = false;
                for (int i = gridRemaining.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = gridRemaining.Rows[i];
                    if (row.Cells[col_gridRemaining_InventoryItems_barcode.Name].Value.ToString().ToUpper() == itemBarcode)
                    {
                        gridRemaining.Rows.Remove(row);
                        isFound = true;
                        Settings.notificationSound.Play();
                    }
                }

                if(!isFound)
                    Settings.nonBarcodeScannerSound.Play();

                txtScanBarcode.Text = "";
                recalculateGridRemaining();
                txtScanBarcode.Focus();
            }
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}

