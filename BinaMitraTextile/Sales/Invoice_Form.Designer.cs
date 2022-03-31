namespace BinaMitraTextile.Sales
{
    partial class Invoice_Form
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_inventory_color_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griditems_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griditems_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPrint = new System.Windows.Forms.Panel();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblTotalCounts = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.lblShippingCost = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.btnPackingList = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAddNotes = new System.Windows.Forms.Button();
            this.chkHidePrices = new System.Windows.Forms.CheckBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.pnlSubmit1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCash4 = new System.Windows.Forms.RadioButton();
            this.rbCash1 = new System.Windows.Forms.RadioButton();
            this.rbCash2 = new System.Windows.Forms.RadioButton();
            this.rbCash3 = new System.Windows.Forms.RadioButton();
            this.rbTransferHutang = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.chkPrintAllPages = new System.Windows.Forms.CheckBox();
            this.pnlSubmit2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPrintButtons = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlPrint.SuspendLayout();
            this.pnlSubmit1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSubmit2.SuspendLayout();
            this.pnlPrintButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(236, 4);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(107, 34);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Grade,
            this.col_grid_inventory_color_name,
            this.qty,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.col_griditems_price,
            this.col_griditems_subtotal});
            this.grid.Location = new System.Drawing.Point(8, 100);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(949, 433);
            this.grid.TabIndex = 109;
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewLinkColumn2.DataPropertyName = "inventory_code";
            this.dataGridViewLinkColumn2.HeaderText = "Code";
            this.dataGridViewLinkColumn2.MinimumWidth = 30;
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "product_store_name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Product";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "product_width_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Lebar (cm)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // Grade
            // 
            this.Grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Grade.DataPropertyName = "grade_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grade.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grade.HeaderText = "Grade";
            this.Grade.MinimumWidth = 50;
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.Width = 50;
            // 
            // col_grid_inventory_color_name
            // 
            this.col_grid_inventory_color_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_inventory_color_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_inventory_color_name.HeaderText = "Warna";
            this.col_grid_inventory_color_name.MinimumWidth = 50;
            this.col_grid_inventory_color_name.Name = "col_grid_inventory_color_name";
            this.col_grid_inventory_color_name.ReadOnly = true;
            this.col_grid_inventory_color_name.Width = 50;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.qty.DataPropertyName = "qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qty.DefaultCellStyle = dataGridViewCellStyle5;
            this.qty.HeaderText = "Pcs";
            this.qty.MinimumWidth = 30;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "item_length";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "length_unit_name";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 30;
            // 
            // col_griditems_price
            // 
            this.col_griditems_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.col_griditems_price.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_griditems_price.HeaderText = "Harga";
            this.col_griditems_price.MinimumWidth = 50;
            this.col_griditems_price.Name = "col_griditems_price";
            this.col_griditems_price.ReadOnly = true;
            this.col_griditems_price.Width = 64;
            // 
            // col_griditems_subtotal
            // 
            this.col_griditems_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griditems_subtotal.DataPropertyName = "subtotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.col_griditems_subtotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_griditems_subtotal.HeaderText = "Subtotal";
            this.col_griditems_subtotal.MinimumWidth = 50;
            this.col_griditems_subtotal.Name = "col_griditems_subtotal";
            this.col_griditems_subtotal.ReadOnly = true;
            this.col_griditems_subtotal.Width = 50;
            // 
            // pnlPrint
            // 
            this.pnlPrint.Controls.Add(this.lblPageCount);
            this.pnlPrint.Controls.Add(this.lblTotalCounts);
            this.pnlPrint.Controls.Add(this.txtNotes);
            this.pnlPrint.Controls.Add(this.lblDisclaimer);
            this.pnlPrint.Controls.Add(this.lblShippingCost);
            this.pnlPrint.Controls.Add(this.lblGrandTotal);
            this.pnlPrint.Controls.Add(this.lblInvoiceNo);
            this.pnlPrint.Controls.Add(this.lblTitle);
            this.pnlPrint.Controls.Add(this.label8);
            this.pnlPrint.Controls.Add(this.lblDate);
            this.pnlPrint.Controls.Add(this.label1);
            this.pnlPrint.Controls.Add(this.lblCustomerInfo);
            this.pnlPrint.Controls.Add(this.label2);
            this.pnlPrint.Controls.Add(this.grid);
            this.pnlPrint.Controls.Add(this.lblTotalSale);
            this.pnlPrint.Controls.Add(this.lblPayment);
            this.pnlPrint.Location = new System.Drawing.Point(7, 4);
            this.pnlPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(964, 624);
            this.pnlPrint.TabIndex = 110;
            // 
            // lblPageCount
            // 
            this.lblPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.Location = new System.Drawing.Point(552, 559);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(104, 17);
            this.lblPageCount.TabIndex = 156;
            this.lblPageCount.Text = "lblPageCount";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.AutoSize = true;
            this.lblTotalCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounts.Location = new System.Drawing.Point(552, 535);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(130, 20);
            this.lblTotalCounts.TabIndex = 114;
            this.lblTotalCounts.Text = "lblTotalCounts";
            this.lblTotalCounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.Enabled = false;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(61, 535);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(483, 68);
            this.txtNotes.TabIndex = 131;
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisclaimer.Location = new System.Drawing.Point(4, 604);
            this.lblDisclaimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(541, 21);
            this.lblDisclaimer.TabIndex = 161;
            this.lblDisclaimer.Text = "*Tidak terima retur grade B. Tidak terima retur grade A cacat bila sudah dipotong" +
    ".";
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblShippingCost.Location = new System.Drawing.Point(697, 556);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new System.Drawing.Size(263, 18);
            this.lblShippingCost.TabIndex = 159;
            this.lblShippingCost.Text = "lblShippingCost";
            this.lblShippingCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGrandTotal.Location = new System.Drawing.Point(705, 575);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(255, 30);
            this.lblGrandTotal.TabIndex = 158;
            this.lblGrandTotal.Text = "lblGrandTotal";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(9, 27);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(111, 20);
            this.lblInvoiceNo.TabIndex = 132;
            this.lblInvoiceNo.Text = "lblInvoiceNo";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(9, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 20);
            this.lblTitle.TabIndex = 130;
            this.lblTitle.Text = "INVOICE";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(643, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(315, 70);
            this.label8.TabIndex = 129;
            this.label8.Text = "Jl. Mayor Sunarya Blok K No. 11A\r\nBandung, Jawa Barat\r\nsimpati/whatsapp: 081.2240" +
    ".44338\r\nbina.mitra.textile@gmail.com";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(50, 16);
            this.lblDate.TabIndex = 127;
            this.lblDate.Text = "lblDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 117;
            this.label1.Text = "Notes:";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(188, 6);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(414, 91);
            this.lblCustomerInfo.TabIndex = 120;
            this.lblCustomerInfo.Text = "lblCustomerInfo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(661, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 25);
            this.label2.TabIndex = 119;
            this.label2.Text = "CV. BINA MITRA TEXTILE";
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSale.Location = new System.Drawing.Point(701, 538);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.Size = new System.Drawing.Size(259, 18);
            this.lblTotalSale.TabIndex = 115;
            this.lblTotalSale.Text = "lblTotalSale";
            this.lblTotalSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayment
            // 
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPayment.Location = new System.Drawing.Point(632, 602);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(328, 18);
            this.lblPayment.TabIndex = 160;
            this.lblPayment.Text = "lblPayment";
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayment.Visible = false;
            // 
            // btnPackingList
            // 
            this.btnPackingList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackingList.Location = new System.Drawing.Point(139, 39);
            this.btnPackingList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPackingList.Name = "btnPackingList";
            this.btnPackingList.Size = new System.Drawing.Size(176, 34);
            this.btnPackingList.TabIndex = 5;
            this.btnPackingList.Text = "PACKING LIST";
            this.btnPackingList.UseVisualStyleBackColor = true;
            this.btnPackingList.Click += new System.EventHandler(this.btnPackingList_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(280, 2);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 34);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(139, 2);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(35, 34);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(179, 2);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 34);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotes.Location = new System.Drawing.Point(7, 673);
            this.btnAddNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Size = new System.Drawing.Size(148, 34);
            this.btnAddNotes.TabIndex = 6;
            this.btnAddNotes.Text = "ADD NOTES";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // chkHidePrices
            // 
            this.chkHidePrices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHidePrices.AutoSize = true;
            this.chkHidePrices.Location = new System.Drawing.Point(15, 4);
            this.chkHidePrices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHidePrices.Name = "chkHidePrices";
            this.chkHidePrices.Size = new System.Drawing.Size(125, 20);
            this.chkHidePrices.TabIndex = 3;
            this.chkHidePrices.Text = "hilangkan harga";
            this.chkHidePrices.UseVisualStyleBackColor = true;
            this.chkHidePrices.CheckedChanged += new System.EventHandler(this.chkHidePrices_CheckedChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(160, 673);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(141, 34);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "PAYMENTS";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // pnlSubmit1
            // 
            this.pnlSubmit1.Controls.Add(this.panel1);
            this.pnlSubmit1.Controls.Add(this.rbTransferHutang);
            this.pnlSubmit1.Controls.Add(this.rbCash);
            this.pnlSubmit1.Location = new System.Drawing.Point(7, 634);
            this.pnlSubmit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSubmit1.Name = "pnlSubmit1";
            this.pnlSubmit1.Size = new System.Drawing.Size(648, 34);
            this.pnlSubmit1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCash4);
            this.panel1.Controls.Add(this.rbCash1);
            this.panel1.Controls.Add(this.rbCash2);
            this.panel1.Controls.Add(this.rbCash3);
            this.panel1.Location = new System.Drawing.Point(184, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 28);
            this.panel1.TabIndex = 162;
            // 
            // rbCash4
            // 
            this.rbCash4.AutoSize = true;
            this.rbCash4.Location = new System.Drawing.Point(348, 4);
            this.rbCash4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCash4.Name = "rbCash4";
            this.rbCash4.Size = new System.Drawing.Size(78, 20);
            this.rbCash4.TabIndex = 1004;
            this.rbCash4.Text = "rbCash4";
            this.rbCash4.UseVisualStyleBackColor = true;
            this.rbCash4.CheckedChanged += new System.EventHandler(this.rbCashAmount_CheckedChanged);
            // 
            // rbCash1
            // 
            this.rbCash1.AutoSize = true;
            this.rbCash1.Location = new System.Drawing.Point(4, 4);
            this.rbCash1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCash1.Name = "rbCash1";
            this.rbCash1.Size = new System.Drawing.Size(78, 20);
            this.rbCash1.TabIndex = 999;
            this.rbCash1.Text = "rbCash1";
            this.rbCash1.UseVisualStyleBackColor = true;
            this.rbCash1.CheckedChanged += new System.EventHandler(this.rbCashAmount_CheckedChanged);
            // 
            // rbCash2
            // 
            this.rbCash2.AutoSize = true;
            this.rbCash2.Location = new System.Drawing.Point(119, 4);
            this.rbCash2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCash2.Name = "rbCash2";
            this.rbCash2.Size = new System.Drawing.Size(78, 20);
            this.rbCash2.TabIndex = 999;
            this.rbCash2.Text = "rbCash2";
            this.rbCash2.UseVisualStyleBackColor = true;
            this.rbCash2.CheckedChanged += new System.EventHandler(this.rbCashAmount_CheckedChanged);
            // 
            // rbCash3
            // 
            this.rbCash3.AutoSize = true;
            this.rbCash3.Location = new System.Drawing.Point(233, 4);
            this.rbCash3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCash3.Name = "rbCash3";
            this.rbCash3.Size = new System.Drawing.Size(78, 20);
            this.rbCash3.TabIndex = 999;
            this.rbCash3.Text = "rbCash3";
            this.rbCash3.UseVisualStyleBackColor = true;
            this.rbCash3.CheckedChanged += new System.EventHandler(this.rbCashAmount_CheckedChanged);
            // 
            // rbTransferHutang
            // 
            this.rbTransferHutang.AutoSize = true;
            this.rbTransferHutang.Location = new System.Drawing.Point(64, 7);
            this.rbTransferHutang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTransferHutang.Name = "rbTransferHutang";
            this.rbTransferHutang.Size = new System.Drawing.Size(98, 20);
            this.rbTransferHutang.TabIndex = 1000;
            this.rbTransferHutang.Text = "TF / Hutang";
            this.rbTransferHutang.UseVisualStyleBackColor = true;
            this.rbTransferHutang.CheckedChanged += new System.EventHandler(this.rbTransferHutang_CheckedChanged);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(1, 7);
            this.rbCash.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(59, 20);
            this.rbCash.TabIndex = 1003;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentAmount.Location = new System.Drawing.Point(67, 5);
            this.txtPaymentAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(161, 30);
            this.txtPaymentAmount.TabIndex = 2;
            this.txtPaymentAmount.Click += new System.EventHandler(this.txtPaymentAmount_Click);
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.txtPaymentAmount_TextChanged);
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowPrintDialog.AutoSize = true;
            this.chkShowPrintDialog.Location = new System.Drawing.Point(15, 26);
            this.chkShowPrintDialog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(95, 20);
            this.chkShowPrintDialog.TabIndex = 111;
            this.chkShowPrintDialog.Text = "print dialog";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // chkPrintAllPages
            // 
            this.chkPrintAllPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintAllPages.AutoSize = true;
            this.chkPrintAllPages.Checked = true;
            this.chkPrintAllPages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintAllPages.Location = new System.Drawing.Point(15, 48);
            this.chkPrintAllPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPrintAllPages.Name = "chkPrintAllPages";
            this.chkPrintAllPages.Size = new System.Drawing.Size(71, 20);
            this.chkPrintAllPages.TabIndex = 151;
            this.chkPrintAllPages.Text = "print all";
            this.chkPrintAllPages.UseVisualStyleBackColor = true;
            // 
            // pnlSubmit2
            // 
            this.pnlSubmit2.Controls.Add(this.label3);
            this.pnlSubmit2.Controls.Add(this.txtPaymentAmount);
            this.pnlSubmit2.Controls.Add(this.btnSubmit);
            this.pnlSubmit2.Location = new System.Drawing.Point(308, 670);
            this.pnlSubmit2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSubmit2.Name = "pnlSubmit2";
            this.pnlSubmit2.Size = new System.Drawing.Size(347, 42);
            this.pnlSubmit2.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "PAY";
            // 
            // pnlPrintButtons
            // 
            this.pnlPrintButtons.Controls.Add(this.btnPrevious);
            this.pnlPrintButtons.Controls.Add(this.btnNext);
            this.pnlPrintButtons.Controls.Add(this.chkPrintAllPages);
            this.pnlPrintButtons.Controls.Add(this.chkHidePrices);
            this.pnlPrintButtons.Controls.Add(this.chkShowPrintDialog);
            this.pnlPrintButtons.Controls.Add(this.btnPrint);
            this.pnlPrintButtons.Controls.Add(this.btnPackingList);
            this.pnlPrintButtons.Location = new System.Drawing.Point(653, 634);
            this.pnlPrintButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPrintButtons.Name = "pnlPrintButtons";
            this.pnlPrintButtons.Size = new System.Drawing.Size(317, 78);
            this.pnlPrintButtons.TabIndex = 162;
            // 
            // Invoice_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(979, 720);
            this.Controls.Add(this.pnlPrintButtons);
            this.Controls.Add(this.pnlSubmit2);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnAddNotes);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.pnlSubmit1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Invoice_Form";
            this.Text = "VERIFY SALES";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            this.pnlSubmit1.ResumeLayout(false);
            this.pnlSubmit1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSubmit2.ResumeLayout(false);
            this.pnlSubmit2.PerformLayout();
            this.pnlPrintButtons.ResumeLayout(false);
            this.pnlPrintButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCounts;
        private System.Windows.Forms.Label lblTotalSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPackingList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkHidePrices;
        private System.Windows.Forms.Label lblShippingCost;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Panel pnlSubmit1;
        private System.Windows.Forms.TextBox txtPaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_inventory_color_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griditems_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griditems_subtotal;
        private System.Windows.Forms.CheckBox chkShowPrintDialog;
        private System.Windows.Forms.CheckBox chkPrintAllPages;
        private System.Windows.Forms.RadioButton rbCash2;
        private System.Windows.Forms.RadioButton rbCash1;
        private System.Windows.Forms.RadioButton rbCash3;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.RadioButton rbTransferHutang;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Label lblDisclaimer;
        private System.Windows.Forms.RadioButton rbCash4;
        private System.Windows.Forms.Panel pnlSubmit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlPrintButtons;
        private System.Windows.Forms.Panel panel1;
    }
}