namespace BinaMitraTextile.CustomerCredits
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.col_gridsummary_customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOnlyHasActivityLast3Months = new System.Windows.Forms.CheckBox();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.iddl_PaymentMethods = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.col_griddetail_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_Confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_griddetail_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_saleBarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_griddetail_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_saleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSummary
            // 
            this.gridSummary.AllowUserToAddRows = false;
            this.gridSummary.AllowUserToDeleteRows = false;
            this.gridSummary.AllowUserToResizeRows = false;
            this.gridSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridSummary.BackgroundColor = System.Drawing.Color.White;
            this.gridSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridsummary_customerid,
            this.col_gridsummary_customername,
            this.col_gridsummary_balance});
            this.gridSummary.Location = new System.Drawing.Point(7, 25);
            this.gridSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSummary.MultiSelect = false;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridSummary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSummary.RowTemplate.Height = 24;
            this.gridSummary.Size = new System.Drawing.Size(246, 588);
            this.gridSummary.TabIndex = 120;
            this.gridSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSummary_CellClick);
            // 
            // col_gridsummary_customerid
            // 
            this.col_gridsummary_customerid.HeaderText = "customer id";
            this.col_gridsummary_customerid.Name = "col_gridsummary_customerid";
            this.col_gridsummary_customerid.ReadOnly = true;
            this.col_gridsummary_customerid.Visible = false;
            // 
            // col_gridsummary_customername
            // 
            this.col_gridsummary_customername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridsummary_customername.DataPropertyName = "notes";
            this.col_gridsummary_customername.HeaderText = "Customer";
            this.col_gridsummary_customername.Name = "col_gridsummary_customername";
            this.col_gridsummary_customername.ReadOnly = true;
            // 
            // col_gridsummary_balance
            // 
            this.col_gridsummary_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_gridsummary_balance.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridsummary_balance.HeaderText = "Balance";
            this.col_gridsummary_balance.Name = "col_gridsummary_balance";
            this.col_gridsummary_balance.ReadOnly = true;
            this.col_gridsummary_balance.Width = 63;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.Location = new System.Drawing.Point(900, 8);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(78, 43);
            this.btnAddPayment.TabIndex = 5;
            this.btnAddPayment.Text = "ADD";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(33, 4);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilter.MaxLength = 500;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(65, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Filter";
            // 
            // chkOnlyHasActivityLast3Months
            // 
            this.chkOnlyHasActivityLast3Months.AutoSize = true;
            this.chkOnlyHasActivityLast3Months.Checked = true;
            this.chkOnlyHasActivityLast3Months.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyHasActivityLast3Months.Location = new System.Drawing.Point(105, 6);
            this.chkOnlyHasActivityLast3Months.Margin = new System.Windows.Forms.Padding(4);
            this.chkOnlyHasActivityLast3Months.Name = "chkOnlyHasActivityLast3Months";
            this.chkOnlyHasActivityLast3Months.Size = new System.Drawing.Size(118, 17);
            this.chkOnlyHasActivityLast3Months.TabIndex = 134;
            this.chkOnlyHasActivityLast3Months.Text = "Activity in 3 Months";
            this.chkOnlyHasActivityLast3Months.UseVisualStyleBackColor = true;
            this.chkOnlyHasActivityLast3Months.CheckedChanged += new System.EventHandler(this.chkOnlyHasActivityLast3Months_CheckedChanged);
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = true;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(259, 1);
            this.iddl_Customers.Margin = new System.Windows.Forms.Padding(5);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(131, 50);
            this.iddl_Customers.TabIndex = 135;
            // 
            // in_Amount
            // 
            this.in_Amount.Checked = false;
            this.in_Amount.DecimalPlaces = 2;
            this.in_Amount.HideUpDown = false;
            this.in_Amount.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_Amount.LabelText = "Amount";
            this.in_Amount.Location = new System.Drawing.Point(400, 1);
            this.in_Amount.Margin = new System.Windows.Forms.Padding(5);
            this.in_Amount.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_Amount.MinimumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.in_Amount.Name = "in_Amount";
            this.in_Amount.ShowAllowDecimalCheckbox = false;
            this.in_Amount.ShowCheckbox = false;
            this.in_Amount.ShowTextboxOnly = false;
            this.in_Amount.Size = new System.Drawing.Size(148, 50);
            this.in_Amount.TabIndex = 136;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // iddl_PaymentMethods
            // 
            this.iddl_PaymentMethods.DisableTextInput = false;
            this.iddl_PaymentMethods.HideFilter = true;
            this.iddl_PaymentMethods.HideUpdateLink = true;
            this.iddl_PaymentMethods.LabelText = "Method";
            this.iddl_PaymentMethods.Location = new System.Drawing.Point(556, 1);
            this.iddl_PaymentMethods.Margin = new System.Windows.Forms.Padding(5);
            this.iddl_PaymentMethods.Name = "iddl_PaymentMethods";
            this.iddl_PaymentMethods.SelectedIndex = -1;
            this.iddl_PaymentMethods.SelectedItem = null;
            this.iddl_PaymentMethods.SelectedItemText = "";
            this.iddl_PaymentMethods.SelectedValue = null;
            this.iddl_PaymentMethods.ShowDropdownlistOnly = false;
            this.iddl_PaymentMethods.Size = new System.Drawing.Size(99, 50);
            this.iddl_PaymentMethods.TabIndex = 137;
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(664, 1);
            this.itxt_Notes.Margin = new System.Windows.Forms.Padding(4);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = false;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 1;
            this.itxt_Notes.ShowDeleteButton = true;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(228, 50);
            this.itxt_Notes.TabIndex = 138;
            this.itxt_Notes.ValueText = "";
            // 
            // col_griddetail_balance
            // 
            this.col_griddetail_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_griddetail_balance.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_griddetail_balance.HeaderText = "Balance";
            this.col_griddetail_balance.MinimumWidth = 50;
            this.col_griddetail_balance.Name = "col_griddetail_balance";
            this.col_griddetail_balance.ReadOnly = true;
            this.col_griddetail_balance.Width = 50;
            // 
            // col_griddetail_Confirmed
            // 
            this.col_griddetail_Confirmed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_Confirmed.HeaderText = "OK";
            this.col_griddetail_Confirmed.MinimumWidth = 30;
            this.col_griddetail_Confirmed.Name = "col_griddetail_Confirmed";
            this.col_griddetail_Confirmed.ReadOnly = true;
            this.col_griddetail_Confirmed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_griddetail_Confirmed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_griddetail_Confirmed.Width = 30;
            // 
            // col_griddetail_amount
            // 
            this.col_griddetail_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_amount.DataPropertyName = "amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_griddetail_amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_griddetail_amount.HeaderText = "Amount";
            this.col_griddetail_amount.MinimumWidth = 50;
            this.col_griddetail_amount.Name = "col_griddetail_amount";
            this.col_griddetail_amount.ReadOnly = true;
            this.col_griddetail_amount.Width = 50;
            // 
            // col_griddetail_saleBarcode
            // 
            this.col_griddetail_saleBarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_saleBarcode.DataPropertyName = "sale_barcode";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_griddetail_saleBarcode.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_griddetail_saleBarcode.HeaderText = "Invoice";
            this.col_griddetail_saleBarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.MinimumWidth = 50;
            this.col_griddetail_saleBarcode.Name = "col_griddetail_saleBarcode";
            this.col_griddetail_saleBarcode.ReadOnly = true;
            this.col_griddetail_saleBarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.Width = 50;
            // 
            // col_griddetail_notes
            // 
            this.col_griddetail_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_griddetail_notes.DataPropertyName = "notes";
            this.col_griddetail_notes.HeaderText = "Notes";
            this.col_griddetail_notes.MinimumWidth = 50;
            this.col_griddetail_notes.Name = "col_griddetail_notes";
            this.col_griddetail_notes.ReadOnly = true;
            // 
            // col_griddetail_method
            // 
            this.col_griddetail_method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_griddetail_method.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_griddetail_method.HeaderText = "Method";
            this.col_griddetail_method.MinimumWidth = 50;
            this.col_griddetail_method.Name = "col_griddetail_method";
            this.col_griddetail_method.ReadOnly = true;
            this.col_griddetail_method.Width = 50;
            // 
            // col_griddetail_saleID
            // 
            this.col_griddetail_saleID.HeaderText = "sale_id";
            this.col_griddetail_saleID.Name = "col_griddetail_saleID";
            this.col_griddetail_saleID.ReadOnly = true;
            this.col_griddetail_saleID.Visible = false;
            // 
            // col_griddetail_timestamp
            // 
            this.col_griddetail_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_timestamp.DataPropertyName = "time_stamp";
            dataGridViewCellStyle8.Format = "dd/MM/yy HH:mm";
            this.col_griddetail_timestamp.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_griddetail_timestamp.HeaderText = "Date";
            this.col_griddetail_timestamp.MinimumWidth = 50;
            this.col_griddetail_timestamp.Name = "col_griddetail_timestamp";
            this.col_griddetail_timestamp.ReadOnly = true;
            this.col_griddetail_timestamp.Width = 50;
            // 
            // col_griddetail_Id
            // 
            this.col_griddetail_Id.HeaderText = "id";
            this.col_griddetail_Id.Name = "col_griddetail_Id";
            this.col_griddetail_Id.ReadOnly = true;
            this.col_griddetail_Id.Visible = false;
            // 
            // gridDetail
            // 
            this.gridDetail.AllowUserToAddRows = false;
            this.gridDetail.AllowUserToDeleteRows = false;
            this.gridDetail.AllowUserToResizeRows = false;
            this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetail.BackgroundColor = System.Drawing.Color.White;
            this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_griddetail_Id,
            this.col_griddetail_timestamp,
            this.col_griddetail_saleID,
            this.col_griddetail_method,
            this.col_griddetail_notes,
            this.col_griddetail_saleBarcode,
            this.col_griddetail_amount,
            this.col_griddetail_Confirmed,
            this.col_griddetail_balance});
            this.gridDetail.Location = new System.Drawing.Point(259, 57);
            this.gridDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridDetail.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetail.RowTemplate.Height = 24;
            this.gridDetail.Size = new System.Drawing.Size(719, 556);
            this.gridDetail.TabIndex = 114;
            this.gridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellContentClick);
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(982, 619);
            this.Controls.Add(this.itxt_Notes);
            this.Controls.Add(this.iddl_PaymentMethods);
            this.Controls.Add(this.in_Amount);
            this.Controls.Add(this.iddl_Customers);
            this.Controls.Add(this.chkOnlyHasActivityLast3Months);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.gridSummary);
            this.Controls.Add(this.gridDetail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.Text = "CUSTOMER CREDITS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Main_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_balance;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOnlyHasActivityLast3Months;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_PaymentMethods;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_balance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_griddetail_Confirmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_amount;
        private System.Windows.Forms.DataGridViewLinkColumn col_griddetail_saleBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_saleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_Id;
        private System.Windows.Forms.DataGridView gridDetail;
    }
}