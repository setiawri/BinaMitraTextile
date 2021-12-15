namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_MoneyAccountItems_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterData_v1_MoneyAccountItems_Form));
            this.itxt_Description = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.iddl_MoneyAccountCategoryAssignments = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccounts = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.label2 = new System.Windows.Forms.Label();
            this.idtp_Timestamp_End = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.idtp_Timestamp_Start = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.pbCalculator = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbCalculator)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(784, 28);
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.Location = new System.Drawing.Point(196, 6);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 127);
            this.pnlActionButtons.Size = new System.Drawing.Size(784, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.in_Amount);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_MoneyAccountCategoryAssignments);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.itxt_Description);
            this.scInputLeft.Size = new System.Drawing.Size(500, 101);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(280, 101);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.DarkOrange;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(784, 484);
            this.scMain.SplitterDistance = 150;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(784, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(784, 101);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.pbCalculator);
            this.pnlQuickSearch.Controls.Add(this.btnApplyFilter);
            this.pnlQuickSearch.Controls.Add(this.label4);
            this.pnlQuickSearch.Controls.Add(this.label3);
            this.pnlQuickSearch.Controls.Add(this.idtp_Timestamp_Start);
            this.pnlQuickSearch.Controls.Add(this.idtp_Timestamp_End);
            this.pnlQuickSearch.Controls.Add(this.label2);
            this.pnlQuickSearch.Controls.Add(this.iddl_MoneyAccounts);
            this.pnlQuickSearch.Size = new System.Drawing.Size(754, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.iddl_MoneyAccounts, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label2, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.idtp_Timestamp_End, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.idtp_Timestamp_Start, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label3, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label4, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.btnApplyFilter, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.pbCalculator, 0);
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Location = new System.Drawing.Point(0, 233);
            this.pnlRowInfo.Size = new System.Drawing.Size(784, 100);
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(764, 21);
            // 
            // pnlRowInfoContent
            // 
            this.pnlRowInfoContent.Size = new System.Drawing.Size(784, 79);
            // 
            // itxt_Description
            // 
            this.itxt_Description.IsBrowseMode = false;
            this.itxt_Description.LabelText = "Description";
            this.itxt_Description.Location = new System.Drawing.Point(3, 5);
            this.itxt_Description.MaxLength = 32767;
            this.itxt_Description.MultiLine = true;
            this.itxt_Description.Name = "itxt_Description";
            this.itxt_Description.PasswordChar = '\0';
            this.itxt_Description.RowCount = 4;
            this.itxt_Description.ShowDeleteButton = false;
            this.itxt_Description.ShowFilter = false;
            this.itxt_Description.ShowTextboxOnly = false;
            this.itxt_Description.Size = new System.Drawing.Size(242, 86);
            this.itxt_Description.TabIndex = 1;
            this.itxt_Description.ValueText = "";
            // 
            // in_Amount
            // 
            this.in_Amount.Checked = false;
            this.in_Amount.DecimalPlaces = 0;
            this.in_Amount.HideUpDown = true;
            this.in_Amount.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.in_Amount.LabelText = "Amount";
            this.in_Amount.Location = new System.Drawing.Point(3, 50);
            this.in_Amount.MaximumValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.in_Amount.MinimumValue = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.in_Amount.Name = "in_Amount";
            this.in_Amount.ShowAllowDecimalCheckbox = false;
            this.in_Amount.ShowCheckbox = false;
            this.in_Amount.ShowTextboxOnly = false;
            this.in_Amount.Size = new System.Drawing.Size(104, 41);
            this.in_Amount.TabIndex = 2;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // iddl_MoneyAccountCategoryAssignments
            // 
            this.iddl_MoneyAccountCategoryAssignments.DisableTextInput = false;
            this.iddl_MoneyAccountCategoryAssignments.HideFilter = false;
            this.iddl_MoneyAccountCategoryAssignments.HideUpdateLink = true;
            this.iddl_MoneyAccountCategoryAssignments.LabelText = "Category";
            this.iddl_MoneyAccountCategoryAssignments.Location = new System.Drawing.Point(3, 6);
            this.iddl_MoneyAccountCategoryAssignments.Name = "iddl_MoneyAccountCategoryAssignments";
            this.iddl_MoneyAccountCategoryAssignments.SelectedIndex = -1;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItem = null;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItemText = "";
            this.iddl_MoneyAccountCategoryAssignments.SelectedValue = null;
            this.iddl_MoneyAccountCategoryAssignments.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategoryAssignments.Size = new System.Drawing.Size(242, 41);
            this.iddl_MoneyAccountCategoryAssignments.TabIndex = 0;
            // 
            // iddl_MoneyAccounts
            // 
            this.iddl_MoneyAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iddl_MoneyAccounts.DisableTextInput = false;
            this.iddl_MoneyAccounts.HideFilter = false;
            this.iddl_MoneyAccounts.HideUpdateLink = true;
            this.iddl_MoneyAccounts.LabelText = "Account";
            this.iddl_MoneyAccounts.Location = new System.Drawing.Point(553, 2);
            this.iddl_MoneyAccounts.Name = "iddl_MoneyAccounts";
            this.iddl_MoneyAccounts.SelectedIndex = -1;
            this.iddl_MoneyAccounts.SelectedItem = null;
            this.iddl_MoneyAccounts.SelectedItemText = "";
            this.iddl_MoneyAccounts.SelectedValue = null;
            this.iddl_MoneyAccounts.ShowDropdownlistOnly = true;
            this.iddl_MoneyAccounts.Size = new System.Drawing.Size(104, 22);
            this.iddl_MoneyAccounts.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ACCOUNT";
            // 
            // idtp_Timestamp_End
            // 
            this.idtp_Timestamp_End.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idtp_Timestamp_End.Checked = false;
            this.idtp_Timestamp_End.CustomFormat = "dd/MM/yy";
            this.idtp_Timestamp_End.DefaultCheckedValue = false;
            this.idtp_Timestamp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_Timestamp_End.LabelText = "dropdownlist";
            this.idtp_Timestamp_End.Location = new System.Drawing.Point(378, 3);
            this.idtp_Timestamp_End.Name = "idtp_Timestamp_End";
            this.idtp_Timestamp_End.ShowCheckBox = true;
            this.idtp_Timestamp_End.ShowDateTimePickerOnly = true;
            this.idtp_Timestamp_End.ShowUpAndDown = false;
            this.idtp_Timestamp_End.Size = new System.Drawing.Size(109, 21);
            this.idtp_Timestamp_End.TabIndex = 6;
            this.idtp_Timestamp_End.Value = null;
            this.idtp_Timestamp_End.ValueTimeSpan = null;
            // 
            // idtp_Timestamp_Start
            // 
            this.idtp_Timestamp_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idtp_Timestamp_Start.Checked = true;
            this.idtp_Timestamp_Start.CustomFormat = "dd/MM/yy";
            this.idtp_Timestamp_Start.DefaultCheckedValue = true;
            this.idtp_Timestamp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_Timestamp_Start.LabelText = "dropdownlist";
            this.idtp_Timestamp_Start.Location = new System.Drawing.Point(271, 3);
            this.idtp_Timestamp_Start.Name = "idtp_Timestamp_Start";
            this.idtp_Timestamp_Start.ShowCheckBox = false;
            this.idtp_Timestamp_Start.ShowDateTimePickerOnly = true;
            this.idtp_Timestamp_Start.ShowUpAndDown = false;
            this.idtp_Timestamp_Start.Size = new System.Drawing.Size(85, 21);
            this.idtp_Timestamp_Start.TabIndex = 7;
            this.idtp_Timestamp_Start.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.idtp_Timestamp_Start.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "TO";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "DATE";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.Location = new System.Drawing.Point(662, 2);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(56, 23);
            this.btnApplyFilter.TabIndex = 1;
            this.btnApplyFilter.Text = "APPLY";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // pbCalculator
            // 
            this.pbCalculator.BackColor = System.Drawing.Color.White;
            this.pbCalculator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCalculator.BackgroundImage")));
            this.pbCalculator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCalculator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCalculator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbCalculator.Location = new System.Drawing.Point(720, 0);
            this.pbCalculator.Name = "pbCalculator";
            this.pbCalculator.Size = new System.Drawing.Size(32, 26);
            this.pbCalculator.TabIndex = 124;
            this.pbCalculator.TabStop = false;
            this.pbCalculator.Click += new System.EventHandler(this.pbCalculator_Click);
            // 
            // MasterData_v1_MoneyAccountItems_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 484);
            this.Mode = LIBUtil.FormModes.Add;
            this.Name = "MasterData_v1_MoneyAccountItems_Form";
            this.Text = "MONEY ACCOUNTS";
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
            ((System.ComponentModel.ISupportInitialize)(this.pbCalculator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Description;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategoryAssignments;
        private System.Windows.Forms.Label label2;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_Timestamp_Start;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_Timestamp_End;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.PictureBox pbCalculator;
    }
}