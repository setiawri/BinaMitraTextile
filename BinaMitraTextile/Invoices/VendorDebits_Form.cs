using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Invoices
{
    public partial class VendorDebits_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private Guid? _vendorId = null;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public VendorDebits_Form()
        {
            InitializeComponent();
        }

        public VendorDebits_Form(Guid? vendorId) : this()
        {
            _vendorId = vendorId;
            cbVendors.SelectedValue = _vendorId;
        }
        
        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
            setupControlsBasedOnRoles();
            
            Tools.populateDropDownList(cbPaymentMethods, typeof(PaymentMethod));
            Vendor.populateDropDownList(cbVendors, false, true);

            gridSummary.AutoGenerateColumns = false;
            gridSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSummary.Columns[col_gridsummary_vendorid.Name].DataPropertyName = VendorDebit.COL_SUMMARY_Vendors_Id;
            gridSummary.Columns[col_gridsummary_vendorname.Name].DataPropertyName = VendorDebit.COL_SUMMARY_Vendors_Name;
            gridSummary.Columns[col_gridsummary_balance.Name].DataPropertyName = VendorDebit.COL_SUMMARY_Balance;

            gridDetail.AutoGenerateColumns = false;
            gridDetail.Columns[col_griddetail_timestamp.Name].DataPropertyName = VendorDebit.COL_DB_Timestamp;
            gridDetail.Columns[col_griddetail_notes.Name].DataPropertyName = VendorDebit.COL_DB_Notes;
            gridDetail.Columns[col_griddetail_vendorinvoiceid.Name].DataPropertyName = VendorDebit.COL_VendorInvoices_id;
            gridDetail.Columns[col_griddetail_vendorinvoiceno.Name].DataPropertyName = VendorDebit.COL_VendorInvoices_invoice_no;
            gridDetail.Columns[col_griddetail_amount.Name].DataPropertyName = VendorDebit.COL_DB_Amount;
            gridDetail.Columns[col_griddetail_method.Name].DataPropertyName = VendorDebit.COL_PaymentType_name;
            gridDetail.Columns[col_griddetail_balance.Name].DataPropertyName = VendorDebit.COL_Balance;
        }

        private void setupControlsBasedOnRoles()
        {

        }

        private void populateData()
        {
            gridSummary.DataSource = VendorDebit.getSummary();
            populateGridDetail();
        }

        private bool isInputValid()
        {
            txtAmount.Text = txtAmount.Text.Trim();

            if (cbVendors.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbVendors, "Please select a vendor from the drop down list");
            else if (Tools.zeroNonNumericString(txtAmount.Text) == 0)
                return Tools.inputError<TextBox>(txtAmount, "Invalid amount");
            else if (cbPaymentMethods.SelectedIndex == -1)
                return Tools.inputError<ComboBox>(cbPaymentMethods, "Please select a payment method from the dropdownlist");
            else if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Giro && string.IsNullOrEmpty(txtNotes.Text.Trim()))
                return Tools.inputError<TextBox>(txtNotes, "Tulis informasi giro di notes");

            return true;
        }

        private void resetData()
        {
            Tools.resetDropDownList(cbVendors);
            txtAmount.Text = "";
            txtNotes.Text = "";
        }

        private void populateGridDetail()
        {
            if (_vendorId == null)
            {
                gridSummary.ClearSelection();
                gridDetail.DataSource = null;
            }
            else
            {
                DataGridViewRow row = Tools.findRow(gridSummary, col_gridsummary_vendorid.Name, (Guid)_vendorId);
                row.Selected = true;

                DataTable dataTable = VendorDebit.getAll(_vendorId);
                gridDetail.DataSource = dataTable;
            }
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            populateData();
            cbVendors.Focus();
        }

        private void gridSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Guid selectedId = (Guid)gridSummary.Rows[e.RowIndex].Cells[col_gridsummary_vendorid.Name].Value;
                if (selectedId != _vendorId)
                {
                    _vendorId = selectedId;
                    populateGridDetail();
                }
            }
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_griddetail_vendorinvoiceno.Name))
            {
                //Tools.displayForm(new Sales.Invoice_Form(new Guid(gridDetail.Rows[e.RowIndex].Cells[col_griddetail_saleID.Name].Value.ToString())));
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                _vendorId = (Guid)cbVendors.SelectedValue;
                VendorDebit.add((Guid)_vendorId, Convert.ToDecimal(txtAmount.Text), null, txtNotes.Text.Trim(), (PaymentMethod)cbPaymentMethods.SelectedValue);
                populateData();
                resetData();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, false, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
