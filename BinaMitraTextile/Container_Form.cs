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
        #region CONSTRUCTOR

        public Container_Form()
        {
            InitializeComponent();
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region CLASS METHODS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            //if(GlobalData.UserAccount.role == Roles.Super)
            //    Util.displayMDIChild(new Summary_Superuser_Form());
            
            if (lnkSummary_Assistant.Visible && GlobalData.UserAccount.role == Roles.Assistant)
                Util.displayMDIChild(new Summary_Assistant_Form());
            else if (lnkSummary_User.Visible && GlobalData.UserAccount.role == Roles.User)
                Util.displayMDIChild(new Summary_User_Form());
        }

        private void setupControls()
        {
            Util.setAsMDIParent(this);

            Settings.setGeneralSettings(this);
            this.Text += " " + Settings.APPVERSION + DBUtil.appendTitleWithInfo();
            
            setupControlsBasedOnRoles();
        }

        private void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                if (GlobalData.UserAccount.role == Roles.Assistant)
                {
                    gbShortcutsForUsers.Visible = false;
                }
                else
                {
                    Sales_FakturPajak.Visible = false;
                    Sales_Kontrabon.Visible = false;

                    Sales_Divider_Penagihan.Visible = false;
                    Inventory_VendorInvoices.Visible = false;
                    Inventory_FakturPajak.Visible = false;
                    Inventory_VendorInvoicePayment.Visible = false;

                    gbShortcutsForAssistants.Visible = false;
                }

                Inventory_Barcodes.Visible = false;

                Admin_PettyCashCategories.Visible = false;

                Internal.Visible = false;

                Account_Log.Visible = false;
            }
        }

        private void populatePageData()
        {
        }

        private void updateOpenFormShortcuts()
        {

        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region SHORTCUT LINKS

        private void lnkKontrabon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.MasterData_v2_Kontrabons_Form());
        }

        private void LnkCreateSales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.Add_Edit_Form());
        }

        private void LnkInventory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.Main_Form());
        }

        private void LnkPettyCash_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Admin.PettyCash_Form());
        }

        private void LnkSaleReturns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Returns.Main_Form());
        }

        private void LnkSummary1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Summary_User_Form());
        }

        private void lnkSummary2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Summary_Assistant_Form());
        }

        private void LnlSales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.Main_Form());
        }

        private void LnkShipping_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.Shipping_Form());
        }

        private void LnkSaleOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Sales.SaleOrders_Form());
        }

        private void LnkSamples_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new Admin.Samples1_Form(FormMode.New));
        }

        private void BtnOpname_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.StockOpname_Form());
        }

        private void LnkCustomerCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new CustomerCredits.Main_Form());
        }

        private void LnkVendorInvoicePayments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.VendorInvoicePayments_Form());
        }

        private void LnkVendorInvoices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.VendorInvoices_Form());
        }

        private void LnkFakturPajak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new SharedForms.MasterData_v1_FakturPajaks_Form(FormModes.Add));
        }

        #endregion SHORTCUT LINKS
        /*******************************************************************************************************/
        #region MENU - INVENTORY

        private void Inventory_Samples_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.Samples1_Form(FormMode.New));
        }

        private void Inventory_Opname_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.StockOpname_Form());
        }

        private void Inventory_Barcodes_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.BarcodePrint_Form());
        }

        private void Inventory_StockLevel_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.StockLevel_Form(FormMode.New));
        }

        private void Inventory_Daftar_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.Main_Form());
        }

        private void Inventory_Products_Daftar_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_Products_Form(FormModes.Search));
        }

        private void Inventory_Products_Grades_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Grades_Form(FormMode.Search));
        }

        private void Inventory_Products_Units_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.LengthUnits_Form(FormMode.Search));
        }

        private void Inventory_Products_Prices_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.ProductPrices_Form());
        }

        private void Inventory_Products_StoreNames_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.ProductStoreNames_Form(FormMode.Search));
        }

        private void Inventory_Products_Widths_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.ProductWidths_Form(FormMode.Search));
        }

        private void Inventory_Products_Vendors_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_Vendors_Form(FormModes.Search));
        }

        private void Inventory_Products_Colors_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.FabricColors_Form(FormMode.Search));
        }

        private void Inventory_VendorInvoices_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.VendorInvoices_Form());
        }

        private void Inventory_PurchaseOrders_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new POs.Main_Form());
        }

        private void Inventory_FakturPajak_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new SharedForms.MasterData_v1_FakturPajaks_Form(FormModes.Add));
        }

        private void Inventory_VendorInvoicePayment_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new InventoryForm.VendorInvoicePayments_Form());
        }

        #endregion MENU - INVENTORY
        /*******************************************************************************************************/
        #region MENU - ADMIN

        private void Admin_Angkutan_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Transports_Form(FormMode.Search));
        }

        private void Admin_Cities_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.Cities_Form(FormMode.Search));
        }

        private void Admin_States_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.States_Form(FormMode.Search));
        }

        private void Admin_Todolist_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_ToDoList_Form(FormModes.Add));
        }

        private void Admin_PettyCash_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.PettyCash_Form());
        }

        private void Admin_PettyCashCategories_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new MasterData.PettyCashRecordsCategories_Form(FormMode.New));
        }

        #endregion MENU - ADMIN
        /*******************************************************************************************************/
        #region MENU - ACCOUNT

        private void Account_Log_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Logs.Main_Form(GlobalData.UserAccount.id));
        }

        private void Account_Peraturan_Click(object sender, EventArgs e)
        {

        }

        private void Account_Komisi_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.SalesComission_Form());
        }

        private void Account_Password_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.PasswordChange_Form());
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - SALES

        private void Sales_SaleOrders_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Sales.SaleOrders_Form());
        }

        private void Sales_Daftar_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Sales.Main_Form());
        }

        private void Sales_FakturPajak_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new SharedForms.MasterData_v1_FakturPajaks_Form(FormModes.Add));
        }

        private void Sales_Returns_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Returns.Main_Form());
        }

        private void Sales_Customers_Credits_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new CustomerCredits.Main_Form());
        }

        private void Sales_Kontrabon_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Sales.MasterData_v2_Kontrabons_Form());
        }

        private void Sales_Customers_Daftar_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_Customers_Form(FormModes.Search));
        }

        private void Sales_Customers_Discounts_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_CustomerSaleAdjustments(FormModes.Add));
        }

        private void Sales_Customers_DebLimits_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.MasterData_v1_CustomerTerms_Form());
        }

        #endregion
        /*******************************************************************************************************/
        #region MENU - INTERNAL

        private void Internal_Test_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Test.Main_Form());
        }

        private void Internal_UserAccounts_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Users.Main_Form());
        }

        private void Internal_Reports_Taxes_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Taxes_Form());
        }

        private void Internal_Reports_Sales_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Sales_Form());
        }

        private void Internal_Reports_Financial_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Reports.Financial_Overview_Form());
        }

        private void Internal_Summary_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Summary_Superuser_Form());
        }

        private void Internal_Settings_Click(object sender, EventArgs e)
        {
            Util.displayMDIChild(new Admin.Settings_Form());
        }

        #endregion MENU - INTERNAL
        /*******************************************************************************************************/
    }
}
