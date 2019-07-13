namespace BinaMitraTextile.FinancialRecords
{
    partial class PettyCash_Form
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
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dropCategories = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPettyCashRecord = new System.Windows.Forms.Button();
            this.dropFilterCategories = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.idtp_FilterEnd = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.idtp_FilterStart = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.chkOnlyNotChecked = new System.Windows.Forms.CheckBox();
            this.pnlCalculator = new System.Windows.Forms.Panel();
            this.lblCalculatorBalance = new System.Windows.Forms.Label();
            this.lblCalculatorBalanceDiff = new System.Windows.Forms.Label();
            this.btnCloseCalculator = new System.Windows.Forms.Button();
            this.btnResetCalculator = new System.Windows.Forms.Button();
            this.lblCalculatorTotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.in_100 = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label12 = new System.Windows.Forms.Label();
            this.in_200 = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label11 = new System.Windows.Forms.Label();
            this.in_500 = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label10 = new System.Windows.Forms.Label();
            this.in_1rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label9 = new System.Windows.Forms.Label();
            this.in_2rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label7 = new System.Windows.Forms.Label();
            this.in_5rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.in_10rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_20rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_50rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_100rb = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_categoryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.panelToggle1 = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.lbl2rb = new System.Windows.Forms.Label();
            this.lbl1rb = new System.Windows.Forms.Label();
            this.lbl500 = new System.Windows.Forms.Label();
            this.lbl200 = new System.Windows.Forms.Label();
            this.lbl100 = new System.Windows.Forms.Label();
            this.lbl5rb = new System.Windows.Forms.Label();
            this.lbl10rb = new System.Windows.Forms.Label();
            this.lbl20rb = new System.Windows.Forms.Label();
            this.lbl50rb = new System.Windows.Forms.Label();
            this.lbl100rb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlCalculator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Notes";
            // 
            // dropCategories
            // 
            this.dropCategories.FormattingEnabled = true;
            this.dropCategories.Location = new System.Drawing.Point(41, 16);
            this.dropCategories.Margin = new System.Windows.Forms.Padding(2);
            this.dropCategories.Name = "dropCategories";
            this.dropCategories.Size = new System.Drawing.Size(107, 21);
            this.dropCategories.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(267, 16);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(363, 20);
            this.txtNotes.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "Category";
            // 
            // btnAddPettyCashRecord
            // 
            this.btnAddPettyCashRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPettyCashRecord.Location = new System.Drawing.Point(635, 15);
            this.btnAddPettyCashRecord.Name = "btnAddPettyCashRecord";
            this.btnAddPettyCashRecord.Size = new System.Drawing.Size(56, 21);
            this.btnAddPettyCashRecord.TabIndex = 3;
            this.btnAddPettyCashRecord.Text = "SUBMIT";
            this.btnAddPettyCashRecord.UseVisualStyleBackColor = true;
            this.btnAddPettyCashRecord.Click += new System.EventHandler(this.btnAddPettyCashRecord_Click);
            // 
            // dropFilterCategories
            // 
            this.dropFilterCategories.FormattingEnabled = true;
            this.dropFilterCategories.Location = new System.Drawing.Point(267, 21);
            this.dropFilterCategories.Margin = new System.Windows.Forms.Padding(2);
            this.dropFilterCategories.Name = "dropFilterCategories";
            this.dropFilterCategories.Size = new System.Drawing.Size(131, 21);
            this.dropFilterCategories.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(666, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 41);
            this.btnUpdate.TabIndex = 125;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(495, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(81, 41);
            this.btnFilter.TabIndex = 125;
            this.btnFilter.Text = "FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // scMain
            // 
            this.scMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.idtp_FilterEnd);
            this.scMain.Panel1.Controls.Add(this.idtp_FilterStart);
            this.scMain.Panel1.Controls.Add(this.chkOnlyNotChecked);
            this.scMain.Panel1.Controls.Add(this.label8);
            this.scMain.Panel1.Controls.Add(this.btnUpdate);
            this.scMain.Panel1.Controls.Add(this.btnFilter);
            this.scMain.Panel1.Controls.Add(this.dropFilterCategories);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pnlCalculator);
            this.scMain.Panel2.Controls.Add(this.grid);
            this.scMain.Panel2.Controls.Add(this.panel1);
            this.scMain.Size = new System.Drawing.Size(746, 591);
            this.scMain.SplitterDistance = 49;
            this.scMain.SplitterWidth = 1;
            this.scMain.TabIndex = 1;
            // 
            // idtp_FilterEnd
            // 
            this.idtp_FilterEnd.Checked = false;
            this.idtp_FilterEnd.CustomFormat = "ddd, dd/MM/yyyy";
            this.idtp_FilterEnd.DefaultCheckedValue = false;
            this.idtp_FilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_FilterEnd.LabelText = "End";
            this.idtp_FilterEnd.Location = new System.Drawing.Point(133, 3);
            this.idtp_FilterEnd.Name = "idtp_FilterEnd";
            this.idtp_FilterEnd.ShowCheckBox = true;
            this.idtp_FilterEnd.ShowUpAndDown = false;
            this.idtp_FilterEnd.Size = new System.Drawing.Size(130, 41);
            this.idtp_FilterEnd.TabIndex = 130;
            this.idtp_FilterEnd.Value = null;
            this.idtp_FilterEnd.ValueTimeSpan = null;
            // 
            // idtp_FilterStart
            // 
            this.idtp_FilterStart.Checked = true;
            this.idtp_FilterStart.CustomFormat = "ddd, dd/MM/yyyy";
            this.idtp_FilterStart.DefaultCheckedValue = true;
            this.idtp_FilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_FilterStart.LabelText = "Start";
            this.idtp_FilterStart.Location = new System.Drawing.Point(3, 3);
            this.idtp_FilterStart.Name = "idtp_FilterStart";
            this.idtp_FilterStart.ShowCheckBox = false;
            this.idtp_FilterStart.ShowUpAndDown = false;
            this.idtp_FilterStart.Size = new System.Drawing.Size(130, 41);
            this.idtp_FilterStart.TabIndex = 7;
            this.idtp_FilterStart.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_FilterStart.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // chkOnlyNotChecked
            // 
            this.chkOnlyNotChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOnlyNotChecked.AutoSize = true;
            this.chkOnlyNotChecked.Location = new System.Drawing.Point(403, 23);
            this.chkOnlyNotChecked.Name = "chkOnlyNotChecked";
            this.chkOnlyNotChecked.Size = new System.Drawing.Size(86, 17);
            this.chkOnlyNotChecked.TabIndex = 129;
            this.chkOnlyNotChecked.Text = "only NOT ok";
            this.chkOnlyNotChecked.UseVisualStyleBackColor = true;
            // 
            // pnlCalculator
            // 
            this.pnlCalculator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCalculator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalculator.Controls.Add(this.lbl5rb);
            this.pnlCalculator.Controls.Add(this.lbl10rb);
            this.pnlCalculator.Controls.Add(this.lbl20rb);
            this.pnlCalculator.Controls.Add(this.lbl50rb);
            this.pnlCalculator.Controls.Add(this.lbl100rb);
            this.pnlCalculator.Controls.Add(this.lbl100);
            this.pnlCalculator.Controls.Add(this.lbl200);
            this.pnlCalculator.Controls.Add(this.lbl500);
            this.pnlCalculator.Controls.Add(this.lbl1rb);
            this.pnlCalculator.Controls.Add(this.lbl2rb);
            this.pnlCalculator.Controls.Add(this.lblCalculatorBalance);
            this.pnlCalculator.Controls.Add(this.lblCalculatorBalanceDiff);
            this.pnlCalculator.Controls.Add(this.btnCloseCalculator);
            this.pnlCalculator.Controls.Add(this.btnResetCalculator);
            this.pnlCalculator.Controls.Add(this.lblCalculatorTotal);
            this.pnlCalculator.Controls.Add(this.label13);
            this.pnlCalculator.Controls.Add(this.in_100);
            this.pnlCalculator.Controls.Add(this.label12);
            this.pnlCalculator.Controls.Add(this.in_200);
            this.pnlCalculator.Controls.Add(this.label11);
            this.pnlCalculator.Controls.Add(this.in_500);
            this.pnlCalculator.Controls.Add(this.label10);
            this.pnlCalculator.Controls.Add(this.in_1rb);
            this.pnlCalculator.Controls.Add(this.label9);
            this.pnlCalculator.Controls.Add(this.in_2rb);
            this.pnlCalculator.Controls.Add(this.label7);
            this.pnlCalculator.Controls.Add(this.in_5rb);
            this.pnlCalculator.Controls.Add(this.label6);
            this.pnlCalculator.Controls.Add(this.label5);
            this.pnlCalculator.Controls.Add(this.label4);
            this.pnlCalculator.Controls.Add(this.label1);
            this.pnlCalculator.Controls.Add(this.in_10rb);
            this.pnlCalculator.Controls.Add(this.in_20rb);
            this.pnlCalculator.Controls.Add(this.in_50rb);
            this.pnlCalculator.Controls.Add(this.in_100rb);
            this.pnlCalculator.Location = new System.Drawing.Point(225, 186);
            this.pnlCalculator.Name = "pnlCalculator";
            this.pnlCalculator.Size = new System.Drawing.Size(294, 223);
            this.pnlCalculator.TabIndex = 7;
            this.pnlCalculator.Visible = false;
            // 
            // lblCalculatorBalance
            // 
            this.lblCalculatorBalance.Location = new System.Drawing.Point(125, 165);
            this.lblCalculatorBalance.Name = "lblCalculatorBalance";
            this.lblCalculatorBalance.Size = new System.Drawing.Size(159, 13);
            this.lblCalculatorBalance.TabIndex = 24;
            this.lblCalculatorBalance.Text = "BALANCE";
            this.lblCalculatorBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalculatorBalanceDiff
            // 
            this.lblCalculatorBalanceDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculatorBalanceDiff.Location = new System.Drawing.Point(69, 178);
            this.lblCalculatorBalanceDiff.Name = "lblCalculatorBalanceDiff";
            this.lblCalculatorBalanceDiff.Size = new System.Drawing.Size(218, 33);
            this.lblCalculatorBalanceDiff.TabIndex = 22;
            this.lblCalculatorBalanceDiff.Text = "0";
            this.lblCalculatorBalanceDiff.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnCloseCalculator
            // 
            this.btnCloseCalculator.Location = new System.Drawing.Point(12, 188);
            this.btnCloseCalculator.Name = "btnCloseCalculator";
            this.btnCloseCalculator.Size = new System.Drawing.Size(52, 23);
            this.btnCloseCalculator.TabIndex = 111;
            this.btnCloseCalculator.Text = "CLOSE";
            this.btnCloseCalculator.UseVisualStyleBackColor = true;
            this.btnCloseCalculator.Click += new System.EventHandler(this.btnCloseCalculator_Click);
            // 
            // btnResetCalculator
            // 
            this.btnResetCalculator.Location = new System.Drawing.Point(12, 165);
            this.btnResetCalculator.Name = "btnResetCalculator";
            this.btnResetCalculator.Size = new System.Drawing.Size(52, 23);
            this.btnResetCalculator.TabIndex = 110;
            this.btnResetCalculator.Text = "RESET";
            this.btnResetCalculator.UseVisualStyleBackColor = true;
            this.btnResetCalculator.Click += new System.EventHandler(this.btnResetCalculator_Click);
            // 
            // lblCalculatorTotal
            // 
            this.lblCalculatorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculatorTotal.Location = new System.Drawing.Point(8, 7);
            this.lblCalculatorTotal.Name = "lblCalculatorTotal";
            this.lblCalculatorTotal.Size = new System.Drawing.Size(283, 39);
            this.lblCalculatorTotal.TabIndex = 20;
            this.lblCalculatorTotal.Text = "0";
            this.lblCalculatorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(189, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "100";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_100
            // 
            this.in_100.Checked = false;
            this.in_100.DecimalPlaces = 0;
            this.in_100.HideUpDown = false;
            this.in_100.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_100.LabelText = "numeric";
            this.in_100.Location = new System.Drawing.Point(214, 137);
            this.in_100.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_100.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_100.Name = "in_100";
            this.in_100.ShowAllowDecimalCheckbox = false;
            this.in_100.ShowCheckbox = false;
            this.in_100.ShowTextboxOnly = true;
            this.in_100.Size = new System.Drawing.Size(67, 22);
            this.in_100.TabIndex = 109;
            this.in_100.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_100.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(189, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "200";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_200
            // 
            this.in_200.Checked = false;
            this.in_200.DecimalPlaces = 0;
            this.in_200.HideUpDown = false;
            this.in_200.Increment = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.in_200.LabelText = "numeric";
            this.in_200.Location = new System.Drawing.Point(214, 115);
            this.in_200.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_200.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_200.Name = "in_200";
            this.in_200.ShowAllowDecimalCheckbox = false;
            this.in_200.ShowCheckbox = false;
            this.in_200.ShowTextboxOnly = true;
            this.in_200.Size = new System.Drawing.Size(67, 22);
            this.in_200.TabIndex = 108;
            this.in_200.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_200.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "500";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_500
            // 
            this.in_500.Checked = false;
            this.in_500.DecimalPlaces = 0;
            this.in_500.HideUpDown = false;
            this.in_500.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.in_500.LabelText = "numeric";
            this.in_500.Location = new System.Drawing.Point(214, 93);
            this.in_500.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_500.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_500.Name = "in_500";
            this.in_500.ShowAllowDecimalCheckbox = false;
            this.in_500.ShowCheckbox = false;
            this.in_500.ShowTextboxOnly = true;
            this.in_500.Size = new System.Drawing.Size(67, 22);
            this.in_500.TabIndex = 107;
            this.in_500.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_500.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(192, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "1rb";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_1rb
            // 
            this.in_1rb.Checked = false;
            this.in_1rb.DecimalPlaces = 0;
            this.in_1rb.HideUpDown = false;
            this.in_1rb.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.in_1rb.LabelText = "numeric";
            this.in_1rb.Location = new System.Drawing.Point(214, 71);
            this.in_1rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_1rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_1rb.Name = "in_1rb";
            this.in_1rb.ShowAllowDecimalCheckbox = false;
            this.in_1rb.ShowCheckbox = false;
            this.in_1rb.ShowTextboxOnly = true;
            this.in_1rb.Size = new System.Drawing.Size(67, 22);
            this.in_1rb.TabIndex = 106;
            this.in_1rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_1rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "2rb";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_2rb
            // 
            this.in_2rb.Checked = false;
            this.in_2rb.DecimalPlaces = 0;
            this.in_2rb.HideUpDown = false;
            this.in_2rb.Increment = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.in_2rb.LabelText = "numeric";
            this.in_2rb.Location = new System.Drawing.Point(214, 49);
            this.in_2rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_2rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_2rb.Name = "in_2rb";
            this.in_2rb.ShowAllowDecimalCheckbox = false;
            this.in_2rb.ShowCheckbox = false;
            this.in_2rb.ShowTextboxOnly = true;
            this.in_2rb.Size = new System.Drawing.Size(67, 22);
            this.in_2rb.TabIndex = 105;
            this.in_2rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_2rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "5rb";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_5rb
            // 
            this.in_5rb.Checked = false;
            this.in_5rb.DecimalPlaces = 0;
            this.in_5rb.HideUpDown = false;
            this.in_5rb.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.in_5rb.LabelText = "numeric";
            this.in_5rb.Location = new System.Drawing.Point(69, 137);
            this.in_5rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_5rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_5rb.Name = "in_5rb";
            this.in_5rb.ShowAllowDecimalCheckbox = false;
            this.in_5rb.ShowCheckbox = false;
            this.in_5rb.ShowTextboxOnly = true;
            this.in_5rb.Size = new System.Drawing.Size(89, 22);
            this.in_5rb.TabIndex = 104;
            this.in_5rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_5rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "10rb";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "20rb";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "50rb";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "100rb";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // in_10rb
            // 
            this.in_10rb.Checked = false;
            this.in_10rb.DecimalPlaces = 0;
            this.in_10rb.HideUpDown = false;
            this.in_10rb.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_10rb.LabelText = "numeric";
            this.in_10rb.Location = new System.Drawing.Point(69, 115);
            this.in_10rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_10rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_10rb.Name = "in_10rb";
            this.in_10rb.ShowAllowDecimalCheckbox = false;
            this.in_10rb.ShowCheckbox = false;
            this.in_10rb.ShowTextboxOnly = true;
            this.in_10rb.Size = new System.Drawing.Size(89, 22);
            this.in_10rb.TabIndex = 103;
            this.in_10rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_10rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // in_20rb
            // 
            this.in_20rb.Checked = false;
            this.in_20rb.DecimalPlaces = 0;
            this.in_20rb.HideUpDown = false;
            this.in_20rb.Increment = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.in_20rb.LabelText = "numeric";
            this.in_20rb.Location = new System.Drawing.Point(69, 93);
            this.in_20rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_20rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_20rb.Name = "in_20rb";
            this.in_20rb.ShowAllowDecimalCheckbox = false;
            this.in_20rb.ShowCheckbox = false;
            this.in_20rb.ShowTextboxOnly = true;
            this.in_20rb.Size = new System.Drawing.Size(89, 22);
            this.in_20rb.TabIndex = 102;
            this.in_20rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_20rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // in_50rb
            // 
            this.in_50rb.Checked = false;
            this.in_50rb.DecimalPlaces = 0;
            this.in_50rb.HideUpDown = false;
            this.in_50rb.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.in_50rb.LabelText = "numeric";
            this.in_50rb.Location = new System.Drawing.Point(69, 71);
            this.in_50rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_50rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_50rb.Name = "in_50rb";
            this.in_50rb.ShowAllowDecimalCheckbox = false;
            this.in_50rb.ShowCheckbox = false;
            this.in_50rb.ShowTextboxOnly = true;
            this.in_50rb.Size = new System.Drawing.Size(89, 22);
            this.in_50rb.TabIndex = 101;
            this.in_50rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_50rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
            // 
            // in_100rb
            // 
            this.in_100rb.Checked = false;
            this.in_100rb.DecimalPlaces = 0;
            this.in_100rb.HideUpDown = false;
            this.in_100rb.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_100rb.LabelText = "numeric";
            this.in_100rb.Location = new System.Drawing.Point(69, 49);
            this.in_100rb.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_100rb.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_100rb.Name = "in_100rb";
            this.in_100rb.ShowAllowDecimalCheckbox = false;
            this.in_100rb.ShowCheckbox = false;
            this.in_100rb.ShowTextboxOnly = true;
            this.in_100rb.Size = new System.Drawing.Size(89, 22);
            this.in_100rb.TabIndex = 100;
            this.in_100rb.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_100rb.ValueChanged += new System.EventHandler(this.in_Calculator_ValueChanged);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_grid_id,
            this.col_grid_no,
            this.col_grid_timestamp,
            this.col_grid_categoryname,
            this.col_grid_notes,
            this.col_grid_amount,
            this.col_grid_balance,
            this.col_grid_IsChecked});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 39);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(744, 500);
            this.grid.TabIndex = 5;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // col_grid_id
            // 
            this.col_grid_id.HeaderText = "ID";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            // 
            // col_grid_no
            // 
            this.col_grid_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_no.HeaderText = "No";
            this.col_grid_no.MinimumWidth = 30;
            this.col_grid_no.Name = "col_grid_no";
            this.col_grid_no.ReadOnly = true;
            this.col_grid_no.Width = 30;
            // 
            // col_grid_timestamp
            // 
            this.col_grid_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.col_grid_timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_timestamp.HeaderText = "Time";
            this.col_grid_timestamp.MinimumWidth = 50;
            this.col_grid_timestamp.Name = "col_grid_timestamp";
            this.col_grid_timestamp.ReadOnly = true;
            this.col_grid_timestamp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_timestamp.Width = 50;
            // 
            // col_grid_categoryname
            // 
            this.col_grid_categoryname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_categoryname.HeaderText = "Category";
            this.col_grid_categoryname.MinimumWidth = 50;
            this.col_grid_categoryname.Name = "col_grid_categoryname";
            this.col_grid_categoryname.ReadOnly = true;
            this.col_grid_categoryname.Width = 50;
            // 
            // col_grid_notes
            // 
            this.col_grid_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_notes.HeaderText = "Notes";
            this.col_grid_notes.MinimumWidth = 50;
            this.col_grid_notes.Name = "col_grid_notes";
            this.col_grid_notes.ReadOnly = true;
            // 
            // col_grid_amount
            // 
            this.col_grid_amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_amount.HeaderText = "Amount";
            this.col_grid_amount.MinimumWidth = 50;
            this.col_grid_amount.Name = "col_grid_amount";
            this.col_grid_amount.ReadOnly = true;
            this.col_grid_amount.Width = 50;
            // 
            // col_grid_balance
            // 
            this.col_grid_balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_balance.HeaderText = "Balance";
            this.col_grid_balance.MinimumWidth = 50;
            this.col_grid_balance.Name = "col_grid_balance";
            this.col_grid_balance.ReadOnly = true;
            this.col_grid_balance.Width = 50;
            // 
            // col_grid_IsChecked
            // 
            this.col_grid_IsChecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_IsChecked.HeaderText = "OK";
            this.col_grid_IsChecked.MinimumWidth = 30;
            this.col_grid_IsChecked.Name = "col_grid_IsChecked";
            this.col_grid_IsChecked.ReadOnly = true;
            this.col_grid_IsChecked.Width = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCalculator);
            this.panel1.Controls.Add(this.in_Amount);
            this.panel1.Controls.Add(this.panelToggle1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAddPettyCashRecord);
            this.panel1.Controls.Add(this.dropCategories);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 39);
            this.panel1.TabIndex = 6;
            // 
            // btnCalculator
            // 
            this.btnCalculator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculator.Location = new System.Drawing.Point(697, 15);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(44, 21);
            this.btnCalculator.TabIndex = 124;
            this.btnCalculator.Text = "CALC";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // in_Amount
            // 
            this.in_Amount.Checked = false;
            this.in_Amount.DecimalPlaces = 0;
            this.in_Amount.HideUpDown = false;
            this.in_Amount.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_Amount.LabelText = "Amount";
            this.in_Amount.Location = new System.Drawing.Point(152, -3);
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
            this.in_Amount.TabIndex = 1;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panelToggle1
            // 
            this.panelToggle1.AdjustLocationOnClick = false;
            this.panelToggle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelToggle1.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Up;
            this.panelToggle1.Location = new System.Drawing.Point(0, 0);
            this.panelToggle1.Name = "panelToggle1";
            this.panelToggle1.Size = new System.Drawing.Size(35, 35);
            this.panelToggle1.TabIndex = 123;
            this.panelToggle1.TogglePanel = this.scMain.Panel1;
            // 
            // lbl2rb
            // 
            this.lbl2rb.AutoSize = true;
            this.lbl2rb.Location = new System.Drawing.Point(164, 54);
            this.lbl2rb.Name = "lbl2rb";
            this.lbl2rb.Size = new System.Drawing.Size(21, 13);
            this.lbl2rb.TabIndex = 112;
            this.lbl2rb.Text = "0 x";
            // 
            // lbl1rb
            // 
            this.lbl1rb.AutoSize = true;
            this.lbl1rb.Location = new System.Drawing.Point(164, 76);
            this.lbl1rb.Name = "lbl1rb";
            this.lbl1rb.Size = new System.Drawing.Size(21, 13);
            this.lbl1rb.TabIndex = 113;
            this.lbl1rb.Text = "0 x";
            // 
            // lbl500
            // 
            this.lbl500.AutoSize = true;
            this.lbl500.Location = new System.Drawing.Point(164, 98);
            this.lbl500.Name = "lbl500";
            this.lbl500.Size = new System.Drawing.Size(21, 13);
            this.lbl500.TabIndex = 114;
            this.lbl500.Text = "0 x";
            // 
            // lbl200
            // 
            this.lbl200.AutoSize = true;
            this.lbl200.Location = new System.Drawing.Point(164, 120);
            this.lbl200.Name = "lbl200";
            this.lbl200.Size = new System.Drawing.Size(21, 13);
            this.lbl200.TabIndex = 115;
            this.lbl200.Text = "0 x";
            // 
            // lbl100
            // 
            this.lbl100.AutoSize = true;
            this.lbl100.Location = new System.Drawing.Point(164, 142);
            this.lbl100.Name = "lbl100";
            this.lbl100.Size = new System.Drawing.Size(21, 13);
            this.lbl100.TabIndex = 116;
            this.lbl100.Text = "0 x";
            // 
            // lbl5rb
            // 
            this.lbl5rb.AutoSize = true;
            this.lbl5rb.Location = new System.Drawing.Point(12, 142);
            this.lbl5rb.Name = "lbl5rb";
            this.lbl5rb.Size = new System.Drawing.Size(21, 13);
            this.lbl5rb.TabIndex = 121;
            this.lbl5rb.Text = "0 x";
            // 
            // lbl10rb
            // 
            this.lbl10rb.AutoSize = true;
            this.lbl10rb.Location = new System.Drawing.Point(12, 120);
            this.lbl10rb.Name = "lbl10rb";
            this.lbl10rb.Size = new System.Drawing.Size(21, 13);
            this.lbl10rb.TabIndex = 120;
            this.lbl10rb.Text = "0 x";
            // 
            // lbl20rb
            // 
            this.lbl20rb.AutoSize = true;
            this.lbl20rb.Location = new System.Drawing.Point(12, 98);
            this.lbl20rb.Name = "lbl20rb";
            this.lbl20rb.Size = new System.Drawing.Size(21, 13);
            this.lbl20rb.TabIndex = 119;
            this.lbl20rb.Text = "0 x";
            // 
            // lbl50rb
            // 
            this.lbl50rb.AutoSize = true;
            this.lbl50rb.Location = new System.Drawing.Point(12, 76);
            this.lbl50rb.Name = "lbl50rb";
            this.lbl50rb.Size = new System.Drawing.Size(21, 13);
            this.lbl50rb.TabIndex = 118;
            this.lbl50rb.Text = "0 x";
            // 
            // lbl100rb
            // 
            this.lbl100rb.AutoSize = true;
            this.lbl100rb.Location = new System.Drawing.Point(12, 54);
            this.lbl100rb.Name = "lbl100rb";
            this.lbl100rb.Size = new System.Drawing.Size(21, 13);
            this.lbl100rb.TabIndex = 117;
            this.lbl100rb.Text = "0 x";
            // 
            // PettyCash_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 591);
            this.Controls.Add(this.scMain);
            this.Name = "PettyCash_Form";
            this.Text = "Petty Cash";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.PettyCash_Form_Shown);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlCalculator.ResumeLayout(false);
            this.pnlCalculator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dropCategories;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPettyCashRecord;
        private System.Windows.Forms.ComboBox dropFilterCategories;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_categoryname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_balance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_IsChecked;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private LIBUtil.Desktop.UserControls.PanelToggle panelToggle1;
        private System.Windows.Forms.CheckBox chkOnlyNotChecked;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_FilterEnd;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_FilterStart;
        private System.Windows.Forms.Panel pnlCalculator;
        private System.Windows.Forms.Label label13;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_100;
        private System.Windows.Forms.Label label12;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_200;
        private System.Windows.Forms.Label label11;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_500;
        private System.Windows.Forms.Label label10;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_1rb;
        private System.Windows.Forms.Label label9;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_2rb;
        private System.Windows.Forms.Label label7;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_5rb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_10rb;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_20rb;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_50rb;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_100rb;
        private System.Windows.Forms.Label lblCalculatorTotal;
        private System.Windows.Forms.Button btnResetCalculator;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnCloseCalculator;
        private System.Windows.Forms.Label lblCalculatorBalanceDiff;
        private System.Windows.Forms.Label lblCalculatorBalance;
        private System.Windows.Forms.Label lbl5rb;
        private System.Windows.Forms.Label lbl10rb;
        private System.Windows.Forms.Label lbl20rb;
        private System.Windows.Forms.Label lbl50rb;
        private System.Windows.Forms.Label lbl100rb;
        private System.Windows.Forms.Label lbl100;
        private System.Windows.Forms.Label lbl200;
        private System.Windows.Forms.Label lbl500;
        private System.Windows.Forms.Label lbl1rb;
        private System.Windows.Forms.Label lbl2rb;
    }
}