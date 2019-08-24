﻿namespace BinaMitraTextile.POs
{
    partial class Add_Edit_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridPOItems = new System.Windows.Forms.DataGridView();
            this.col_gridPOItems_deleteRow = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridPOItems_findInventory = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridPOItems_productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_widthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_gradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_colorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_unitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_pricePerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_referencedInventoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.dtpTarget = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.rbVendor = new System.Windows.Forms.RadioButton();
            this.rbCustomer = new System.Windows.Forms.RadioButton();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_Vendor = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPOItems
            // 
            this.gridPOItems.AllowUserToResizeRows = false;
            this.gridPOItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPOItems.BackgroundColor = System.Drawing.Color.White;
            this.gridPOItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPOItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.gridPOItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPOItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridPOItems_deleteRow,
            this.col_gridPOItems_findInventory,
            this.col_gridPOItems_productName,
            this.col_gridPOItems_widthName,
            this.col_gridPOItems_gradeName,
            this.col_gridPOItems_colorName,
            this.col_gridPOItems_qty,
            this.col_gridPOItems_unitName,
            this.col_gridPOItems_pricePerUnit,
            this.col_gridPOItems_subtotal,
            this.col_gridPOItems_notes,
            this.col_gridPOItems_referencedInventoryID});
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPOItems.DefaultCellStyle = dataGridViewCellStyle40;
            this.gridPOItems.Location = new System.Drawing.Point(14, 102);
            this.gridPOItems.Margin = new System.Windows.Forms.Padding(2);
            this.gridPOItems.MultiSelect = false;
            this.gridPOItems.Name = "gridPOItems";
            this.gridPOItems.RowHeadersVisible = false;
            this.gridPOItems.RowTemplate.Height = 24;
            this.gridPOItems.Size = new System.Drawing.Size(949, 303);
            this.gridPOItems.TabIndex = 100;
            this.gridPOItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPOItems_CellContentClick);
            this.gridPOItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPOItems_CellEndEdit);
            // 
            // col_gridPOItems_deleteRow
            // 
            this.col_gridPOItems_deleteRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridPOItems_deleteRow.HeaderText = "";
            this.col_gridPOItems_deleteRow.MinimumWidth = 10;
            this.col_gridPOItems_deleteRow.Name = "col_gridPOItems_deleteRow";
            this.col_gridPOItems_deleteRow.Text = "X";
            this.col_gridPOItems_deleteRow.UseColumnTextForLinkValue = true;
            this.col_gridPOItems_deleteRow.Width = 20;
            // 
            // col_gridPOItems_findInventory
            // 
            this.col_gridPOItems_findInventory.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_gridPOItems_findInventory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_findInventory.DefaultCellStyle = dataGridViewCellStyle32;
            this.col_gridPOItems_findInventory.HeaderText = "";
            this.col_gridPOItems_findInventory.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_gridPOItems_findInventory.MinimumWidth = 20;
            this.col_gridPOItems_findInventory.Name = "col_gridPOItems_findInventory";
            this.col_gridPOItems_findInventory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridPOItems_findInventory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridPOItems_findInventory.Text = "Find";
            this.col_gridPOItems_findInventory.UseColumnTextForLinkValue = true;
            this.col_gridPOItems_findInventory.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_gridPOItems_findInventory.Width = 20;
            // 
            // col_gridPOItems_productName
            // 
            this.col_gridPOItems_productName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridPOItems_productName.HeaderText = "Product";
            this.col_gridPOItems_productName.MaxInputLength = 50;
            this.col_gridPOItems_productName.Name = "col_gridPOItems_productName";
            // 
            // col_gridPOItems_widthName
            // 
            this.col_gridPOItems_widthName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_widthName.DefaultCellStyle = dataGridViewCellStyle33;
            this.col_gridPOItems_widthName.HeaderText = "Lebar";
            this.col_gridPOItems_widthName.MaxInputLength = 5;
            this.col_gridPOItems_widthName.MinimumWidth = 50;
            this.col_gridPOItems_widthName.Name = "col_gridPOItems_widthName";
            this.col_gridPOItems_widthName.Width = 50;
            // 
            // col_gridPOItems_gradeName
            // 
            this.col_gridPOItems_gradeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_gradeName.DefaultCellStyle = dataGridViewCellStyle34;
            this.col_gridPOItems_gradeName.HeaderText = "Grade";
            this.col_gridPOItems_gradeName.MaxInputLength = 10;
            this.col_gridPOItems_gradeName.MinimumWidth = 50;
            this.col_gridPOItems_gradeName.Name = "col_gridPOItems_gradeName";
            this.col_gridPOItems_gradeName.Width = 50;
            // 
            // col_gridPOItems_colorName
            // 
            this.col_gridPOItems_colorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_colorName.DefaultCellStyle = dataGridViewCellStyle35;
            this.col_gridPOItems_colorName.HeaderText = "Warna";
            this.col_gridPOItems_colorName.MaxInputLength = 20;
            this.col_gridPOItems_colorName.MinimumWidth = 50;
            this.col_gridPOItems_colorName.Name = "col_gridPOItems_colorName";
            this.col_gridPOItems_colorName.Width = 50;
            // 
            // col_gridPOItems_qty
            // 
            this.col_gridPOItems_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black;
            this.col_gridPOItems_qty.DefaultCellStyle = dataGridViewCellStyle36;
            this.col_gridPOItems_qty.HeaderText = "Qty";
            this.col_gridPOItems_qty.MaxInputLength = 9;
            this.col_gridPOItems_qty.MinimumWidth = 50;
            this.col_gridPOItems_qty.Name = "col_gridPOItems_qty";
            this.col_gridPOItems_qty.Width = 50;
            // 
            // col_gridPOItems_unitName
            // 
            this.col_gridPOItems_unitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_unitName.DefaultCellStyle = dataGridViewCellStyle37;
            this.col_gridPOItems_unitName.HeaderText = "Unit";
            this.col_gridPOItems_unitName.MaxInputLength = 10;
            this.col_gridPOItems_unitName.MinimumWidth = 50;
            this.col_gridPOItems_unitName.Name = "col_gridPOItems_unitName";
            this.col_gridPOItems_unitName.Width = 50;
            // 
            // col_gridPOItems_pricePerUnit
            // 
            this.col_gridPOItems_pricePerUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle38.Format = "N2";
            this.col_gridPOItems_pricePerUnit.DefaultCellStyle = dataGridViewCellStyle38;
            this.col_gridPOItems_pricePerUnit.HeaderText = "Price/Unit";
            this.col_gridPOItems_pricePerUnit.MaxInputLength = 10;
            this.col_gridPOItems_pricePerUnit.MinimumWidth = 70;
            this.col_gridPOItems_pricePerUnit.Name = "col_gridPOItems_pricePerUnit";
            this.col_gridPOItems_pricePerUnit.Width = 70;
            // 
            // col_gridPOItems_subtotal
            // 
            this.col_gridPOItems_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle39.Format = "N2";
            dataGridViewCellStyle39.NullValue = null;
            this.col_gridPOItems_subtotal.DefaultCellStyle = dataGridViewCellStyle39;
            this.col_gridPOItems_subtotal.HeaderText = "Subtotal";
            this.col_gridPOItems_subtotal.MinimumWidth = 70;
            this.col_gridPOItems_subtotal.Name = "col_gridPOItems_subtotal";
            this.col_gridPOItems_subtotal.ReadOnly = true;
            this.col_gridPOItems_subtotal.Width = 70;
            // 
            // col_gridPOItems_notes
            // 
            this.col_gridPOItems_notes.HeaderText = "Notes";
            this.col_gridPOItems_notes.MaxInputLength = 100;
            this.col_gridPOItems_notes.MinimumWidth = 50;
            this.col_gridPOItems_notes.Name = "col_gridPOItems_notes";
            this.col_gridPOItems_notes.Width = 300;
            // 
            // col_gridPOItems_referencedInventoryID
            // 
            this.col_gridPOItems_referencedInventoryID.HeaderText = "Ref. Inventory ID";
            this.col_gridPOItems_referencedInventoryID.Name = "col_gridPOItems_referencedInventoryID";
            this.col_gridPOItems_referencedInventoryID.ReadOnly = true;
            this.col_gridPOItems_referencedInventoryID.Visible = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(700, 407);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(263, 32);
            this.lblTotalAmount.TabIndex = 116;
            this.lblTotalAmount.Text = "GrandTotal";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(443, 6);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(220, 84);
            this.lblInfo.TabIndex = 121;
            this.lblInfo.Text = "lblInfo";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(727, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 57);
            this.label8.TabIndex = 131;
            this.label8.Text = "Jl. Mayor Sunarya Blok K No. 11A\r\nBandung, Jawa Barat\r\nsimpati/whatsapp: 081.2240" +
    ".44338\r\npin bb: 74E4F9D9, bina.mitra.textile@gmail.com";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(741, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 130;
            this.label2.Text = "CV. BINA MITRA TEXTILE";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 407);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNotes.Location = new System.Drawing.Point(50, 407);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(315, 72);
            this.txtNotes.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(875, 451);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 28);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 135;
            this.label3.Text = "PO No";
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(55, 7);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(100, 20);
            this.txtPONo.TabIndex = 0;
            // 
            // dtpTarget
            // 
            this.dtpTarget.CustomFormat = "dddd, dd/MM/yy";
            this.dtpTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarget.Location = new System.Drawing.Point(55, 32);
            this.dtpTarget.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTarget.Name = "dtpTarget";
            this.dtpTarget.Size = new System.Drawing.Size(155, 20);
            this.dtpTarget.TabIndex = 1;
            this.dtpTarget.Value = new System.DateTime(2014, 11, 15, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Due";
            // 
            // rbVendor
            // 
            this.rbVendor.AutoSize = true;
            this.rbVendor.Checked = true;
            this.rbVendor.Location = new System.Drawing.Point(225, 9);
            this.rbVendor.Name = "rbVendor";
            this.rbVendor.Size = new System.Drawing.Size(14, 13);
            this.rbVendor.TabIndex = 143;
            this.rbVendor.TabStop = true;
            this.rbVendor.UseVisualStyleBackColor = true;
            this.rbVendor.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbCustomer
            // 
            this.rbCustomer.AutoSize = true;
            this.rbCustomer.Location = new System.Drawing.Point(225, 52);
            this.rbCustomer.Name = "rbCustomer";
            this.rbCustomer.Size = new System.Drawing.Size(14, 13);
            this.rbCustomer.TabIndex = 147;
            this.rbCustomer.UseVisualStyleBackColor = true;
            this.rbCustomer.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.Enabled = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = false;
            this.iddl_Customers.LabelText = "Customers";
            this.iddl_Customers.Location = new System.Drawing.Point(242, 49);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(180, 41);
            this.iddl_Customers.TabIndex = 148;
            this.iddl_Customers.SelectedIndexChanged += new System.EventHandler(this.iddl_SelectedIndexChanged);
            this.iddl_Customers.UpdateLink_Click += new System.EventHandler(this.iddl_Customers_UpdateLink_Click);
            // 
            // iddl_Vendor
            // 
            this.iddl_Vendor.DisableTextInput = false;
            this.iddl_Vendor.HideFilter = false;
            this.iddl_Vendor.HideUpdateLink = false;
            this.iddl_Vendor.LabelText = "Vendor";
            this.iddl_Vendor.Location = new System.Drawing.Point(242, 6);
            this.iddl_Vendor.Name = "iddl_Vendor";
            this.iddl_Vendor.SelectedIndex = -1;
            this.iddl_Vendor.SelectedItem = null;
            this.iddl_Vendor.SelectedItemText = "";
            this.iddl_Vendor.SelectedValue = null;
            this.iddl_Vendor.ShowDropdownlistOnly = false;
            this.iddl_Vendor.Size = new System.Drawing.Size(180, 41);
            this.iddl_Vendor.TabIndex = 149;
            this.iddl_Vendor.SelectedIndexChanged += new System.EventHandler(this.iddl_SelectedIndexChanged);
            this.iddl_Vendor.UpdateLink_Click += new System.EventHandler(this.Iddl_Vendor_UpdateLink_Click);
            // 
            // Add_Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 488);
            this.Controls.Add(this.iddl_Vendor);
            this.Controls.Add(this.iddl_Customers);
            this.Controls.Add(this.rbCustomer);
            this.Controls.Add(this.rbVendor);
            this.Controls.Add(this.dtpTarget);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.gridPOItems);
            this.Name = "Add_Edit_Form";
            this.Text = "New PO";
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPOItems;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.DateTimePicker dtpTarget;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridPOItems_deleteRow;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridPOItems_findInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_widthName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_gradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_colorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_unitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_pricePerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_referencedInventoryID;
        private System.Windows.Forms.RadioButton rbVendor;
        private System.Windows.Forms.RadioButton rbCustomer;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Vendor;
    }
}