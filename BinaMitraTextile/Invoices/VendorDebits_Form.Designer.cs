namespace BinaMitraTextile.Invoices
{
    partial class VendorDebits_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVendors = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.col_gridsummary_vendorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridsummary_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDetail = new System.Windows.Forms.DataGridView();
            this.col_griddetail_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_vendorinvoiceid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_vendorinvoiceno = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_griddetail_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_griddetail_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 140;
            this.label4.Text = "Method";
            // 
            // cbPaymentMethods
            // 
            this.cbPaymentMethods.FormattingEnabled = true;
            this.cbPaymentMethods.Location = new System.Drawing.Point(404, 31);
            this.cbPaymentMethods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPaymentMethods.Name = "cbPaymentMethods";
            this.cbPaymentMethods.Size = new System.Drawing.Size(109, 24);
            this.cbPaymentMethods.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 139;
            this.label3.Text = "Vendors";
            // 
            // cbVendors
            // 
            this.cbVendors.FormattingEnabled = true;
            this.cbVendors.Location = new System.Drawing.Point(15, 31);
            this.cbVendors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVendors.Name = "cbVendors";
            this.cbVendors.Size = new System.Drawing.Size(260, 24);
            this.cbVendors.TabIndex = 132;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(520, 31);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(528, 22);
            this.txtNotes.TabIndex = 135;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPayment.Location = new System.Drawing.Point(1056, 28);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(100, 28);
            this.btnAddPayment.TabIndex = 136;
            this.btnAddPayment.Text = "Add";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 137;
            this.label1.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(281, 31);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(116, 22);
            this.txtAmount.TabIndex = 133;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
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
            this.col_gridsummary_vendorid,
            this.col_gridsummary_vendorname,
            this.col_gridsummary_balance});
            this.gridSummary.Location = new System.Drawing.Point(15, 62);
            this.gridSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSummary.MultiSelect = false;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridSummary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSummary.RowTemplate.Height = 24;
            this.gridSummary.Size = new System.Drawing.Size(333, 473);
            this.gridSummary.TabIndex = 142;
            this.gridSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSummary_CellClick);
            // 
            // col_gridsummary_vendorid
            // 
            this.col_gridsummary_vendorid.HeaderText = "vendor id";
            this.col_gridsummary_vendorid.Name = "col_gridsummary_vendorid";
            this.col_gridsummary_vendorid.ReadOnly = true;
            this.col_gridsummary_vendorid.Visible = false;
            // 
            // col_gridsummary_vendorname
            // 
            this.col_gridsummary_vendorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridsummary_vendorname.HeaderText = "Vendor";
            this.col_gridsummary_vendorname.Name = "col_gridsummary_vendorname";
            this.col_gridsummary_vendorname.ReadOnly = true;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_griddetail_timestamp,
            this.col_griddetail_vendorinvoiceid,
            this.col_griddetail_method,
            this.col_griddetail_notes,
            this.col_griddetail_vendorinvoiceno,
            this.col_griddetail_amount,
            this.col_griddetail_balance});
            this.gridDetail.Location = new System.Drawing.Point(364, 62);
            this.gridDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridDetail.MultiSelect = false;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.ReadOnly = true;
            this.gridDetail.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridDetail.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetail.RowTemplate.Height = 24;
            this.gridDetail.Size = new System.Drawing.Size(792, 473);
            this.gridDetail.TabIndex = 141;
            this.gridDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetail_CellContentClick);
            // 
            // col_griddetail_timestamp
            // 
            this.col_griddetail_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_griddetail_timestamp.DataPropertyName = "time_stamp";
            dataGridViewCellStyle5.Format = "dd/MM/yy HH:mm";
            this.col_griddetail_timestamp.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_griddetail_timestamp.HeaderText = "Time Stamp";
            this.col_griddetail_timestamp.Name = "col_griddetail_timestamp";
            this.col_griddetail_timestamp.ReadOnly = true;
            this.col_griddetail_timestamp.Width = 79;
            // 
            // col_griddetail_vendorinvoiceid
            // 
            this.col_griddetail_vendorinvoiceid.HeaderText = "vendorinvoice_id";
            this.col_griddetail_vendorinvoiceid.Name = "col_griddetail_vendorinvoiceid";
            this.col_griddetail_vendorinvoiceid.ReadOnly = true;
            this.col_griddetail_vendorinvoiceid.Visible = false;
            // 
            // col_griddetail_method
            // 
            this.col_griddetail_method.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_griddetail_method.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_griddetail_method.HeaderText = "Method";
            this.col_griddetail_method.Name = "col_griddetail_method";
            this.col_griddetail_method.ReadOnly = true;
            this.col_griddetail_method.Width = 62;
            // 
            // col_griddetail_notes
            // 
            this.col_griddetail_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_griddetail_notes.DataPropertyName = "notes";
            this.col_griddetail_notes.HeaderText = "Notes";
            this.col_griddetail_notes.Name = "col_griddetail_notes";
            this.col_griddetail_notes.ReadOnly = true;
            // 
            // col_griddetail_vendorinvoiceno
            // 
            this.col_griddetail_vendorinvoiceno.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_griddetail_vendorinvoiceno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_griddetail_vendorinvoiceno.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_griddetail_vendorinvoiceno.HeaderText = "Invoice";
            this.col_griddetail_vendorinvoiceno.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_griddetail_vendorinvoiceno.Name = "col_griddetail_vendorinvoiceno";
            this.col_griddetail_vendorinvoiceno.ReadOnly = true;
            this.col_griddetail_vendorinvoiceno.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.col_griddetail_vendorinvoiceno.Width = 42;
            // 
            // col_griddetail_amount
            // 
            this.col_griddetail_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_griddetail_amount.DataPropertyName = "amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.col_griddetail_amount.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_griddetail_amount.HeaderText = "Amount";
            this.col_griddetail_amount.Name = "col_griddetail_amount";
            this.col_griddetail_amount.ReadOnly = true;
            this.col_griddetail_amount.Width = 63;
            // 
            // col_griddetail_balance
            // 
            this.col_griddetail_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.col_griddetail_balance.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_griddetail_balance.HeaderText = "Balance";
            this.col_griddetail_balance.Name = "col_griddetail_balance";
            this.col_griddetail_balance.ReadOnly = true;
            this.col_griddetail_balance.Width = 63;
            // 
            // VendorDebits_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1164, 548);
            this.Controls.Add(this.gridSummary);
            this.Controls.Add(this.gridDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPaymentMethods);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVendors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VendorDebits_Form";
            this.Text = "VENDOR DEBITS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPaymentMethods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVendors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.DataGridView gridDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_vendorinvoiceid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_method;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_notes;
        private System.Windows.Forms.DataGridViewLinkColumn col_griddetail_vendorinvoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_griddetail_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_vendorid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridsummary_balance;
    }
}