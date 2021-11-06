using System;
using System.Data;
using System.Windows.Forms;

namespace BinaMitraTextile.CustomerCredits
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private Guid? _customerID = null;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION
        
        public Main_Form()
        {
            InitializeComponent();
        }

        public Main_Form(Guid customerID)
            : this()
        {
            _customerID = customerID;
            iddl_Customers.SelectedValue = _customerID;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            gridSummary.ClearSelection();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            Tools.populateDropDownList(cbPaymentMethods, typeof(PaymentMethod));

            gridSummary.AutoGenerateColumns = false;
            gridSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSummary.Columns[col_gridsummary_customerid.Name].DataPropertyName = CustomerCredit.COL_SUMMARY_CUSTOMERID;
            gridSummary.Columns[col_gridsummary_customername.Name].DataPropertyName = CustomerCredit.COL_SUMMARY_CUSTOMERNAME;
            gridSummary.Columns[col_gridsummary_balance.Name].DataPropertyName = CustomerCredit.COL_SUMMARY_BALANCE;

            gridDetail.AutoGenerateColumns = false;
            gridDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_griddetail_Id.DataPropertyName = CustomerCredit.COL_DB_ID;
            gridDetail.Columns[col_griddetail_timestamp.Name].DataPropertyName = CustomerCredit.COL_DB_TIMESTAMP;
            gridDetail.Columns[col_griddetail_notes.Name].DataPropertyName = CustomerCredit.COL_DB_NOTES;
            gridDetail.Columns[col_griddetail_saleID.Name].DataPropertyName = CustomerCredit.COL_SALEID;
            gridDetail.Columns[col_griddetail_saleBarcode.Name].DataPropertyName = CustomerCredit.COL_SALEBARCODE;
            gridDetail.Columns[col_griddetail_amount.Name].DataPropertyName = CustomerCredit.COL_DB_AMOUNT;
            gridDetail.Columns[col_griddetail_method.Name].DataPropertyName = CustomerCredit.COL_PAYMENT_METHODNAME;
            gridDetail.Columns[col_griddetail_balance.Name].DataPropertyName = CustomerCredit.COL_BALANCE;
            col_griddetail_Confirmed.DataPropertyName = CustomerCredit.COL_DB_Confirmed;

            Customer.populateInputControlDropDownList(iddl_Customers, false);

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_griddetail_Confirmed.Visible = false;
            }
        }

        private void populatePageData()
        {
            gridDetail.DataSource = null;
            _customerID = null;
            populateGridSummary(true);
            populateGridDetail();
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST
            
        private void gridSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                Guid selectedCustomerID = (Guid)gridSummary.Rows[e.RowIndex].Cells[col_gridsummary_customerid.Name].Value;
                if (selectedCustomerID != _customerID)
                {
                    _customerID = selectedCustomerID;
                    gridDetail.DataSource = null; //reset firstscrollingindex
                    populateGridDetail();

                    iddl_Customers.SelectedValue = _customerID;
                }
            }
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_griddetail_saleBarcode.Name))
            {
                Tools.displayForm(new Sales.Invoice_Form(new Guid(gridDetail.Rows[e.RowIndex].Cells[col_griddetail_saleID.Name].Value.ToString())));
            }
            else if (LIBUtil.Util.isColumnMatch(sender, e, col_griddetail_Confirmed))
            {
                CustomerCredit.updateConfirmedStatus(LIBUtil.Util.getSelectedRowID(gridDetail, col_griddetail_Id), !LIBUtil.Util.getCheckboxValue(sender, e));
                populateGridDetail();
            }
        }

        private void populateGridSummary(bool reloadFromDB)
        {
            DataView dvw;

            if (reloadFromDB)
                dvw = CustomerCredit.getSummary(chkOnlyHasActivityLast3Months.Checked).DefaultView;
            else
                dvw = LIBUtil.Util.getDataView(gridSummary.DataSource);

            dvw.RowFilter = LIBUtil.Util.compileQuickSearchFilter(LIBUtil.Util.sanitize(txtFilter.Text), new string[] { CustomerCredit.COL_SUMMARY_CUSTOMERNAME });
            gridSummary.DataSource = dvw;
        }

        private void populateGridDetail()
        {
            if (_customerID == null)
            {
                gridSummary.ClearSelection();
                gridDetail.DataSource = null;
            }
            else
            {
                DataGridViewRow row = Tools.findRow(gridSummary, col_gridsummary_customerid.Name, (Guid)_customerID);
                row.Selected = true;

                LIBUtil.Util.setGridviewDataSource(gridDetail, true, true, CustomerCredit.getAll(_customerID));
            }
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                _customerID = (Guid)iddl_Customers.SelectedValue;
                CustomerCredit.submitNew((Guid)_customerID, in_Amount.ValueDecimal, null, txtNotes.Text.Trim(), (PaymentMethod)cbPaymentMethods.SelectedValue);
                populateGridSummary(true);
                populateGridDetail();

                in_Amount.reset();
                txtNotes.Text = "";
            }
        }

        private bool isInputValid()
        {
            if (!iddl_Customers.isValidSelectedValue())
                return iddl_Customers.SelectedValueError("Please select a customer from the drop down list");
            else if (in_Amount.Value == 0)
                return in_Amount.isValueError("Invalid amount");
            else if (cbPaymentMethods.SelectedIndex == -1)
                return Tools.inputError<ComboBox>(cbPaymentMethods, "Please select a payment method from the dropdownlist");
            else if ((PaymentMethod)cbPaymentMethods.SelectedValue == PaymentMethod.Giro && string.IsNullOrEmpty(txtNotes.Text.Trim()))
                return Tools.inputError<TextBox>(txtNotes, "Tulis informasi giro di notes");

            return true;
        }

        private void resetForm()
        {
            iddl_Customers.reset();
            in_Amount.reset();
            txtNotes.Text = "";
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, false, true);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            populateGridSummary(false);

            gridDetail.DataSource = null;
            _customerID = null;
            iddl_Customers.reset();
            gridSummary.ClearSelection();
        }

        private void chkOnlyHasActivityLast3Months_CheckedChanged(object sender, EventArgs e)
        {
            populatePageData();
        }

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            populatePageData();
            iddl_Customers.Focus();
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION
        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region PRINT METHODS
        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
