﻿namespace BinaMitraTextile.Sales
{
    partial class MasterData_v1_FakturPajaks_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            this.idtp_Timestamp = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_DPP = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.itxt_No = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_PPN = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnAddSales = new System.Windows.Forms.Button();
            this.gridSaleInvoices = new System.Windows.Forms.DataGridView();
            this.col_gridSaleInvoices_removeFakturPajaks_Id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridSaleInvoices_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_hexbarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridSaleInvoices_sale_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_sale_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_SaleAmount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridSaleInvoices_shippingcost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_ReceivableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_returnedamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_Sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.btnAddReturns = new System.Windows.Forms.Button();
            this.gridReturns = new System.Windows.Forms.DataGridView();
            this.col_gridReturns_removeFakturPajaks_Id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridReturns_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridReturns_hexbarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridReturns_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridReturns_sale_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridReturns_sale_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridReturns_sale_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridReturns_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRowInfoHeader = new System.Windows.Forms.Label();
            this.chkShowCompleted = new System.Windows.Forms.CheckBox();
            this.idtp_StartDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.idtp_EndDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.tcRowInfo = new System.Windows.Forms.TabControl();
            this.tpSaleInvoices = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tpVendorInvoices = new System.Windows.Forms.TabPage();
            this.gridVendorInvoices = new System.Windows.Forms.DataGridView();
            this.col_gridvendorinvoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoices_removeFakturPajaks_Id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridvendorinvoice_statusenumid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_invoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddVendorInvoices = new System.Windows.Forms.Button();
            this.tpSaleReturns = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iddl_Vendors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.rbVendor = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.Panel1.SuspendLayout();
            this.scInputLeft.Panel2.SuspendLayout();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.Panel1.SuspendLayout();
            this.scInputRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).BeginInit();
            this.scInputContainer.Panel1.SuspendLayout();
            this.scInputContainer.Panel2.SuspendLayout();
            this.scInputContainer.SuspendLayout();
            this.pnlQuickSearch.SuspendLayout();
            this.pnlRowInfo.SuspendLayout();
            this.pnlRowInfoHeader.SuspendLayout();
            this.pnlRowInfoContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturns)).BeginInit();
            this.tcRowInfo.SuspendLayout();
            this.tpSaleInvoices.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tpVendorInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoices)).BeginInit();
            this.panel3.SuspendLayout();
            this.tpSaleReturns.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(884, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 177);
            this.pnlActionButtons.Size = new System.Drawing.Size(884, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.rbCustomer);
            this.scInputLeft.Panel1.Controls.Add(this.rbVendor);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Vendors);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Customers);
            this.scInputLeft.Panel1.Controls.Add(this.itxt_No);
            this.scInputLeft.Panel1.Controls.Add(this.idtp_Timestamp);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.itxt_Notes);
            this.scInputLeft.Panel2.Controls.Add(this.in_PPN);
            this.scInputLeft.Panel2.Controls.Add(this.in_DPP);
            this.scInputLeft.Size = new System.Drawing.Size(500, 151);
            // 
            // scInputRight
            // 
            // 
            // scInputRight.Panel1
            // 
            this.scInputRight.Panel1.Controls.Add(this.idtp_StartDate);
            this.scInputRight.Panel1.Controls.Add(this.idtp_EndDate);
            this.scInputRight.Size = new System.Drawing.Size(380, 151);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.DarkOrange;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(884, 531);
            this.scMain.SplitterDistance = 200;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(884, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(884, 151);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkShowCompleted);
            this.pnlQuickSearch.Size = new System.Drawing.Size(854, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkShowCompleted, 0);
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Location = new System.Drawing.Point(0, 162);
            this.pnlRowInfo.Size = new System.Drawing.Size(884, 168);
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.Controls.Add(this.lblRowInfoHeader);
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(864, 21);
            // 
            // pnlRowInfoContent
            // 
            this.pnlRowInfoContent.Controls.Add(this.tcRowInfo);
            this.pnlRowInfoContent.Size = new System.Drawing.Size(884, 147);
            // 
            // idtp_Timestamp
            // 
            this.idtp_Timestamp.Checked = true;
            this.idtp_Timestamp.CustomFormat = "dd/MM/yy";
            this.idtp_Timestamp.DefaultCheckedValue = false;
            this.idtp_Timestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_Timestamp.LabelText = "Date";
            this.idtp_Timestamp.Location = new System.Drawing.Point(156, 6);
            this.idtp_Timestamp.Name = "idtp_Timestamp";
            this.idtp_Timestamp.ShowCheckBox = false;
            this.idtp_Timestamp.ShowDateTimePickerOnly = false;
            this.idtp_Timestamp.ShowUpAndDown = false;
            this.idtp_Timestamp.Size = new System.Drawing.Size(86, 41);
            this.idtp_Timestamp.TabIndex = 1;
            this.idtp_Timestamp.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_Timestamp.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(6, 50);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(234, 86);
            this.itxt_Notes.TabIndex = 5;
            this.itxt_Notes.ValueText = "";
            // 
            // in_DPP
            // 
            this.in_DPP.Checked = false;
            this.in_DPP.DecimalPlaces = 2;
            this.in_DPP.HideUpDown = false;
            this.in_DPP.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.in_DPP.LabelText = "DPP";
            this.in_DPP.Location = new System.Drawing.Point(6, 6);
            this.in_DPP.MaximumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            0});
            this.in_DPP.MinimumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            -2147483648});
            this.in_DPP.Name = "in_DPP";
            this.in_DPP.ShowAllowDecimalCheckbox = false;
            this.in_DPP.ShowCheckbox = false;
            this.in_DPP.ShowTextboxOnly = false;
            this.in_DPP.Size = new System.Drawing.Size(115, 41);
            this.in_DPP.TabIndex = 3;
            this.in_DPP.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_DPP.ValueChanged += new System.EventHandler(this.In_DPP_ValueChanged);
            // 
            // itxt_No
            // 
            this.itxt_No.IsBrowseMode = false;
            this.itxt_No.LabelText = "Nomor Faktur";
            this.itxt_No.Location = new System.Drawing.Point(8, 6);
            this.itxt_No.MaxLength = 32767;
            this.itxt_No.MultiLine = false;
            this.itxt_No.Name = "itxt_No";
            this.itxt_No.PasswordChar = '\0';
            this.itxt_No.RowCount = 1;
            this.itxt_No.ShowDeleteButton = false;
            this.itxt_No.ShowFilter = false;
            this.itxt_No.ShowTextboxOnly = false;
            this.itxt_No.Size = new System.Drawing.Size(142, 41);
            this.itxt_No.TabIndex = 0;
            this.itxt_No.ValueText = "";
            // 
            // in_PPN
            // 
            this.in_PPN.Checked = false;
            this.in_PPN.DecimalPlaces = 2;
            this.in_PPN.HideUpDown = false;
            this.in_PPN.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_PPN.LabelText = "PPN";
            this.in_PPN.Location = new System.Drawing.Point(125, 6);
            this.in_PPN.MaximumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            0});
            this.in_PPN.MinimumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            -2147483648});
            this.in_PPN.Name = "in_PPN";
            this.in_PPN.ShowAllowDecimalCheckbox = false;
            this.in_PPN.ShowCheckbox = false;
            this.in_PPN.ShowTextboxOnly = false;
            this.in_PPN.Size = new System.Drawing.Size(115, 41);
            this.in_PPN.TabIndex = 4;
            this.in_PPN.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnAddSales
            // 
            this.btnAddSales.Location = new System.Drawing.Point(1, 1);
            this.btnAddSales.Name = "btnAddSales";
            this.btnAddSales.Size = new System.Drawing.Size(40, 23);
            this.btnAddSales.TabIndex = 127;
            this.btnAddSales.Text = "ADD";
            this.btnAddSales.UseVisualStyleBackColor = true;
            this.btnAddSales.Click += new System.EventHandler(this.BtnAddSales_Click);
            // 
            // gridSaleInvoices
            // 
            this.gridSaleInvoices.AllowUserToAddRows = false;
            this.gridSaleInvoices.AllowUserToDeleteRows = false;
            this.gridSaleInvoices.AllowUserToResizeRows = false;
            this.gridSaleInvoices.BackgroundColor = System.Drawing.Color.White;
            this.gridSaleInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSaleInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSaleInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.gridSaleInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSaleInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridSaleInvoices_removeFakturPajaks_Id,
            this.col_gridSaleInvoices_timestamp,
            this.col_gridSaleInvoices_hexbarcode,
            this.col_gridSaleInvoices_sale_qty,
            this.col_gridSaleInvoices_sale_length,
            this.col_gridSaleInvoices_SaleAmount,
            this.col_gridSaleInvoices_shippingcost,
            this.col_gridSaleInvoices_ReceivableAmount,
            this.col_gridSaleInvoices_returnedamount,
            this.col_gridSaleInvoices_Sales_id});
            this.gridSaleInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSaleInvoices.Location = new System.Drawing.Point(3, 28);
            this.gridSaleInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.gridSaleInvoices.MultiSelect = false;
            this.gridSaleInvoices.Name = "gridSaleInvoices";
            this.gridSaleInvoices.ReadOnly = true;
            this.gridSaleInvoices.RowHeadersVisible = false;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridSaleInvoices.RowsDefaultCellStyle = dataGridViewCellStyle57;
            this.gridSaleInvoices.RowTemplate.Height = 24;
            this.gridSaleInvoices.Size = new System.Drawing.Size(870, 90);
            this.gridSaleInvoices.TabIndex = 128;
            this.gridSaleInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSaleInvoices_CellContentClick);
            // 
            // col_gridSaleInvoices_removeFakturPajaks_Id
            // 
            this.col_gridSaleInvoices_removeFakturPajaks_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_gridSaleInvoices_removeFakturPajaks_Id.DefaultCellStyle = dataGridViewCellStyle48;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.HeaderText = "";
            this.col_gridSaleInvoices_removeFakturPajaks_Id.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.LinkColor = System.Drawing.Color.Red;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.MinimumWidth = 10;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.Name = "col_gridSaleInvoices_removeFakturPajaks_Id";
            this.col_gridSaleInvoices_removeFakturPajaks_Id.ReadOnly = true;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.Text = "X";
            this.col_gridSaleInvoices_removeFakturPajaks_Id.UseColumnTextForLinkValue = true;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.VisitedLinkColor = System.Drawing.Color.Red;
            this.col_gridSaleInvoices_removeFakturPajaks_Id.Width = 10;
            // 
            // col_gridSaleInvoices_timestamp
            // 
            this.col_gridSaleInvoices_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle49.Format = "dd/MM/yy";
            this.col_gridSaleInvoices_timestamp.DefaultCellStyle = dataGridViewCellStyle49;
            this.col_gridSaleInvoices_timestamp.HeaderText = "Date";
            this.col_gridSaleInvoices_timestamp.MinimumWidth = 50;
            this.col_gridSaleInvoices_timestamp.Name = "col_gridSaleInvoices_timestamp";
            this.col_gridSaleInvoices_timestamp.ReadOnly = true;
            this.col_gridSaleInvoices_timestamp.Width = 50;
            // 
            // col_gridSaleInvoices_hexbarcode
            // 
            this.col_gridSaleInvoices_hexbarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_hexbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_gridSaleInvoices_hexbarcode.DefaultCellStyle = dataGridViewCellStyle50;
            this.col_gridSaleInvoices_hexbarcode.HeaderText = "Invoice";
            this.col_gridSaleInvoices_hexbarcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridSaleInvoices_hexbarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_hexbarcode.MinimumWidth = 40;
            this.col_gridSaleInvoices_hexbarcode.Name = "col_gridSaleInvoices_hexbarcode";
            this.col_gridSaleInvoices_hexbarcode.ReadOnly = true;
            this.col_gridSaleInvoices_hexbarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridSaleInvoices_hexbarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridSaleInvoices_hexbarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_hexbarcode.Width = 40;
            // 
            // col_gridSaleInvoices_sale_qty
            // 
            this.col_gridSaleInvoices_sale_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Format = "N0";
            this.col_gridSaleInvoices_sale_qty.DefaultCellStyle = dataGridViewCellStyle51;
            this.col_gridSaleInvoices_sale_qty.HeaderText = "Pcs";
            this.col_gridSaleInvoices_sale_qty.MinimumWidth = 30;
            this.col_gridSaleInvoices_sale_qty.Name = "col_gridSaleInvoices_sale_qty";
            this.col_gridSaleInvoices_sale_qty.ReadOnly = true;
            this.col_gridSaleInvoices_sale_qty.Width = 30;
            // 
            // col_gridSaleInvoices_sale_length
            // 
            this.col_gridSaleInvoices_sale_length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle52.Format = "N2";
            this.col_gridSaleInvoices_sale_length.DefaultCellStyle = dataGridViewCellStyle52;
            this.col_gridSaleInvoices_sale_length.HeaderText = "Qty";
            this.col_gridSaleInvoices_sale_length.MinimumWidth = 30;
            this.col_gridSaleInvoices_sale_length.Name = "col_gridSaleInvoices_sale_length";
            this.col_gridSaleInvoices_sale_length.ReadOnly = true;
            this.col_gridSaleInvoices_sale_length.Width = 30;
            // 
            // col_gridSaleInvoices_SaleAmount
            // 
            this.col_gridSaleInvoices_SaleAmount.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle53.Format = "N0";
            this.col_gridSaleInvoices_SaleAmount.DefaultCellStyle = dataGridViewCellStyle53;
            this.col_gridSaleInvoices_SaleAmount.HeaderText = "Amount";
            this.col_gridSaleInvoices_SaleAmount.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridSaleInvoices_SaleAmount.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.MinimumWidth = 50;
            this.col_gridSaleInvoices_SaleAmount.Name = "col_gridSaleInvoices_SaleAmount";
            this.col_gridSaleInvoices_SaleAmount.ReadOnly = true;
            this.col_gridSaleInvoices_SaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridSaleInvoices_SaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridSaleInvoices_SaleAmount.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.Width = 50;
            // 
            // col_gridSaleInvoices_shippingcost
            // 
            this.col_gridSaleInvoices_shippingcost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle54.Format = "N0";
            this.col_gridSaleInvoices_shippingcost.DefaultCellStyle = dataGridViewCellStyle54;
            this.col_gridSaleInvoices_shippingcost.HeaderText = "Shipping";
            this.col_gridSaleInvoices_shippingcost.MinimumWidth = 50;
            this.col_gridSaleInvoices_shippingcost.Name = "col_gridSaleInvoices_shippingcost";
            this.col_gridSaleInvoices_shippingcost.ReadOnly = true;
            this.col_gridSaleInvoices_shippingcost.Width = 50;
            // 
            // col_gridSaleInvoices_ReceivableAmount
            // 
            this.col_gridSaleInvoices_ReceivableAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle55.Format = "N0";
            this.col_gridSaleInvoices_ReceivableAmount.DefaultCellStyle = dataGridViewCellStyle55;
            this.col_gridSaleInvoices_ReceivableAmount.HeaderText = "Hutang";
            this.col_gridSaleInvoices_ReceivableAmount.MinimumWidth = 50;
            this.col_gridSaleInvoices_ReceivableAmount.Name = "col_gridSaleInvoices_ReceivableAmount";
            this.col_gridSaleInvoices_ReceivableAmount.ReadOnly = true;
            this.col_gridSaleInvoices_ReceivableAmount.Width = 50;
            // 
            // col_gridSaleInvoices_returnedamount
            // 
            this.col_gridSaleInvoices_returnedamount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle56.Format = "N0";
            this.col_gridSaleInvoices_returnedamount.DefaultCellStyle = dataGridViewCellStyle56;
            this.col_gridSaleInvoices_returnedamount.HeaderText = "Return";
            this.col_gridSaleInvoices_returnedamount.MinimumWidth = 50;
            this.col_gridSaleInvoices_returnedamount.Name = "col_gridSaleInvoices_returnedamount";
            this.col_gridSaleInvoices_returnedamount.ReadOnly = true;
            // 
            // col_gridSaleInvoices_Sales_id
            // 
            this.col_gridSaleInvoices_Sales_id.HeaderText = "id";
            this.col_gridSaleInvoices_Sales_id.Name = "col_gridSaleInvoices_Sales_id";
            this.col_gridSaleInvoices_Sales_id.ReadOnly = true;
            this.col_gridSaleInvoices_Sales_id.Visible = false;
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = false;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(30, 97);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(212, 41);
            this.iddl_Customers.TabIndex = 2;
            // 
            // btnAddReturns
            // 
            this.btnAddReturns.Location = new System.Drawing.Point(1, 1);
            this.btnAddReturns.Name = "btnAddReturns";
            this.btnAddReturns.Size = new System.Drawing.Size(40, 23);
            this.btnAddReturns.TabIndex = 129;
            this.btnAddReturns.Text = "ADD";
            this.btnAddReturns.UseVisualStyleBackColor = true;
            this.btnAddReturns.Click += new System.EventHandler(this.BtnAddReturns_Click);
            // 
            // gridReturns
            // 
            this.gridReturns.AllowUserToAddRows = false;
            this.gridReturns.AllowUserToDeleteRows = false;
            this.gridReturns.AllowUserToResizeRows = false;
            this.gridReturns.BackgroundColor = System.Drawing.Color.White;
            this.gridReturns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridReturns.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReturns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.gridReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReturns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridReturns_removeFakturPajaks_Id,
            this.col_gridReturns_Timestamp,
            this.col_gridReturns_hexbarcode,
            this.col_gridReturns_customer_name,
            this.col_gridReturns_sale_qty,
            this.col_gridReturns_sale_length,
            this.col_gridReturns_sale_amount,
            this.col_gridReturns_id});
            this.gridReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReturns.Location = new System.Drawing.Point(0, 25);
            this.gridReturns.Margin = new System.Windows.Forms.Padding(2);
            this.gridReturns.MultiSelect = false;
            this.gridReturns.Name = "gridReturns";
            this.gridReturns.ReadOnly = true;
            this.gridReturns.RowHeadersVisible = false;
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridReturns.RowsDefaultCellStyle = dataGridViewCellStyle65;
            this.gridReturns.RowTemplate.Height = 24;
            this.gridReturns.Size = new System.Drawing.Size(876, 96);
            this.gridReturns.TabIndex = 108;
            this.gridReturns.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridReturns_CellContentClick);
            // 
            // col_gridReturns_removeFakturPajaks_Id
            // 
            this.col_gridReturns_removeFakturPajaks_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_gridReturns_removeFakturPajaks_Id.DefaultCellStyle = dataGridViewCellStyle59;
            this.col_gridReturns_removeFakturPajaks_Id.HeaderText = "";
            this.col_gridReturns_removeFakturPajaks_Id.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridReturns_removeFakturPajaks_Id.LinkColor = System.Drawing.Color.Red;
            this.col_gridReturns_removeFakturPajaks_Id.MinimumWidth = 10;
            this.col_gridReturns_removeFakturPajaks_Id.Name = "col_gridReturns_removeFakturPajaks_Id";
            this.col_gridReturns_removeFakturPajaks_Id.ReadOnly = true;
            this.col_gridReturns_removeFakturPajaks_Id.Text = "X";
            this.col_gridReturns_removeFakturPajaks_Id.UseColumnTextForLinkValue = true;
            this.col_gridReturns_removeFakturPajaks_Id.VisitedLinkColor = System.Drawing.Color.Red;
            this.col_gridReturns_removeFakturPajaks_Id.Width = 10;
            // 
            // col_gridReturns_Timestamp
            // 
            this.col_gridReturns_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle60.Format = "dd/MM/yy";
            this.col_gridReturns_Timestamp.DefaultCellStyle = dataGridViewCellStyle60;
            this.col_gridReturns_Timestamp.HeaderText = "Date";
            this.col_gridReturns_Timestamp.MinimumWidth = 30;
            this.col_gridReturns_Timestamp.Name = "col_gridReturns_Timestamp";
            this.col_gridReturns_Timestamp.ReadOnly = true;
            this.col_gridReturns_Timestamp.Width = 30;
            // 
            // col_gridReturns_hexbarcode
            // 
            this.col_gridReturns_hexbarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridReturns_hexbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_gridReturns_hexbarcode.DefaultCellStyle = dataGridViewCellStyle61;
            this.col_gridReturns_hexbarcode.HeaderText = "No";
            this.col_gridReturns_hexbarcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridReturns_hexbarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridReturns_hexbarcode.MinimumWidth = 30;
            this.col_gridReturns_hexbarcode.Name = "col_gridReturns_hexbarcode";
            this.col_gridReturns_hexbarcode.ReadOnly = true;
            this.col_gridReturns_hexbarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridReturns_hexbarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridReturns_hexbarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridReturns_hexbarcode.Width = 30;
            // 
            // col_gridReturns_customer_name
            // 
            this.col_gridReturns_customer_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridReturns_customer_name.HeaderText = "Customer";
            this.col_gridReturns_customer_name.MinimumWidth = 50;
            this.col_gridReturns_customer_name.Name = "col_gridReturns_customer_name";
            this.col_gridReturns_customer_name.ReadOnly = true;
            this.col_gridReturns_customer_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridReturns_customer_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_gridReturns_sale_qty
            // 
            this.col_gridReturns_sale_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridReturns_sale_qty.DefaultCellStyle = dataGridViewCellStyle62;
            this.col_gridReturns_sale_qty.HeaderText = "Pcs";
            this.col_gridReturns_sale_qty.MinimumWidth = 30;
            this.col_gridReturns_sale_qty.Name = "col_gridReturns_sale_qty";
            this.col_gridReturns_sale_qty.ReadOnly = true;
            this.col_gridReturns_sale_qty.Width = 30;
            // 
            // col_gridReturns_sale_length
            // 
            this.col_gridReturns_sale_length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridReturns_sale_length.DefaultCellStyle = dataGridViewCellStyle63;
            this.col_gridReturns_sale_length.HeaderText = "Qty";
            this.col_gridReturns_sale_length.MinimumWidth = 30;
            this.col_gridReturns_sale_length.Name = "col_gridReturns_sale_length";
            this.col_gridReturns_sale_length.ReadOnly = true;
            this.col_gridReturns_sale_length.Width = 30;
            // 
            // col_gridReturns_sale_amount
            // 
            this.col_gridReturns_sale_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle64.Format = "N2";
            dataGridViewCellStyle64.NullValue = null;
            this.col_gridReturns_sale_amount.DefaultCellStyle = dataGridViewCellStyle64;
            this.col_gridReturns_sale_amount.HeaderText = "Amount";
            this.col_gridReturns_sale_amount.MinimumWidth = 50;
            this.col_gridReturns_sale_amount.Name = "col_gridReturns_sale_amount";
            this.col_gridReturns_sale_amount.ReadOnly = true;
            this.col_gridReturns_sale_amount.Width = 50;
            // 
            // col_gridReturns_id
            // 
            this.col_gridReturns_id.HeaderText = "id";
            this.col_gridReturns_id.Name = "col_gridReturns_id";
            this.col_gridReturns_id.ReadOnly = true;
            this.col_gridReturns_id.Visible = false;
            // 
            // lblRowInfoHeader
            // 
            this.lblRowInfoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRowInfoHeader.Location = new System.Drawing.Point(0, 0);
            this.lblRowInfoHeader.Name = "lblRowInfoHeader";
            this.lblRowInfoHeader.Size = new System.Drawing.Size(862, 19);
            this.lblRowInfoHeader.TabIndex = 107;
            this.lblRowInfoHeader.Text = "Faktur Pajak: None";
            this.lblRowInfoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkShowCompleted
            // 
            this.chkShowCompleted.AutoSize = true;
            this.chkShowCompleted.Location = new System.Drawing.Point(199, 7);
            this.chkShowCompleted.Name = "chkShowCompleted";
            this.chkShowCompleted.Size = new System.Drawing.Size(88, 17);
            this.chkShowCompleted.TabIndex = 14;
            this.chkShowCompleted.Text = "Show locked";
            this.chkShowCompleted.UseVisualStyleBackColor = true;
            this.chkShowCompleted.CheckedChanged += new System.EventHandler(this.ChkShowCompleted_CheckedChanged);
            // 
            // idtp_StartDate
            // 
            this.idtp_StartDate.Checked = false;
            this.idtp_StartDate.CustomFormat = "dd/MM/yy";
            this.idtp_StartDate.DefaultCheckedValue = false;
            this.idtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_StartDate.LabelText = "Start Date";
            this.idtp_StartDate.Location = new System.Drawing.Point(3, 6);
            this.idtp_StartDate.Name = "idtp_StartDate";
            this.idtp_StartDate.ShowCheckBox = true;
            this.idtp_StartDate.ShowDateTimePickerOnly = false;
            this.idtp_StartDate.ShowUpAndDown = false;
            this.idtp_StartDate.Size = new System.Drawing.Size(105, 39);
            this.idtp_StartDate.TabIndex = 5;
            this.idtp_StartDate.Value = null;
            this.idtp_StartDate.ValueTimeSpan = null;
            // 
            // idtp_EndDate
            // 
            this.idtp_EndDate.Checked = false;
            this.idtp_EndDate.CustomFormat = "dd/MM/yy";
            this.idtp_EndDate.DefaultCheckedValue = false;
            this.idtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_EndDate.LabelText = "End Date";
            this.idtp_EndDate.Location = new System.Drawing.Point(114, 6);
            this.idtp_EndDate.Name = "idtp_EndDate";
            this.idtp_EndDate.ShowCheckBox = true;
            this.idtp_EndDate.ShowDateTimePickerOnly = false;
            this.idtp_EndDate.ShowUpAndDown = false;
            this.idtp_EndDate.Size = new System.Drawing.Size(105, 39);
            this.idtp_EndDate.TabIndex = 17;
            this.idtp_EndDate.Value = null;
            this.idtp_EndDate.ValueTimeSpan = null;
            // 
            // tcRowInfo
            // 
            this.tcRowInfo.Controls.Add(this.tpVendorInvoices);
            this.tcRowInfo.Controls.Add(this.tpSaleInvoices);
            this.tcRowInfo.Controls.Add(this.tpSaleReturns);
            this.tcRowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRowInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tcRowInfo.Location = new System.Drawing.Point(0, 0);
            this.tcRowInfo.Name = "tcRowInfo";
            this.tcRowInfo.SelectedIndex = 0;
            this.tcRowInfo.Size = new System.Drawing.Size(884, 147);
            this.tcRowInfo.TabIndex = 7;
            // 
            // tpSaleInvoices
            // 
            this.tpSaleInvoices.Controls.Add(this.gridSaleInvoices);
            this.tpSaleInvoices.Controls.Add(this.panel4);
            this.tpSaleInvoices.Location = new System.Drawing.Point(4, 22);
            this.tpSaleInvoices.Name = "tpSaleInvoices";
            this.tpSaleInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaleInvoices.Size = new System.Drawing.Size(876, 121);
            this.tpSaleInvoices.TabIndex = 0;
            this.tpSaleInvoices.Text = "Sale Invoices";
            this.tpSaleInvoices.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddSales);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(870, 25);
            this.panel4.TabIndex = 132;
            // 
            // tpVendorInvoices
            // 
            this.tpVendorInvoices.Controls.Add(this.gridVendorInvoices);
            this.tpVendorInvoices.Controls.Add(this.panel3);
            this.tpVendorInvoices.Location = new System.Drawing.Point(4, 22);
            this.tpVendorInvoices.Name = "tpVendorInvoices";
            this.tpVendorInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tpVendorInvoices.Size = new System.Drawing.Size(876, 121);
            this.tpVendorInvoices.TabIndex = 1;
            this.tpVendorInvoices.Text = "Vendor Invoices";
            this.tpVendorInvoices.UseVisualStyleBackColor = true;
            // 
            // gridVendorInvoices
            // 
            this.gridVendorInvoices.AllowUserToAddRows = false;
            this.gridVendorInvoices.AllowUserToDeleteRows = false;
            this.gridVendorInvoices.AllowUserToResizeRows = false;
            this.gridVendorInvoices.BackgroundColor = System.Drawing.Color.White;
            this.gridVendorInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle66.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle66.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle66.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle66.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVendorInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle66;
            this.gridVendorInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendorInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridvendorinvoice_id,
            this.col_gridVendorInvoices_removeFakturPajaks_Id,
            this.col_gridvendorinvoice_statusenumid,
            this.col_gridvendorinvoice_statusname,
            this.col_gridvendorinvoice_timestamp,
            this.col_gridvendorinvoice_invoiceno,
            this.col_gridvendorinvoice_vendorname,
            this.col_gridvendorinvoice_Amount,
            this.col_gridvendorinvoice_notes});
            this.gridVendorInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVendorInvoices.Location = new System.Drawing.Point(3, 28);
            this.gridVendorInvoices.Name = "gridVendorInvoices";
            this.gridVendorInvoices.RowHeadersVisible = false;
            this.gridVendorInvoices.Size = new System.Drawing.Size(870, 90);
            this.gridVendorInvoices.TabIndex = 129;
            this.gridVendorInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVendorInvoices_CellContentClick);
            // 
            // col_gridvendorinvoice_id
            // 
            this.col_gridvendorinvoice_id.DataPropertyName = "id";
            this.col_gridvendorinvoice_id.HeaderText = "id";
            this.col_gridvendorinvoice_id.Name = "col_gridvendorinvoice_id";
            this.col_gridvendorinvoice_id.ReadOnly = true;
            this.col_gridvendorinvoice_id.Visible = false;
            // 
            // col_gridVendorInvoices_removeFakturPajaks_Id
            // 
            this.col_gridVendorInvoices_removeFakturPajaks_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.Color.Red;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.DefaultCellStyle = dataGridViewCellStyle67;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.HeaderText = "";
            this.col_gridVendorInvoices_removeFakturPajaks_Id.LinkColor = System.Drawing.Color.Red;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.MinimumWidth = 10;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.Name = "col_gridVendorInvoices_removeFakturPajaks_Id";
            this.col_gridVendorInvoices_removeFakturPajaks_Id.ReadOnly = true;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.Text = "X";
            this.col_gridVendorInvoices_removeFakturPajaks_Id.UseColumnTextForLinkValue = true;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.VisitedLinkColor = System.Drawing.Color.Red;
            this.col_gridVendorInvoices_removeFakturPajaks_Id.Width = 10;
            // 
            // col_gridvendorinvoice_statusenumid
            // 
            this.col_gridvendorinvoice_statusenumid.HeaderText = "Status Enum ID";
            this.col_gridvendorinvoice_statusenumid.Name = "col_gridvendorinvoice_statusenumid";
            this.col_gridvendorinvoice_statusenumid.ReadOnly = true;
            this.col_gridvendorinvoice_statusenumid.Visible = false;
            // 
            // col_gridvendorinvoice_statusname
            // 
            this.col_gridvendorinvoice_statusname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridvendorinvoice_statusname.HeaderText = "Status";
            this.col_gridvendorinvoice_statusname.MinimumWidth = 40;
            this.col_gridvendorinvoice_statusname.Name = "col_gridvendorinvoice_statusname";
            this.col_gridvendorinvoice_statusname.ReadOnly = true;
            this.col_gridvendorinvoice_statusname.Width = 40;
            // 
            // col_gridvendorinvoice_timestamp
            // 
            this.col_gridvendorinvoice_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle68.Format = "dd/MM/yy";
            this.col_gridvendorinvoice_timestamp.DefaultCellStyle = dataGridViewCellStyle68;
            this.col_gridvendorinvoice_timestamp.HeaderText = "Date";
            this.col_gridvendorinvoice_timestamp.MinimumWidth = 40;
            this.col_gridvendorinvoice_timestamp.Name = "col_gridvendorinvoice_timestamp";
            this.col_gridvendorinvoice_timestamp.ReadOnly = true;
            this.col_gridvendorinvoice_timestamp.Width = 40;
            // 
            // col_gridvendorinvoice_invoiceno
            // 
            this.col_gridvendorinvoice_invoiceno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridvendorinvoice_invoiceno.HeaderText = "Invoice";
            this.col_gridvendorinvoice_invoiceno.MinimumWidth = 50;
            this.col_gridvendorinvoice_invoiceno.Name = "col_gridvendorinvoice_invoiceno";
            this.col_gridvendorinvoice_invoiceno.ReadOnly = true;
            this.col_gridvendorinvoice_invoiceno.Width = 50;
            // 
            // col_gridvendorinvoice_vendorname
            // 
            this.col_gridvendorinvoice_vendorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridvendorinvoice_vendorname.HeaderText = "Vendor";
            this.col_gridvendorinvoice_vendorname.MinimumWidth = 45;
            this.col_gridvendorinvoice_vendorname.Name = "col_gridvendorinvoice_vendorname";
            this.col_gridvendorinvoice_vendorname.ReadOnly = true;
            this.col_gridvendorinvoice_vendorname.Width = 45;
            // 
            // col_gridvendorinvoice_Amount
            // 
            this.col_gridvendorinvoice_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle69.Format = "N0";
            this.col_gridvendorinvoice_Amount.DefaultCellStyle = dataGridViewCellStyle69;
            this.col_gridvendorinvoice_Amount.HeaderText = "Amount";
            this.col_gridvendorinvoice_Amount.MinimumWidth = 40;
            this.col_gridvendorinvoice_Amount.Name = "col_gridvendorinvoice_Amount";
            this.col_gridvendorinvoice_Amount.ReadOnly = true;
            this.col_gridvendorinvoice_Amount.Width = 40;
            // 
            // col_gridvendorinvoice_notes
            // 
            this.col_gridvendorinvoice_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridvendorinvoice_notes.HeaderText = "Notes";
            this.col_gridvendorinvoice_notes.MinimumWidth = 30;
            this.col_gridvendorinvoice_notes.Name = "col_gridvendorinvoice_notes";
            this.col_gridvendorinvoice_notes.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddVendorInvoices);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 25);
            this.panel3.TabIndex = 131;
            // 
            // btnAddVendorInvoices
            // 
            this.btnAddVendorInvoices.Location = new System.Drawing.Point(1, 1);
            this.btnAddVendorInvoices.Name = "btnAddVendorInvoices";
            this.btnAddVendorInvoices.Size = new System.Drawing.Size(40, 23);
            this.btnAddVendorInvoices.TabIndex = 128;
            this.btnAddVendorInvoices.Text = "ADD";
            this.btnAddVendorInvoices.UseVisualStyleBackColor = true;
            this.btnAddVendorInvoices.Click += new System.EventHandler(this.BtnAddVendorInvoices_Click);
            // 
            // tpSaleReturns
            // 
            this.tpSaleReturns.Controls.Add(this.gridReturns);
            this.tpSaleReturns.Controls.Add(this.panel2);
            this.tpSaleReturns.Location = new System.Drawing.Point(4, 22);
            this.tpSaleReturns.Name = "tpSaleReturns";
            this.tpSaleReturns.Size = new System.Drawing.Size(876, 121);
            this.tpSaleReturns.TabIndex = 2;
            this.tpSaleReturns.Text = "Sale Returns";
            this.tpSaleReturns.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddReturns);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 25);
            this.panel2.TabIndex = 130;
            // 
            // iddl_Vendors
            // 
            this.iddl_Vendors.DisableTextInput = false;
            this.iddl_Vendors.HideFilter = false;
            this.iddl_Vendors.HideUpdateLink = false;
            this.iddl_Vendors.LabelText = "Vendor";
            this.iddl_Vendors.Location = new System.Drawing.Point(30, 50);
            this.iddl_Vendors.Name = "iddl_Vendors";
            this.iddl_Vendors.SelectedIndex = -1;
            this.iddl_Vendors.SelectedItem = null;
            this.iddl_Vendors.SelectedItemText = "";
            this.iddl_Vendors.SelectedValue = null;
            this.iddl_Vendors.ShowDropdownlistOnly = false;
            this.iddl_Vendors.Size = new System.Drawing.Size(212, 41);
            this.iddl_Vendors.TabIndex = 3;
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(8, 121);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(14, 13);
            this.rbCustomer.TabIndex = 18;
            this.rbCustomer.TabStop = true;
            this.rbCustomer.UseVisualStyleBackColor = true;
            this.rbCustomer.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbVendor
            // 
            this.rbVendor.AutoSize = true;
            this.rbVendor.Location = new System.Drawing.Point(8, 74);
            this.rbVendor.Name = "rbVendor";
            this.rbVendor.Size = new System.Drawing.Size(14, 13);
            this.rbVendor.TabIndex = 19;
            this.rbVendor.TabStop = true;
            this.rbVendor.UseVisualStyleBackColor = true;
            this.rbVendor.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // MasterData_v1_FakturPajaks_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 531);
            this.Mode = LIBUtil.FormModes.Add;
            this.Name = "MasterData_v1_FakturPajaks_Form";
            this.Text = "FAKTUR PAJAK";
            this.Shown += new System.EventHandler(this.MasterData_v1_FakturPajaks_Form_Shown);
            this.panel1.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputLeft.Panel1.ResumeLayout(false);
            this.scInputLeft.Panel1.PerformLayout();
            this.scInputLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            this.scInputRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).EndInit();
            this.scInputRight.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.scInputContainer.Panel1.ResumeLayout(false);
            this.scInputContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).EndInit();
            this.scInputContainer.ResumeLayout(false);
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            this.pnlRowInfo.ResumeLayout(false);
            this.pnlRowInfoHeader.ResumeLayout(false);
            this.pnlRowInfoContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturns)).EndInit();
            this.tcRowInfo.ResumeLayout(false);
            this.tpSaleInvoices.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tpVendorInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoices)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tpSaleReturns.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_DPP;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_Timestamp;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_No;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PPN;
        private System.Windows.Forms.Button btnAddSales;
        private System.Windows.Forms.DataGridView gridSaleInvoices;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridSaleInvoices_removeFakturPajaks_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_timestamp;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridSaleInvoices_hexbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_sale_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_sale_length;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridSaleInvoices_SaleAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_shippingcost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_ReceivableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_returnedamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_Sales_id;
        private System.Windows.Forms.Button btnAddReturns;
        private System.Windows.Forms.DataGridView gridReturns;
        private System.Windows.Forms.Label lblRowInfoHeader;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridReturns_removeFakturPajaks_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_Timestamp;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridReturns_hexbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_sale_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_sale_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_sale_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridReturns_id;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_StartDate;
        private System.Windows.Forms.CheckBox chkShowCompleted;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_EndDate;
        private System.Windows.Forms.TabControl tcRowInfo;
        private System.Windows.Forms.TabPage tpSaleInvoices;
        private System.Windows.Forms.TabPage tpVendorInvoices;
        private System.Windows.Forms.TabPage tpSaleReturns;
        private System.Windows.Forms.Button btnAddVendorInvoices;
        private System.Windows.Forms.DataGridView gridVendorInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_id;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridVendorInvoices_removeFakturPajaks_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_statusenumid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_statusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_invoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_notes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Vendors;
        private System.Windows.Forms.RadioButton rbCustomer;
        private System.Windows.Forms.RadioButton rbVendor;
    }
}