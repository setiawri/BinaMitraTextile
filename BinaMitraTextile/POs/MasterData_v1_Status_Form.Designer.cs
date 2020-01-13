namespace BinaMitraTextile.POs
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
            this.iddl_POItemStatus = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_PriorityNo = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.idtp_ExpectedDeliveryDate = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.chkShowHidden = new System.Windows.Forms.CheckBox();
            this.in_PriorityQty = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.chkShowCustomerName = new System.Windows.Forms.CheckBox();
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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(834, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 87);
            this.pnlActionButtons.Size = new System.Drawing.Size(834, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.in_PriorityQty);
            this.scInputLeft.Panel1.Controls.Add(this.in_PriorityNo);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_POItemStatus);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.idtp_ExpectedDeliveryDate);
            this.scInputLeft.Size = new System.Drawing.Size(500, 61);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(330, 61);
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(834, 450);
            this.scMain.SplitterDistance = 110;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(834, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(834, 61);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkShowCustomerName);
            this.pnlQuickSearch.Controls.Add(this.chkShowHidden);
            this.pnlQuickSearch.Size = new System.Drawing.Size(804, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkShowHidden, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkShowCustomerName, 0);
            // 
            // iddl_POItemStatus
            // 
            this.iddl_POItemStatus.DisableTextInput = false;
            this.iddl_POItemStatus.HideFilter = false;
            this.iddl_POItemStatus.HideUpdateLink = false;
            this.iddl_POItemStatus.LabelText = "Status";
            this.iddl_POItemStatus.Location = new System.Drawing.Point(3, 6);
            this.iddl_POItemStatus.Name = "iddl_POItemStatus";
            this.iddl_POItemStatus.SelectedIndex = -1;
            this.iddl_POItemStatus.SelectedItem = null;
            this.iddl_POItemStatus.SelectedItemText = "";
            this.iddl_POItemStatus.SelectedValue = null;
            this.iddl_POItemStatus.ShowDropdownlistOnly = false;
            this.iddl_POItemStatus.Size = new System.Drawing.Size(125, 41);
            this.iddl_POItemStatus.TabIndex = 0;
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
            this.in_PriorityNo.Location = new System.Drawing.Point(129, 7);
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
            this.in_PriorityNo.Size = new System.Drawing.Size(45, 41);
            this.in_PriorityNo.TabIndex = 0;
            this.in_PriorityNo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // idtp_ExpectedDeliveryDate
            // 
            this.idtp_ExpectedDeliveryDate.Checked = true;
            this.idtp_ExpectedDeliveryDate.CustomFormat = "ddd dd/MM";
            this.idtp_ExpectedDeliveryDate.DefaultCheckedValue = false;
            this.idtp_ExpectedDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_ExpectedDeliveryDate.LabelText = "Expected Delivery";
            this.idtp_ExpectedDeliveryDate.Location = new System.Drawing.Point(3, 6);
            this.idtp_ExpectedDeliveryDate.Name = "idtp_ExpectedDeliveryDate";
            this.idtp_ExpectedDeliveryDate.ShowCheckBox = true;
            this.idtp_ExpectedDeliveryDate.ShowUpAndDown = false;
            this.idtp_ExpectedDeliveryDate.Size = new System.Drawing.Size(112, 41);
            this.idtp_ExpectedDeliveryDate.TabIndex = 0;
            this.idtp_ExpectedDeliveryDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_ExpectedDeliveryDate.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // chkShowHidden
            // 
            this.chkShowHidden.AutoSize = true;
            this.chkShowHidden.Location = new System.Drawing.Point(199, 6);
            this.chkShowHidden.Name = "chkShowHidden";
            this.chkShowHidden.Size = new System.Drawing.Size(33, 17);
            this.chkShowHidden.TabIndex = 14;
            this.chkShowHidden.Text = "X";
            this.chkShowHidden.UseVisualStyleBackColor = true;
            this.chkShowHidden.Visible = false;
            this.chkShowHidden.CheckedChanged += new System.EventHandler(this.chkShowHidden_CheckedChanged);
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
            this.in_PriorityQty.Location = new System.Drawing.Point(175, 7);
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
            this.in_PriorityQty.Size = new System.Drawing.Size(71, 41);
            this.in_PriorityQty.TabIndex = 1;
            this.in_PriorityQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chkShowCustomerName
            // 
            this.chkShowCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowCustomerName.AutoSize = true;
            this.chkShowCustomerName.Location = new System.Drawing.Point(729, 6);
            this.chkShowCustomerName.Name = "chkShowCustomerName";
            this.chkShowCustomerName.Size = new System.Drawing.Size(70, 17);
            this.chkShowCustomerName.TabIndex = 15;
            this.chkShowCustomerName.Text = "Customer";
            this.chkShowCustomerName.UseVisualStyleBackColor = true;
            this.chkShowCustomerName.CheckedChanged += new System.EventHandler(this.ChkShowCustomerName_CheckedChanged);
            // 
            // MasterData_v1_Status_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Name = "MasterData_v1_Status_Form";
            this.Text = "PO Status";
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
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_POItemStatus;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PriorityNo;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_ExpectedDeliveryDate;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PriorityQty;
        private System.Windows.Forms.CheckBox chkShowCustomerName;
    }
}