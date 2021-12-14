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
            this.btnEdit = new System.Windows.Forms.Button();
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.lblShippingCost = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalCounts = new System.Windows.Forms.Label();
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
            this.iddl_MoneyAccountCategories = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.rbHutang = new System.Windows.Forms.RadioButton();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.iddl_PaymentMethods = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.txtPaymentAmount = new System.Windows.Forms.TextBox();
            this.rbCash4 = new System.Windows.Forms.RadioButton();
            this.rbCash3 = new System.Windows.Forms.RadioButton();
            this.rbCash2 = new System.Windows.Forms.RadioButton();
            this.rbCash1 = new System.Windows.Forms.RadioButton();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.chkPrintAllPages = new System.Windows.Forms.CheckBox();
            this.pnlSubmit2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlPrint.SuspendLayout();
            this.pnlSubmit1.SuspendLayout();
            this.pnlSubmit2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(5, 548);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 28);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(404, 0);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 28);
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
            this.grid.Location = new System.Drawing.Point(6, 81);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(712, 352);
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
            this.col_griditems_price.Width = 51;
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
            this.pnlPrint.Controls.Add(this.txtNotes);
            this.pnlPrint.Controls.Add(this.lblDisclaimer);
            this.pnlPrint.Controls.Add(this.lblShippingCost);
            this.pnlPrint.Controls.Add(this.lblGrandTotal);
            this.pnlPrint.Controls.Add(this.lblPageCount);
            this.pnlPrint.Controls.Add(this.lblInvoiceNo);
            this.pnlPrint.Controls.Add(this.lblTitle);
            this.pnlPrint.Controls.Add(this.label8);
            this.pnlPrint.Controls.Add(this.lblDate);
            this.pnlPrint.Controls.Add(this.label1);
            this.pnlPrint.Controls.Add(this.lblCustomerInfo);
            this.pnlPrint.Controls.Add(this.label2);
            this.pnlPrint.Controls.Add(this.grid);
            this.pnlPrint.Controls.Add(this.lblTotalCounts);
            this.pnlPrint.Controls.Add(this.lblTotalSale);
            this.pnlPrint.Controls.Add(this.lblPayment);
            this.pnlPrint.Location = new System.Drawing.Point(5, 3);
            this.pnlPrint.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(723, 507);
            this.pnlPrint.TabIndex = 110;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.Enabled = false;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(46, 435);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(363, 56);
            this.txtNotes.TabIndex = 131;
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisclaimer.Location = new System.Drawing.Point(3, 491);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(406, 17);
            this.lblDisclaimer.TabIndex = 161;
            this.lblDisclaimer.Text = "*Tidak terima retur grade B. Tidak terima retur grade A cacat bila sudah dipotong" +
    ".";
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblShippingCost.Location = new System.Drawing.Point(523, 452);
            this.lblShippingCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new System.Drawing.Size(197, 15);
            this.lblShippingCost.TabIndex = 159;
            this.lblShippingCost.Text = "lblShippingCost";
            this.lblShippingCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGrandTotal.Location = new System.Drawing.Point(529, 467);
            this.lblGrandTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(191, 24);
            this.lblGrandTotal.TabIndex = 158;
            this.lblGrandTotal.Text = "lblGrandTotal";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPageCount
            // 
            this.lblPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.Location = new System.Drawing.Point(414, 454);
            this.lblPageCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(82, 13);
            this.lblPageCount.TabIndex = 156;
            this.lblPageCount.Text = "lblPageCount";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(7, 22);
            this.lblInvoiceNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(95, 16);
            this.lblInvoiceNo.TabIndex = 132;
            this.lblInvoiceNo.Text = "lblInvoiceNo";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(68, 16);
            this.lblTitle.TabIndex = 130;
            this.lblTitle.Text = "INVOICE";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(482, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 57);
            this.label8.TabIndex = 129;
            this.label8.Text = "Jl. Mayor Sunarya Blok K No. 11A\r\nBandung, Jawa Barat\r\nsimpati/whatsapp: 081.2240" +
    ".44338\r\nbina.mitra.textile@gmail.com";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 66);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 127;
            this.lblDate.Text = "lblDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 437);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Notes:";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(141, 5);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(311, 74);
            this.lblCustomerInfo.TabIndex = 120;
            this.lblCustomerInfo.Text = "lblCustomerInfo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(496, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "CV. BINA MITRA TEXTILE";
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.AutoSize = true;
            this.lblTotalCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounts.Location = new System.Drawing.Point(414, 435);
            this.lblTotalCounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(108, 16);
            this.lblTotalCounts.TabIndex = 114;
            this.lblTotalCounts.Text = "lblTotalCounts";
            this.lblTotalCounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSale.Location = new System.Drawing.Point(526, 437);
            this.lblTotalSale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.Size = new System.Drawing.Size(194, 15);
            this.lblTotalSale.TabIndex = 115;
            this.lblTotalSale.Text = "lblTotalSale";
            this.lblTotalSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayment
            // 
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPayment.Location = new System.Drawing.Point(474, 489);
            this.lblPayment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(246, 15);
            this.lblPayment.TabIndex = 160;
            this.lblPayment.Text = "lblPayment";
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPayment.Visible = false;
            // 
            // btnPackingList
            // 
            this.btnPackingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPackingList.Location = new System.Drawing.Point(596, 547);
            this.btnPackingList.Margin = new System.Windows.Forms.Padding(2);
            this.btnPackingList.Name = "btnPackingList";
            this.btnPackingList.Size = new System.Drawing.Size(132, 28);
            this.btnPackingList.TabIndex = 5;
            this.btnPackingList.Text = "PACKING LIST";
            this.btnPackingList.UseVisualStyleBackColor = true;
            this.btnPackingList.Click += new System.EventHandler(this.btnPackingList_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(702, 514);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 28);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(596, 514);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(26, 28);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(626, 514);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotes.Location = new System.Drawing.Point(72, 548);
            this.btnAddNotes.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Size = new System.Drawing.Size(111, 28);
            this.btnAddNotes.TabIndex = 6;
            this.btnAddNotes.Text = "ADD NOTES";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // chkHidePrices
            // 
            this.chkHidePrices.AutoSize = true;
            this.chkHidePrices.Location = new System.Drawing.Point(493, 515);
            this.chkHidePrices.Name = "chkHidePrices";
            this.chkHidePrices.Size = new System.Drawing.Size(102, 17);
            this.chkHidePrices.TabIndex = 3;
            this.chkHidePrices.Text = "hilangkan harga";
            this.chkHidePrices.UseVisualStyleBackColor = true;
            this.chkHidePrices.CheckedChanged += new System.EventHandler(this.chkHidePrices_CheckedChanged);
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(187, 548);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(106, 28);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "PAYMENTS";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // pnlSubmit1
            // 
            this.pnlSubmit1.Controls.Add(this.iddl_MoneyAccountCategories);
            this.pnlSubmit1.Controls.Add(this.rbHutang);
            this.pnlSubmit1.Controls.Add(this.rbTransfer);
            this.pnlSubmit1.Controls.Add(this.rbCash);
            this.pnlSubmit1.Controls.Add(this.iddl_PaymentMethods);
            this.pnlSubmit1.Controls.Add(this.txtPaymentAmount);
            this.pnlSubmit1.Controls.Add(this.btnSubmit);
            this.pnlSubmit1.Location = new System.Drawing.Point(5, 515);
            this.pnlSubmit1.Name = "pnlSubmit1";
            this.pnlSubmit1.Size = new System.Drawing.Size(486, 28);
            this.pnlSubmit1.TabIndex = 2;
            // 
            // iddl_MoneyAccountCategories
            // 
            this.iddl_MoneyAccountCategories.DisableTextInput = false;
            this.iddl_MoneyAccountCategories.HideFilter = true;
            this.iddl_MoneyAccountCategories.HideUpdateLink = false;
            this.iddl_MoneyAccountCategories.LabelText = "dropdownlist";
            this.iddl_MoneyAccountCategories.Location = new System.Drawing.Point(141, 4);
            this.iddl_MoneyAccountCategories.Name = "iddl_MoneyAccountCategories";
            this.iddl_MoneyAccountCategories.SelectedIndex = -1;
            this.iddl_MoneyAccountCategories.SelectedItem = null;
            this.iddl_MoneyAccountCategories.SelectedItemText = "";
            this.iddl_MoneyAccountCategories.SelectedValue = null;
            this.iddl_MoneyAccountCategories.ShowDropdownlistOnly = true;
            this.iddl_MoneyAccountCategories.Size = new System.Drawing.Size(131, 22);
            this.iddl_MoneyAccountCategories.TabIndex = 1002;
            // 
            // rbHutang
            // 
            this.rbHutang.AutoSize = true;
            this.rbHutang.Location = new System.Drawing.Point(88, 6);
            this.rbHutang.Name = "rbHutang";
            this.rbHutang.Size = new System.Drawing.Size(47, 17);
            this.rbHutang.TabIndex = 1001;
            this.rbHutang.Text = "Owe";
            this.rbHutang.UseVisualStyleBackColor = true;
            this.rbHutang.CheckedChanged += new System.EventHandler(this.rbHutang_CheckedChanged);
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.Location = new System.Drawing.Point(50, 6);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(38, 17);
            this.rbTransfer.TabIndex = 1000;
            this.rbTransfer.Text = "TF";
            this.rbTransfer.UseVisualStyleBackColor = true;
            this.rbTransfer.CheckedChanged += new System.EventHandler(this.rbTransfer_CheckedChanged);
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(1, 6);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(49, 17);
            this.rbCash.TabIndex = 1003;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // iddl_PaymentMethods
            // 
            this.iddl_PaymentMethods.DisableTextInput = false;
            this.iddl_PaymentMethods.HideFilter = true;
            this.iddl_PaymentMethods.HideUpdateLink = false;
            this.iddl_PaymentMethods.LabelText = "dropdownlist";
            this.iddl_PaymentMethods.Location = new System.Drawing.Point(274, 4);
            this.iddl_PaymentMethods.Name = "iddl_PaymentMethods";
            this.iddl_PaymentMethods.SelectedIndex = -1;
            this.iddl_PaymentMethods.SelectedItem = null;
            this.iddl_PaymentMethods.SelectedItemText = "";
            this.iddl_PaymentMethods.SelectedValue = null;
            this.iddl_PaymentMethods.ShowDropdownlistOnly = true;
            this.iddl_PaymentMethods.Size = new System.Drawing.Size(61, 22);
            this.iddl_PaymentMethods.TabIndex = 161;
            // 
            // txtPaymentAmount
            // 
            this.txtPaymentAmount.Location = new System.Drawing.Point(337, 5);
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.Size = new System.Drawing.Size(66, 20);
            this.txtPaymentAmount.TabIndex = 2;
            this.txtPaymentAmount.Click += new System.EventHandler(this.txtPaymentAmount_Click);
            this.txtPaymentAmount.TextChanged += new System.EventHandler(this.txtPaymentAmount_TextChanged);
            // 
            // rbCash4
            // 
            this.rbCash4.AutoSize = true;
            this.rbCash4.Location = new System.Drawing.Point(91, 20);
            this.rbCash4.Name = "rbCash4";
            this.rbCash4.Size = new System.Drawing.Size(64, 17);
            this.rbCash4.TabIndex = 999;
            this.rbCash4.Text = "rbCash4";
            this.rbCash4.UseVisualStyleBackColor = true;
            this.rbCash4.CheckedChanged += new System.EventHandler(this.rbCash4_CheckedChanged);
            // 
            // rbCash3
            // 
            this.rbCash3.AutoSize = true;
            this.rbCash3.Location = new System.Drawing.Point(91, 3);
            this.rbCash3.Name = "rbCash3";
            this.rbCash3.Size = new System.Drawing.Size(64, 17);
            this.rbCash3.TabIndex = 999;
            this.rbCash3.Text = "rbCash3";
            this.rbCash3.UseVisualStyleBackColor = true;
            this.rbCash3.CheckedChanged += new System.EventHandler(this.rbCash3_CheckedChanged);
            // 
            // rbCash2
            // 
            this.rbCash2.AutoSize = true;
            this.rbCash2.Location = new System.Drawing.Point(3, 20);
            this.rbCash2.Name = "rbCash2";
            this.rbCash2.Size = new System.Drawing.Size(64, 17);
            this.rbCash2.TabIndex = 999;
            this.rbCash2.Text = "rbCash2";
            this.rbCash2.UseVisualStyleBackColor = true;
            this.rbCash2.CheckedChanged += new System.EventHandler(this.rbCash2_CheckedChanged);
            // 
            // rbCash1
            // 
            this.rbCash1.AutoSize = true;
            this.rbCash1.Location = new System.Drawing.Point(3, 3);
            this.rbCash1.Name = "rbCash1";
            this.rbCash1.Size = new System.Drawing.Size(64, 17);
            this.rbCash1.TabIndex = 999;
            this.rbCash1.Text = "rbCash1";
            this.rbCash1.UseVisualStyleBackColor = true;
            this.rbCash1.CheckedChanged += new System.EventHandler(this.rbCash1_CheckedChanged);
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.AutoSize = true;
            this.chkShowPrintDialog.Location = new System.Drawing.Point(493, 531);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(77, 17);
            this.chkShowPrintDialog.TabIndex = 111;
            this.chkShowPrintDialog.Text = "print dialog";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // chkPrintAllPages
            // 
            this.chkPrintAllPages.AutoSize = true;
            this.chkPrintAllPages.Checked = true;
            this.chkPrintAllPages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintAllPages.Location = new System.Drawing.Point(493, 547);
            this.chkPrintAllPages.Name = "chkPrintAllPages";
            this.chkPrintAllPages.Size = new System.Drawing.Size(59, 17);
            this.chkPrintAllPages.TabIndex = 151;
            this.chkPrintAllPages.Text = "print all";
            this.chkPrintAllPages.UseVisualStyleBackColor = true;
            // 
            // pnlSubmit2
            // 
            this.pnlSubmit2.Controls.Add(this.rbCash4);
            this.pnlSubmit2.Controls.Add(this.rbCash3);
            this.pnlSubmit2.Controls.Add(this.rbCash1);
            this.pnlSubmit2.Controls.Add(this.rbCash2);
            this.pnlSubmit2.Location = new System.Drawing.Point(298, 546);
            this.pnlSubmit2.Name = "pnlSubmit2";
            this.pnlSubmit2.Size = new System.Drawing.Size(189, 42);
            this.pnlSubmit2.TabIndex = 161;
            // 
            // Invoice_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 585);
            this.Controls.Add(this.pnlSubmit2);
            this.Controls.Add(this.chkPrintAllPages);
            this.Controls.Add(this.chkShowPrintDialog);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnAddNotes);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.chkHidePrices);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPackingList);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.pnlSubmit1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Invoice_Form";
            this.Text = "VERIFY SALES";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            this.pnlSubmit1.ResumeLayout(false);
            this.pnlSubmit1.PerformLayout();
            this.pnlSubmit2.ResumeLayout(false);
            this.pnlSubmit2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
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
        private System.Windows.Forms.RadioButton rbCash4;
        private System.Windows.Forms.RadioButton rbCash3;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Panel pnlSubmit2;
        private System.Windows.Forms.RadioButton rbTransfer;
        private System.Windows.Forms.RadioButton rbHutang;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategories;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_PaymentMethods;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Label lblDisclaimer;
    }
}