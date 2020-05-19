namespace BinaMitraTextile.Returns
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReturnSale = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.DateTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hexbarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInventoryItemBarcode = new System.Windows.Forms.TextBox();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlFilterAndButtons = new System.Windows.Forms.Panel();
            this.idtp_StartDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.idtp_EndDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlFilterAndButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturnSale
            // 
            this.btnReturnSale.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnReturnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnSale.ForeColor = System.Drawing.Color.Orange;
            this.btnReturnSale.Location = new System.Drawing.Point(9, 7);
            this.btnReturnSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturnSale.Name = "btnReturnSale";
            this.btnReturnSale.Size = new System.Drawing.Size(200, 60);
            this.btnReturnSale.TabIndex = 0;
            this.btnReturnSale.Text = "NEW RETURN";
            this.btnReturnSale.UseVisualStyleBackColor = true;
            this.btnReturnSale.Click += new System.EventHandler(this.btnReturnSale_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateTimeStamp,
            this.hexbarcode,
            this.customer_name,
            this.sale_qty,
            this.sale_length,
            this.sale_amount,
            this.col_grid_id,
            this.col_grid_Checked});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(219, 0);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(617, 265);
            this.grid.TabIndex = 2;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentDoubleClick);
            // 
            // DateTimeStamp
            // 
            this.DateTimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DateTimeStamp.DataPropertyName = "time_stamp";
            dataGridViewCellStyle16.Format = "dd/MM/yy HH:mm";
            this.DateTimeStamp.DefaultCellStyle = dataGridViewCellStyle16;
            this.DateTimeStamp.HeaderText = "Date";
            this.DateTimeStamp.MinimumWidth = 30;
            this.DateTimeStamp.Name = "DateTimeStamp";
            this.DateTimeStamp.ReadOnly = true;
            this.DateTimeStamp.Width = 30;
            // 
            // hexbarcode
            // 
            this.hexbarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.hexbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.hexbarcode.DataPropertyName = "hexbarcode";
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexbarcode.DefaultCellStyle = dataGridViewCellStyle17;
            this.hexbarcode.HeaderText = "No";
            this.hexbarcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.hexbarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.hexbarcode.MinimumWidth = 30;
            this.hexbarcode.Name = "hexbarcode";
            this.hexbarcode.ReadOnly = true;
            this.hexbarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hexbarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hexbarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.hexbarcode.Width = 30;
            // 
            // customer_name
            // 
            this.customer_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customer_name.DataPropertyName = "customer_name";
            this.customer_name.HeaderText = "Customer";
            this.customer_name.MinimumWidth = 50;
            this.customer_name.Name = "customer_name";
            this.customer_name.ReadOnly = true;
            this.customer_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customer_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sale_qty
            // 
            this.sale_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.sale_qty.DataPropertyName = "sale_qty";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sale_qty.DefaultCellStyle = dataGridViewCellStyle18;
            this.sale_qty.HeaderText = "Pcs";
            this.sale_qty.MinimumWidth = 30;
            this.sale_qty.Name = "sale_qty";
            this.sale_qty.ReadOnly = true;
            this.sale_qty.Width = 30;
            // 
            // sale_length
            // 
            this.sale_length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.sale_length.DataPropertyName = "sale_length";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sale_length.DefaultCellStyle = dataGridViewCellStyle19;
            this.sale_length.HeaderText = "Qty";
            this.sale_length.MinimumWidth = 30;
            this.sale_length.Name = "sale_length";
            this.sale_length.ReadOnly = true;
            this.sale_length.Width = 30;
            // 
            // sale_amount
            // 
            this.sale_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.sale_amount.DataPropertyName = "sale_amount";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.sale_amount.DefaultCellStyle = dataGridViewCellStyle20;
            this.sale_amount.HeaderText = "Amount";
            this.sale_amount.MinimumWidth = 50;
            this.sale_amount.Name = "sale_amount";
            this.sale_amount.ReadOnly = true;
            this.sale_amount.Width = 50;
            // 
            // col_grid_id
            // 
            this.col_grid_id.DataPropertyName = "id";
            this.col_grid_id.HeaderText = "id";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idtp_EndDate);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInventoryItemBarcode);
            this.groupBox1.Controls.Add(this.cbCustomers);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(9, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(200, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(90, 17);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(102, 20);
            this.txtBarcode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "Return Barcode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Item Barcode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "from";
            // 
            // txtInventoryItemBarcode
            // 
            this.txtInventoryItemBarcode.Location = new System.Drawing.Point(90, 40);
            this.txtInventoryItemBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtInventoryItemBarcode.Name = "txtInventoryItemBarcode";
            this.txtInventoryItemBarcode.Size = new System.Drawing.Size(102, 20);
            this.txtInventoryItemBarcode.TabIndex = 1;
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(57, 111);
            this.cbCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(135, 21);
            this.cbCustomers.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(9, 139);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(82, 19);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter Results";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 104;
            this.label4.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "to";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(95, 139);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 19);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlFilterAndButtons
            // 
            this.pnlFilterAndButtons.Controls.Add(this.btnReturnSale);
            this.pnlFilterAndButtons.Controls.Add(this.groupBox1);
            this.pnlFilterAndButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilterAndButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterAndButtons.Name = "pnlFilterAndButtons";
            this.pnlFilterAndButtons.Size = new System.Drawing.Size(219, 265);
            this.pnlFilterAndButtons.TabIndex = 3;
            // 
            // idtp_StartDate
            // 
            this.idtp_StartDate.Checked = true;
            this.idtp_StartDate.CustomFormat = "dd/MM/yyyy";
            this.idtp_StartDate.DefaultCheckedValue = false;
            this.idtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_StartDate.LabelText = "Start Date";
            this.idtp_StartDate.Location = new System.Drawing.Point(99, 135);
            this.idtp_StartDate.Name = "idtp_StartDate";
            this.idtp_StartDate.ShowCheckBox = false;
            this.idtp_StartDate.ShowDateTimePickerOnly = true;
            this.idtp_StartDate.ShowUpAndDown = false;
            this.idtp_StartDate.Size = new System.Drawing.Size(102, 21);
            this.idtp_StartDate.TabIndex = 4;
            this.idtp_StartDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_StartDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // idtp_EndDate
            // 
            this.idtp_EndDate.Checked = true;
            this.idtp_EndDate.CustomFormat = "dd/MM/yyyy";
            this.idtp_EndDate.DefaultCheckedValue = false;
            this.idtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_EndDate.LabelText = "Start Date";
            this.idtp_EndDate.Location = new System.Drawing.Point(90, 84);
            this.idtp_EndDate.Name = "idtp_EndDate";
            this.idtp_EndDate.ShowCheckBox = true;
            this.idtp_EndDate.ShowDateTimePickerOnly = true;
            this.idtp_EndDate.ShowUpAndDown = false;
            this.idtp_EndDate.Size = new System.Drawing.Size(102, 21);
            this.idtp_EndDate.TabIndex = 5;
            this.idtp_EndDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_EndDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 265);
            this.Controls.Add(this.idtp_StartDate);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlFilterAndButtons);
            this.Name = "Main_Form";
            this.Text = "SALES RETURNS";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFilterAndButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturnSale;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInventoryItemBarcode;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlFilterAndButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeStamp;
        private System.Windows.Forms.DataGridViewLinkColumn hexbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_Checked;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_EndDate;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_StartDate;
    }
}