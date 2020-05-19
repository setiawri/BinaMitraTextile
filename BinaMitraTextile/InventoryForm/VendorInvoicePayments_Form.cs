using System;
using System.Windows.Forms;
using System.Data;
using LIBUtil;

namespace BinaMitraTextile.InventoryForm
{
    public partial class VendorInvoicePayments_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private bool isFormShown = false;

        private Guid _updateitem_Id;

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public VendorInvoicePayments_Form()
        {
            InitializeComponent();
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
            populateGridVendorInvoicePayments();
        }

        public void setupControls()
        {
            Settings.setGeneralSettings(this);

            gridVendorInvoicePayments.AutoGenerateColumns = false;
            gridVendorInvoicePayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridVendorInvoicePayments_Id.DataPropertyName = VendorInvoicePayment.COL_DB_Id;
            col_gridVendorInvoicePayments_No.DataPropertyName = VendorInvoicePayment.COL_DB_No;
            col_gridVendorInvoicePayments_Timestamp.DataPropertyName = VendorInvoicePayment.COL_DB_Timestamp;
            col_gridVendorInvoicePayments_Vendors_Name.DataPropertyName = VendorInvoicePayment.COL_Vendors_Name;
            col_gridVendorInvoicePayments_Amount.DataPropertyName = VendorInvoicePayment.COL_Amount;
            col_gridVendorInvoicePayments_Approved.DataPropertyName = VendorInvoicePayment.COL_DB_Approved;
            col_gridVendorInvoicePayments_Cancelled.DataPropertyName = VendorInvoicePayment.COL_DB_Cancelled;
            col_gridVendorInvoicePayments_Notes.DataPropertyName = VendorInvoicePayment.COL_DB_Notes;
            col_gridVendorInvoicePayments_Notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gridVendorInvoicePaymentItems.AutoGenerateColumns = false;
            gridVendorInvoicePaymentItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridVendorInvoicePaymentItems_Amount.DataPropertyName = VendorInvoicePaymentItem.COL_DB_Amount;
            col_gridVendorInvoicePaymentItems_VendorInvoices_Id.DataPropertyName = VendorInvoicePaymentItem.COL_DB_VendorInvoices_Id;
            col_gridVendorInvoicePaymentItems_Id.DataPropertyName = VendorInvoicePaymentItem.COL_DB_Id;
            col_gridVendorInvoicePaymentItems_VendorInvoices_No.DataPropertyName = VendorInvoicePaymentItem.COL_VendorInvoices_No;
            col_gridVendorInvoicePaymentItems_Notes.DataPropertyName = VendorInvoicePaymentItem.COL_DB_Notes;
            col_gridVendorInvoicePaymentItems_Notes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void populateGridVendorInvoicePayments()
        {
            Util.setGridviewDataSource(gridVendorInvoicePayments, true, true, VendorInvoicePayment.get(null, itxt_QuickSearch.ValueText, itxt_VendorInvoiceNo.ValueText, chkShowOnlyLast3Months.Checked, chkShowUnapprovedOnly.Checked));
            pbLog.Enabled = (gridVendorInvoicePayments.Rows.Count > 0);
        }

        public void searchVendorInvoiceNo(string VendorInvoices_No)
        {
            if (!ptFilterAndButtons.isTogglePanelVisible())
                ptFilterAndButtons.toggle();

            itxt_VendorInvoiceNo.ValueText = VendorInvoices_No;

            this.chkShowOnlyLast3Months.CheckedChanged -= new System.EventHandler(this.ChkShowOnlyLast3Months_CheckedChanged);
            this.chkShowUnapprovedOnly.CheckedChanged -= new System.EventHandler(this.ChkShowOnlyApproved_CheckedChanged);
            chkShowOnlyLast3Months.Checked = false;
            chkShowUnapprovedOnly.Checked = false;
            this.chkShowOnlyLast3Months.CheckedChanged += new System.EventHandler(this.ChkShowOnlyLast3Months_CheckedChanged);
            this.chkShowUnapprovedOnly.CheckedChanged += new System.EventHandler(this.ChkShowOnlyApproved_CheckedChanged);

            populateGridVendorInvoicePayments();
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void GridVendorInvoicePayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (Util.isColumnMatch(sender, e, col_gridVendorInvoicePayments_Notes, col_gridVendorInvoicePayments_Timestamp))
            {
                pnlUpdateVendorInvoicePayment.Visible = true;
                _updateitem_Id = Util.getClickedRowValue<Guid>(sender, e, col_gridVendorInvoicePayments_Id);
                VendorInvoicePayment obj = new VendorInvoicePayment(_updateitem_Id);
                idtp_Timestamp.Value = obj.Timestamp;
                itxt_Notes.ValueText = obj.Notes;
                idtp_Timestamp.focus();
            }
            else if (e.RowIndex > -1)
            {
                DataTable data = VendorInvoicePaymentItem.get(null, Util.getSelectedRowID(sender, col_gridVendorInvoicePayments_Id));
                Util.setGridviewDataSource(gridVendorInvoicePaymentItems, false, false, data);
                lblRowInfoHeader.Text = string.Format("Payment No: {0}", Util.getSelectedRowValue(sender, col_gridVendorInvoicePayments_No));
            }
        }

        private void GridVendorInvoicePaymentItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridVendorInvoicePaymentItems_VendorInvoices_No))
                Util.displayForm(new InventoryForm.VendorInvoices_Form(Util.getClickedRowValue(sender, e, col_gridVendorInvoicePaymentItems_VendorInvoices_No).ToString()));
        }

        private void ChkShowOnlyApproved_CheckedChanged(object sender, EventArgs e)
        {
            populateGridVendorInvoicePayments();
        }

        private void ChkShowOnlyLast3Months_CheckedChanged(object sender, EventArgs e)
        {
            populateGridVendorInvoicePayments();
        }

        private void Itxt_QuickSearch_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                populateGridVendorInvoicePayments();
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            populateGridVendorInvoicePayments();
        }

        private void PbLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(new Logs.Main_Form(Util.getSelectedRowID(gridVendorInvoicePayments, col_gridVendorInvoicePayments_Id)));
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            populateGridVendorInvoicePayments();
        }

        private void GridVendorInvoicePayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_gridVendorInvoicePayments_Approved))
            {
                VendorInvoicePayment.update_Approved(Util.getClickedRowValue<Guid>(sender, e, col_gridVendorInvoicePayments_Id), !Util.getCheckboxValue(sender, e));
                populateGridVendorInvoicePayments();
            }
            else if (Util.isColumnMatch(sender, e, col_gridVendorInvoicePayments_Cancelled))
            {
                VendorInvoicePayment.update_Cancelled(Util.getClickedRowValue<Guid>(sender, e, col_gridVendorInvoicePayments_Id), !Util.getCheckboxValue(sender, e));
                populateGridVendorInvoicePayments();
            }
        }

        private void btnUpdateVendorInvoicePayment_Click(object sender, EventArgs e)
        {
            VendorInvoicePayment.update(_updateitem_Id, (DateTime)idtp_Timestamp.ValueAsStartDateFilter, itxt_Notes.ValueText);
            pnlUpdateVendorInvoicePayment.Visible = false;
            populateGridVendorInvoicePayments();
        }

        private void btnCancelUpdateVendorInvoicePayment_Click(object sender, EventArgs e)
        {
            pnlUpdateVendorInvoicePayment.Visible = false;
        }

        #endregion
        /*******************************************************************************************************/
    }
}
