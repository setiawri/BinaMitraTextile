namespace BinaMitraTextile.Users
{
    partial class SaleComissions_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleComissions_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeaderContainer = new System.Windows.Forms.Panel();
            this.pnlFilterHeaderContainer = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbLog = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.ptHeader = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.idtp_StartPeriod = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.idtp_GeneratePeriod = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.col_grid_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Users_Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_GlobalPercentComission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_CorrectionAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_CorrectionNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.itxt_CorrectionNotes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_CorrectionAmount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.idtp_PaymentDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.pnlHeaderContainer.SuspendLayout();
            this.pnlFilterHeaderContainer.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeaderContainer
            // 
            this.pnlHeaderContainer.BackColor = System.Drawing.Color.White;
            this.pnlHeaderContainer.Controls.Add(this.panel1);
            this.pnlHeaderContainer.Controls.Add(this.pnlFilterHeaderContainer);
            this.pnlHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderContainer.Name = "pnlHeaderContainer";
            this.pnlHeaderContainer.Size = new System.Drawing.Size(652, 76);
            this.pnlHeaderContainer.TabIndex = 4;
            // 
            // pnlFilterHeaderContainer
            // 
            this.pnlFilterHeaderContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterHeaderContainer.Controls.Add(this.pnlHeader);
            this.pnlFilterHeaderContainer.Controls.Add(this.ptHeader);
            this.pnlFilterHeaderContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilterHeaderContainer.Location = new System.Drawing.Point(0, 49);
            this.pnlFilterHeaderContainer.Name = "pnlFilterHeaderContainer";
            this.pnlFilterHeaderContainer.Size = new System.Drawing.Size(652, 27);
            this.pnlFilterHeaderContainer.TabIndex = 96;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.pbLog);
            this.pnlHeader.Controls.Add(this.pbRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(25, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(627, 27);
            this.pnlHeader.TabIndex = 98;
            // 
            // pbLog
            // 
            this.pbLog.BackColor = System.Drawing.Color.White;
            this.pbLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLog.BackgroundImage")));
            this.pbLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLog.Location = new System.Drawing.Point(25, 0);
            this.pbLog.Name = "pbLog";
            this.pbLog.Size = new System.Drawing.Size(25, 25);
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
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(25, 25);
            this.pbRefresh.TabIndex = 97;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // ptHeader
            // 
            this.ptHeader.AdjustLocationOnClick = false;
            this.ptHeader.BackColor = System.Drawing.Color.White;
            this.ptHeader.ContainerPanel = this.pnlHeaderContainer;
            this.ptHeader.ContainerPanelOriginalSize = new System.Drawing.Size(0, 0);
            this.ptHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptHeader.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Up;
            this.ptHeader.Location = new System.Drawing.Point(0, 0);
            this.ptHeader.MinimumSplitterDistance = 100;
            this.ptHeader.Name = "ptHeader";
            this.ptHeader.Size = new System.Drawing.Size(25, 27);
            this.ptHeader.TabIndex = 94;
            this.ptHeader.TogglePanel = null;
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
            this.col_grid_Id,
            this.col_grid_Period,
            this.col_grid_Users_Username,
            this.col_grid_GlobalPercentComission,
            this.col_grid_Amount,
            this.col_grid_CorrectionAmount,
            this.col_grid_CorrectionNotes,
            this.col_grid_TotalAmount,
            this.col_grid_PaymentDate});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 76);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(652, 269);
            this.grid.TabIndex = 5;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(574, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 97;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // idtp_StartPeriod
            // 
            this.idtp_StartPeriod.Checked = true;
            this.idtp_StartPeriod.CustomFormat = "MMM yyyy";
            this.idtp_StartPeriod.DefaultCheckedValue = true;
            this.idtp_StartPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_StartPeriod.LabelText = "Start Period";
            this.idtp_StartPeriod.Location = new System.Drawing.Point(12, 3);
            this.idtp_StartPeriod.Name = "idtp_StartPeriod";
            this.idtp_StartPeriod.ShowCheckBox = true;
            this.idtp_StartPeriod.ShowDateTimePickerOnly = false;
            this.idtp_StartPeriod.ShowUpAndDown = false;
            this.idtp_StartPeriod.Size = new System.Drawing.Size(110, 39);
            this.idtp_StartPeriod.TabIndex = 98;
            this.idtp_StartPeriod.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.idtp_StartPeriod.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // idtp_GeneratePeriod
            // 
            this.idtp_GeneratePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idtp_GeneratePeriod.Checked = true;
            this.idtp_GeneratePeriod.CustomFormat = "MMM yyyy";
            this.idtp_GeneratePeriod.DefaultCheckedValue = true;
            this.idtp_GeneratePeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_GeneratePeriod.LabelText = "Period";
            this.idtp_GeneratePeriod.Location = new System.Drawing.Point(458, 3);
            this.idtp_GeneratePeriod.Name = "idtp_GeneratePeriod";
            this.idtp_GeneratePeriod.ShowCheckBox = true;
            this.idtp_GeneratePeriod.ShowDateTimePickerOnly = false;
            this.idtp_GeneratePeriod.ShowUpAndDown = false;
            this.idtp_GeneratePeriod.Size = new System.Drawing.Size(110, 39);
            this.idtp_GeneratePeriod.TabIndex = 99;
            this.idtp_GeneratePeriod.Value = new System.DateTime(2020, 9, 17, 0, 0, 0, 0);
            this.idtp_GeneratePeriod.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // col_grid_Id
            // 
            this.col_grid_Id.HeaderText = "Id";
            this.col_grid_Id.Name = "col_grid_Id";
            this.col_grid_Id.ReadOnly = true;
            this.col_grid_Id.Visible = false;
            // 
            // col_grid_Period
            // 
            this.col_grid_Period.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "MMM yyyy";
            this.col_grid_Period.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_Period.HeaderText = "Period";
            this.col_grid_Period.MinimumWidth = 50;
            this.col_grid_Period.Name = "col_grid_Period";
            this.col_grid_Period.ReadOnly = true;
            this.col_grid_Period.Width = 50;
            // 
            // col_grid_Users_Username
            // 
            this.col_grid_Users_Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_Users_Username.HeaderText = "Name";
            this.col_grid_Users_Username.MinimumWidth = 50;
            this.col_grid_Users_Username.Name = "col_grid_Users_Username";
            this.col_grid_Users_Username.ReadOnly = true;
            this.col_grid_Users_Username.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_Users_Username.Width = 50;
            // 
            // col_grid_GlobalPercentComission
            // 
            this.col_grid_GlobalPercentComission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_GlobalPercentComission.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_GlobalPercentComission.HeaderText = "% Global";
            this.col_grid_GlobalPercentComission.MinimumWidth = 65;
            this.col_grid_GlobalPercentComission.Name = "col_grid_GlobalPercentComission";
            this.col_grid_GlobalPercentComission.ReadOnly = true;
            this.col_grid_GlobalPercentComission.Width = 65;
            // 
            // col_grid_Amount
            // 
            this.col_grid_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.col_grid_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_Amount.HeaderText = "Sales";
            this.col_grid_Amount.MinimumWidth = 50;
            this.col_grid_Amount.Name = "col_grid_Amount";
            this.col_grid_Amount.ReadOnly = true;
            this.col_grid_Amount.Width = 50;
            // 
            // col_grid_CorrectionAmount
            // 
            this.col_grid_CorrectionAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.col_grid_CorrectionAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_grid_CorrectionAmount.HeaderText = "Correction";
            this.col_grid_CorrectionAmount.MinimumWidth = 70;
            this.col_grid_CorrectionAmount.Name = "col_grid_CorrectionAmount";
            this.col_grid_CorrectionAmount.ReadOnly = true;
            this.col_grid_CorrectionAmount.Width = 70;
            // 
            // col_grid_CorrectionNotes
            // 
            this.col_grid_CorrectionNotes.HeaderText = "Notes";
            this.col_grid_CorrectionNotes.MinimumWidth = 200;
            this.col_grid_CorrectionNotes.Name = "col_grid_CorrectionNotes";
            this.col_grid_CorrectionNotes.ReadOnly = true;
            this.col_grid_CorrectionNotes.Width = 200;
            // 
            // col_grid_TotalAmount
            // 
            this.col_grid_TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_grid_TotalAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_grid_TotalAmount.HeaderText = "Amount";
            this.col_grid_TotalAmount.MinimumWidth = 50;
            this.col_grid_TotalAmount.Name = "col_grid_TotalAmount";
            this.col_grid_TotalAmount.ReadOnly = true;
            this.col_grid_TotalAmount.Width = 50;
            // 
            // col_grid_PaymentDate
            // 
            this.col_grid_PaymentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "dd/MM/yy";
            this.col_grid_PaymentDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_grid_PaymentDate.HeaderText = "Payment";
            this.col_grid_PaymentDate.MinimumWidth = 50;
            this.col_grid_PaymentDate.Name = "col_grid_PaymentDate";
            this.col_grid_PaymentDate.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.idtp_GeneratePeriod);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.idtp_StartPeriod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 49);
            this.panel1.TabIndex = 6;
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUpdate.Controls.Add(this.idtp_PaymentDate);
            this.pnlUpdate.Controls.Add(this.btnCancelUpdate);
            this.pnlUpdate.Controls.Add(this.in_CorrectionAmount);
            this.pnlUpdate.Controls.Add(this.itxt_CorrectionNotes);
            this.pnlUpdate.Controls.Add(this.btnUpdate);
            this.pnlUpdate.Location = new System.Drawing.Point(212, 100);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(228, 153);
            this.pnlUpdate.TabIndex = 6;
            this.pnlUpdate.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.Location = new System.Drawing.Point(38, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 98;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // itxt_CorrectionNotes
            // 
            this.itxt_CorrectionNotes.IsBrowseMode = false;
            this.itxt_CorrectionNotes.LabelText = "Notes";
            this.itxt_CorrectionNotes.Location = new System.Drawing.Point(7, 60);
            this.itxt_CorrectionNotes.MaxLength = 32767;
            this.itxt_CorrectionNotes.MultiLine = false;
            this.itxt_CorrectionNotes.Name = "itxt_CorrectionNotes";
            this.itxt_CorrectionNotes.PasswordChar = '\0';
            this.itxt_CorrectionNotes.RowCount = 1;
            this.itxt_CorrectionNotes.ShowDeleteButton = false;
            this.itxt_CorrectionNotes.ShowFilter = false;
            this.itxt_CorrectionNotes.ShowTextboxOnly = false;
            this.itxt_CorrectionNotes.Size = new System.Drawing.Size(214, 41);
            this.itxt_CorrectionNotes.TabIndex = 100;
            this.itxt_CorrectionNotes.ValueText = "";
            // 
            // in_CorrectionAmount
            // 
            this.in_CorrectionAmount.Checked = false;
            this.in_CorrectionAmount.DecimalPlaces = 0;
            this.in_CorrectionAmount.HideUpDown = false;
            this.in_CorrectionAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_CorrectionAmount.LabelText = "Correction";
            this.in_CorrectionAmount.Location = new System.Drawing.Point(7, 13);
            this.in_CorrectionAmount.MaximumValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.in_CorrectionAmount.MinimumValue = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.in_CorrectionAmount.Name = "in_CorrectionAmount";
            this.in_CorrectionAmount.ShowAllowDecimalCheckbox = false;
            this.in_CorrectionAmount.ShowCheckbox = false;
            this.in_CorrectionAmount.ShowTextboxOnly = false;
            this.in_CorrectionAmount.Size = new System.Drawing.Size(88, 41);
            this.in_CorrectionAmount.TabIndex = 101;
            this.in_CorrectionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelUpdate.Location = new System.Drawing.Point(114, 114);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCancelUpdate.TabIndex = 102;
            this.btnCancelUpdate.Text = "CANCEL";
            this.btnCancelUpdate.UseVisualStyleBackColor = true;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            // 
            // idtp_PaymentDate
            // 
            this.idtp_PaymentDate.Checked = false;
            this.idtp_PaymentDate.CustomFormat = "dd/MM/yyyy";
            this.idtp_PaymentDate.DefaultCheckedValue = false;
            this.idtp_PaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_PaymentDate.LabelText = "Payment Date";
            this.idtp_PaymentDate.Location = new System.Drawing.Point(101, 12);
            this.idtp_PaymentDate.Name = "idtp_PaymentDate";
            this.idtp_PaymentDate.ShowCheckBox = true;
            this.idtp_PaymentDate.ShowDateTimePickerOnly = false;
            this.idtp_PaymentDate.ShowUpAndDown = false;
            this.idtp_PaymentDate.Size = new System.Drawing.Size(120, 41);
            this.idtp_PaymentDate.TabIndex = 103;
            this.idtp_PaymentDate.Value = null;
            this.idtp_PaymentDate.ValueTimeSpan = null;
            // 
            // SaleComissions_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 345);
            this.Controls.Add(this.pnlUpdate);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlHeaderContainer);
            this.Name = "SaleComissions_Form";
            this.Text = "KOMISI SALES";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.pnlHeaderContainer.ResumeLayout(false);
            this.pnlFilterHeaderContainer.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeaderContainer;
        private System.Windows.Forms.Panel pnlFilterHeaderContainer;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox pbLog;
        private System.Windows.Forms.PictureBox pbRefresh;
        private LIBUtil.Desktop.UserControls.PanelToggle ptHeader;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnGenerate;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_StartPeriod;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_GeneratePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Users_Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_GlobalPercentComission;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_CorrectionAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_CorrectionNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_PaymentDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlUpdate;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_CorrectionAmount;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_CorrectionNotes;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancelUpdate;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_PaymentDate;
    }
}