namespace BinaMitraTextile
{
    partial class Container_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menu_sales = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_sales_list = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_sales_saleorders = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_stock = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_stocklevel = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_invoices = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_opname = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_po = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_printbarcodes = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_inventory_samples = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_returns = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_customercredit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin = new System.Windows.Forms.ToolStripMenuItem();
            this.angkutanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_cities = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_colors = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_customers = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_customersaleadjustments = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_customerterms = new System.Windows.Forms.ToolStripMenuItem();
            this.gradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_length_units = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_pettycashcategories = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_pettycash = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_prices = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_products = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_productstorenames = new System.Windows.Forms.ToolStripMenuItem();
            this.statesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_vendors = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_vendorinvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_admin_widths = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_users = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_reports = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_reports_financial = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_reports_sales = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_reports_tax = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_todolist = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_test = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account_password = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account_salescomission = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account_rules = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_account_log = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.expandCollapseToggle1 = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.pnlShortcuts = new System.Windows.Forms.Panel();
            this.gbShortcuts = new System.Windows.Forms.GroupBox();
            this.flpShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkCreateSales = new System.Windows.Forms.LinkLabel();
            this.lnkInventory = new System.Windows.Forms.LinkLabel();
            this.lnkOpname = new System.Windows.Forms.LinkLabel();
            this.lnkPettyCash = new System.Windows.Forms.LinkLabel();
            this.lnkSummary = new System.Windows.Forms.LinkLabel();
            this.mainMenu.SuspendLayout();
            this.pnlShortcuts.SuspendLayout();
            this.gbShortcuts.SuspendLayout();
            this.flpShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_sales,
            this.menu_inventory,
            this.menu_returns,
            this.menu_customercredit,
            this.menu_admin,
            this.menu_users,
            this.menu_reports,
            this.menu_todolist,
            this.menu_test,
            this.menu_account,
            this.menu_quit});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "mainMenu";
            // 
            // menu_sales
            // 
            this.menu_sales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_sales_list,
            this.menu_sales_saleorders});
            this.menu_sales.Name = "menu_sales";
            this.menu_sales.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.menu_sales.Size = new System.Drawing.Size(45, 20);
            this.menu_sales.Text = "Sales";
            // 
            // menu_sales_list
            // 
            this.menu_sales_list.Name = "menu_sales_list";
            this.menu_sales_list.Size = new System.Drawing.Size(180, 22);
            this.menu_sales_list.Text = "Daftar Sales";
            this.menu_sales_list.Click += new System.EventHandler(this.menu_sales_list_Click);
            // 
            // menu_sales_saleorders
            // 
            this.menu_sales_saleorders.Name = "menu_sales_saleorders";
            this.menu_sales_saleorders.Size = new System.Drawing.Size(180, 22);
            this.menu_sales_saleorders.Text = "Sale Orders";
            this.menu_sales_saleorders.Click += new System.EventHandler(this.menu_sales_saleorders_Click);
            // 
            // menu_inventory
            // 
            this.menu_inventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_inventory_stock,
            this.menu_inventory_stocklevel,
            this.menu_inventory_invoices,
            this.menu_inventory_opname,
            this.menu_inventory_po,
            this.menu_inventory_printbarcodes,
            this.menu_inventory_samples});
            this.menu_inventory.Name = "menu_inventory";
            this.menu_inventory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.menu_inventory.Size = new System.Drawing.Size(69, 20);
            this.menu_inventory.Text = "Inventory";
            // 
            // menu_inventory_stock
            // 
            this.menu_inventory_stock.Name = "menu_inventory_stock";
            this.menu_inventory_stock.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.menu_inventory_stock.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_stock.Text = "Stock";
            this.menu_inventory_stock.Click += new System.EventHandler(this.menu_inventory_stock_Click);
            // 
            // menu_inventory_stocklevel
            // 
            this.menu_inventory_stocklevel.Name = "menu_inventory_stocklevel";
            this.menu_inventory_stocklevel.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_stocklevel.Text = "Stock Level";
            this.menu_inventory_stocklevel.Click += new System.EventHandler(this.menu_inventory_stocklevel_Click);
            // 
            // menu_inventory_invoices
            // 
            this.menu_inventory_invoices.Name = "menu_inventory_invoices";
            this.menu_inventory_invoices.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.menu_inventory_invoices.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_invoices.Text = "Invoices";
            this.menu_inventory_invoices.Click += new System.EventHandler(this.menu_inventory_invoices_Click);
            // 
            // menu_inventory_opname
            // 
            this.menu_inventory_opname.Name = "menu_inventory_opname";
            this.menu_inventory_opname.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.menu_inventory_opname.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_opname.Text = "Opname";
            this.menu_inventory_opname.Click += new System.EventHandler(this.menu_inventory_opname_Click);
            // 
            // menu_inventory_po
            // 
            this.menu_inventory_po.Name = "menu_inventory_po";
            this.menu_inventory_po.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.menu_inventory_po.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_po.Text = "PO";
            this.menu_inventory_po.Click += new System.EventHandler(this.menu_inventory_po_Click);
            // 
            // menu_inventory_printbarcodes
            // 
            this.menu_inventory_printbarcodes.Name = "menu_inventory_printbarcodes";
            this.menu_inventory_printbarcodes.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_printbarcodes.Text = "Print Barcodes";
            this.menu_inventory_printbarcodes.Click += new System.EventHandler(this.menu_inventory_printbarcodes_Click);
            // 
            // menu_inventory_samples
            // 
            this.menu_inventory_samples.Name = "menu_inventory_samples";
            this.menu_inventory_samples.Size = new System.Drawing.Size(180, 22);
            this.menu_inventory_samples.Text = "Samples";
            this.menu_inventory_samples.Click += new System.EventHandler(this.menu_inventory_samples_Click);
            // 
            // menu_returns
            // 
            this.menu_returns.Name = "menu_returns";
            this.menu_returns.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.menu_returns.Size = new System.Drawing.Size(59, 20);
            this.menu_returns.Text = "Returns";
            this.menu_returns.Click += new System.EventHandler(this.menu_returns_Click);
            // 
            // menu_customercredit
            // 
            this.menu_customercredit.Name = "menu_customercredit";
            this.menu_customercredit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.menu_customercredit.Size = new System.Drawing.Size(56, 20);
            this.menu_customercredit.Text = "Credits";
            this.menu_customercredit.Click += new System.EventHandler(this.menu_customercredit_Click);
            // 
            // menu_admin
            // 
            this.menu_admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.angkutanToolStripMenuItem,
            this.menu_admin_cities,
            this.menu_admin_colors,
            this.menu_admin_customers,
            this.menu_admin_customersaleadjustments,
            this.menu_admin_customerterms,
            this.gradesToolStripMenuItem,
            this.menu_admin_length_units,
            this.menu_admin_pettycashcategories,
            this.menu_admin_pettycash,
            this.menu_admin_prices,
            this.menu_admin_products,
            this.menu_admin_productstorenames,
            this.statesToolStripMenuItem,
            this.menu_admin_vendors,
            this.menu_admin_vendorinvoices,
            this.menu_admin_widths});
            this.menu_admin.Name = "menu_admin";
            this.menu_admin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.menu_admin.Size = new System.Drawing.Size(55, 20);
            this.menu_admin.Text = "Admin";
            // 
            // angkutanToolStripMenuItem
            // 
            this.angkutanToolStripMenuItem.Name = "angkutanToolStripMenuItem";
            this.angkutanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.angkutanToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.angkutanToolStripMenuItem.Text = "Angkutan";
            this.angkutanToolStripMenuItem.Click += new System.EventHandler(this.menu_admin_angkutan_Click);
            // 
            // menu_admin_cities
            // 
            this.menu_admin_cities.Name = "menu_admin_cities";
            this.menu_admin_cities.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.menu_admin_cities.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_cities.Text = "Cities";
            this.menu_admin_cities.Click += new System.EventHandler(this.menu_admin_cities_Click);
            // 
            // menu_admin_colors
            // 
            this.menu_admin_colors.Name = "menu_admin_colors";
            this.menu_admin_colors.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_colors.Text = "Colors";
            this.menu_admin_colors.Click += new System.EventHandler(this.menu_admin_colors_Click);
            // 
            // menu_admin_customers
            // 
            this.menu_admin_customers.Name = "menu_admin_customers";
            this.menu_admin_customers.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_customers.Text = "Customers";
            this.menu_admin_customers.Click += new System.EventHandler(this.menu_admin_customers_Click);
            // 
            // menu_admin_customersaleadjustments
            // 
            this.menu_admin_customersaleadjustments.Name = "menu_admin_customersaleadjustments";
            this.menu_admin_customersaleadjustments.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_customersaleadjustments.Text = "Customer Discounts";
            this.menu_admin_customersaleadjustments.Click += new System.EventHandler(this.menu_admin_customersaleadjustments_Click);
            // 
            // menu_admin_customerterms
            // 
            this.menu_admin_customerterms.Name = "menu_admin_customerterms";
            this.menu_admin_customerterms.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_customerterms.Text = "Debt Limits";
            this.menu_admin_customerterms.Click += new System.EventHandler(this.menu_admin_customerterms_Click);
            // 
            // gradesToolStripMenuItem
            // 
            this.gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            this.gradesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.gradesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gradesToolStripMenuItem.Text = "Grades";
            this.gradesToolStripMenuItem.Click += new System.EventHandler(this.menu_admin_grades_Click);
            // 
            // menu_admin_length_units
            // 
            this.menu_admin_length_units.Name = "menu_admin_length_units";
            this.menu_admin_length_units.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.menu_admin_length_units.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_length_units.Text = "Length Units";
            this.menu_admin_length_units.Click += new System.EventHandler(this.menu_admin_length_units_Click);
            // 
            // menu_admin_pettycashcategories
            // 
            this.menu_admin_pettycashcategories.Name = "menu_admin_pettycashcategories";
            this.menu_admin_pettycashcategories.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_pettycashcategories.Text = "Petty Cash Categories";
            this.menu_admin_pettycashcategories.Click += new System.EventHandler(this.menu_admin_pettycashcategories_Click);
            // 
            // menu_admin_pettycash
            // 
            this.menu_admin_pettycash.Name = "menu_admin_pettycash";
            this.menu_admin_pettycash.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_pettycash.Text = "Petty Cash";
            this.menu_admin_pettycash.Click += new System.EventHandler(this.menu_admin_pettycash_Click);
            // 
            // menu_admin_prices
            // 
            this.menu_admin_prices.Name = "menu_admin_prices";
            this.menu_admin_prices.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.menu_admin_prices.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_prices.Text = "Prices";
            this.menu_admin_prices.Click += new System.EventHandler(this.menu_admin_prices_Click);
            // 
            // menu_admin_products
            // 
            this.menu_admin_products.Name = "menu_admin_products";
            this.menu_admin_products.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_products.Text = "Products";
            this.menu_admin_products.Click += new System.EventHandler(this.menu_admin_products_Click);
            // 
            // menu_admin_productstorenames
            // 
            this.menu_admin_productstorenames.Name = "menu_admin_productstorenames";
            this.menu_admin_productstorenames.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_productstorenames.Text = "Product Store Names";
            this.menu_admin_productstorenames.Click += new System.EventHandler(this.menu_admin_productstorenames_Click);
            // 
            // statesToolStripMenuItem
            // 
            this.statesToolStripMenuItem.Name = "statesToolStripMenuItem";
            this.statesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.statesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.statesToolStripMenuItem.Text = "States";
            this.statesToolStripMenuItem.Click += new System.EventHandler(this.menu_admin_states_Click);
            // 
            // menu_admin_vendors
            // 
            this.menu_admin_vendors.Name = "menu_admin_vendors";
            this.menu_admin_vendors.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.menu_admin_vendors.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_vendors.Text = "Vendors";
            this.menu_admin_vendors.Click += new System.EventHandler(this.menu_admin_vendors_Click);
            // 
            // menu_admin_vendorinvoices
            // 
            this.menu_admin_vendorinvoices.Name = "menu_admin_vendorinvoices";
            this.menu_admin_vendorinvoices.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_vendorinvoices.Text = "Vendor Invoices";
            this.menu_admin_vendorinvoices.Click += new System.EventHandler(this.menu_admin_vendorinvoices_Click);
            // 
            // menu_admin_widths
            // 
            this.menu_admin_widths.Name = "menu_admin_widths";
            this.menu_admin_widths.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.menu_admin_widths.Size = new System.Drawing.Size(189, 22);
            this.menu_admin_widths.Text = "Widths";
            this.menu_admin_widths.Click += new System.EventHandler(this.menu_admin_widths_Click);
            // 
            // menu_users
            // 
            this.menu_users.Name = "menu_users";
            this.menu_users.Size = new System.Drawing.Size(47, 20);
            this.menu_users.Text = "Users";
            this.menu_users.Click += new System.EventHandler(this.menu_users_Click);
            // 
            // menu_reports
            // 
            this.menu_reports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_reports_financial,
            this.menu_reports_sales,
            this.menu_reports_tax});
            this.menu_reports.Name = "menu_reports";
            this.menu_reports.Size = new System.Drawing.Size(59, 20);
            this.menu_reports.Text = "Reports";
            // 
            // menu_reports_financial
            // 
            this.menu_reports_financial.Name = "menu_reports_financial";
            this.menu_reports_financial.Size = new System.Drawing.Size(180, 22);
            this.menu_reports_financial.Text = "Financial";
            this.menu_reports_financial.Click += new System.EventHandler(this.menu_reports_financial_Click);
            // 
            // menu_reports_sales
            // 
            this.menu_reports_sales.Name = "menu_reports_sales";
            this.menu_reports_sales.Size = new System.Drawing.Size(180, 22);
            this.menu_reports_sales.Text = "Sales";
            this.menu_reports_sales.Click += new System.EventHandler(this.menu_reports_sales_Click);
            // 
            // menu_reports_tax
            // 
            this.menu_reports_tax.Name = "menu_reports_tax";
            this.menu_reports_tax.Size = new System.Drawing.Size(180, 22);
            this.menu_reports_tax.Text = "Tax";
            this.menu_reports_tax.Click += new System.EventHandler(this.menu_reports_tax_Click);
            // 
            // menu_todolist
            // 
            this.menu_todolist.Name = "menu_todolist";
            this.menu_todolist.Size = new System.Drawing.Size(70, 20);
            this.menu_todolist.Text = "To Do List";
            this.menu_todolist.Click += new System.EventHandler(this.menu_todolist_Click);
            // 
            // menu_test
            // 
            this.menu_test.Name = "menu_test";
            this.menu_test.Size = new System.Drawing.Size(39, 20);
            this.menu_test.Text = "Test";
            this.menu_test.Click += new System.EventHandler(this.menu_test_Click);
            // 
            // menu_account
            // 
            this.menu_account.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_account_password,
            this.menu_account_salescomission,
            this.menu_account_rules,
            this.menu_account_log});
            this.menu_account.Name = "menu_account";
            this.menu_account.Size = new System.Drawing.Size(64, 20);
            this.menu_account.Text = "Account";
            // 
            // menu_account_password
            // 
            this.menu_account_password.Name = "menu_account_password";
            this.menu_account_password.Size = new System.Drawing.Size(180, 22);
            this.menu_account_password.Text = "Password";
            this.menu_account_password.Click += new System.EventHandler(this.menu_account_password_Click);
            // 
            // menu_account_salescomission
            // 
            this.menu_account_salescomission.Name = "menu_account_salescomission";
            this.menu_account_salescomission.Size = new System.Drawing.Size(180, 22);
            this.menu_account_salescomission.Text = "Komisi";
            this.menu_account_salescomission.Click += new System.EventHandler(this.menu_account_salescomission_Click);
            // 
            // menu_account_rules
            // 
            this.menu_account_rules.Name = "menu_account_rules";
            this.menu_account_rules.Size = new System.Drawing.Size(180, 22);
            this.menu_account_rules.Text = "Peraturan";
            this.menu_account_rules.Visible = false;
            // 
            // menu_account_log
            // 
            this.menu_account_log.Name = "menu_account_log";
            this.menu_account_log.Size = new System.Drawing.Size(180, 22);
            this.menu_account_log.Text = "Log";
            this.menu_account_log.Click += new System.EventHandler(this.menu_account_log_Click);
            // 
            // menu_quit
            // 
            this.menu_quit.Name = "menu_quit";
            this.menu_quit.Size = new System.Drawing.Size(42, 20);
            this.menu_quit.Text = "Quit";
            this.menu_quit.Click += new System.EventHandler(this.menu_quit_Click);
            // 
            // expandCollapseToggle1
            // 
            this.expandCollapseToggle1.AdjustLocationOnClick = true;
            this.expandCollapseToggle1.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Left;
            this.expandCollapseToggle1.Location = new System.Drawing.Point(145, 24);
            this.expandCollapseToggle1.Margin = new System.Windows.Forms.Padding(4);
            this.expandCollapseToggle1.Name = "expandCollapseToggle1";
            this.expandCollapseToggle1.Size = new System.Drawing.Size(20, 20);
            this.expandCollapseToggle1.TabIndex = 19;
            this.expandCollapseToggle1.TogglePanel = this.pnlShortcuts;
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.BackColor = System.Drawing.Color.White;
            this.pnlShortcuts.Controls.Add(this.gbShortcuts);
            this.pnlShortcuts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlShortcuts.Location = new System.Drawing.Point(0, 24);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Padding = new System.Windows.Forms.Padding(5);
            this.pnlShortcuts.Size = new System.Drawing.Size(145, 426);
            this.pnlShortcuts.TabIndex = 18;
            // 
            // gbShortcuts
            // 
            this.gbShortcuts.AutoSize = true;
            this.gbShortcuts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbShortcuts.Controls.Add(this.flpShortcuts);
            this.gbShortcuts.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbShortcuts.Location = new System.Drawing.Point(5, 5);
            this.gbShortcuts.Name = "gbShortcuts";
            this.gbShortcuts.Size = new System.Drawing.Size(135, 144);
            this.gbShortcuts.TabIndex = 14;
            this.gbShortcuts.TabStop = false;
            this.gbShortcuts.Text = "Shortcuts";
            // 
            // flpShortcuts
            // 
            this.flpShortcuts.AutoSize = true;
            this.flpShortcuts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpShortcuts.Controls.Add(this.lnkCreateSales);
            this.flpShortcuts.Controls.Add(this.lnkInventory);
            this.flpShortcuts.Controls.Add(this.lnkOpname);
            this.flpShortcuts.Controls.Add(this.lnkPettyCash);
            this.flpShortcuts.Controls.Add(this.lnkSummary);
            this.flpShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpShortcuts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpShortcuts.Location = new System.Drawing.Point(3, 16);
            this.flpShortcuts.Name = "flpShortcuts";
            this.flpShortcuts.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flpShortcuts.Size = new System.Drawing.Size(129, 125);
            this.flpShortcuts.TabIndex = 17;
            // 
            // lnkCreateSales
            // 
            this.lnkCreateSales.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkCreateSales.AutoSize = true;
            this.lnkCreateSales.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lnkCreateSales.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateSales.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkCreateSales.Location = new System.Drawing.Point(3, 5);
            this.lnkCreateSales.Name = "lnkCreateSales";
            this.lnkCreateSales.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lnkCreateSales.Size = new System.Drawing.Size(80, 23);
            this.lnkCreateSales.TabIndex = 25;
            this.lnkCreateSales.TabStop = true;
            this.lnkCreateSales.Text = "CREATE SALE";
            this.lnkCreateSales.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkCreateSales.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkCreateSales_LinkClicked);
            // 
            // lnkInventory
            // 
            this.lnkInventory.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkInventory.AutoSize = true;
            this.lnkInventory.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lnkInventory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkInventory.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkInventory.Location = new System.Drawing.Point(3, 28);
            this.lnkInventory.Name = "lnkInventory";
            this.lnkInventory.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lnkInventory.Size = new System.Drawing.Size(70, 23);
            this.lnkInventory.TabIndex = 21;
            this.lnkInventory.TabStop = true;
            this.lnkInventory.Text = "INVENTORY";
            this.lnkInventory.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkInventory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkInventory_LinkClicked);
            // 
            // lnkOpname
            // 
            this.lnkOpname.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkOpname.AutoSize = true;
            this.lnkOpname.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lnkOpname.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOpname.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkOpname.Location = new System.Drawing.Point(3, 51);
            this.lnkOpname.Name = "lnkOpname";
            this.lnkOpname.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lnkOpname.Size = new System.Drawing.Size(53, 23);
            this.lnkOpname.TabIndex = 22;
            this.lnkOpname.TabStop = true;
            this.lnkOpname.Text = "OPNAME";
            this.lnkOpname.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkOpname.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkOpname_LinkClicked);
            // 
            // lnkPettyCash
            // 
            this.lnkPettyCash.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkPettyCash.AutoSize = true;
            this.lnkPettyCash.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lnkPettyCash.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPettyCash.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkPettyCash.Location = new System.Drawing.Point(3, 74);
            this.lnkPettyCash.Name = "lnkPettyCash";
            this.lnkPettyCash.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lnkPettyCash.Size = new System.Drawing.Size(36, 23);
            this.lnkPettyCash.TabIndex = 23;
            this.lnkPettyCash.TabStop = true;
            this.lnkPettyCash.Text = "CASH";
            this.lnkPettyCash.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkPettyCash.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkPettyCash_LinkClicked);
            // 
            // lnkSummary
            // 
            this.lnkSummary.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkSummary.AutoSize = true;
            this.lnkSummary.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lnkSummary.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSummary.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkSummary.Location = new System.Drawing.Point(3, 97);
            this.lnkSummary.Name = "lnkSummary";
            this.lnkSummary.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lnkSummary.Size = new System.Drawing.Size(62, 23);
            this.lnkSummary.TabIndex = 24;
            this.lnkSummary.TabStop = true;
            this.lnkSummary.Text = "SUMMARY";
            this.lnkSummary.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkSummary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkSummary_LinkClicked);
            // 
            // Container_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.expandCollapseToggle1);
            this.Controls.Add(this.pnlShortcuts);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.Name = "Container_Form";
            this.Text = "BINA MITRA TEXTILE APP";
            this.Load += new System.EventHandler(this.Form_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.pnlShortcuts.ResumeLayout(false);
            this.pnlShortcuts.PerformLayout();
            this.gbShortcuts.ResumeLayout(false);
            this.gbShortcuts.PerformLayout();
            this.flpShortcuts.ResumeLayout(false);
            this.flpShortcuts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_sales;
        private System.Windows.Forms.ToolStripMenuItem menu_sales_list;
        private System.Windows.Forms.ToolStripMenuItem menu_sales_saleorders;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_stock;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_stocklevel;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_invoices;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_opname;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_po;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_printbarcodes;
        private System.Windows.Forms.ToolStripMenuItem menu_inventory_samples;
        private System.Windows.Forms.ToolStripMenuItem menu_returns;
        private System.Windows.Forms.ToolStripMenuItem menu_customercredit;
        private System.Windows.Forms.ToolStripMenuItem menu_admin;
        private System.Windows.Forms.ToolStripMenuItem angkutanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_cities;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_colors;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_customers;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_customersaleadjustments;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_customerterms;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_length_units;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_pettycashcategories;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_pettycash;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_prices;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_products;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_productstorenames;
        private System.Windows.Forms.ToolStripMenuItem statesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_vendors;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_vendorinvoices;
        private System.Windows.Forms.ToolStripMenuItem menu_admin_widths;
        private System.Windows.Forms.ToolStripMenuItem menu_users;
        private System.Windows.Forms.ToolStripMenuItem menu_reports;
        private System.Windows.Forms.ToolStripMenuItem menu_reports_financial;
        private System.Windows.Forms.ToolStripMenuItem menu_reports_sales;
        private System.Windows.Forms.ToolStripMenuItem menu_reports_tax;
        private System.Windows.Forms.ToolStripMenuItem menu_todolist;
        private System.Windows.Forms.ToolStripMenuItem menu_test;
        private System.Windows.Forms.ToolStripMenuItem menu_account;
        private System.Windows.Forms.ToolStripMenuItem menu_account_password;
        private System.Windows.Forms.ToolStripMenuItem menu_account_salescomission;
        private System.Windows.Forms.ToolStripMenuItem menu_account_rules;
        private System.Windows.Forms.ToolStripMenuItem menu_account_log;
        private System.Windows.Forms.ToolStripMenuItem menu_quit;
        private LIBUtil.Desktop.UserControls.PanelToggle expandCollapseToggle1;
        private System.Windows.Forms.Panel pnlShortcuts;
        private System.Windows.Forms.GroupBox gbShortcuts;
        private System.Windows.Forms.FlowLayoutPanel flpShortcuts;
        private System.Windows.Forms.LinkLabel lnkCreateSales;
        private System.Windows.Forms.LinkLabel lnkInventory;
        private System.Windows.Forms.LinkLabel lnkOpname;
        private System.Windows.Forms.LinkLabel lnkPettyCash;
        private System.Windows.Forms.LinkLabel lnkSummary;
    }
}