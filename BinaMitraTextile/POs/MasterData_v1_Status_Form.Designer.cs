﻿namespace BinaMitraTextile.POs
{
    partial class MasterData_v1_Status_Form
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
            this.idtp_ExpectedDeliveryDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.chkShowHidden = new System.Windows.Forms.CheckBox();
            this.chkShowCustomerName = new System.Windows.Forms.CheckBox();
            this.in_PriorityQty = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_PriorityNo = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.iddl_POItemStatus = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.panel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.Panel1.SuspendLayout();
            this.scInputLeft.Panel2.SuspendLayout();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).BeginInit();
            this.scInputContainer.Panel1.SuspendLayout();
            this.scInputContainer.Panel2.SuspendLayout();
            this.scInputContainer.SuspendLayout();
            this.pnlQuickSearch.SuspendLayout();
            this.pnlRowInfo.SuspendLayout();
            this.pnlRowInfoHeaderContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).BeginInit();
            this.scContent.Panel2.SuspendLayout();
            this.scContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1112, 34);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 102);
            this.pnlActionButtons.Margin = new System.Windows.Forms.Padding(5);
            this.pnlActionButtons.Size = new System.Drawing.Size(1112, 28);
            // 
            // scInputLeft
            // 
            this.scInputLeft.Margin = new System.Windows.Forms.Padding(5);
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.iddl_POItemStatus);
            this.scInputLeft.Panel1.Controls.Add(this.in_PriorityNo);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.idtp_ExpectedDeliveryDate);
            this.scInputLeft.Panel2.Controls.Add(this.in_PriorityQty);
            this.scInputLeft.Size = new System.Drawing.Size(520, 70);
            this.scInputLeft.SplitterWidth = 7;
            // 
            // scInputRight
            // 
            this.scInputRight.Margin = new System.Windows.Forms.Padding(5);
            this.scInputRight.Size = new System.Drawing.Size(585, 70);
            this.scInputRight.SplitterWidth = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnCancel
            // 
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            // 
            // btnReset
            // 
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            // 
            // scMain
            // 
            this.scMain.Margin = new System.Windows.Forms.Padding(5);
            this.scMain.Size = new System.Drawing.Size(1112, 554);
            this.scMain.SplitterDistance = 130;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(5);
            this.pnlButtons.Size = new System.Drawing.Size(1112, 32);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Margin = new System.Windows.Forms.Padding(5);
            this.scInputContainer.Size = new System.Drawing.Size(1112, 70);
            this.scInputContainer.SplitterDistance = 520;
            this.scInputContainer.SplitterWidth = 7;
            // 
            // ptInputPanel
            // 
            this.ptInputPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkShowHidden);
            this.pnlQuickSearch.Controls.Add(this.chkShowCustomerName);
            this.pnlQuickSearch.Margin = new System.Windows.Forms.Padding(5);
            this.pnlQuickSearch.Size = new System.Drawing.Size(1078, 34);
            this.pnlQuickSearch.Controls.SetChildIndex(this.pbRefresh, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.pbLog, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.itxt_QuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkShowCustomerName, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkShowHidden, 0);
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Margin = new System.Windows.Forms.Padding(5);
            this.pnlRowInfo.Size = new System.Drawing.Size(1112, 187);
            // 
            // pnlRowInfoHeaderContainer
            // 
            this.pnlRowInfoHeaderContainer.Margin = new System.Windows.Forms.Padding(5);
            this.pnlRowInfoHeaderContainer.Size = new System.Drawing.Size(1112, 26);
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.Margin = new System.Windows.Forms.Padding(5);
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(1086, 26);
            // 
            // ptRowInfo
            // 
            this.ptRowInfo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            // 
            // pnlRowInfoContent
            // 
            this.pnlRowInfoContent.Margin = new System.Windows.Forms.Padding(5);
            this.pnlRowInfoContent.Size = new System.Drawing.Size(1112, 161);
            // 
            // pbLog
            // 
            this.pbLog.Margin = new System.Windows.Forms.Padding(5);
            this.pbLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.Margin = new System.Windows.Forms.Padding(5);
            // 
            // itxt_QuickSearch
            // 
            this.itxt_QuickSearch.ShowDeleteButton = true;
            // 
            // scContent
            // 
            this.scContent.Margin = new System.Windows.Forms.Padding(4);
            this.scContent.Size = new System.Drawing.Size(1112, 389);
            this.scContent.SplitterDistance = 197;
            this.scContent.SplitterWidth = 5;
            // 
            // idtp_ExpectedDeliveryDate
            // 
            this.idtp_ExpectedDeliveryDate.Checked = true;
            this.idtp_ExpectedDeliveryDate.CustomFormat = "ddd dd/MM";
            this.idtp_ExpectedDeliveryDate.DefaultCheckedValue = false;
            this.idtp_ExpectedDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_ExpectedDeliveryDate.LabelText = "Expected Delivery";
            this.idtp_ExpectedDeliveryDate.Location = new System.Drawing.Point(109, 10);
            this.idtp_ExpectedDeliveryDate.Margin = new System.Windows.Forms.Padding(5);
            this.idtp_ExpectedDeliveryDate.Name = "idtp_ExpectedDeliveryDate";
            this.idtp_ExpectedDeliveryDate.ShowCheckBox = true;
            this.idtp_ExpectedDeliveryDate.ShowDateTimePickerOnly = false;
            this.idtp_ExpectedDeliveryDate.ShowUpAndDown = false;
            this.idtp_ExpectedDeliveryDate.Size = new System.Drawing.Size(149, 50);
            this.idtp_ExpectedDeliveryDate.TabIndex = 0;
            this.idtp_ExpectedDeliveryDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_ExpectedDeliveryDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // chkShowHidden
            // 
            this.chkShowHidden.AutoSize = true;
            this.chkShowHidden.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkShowHidden.Location = new System.Drawing.Point(277, 0);
            this.chkShowHidden.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowHidden.Name = "chkShowHidden";
            this.chkShowHidden.Size = new System.Drawing.Size(33, 32);
            this.chkShowHidden.TabIndex = 14;
            this.chkShowHidden.Text = "X";
            this.chkShowHidden.UseVisualStyleBackColor = true;
            this.chkShowHidden.Visible = false;
            this.chkShowHidden.CheckedChanged += new System.EventHandler(this.chkShowHidden_CheckedChanged);
            this.chkShowHidden.Click += new System.EventHandler(this.chkShowHidden_CheckedChanged);
            // 
            // chkShowCustomerName
            // 
            this.chkShowCustomerName.AutoSize = true;
            this.chkShowCustomerName.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkShowCustomerName.Location = new System.Drawing.Point(1006, 0);
            this.chkShowCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowCustomerName.Name = "chkShowCustomerName";
            this.chkShowCustomerName.Size = new System.Drawing.Size(70, 32);
            this.chkShowCustomerName.TabIndex = 15;
            this.chkShowCustomerName.Text = "Customer";
            this.chkShowCustomerName.UseVisualStyleBackColor = true;
            this.chkShowCustomerName.CheckedChanged += new System.EventHandler(this.ChkShowCustomerName_CheckedChanged);
            this.chkShowCustomerName.Click += new System.EventHandler(this.ChkShowCustomerName_CheckedChanged);
            // 
            // in_PriorityQty
            // 
            this.in_PriorityQty.Checked = false;
            this.in_PriorityQty.DecimalPlaces = 0;
            this.in_PriorityQty.HideUpDown = false;
            this.in_PriorityQty.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_PriorityQty.LabelText = "Qty";
            this.in_PriorityQty.Location = new System.Drawing.Point(4, 10);
            this.in_PriorityQty.Margin = new System.Windows.Forms.Padding(5);
            this.in_PriorityQty.MaximumValue = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.in_PriorityQty.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_PriorityQty.Name = "in_PriorityQty";
            this.in_PriorityQty.ShowAllowDecimalCheckbox = false;
            this.in_PriorityQty.ShowCheckbox = false;
            this.in_PriorityQty.ShowTextboxOnly = false;
            this.in_PriorityQty.Size = new System.Drawing.Size(95, 50);
            this.in_PriorityQty.TabIndex = 2;
            this.in_PriorityQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // in_PriorityNo
            // 
            this.in_PriorityNo.Checked = false;
            this.in_PriorityNo.DecimalPlaces = 0;
            this.in_PriorityNo.HideUpDown = false;
            this.in_PriorityNo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_PriorityNo.LabelText = "Priority";
            this.in_PriorityNo.Location = new System.Drawing.Point(182, 10);
            this.in_PriorityNo.Margin = new System.Windows.Forms.Padding(5);
            this.in_PriorityNo.MaximumValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.in_PriorityNo.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_PriorityNo.Name = "in_PriorityNo";
            this.in_PriorityNo.ShowAllowDecimalCheckbox = false;
            this.in_PriorityNo.ShowCheckbox = false;
            this.in_PriorityNo.ShowTextboxOnly = false;
            this.in_PriorityNo.Size = new System.Drawing.Size(60, 50);
            this.in_PriorityNo.TabIndex = 3;
            this.in_PriorityNo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // iddl_POItemStatus
            // 
            this.iddl_POItemStatus.DisableTextInput = false;
            this.iddl_POItemStatus.HideFilter = false;
            this.iddl_POItemStatus.HideUpdateLink = true;
            this.iddl_POItemStatus.LabelText = "Status";
            this.iddl_POItemStatus.Location = new System.Drawing.Point(5, 10);
            this.iddl_POItemStatus.Margin = new System.Windows.Forms.Padding(4);
            this.iddl_POItemStatus.Name = "iddl_POItemStatus";
            this.iddl_POItemStatus.SelectedIndex = -1;
            this.iddl_POItemStatus.SelectedItem = null;
            this.iddl_POItemStatus.SelectedItemText = "";
            this.iddl_POItemStatus.SelectedValue = null;
            this.iddl_POItemStatus.ShowDropdownlistOnly = false;
            this.iddl_POItemStatus.Size = new System.Drawing.Size(168, 50);
            this.iddl_POItemStatus.TabIndex = 4;
            // 
            // MasterData_v1_Status_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1112, 554);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Mode = LIBUtil.FormModes.Add;
            this.Name = "MasterData_v1_Status_Form";
            this.Text = "PO STATUS";
            this.panel1.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputLeft.Panel1.ResumeLayout(false);
            this.scInputLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).EndInit();
            this.scInputRight.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.scInputContainer.Panel1.ResumeLayout(false);
            this.scInputContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).EndInit();
            this.scInputContainer.ResumeLayout(false);
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            this.pnlRowInfo.ResumeLayout(false);
            this.pnlRowInfoHeaderContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.scContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scContent)).EndInit();
            this.scContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_ExpectedDeliveryDate;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private System.Windows.Forms.CheckBox chkShowCustomerName;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PriorityNo;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PriorityQty;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_POItemStatus;
    }
}