using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LIBUtil;
using LIBUtil.Desktop.UserControls;

namespace BinaMitraTextile.Admin
{
    public partial class MoneyAccountItems_Add_Form : Form
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
        private Guid _Id;
        private bool _IsApproved;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MoneyAccountItems_Add_Form(Guid Id, bool isApproved) 
        { 
            InitializeComponent();

            _Id = Id;
            _IsApproved = isApproved;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_grid_Approved.Visible = false;
            }
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts, true, GlobalData.UserAccount.role != Roles.User);
            MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_Id.DataPropertyName = MoneyAccountItem.COL_DB_Id;
            col_grid_Timestamp.DataPropertyName = MoneyAccountItem.COL_DB_Timestamp;
            col_grid_No.DataPropertyName = MoneyAccountItem.COL_DB_No;
            col_grid_MoneyAccounts_Name.DataPropertyName = MoneyAccountItem.COL_MoneyAccounts_Name;
            col_grid_MoneyAccountCategories_Name.DataPropertyName = MoneyAccountItem.COL_MoneyAccountCategories_Name;
            col_grid_Description.DataPropertyName = MoneyAccountItem.COL_DB_Description;
            col_grid_Amount.DataPropertyName = MoneyAccountItem.COL_DB_Amount;
            col_grid_Approved.DataPropertyName = MoneyAccountItem.COL_DB_Approved;

            iddl_MoneyAccounts.focus();
        }

        private void populatePageData()
        {
            populateGrid();
        }

        private void populateGrid()
        {
            Util.populateDataGridView(grid, MoneyAccountItem.get_by_ReferenceId(_Id));
        }

        private void resetInputFields()
        {
            itxt_Description.ValueText = "";
            in_Amount.Value = 0;
            iddl_MoneyAccounts.focus();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_IsApproved)
                Util.displayMessageBoxError("Cannot add expense to locked invoice");
            else if (!iddl_MoneyAccounts.hasSelectedValue())
                iddl_MoneyAccounts.SelectedValueError("Select account");
            else if (!iddl_MoneyAccountCategoryAssignments.hasSelectedValue())
                iddl_MoneyAccountCategoryAssignments.SelectedValueError("Select category");
            else
            {
                Sale.update_ShippingExpense(_Id, (Guid)iddl_MoneyAccountCategoryAssignments.SelectedValue, in_Amount.ValueInt, itxt_Description.ValueText);
                resetInputFields();
                populateGrid();
            }
        }

        private void in_Amount_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSubmit.PerformClick();
        }

        private void iddl_MoneyAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormShown)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_grid_Approved))
            {
                MoneyAccountItem.update_Approved(Util.getSelectedRowID(sender, col_grid_Id), !(bool)Util.getClickedRowValue(sender, e));
                populateGrid();
            }
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
