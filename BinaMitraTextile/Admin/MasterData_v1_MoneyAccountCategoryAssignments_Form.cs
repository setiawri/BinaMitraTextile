using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_MoneyAccountCategoryAssignments_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_MoneyAccountCategories;
        private DataGridViewColumn col_dgv_MoneyAccounts_Name;
        private DataGridViewColumn col_dgv_Notes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_MoneyAccountCategoryAssignments_Form() : this(FormModes.Add) { }
        public MasterData_v1_MoneyAccountCategoryAssignments_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);
            scContent.Panel2Collapsed = true;

            setColumnsDataPropertyNames(MoneyAccountCategoryAssignment.COL_DB_Id, MoneyAccountCategoryAssignment.COL_DB_Active, null, null, MoneyAccountCategoryAssignment.COL_DB_Default, null);
            col_dgv_MoneyAccounts_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MoneyAccounts_Name", iddl_MoneyAccounts.LabelText, MoneyAccountCategoryAssignment.COL_MoneyAccounts_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_MoneyAccountCategories = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MoneyAccountCategories", iddl_MoneyAccountCategories.LabelText, MoneyAccountCategoryAssignment.COL_MoneyAccountCategories_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);

            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, MoneyAccountCategoryAssignment.COL_DB_Notes, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts, null, null);
            MoneyAccountCategory.populateInputControlDropDownList(iddl_MoneyAccountCategories, null);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            iddl_MoneyAccountCategories.reset();
            iddl_MoneyAccounts.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return MoneyAccountCategoryAssignment.get(null, null, null, chkIncludeInactive.Checked ? null : (bool?)true).DefaultView;
            else
                return MoneyAccountCategoryAssignment.get(null, (Guid?)iddl_MoneyAccountCategories.SelectedValue, (Guid?)iddl_MoneyAccounts.SelectedValue, chkIncludeInactive.Checked ? null : (bool?)true).DefaultView;
        }

        protected override void populateInputFields()
        {
            MoneyAccountCategoryAssignment obj = new MoneyAccountCategoryAssignment(selectedRowID());
            iddl_MoneyAccounts.SelectedValue = obj.MoneyAccounts_Id;
            iddl_MoneyAccountCategories.SelectedValue = obj.MoneyAccountCategories_Id;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            MoneyAccountCategoryAssignment.update(selectedRowID(), (Guid)iddl_MoneyAccountCategories.SelectedValue, (Guid)iddl_MoneyAccounts.SelectedValue, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            MoneyAccountCategoryAssignment.add((Guid)iddl_MoneyAccountCategories.SelectedValue, (Guid)iddl_MoneyAccounts.SelectedValue, itxt_Notes.ValueText);
        }

        protected override bool isInputFieldsValid()
        {
            if (!iddl_MoneyAccounts.hasSelectedValue())
                return iddl_MoneyAccounts.SelectedValueError("Please select an account");
            else if (!iddl_MoneyAccountCategories.hasSelectedValue())
                return iddl_MoneyAccountCategories.SelectedValueError("Please select a category");
            else if ((Mode != FormModes.Update && MoneyAccountCategoryAssignment.isExist(null, (Guid)iddl_MoneyAccountCategories.SelectedValue, (Guid)iddl_MoneyAccounts.SelectedValue))
                || (Mode == FormModes.Update && MoneyAccountCategoryAssignment.isExist(selectedRowID(), (Guid)iddl_MoneyAccountCategories.SelectedValue, (Guid)iddl_MoneyAccounts.SelectedValue)))
                return iddl_MoneyAccountCategories.SelectedValueError("Combination is already in list");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id)
        {
            MoneyAccountCategoryAssignment.update_Default(id);
        }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            MoneyAccountCategoryAssignment.update_Active(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void iddl_MoneyAccounts_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new MasterData_v1_MoneyAccounts_Form(), false);
            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts, true, null);
        }

        private void iddl_MoneyAccountCategories_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new MasterData_v1_MoneyAccountCategories_Form(), false);
            MoneyAccountCategory.populateInputControlDropDownList(iddl_MoneyAccountCategories, true);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
