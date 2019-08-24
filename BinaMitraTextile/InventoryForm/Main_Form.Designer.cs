﻿namespace BinaMitraTextile.InventoryForm
{
    partial class Main_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.iclb_ProductWidths = new LIBUtil.Desktop.UserControls.InputControl_CheckedListBox();
            this.iclb_Grades = new LIBUtil.Desktop.UserControls.InputControl_CheckedListBox();
            this.iclb_LengthUnits = new LIBUtil.Desktop.UserControls.InputControl_CheckedListBox();
            this.iclb_ProductStoreNames = new LIBUtil.Desktop.UserControls.InputControl_CheckedListBox();
            this.iclb_Colors = new LIBUtil.Desktop.UserControls.InputControl_CheckedListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlModeButtons = new System.Windows.Forms.Panel();
            this.btnClearQtyZeroes = new System.Windows.Forms.Button();
            this.btnUpdateItemColor = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.btnRefreshPage = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSetPrice = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlUpdateBuyPrice = new System.Windows.Forms.Panel();
            this.btnCancelUpdateBuyPrice = new System.Windows.Forms.Button();
            this.btnUpdateBuyPrice = new System.Windows.Forms.Button();
            this.in_BuyPrice = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_receiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_productWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_buyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_sellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_availablePcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_availableQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_totalPcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_totalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_invoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_packingListNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_isConsignment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_OpnameMarker = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.extracol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlQuickSearch = new System.Windows.Forms.Panel();
            this.chkCalculateBuyValue = new System.Windows.Forms.CheckBox();
            this.panelToggle1 = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.chkShowHidden = new System.Windows.Forms.CheckBox();
            this.chkRearrange = new System.Windows.Forms.CheckBox();
            this.chkLast3Months = new System.Windows.Forms.CheckBox();
            this.lblCounts = new System.Windows.Forms.Label();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.lnkClearQuickSearch = new System.Windows.Forms.LinkLabel();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.pnlModeButtons.SuspendLayout();
            this.pnlUpdateBuyPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlQuickSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbFilters);
            this.scMain.Panel1.Controls.Add(this.pnlModeButtons);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlUpdateBuyPrice);
            this.scMain.Panel2.Controls.Add(this.grid);
            this.scMain.Panel2.Controls.Add(this.pnlQuickSearch);
            this.scMain.Size = new System.Drawing.Size(1084, 609);
            this.scMain.SplitterDistance = 200;
            this.scMain.SplitterWidth = 1;
            this.scMain.TabIndex = 0;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.iclb_ProductWidths);
            this.gbFilters.Controls.Add(this.iclb_Grades);
            this.gbFilters.Controls.Add(this.iclb_LengthUnits);
            this.gbFilters.Controls.Add(this.iclb_ProductStoreNames);
            this.gbFilters.Controls.Add(this.iclb_Colors);
            this.gbFilters.Controls.Add(this.btnReset);
            this.gbFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFilters.Location = new System.Drawing.Point(5, 105);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(190, 499);
            this.gbFilters.TabIndex = 6;
            this.gbFilters.TabStop = false;
            // 
            // iclb_ProductWidths
            // 
            this.iclb_ProductWidths.LabelText = "Lebar";
            this.iclb_ProductWidths.Location = new System.Drawing.Point(96, 11);
            this.iclb_ProductWidths.Name = "iclb_ProductWidths";
            this.iclb_ProductWidths.ShowListOnly = true;
            this.iclb_ProductWidths.Size = new System.Drawing.Size(89, 80);
            this.iclb_ProductWidths.TabIndex = 20;
            this.iclb_ProductWidths.Item_Checked += new System.EventHandler(this.CheckedListBox_ItemChecked);
            // 
            // iclb_Grades
            // 
            this.iclb_Grades.LabelText = "Grades";
            this.iclb_Grades.Location = new System.Drawing.Point(5, 11);
            this.iclb_Grades.Name = "iclb_Grades";
            this.iclb_Grades.ShowListOnly = true;
            this.iclb_Grades.Size = new System.Drawing.Size(89, 80);
            this.iclb_Grades.TabIndex = 6;
            this.iclb_Grades.Item_Checked += new System.EventHandler(this.CheckedListBox_ItemChecked);
            // 
            // iclb_LengthUnits
            // 
            this.iclb_LengthUnits.LabelText = "Unit";
            this.iclb_LengthUnits.Location = new System.Drawing.Point(5, 93);
            this.iclb_LengthUnits.Name = "iclb_LengthUnits";
            this.iclb_LengthUnits.ShowListOnly = true;
            this.iclb_LengthUnits.Size = new System.Drawing.Size(179, 66);
            this.iclb_LengthUnits.TabIndex = 19;
            this.iclb_LengthUnits.Item_Checked += new System.EventHandler(this.CheckedListBox_ItemChecked);
            // 
            // iclb_ProductStoreNames
            // 
            this.iclb_ProductStoreNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.iclb_ProductStoreNames.LabelText = "Product (store)";
            this.iclb_ProductStoreNames.Location = new System.Drawing.Point(5, 306);
            this.iclb_ProductStoreNames.Name = "iclb_ProductStoreNames";
            this.iclb_ProductStoreNames.ShowListOnly = false;
            this.iclb_ProductStoreNames.Size = new System.Drawing.Size(180, 159);
            this.iclb_ProductStoreNames.TabIndex = 6;
            this.iclb_ProductStoreNames.Item_Checked += new System.EventHandler(this.CheckedListBox_ItemChecked);
            // 
            // iclb_Colors
            // 
            this.iclb_Colors.LabelText = "Warna";
            this.iclb_Colors.Location = new System.Drawing.Point(5, 160);
            this.iclb_Colors.Name = "iclb_Colors";
            this.iclb_Colors.ShowListOnly = false;
            this.iclb_Colors.Size = new System.Drawing.Size(180, 145);
            this.iclb_Colors.TabIndex = 6;
            this.iclb_Colors.Item_Checked += new System.EventHandler(this.CheckedListBox_ItemChecked);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(61, 465);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(69, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlModeButtons
            // 
            this.pnlModeButtons.Controls.Add(this.btnClearQtyZeroes);
            this.pnlModeButtons.Controls.Add(this.btnUpdateItemColor);
            this.pnlModeButtons.Controls.Add(this.btnAddItems);
            this.pnlModeButtons.Controls.Add(this.btnRefreshPage);
            this.pnlModeButtons.Controls.Add(this.btnUpdate);
            this.pnlModeButtons.Controls.Add(this.btnSetPrice);
            this.pnlModeButtons.Controls.Add(this.btnLog);
            this.pnlModeButtons.Controls.Add(this.btnAdd);
            this.pnlModeButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModeButtons.Location = new System.Drawing.Point(5, 5);
            this.pnlModeButtons.Name = "pnlModeButtons";
            this.pnlModeButtons.Size = new System.Drawing.Size(190, 100);
            this.pnlModeButtons.TabIndex = 108;
            this.pnlModeButtons.TabStop = true;
            // 
            // btnClearQtyZeroes
            // 
            this.btnClearQtyZeroes.Location = new System.Drawing.Point(95, 74);
            this.btnClearQtyZeroes.Name = "btnClearQtyZeroes";
            this.btnClearQtyZeroes.Size = new System.Drawing.Size(87, 23);
            this.btnClearQtyZeroes.TabIndex = 7;
            this.btnClearQtyZeroes.Text = "HIDE QTY 0";
            this.btnClearQtyZeroes.UseVisualStyleBackColor = true;
            this.btnClearQtyZeroes.Click += new System.EventHandler(this.btnClearQtyZeroes_Click);
            // 
            // btnUpdateItemColor
            // 
            this.btnUpdateItemColor.Location = new System.Drawing.Point(8, 74);
            this.btnUpdateItemColor.Name = "btnUpdateItemColor";
            this.btnUpdateItemColor.Size = new System.Drawing.Size(87, 23);
            this.btnUpdateItemColor.TabIndex = 6;
            this.btnUpdateItemColor.Text = "WARNA";
            this.btnUpdateItemColor.UseVisualStyleBackColor = true;
            this.btnUpdateItemColor.Click += new System.EventHandler(this.btnUpdateItemColor_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Location = new System.Drawing.Point(95, 5);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(87, 23);
            this.btnAddItems.TabIndex = 1;
            this.btnAddItems.Text = "ITEMS";
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // btnRefreshPage
            // 
            this.btnRefreshPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPage.Location = new System.Drawing.Point(95, 51);
            this.btnRefreshPage.Name = "btnRefreshPage";
            this.btnRefreshPage.Size = new System.Drawing.Size(87, 23);
            this.btnRefreshPage.TabIndex = 5;
            this.btnRefreshPage.Text = "REFRESH PAGE";
            this.btnRefreshPage.UseVisualStyleBackColor = true;
            this.btnRefreshPage.Click += new System.EventHandler(this.btnRefreshPage_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(95, 28);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSetPrice
            // 
            this.btnSetPrice.Location = new System.Drawing.Point(8, 28);
            this.btnSetPrice.Name = "btnSetPrice";
            this.btnSetPrice.Size = new System.Drawing.Size(87, 23);
            this.btnSetPrice.TabIndex = 2;
            this.btnSetPrice.Text = "SET PRICE";
            this.btnSetPrice.UseVisualStyleBackColor = true;
            this.btnSetPrice.Click += new System.EventHandler(this.btnSetPrice_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(8, 51);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(87, 23);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ADD NEW";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlUpdateBuyPrice
            // 
            this.pnlUpdateBuyPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlUpdateBuyPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdateBuyPrice.Controls.Add(this.btnCancelUpdateBuyPrice);
            this.pnlUpdateBuyPrice.Controls.Add(this.btnUpdateBuyPrice);
            this.pnlUpdateBuyPrice.Controls.Add(this.in_BuyPrice);
            this.pnlUpdateBuyPrice.Location = new System.Drawing.Point(331, 249);
            this.pnlUpdateBuyPrice.Name = "pnlUpdateBuyPrice";
            this.pnlUpdateBuyPrice.Size = new System.Drawing.Size(230, 110);
            this.pnlUpdateBuyPrice.TabIndex = 7;
            this.pnlUpdateBuyPrice.Visible = false;
            // 
            // btnCancelUpdateBuyPrice
            // 
            this.btnCancelUpdateBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelUpdateBuyPrice.Location = new System.Drawing.Point(123, 66);
            this.btnCancelUpdateBuyPrice.Name = "btnCancelUpdateBuyPrice";
            this.btnCancelUpdateBuyPrice.Size = new System.Drawing.Size(61, 23);
            this.btnCancelUpdateBuyPrice.TabIndex = 2;
            this.btnCancelUpdateBuyPrice.Text = "CANCEL";
            this.btnCancelUpdateBuyPrice.UseVisualStyleBackColor = true;
            this.btnCancelUpdateBuyPrice.Click += new System.EventHandler(this.btnCancelUpdateBuyPrice_Click);
            // 
            // btnUpdateBuyPrice
            // 
            this.btnUpdateBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateBuyPrice.Location = new System.Drawing.Point(45, 66);
            this.btnUpdateBuyPrice.Name = "btnUpdateBuyPrice";
            this.btnUpdateBuyPrice.Size = new System.Drawing.Size(72, 23);
            this.btnUpdateBuyPrice.TabIndex = 1;
            this.btnUpdateBuyPrice.Text = "UPDATE";
            this.btnUpdateBuyPrice.UseVisualStyleBackColor = true;
            this.btnUpdateBuyPrice.Click += new System.EventHandler(this.btnUpdateBuyPrice_Click);
            // 
            // in_BuyPrice
            // 
            this.in_BuyPrice.Checked = false;
            this.in_BuyPrice.DecimalPlaces = 2;
            this.in_BuyPrice.HideUpDown = true;
            this.in_BuyPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_BuyPrice.LabelText = "Buy";
            this.in_BuyPrice.Location = new System.Drawing.Point(45, 19);
            this.in_BuyPrice.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_BuyPrice.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_BuyPrice.Name = "in_BuyPrice";
            this.in_BuyPrice.ShowAllowDecimalCheckbox = false;
            this.in_BuyPrice.ShowCheckbox = false;
            this.in_BuyPrice.ShowTextboxOnly = false;
            this.in_BuyPrice.Size = new System.Drawing.Size(139, 41);
            this.in_BuyPrice.TabIndex = 0;
            this.in_BuyPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_BuyPrice.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.in_BuyPrice_onKeyDown);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_grid_id,
            this.col_grid_receiveDate,
            this.col_grid_code,
            this.col_grid_grade,
            this.col_grid_product,
            this.col_grid_productWidth,
            this.col_grid_color,
            this.col_grid_buyPrice,
            this.col_grid_sellPrice,
            this.col_grid_select,
            this.col_grid_availablePcs,
            this.col_grid_availableQty,
            this.col_grid_unit,
            this.col_grid_totalPcs,
            this.col_grid_totalQty,
            this.col_grid_invoiceNo,
            this.col_grid_packingListNo,
            this.col_grid_active,
            this.col_grid_isConsignment,
            this.col_grid_OpnameMarker,
            this.extracol});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 28);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(883, 581);
            this.grid.TabIndex = 5;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // col_grid_id
            // 
            this.col_grid_id.DataPropertyName = "id";
            this.col_grid_id.HeaderText = "id";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            // 
            // col_grid_receiveDate
            // 
            this.col_grid_receiveDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd/MM/yy";
            this.col_grid_receiveDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_receiveDate.HeaderText = "Terima";
            this.col_grid_receiveDate.MinimumWidth = 50;
            this.col_grid_receiveDate.Name = "col_grid_receiveDate";
            this.col_grid_receiveDate.ReadOnly = true;
            this.col_grid_receiveDate.Width = 50;
            // 
            // col_grid_code
            // 
            this.col_grid_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_code.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_code.HeaderText = "Code";
            this.col_grid_code.MinimumWidth = 30;
            this.col_grid_code.Name = "col_grid_code";
            this.col_grid_code.ReadOnly = true;
            this.col_grid_code.Width = 30;
            // 
            // col_grid_grade
            // 
            this.col_grid_grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_grade.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_grade.HeaderText = "Grade";
            this.col_grid_grade.MinimumWidth = 40;
            this.col_grid_grade.Name = "col_grid_grade";
            this.col_grid_grade.ReadOnly = true;
            this.col_grid_grade.Width = 40;
            // 
            // col_grid_product
            // 
            this.col_grid_product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_product.HeaderText = "Product (Store)";
            this.col_grid_product.MinimumWidth = 80;
            this.col_grid_product.Name = "col_grid_product";
            this.col_grid_product.ReadOnly = true;
            // 
            // col_grid_productWidth
            // 
            this.col_grid_productWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_productWidth.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_grid_productWidth.HeaderText = "Lebar";
            this.col_grid_productWidth.MinimumWidth = 40;
            this.col_grid_productWidth.Name = "col_grid_productWidth";
            this.col_grid_productWidth.ReadOnly = true;
            this.col_grid_productWidth.Width = 40;
            // 
            // col_grid_color
            // 
            this.col_grid_color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_color.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_grid_color.HeaderText = "Warna";
            this.col_grid_color.MinimumWidth = 40;
            this.col_grid_color.Name = "col_grid_color";
            this.col_grid_color.ReadOnly = true;
            this.col_grid_color.Width = 40;
            // 
            // col_grid_buyPrice
            // 
            this.col_grid_buyPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.col_grid_buyPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_grid_buyPrice.HeaderText = "Buy";
            this.col_grid_buyPrice.MinimumWidth = 40;
            this.col_grid_buyPrice.Name = "col_grid_buyPrice";
            this.col_grid_buyPrice.ReadOnly = true;
            this.col_grid_buyPrice.Width = 40;
            // 
            // col_grid_sellPrice
            // 
            this.col_grid_sellPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.col_grid_sellPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_grid_sellPrice.HeaderText = "Price";
            this.col_grid_sellPrice.MinimumWidth = 40;
            this.col_grid_sellPrice.Name = "col_grid_sellPrice";
            this.col_grid_sellPrice.ReadOnly = true;
            this.col_grid_sellPrice.Width = 40;
            // 
            // col_grid_select
            // 
            this.col_grid_select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_select.HeaderText = "";
            this.col_grid_select.MinimumWidth = 30;
            this.col_grid_select.Name = "col_grid_select";
            this.col_grid_select.Width = 30;
            // 
            // col_grid_availablePcs
            // 
            this.col_grid_availablePcs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_availablePcs.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_grid_availablePcs.HeaderText = "";
            this.col_grid_availablePcs.MinimumWidth = 30;
            this.col_grid_availablePcs.Name = "col_grid_availablePcs";
            this.col_grid_availablePcs.ReadOnly = true;
            this.col_grid_availablePcs.Width = 30;
            // 
            // col_grid_availableQty
            // 
            this.col_grid_availableQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.col_grid_availableQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.col_grid_availableQty.HeaderText = "Qty";
            this.col_grid_availableQty.MinimumWidth = 30;
            this.col_grid_availableQty.Name = "col_grid_availableQty";
            this.col_grid_availableQty.ReadOnly = true;
            this.col_grid_availableQty.Width = 30;
            // 
            // col_grid_unit
            // 
            this.col_grid_unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_unit.DefaultCellStyle = dataGridViewCellStyle11;
            this.col_grid_unit.HeaderText = "Unit";
            this.col_grid_unit.MinimumWidth = 40;
            this.col_grid_unit.Name = "col_grid_unit";
            this.col_grid_unit.ReadOnly = true;
            this.col_grid_unit.Width = 40;
            // 
            // col_grid_totalPcs
            // 
            this.col_grid_totalPcs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_totalPcs.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_grid_totalPcs.HeaderText = "";
            this.col_grid_totalPcs.MinimumWidth = 30;
            this.col_grid_totalPcs.Name = "col_grid_totalPcs";
            this.col_grid_totalPcs.ReadOnly = true;
            this.col_grid_totalPcs.Width = 30;
            // 
            // col_grid_totalQty
            // 
            this.col_grid_totalQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.col_grid_totalQty.DefaultCellStyle = dataGridViewCellStyle13;
            this.col_grid_totalQty.HeaderText = "Terima";
            this.col_grid_totalQty.MinimumWidth = 50;
            this.col_grid_totalQty.Name = "col_grid_totalQty";
            this.col_grid_totalQty.ReadOnly = true;
            this.col_grid_totalQty.Width = 50;
            // 
            // col_grid_invoiceNo
            // 
            this.col_grid_invoiceNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_grid_invoiceNo.HeaderText = "Invoice";
            this.col_grid_invoiceNo.MinimumWidth = 50;
            this.col_grid_invoiceNo.Name = "col_grid_invoiceNo";
            this.col_grid_invoiceNo.ReadOnly = true;
            this.col_grid_invoiceNo.Width = 50;
            // 
            // col_grid_packingListNo
            // 
            this.col_grid_packingListNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_grid_packingListNo.HeaderText = "Pack List";
            this.col_grid_packingListNo.MinimumWidth = 50;
            this.col_grid_packingListNo.Name = "col_grid_packingListNo";
            this.col_grid_packingListNo.ReadOnly = true;
            this.col_grid_packingListNo.Width = 50;
            // 
            // col_grid_active
            // 
            this.col_grid_active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_active.HeaderText = "On";
            this.col_grid_active.MinimumWidth = 30;
            this.col_grid_active.Name = "col_grid_active";
            this.col_grid_active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_active.Width = 30;
            // 
            // col_grid_isConsignment
            // 
            this.col_grid_isConsignment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_grid_isConsignment.HeaderText = "Titip";
            this.col_grid_isConsignment.MinimumWidth = 40;
            this.col_grid_isConsignment.Name = "col_grid_isConsignment";
            this.col_grid_isConsignment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_isConsignment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_isConsignment.Width = 47;
            // 
            // col_grid_OpnameMarker
            // 
            this.col_grid_OpnameMarker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_OpnameMarker.HeaderText = "OP";
            this.col_grid_OpnameMarker.MinimumWidth = 30;
            this.col_grid_OpnameMarker.Name = "col_grid_OpnameMarker";
            this.col_grid_OpnameMarker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_OpnameMarker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_OpnameMarker.Width = 30;
            // 
            // extracol
            // 
            this.extracol.HeaderText = "";
            this.extracol.Name = "extracol";
            this.extracol.ReadOnly = true;
            this.extracol.Width = 5;
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkCalculateBuyValue);
            this.pnlQuickSearch.Controls.Add(this.panelToggle1);
            this.pnlQuickSearch.Controls.Add(this.chkShowHidden);
            this.pnlQuickSearch.Controls.Add(this.chkRearrange);
            this.pnlQuickSearch.Controls.Add(this.chkLast3Months);
            this.pnlQuickSearch.Controls.Add(this.lblCounts);
            this.pnlQuickSearch.Controls.Add(this.txtQuickSearch);
            this.pnlQuickSearch.Controls.Add(this.lnkClearQuickSearch);
            this.pnlQuickSearch.Controls.Add(this.chkIncludeInactive);
            this.pnlQuickSearch.Controls.Add(this.label1);
            this.pnlQuickSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlQuickSearch.Name = "pnlQuickSearch";
            this.pnlQuickSearch.Size = new System.Drawing.Size(883, 28);
            this.pnlQuickSearch.TabIndex = 0;
            // 
            // chkCalculateBuyValue
            // 
            this.chkCalculateBuyValue.AutoSize = true;
            this.chkCalculateBuyValue.Location = new System.Drawing.Point(476, 6);
            this.chkCalculateBuyValue.Name = "chkCalculateBuyValue";
            this.chkCalculateBuyValue.Size = new System.Drawing.Size(43, 17);
            this.chkCalculateBuyValue.TabIndex = 18;
            this.chkCalculateBuyValue.Text = "buy";
            this.chkCalculateBuyValue.UseVisualStyleBackColor = true;
            // 
            // panelToggle1
            // 
            this.panelToggle1.AdjustLocationOnClick = false;
            this.panelToggle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelToggle1.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Left;
            this.panelToggle1.Location = new System.Drawing.Point(0, 0);
            this.panelToggle1.Name = "panelToggle1";
            this.panelToggle1.Size = new System.Drawing.Size(25, 25);
            this.panelToggle1.TabIndex = 6;
            this.panelToggle1.TogglePanel = this.scMain.Panel1;
            // 
            // chkShowHidden
            // 
            this.chkShowHidden.AutoSize = true;
            this.chkShowHidden.Location = new System.Drawing.Point(441, 6);
            this.chkShowHidden.Name = "chkShowHidden";
            this.chkShowHidden.Size = new System.Drawing.Size(33, 17);
            this.chkShowHidden.TabIndex = 6;
            this.chkShowHidden.Text = "X";
            this.chkShowHidden.UseVisualStyleBackColor = true;
            this.chkShowHidden.CheckedChanged += new System.EventHandler(this.chkShowHidden_CheckedChanged);
            // 
            // chkRearrange
            // 
            this.chkRearrange.AutoSize = true;
            this.chkRearrange.Location = new System.Drawing.Point(374, 6);
            this.chkRearrange.Name = "chkRearrange";
            this.chkRearrange.Size = new System.Drawing.Size(71, 17);
            this.chkRearrange.TabIndex = 17;
            this.chkRearrange.TabStop = false;
            this.chkRearrange.Text = "rearrange";
            this.chkRearrange.UseVisualStyleBackColor = true;
            this.chkRearrange.CheckedChanged += new System.EventHandler(this.chkRearrange_CheckedChanged);
            // 
            // chkLast3Months
            // 
            this.chkLast3Months.AutoSize = true;
            this.chkLast3Months.Checked = true;
            this.chkLast3Months.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLast3Months.Location = new System.Drawing.Point(280, 6);
            this.chkLast3Months.Name = "chkLast3Months";
            this.chkLast3Months.Size = new System.Drawing.Size(88, 17);
            this.chkLast3Months.TabIndex = 15;
            this.chkLast3Months.TabStop = false;
            this.chkLast3Months.Text = "last 3 months";
            this.chkLast3Months.UseVisualStyleBackColor = true;
            this.chkLast3Months.CheckedChanged += new System.EventHandler(this.chkLast3Months_CheckedChanged);
            // 
            // lblCounts
            // 
            this.lblCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounts.Location = new System.Drawing.Point(451, 8);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCounts.Size = new System.Drawing.Size(420, 13);
            this.lblCounts.TabIndex = 12;
            this.lblCounts.Text = "lblCounts";
            this.lblCounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(109, 4);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(57, 20);
            this.txtQuickSearch.TabIndex = 0;
            this.txtQuickSearch.TextChanged += new System.EventHandler(this.txtQuickSearch_TextChanged);
            // 
            // lnkClearQuickSearch
            // 
            this.lnkClearQuickSearch.ActiveLinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.AutoSize = true;
            this.lnkClearQuickSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClearQuickSearch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkClearQuickSearch.LinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.Location = new System.Drawing.Point(164, 8);
            this.lnkClearQuickSearch.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lnkClearQuickSearch.Name = "lnkClearQuickSearch";
            this.lnkClearQuickSearch.Size = new System.Drawing.Size(15, 13);
            this.lnkClearQuickSearch.TabIndex = 1;
            this.lnkClearQuickSearch.TabStop = true;
            this.lnkClearQuickSearch.Text = "X";
            this.lnkClearQuickSearch.VisitedLinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearQuickSearch_LinkClicked);
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(183, 6);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(91, 17);
            this.chkIncludeInactive.TabIndex = 1;
            this.chkIncludeInactive.TabStop = false;
            this.chkIncludeInactive.Text = "show inactive";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged += new System.EventHandler(this.chkIncludeInactive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Quick Search:";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 609);
            this.Controls.Add(this.scMain);
            this.Name = "Main_Form";
            this.Text = "INVENTORY";
            this.Load += new System.EventHandler(this.Inventory_Form_Load);
            this.Shown += new System.EventHandler(this.Main_Form_Shown);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.pnlModeButtons.ResumeLayout(false);
            this.pnlUpdateBuyPrice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        public System.Windows.Forms.Panel pnlModeButtons;
        public System.Windows.Forms.Button btnLog;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlQuickSearch;
        public System.Windows.Forms.LinkLabel lnkClearQuickSearch;
        public System.Windows.Forms.CheckBox chkIncludeInactive;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtQuickSearch;
        public System.Windows.Forms.Button btnSetPrice;
        public System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.GroupBox gbFilters;
        public System.Windows.Forms.Button btnRefreshPage;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.DataGridView grid;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnUpdateItemColor;
        private LIBUtil.Desktop.UserControls.InputControl_CheckedListBox iclb_Colors;
        private LIBUtil.Desktop.UserControls.InputControl_CheckedListBox iclb_ProductStoreNames;
        private LIBUtil.Desktop.UserControls.InputControl_CheckedListBox iclb_LengthUnits;
        private LIBUtil.Desktop.UserControls.InputControl_CheckedListBox iclb_ProductWidths;
        private LIBUtil.Desktop.UserControls.InputControl_CheckedListBox iclb_Grades;
        public System.Windows.Forms.CheckBox chkLast3Months;
        public System.Windows.Forms.CheckBox chkRearrange;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private LIBUtil.Desktop.UserControls.PanelToggle panelToggle1;
        private System.Windows.Forms.Panel pnlUpdateBuyPrice;
        public System.Windows.Forms.Button btnUpdateBuyPrice;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_BuyPrice;
        public System.Windows.Forms.Button btnCancelUpdateBuyPrice;
        private System.Windows.Forms.CheckBox chkCalculateBuyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_receiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_productWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_buyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_sellPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_availablePcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_availableQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_totalPcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_totalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_invoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_packingListNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_active;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_isConsignment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_OpnameMarker;
        private System.Windows.Forms.DataGridViewTextBoxColumn extracol;
        public System.Windows.Forms.Button btnClearQtyZeroes;
    }
}