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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.col_griddetail_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_saleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_saleBarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_griddetail_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_Confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_griddetail_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.col_gridsummary_customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOnlyHasActivityLast3Months = new System.Windows.Forms.CheckBox();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.gridDetail.Location = new System.Drawing.Point(275, 47);
            this.gridDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridDetail.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gridDetail.RowTemplate.Height = 24;
            this.gridDetail.Size = new System.Drawing.Size(594, 377);
            this.gridDetail.TabIndex = 114;
            this.gridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellContentClick);
            // 
            // col_griddetail_Id
            // 
            this.col_griddetail_Id.HeaderText = "id";
            this.col_griddetail_Id.Name = "col_griddetail_Id";
            this.col_griddetail_Id.ReadOnly = true;
            this.col_griddetail_Id.Visible = false;
            // 
            // col_griddetail_timestamp
            // 
            this.col_griddetail_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_timestamp.DataPropertyName = "time_stamp";
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.col_griddetail_timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_griddetail_timestamp.HeaderText = "Date";
            this.col_griddetail_timestamp.MinimumWidth = 50;
            this.col_griddetail_timestamp.Name = "col_griddetail_timestamp";
            this.col_griddetail_timestamp.ReadOnly = true;
            this.col_griddetail_timestamp.Width = 50;
            // 
            // col_griddetail_saleID
            // 
            this.col_griddetail_saleID.HeaderText = "sale_id";
            this.col_griddetail_saleID.Name = "col_griddetail_saleID";
            this.col_griddetail_saleID.ReadOnly = true;
            this.col_griddetail_saleID.Visible = false;
            // 
            // col_griddetail_method
            // 
            this.col_griddetail_method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_griddetail_method.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_griddetail_method.HeaderText = "Method";
            this.col_griddetail_method.MinimumWidth = 50;
            this.col_griddetail_method.Name = "col_griddetail_method";
            this.col_griddetail_method.ReadOnly = true;
            this.col_griddetail_method.Width = 50;
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
            // col_griddetail_saleBarcode
            // 
            this.col_griddetail_saleBarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_griddetail_saleBarcode.DataPropertyName = "sale_barcode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_griddetail_saleBarcode.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_griddetail_saleBarcode.HeaderText = "Invoice";
            this.col_griddetail_saleBarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.MinimumWidth = 50;
            this.col_griddetail_saleBarcode.Name = "col_griddetail_saleBarcode";
            this.col_griddetail_saleBarcode.ReadOnly = true;
            this.col_griddetail_saleBarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_griddetail_saleBarcode.Width = 50;
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
            // col_griddetail_balance
            // 
            this.col_griddetail_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.col_griddetail_balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_griddetail_balance.HeaderText = "Balance";
            this.col_griddetail_balance.MinimumWidth = 50;
            this.col_griddetail_balance.Name = "col_griddetail_balance";
            this.col_griddetail_balance.ReadOnly = true;
            this.col_griddetail_balance.Width = 50;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridsummary_customerid,
            this.col_gridsummary_customername,
            this.col_gridsummary_balance});
            this.gridSummary.Location = new System.Drawing.Point(13, 27);
            this.gridSummary.Margin = new System.Windows.Forms.Padding(2);
            this.gridSummary.MultiSelect = false;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridSummary.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridSummary.RowTemplate.Height = 24;
            this.gridSummary.Size = new System.Drawing.Size(250, 397);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.col_gridsummary_balance.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_gridsummary_balance.HeaderText = "Balance";
            this.col_gridsummary_balance.Name = "col_gridsummary_balance";
            this.col_gridsummary_balance.ReadOnly = true;
            this.col_gridsummary_balance.Width = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(620, 23);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(195, 20);
            this.txtNotes.TabIndex = 4;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPayment.Location = new System.Drawing.Point(820, 21);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(49, 23);
            this.btnAddPayment.TabIndex = 5;
            this.btnAddPayment.Text = "Add";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Method";
            // 
            // cbPaymentMethods
            // 
            this.cbPaymentMethods.FormattingEnabled = true;
            this.cbPaymentMethods.Location = new System.Drawing.Point(533, 23);
            this.cbPaymentMethods.Margin = new System.Windows.Forms.Padding(2);
            this.cbPaymentMethods.Name = "cbPaymentMethods";
            this.cbPaymentMethods.Size = new System.Drawing.Size(83, 21);
            this.cbPaymentMethods.TabIndex = 3;
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = true;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(275, 3);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(142, 41);
            this.iddl_Customers.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(44, 4);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.MaxLength = 500;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(60, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.chkOnlyHasActivityLast3Months.Location = new System.Drawing.Point(109, 6);
            this.chkOnlyHasActivityLast3Months.Name = "chkOnlyHasActivityLast3Months";
            this.chkOnlyHasActivityLast3Months.Size = new System.Drawing.Size(152, 17);
            this.chkOnlyHasActivityLast3Months.TabIndex = 134;
            this.chkOnlyHasActivityLast3Months.Text = "Has Activity Last 3 Months";
            this.chkOnlyHasActivityLast3Months.UseVisualStyleBackColor = true;
            this.chkOnlyHasActivityLast3Months.CheckedChanged += new System.EventHandler(this.chkOnlyHasActivityLast3Months_CheckedChanged);
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
            this.in_Amount.Location = new System.Drawing.Point(419, 3);
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
            this.in_Amount.Size = new System.Drawing.Size(111, 41);
            this.in_Amount.TabIndex = 2;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 435);
            this.Controls.Add(this.in_Amount);
            this.Controls.Add(this.chkOnlyHasActivityLast3Months);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.iddl_Customers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPaymentMethods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.gridSummary);
            this.Controls.Add(this.gridDetail);
            this.Name = "Main_Form";
            this.Text = "CUSTOMER CREDITS";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPaymentMethods;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_balance;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOnlyHasActivityLast3Months;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_saleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_notes;
        private System.Windows.Forms.DataGridViewLinkColumn col_griddetail_saleBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_griddetail_Confirmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_balance;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
    }
}