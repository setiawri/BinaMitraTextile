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

            gridFPMasukan.AutoGenerateColumns = false;
            gridFPMasukan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridFPMasukan_VendorInvoices_Id.DataPropertyName = VendorInvoice.COL_DB_Id;
            col_gridFPMasukan_VendorInvoices_Timestamp.DataPropertyName = VendorInvoice.COL_DB_Timestamp;
            col_gridFPMasukan_VendorInvoices_No.DataPropertyName = VendorInvoice.COL_DB_InvoiceNo;
            col_gridFPMasukan_Vendors_Name.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridFPMasukan_VendorInvoices_Amount.DataPropertyName = VendorInvoice.COL_DB_Amount;
        }

        private void populatePageData()
        {
            populateGridFPMasukan();
            populateGridFPMasukanRetur();
            populateGridFPKeluaran();
            populateGridFPKeluaranRetur();
        }

        private void populateGridFPMasukan()
        {
            lblFPMasukan.Text = string.Format("");

        }

        private void populateGridFPMasukanRetur()
        {
            lblFPMasukanRetur.Text = string.Format("");

        }

        private void populateGridFPKeluaran()
        {
            lblFPKeluaran.Text = string.Format("");

        }

        private void populateGridFPKeluaranRetur()
        {
            lblFPKeluaranRetur.Text = string.Format("");

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
