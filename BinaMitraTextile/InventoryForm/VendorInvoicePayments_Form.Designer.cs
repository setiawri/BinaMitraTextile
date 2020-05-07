﻿namespace BinaMitraTextile.InventoryForm
{
    partial class VendorInvoicePayments_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorInvoicePayments_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridVendorInvoicePaymentItems = new System.Windows.Forms.DataGridView();
            this.pnlFilterAndButtons = new System.Windows.Forms.Panel();
            this.pnlFilterAndButtonsContent = new System.Windows.Forms.Panel();
            this.pnlFilterAndButtonsHeader = new System.Windows.Forms.Panel();
            this.pnlQuickSearch = new System.Windows.Forms.Panel();
            this.pbLog = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.chkShowOnlyLast3Months = new System.Windows.Forms.CheckBox();
            this.itxt_QuickSearch = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.chkShowUnapprovedOnly = new System.Windows.Forms.CheckBox();
            this.ptInputPanel = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.gridVendorInvoicePayments = new System.Windows.Forms.DataGridView();
            this.pnlRowInfo = new System.Windows.Forms.Panel();
            this.pnlRowInfoHeaderContainer = new System.Windows.Forms.Panel();
            this.pnlRowInfoHeader = new System.Windows.Forms.Panel();
            this.ptRowInfo = new LIBUtil.Desktop.UserControls.PanelToggle();
            this.col_gridVendorInvoicePayments_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_Cancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_gridVendorInvoicePayments_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_Vendors_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePayments_Approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblRowInfoHeader = new System.Windows.Forms.Label();
            this.col_gridVendorInvoicePaymentItems_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePaymentItems_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridVendorInvoicePaymentItems_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoicePaymentItems)).BeginInit();
            this.pnlFilterAndButtons.SuspendLayout();
            this.pnlFilterAndButtonsHeader.SuspendLayout();
            this.pnlQuickSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoicePayments)).BeginInit();
            this.pnlRowInfo.SuspendLayout();
            this.pnlRowInfoHeaderContainer.SuspendLayout();
            this.pnlRowInfoHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridVendorInvoicePaymentItems
            // 
            this.gridVendorInvoicePaymentItems.AllowUserToAddRows = false;
            this.gridVendorInvoicePaymentItems.AllowUserToDeleteRows = false;
            this.gridVendorInvoicePaymentItems.AllowUserToResizeRows = false;
            this.gridVendorInvoicePaymentItems.BackgroundColor = System.Drawing.Color.White;
            this.gridVendorInvoicePaymentItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridVendorInvoicePaymentItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVendorInvoicePaymentItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVendorInvoicePaymentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendorInvoicePaymentItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridVendorInvoicePaymentItems_Id,
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id,
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No,
            this.col_gridVendorInvoicePaymentItems_Amount,
            this.col_gridVendorInvoicePaymentItems_Notes});
            this.gridVendorInvoicePaymentItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVendorInvoicePaymentItems.Location = new System.Drawing.Point(0, 21);
            this.gridVendorInvoicePaymentItems.Name = "gridVendorInvoicePaymentItems";
            this.gridVendorInvoicePaymentItems.RowHeadersVisible = false;
            this.gridVendorInvoicePaymentItems.Size = new System.Drawing.Size(685, 142);
            this.gridVendorInvoicePaymentItems.TabIndex = 6;
            this.gridVendorInvoicePaymentItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVendorInvoicePaymentItems_CellContentClick);
            // 
            // pnlFilterAndButtons
            // 
            this.pnlFilterAndButtons.Controls.Add(this.pnlFilterAndButtonsContent);
            this.pnlFilterAndButtons.Controls.Add(this.pnlFilterAndButtonsHeader);
            this.pnlFilterAndButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterAndButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterAndButtons.Name = "pnlFilterAndButtons";
            this.pnlFilterAndButtons.Size = new System.Drawing.Size(685, 76);
            this.pnlFilterAndButtons.TabIndex = 7;
            // 
            // pnlFilterAndButtonsContent
            // 
            this.pnlFilterAndButtonsContent.BackColor = System.Drawing.Color.White;
            this.pnlFilterAndButtonsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterAndButtonsContent.Location = new System.Drawing.Point(0, 0);
            this.pnlFilterAndButtonsContent.Name = "pnlFilterAndButtonsContent";
            this.pnlFilterAndButtonsContent.Size = new System.Drawing.Size(685, 48);
            this.pnlFilterAndButtonsContent.TabIndex = 9;
            // 
            // pnlFilterAndButtonsHeader
            // 
            this.pnlFilterAndButtonsHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilterAndButtonsHeader.Controls.Add(this.pnlQuickSearch);
            this.pnlFilterAndButtonsHeader.Controls.Add(this.ptInputPanel);
            this.pnlFilterAndButtonsHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFilterAndButtonsHeader.Location = new System.Drawing.Point(0, 48);
            this.pnlFilterAndButtonsHeader.Name = "pnlFilterAndButtonsHeader";
            this.pnlFilterAndButtonsHeader.Size = new System.Drawing.Size(685, 28);
            this.pnlFilterAndButtonsHeader.TabIndex = 116;
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickSearch.Controls.Add(this.pbLog);
            this.pnlQuickSearch.Controls.Add(this.pbRefresh);
            this.pnlQuickSearch.Controls.Add(this.chkShowOnlyLast3Months);
            this.pnlQuickSearch.Controls.Add(this.itxt_QuickSearch);
            this.pnlQuickSearch.Controls.Add(this.chkShowUnapprovedOnly);
            this.pnlQuickSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuickSearch.Location = new System.Drawing.Point(30, 0);
            this.pnlQuickSearch.Name = "pnlQuickSearch";
            this.pnlQuickSearch.Size = new System.Drawing.Size(655, 28);
            this.pnlQuickSearch.TabIndex = 97;
            // 
            // pbLog
            // 
            this.pbLog.BackColor = System.Drawing.Color.White;
            this.pbLog.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLog.BackgroundImage")));
            this.pbLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLog.Location = new System.Drawing.Point(28, 0);
            this.pbLog.Name = "pbLog";
            this.pbLog.Size = new System.Drawing.Size(28, 26);
            this.pbLog.TabIndex = 17;
            this.pbLog.TabStop = false;
            this.pbLog.Click += new System.EventHandler(this.PbLog_Click);
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
            this.pbRefresh.Size = new System.Drawing.Size(28, 26);
            this.pbRefresh.TabIndex = 9;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.PbRefresh_Click);
            // 
            // chkShowOnlyLast3Months
            // 
            this.chkShowOnlyLast3Months.AutoSize = true;
            this.chkShowOnlyLast3Months.Checked = true;
            this.chkShowOnlyLast3Months.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowOnlyLast3Months.Location = new System.Drawing.Point(182, 6);
            this.chkShowOnlyLast3Months.Name = "chkShowOnlyLast3Months";
            this.chkShowOnlyLast3Months.Size = new System.Drawing.Size(88, 17);
            this.chkShowOnlyLast3Months.TabIndex = 16;
            this.chkShowOnlyLast3Months.TabStop = false;
            this.chkShowOnlyLast3Months.Text = "last 3 months";
            this.chkShowOnlyLast3Months.UseVisualStyleBackColor = true;
            this.chkShowOnlyLast3Months.CheckedChanged += new System.EventHandler(this.ChkShowOnlyLast3Months_CheckedChanged);
            // 
            // itxt_QuickSearch
            // 
            this.itxt_QuickSearch.IsBrowseMode = false;
            this.itxt_QuickSearch.LabelText = "textbox";
            this.itxt_QuickSearch.Location = new System.Drawing.Point(58, 3);
            this.itxt_QuickSearch.MaxLength = 32767;
            this.itxt_QuickSearch.MultiLine = false;
            this.itxt_QuickSearch.Name = "itxt_QuickSearch";
            this.itxt_QuickSearch.PasswordChar = '\0';
            this.itxt_QuickSearch.RowCount = 1;
            this.itxt_QuickSearch.ShowDeleteButton = true;
            this.itxt_QuickSearch.ShowFilter = false;
            this.itxt_QuickSearch.ShowTextboxOnly = true;
            this.itxt_QuickSearch.Size = new System.Drawing.Size(118, 21);
            this.itxt_QuickSearch.TabIndex = 14;
            this.itxt_QuickSearch.ValueText = "";
            this.itxt_QuickSearch.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.Itxt_QuickSearch_onKeyDown);
            // 
            // chkShowUnapprovedOnly
            // 
            this.chkShowUnapprovedOnly.AutoSize = true;
            this.chkShowUnapprovedOnly.Checked = true;
            this.chkShowUnapprovedOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowUnapprovedOnly.Location = new System.Drawing.Point(270, 6);
            this.chkShowUnapprovedOnly.Name = "chkShowUnapprovedOnly";
            this.chkShowUnapprovedOnly.Size = new System.Drawing.Size(105, 17);
            this.chkShowUnapprovedOnly.TabIndex = 1;
            this.chkShowUnapprovedOnly.TabStop = false;
            this.chkShowUnapprovedOnly.Text = "only unapproved";
            this.chkShowUnapprovedOnly.UseVisualStyleBackColor = true;
            this.chkShowUnapprovedOnly.CheckedChanged += new System.EventHandler(this.ChkShowOnlyApproved_CheckedChanged);
            // 
            // ptInputPanel
            // 
            this.ptInputPanel.AdjustLocationOnClick = false;
            this.ptInputPanel.BackColor = System.Drawing.Color.White;
            this.ptInputPanel.ContainerPanel = this.pnlFilterAndButtons;
            this.ptInputPanel.ContainerPanelOriginalSize = new System.Drawing.Size(0, 0);
            this.ptInputPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptInputPanel.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Up;
            this.ptInputPanel.Location = new System.Drawing.Point(0, 0);
            this.ptInputPanel.Name = "ptInputPanel";
            this.ptInputPanel.Size = new System.Drawing.Size(30, 28);
            this.ptInputPanel.TabIndex = 96;
            this.ptInputPanel.TogglePanel = null;
            // 
            // gridVendorInvoicePayments
            // 
            this.gridVendorInvoicePayments.AllowUserToAddRows = false;
            this.gridVendorInvoicePayments.AllowUserToDeleteRows = false;
            this.gridVendorInvoicePayments.AllowUserToResizeRows = false;
            this.gridVendorInvoicePayments.BackgroundColor = System.Drawing.Color.White;
            this.gridVendorInvoicePayments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVendorInvoicePayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridVendorInvoicePayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendorInvoicePayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridVendorInvoicePayments_Id,
            this.col_gridVendorInvoicePayments_Cancelled,
            this.col_gridVendorInvoicePayments_Timestamp,
            this.col_gridVendorInvoicePayments_Vendors_Name,
            this.col_gridVendorInvoicePayments_No,
            this.col_gridVendorInvoicePayments_Amount,
            this.col_gridVendorInvoicePayments_Notes,
            this.col_gridVendorInvoicePayments_Approved});
            this.gridVendorInvoicePayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVendorInvoicePayments.Location = new System.Drawing.Point(0, 76);
            this.gridVendorInvoicePayments.Name = "gridVendorInvoicePayments";
            this.gridVendorInvoicePayments.RowHeadersVisible = false;
            this.gridVendorInvoicePayments.Size = new System.Drawing.Size(685, 322);
            this.gridVendorInvoicePayments.TabIndex = 6;
            this.gridVendorInvoicePayments.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVendorInvoicePayments_CellDoubleClick);
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Controls.Add(this.gridVendorInvoicePaymentItems);
            this.pnlRowInfo.Controls.Add(this.pnlRowInfoHeaderContainer);
            this.pnlRowInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRowInfo.Location = new System.Drawing.Point(0, 398);
            this.pnlRowInfo.Name = "pnlRowInfo";
            this.pnlRowInfo.Size = new System.Drawing.Size(685, 163);
            this.pnlRowInfo.TabIndex = 8;
            // 
            // pnlRowInfoHeaderContainer
            // 
            this.pnlRowInfoHeaderContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlRowInfoHeaderContainer.Controls.Add(this.pnlRowInfoHeader);
            this.pnlRowInfoHeaderContainer.Controls.Add(this.ptRowInfo);
            this.pnlRowInfoHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRowInfoHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlRowInfoHeaderContainer.Name = "pnlRowInfoHeaderContainer";
            this.pnlRowInfoHeaderContainer.Size = new System.Drawing.Size(685, 21);
            this.pnlRowInfoHeaderContainer.TabIndex = 1;
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRowInfoHeader.Controls.Add(this.lblRowInfoHeader);
            this.pnlRowInfoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRowInfoHeader.Location = new System.Drawing.Point(20, 0);
            this.pnlRowInfoHeader.Name = "pnlRowInfoHeader";
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(665, 21);
            this.pnlRowInfoHeader.TabIndex = 6;
            // 
            // ptRowInfo
            // 
            this.ptRowInfo.AdjustLocationOnClick = true;
            this.ptRowInfo.BackColor = System.Drawing.Color.White;
            this.ptRowInfo.ContainerPanel = this.pnlRowInfo;
            this.ptRowInfo.ContainerPanelOriginalSize = new System.Drawing.Size(0, 0);
            this.ptRowInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptRowInfo.InitialArrowDirection = System.Windows.Forms.ArrowDirection.Down;
            this.ptRowInfo.Location = new System.Drawing.Point(0, 0);
            this.ptRowInfo.Name = "ptRowInfo";
            this.ptRowInfo.Size = new System.Drawing.Size(20, 21);
            this.ptRowInfo.TabIndex = 5;
            this.ptRowInfo.TogglePanel = null;
            // 
            // col_gridVendorInvoicePayments_Id
            // 
            this.col_gridVendorInvoicePayments_Id.HeaderText = "id";
            this.col_gridVendorInvoicePayments_Id.Name = "col_gridVendorInvoicePayments_Id";
            this.col_gridVendorInvoicePayments_Id.ReadOnly = true;
            this.col_gridVendorInvoicePayments_Id.Visible = false;
            // 
            // col_gridVendorInvoicePayments_Cancelled
            // 
            this.col_gridVendorInvoicePayments_Cancelled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridVendorInvoicePayments_Cancelled.HeaderText = "Cancel";
            this.col_gridVendorInvoicePayments_Cancelled.MinimumWidth = 40;
            this.col_gridVendorInvoicePayments_Cancelled.Name = "col_gridVendorInvoicePayments_Cancelled";
            this.col_gridVendorInvoicePayments_Cancelled.Width = 40;
            // 
            // col_gridVendorInvoicePayments_Timestamp
            // 
            this.col_gridVendorInvoicePayments_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Format = "dd/MM/yy";
            this.col_gridVendorInvoicePayments_Timestamp.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridVendorInvoicePayments_Timestamp.HeaderText = "Date";
            this.col_gridVendorInvoicePayments_Timestamp.MinimumWidth = 40;
            this.col_gridVendorInvoicePayments_Timestamp.Name = "col_gridVendorInvoicePayments_Timestamp";
            this.col_gridVendorInvoicePayments_Timestamp.ReadOnly = true;
            this.col_gridVendorInvoicePayments_Timestamp.Width = 40;
            // 
            // col_gridVendorInvoicePayments_Vendors_Name
            // 
            this.col_gridVendorInvoicePayments_Vendors_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridVendorInvoicePayments_Vendors_Name.HeaderText = "Vendor";
            this.col_gridVendorInvoicePayments_Vendors_Name.MinimumWidth = 45;
            this.col_gridVendorInvoicePayments_Vendors_Name.Name = "col_gridVendorInvoicePayments_Vendors_Name";
            this.col_gridVendorInvoicePayments_Vendors_Name.ReadOnly = true;
            this.col_gridVendorInvoicePayments_Vendors_Name.Width = 45;
            // 
            // col_gridVendorInvoicePayments_No
            // 
            this.col_gridVendorInvoicePayments_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridVendorInvoicePayments_No.HeaderText = "No";
            this.col_gridVendorInvoicePayments_No.MinimumWidth = 40;
            this.col_gridVendorInvoicePayments_No.Name = "col_gridVendorInvoicePayments_No";
            this.col_gridVendorInvoicePayments_No.ReadOnly = true;
            this.col_gridVendorInvoicePayments_No.Width = 40;
            // 
            // col_gridVendorInvoicePayments_Amount
            // 
            this.col_gridVendorInvoicePayments_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.col_gridVendorInvoicePayments_Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_gridVendorInvoicePayments_Amount.HeaderText = "Amount";
            this.col_gridVendorInvoicePayments_Amount.MinimumWidth = 45;
            this.col_gridVendorInvoicePayments_Amount.Name = "col_gridVendorInvoicePayments_Amount";
            this.col_gridVendorInvoicePayments_Amount.ReadOnly = true;
            this.col_gridVendorInvoicePayments_Amount.Width = 45;
            // 
            // col_gridVendorInvoicePayments_Notes
            // 
            this.col_gridVendorInvoicePayments_Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridVendorInvoicePayments_Notes.HeaderText = "Notes";
            this.col_gridVendorInvoicePayments_Notes.MinimumWidth = 50;
            this.col_gridVendorInvoicePayments_Notes.Name = "col_gridVendorInvoicePayments_Notes";
            this.col_gridVendorInvoicePayments_Notes.ReadOnly = true;
            // 
            // col_gridVendorInvoicePayments_Approved
            // 
            this.col_gridVendorInvoicePayments_Approved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridVendorInvoicePayments_Approved.HeaderText = "OK";
            this.col_gridVendorInvoicePayments_Approved.MinimumWidth = 30;
            this.col_gridVendorInvoicePayments_Approved.Name = "col_gridVendorInvoicePayments_Approved";
            this.col_gridVendorInvoicePayments_Approved.ReadOnly = true;
            this.col_gridVendorInvoicePayments_Approved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridVendorInvoicePayments_Approved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridVendorInvoicePayments_Approved.Width = 30;
            // 
            // lblRowInfoHeader
            // 
            this.lblRowInfoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRowInfoHeader.Location = new System.Drawing.Point(0, 0);
            this.lblRowInfoHeader.Name = "lblRowInfoHeader";
            this.lblRowInfoHeader.Size = new System.Drawing.Size(663, 19);
            this.lblRowInfoHeader.TabIndex = 108;
            this.lblRowInfoHeader.Text = "lblRowInfoHeader";
            this.lblRowInfoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // col_gridVendorInvoicePaymentItems_Id
            // 
            this.col_gridVendorInvoicePaymentItems_Id.HeaderText = "Id";
            this.col_gridVendorInvoicePaymentItems_Id.Name = "col_gridVendorInvoicePaymentItems_Id";
            this.col_gridVendorInvoicePaymentItems_Id.ReadOnly = true;
            this.col_gridVendorInvoicePaymentItems_Id.Visible = false;
            // 
            // col_gridVendorInvoicePaymentItems_VendorInvoices_Id
            // 
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id.HeaderText = "VendorInvoices_Id";
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id.Name = "col_gridVendorInvoicePaymentItems_VendorInvoices_Id";
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id.ReadOnly = true;
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_Id.Visible = false;
            // 
            // col_gridVendorInvoicePaymentItems_VendorInvoices_No
            // 
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.HeaderText = "Invoice";
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.MinimumWidth = 50;
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.Name = "col_gridVendorInvoicePaymentItems_VendorInvoices_No";
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.ReadOnly = true;
            this.col_gridVendorInvoicePaymentItems_VendorInvoices_No.Width = 50;
            // 
            // col_gridVendorInvoicePaymentItems_Amount
            // 
            this.col_gridVendorInvoicePaymentItems_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.col_gridVendorInvoicePaymentItems_Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridVendorInvoicePaymentItems_Amount.HeaderText = "Amount";
            this.col_gridVendorInvoicePaymentItems_Amount.MinimumWidth = 50;
            this.col_gridVendorInvoicePaymentItems_Amount.Name = "col_gridVendorInvoicePaymentItems_Amount";
            this.col_gridVendorInvoicePaymentItems_Amount.ReadOnly = true;
            this.col_gridVendorInvoicePaymentItems_Amount.Width = 50;
            // 
            // col_gridVendorInvoicePaymentItems_Notes
            // 
            this.col_gridVendorInvoicePaymentItems_Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridVendorInvoicePaymentItems_Notes.HeaderText = "Notes";
            this.col_gridVendorInvoicePaymentItems_Notes.MinimumWidth = 40;
            this.col_gridVendorInvoicePaymentItems_Notes.Name = "col_gridVendorInvoicePaymentItems_Notes";
            this.col_gridVendorInvoicePaymentItems_Notes.ReadOnly = true;
            // 
            // VendorInvoicePayments_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 561);
            this.Controls.Add(this.gridVendorInvoicePayments);
            this.Controls.Add(this.pnlRowInfo);
            this.Controls.Add(this.pnlFilterAndButtons);
            this.Name = "VendorInvoicePayments_Form";
            this.Text = "VENDOR INVOICE PAYMENTS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoicePaymentItems)).EndInit();
            this.pnlFilterAndButtons.ResumeLayout(false);
            this.pnlFilterAndButtonsHeader.ResumeLayout(false);
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVendorInvoicePayments)).EndInit();
            this.pnlRowInfo.ResumeLayout(false);
            this.pnlRowInfoHeaderContainer.ResumeLayout(false);
            this.pnlRowInfoHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridVendorInvoicePaymentItems;
        private System.Windows.Forms.Panel pnlFilterAndButtons;
        protected System.Windows.Forms.Panel pnlFilterAndButtonsHeader;
        protected System.Windows.Forms.Panel pnlQuickSearch;
        public System.Windows.Forms.CheckBox chkShowUnapprovedOnly;
        public LIBUtil.Desktop.UserControls.PanelToggle ptInputPanel;
        private System.Windows.Forms.DataGridView gridVendorInvoicePayments;
        private System.Windows.Forms.Panel pnlRowInfo;
        private System.Windows.Forms.Panel pnlRowInfoHeaderContainer;
        protected System.Windows.Forms.Panel pnlRowInfoHeader;
        protected LIBUtil.Desktop.UserControls.PanelToggle ptRowInfo;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_QuickSearch;
        private System.Windows.Forms.Panel pnlFilterAndButtonsContent;
        public System.Windows.Forms.CheckBox chkShowOnlyLast3Months;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.PictureBox pbLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_gridVendorInvoicePayments_Cancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_Vendors_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePayments_Notes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_gridVendorInvoicePayments_Approved;
        private System.Windows.Forms.Label lblRowInfoHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePaymentItems_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePaymentItems_VendorInvoices_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePaymentItems_VendorInvoices_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePaymentItems_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridVendorInvoicePaymentItems_Notes;
    }
}