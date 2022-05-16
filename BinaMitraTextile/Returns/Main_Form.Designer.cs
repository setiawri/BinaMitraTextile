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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.btnReturnSale = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.DateTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hexbarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Vendors_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_FakturPajaks_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtp_EndDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInventoryItemBarcode = new System.Windows.Forms.TextBox();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlFilterHeaderContainer = new System.Windows.Forms.Panel();
            this.pnlFilterHeader = new System.Windows.Forms.Panel();
            this.pbLog = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.ptFilter = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.idtp_StartDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlFilterHeaderContainer.SuspendLayout();
            this.pnlFilterHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturnSale
            // 
            this.btnReturnSale.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnReturnSale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnSale.ForeColor = System.Drawing.Color.Orange;
            this.btnReturnSale.Location = new System.Drawing.Point(73, 1);
            this.btnReturnSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReturnSale.Name = "btnReturnSale";
            this.btnReturnSale.Size = new System.Drawing.Size(93, 28);
            this.btnReturnSale.TabIndex = 0;
            this.btnReturnSale.Text = "CREATE";
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
            this.DateTimeStamp,
            this.hexbarcode,
            this.customer_name,
            this.col_grid_Vendors_Name,
            this.sale_qty,
            this.sale_length,
            this.sale_amount,
            this.col_grid_id,
            this.col_grid_Checked,
            this.col_grid_FakturPajaks_No});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 113);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(965, 303);
            this.grid.TabIndex = 2;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentDoubleClick);
            // 
            // DateTimeStamp
            // 
            this.DateTimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DateTimeStamp.DataPropertyName = "time_stamp";
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.DateTimeStamp.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexbarcode.DefaultCellStyle = dataGridViewCellStyle3;
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
            // col_grid_Vendors_Name
            // 
            this.col_grid_Vendors_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_Vendors_Name.HeaderText = "Vendor";
            this.col_grid_Vendors_Name.MinimumWidth = 50;
            this.col_grid_Vendors_Name.Name = "col_grid_Vendors_Name";
            this.col_grid_Vendors_Name.ReadOnly = true;
            // 
            // sale_qty
            // 
            this.sale_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.sale_qty.DataPropertyName = "sale_qty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sale_qty.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sale_length.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.sale_amount.DefaultCellStyle = dataGridViewCellStyle6;
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
            // col_grid_FakturPajaks_No
            // 
            this.col_grid_FakturPajaks_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_FakturPajaks_No.HeaderText = "FP";
            this.col_grid_FakturPajaks_No.MinimumWidth = 30;
            this.col_grid_FakturPajaks_No.Name = "col_grid_FakturPajaks_No";
            this.col_grid_FakturPajaks_No.ReadOnly = true;
            this.col_grid_FakturPajaks_No.Width = 30;
            // 
            // idtp_EndDate
            // 
            this.idtp_EndDate.Checked = true;
            this.idtp_EndDate.CustomFormat = "dd/MM/yyyy";
            this.idtp_EndDate.DefaultCheckedValue = false;
            this.idtp_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_EndDate.LabelText = "Start Date";
            this.idtp_EndDate.Location = new System.Drawing.Point(443, 12);
            this.idtp_EndDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.idtp_EndDate.Name = "idtp_EndDate";
            this.idtp_EndDate.ShowCheckBox = true;
            this.idtp_EndDate.ShowDateTimePickerOnly = true;
            this.idtp_EndDate.ShowUpAndDown = false;
            this.idtp_EndDate.Size = new System.Drawing.Size(136, 26);
            this.idtp_EndDate.TabIndex = 5;
            this.idtp_EndDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_EndDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 99;
            this.label5.Text = "Item Barcode";
            // 
            // txtInventoryItemBarcode
            // 
            this.txtInventoryItemBarcode.Location = new System.Drawing.Point(129, 12);
            this.txtInventoryItemBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInventoryItemBarcode.Name = "txtInventoryItemBarcode";
            this.txtInventoryItemBarcode.Size = new System.Drawing.Size(135, 22);
            this.txtInventoryItemBarcode.TabIndex = 1;
            // 
            // cbCustomers
            // 
            this.cbCustomers.FormattingEnabled = true;
            this.cbCustomers.Location = new System.Drawing.Point(129, 42);
            this.cbCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(135, 24);
            this.cbCustomers.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(585, 12);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(109, 53);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 16);
            this.label1.TabIndex = 94;
            this.label1.Text = "to";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(700, 12);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(109, 53);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.pnlFilterHeaderContainer);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.btnClear);
            this.pnlFilter.Controls.Add(this.cbCustomers);
            this.pnlFilter.Controls.Add(this.idtp_EndDate);
            this.pnlFilter.Controls.Add(this.txtInventoryItemBarcode);
            this.pnlFilter.Controls.Add(this.idtp_StartDate);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(965, 113);
            this.pnlFilter.TabIndex = 3;
            // 
            // pnlFilterHeaderContainer
            // 
            this.pnlFilterHeaderContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterHeaderContainer.Controls.Add(this.pnlFilterHeader);
            this.pnlFilterHeaderContainer.Controls.Add(this.ptFilter);
            this.pnlFilterHeaderContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilterHeaderContainer.Location = new System.Drawing.Point(0, 80);
            this.pnlFilterHeaderContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFilterHeaderContainer.Name = "pnlFilterHeaderContainer";
            this.pnlFilterHeaderContainer.Size = new System.Drawing.Size(965, 33);
            this.pnlFilterHeaderContainer.TabIndex = 96;
            // 
            // pnlFilterHeader
            // 
            this.pnlFilterHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilterHeader.Controls.Add(this.pbLog);
            this.pnlFilterHeader.Controls.Add(this.btnReturnSale);
            this.pnlFilterHeader.Controls.Add(this.pbRefresh);
            this.pnlFilterHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterHeader.Location = new System.Drawing.Point(33, 0);
            this.pnlFilterHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFilterHeader.Name = "pnlFilterHeader";
            this.pnlFilterHeader.Size = new System.Drawing.Size(932, 33);
            this.pnlFilterHeader.TabIndex = 98;
            // 
            // pbLog
            // 
            this.pbLog.BackColor = System.Drawing.Color.White;
            this.pbLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLog.BackgroundImage")));
            this.pbLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLog.Location = new System.Drawing.Point(33, 0);
            this.pbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLog.Name = "pbLog";
            this.pbLog.Size = new System.Drawing.Size(33, 31);
            this.pbLog.TabIndex = 98;
            this.pbLog.TabStop = false;
            this.pbLog.Click += new System.EventHandler(this.pbLog_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.BackColor = System.Drawing.Color.White;
            this.pbRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRefresh.BackgroundImage")));
            this.pbRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbRefresh.Location = new System.Drawing.Point(0, 0);
            this.pbRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(33, 31);
            this.pbRefresh.TabIndex = 97;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // ptFilter
            // 
            this.ptFilter.AdjustLocationOnClick = false;
            this.ptFilter.BackColor = System.Drawing.Color.White;
            this.ptFilter.ContainerPanel = this.pnlFilter;
            this.ptFilter.ContainerPanelOriginalSize = new System.Drawing.Size(0, 0);
            this.ptFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptFilter.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Up;
            this.ptFilter.Location = new System.Drawing.Point(0, 0);
            this.ptFilter.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ptFilter.MinimumSplitterDistance = 100;
            this.ptFilter.Name = "ptFilter";
            this.ptFilter.Size = new System.Drawing.Size(33, 33);
            this.ptFilter.TabIndex = 94;
            this.ptFilter.TogglePanel = null;
            // 
            // idtp_StartDate
            // 
            this.idtp_StartDate.Checked = true;
            this.idtp_StartDate.CustomFormat = "dd/MM/yyyy";
            this.idtp_StartDate.DefaultCheckedValue = false;
            this.idtp_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_StartDate.LabelText = "Start Date";
            this.idtp_StartDate.Location = new System.Drawing.Point(285, 12);
            this.idtp_StartDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.idtp_StartDate.Name = "idtp_StartDate";
            this.idtp_StartDate.ShowCheckBox = false;
            this.idtp_StartDate.ShowDateTimePickerOnly = true;
            this.idtp_StartDate.ShowUpAndDown = false;
            this.idtp_StartDate.Size = new System.Drawing.Size(136, 26);
            this.idtp_StartDate.TabIndex = 4;
            this.idtp_StartDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_StartDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(965, 416);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlFilter);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main_Form";
            this.Text = "SALES RETURNS";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilterHeaderContainer.ResumeLayout(false);
            this.pnlFilterHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturnSale;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInventoryItemBarcode;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlFilter;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_EndDate;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_StartDate;
        private System.Windows.Forms.Panel pnlFilterHeaderContainer;
        private System.Windows.Forms.Panel pnlFilterHeader;
        private System.Windows.Forms.PictureBox pbLog;
        private System.Windows.Forms.PictureBox pbRefresh;
        private LIBUtil.Desktop.UserControls.PanelToggle ptFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTimeStamp;
        private System.Windows.Forms.DataGridViewLinkColumn hexbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Vendors_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_FakturPajaks_No;
    }
}