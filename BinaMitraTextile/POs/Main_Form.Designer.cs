namespace BinaMitraTextile.POs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProductStoreNames = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPackingListNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVendors = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddPO = new System.Windows.Forms.Button();
            this.gridPO = new System.Windows.Forms.DataGridView();
            this.col_gridPO_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_po_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_vendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_vendor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPO_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLog = new System.Windows.Forms.Button();
            this.gridPOItems = new System.Windows.Forms.DataGridView();
            this.col_gridPOItems_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_po_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_productDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_unitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_receivedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_pricePerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridPOItems_statusEnumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_SaleOrderItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlUpdatePOItem = new System.Windows.Forms.Panel();
            this.itxt_POItemNotes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_POItemPricePerUnit = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnCancelUpdatePOItemQty = new System.Windows.Forms.Button();
            this.btnUpdatePOItem = new System.Windows.Forms.Button();
            this.in_POItemQty = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).BeginInit();
            this.pnlUpdatePOItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProductStoreNames);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPackingListNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbStatus);
            this.groupBox1.Controls.Add(this.txtPONo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbVendors);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(7, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(283, 301);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cbProductStoreNames
            // 
            this.cbProductStoreNames.FormattingEnabled = true;
            this.cbProductStoreNames.Location = new System.Drawing.Point(88, 107);
            this.cbProductStoreNames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbProductStoreNames.Name = "cbProductStoreNames";
            this.cbProductStoreNames.Size = new System.Drawing.Size(189, 21);
            this.cbProductStoreNames.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 117;
            this.label8.Text = "Invoice No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(88, 76);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(111, 20);
            this.txtInvoiceNo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "Pack List No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Product";
            // 
            // txtPackingListNo
            // 
            this.txtPackingListNo.Location = new System.Drawing.Point(88, 47);
            this.txtPackingListNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPackingListNo.Name = "txtPackingListNo";
            this.txtPackingListNo.Size = new System.Drawing.Size(111, 20);
            this.txtPackingListNo.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(88, 168);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(189, 21);
            this.cbStatus.TabIndex = 5;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(88, 17);
            this.txtPONo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(111, 20);
            this.txtPONo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "PO #";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dddd, dd/MM/yy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(88, 199);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(189, 20);
            this.dtpStart.TabIndex = 6;
            this.dtpStart.Value = new System.DateTime(2014, 11, 15, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "from";
            // 
            // cbVendors
            // 
            this.cbVendors.FormattingEnabled = true;
            this.cbVendors.Location = new System.Drawing.Point(88, 138);
            this.cbVendors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVendors.Name = "cbVendors";
            this.cbVendors.Size = new System.Drawing.Size(189, 21);
            this.cbVendors.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(71, 272);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(109, 26);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dddd, dd/MM/yy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(88, 229);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(189, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Vendor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "to";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(185, 272);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddPO
            // 
            this.btnAddPO.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAddPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPO.ForeColor = System.Drawing.Color.Orange;
            this.btnAddPO.Location = new System.Drawing.Point(12, 3);
            this.btnAddPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPO.Name = "btnAddPO";
            this.btnAddPO.Size = new System.Drawing.Size(129, 34);
            this.btnAddPO.TabIndex = 0;
            this.btnAddPO.Text = "CREATE";
            this.btnAddPO.UseVisualStyleBackColor = true;
            this.btnAddPO.Click += new System.EventHandler(this.btnAddPO_Click);
            // 
            // gridPO
            // 
            this.gridPO.AllowUserToAddRows = false;
            this.gridPO.AllowUserToDeleteRows = false;
            this.gridPO.AllowUserToResizeRows = false;
            this.gridPO.BackgroundColor = System.Drawing.Color.White;
            this.gridPO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.gridPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridPO_id,
            this.col_gridPO_timestamp,
            this.col_gridPO_po_no,
            this.col_gridPO_vendorID,
            this.col_gridPO_vendor_name,
            this.col_gridPO_amount,
            this.col_gridPO_notes});
            this.gridPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPO.Location = new System.Drawing.Point(0, 0);
            this.gridPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridPO.MultiSelect = false;
            this.gridPO.Name = "gridPO";
            this.gridPO.ReadOnly = true;
            this.gridPO.RowHeadersVisible = false;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridPO.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.gridPO.RowTemplate.Height = 24;
            this.gridPO.Size = new System.Drawing.Size(853, 354);
            this.gridPO.TabIndex = 114;
            this.gridPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPO_CellDoubleClick);
            this.gridPO.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridPO_CellMouseDown);
            this.gridPO.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridPO_DataBindingComplete);
            this.gridPO.SelectionChanged += new System.EventHandler(this.gridPO_SelectionChanged);
            // 
            // col_gridPO_id
            // 
            this.col_gridPO_id.HeaderText = "ID";
            this.col_gridPO_id.Name = "col_gridPO_id";
            this.col_gridPO_id.ReadOnly = true;
            this.col_gridPO_id.Visible = false;
            // 
            // col_gridPO_timestamp
            // 
            this.col_gridPO_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle26.Format = "dd/MM/yy HH:mm";
            this.col_gridPO_timestamp.DefaultCellStyle = dataGridViewCellStyle26;
            this.col_gridPO_timestamp.HeaderText = "Date";
            this.col_gridPO_timestamp.MinimumWidth = 40;
            this.col_gridPO_timestamp.Name = "col_gridPO_timestamp";
            this.col_gridPO_timestamp.ReadOnly = true;
            this.col_gridPO_timestamp.Width = 40;
            // 
            // col_gridPO_po_no
            // 
            this.col_gridPO_po_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridPO_po_no.HeaderText = "PO";
            this.col_gridPO_po_no.MinimumWidth = 30;
            this.col_gridPO_po_no.Name = "col_gridPO_po_no";
            this.col_gridPO_po_no.ReadOnly = true;
            this.col_gridPO_po_no.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridPO_po_no.Width = 30;
            // 
            // col_gridPO_vendorID
            // 
            this.col_gridPO_vendorID.HeaderText = "Vendor ID";
            this.col_gridPO_vendorID.Name = "col_gridPO_vendorID";
            this.col_gridPO_vendorID.ReadOnly = true;
            this.col_gridPO_vendorID.Visible = false;
            // 
            // col_gridPO_vendor_name
            // 
            this.col_gridPO_vendor_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridPO_vendor_name.HeaderText = "Vendor";
            this.col_gridPO_vendor_name.MinimumWidth = 50;
            this.col_gridPO_vendor_name.Name = "col_gridPO_vendor_name";
            this.col_gridPO_vendor_name.ReadOnly = true;
            this.col_gridPO_vendor_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridPO_vendor_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_gridPO_vendor_name.Width = 50;
            // 
            // col_gridPO_amount
            // 
            this.col_gridPO_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N2";
            this.col_gridPO_amount.DefaultCellStyle = dataGridViewCellStyle27;
            this.col_gridPO_amount.HeaderText = "Amount";
            this.col_gridPO_amount.MinimumWidth = 50;
            this.col_gridPO_amount.Name = "col_gridPO_amount";
            this.col_gridPO_amount.ReadOnly = true;
            this.col_gridPO_amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridPO_amount.Width = 50;
            // 
            // col_gridPO_notes
            // 
            this.col_gridPO_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridPO_notes.HeaderText = "Notes";
            this.col_gridPO_notes.MinimumWidth = 50;
            this.col_gridPO_notes.Name = "col_gridPO_notes";
            this.col_gridPO_notes.ReadOnly = true;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Margin = new System.Windows.Forms.Padding(4);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.groupBox1);
            this.scMain.Panel1.Controls.Add(this.panel1);
            this.scMain.Panel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlUpdatePOItem);
            this.scMain.Panel2.Controls.Add(this.gridPO);
            this.scMain.Size = new System.Drawing.Size(1155, 354);
            this.scMain.SplitterDistance = 297;
            this.scMain.SplitterWidth = 5;
            this.scMain.TabIndex = 115;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.btnAddPO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 41);
            this.panel1.TabIndex = 115;
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(141, 3);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(129, 34);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // gridPOItems
            // 
            this.gridPOItems.AllowUserToAddRows = false;
            this.gridPOItems.AllowUserToDeleteRows = false;
            this.gridPOItems.AllowUserToResizeRows = false;
            this.gridPOItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridPOItems.BackgroundColor = System.Drawing.Color.White;
            this.gridPOItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPOItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPOItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.gridPOItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPOItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridPOItems_id,
            this.col_gridPOItems_no,
            this.col_gridPOItems_po_no,
            this.col_gridPOItems_date,
            this.col_gridPOItems_productDescription,
            this.col_gridPOItems_notes,
            this.col_gridPOItems_qty,
            this.col_gridPOItems_unitName,
            this.col_gridPOItems_receivedQty,
            this.col_gridPOItems_pricePerUnit,
            this.col_gridPOItems_subtotal,
            this.col_gridPOItems_status_name,
            this.col_gridPOItems_statusEnumID,
            this.col_grid_SaleOrderItemDescription});
            this.gridPOItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPOItems.Location = new System.Drawing.Point(0, 354);
            this.gridPOItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridPOItems.MultiSelect = false;
            this.gridPOItems.Name = "gridPOItems";
            this.gridPOItems.ReadOnly = true;
            this.gridPOItems.RowHeadersVisible = false;
            this.gridPOItems.RowTemplate.Height = 24;
            this.gridPOItems.Size = new System.Drawing.Size(1155, 199);
            this.gridPOItems.TabIndex = 116;
            this.gridPOItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPOItems_CellDoubleClick);
            this.gridPOItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridPOItems_CellMouseDown);
            // 
            // col_gridPOItems_id
            // 
            this.col_gridPOItems_id.HeaderText = "ID";
            this.col_gridPOItems_id.Name = "col_gridPOItems_id";
            this.col_gridPOItems_id.ReadOnly = true;
            this.col_gridPOItems_id.Visible = false;
            // 
            // col_gridPOItems_no
            // 
            this.col_gridPOItems_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridPOItems_no.HeaderText = "No";
            this.col_gridPOItems_no.MinimumWidth = 20;
            this.col_gridPOItems_no.Name = "col_gridPOItems_no";
            this.col_gridPOItems_no.ReadOnly = true;
            this.col_gridPOItems_no.Width = 20;
            // 
            // col_gridPOItems_po_no
            // 
            this.col_gridPOItems_po_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridPOItems_po_no.HeaderText = "PO No";
            this.col_gridPOItems_po_no.MinimumWidth = 30;
            this.col_gridPOItems_po_no.Name = "col_gridPOItems_po_no";
            this.col_gridPOItems_po_no.ReadOnly = true;
            this.col_gridPOItems_po_no.Visible = false;
            // 
            // col_gridPOItems_date
            // 
            this.col_gridPOItems_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.Format = "dd/MM";
            this.col_gridPOItems_date.DefaultCellStyle = dataGridViewCellStyle30;
            this.col_gridPOItems_date.HeaderText = "Date";
            this.col_gridPOItems_date.MinimumWidth = 30;
            this.col_gridPOItems_date.Name = "col_gridPOItems_date";
            this.col_gridPOItems_date.ReadOnly = true;
            this.col_gridPOItems_date.Visible = false;
            // 
            // col_gridPOItems_productDescription
            // 
            this.col_gridPOItems_productDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridPOItems_productDescription.HeaderText = "Product Description";
            this.col_gridPOItems_productDescription.MinimumWidth = 200;
            this.col_gridPOItems_productDescription.Name = "col_gridPOItems_productDescription";
            this.col_gridPOItems_productDescription.ReadOnly = true;
            // 
            // col_gridPOItems_notes
            // 
            this.col_gridPOItems_notes.HeaderText = "Notes";
            this.col_gridPOItems_notes.MinimumWidth = 50;
            this.col_gridPOItems_notes.Name = "col_gridPOItems_notes";
            this.col_gridPOItems_notes.ReadOnly = true;
            this.col_gridPOItems_notes.Width = 50;
            // 
            // col_gridPOItems_qty
            // 
            this.col_gridPOItems_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "N2";
            this.col_gridPOItems_qty.DefaultCellStyle = dataGridViewCellStyle31;
            this.col_gridPOItems_qty.HeaderText = "Order";
            this.col_gridPOItems_qty.MinimumWidth = 30;
            this.col_gridPOItems_qty.Name = "col_gridPOItems_qty";
            this.col_gridPOItems_qty.ReadOnly = true;
            this.col_gridPOItems_qty.Width = 30;
            // 
            // col_gridPOItems_unitName
            // 
            this.col_gridPOItems_unitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_unitName.DefaultCellStyle = dataGridViewCellStyle32;
            this.col_gridPOItems_unitName.HeaderText = "Unit";
            this.col_gridPOItems_unitName.MinimumWidth = 30;
            this.col_gridPOItems_unitName.Name = "col_gridPOItems_unitName";
            this.col_gridPOItems_unitName.ReadOnly = true;
            this.col_gridPOItems_unitName.Width = 30;
            // 
            // col_gridPOItems_receivedQty
            // 
            this.col_gridPOItems_receivedQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "N2";
            this.col_gridPOItems_receivedQty.DefaultCellStyle = dataGridViewCellStyle33;
            this.col_gridPOItems_receivedQty.HeaderText = "Received";
            this.col_gridPOItems_receivedQty.MinimumWidth = 50;
            this.col_gridPOItems_receivedQty.Name = "col_gridPOItems_receivedQty";
            this.col_gridPOItems_receivedQty.ReadOnly = true;
            this.col_gridPOItems_receivedQty.Width = 50;
            // 
            // col_gridPOItems_pricePerUnit
            // 
            this.col_gridPOItems_pricePerUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "N2";
            this.col_gridPOItems_pricePerUnit.DefaultCellStyle = dataGridViewCellStyle34;
            this.col_gridPOItems_pricePerUnit.HeaderText = "Price";
            this.col_gridPOItems_pricePerUnit.MinimumWidth = 50;
            this.col_gridPOItems_pricePerUnit.Name = "col_gridPOItems_pricePerUnit";
            this.col_gridPOItems_pricePerUnit.ReadOnly = true;
            this.col_gridPOItems_pricePerUnit.Width = 50;
            // 
            // col_gridPOItems_subtotal
            // 
            this.col_gridPOItems_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "N2";
            dataGridViewCellStyle35.NullValue = null;
            this.col_gridPOItems_subtotal.DefaultCellStyle = dataGridViewCellStyle35;
            this.col_gridPOItems_subtotal.HeaderText = "Subtotal";
            this.col_gridPOItems_subtotal.MinimumWidth = 50;
            this.col_gridPOItems_subtotal.Name = "col_gridPOItems_subtotal";
            this.col_gridPOItems_subtotal.ReadOnly = true;
            this.col_gridPOItems_subtotal.Width = 50;
            // 
            // col_gridPOItems_status_name
            // 
            this.col_gridPOItems_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridPOItems_status_name.DefaultCellStyle = dataGridViewCellStyle36;
            this.col_gridPOItems_status_name.HeaderText = "Status";
            this.col_gridPOItems_status_name.MinimumWidth = 40;
            this.col_gridPOItems_status_name.Name = "col_gridPOItems_status_name";
            this.col_gridPOItems_status_name.ReadOnly = true;
            this.col_gridPOItems_status_name.Width = 40;
            // 
            // col_gridPOItems_statusEnumID
            // 
            this.col_gridPOItems_statusEnumID.HeaderText = "Status Enum ID";
            this.col_gridPOItems_statusEnumID.Name = "col_gridPOItems_statusEnumID";
            this.col_gridPOItems_statusEnumID.ReadOnly = true;
            this.col_gridPOItems_statusEnumID.Visible = false;
            // 
            // col_grid_SaleOrderItemDescription
            // 
            this.col_grid_SaleOrderItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_SaleOrderItemDescription.HeaderText = "SO";
            this.col_grid_SaleOrderItemDescription.MinimumWidth = 30;
            this.col_grid_SaleOrderItemDescription.Name = "col_grid_SaleOrderItemDescription";
            this.col_grid_SaleOrderItemDescription.ReadOnly = true;
            this.col_grid_SaleOrderItemDescription.Width = 30;
            // 
            // pnlUpdatePOItem
            // 
            this.pnlUpdatePOItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlUpdatePOItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdatePOItem.Controls.Add(this.itxt_POItemNotes);
            this.pnlUpdatePOItem.Controls.Add(this.in_POItemPricePerUnit);
            this.pnlUpdatePOItem.Controls.Add(this.btnCancelUpdatePOItemQty);
            this.pnlUpdatePOItem.Controls.Add(this.btnUpdatePOItem);
            this.pnlUpdatePOItem.Controls.Add(this.in_POItemQty);
            this.pnlUpdatePOItem.Location = new System.Drawing.Point(120, 82);
            this.pnlUpdatePOItem.Margin = new System.Windows.Forms.Padding(4);
            this.pnlUpdatePOItem.Name = "pnlUpdatePOItem";
            this.pnlUpdatePOItem.Size = new System.Drawing.Size(306, 249);
            this.pnlUpdatePOItem.TabIndex = 121;
            this.pnlUpdatePOItem.Visible = false;
            // 
            // itxt_POItemNotes
            // 
            this.itxt_POItemNotes.IsBrowseMode = false;
            this.itxt_POItemNotes.LabelText = "Notes";
            this.itxt_POItemNotes.Location = new System.Drawing.Point(38, 103);
            this.itxt_POItemNotes.Margin = new System.Windows.Forms.Padding(4);
            this.itxt_POItemNotes.MaxLength = 32767;
            this.itxt_POItemNotes.MultiLine = true;
            this.itxt_POItemNotes.Name = "itxt_POItemNotes";
            this.itxt_POItemNotes.PasswordChar = '\0';
            this.itxt_POItemNotes.RowCount = 4;
            this.itxt_POItemNotes.ShowDeleteButton = false;
            this.itxt_POItemNotes.ShowFilter = false;
            this.itxt_POItemNotes.ShowTextboxOnly = false;
            this.itxt_POItemNotes.Size = new System.Drawing.Size(228, 98);
            this.itxt_POItemNotes.TabIndex = 6;
            this.itxt_POItemNotes.ValueText = "";
            // 
            // in_POItemPricePerUnit
            // 
            this.in_POItemPricePerUnit.Checked = false;
            this.in_POItemPricePerUnit.DecimalPlaces = 2;
            this.in_POItemPricePerUnit.HideUpDown = true;
            this.in_POItemPricePerUnit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_POItemPricePerUnit.LabelText = "Price / Unit";
            this.in_POItemPricePerUnit.Location = new System.Drawing.Point(38, 52);
            this.in_POItemPricePerUnit.Margin = new System.Windows.Forms.Padding(5);
            this.in_POItemPricePerUnit.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_POItemPricePerUnit.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_POItemPricePerUnit.Name = "in_POItemPricePerUnit";
            this.in_POItemPricePerUnit.ShowAllowDecimalCheckbox = false;
            this.in_POItemPricePerUnit.ShowCheckbox = false;
            this.in_POItemPricePerUnit.ShowTextboxOnly = false;
            this.in_POItemPricePerUnit.Size = new System.Drawing.Size(228, 50);
            this.in_POItemPricePerUnit.TabIndex = 1;
            this.in_POItemPricePerUnit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnCancelUpdatePOItemQty
            // 
            this.btnCancelUpdatePOItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelUpdatePOItemQty.Location = new System.Drawing.Point(164, 209);
            this.btnCancelUpdatePOItemQty.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelUpdatePOItemQty.Name = "btnCancelUpdatePOItemQty";
            this.btnCancelUpdatePOItemQty.Size = new System.Drawing.Size(81, 28);
            this.btnCancelUpdatePOItemQty.TabIndex = 3;
            this.btnCancelUpdatePOItemQty.Text = "CANCEL";
            this.btnCancelUpdatePOItemQty.UseVisualStyleBackColor = true;
            this.btnCancelUpdatePOItemQty.Click += new System.EventHandler(this.btnCancelUpdatePOItemQty_Click);
            // 
            // btnUpdatePOItem
            // 
            this.btnUpdatePOItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePOItem.Location = new System.Drawing.Point(60, 209);
            this.btnUpdatePOItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdatePOItem.Name = "btnUpdatePOItem";
            this.btnUpdatePOItem.Size = new System.Drawing.Size(96, 28);
            this.btnUpdatePOItem.TabIndex = 2;
            this.btnUpdatePOItem.Text = "UPDATE";
            this.btnUpdatePOItem.UseVisualStyleBackColor = true;
            this.btnUpdatePOItem.Click += new System.EventHandler(this.btnUpdatePOItem_Click);
            // 
            // in_POItemQty
            // 
            this.in_POItemQty.Checked = false;
            this.in_POItemQty.DecimalPlaces = 2;
            this.in_POItemQty.HideUpDown = true;
            this.in_POItemQty.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_POItemQty.LabelText = "Qty";
            this.in_POItemQty.Location = new System.Drawing.Point(38, 4);
            this.in_POItemQty.Margin = new System.Windows.Forms.Padding(5);
            this.in_POItemQty.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_POItemQty.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_POItemQty.Name = "in_POItemQty";
            this.in_POItemQty.ShowAllowDecimalCheckbox = false;
            this.in_POItemQty.ShowCheckbox = false;
            this.in_POItemQty.ShowTextboxOnly = false;
            this.in_POItemQty.Size = new System.Drawing.Size(228, 48);
            this.in_POItemQty.TabIndex = 0;
            this.in_POItemQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1155, 553);
            this.Controls.Add(this.gridPOItems);
            this.Controls.Add(this.scMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.Text = "PURCHASE ORDERS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPO)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPOItems)).EndInit();
            this.pnlUpdatePOItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVendors;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnAddPO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPackingListNo;
        private System.Windows.Forms.DataGridView gridPO;
        private System.Windows.Forms.ComboBox cbProductStoreNames;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.DataGridView gridPOItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_po_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_vendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_vendor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPO_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_po_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_productDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_unitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_receivedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_pricePerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridPOItems_statusEnumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_SaleOrderItemDescription;
        private System.Windows.Forms.Panel pnlUpdatePOItem;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_POItemNotes;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_POItemPricePerUnit;
        public System.Windows.Forms.Button btnCancelUpdatePOItemQty;
        public System.Windows.Forms.Button btnUpdatePOItem;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_POItemQty;
    }
}