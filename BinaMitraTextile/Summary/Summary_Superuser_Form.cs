using BinaMitraTextile.SharedForms;
using LIBUtil;
using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    public partial class Summary_Superuser_Form : Form
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

        private bool _isFormShown = false;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Summary_Superuser_Form() : this(null) { }
        public Summary_Superuser_Form(Guid? Id) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {

        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            gridFakturPajak.AutoGenerateColumns = false;
            gridFakturPajak.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridFakturPajak_Id.DataPropertyName = FakturPajak.COL_DB_Id;
            col_gridFakturPajak_Timestamp.DataPropertyName = FakturPajak.COL_DB_Timestamp;
            col_gridFakturPajak_No.DataPropertyName = FakturPajak.COL_DB_No;
            col_gridFakturPajak_Vendors_Name.DataPropertyName = FakturPajak.COL_Vendors_Name;
            col_gridFakturPajak_Customers_Name.DataPropertyName = FakturPajak.COL_Customers_Name;
            col_gridFakturPajak_Amount.DataPropertyName = FakturPajak.COL_TotalAmount;
            col_gridFakturPajak_Notes.DataPropertyName = FakturPajak.COL_DB_Notes;
            col_gridFakturPajak_AmountDiff.DataPropertyName = FakturPajak.COL_AmountDifference;

            gridFPMasukan.AutoGenerateColumns = false;
            gridFPMasukan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridFPMasukan_VendorInvoices_Id.DataPropertyName = VendorInvoice.COL_DB_Id;
            col_gridFPMasukan_VendorInvoices_Timestamp.DataPropertyName = VendorInvoice.COL_DB_Timestamp;
            col_gridFPMasukan_VendorInvoices_No.DataPropertyName = VendorInvoice.COL_DB_InvoiceNo;
            col_gridFPMasukan_Vendors_Name.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridFPMasukan_VendorInvoices_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
            col_gridFPMasukan_Notes.DataPropertyName = VendorInvoice.COL_DB_Notes;

            gridFPMasukanRetur.AutoGenerateColumns = false;
            gridFPMasukanRetur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridFPMasukanRetur_Vendors_Name.DataPropertyName = Sale.COL_Vendors_Name;
            col_gridSaleInvoices_ReceivableAmount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridSaleInvoices_returnedamount.DataPropertyName = Sale.COL_RETURNEDAMOUNT;
            col_gridSaleInvoices_SaleAmount.DataPropertyName = Sale.COL_SALEAMOUNT;
            col_gridSaleInvoices_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_shippingcost.DataPropertyName = Sale.COL_DB_SHIPPINGCOST;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;
            col_gridFPMasukanRetur_Notes.DataPropertyName = Sale.COL_DB_Notes;

            gridFPKeluaran.AutoGenerateColumns = false;
            gridFPKeluaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridFPKeluaran_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridFPKeluaran_Customers_Name.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_gridFPKeluaran_ReceivableAmount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridFPKeluaran_ReturnedAmount.DataPropertyName = Sale.COL_RETURNEDAMOUNT;
            col_gridFPKeluaran_SaleAmount.DataPropertyName = Sale.COL_SALEAMOUNT;
            col_gridFPKeluaran_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridFPKeluaran_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridFPKeluaran_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridFPKeluaran_shippingcost.DataPropertyName = Sale.COL_DB_SHIPPINGCOST;
            col_gridFPKeluaran_Timestamp.DataPropertyName = Sale.COL_DB_Timestamp;
            col_gridFPKeluaran_Notes.DataPropertyName = Sale.COL_DB_Notes;

            gridFPKeluaranRetur.AutoGenerateColumns = false;
            gridFPKeluaranRetur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridReturns_customer_name.DataPropertyName = SaleReturn.COL_Customers_Name;
            col_gridReturns_hexbarcode.DataPropertyName = SaleReturn.COL_HEXBARCODE;
            col_gridReturns_id.DataPropertyName = SaleReturn.COL_ID;
            col_gridReturns_sale_amount.DataPropertyName = SaleReturn.COL_RETURNAMOUNT;
            col_gridReturns_sale_length.DataPropertyName = SaleReturn.COL_SaleLength;
            col_gridReturns_sale_qty.DataPropertyName = SaleReturn.COL_SaleQty;
            col_gridReturns_Timestamp.DataPropertyName = SaleReturn.COL_DB_Timestamp;
            col_gridReturns_Notes.DataPropertyName = SaleReturn.COL_DB_Notes;
        }

        private void populatePageData()
        {
            populateTabFakturPajak();
        }

        private void populateTabFakturPajak()
        {
            populateGridFakturPajak();
            populateGridFPMasukan();
            populateGridFPMasukanRetur();
            populateGridFPKeluaran();
            populateGridFPKeluaranRetur();

            tpFakturPajak.Text = string.Format("Faktur Pajak: {0}",
                gridFakturPajak.Rows.Count
                + gridFPMasukan.Rows.Count 
                + gridFPMasukanRetur.Rows.Count
                + gridFPKeluaran.Rows.Count
                + gridFPKeluaranRetur.Rows.Count);
        }

        private void populateGridFakturPajak()
        {
            Util.setGridviewDataSource(gridFakturPajak, FakturPajak.get_Reminder());
            tpFP.Text = string.Format("Faktur Pajak: {0}", gridFakturPajak.Rows.Count);
        }

        private void populateGridFPMasukan()
        {
            Util.setGridviewDataSource(gridFPMasukan, VendorInvoice.get_Reminder());
            tpFPMasukan.Text = string.Format("Masukan: {0}", gridFPMasukan.Rows.Count);
        }

        private void populateGridFPMasukanRetur()
        {
            Util.setGridviewDataSource(gridFPMasukanRetur, Sale.get_Reminder_MasukanRetur());
            tpFPMasukanRetur.Text = string.Format("Masukan Retur: {0}", gridFPMasukanRetur.Rows.Count);
        }

        private void populateGridFPKeluaran()
        {
            Util.setGridviewDataSource(gridFPKeluaran, Sale.get_Reminder_Keluaran());
            tpFPKeluaran.Text = string.Format("Keluaran: {0}", gridFPKeluaran.Rows.Count);
        }

        private void populateGridFPKeluaranRetur()
        {
            Util.setGridviewDataSource(gridFPKeluaranRetur, SaleReturn.get_Reminder());
            tpFPKeluaranRetur.Text = string.Format("Keluaran Retur: {0}", gridFPKeluaranRetur.Rows.Count);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            setupControlsBasedOnRoles();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            _isFormShown = true;
            populatePageData();
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
