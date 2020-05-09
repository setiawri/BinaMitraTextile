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
    public enum PaymentMode
    {
        SaleInvoice,
        VendorInvoice
    }

    public partial class Payment_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORMTITLE = "";

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private PaymentMode _paymentMode;
        private VendorInvoice _vendorInvoice;
        private Sale _sale;

        private decimal _creditBalance = 0;
        private decimal _payableAmount = 0;

        private bool _dataWasUpdated = false;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Payment_Form(Type type, Guid id)
        {
            InitializeComponent();

            if (type == typeof(VendorInvoice))
            {
                _vendorInvoice = new VendorInvoice(id);
                _paymentMode = PaymentMode.VendorInvoice;
            }
            else if (type == typeof(Sale))
            {
                _sale = new Sale(id);
                _paymentMode = PaymentMode.SaleInvoice;
            }
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS
            
        private void setupControls()
        {
            Settings.setGeneralSettings(this);
            this.Text = FORMTITLE + DBUtil.appendTitleWithInfo();
            setupControlsBasedOnRoles();
            
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_id.DataPropertyName = Payment.COL_DB_Id;
            col_grid_referenceid.DataPropertyName = Payment.COL_DB_ReferenceId;
            col_grid_timestamp.DataPropertyName = Payment.COL_DB_Timestamp;
            col_grid_methodname.DataPropertyName = Payment.COL_PaymentMethod_enumname;
            col_grid_amount.DataPropertyName = Payment.COL_DB_Amount;
            col_grid_balance.DataPropertyName = Payment.COL_Balance;
            col_grid_notes.DataPropertyName = Payment.COL_DB_Notes;
            col_grid_Checked.DataPropertyName = Payment.COL_DB_Checked;

            Tools.populateDropDownList(cbPaymentMethods, typeof(PaymentMethod));
            cbPaymentMethods.Focus();

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_grid_Checked.Visible = false;
            }
        }

        private void setupControlsBasedOnRoles() { }

        private void populateData()
        {
            decimal startingBalance = 0;
            Guid referenceId = new Guid();

            if (_paymentMode == PaymentMode.VendorInvoice)
            {
                referenceId = _vendorInvoice.ID;
                startingBalance = _vendorInvoice.CalculatedAmount;
                
                _creditBalance = VendorDebit.getBalance(_vendorInvoice.Vendors_Id);
                lblCreditBalance.Text = String.Format("Credit {0}: Rp.{1:N2}", _vendorInvoice.VendorName, _creditBalance);
            }
            else if (_paymentMode == PaymentMode.SaleInvoice)
            {
                referenceId = _sale.id;
                startingBalance = _sale.SaleAmount + _sale.ShippingCost;
                
                _creditBalance = CustomerCredit.getBalance((Guid)_sale.customer_id);
                lblCreditBalance.Text = String.Format("Credit {0}: Rp.{1:N2}", new Customer(_sale.customer_id).Name, _creditBalance);
            }

            DataTable dataTable = Payment.get(referenceId, startingBalance);
            LIBUtil.Util.setGridviewDataSource(grid, true, true, dataTable);

            if (dataTable.Rows.Count > 0)
                _payableAmount = DBUtil.parseData<decimal>(dataTable.Rows[dataTable.Rows.Count - 1], Payment.COL_Balance);
            else
                _payableAmount = startingBalance;

            lblTotalAmount.Text = String.Format("Balance: Rp.{0:N2} / Rp.{1:N2}", _payableAmount, startingBalance);
            
            if (_creditBalance > 0)
                cbPaymentMethods.SelectedItem = PaymentMethod.Credit;
            else
                cbPaymentMethods.SelectedItem = PaymentMethod.Cash;

            autoSetPaymentAmount();
        }

        private void resetData()
        {
            Tools.resetDropDownList(cbPaymentMethods);
            in_PaymentAmount.reset();
            txtNotes.Text = "";
        }

        private bool isInputFieldsValid()
        {
            DBUtil.sanitize(txtNotes);
            
            if (cbPaymentMethods.SelectedIndex == -1)
                return Tools.inputError<ComboBox>(cbPaymentMethods, "Please select a payment method from the dropdownlist");

            decimal paymentAmount = in_PaymentAmount.ValueDecimal;

            if (paymentAmount <= 0)
                return in_PaymentAmount.isValueError("Invalid Payment Amount");
            else if ((PaymentMethod)cbPaymentMethods.SelectedValue != PaymentMethod.Cash && paymentAmount > _payableAmount)
                return in_PaymentAmount.isValueError("Pembayaran melebihi jumlah yang belum dibayar");
            else if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Credit && paymentAmount > _creditBalance)
                return in_PaymentAmount.isValueError("Pembayaran melebihi credit yang tersedia");
            else if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Giro && string.IsNullOrEmpty(txtNotes.Text.Trim()))
                return Tools.inputError<TextBox>(txtNotes, "Tulis informasi giro di notes");
            
            return true;
        }

        private void autoSetPaymentAmount()
        {
            if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Credit)
            {
                if (_creditBalance > _payableAmount)
                    in_PaymentAmount.Value = _payableAmount;
                else
                    in_PaymentAmount.Value = _creditBalance;                
            }
            else
            {
                in_PaymentAmount.Value = _payableAmount;
            }
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateData();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (isInputFieldsValid())
            {
                decimal paymentAmount = in_PaymentAmount.ValueDecimal;
                if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Cash && paymentAmount > _payableAmount)
                {
                    Tools.displayForm(new SharedForms.Verify_Form("KEMBALI", string.Format("Rp. {0:N0}", paymentAmount - _payableAmount), SharedForms.VerifyFormFontSize.Medium));
                    paymentAmount = _payableAmount;
                }
                
                if (_paymentMode == PaymentMode.VendorInvoice)
                    Payment.add(_vendorInvoice.ID, (PaymentMethod)cbPaymentMethods.SelectedValue, paymentAmount, txtNotes.Text.Trim());
                else if (_paymentMode == PaymentMode.SaleInvoice)
                {
                    Guid id = Payment.add(_sale.id, (PaymentMethod)cbPaymentMethods.SelectedValue, paymentAmount, txtNotes.Text.Trim());
                    if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Credit)
                        CustomerCredit.submitNew((Guid)_sale.customer_id, paymentAmount * -1, id, txtNotes.Text.Trim(), null);
                }

                populateData();
                //resetData();
                txtNotes.Text = "";
                _dataWasUpdated = true;
            }
        }

        private void itxt_PaymentAmount_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, false, true);
        }

        private void cbPaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentMethods != null && cbPaymentMethods.SelectedValue != null)
                autoSetPaymentAmount();
        }

        private void btnAddCredit_Click(object sender, EventArgs e)
        {
            if (_paymentMode == PaymentMode.VendorInvoice)
                Tools.displayForm(new Invoices.VendorDebits_Form(_vendorInvoice.Vendors_Id));
            else if (_paymentMode == PaymentMode.SaleInvoice)
                Tools.displayForm(new CustomerCredits.Main_Form((Guid)_sale.customer_id));
        }
        
        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Tools.getClickedRowID(grid, col_grid_referenceid, e.RowIndex)));
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (LIBUtil.Util.isColumnMatch(sender, e, col_grid_Checked))
            {
                Payment.updateCheckedStatus(LIBUtil.Util.getSelectedRowID(grid, col_grid_id), !LIBUtil.Util.getCheckboxValue(sender, e));
                populateData();
                _dataWasUpdated = true;
            }
        }

        private void Payment_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_dataWasUpdated)
                this.DialogResult = DialogResult.OK;
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/




        /*******************************************************************************************************/
    }
}
