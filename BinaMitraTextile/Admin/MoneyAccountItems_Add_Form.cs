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

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MoneyAccountItems_Add_Form(Guid Id) 
        { 
            InitializeComponent();

            _Id = Id;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {

        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            MoneyAccount.populateInputControlDropDownList(iddl_MoneyAccounts, true);
            MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);

            iddl_MoneyAccounts.focus();
        }

        private void populatePageData()
        {
        }

        private void resetInputFields()
        {
            itxt_ShippingExpenseNotes.ValueText = "";
            in_ShippingExpense.Value = new Sale(_Id).ShippingExpense;
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

        private void btnUpdateShippingExpense_Click(object sender, EventArgs e)
        {
            if (!iddl_MoneyAccountCategoryAssignments.hasSelectedValue())
                iddl_MoneyAccountCategoryAssignments.SelectedValueError("Select category");
            else
            {
                Sale.update_ShippingExpense(_Id, (Guid)iddl_MoneyAccountCategoryAssignments.SelectedValue, in_ShippingExpense.ValueInt, itxt_ShippingExpenseNotes.ValueText);
            }
        }

        private void in_ShippingExpense_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnUpdateShippingExpense.PerformClick();
        }

        private void iddl_MoneyAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormShown)
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_MoneyAccountCategoryAssignments, (Guid)iddl_MoneyAccounts.SelectedValue, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
