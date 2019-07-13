namespace BinaMitraTextile.Invoices
{
    partial class Payment_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment_Form));
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_referenceid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_methodname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbPaymentMethods = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCreditBalance = new System.Windows.Forms.Label();
            this.btnAddCredit = new System.Windows.Forms.Button();
            this.in_PaymentAmount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.col_grid_referenceid,
            this.col_grid_timestamp,
            this.col_grid_methodname,
            this.col_grid_amount,
            this.col_grid_balance,
            this.col_grid_notes,
            this.col_grid_Checked});
            this.grid.Location = new System.Drawing.Point(14, 54);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(797, 261);
            this.grid.TabIndex = 4;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // col_grid_id
            // 
            this.col_grid_id.HeaderText = "ID";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            // 
            // col_grid_referenceid
            // 
            this.col_grid_referenceid.HeaderText = "Reference ID";
            this.col_grid_referenceid.Name = "col_grid_referenceid";
            this.col_grid_referenceid.ReadOnly = true;
            this.col_grid_referenceid.Visible = false;
            // 
            // col_grid_timestamp
            // 
            this.col_grid_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.col_grid_timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_timestamp.HeaderText = "Date";
            this.col_grid_timestamp.Name = "col_grid_timestamp";
            this.col_grid_timestamp.ReadOnly = true;
            this.col_grid_timestamp.Width = 50;
            // 
            // col_grid_methodname
            // 
            this.col_grid_methodname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_methodname.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_methodname.HeaderText = "Method";
            this.col_grid_methodname.Name = "col_grid_methodname";
            this.col_grid_methodname.ReadOnly = true;
            this.col_grid_methodname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_methodname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_grid_methodname.Width = 43;
            // 
            // col_grid_amount
            // 
            this.col_grid_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_grid_amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_amount.HeaderText = "Amount";
            this.col_grid_amount.Name = "col_grid_amount";
            this.col_grid_amount.ReadOnly = true;
            this.col_grid_amount.Width = 63;
            // 
            // col_grid_balance
            // 
            this.col_grid_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_grid_balance.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_grid_balance.HeaderText = "Balance";
            this.col_grid_balance.Name = "col_grid_balance";
            this.col_grid_balance.ReadOnly = true;
            this.col_grid_balance.Width = 63;
            // 
            // col_grid_notes
            // 
            this.col_grid_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_notes.HeaderText = "Notes";
            this.col_grid_notes.Name = "col_grid_notes";
            this.col_grid_notes.ReadOnly = true;
            // 
            // col_grid_Checked
            // 
            this.col_grid_Checked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_Checked.HeaderText = "OK";
            this.col_grid_Checked.MinimumWidth = 30;
            this.col_grid_Checked.Name = "col_grid_Checked";
            this.col_grid_Checked.ReadOnly = true;
            this.col_grid_Checked.Width = 30;
            // 
            // cbPaymentMethods
            // 
            this.cbPaymentMethods.FormattingEnabled = true;
            this.cbPaymentMethods.Location = new System.Drawing.Point(14, 30);
            this.cbPaymentMethods.Margin = new System.Windows.Forms.Padding(2);
            this.cbPaymentMethods.Name = "cbPaymentMethods";
            this.cbPaymentMethods.Size = new System.Drawing.Size(83, 21);
            this.cbPaymentMethods.TabIndex = 0;
            this.cbPaymentMethods.SelectedIndexChanged += new System.EventHandler(this.cbPaymentMethods_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 102;
            this.label3.Text = "Method";
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(453, 28);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(61, 23);
            this.btnAddPayment.TabIndex = 3;
            this.btnAddPayment.Text = "Add";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(519, 29);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(292, 23);
            this.lblTotalAmount.TabIndex = 108;
            this.lblTotalAmount.Text = "lblTotalAmount";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreditBalance
            // 
            this.lblCreditBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreditBalance.Location = new System.Drawing.Point(396, 13);
            this.lblCreditBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreditBalance.Name = "lblCreditBalance";
            this.lblCreditBalance.Size = new System.Drawing.Size(396, 13);
            this.lblCreditBalance.TabIndex = 109;
            this.lblCreditBalance.Text = "lblCreditBalance";
            this.lblCreditBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddCredit
            // 
            this.btnAddCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCredit.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCredit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCredit.BackgroundImage")));
            this.btnAddCredit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCredit.FlatAppearance.BorderSize = 0;
            this.btnAddCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCredit.Location = new System.Drawing.Point(793, 11);
            this.btnAddCredit.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCredit.Name = "btnAddCredit";
            this.btnAddCredit.Size = new System.Drawing.Size(15, 16);
            this.btnAddCredit.TabIndex = 120;
            this.btnAddCredit.UseVisualStyleBackColor = false;
            this.btnAddCredit.Click += new System.EventHandler(this.btnAddCredit_Click);
            // 
            // in_PaymentAmount
            // 
            this.in_PaymentAmount.Checked = false;
            this.in_PaymentAmount.DecimalPlaces = 0;
            this.in_PaymentAmount.HideUpDown = true;
            this.in_PaymentAmount.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_PaymentAmount.LabelText = "Amount";
            this.in_PaymentAmount.Location = new System.Drawing.Point(102, 12);
            this.in_PaymentAmount.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_PaymentAmount.MinimumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.in_PaymentAmount.Name = "in_PaymentAmount";
            this.in_PaymentAmount.ShowCheckbox = false;
            this.in_PaymentAmount.ShowAllowDecimalCheckbox = false;
            this.in_PaymentAmount.ShowTextboxOnly = false;
            this.in_PaymentAmount.Size = new System.Drawing.Size(111, 40);
            this.in_PaymentAmount.TabIndex = 1;
            this.in_PaymentAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(218, 30);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(232, 20);
            this.txtNotes.TabIndex = 2;
            // 
            // Payment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 326);
            this.Controls.Add(this.in_PaymentAmount);
            this.Controls.Add(this.btnAddCredit);
            this.Controls.Add(this.lblCreditBalance);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPaymentMethods);
            this.Controls.Add(this.grid);
            this.Name = "Payment_Form";
            this.Text = "Payment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payment_Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ComboBox cbPaymentMethods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCreditBalance;
        private System.Windows.Forms.Button btnAddCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_referenceid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_methodname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_notes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_Checked;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PaymentAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
    }
}