﻿namespace BinaMitraTextile.Admin
{
    partial class ProductPrices_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProductStoreNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProductWidths = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbLengthUnits = new System.Windows.Forms.ComboBox();
            this.txtTagPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_IsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_productStoreName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_grid_inventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length_unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_colorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGrades = new System.Windows.Forms.ComboBox();
            this.gbNonSelectionPanel = new System.Windows.Forms.GroupBox();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInventoryCode = new System.Windows.Forms.TextBox();
            this.chkUseInventoryID = new System.Windows.Forms.CheckBox();
            this.gbSelectionPanel = new System.Windows.Forms.GroupBox();
            this.in_Price = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnCancelSelections = new System.Windows.Forms.Button();
            this.btnUpdateSelected = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.itxt_QuickSearch = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOnlyNotOK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.gbNonSelectionPanel.SuspendLayout();
            this.gbSelectionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(387, 144);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 19);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Product Store Name";
            // 
            // cbProductStoreNames
            // 
            this.cbProductStoreNames.FormattingEnabled = true;
            this.cbProductStoreNames.Location = new System.Drawing.Point(162, 45);
            this.cbProductStoreNames.Margin = new System.Windows.Forms.Padding(2);
            this.cbProductStoreNames.Name = "cbProductStoreNames";
            this.cbProductStoreNames.Size = new System.Drawing.Size(138, 21);
            this.cbProductStoreNames.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Width";
            // 
            // cbProductWidths
            // 
            this.cbProductWidths.FormattingEnabled = true;
            this.cbProductWidths.Location = new System.Drawing.Point(162, 95);
            this.cbProductWidths.Margin = new System.Windows.Forms.Padding(2);
            this.cbProductWidths.Name = "cbProductWidths";
            this.cbProductWidths.Size = new System.Drawing.Size(138, 21);
            this.cbProductWidths.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Length Unit";
            // 
            // cbLengthUnits
            // 
            this.cbLengthUnits.FormattingEnabled = true;
            this.cbLengthUnits.Location = new System.Drawing.Point(162, 120);
            this.cbLengthUnits.Margin = new System.Windows.Forms.Padding(2);
            this.cbLengthUnits.Name = "cbLengthUnits";
            this.cbLengthUnits.Size = new System.Drawing.Size(138, 21);
            this.cbLengthUnits.TabIndex = 3;
            // 
            // txtTagPrice
            // 
            this.txtTagPrice.Location = new System.Drawing.Point(356, 19);
            this.txtTagPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtTagPrice.MaxLength = 8;
            this.txtTagPrice.Name = "txtTagPrice";
            this.txtTagPrice.Size = new System.Drawing.Size(137, 20);
            this.txtTagPrice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Price";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_grid_id,
            this.col_grid_IsSelected,
            this.col_grid_productStoreName,
            this.col_grid_inventoryCode,
            this.GradeName,
            this.width_name,
            this.length_unit_name,
            this.col_grid_colorname,
            this.sell_price,
            this.col_grid_Checked});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 248);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(548, 363);
            this.grid.TabIndex = 1;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // col_grid_id
            // 
            this.col_grid_id.DataPropertyName = "id";
            this.col_grid_id.HeaderText = "ID";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            // 
            // col_grid_IsSelected
            // 
            this.col_grid_IsSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_IsSelected.HeaderText = "";
            this.col_grid_IsSelected.Name = "col_grid_IsSelected";
            this.col_grid_IsSelected.ReadOnly = true;
            this.col_grid_IsSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_IsSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_IsSelected.Width = 5;
            // 
            // col_grid_productStoreName
            // 
            this.col_grid_productStoreName.ActiveLinkColor = System.Drawing.Color.Orange;
            this.col_grid_productStoreName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_productStoreName.DataPropertyName = "product_store_name";
            this.col_grid_productStoreName.HeaderText = "Name (Store)";
            this.col_grid_productStoreName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_grid_productStoreName.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_grid_productStoreName.Name = "col_grid_productStoreName";
            this.col_grid_productStoreName.ReadOnly = true;
            this.col_grid_productStoreName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_productStoreName.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            // 
            // col_grid_inventoryCode
            // 
            this.col_grid_inventoryCode.DataPropertyName = "inventory_code";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_inventoryCode.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_grid_inventoryCode.HeaderText = "Code";
            this.col_grid_inventoryCode.Name = "col_grid_inventoryCode";
            this.col_grid_inventoryCode.ReadOnly = true;
            this.col_grid_inventoryCode.Width = 50;
            // 
            // GradeName
            // 
            this.GradeName.DataPropertyName = "grade_name";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GradeName.DefaultCellStyle = dataGridViewCellStyle8;
            this.GradeName.HeaderText = "Grade";
            this.GradeName.Name = "GradeName";
            this.GradeName.ReadOnly = true;
            this.GradeName.Width = 50;
            // 
            // width_name
            // 
            this.width_name.DataPropertyName = "width_name";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.width_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.width_name.HeaderText = "Lebar";
            this.width_name.Name = "width_name";
            this.width_name.ReadOnly = true;
            this.width_name.Width = 50;
            // 
            // length_unit_name
            // 
            this.length_unit_name.DataPropertyName = "length_unit_name";
            this.length_unit_name.HeaderText = "Unit";
            this.length_unit_name.Name = "length_unit_name";
            this.length_unit_name.ReadOnly = true;
            this.length_unit_name.Width = 60;
            // 
            // col_grid_colorname
            // 
            this.col_grid_colorname.HeaderText = "Color";
            this.col_grid_colorname.Name = "col_grid_colorname";
            this.col_grid_colorname.ReadOnly = true;
            // 
            // sell_price
            // 
            this.sell_price.DataPropertyName = "sell_price";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.sell_price.DefaultCellStyle = dataGridViewCellStyle10;
            this.sell_price.HeaderText = "Price";
            this.sell_price.Name = "sell_price";
            this.sell_price.ReadOnly = true;
            // 
            // col_grid_Checked
            // 
            this.col_grid_Checked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_Checked.HeaderText = "OK";
            this.col_grid_Checked.MinimumWidth = 30;
            this.col_grid_Checked.Name = "col_grid_Checked";
            this.col_grid_Checked.ReadOnly = true;
            this.col_grid_Checked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_Checked.Width = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(356, 42);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(138, 50);
            this.txtNotes.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(387, 121);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(71, 19);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(387, 98);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(71, 19);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "ADD NEW";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "Grade";
            // 
            // cbGrades
            // 
            this.cbGrades.FormattingEnabled = true;
            this.cbGrades.Location = new System.Drawing.Point(162, 70);
            this.cbGrades.Margin = new System.Windows.Forms.Padding(2);
            this.cbGrades.Name = "cbGrades";
            this.cbGrades.Size = new System.Drawing.Size(138, 21);
            this.cbGrades.TabIndex = 1;
            // 
            // gbNonSelectionPanel
            // 
            this.gbNonSelectionPanel.Controls.Add(this.cbColors);
            this.gbNonSelectionPanel.Controls.Add(this.label7);
            this.gbNonSelectionPanel.Controls.Add(this.btnDelete);
            this.gbNonSelectionPanel.Controls.Add(this.txtInventoryCode);
            this.gbNonSelectionPanel.Controls.Add(this.btnSubmit);
            this.gbNonSelectionPanel.Controls.Add(this.btnClear);
            this.gbNonSelectionPanel.Controls.Add(this.chkUseInventoryID);
            this.gbNonSelectionPanel.Controls.Add(this.label6);
            this.gbNonSelectionPanel.Controls.Add(this.txtTagPrice);
            this.gbNonSelectionPanel.Controls.Add(this.label4);
            this.gbNonSelectionPanel.Controls.Add(this.cbProductStoreNames);
            this.gbNonSelectionPanel.Controls.Add(this.label3);
            this.gbNonSelectionPanel.Controls.Add(this.cbGrades);
            this.gbNonSelectionPanel.Controls.Add(this.txtNotes);
            this.gbNonSelectionPanel.Controls.Add(this.cbLengthUnits);
            this.gbNonSelectionPanel.Controls.Add(this.label5);
            this.gbNonSelectionPanel.Controls.Add(this.label2);
            this.gbNonSelectionPanel.Controls.Add(this.cbProductWidths);
            this.gbNonSelectionPanel.Controls.Add(this.label1);
            this.gbNonSelectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNonSelectionPanel.Location = new System.Drawing.Point(0, 39);
            this.gbNonSelectionPanel.Name = "gbNonSelectionPanel";
            this.gbNonSelectionPanel.Size = new System.Drawing.Size(548, 177);
            this.gbNonSelectionPanel.TabIndex = 0;
            this.gbNonSelectionPanel.TabStop = false;
            // 
            // cbColors
            // 
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Location = new System.Drawing.Point(162, 145);
            this.cbColors.Margin = new System.Windows.Forms.Padding(2);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(138, 21);
            this.cbColors.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "Color";
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.Location = new System.Drawing.Point(162, 20);
            this.txtInventoryCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtInventoryCode.MaxLength = 8;
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.ReadOnly = true;
            this.txtInventoryCode.Size = new System.Drawing.Size(138, 20);
            this.txtInventoryCode.TabIndex = 88;
            // 
            // chkUseInventoryID
            // 
            this.chkUseInventoryID.AutoSize = true;
            this.chkUseInventoryID.Location = new System.Drawing.Point(38, 23);
            this.chkUseInventoryID.Name = "chkUseInventoryID";
            this.chkUseInventoryID.Size = new System.Drawing.Size(122, 17);
            this.chkUseInventoryID.TabIndex = 87;
            this.chkUseInventoryID.Text = "Only Inventory Code";
            this.chkUseInventoryID.UseVisualStyleBackColor = true;
            this.chkUseInventoryID.CheckedChanged += new System.EventHandler(this.chkUseInventoryID_CheckedChanged);
            // 
            // gbSelectionPanel
            // 
            this.gbSelectionPanel.Controls.Add(this.in_Price);
            this.gbSelectionPanel.Controls.Add(this.btnCancelSelections);
            this.gbSelectionPanel.Controls.Add(this.btnUpdateSelected);
            this.gbSelectionPanel.Controls.Add(this.label8);
            this.gbSelectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSelectionPanel.Location = new System.Drawing.Point(0, 0);
            this.gbSelectionPanel.Name = "gbSelectionPanel";
            this.gbSelectionPanel.Size = new System.Drawing.Size(548, 39);
            this.gbSelectionPanel.TabIndex = 2;
            this.gbSelectionPanel.TabStop = false;
            this.gbSelectionPanel.Visible = false;
            // 
            // in_Price
            // 
            this.in_Price.Checked = false;
            this.in_Price.DecimalPlaces = 2;
            this.in_Price.HideUpDown = true;
            this.in_Price.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_Price.LabelText = "numeric";
            this.in_Price.Location = new System.Drawing.Point(47, 12);
            this.in_Price.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_Price.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Price.Name = "in_Price";
            this.in_Price.ShowCheckbox = false;
            this.in_Price.ShowTextboxOnly = true;
            this.in_Price.Size = new System.Drawing.Size(96, 22);
            this.in_Price.TabIndex = 94;
            this.in_Price.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnCancelSelections
            // 
            this.btnCancelSelections.Location = new System.Drawing.Point(218, 11);
            this.btnCancelSelections.Name = "btnCancelSelections";
            this.btnCancelSelections.Size = new System.Drawing.Size(60, 23);
            this.btnCancelSelections.TabIndex = 93;
            this.btnCancelSelections.Text = "CANCEL";
            this.btnCancelSelections.UseVisualStyleBackColor = true;
            this.btnCancelSelections.Click += new System.EventHandler(this.btnCancelSelections_Click);
            // 
            // btnUpdateSelected
            // 
            this.btnUpdateSelected.Location = new System.Drawing.Point(150, 11);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(62, 23);
            this.btnUpdateSelected.TabIndex = 92;
            this.btnUpdateSelected.Text = "UPDATE";
            this.btnUpdateSelected.UseVisualStyleBackColor = true;
            this.btnUpdateSelected.Click += new System.EventHandler(this.btnUpdateSelected_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 91;
            this.label9.Text = "Search";
            // 
            // itxt_QuickSearch
            // 
            this.itxt_QuickSearch.IsBrowseMode = false;
            this.itxt_QuickSearch.LabelText = "textbox";
            this.itxt_QuickSearch.Location = new System.Drawing.Point(51, 6);
            this.itxt_QuickSearch.MaxLength = 7;
            this.itxt_QuickSearch.MultiLine = false;
            this.itxt_QuickSearch.Name = "itxt_QuickSearch";
            this.itxt_QuickSearch.PasswordChar = '\0';
            this.itxt_QuickSearch.RowCount = 1;
            this.itxt_QuickSearch.ShowDeleteButton = false;
            this.itxt_QuickSearch.ShowTextboxOnly = true;
            this.itxt_QuickSearch.Size = new System.Drawing.Size(51, 21);
            this.itxt_QuickSearch.TabIndex = 0;
            this.itxt_QuickSearch.ValueText = "";
            this.itxt_QuickSearch.onTextChanged += new System.EventHandler(this.itxt_QuickSearch_onTextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOnlyNotOK);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.itxt_QuickSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 32);
            this.panel1.TabIndex = 95;
            // 
            // chkOnlyNotOK
            // 
            this.chkOnlyNotOK.AutoSize = true;
            this.chkOnlyNotOK.Location = new System.Drawing.Point(108, 9);
            this.chkOnlyNotOK.Name = "chkOnlyNotOK";
            this.chkOnlyNotOK.Size = new System.Drawing.Size(81, 17);
            this.chkOnlyNotOK.TabIndex = 96;
            this.chkOnlyNotOK.Text = "only not OK";
            this.chkOnlyNotOK.UseVisualStyleBackColor = true;
            this.chkOnlyNotOK.CheckedChanged += new System.EventHandler(this.chkOnlyNotOK_CheckedChanged);
            // 
            // ProductPrices_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 611);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbNonSelectionPanel);
            this.Controls.Add(this.gbSelectionPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductPrices_Form";
            this.Text = "Product Prices";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.gbNonSelectionPanel.ResumeLayout(false);
            this.gbNonSelectionPanel.PerformLayout();
            this.gbSelectionPanel.ResumeLayout(false);
            this.gbSelectionPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProductStoreNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProductWidths;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLengthUnits;
        private System.Windows.Forms.TextBox txtTagPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGrades;
        private System.Windows.Forms.GroupBox gbNonSelectionPanel;
        private System.Windows.Forms.TextBox txtInventoryCode;
        private System.Windows.Forms.CheckBox chkUseInventoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag_price;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbSelectionPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelSelections;
        private System.Windows.Forms.Button btnUpdateSelected;
        private System.Windows.Forms.Label label9;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_QuickSearch;
        private System.Windows.Forms.Panel panel1;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_IsSelected;
        private System.Windows.Forms.DataGridViewLinkColumn col_grid_productStoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_inventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn width_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn length_unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_colorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_price;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_Checked;
        private System.Windows.Forms.CheckBox chkOnlyNotOK;
    }
}