using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MoneyAccountItems_Transfer_Form : Form
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
        private Guid _Initial_MoneyAccounts_Id;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MoneyAccountItems_Transfer_Form(Guid Id) 
        { 
            InitializeComponent();

            _Initial_MoneyAccounts_Id = Id;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
            }
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts_From, true, MoneyAccount.getUserRoleRestriction(GlobalData.UserAccount.role));
            iddl_MoneyAccounts_From.SelectedValue = _Initial_MoneyAccounts_Id;

            if(iddl_MoneyAccounts_From.SelectedValue != null)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments_From, (Guid)iddl_MoneyAccounts_From.SelectedValue, true);

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts_To, true, null);

            if (iddl_MoneyAccounts_To.SelectedValue != null)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments_To, (Guid)iddl_MoneyAccounts_To.SelectedValue, true);

            iddl_MoneyAccounts_From.focus();
        }

        private void populatePageData()
        {
            populateGrid();
        }

        private void populateGrid()
        {
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
            if (!iddl_MoneyAccounts_From.hasSelectedValue())
                iddl_MoneyAccounts_From.SelectedValueError("Select origin account");
            else if (!iddl_MoneyAccountCategoryAssignments_From.hasSelectedValue())
                iddl_MoneyAccountCategoryAssignments_From.SelectedValueError("Select origin category");
            else if (!iddl_MoneyAccounts_To.hasSelectedValue())
                iddl_MoneyAccounts_To.SelectedValueError("Select destination account");
            else if (!iddl_MoneyAccountCategoryAssignments_To.hasSelectedValue())
                iddl_MoneyAccountCategoryAssignments_To.SelectedValueError("Select destination category");
            else
            {
                string descriptionFrom = "To Account " + iddl_MoneyAccounts_To.SelectedItemText;
                if (!string.IsNullOrEmpty(itxt_Description_From.ValueText))
                    descriptionFrom += ", " + itxt_Description_From.ValueText;

                string descriptionTo = "From Account " + iddl_MoneyAccounts_From.SelectedItemText;
                if (!string.IsNullOrEmpty(itxt_Description_To.ValueText))
                    descriptionTo += ", " + itxt_Description_To.ValueText;

                Guid ReferenceId = (Guid)MoneyAccountItem.add((Guid)iddl_MoneyAccountCategoryAssignments_From.SelectedValue, descriptionFrom, -1 * in_Amount.ValueInt, null);
                ActivityLog.submitCreate(ReferenceId);

                ReferenceId = (Guid)MoneyAccountItem.add((Guid)iddl_MoneyAccountCategoryAssignments_To.SelectedValue, descriptionTo, in_Amount.ValueInt, ReferenceId);
                ActivityLog.submitCreate(ReferenceId);

                this.Close();
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
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments_From, (Guid)iddl_MoneyAccounts_From.SelectedValue, true);
        }

        private void iddl_MoneyAccounts_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormShown)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments_To, (Guid)iddl_MoneyAccounts_To.SelectedValue, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
