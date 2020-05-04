using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_CustomerTerms_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Customers_Name;
        private DataGridViewColumn col_dgv_DebtLimit;
        private DataGridViewColumn col_dgv_TermDays;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_Checked;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_CustomerTerms_Form() : this(FormModes.Add) { }
        public MasterData_v1_CustomerTerms_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            setColumnsDataPropertyNames(CustomerTerm.COL_DB_ID, CustomerTerm.COL_DB_ACTIVE, null, null, null, null);
            col_dgv_Customers_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Name", iddl_Customers.LabelText, CustomerTerm.COL_CUSTOMERS_NAME, true, true, "", true, false, 100, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_DebtLimit = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_DebtLimit", in_DebtLimit.LabelText, CustomerTerm.COL_DB_DEBTLIMIT, true, true, "N0", false, false, 100, DataGridViewContentAlignment.MiddleRight);
            col_dgv_TermDays = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_TermDays", in_TermDays.LabelText, CustomerTerm.COL_DB_TERMDAYS, true, true, "N0", false, false, 50, DataGridViewContentAlignment.MiddleRight);
            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, CustomerTerm.COL_DB_NOTES, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_dgv_Checked = base.addColumn<DataGridViewCheckBoxCell>(dgv, "col_dgv_Checked", "OK", CustomerTerm.COL_DB_Checked, true, true, "", true, false, 30, DataGridViewContentAlignment.MiddleLeft);

            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);

            InputToDisableOnSearch.Add(in_DebtLimit);
            InputToDisableOnSearch.Add(in_TermDays);

            InputToDisableOnUpdate.Add(iddl_Customers);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                chkOnlyNotOK.Visible = false;
                col_dgv_Checked.Visible = false;
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            iddl_Customers.reset();            
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return CustomerTerm.get(null, null, chkIncludeInactive.Checked, chkOnlyNotOK.Checked).DefaultView;
            else
                return CustomerTerm.get(null, (Guid?)iddl_Customers.SelectedValue, chkIncludeInactive.Checked, chkOnlyNotOK.Checked).DefaultView;
        }

        protected override void populateInputFields()
        {
            CustomerTerm obj = new CustomerTerm(selectedRowID());
            iddl_Customers.SelectedValue = obj.Customers_Id;
            in_DebtLimit.Value = obj.DebtLimit;
            in_TermDays.Value = obj.TermDays;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            CustomerTerm.update(selectedRowID(), in_DebtLimit.ValueDecimal, in_TermDays.ValueInt, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            CustomerTerm.add((Guid)iddl_Customers.SelectedValue, in_DebtLimit.ValueDecimal, in_TermDays.ValueInt, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (!iddl_Customers.hasSelectedValue())
                return iddl_Customers.SelectedValueError("Please select a customer");
            else if ((Mode != FormModes.Update && CustomerTerm.isExist_CustomersId(null, (Guid)iddl_Customers.SelectedValue))
                || (Mode == FormModes.Update && CustomerTerm.isExist_CustomersId(selectedRowID(), (Guid)iddl_Customers.SelectedValue)))
                return iddl_Customers.SelectedValueError("Customer is already in the list");
            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            CustomerTerm.updateActive(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_dgv_Checked))
            {
                CustomerTerm.updateCheckedStatus(GlobalData.UserAccount.id, (Guid)Util.getSelectedRowValue(sender, col_dgv_Id), !Util.getCheckboxValue(sender, e));
                populateGridViewDataSource(true);
            }
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void iddl_Customers_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_Customers_Form(FormModes.Add), false);
            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);
        }

        private void chkIncludeCompleted_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        private void chkOnlyNotOK_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
