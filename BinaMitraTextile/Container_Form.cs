using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile
{
    public partial class Container_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES


        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Container_Form()
        {
            InitializeComponent();
        }

        private void setupControls()
        {
            Util.setAsMDIParent(this);

            this.Text += DBUtil.appendTitleWithInfo();
            this.Icon = Settings.taskbarIcon;

            setupControlsBasedOnRoles();
        }

        private void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                menu_users.Visible = false;

                menu_test.Visible = false;

                menu_inventory_printbarcodes.Visible = false;
                menu_inventory_po.Visible = false;
                menu_inventory_invoices.Visible = false;

                menu_reports_financial.Visible = false;
                menu_reports_tax.Visible = false;

                menu_admin_vendorinvoices.Visible = false;

                menu_account_log.Visible = false;
            }

            if (GlobalData.UserAccount.role == Roles.Assistant)
            {
                menu_sales.Visible = false;
                menu_inventory.Visible = false;
                menu_returns.Visible = false;
                menu_customercredit.Visible = false;
                menu_admin.Visible = false;
                menu_users.Visible = false;
                menu_reports.Visible = false;
                menu_test.Visible = false;
                menu_account_salescomission.Visible = false;
                menu_account_log.Visible = false;

                lnkCreateSales.Visible = false;
                lnkPettyCash.Visible = false;
                lnkSummary.Visible = false;
            }
        }

        private void populatePageData()
        {
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region MENU - INVENTORY

        private void menu_inventory_samples_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.Samples1_Form(FormMode.New));
        }

        private void menu_inventory_stock_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.Main_Form());
        }

        private void menu_inventory_opname_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.ItemCheck_Form());
        }

        private void menu_inventory_printbarcodes_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.BarcodePrint_Form());
        }

        private void menu_inventory_po_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new POs.Main_Form());
        }

        private void menu_inventory_stocklevel_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.StockLevel_Form(FormMode.New));
        }

        private void menu_inventory_invoices_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Invoices.VendorInvoices_Form());
        }

        #endregion MENU - INVENTORY
        /*******************************************************************************************************/
        #region RETURNS

        private void menu_returns_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Returns.Main_Form());
        }

        #endregion RETURNS
        /*******************************************************************************************************/
        #region MENU - CUSTOMER CREDIT

        private void menu_customercredit_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new CustomerCredits.Main_Form());
        }

        #endregion MENU - CUSTOMER CREDIT
        /*******************************************************************************************************/
        #region MENU - ADMIN

        private void menu_admin_vendorinvoices_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Invoices.VendorInvoices_Form());
        }

        private void menu_admin_vendors_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Vendors_Form(FormMode.Search));
        }

        private void menu_admin_length_units_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.LengthUnits_Form(FormMode.Search));
        }

        private void menu_admin_customers_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Customers_Form(FormMode.Search));
        }

        private void menu_admin_cities_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Cities_Form(FormMode.Search));
        }

        private void menu_admin_products_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Products_Form(FormMode.Search));
        }

        private void menu_admin_prices_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.ProductPrices_Form());
        }

        private void menu_admin_widths_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.ProductWidths_Form(FormMode.Search));
        }

        private void menu_admin_colors_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.FabricColors_Form(FormMode.Search));
        }

        private void menu_admin_grades_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Grades_Form(FormMode.Search));
        }

        private void menu_admin_states_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.States_Form(FormMode.Search));
        }

        private void menu_admin_productstorenames_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.ProductStoreNames_Form(FormMode.Search));
        }

        private void menu_admin_angkutan_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Transports_Form(FormMode.Search));
        }

        private void menu_admin_customersaleadjustments_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_CustomerSaleAdjustments(FormModes.Add));
        }

        private void menu_admin_pettycash_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new FinancialRecords.PettyCash_Form());
        }

        private void menu_admin_pettycashcategories_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.PettyCashRecordsCategories_Form(FormMode.New));
        }

        private void menu_admin_customerterms_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_CustomerTerms_Form());
        }

        #endregion MENU - ADMIN
        /*******************************************************************************************************/
        #region MENU - USERS

        private void menu_users_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.Main_Form());
        }

        #endregion MENU - USERS
        /*******************************************************************************************************/
        #region MENU - TEST

        private void menu_test_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Test.Main_Form());
        }

        #endregion MENU - TEST
        /*******************************************************************************************************/
        #region MENU - QUIT

        private void menu_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion MENU - QUIT
        /*******************************************************************************************************/
        #region MENU - REPORTS

        private void menu_reports_financial_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Financial_Overview_Form());
        }

        private void menu_reports_sales_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Sales_Form());
        }

        private void menu_reports_tax_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Taxes_Form());
        }

        #endregion MENU - REPORTS
        /*******************************************************************************************************/
        #region MENU - ACCOUNT
            
        private void menu_account_password_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.PasswordChange_Form());
        }

        private void menu_account_salescomission_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.SalesComission_Form());
        }

        private void menu_account_log_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Logs.Main_Form(GlobalData.UserAccount.id));
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - SALES

        private void menu_sales_list_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Sales.Main_Form());
        }

        private void menu_sales_saleorders_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new SaleOrders.Main_Form());
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - TO DO LIST

        private void menu_todolist_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_ToDoList_Form(LIBUtil.FormModes.Add));
        }

        #endregion
        /*******************************************************************************************************/
        #region CLASS METHODS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();

            Util.displayMDIChild(new Main_Form());
        }

        private void LnkCreateSales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.Add_Edit_Form());
        }

        private void LnkInventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.Main_Form());
        }

        private void LnkOpname_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.ItemCheck_Form());
        }

        private void LnkPettyCash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new FinancialRecords.PettyCash_Form());
        }

        private void LnkSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Main_Form());
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region ----

        #endregion
        /*******************************************************************************************************/
    }
}
