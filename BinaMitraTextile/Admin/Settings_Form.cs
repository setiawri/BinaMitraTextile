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

            //not used. category is selected when submitting expense
            //PettyCashRecordsCategory.populateInputControlDropDownList(iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense, true);
            //iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedValue = Settings.PettyCashCategoryForSaleInvoiceShippingExpense;
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

        private void iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_isFormShown)
            {
                //not used. category is selected when submitting expense
                //if (iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.hasSelectedValue())
                //    Settings.PettyCashCategoryForSaleInvoiceShippingExpense = (Guid)iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedValue;
                //else
                //    Settings.PettyCashCategoryForSaleInvoiceShippingExpense = null;
            }
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
