using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_MoneyAccountItems_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private Guid MoneyAccounts_Id;

        private DataGridViewColumn col_dgv_Timestamp;
        private DataGridViewColumn col_dgv_No;
        private DataGridViewColumn col_dgv_Description;
        private DataGridViewColumn col_dgv_Amount;
        private DataGridViewColumn col_dgv_ReferenceId;
        private DataGridViewColumn col_dgv_MoneyAccounts_Name;
        private DataGridViewColumn col_dgv_MoneyAccountCategories_Name;
        private DataGridViewColumn col_dgv_Balance;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_MoneyAccountItems_Form() : this(FormModes.Add) { }
        public MasterData_v1_MoneyAccountItems_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);
            chkIncludeInactive.Visible = false;
            idtp_Timestamp_Start.Value = Util.getFirstDayOfSelectedMonth(DateTime.Now.AddMonths(-1));
            idtp_Timestamp_End.Value = DateTime.Now;
            idtp_Timestamp_End.Checked = false;
            InputToDisableOnSearch.Add(in_Amount);

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts, true, MoneyAccount.getUserRoleRestriction(GlobalData.UserAccount.role));
            MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);
            col_dgv_Checkbox1.HeaderText = "OK";

            setColumnsDataPropertyNames(MoneyAccountItem.COL_DB_Id, null, null, null, null, MoneyAccountItem.COL_DB_Approved);
            col_dgv_No = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_No", "No", MoneyAccountItem.COL_DB_No, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleCenter);
            col_dgv_Timestamp = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Timestamp", "Time", MoneyAccountItem.COL_DB_Timestamp, true, true, "dd/MM/yy HH:mm", false, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_MoneyAccountCategories_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MoneyAccountCategories_Name", iddl_MoneyAccountCategoryAssignments.LabelText, MoneyAccountItem.COL_MoneyAccountCategories_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);

            col_dgv_Description = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Description", itxt_Description.LabelText, MoneyAccountItem.COL_DB_Description, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            col_dgv_Amount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Amount", in_Amount.LabelText, MoneyAccountItem.COL_DB_Amount, true, true, "N0", false, false, 50, DataGridViewContentAlignment.MiddleRight);
            col_dgv_Balance = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Balance", "Balance", MoneyAccountItem.COL_Balance, true, true, "N0", false, false, 50, DataGridViewContentAlignment.MiddleRight);

            InputToDisableOnSearch.Add(itxt_Description);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                chkOnlyNotApproved.Visible = false;
                col_dgv_Checkbox1.Visible = false;
                btnUpdate.Visible = false;
                btnLog.Visible = false;
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            itxt_Description.reset();
            in_Amount.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (chkOnlyNotApproved.Checked || Mode == FormModes.Search)
                col_dgv_Balance.Visible = false;
            else
                col_dgv_Balance.Visible = true;

            if (Mode == FormModes.Add)
                return MoneyAccountItem.get(null, (Guid)iddl_MoneyAccounts.SelectedValue, null, null, chkOnlyNotApproved.Checked ? (bool?)false : null, idtp_Timestamp_Start.ValueAsStartDateFilter, idtp_Timestamp_End.ValueAsEndDateFilter, null).DefaultView;
            else
                return MoneyAccountItem.get(null, null, null, (Guid)iddl_MoneyAccountCategoryAssignments.SelectedValue, chkOnlyNotApproved.Checked ? (bool?)false : null, idtp_Timestamp_Start.ValueAsStartDateFilter, idtp_Timestamp_End.ValueAsEndDateFilter, null).DefaultView;
        }

        protected override void populateInputFields()
        {
            MoneyAccountItem obj = new MoneyAccountItem(selectedRowID());
            iddl_MoneyAccountCategoryAssignments.SelectedValue = MoneyAccountCategoryAssignment.get(obj.MoneyAccountCategories_Id, obj.MoneyAccounts_Id);
            itxt_Description.ValueText = obj.Description;
            in_Amount.Value = obj.Amount;
        }

        protected override void update()
        {
            MoneyAccountItem.update(selectedRowID(), (Guid)iddl_MoneyAccountCategoryAssignments.SelectedValue, itxt_Description.ValueText, in_Amount.ValueInt);
        }

        protected override void add()
        {
            MoneyAccountItem.add((Guid)iddl_MoneyAccountCategoryAssignments.SelectedValue, itxt_Description.ValueText, in_Amount.ValueInt, null);
        }

        protected override bool isInputFieldsValid()
        {
            if (!iddl_MoneyAccountCategoryAssignments.hasSelectedValue())
                return iddl_MoneyAccountCategoryAssignments.SelectedValueError("Please select Category");
            else if (itxt_Description.isEmpty())
                return itxt_Description.isValueError("Please provide description");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateCheckbox1Column(Guid id, bool newValue)
        {
            MoneyAccountItem.update_Approved(id, newValue);
        }

        protected override void updateDefaultRow(Guid id)
        {
        }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void pbCalculator_Click(object sender, EventArgs e)
        {
            int balance = 0;
            if (dgv.Rows.Count > 0)
                balance = (int)Util.zeroNonNumericString(Util.getRowValue(dgv.Rows[0], col_dgv_Balance));

            Util.displayForm(new Admin.Calculator_Form(balance));
        }

        private void iddl_MoneyAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isFormShown)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Util.displayForm(new Admin.MoneyAccountItems_Transfer_Form((Guid)iddl_MoneyAccounts.SelectedValue));
            populateGridViewDataSource(true);
        }

        private void idtp_Timestamp_End_Load(object sender, EventArgs e)
        {

        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
