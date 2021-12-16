using System;
using System.Windows.Forms;

namespace BinaMitraTextile.Admin
{
    public partial class Settings_Form : Form
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

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Settings_Form() : this(null) { }
        public Settings_Form(Guid? Id) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {

        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            MoneyAccount.populateInputControlDropDownList(iddl_SalePayment_MoneyAccounts, true);
            iddl_SalePayment_MoneyAccounts.SelectedValue = Settings.SalePayment_MoneyAccounts_Id;
            if (iddl_SalePayment_MoneyAccounts.hasSelectedValue())
            {
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_SalePayment_MoneyAccountCategoryAssignments_Cash, (Guid)Settings.SalePayment_MoneyAccounts_Id, true);
                iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedValue = Settings.SalePayment_MoneyAccountCategoryAssignments_Id_Cash;

                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe, (Guid)Settings.SalePayment_MoneyAccounts_Id, true);
                iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedValue = Settings.SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe;
            }
            else
            {
                iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Enabled = false;
                iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Enabled = false;
            }
        }

        private void populatePageData()
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

        private void iddl_MoneyAccountCategories_SalePayment_Cash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormShown)
                setSalePayment_MoneyAccountCategoryAssignments_Id_Cash();
        }

        private void iddl_MoneyAccountCategories_SalePayment_TransferOwe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFormShown)
                setSalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe();
        }

        private void iddl_SalePayment_MoneyAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_isFormShown && iddl_SalePayment_MoneyAccounts.hasSelectedValue())
            {
                iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Enabled = true;
                iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Enabled = true;

                Settings.SalePayment_MoneyAccounts_Id = (Guid?)iddl_SalePayment_MoneyAccounts.SelectedValue;

                this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedIndexChanged -= new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_Cash_SelectedIndexChanged);
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_SalePayment_MoneyAccountCategoryAssignments_Cash, (Guid)iddl_SalePayment_MoneyAccounts.SelectedValue, true);
                this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_Cash_SelectedIndexChanged);
                setSalePayment_MoneyAccountCategoryAssignments_Id_Cash();

                this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedIndexChanged -= new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_TransferOwe_SelectedIndexChanged);
                MoneyAccountCategoryAssignment.populateInputControlDropDownList(iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe, (Guid)iddl_SalePayment_MoneyAccounts.SelectedValue, true);
                this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_TransferOwe_SelectedIndexChanged);
                setSalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe();
            }
        }

        public void setSalePayment_MoneyAccountCategoryAssignments_Id_Cash()
        {
            Settings.SalePayment_MoneyAccountCategoryAssignments_Id_Cash = (Guid?)iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedValue;
        }

        public void setSalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe()
        {
            Settings.SalePayment_MoneyAccountCategoryAssignments_Id_TransferOwe = (Guid?)iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedValue;
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
