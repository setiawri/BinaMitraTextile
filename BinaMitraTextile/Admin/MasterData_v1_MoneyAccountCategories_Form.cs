using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_MoneyAccountCategories_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Name;
        private DataGridViewColumn col_dgv_MoneyAccountCategories_Name;
        private DataGridViewColumn col_dgv_Notes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_MoneyAccountCategories_Form() : this(FormModes.Add) { }
        public MasterData_v1_MoneyAccountCategories_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            setColumnsDataPropertyNames(MoneyAccountCategory.COL_DB_Id, MoneyAccountCategory.COL_DB_Active, null, null, MoneyAccountCategory.COL_DB_Default, null);
            col_dgv_MoneyAccountCategories_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MoneyAccountCategories_Name", iddl_MoneyAccounts_Id.LabelText, MoneyAccountCategory.COL_DB_MoneyAccounts_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Name", itxt_Name.LabelText, MoneyAccountCategory.COL_DB_Name, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);

            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, MoneyAccountCategory.COL_DB_Notes, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts_Id, null);

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
            itxt_Name.reset();
            iddl_MoneyAccounts_Id.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return MoneyAccountCategory.get(null, null, (Guid?)iddl_MoneyAccounts_Id.SelectedValue, chkIncludeInactive.Checked ? null : (bool?)true).DefaultView;
            else
                return MoneyAccountCategory.get(null, itxt_Name.ValueText, (Guid?)iddl_MoneyAccounts_Id.SelectedValue, chkIncludeInactive.Checked ? null : (bool?)true).DefaultView;
        }

        protected override void populateInputFields()
        {
            MoneyAccountCategory obj = new MoneyAccountCategory(selectedRowID());
            itxt_Name.ValueText = obj.Name;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            MoneyAccountCategory.update(selectedRowID(), itxt_Name.ValueText, (Guid)iddl_MoneyAccounts_Id.SelectedValue, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            MoneyAccountCategory.add(itxt_Name.ValueText, (Guid)iddl_MoneyAccounts_Id.SelectedValue, itxt_Notes.ValueText);
        }

        protected override bool isInputFieldsValid()
        {
            if (itxt_Name.isEmpty())
                return itxt_Name.isValueError("Please provide name");
            else if (!iddl_MoneyAccounts_Id.hasSelectedValue())
                return iddl_MoneyAccounts_Id.SelectedValueError("Please select an account");
            else if ((Mode != FormModes.Update && MoneyAccountCategory.isExist(null, itxt_Name.ValueText, (Guid)iddl_MoneyAccounts_Id.SelectedValue))
                || (Mode == FormModes.Update && MoneyAccountCategory.isExist(selectedRowID(), itxt_Name.ValueText, (Guid)iddl_MoneyAccounts_Id.SelectedValue)))
                return itxt_Name.isValueError("Name is already in list");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id)
        {
            MoneyAccountCategory.update_Default(id);
        }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            MoneyAccountCategory.update_Active(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void iddl_MoneyAccounts_Id_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new MasterData_v1_MoneyAccounts_Form(), false);
            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts_Id, true);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
