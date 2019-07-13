namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_CustomerTerms_Form
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
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_DebtLimit = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_TermDays = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.chkOnlyNotOK = new System.Windows.Forms.CheckBox();
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
            this.panel1.Size = new System.Drawing.Size(800, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 127);
            this.pnlActionButtons.Size = new System.Drawing.Size(800, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.in_TermDays);
            this.scInputLeft.Panel1.Controls.Add(this.in_DebtLimit);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Customers);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.itxt_Notes);
            this.scInputLeft.Size = new System.Drawing.Size(500, 101);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(296, 101);
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(800, 484);
            this.scMain.SplitterDistance = 150;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(800, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(800, 101);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkOnlyNotOK);
            this.pnlQuickSearch.Size = new System.Drawing.Size(770, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkOnlyNotOK, 0);
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(3, 6);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 3;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(243, 71);
            this.itxt_Notes.TabIndex = 0;
            this.itxt_Notes.ValueText = "";
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = false;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(3, 3);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(243, 41);
            this.iddl_Customers.TabIndex = 0;
            this.iddl_Customers.UpdateLink_Click += new System.EventHandler(this.iddl_Customers_UpdateLink_Click);
            // 
            // in_DebtLimit
            // 
            this.in_DebtLimit.Checked = false;
            this.in_DebtLimit.DecimalPlaces = 0;
            this.in_DebtLimit.HideUpDown = false;
            this.in_DebtLimit.Increment = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.in_DebtLimit.LabelText = "Limit";
            this.in_DebtLimit.Location = new System.Drawing.Point(3, 44);
            this.in_DebtLimit.MaximumValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.in_DebtLimit.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_DebtLimit.Name = "in_DebtLimit";
            this.in_DebtLimit.ShowAllowDecimalCheckbox = false;
            this.in_DebtLimit.ShowCheckbox = false;
            this.in_DebtLimit.ShowTextboxOnly = false;
            this.in_DebtLimit.Size = new System.Drawing.Size(163, 41);
            this.in_DebtLimit.TabIndex = 2;
            this.in_DebtLimit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // in_TermDays
            // 
            this.in_TermDays.Checked = false;
            this.in_TermDays.DecimalPlaces = 0;
            this.in_TermDays.HideUpDown = false;
            this.in_TermDays.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.in_TermDays.LabelText = "Term days";
            this.in_TermDays.Location = new System.Drawing.Point(172, 44);
            this.in_TermDays.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_TermDays.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_TermDays.Name = "in_TermDays";
            this.in_TermDays.ShowAllowDecimalCheckbox = false;
            this.in_TermDays.ShowCheckbox = false;
            this.in_TermDays.ShowTextboxOnly = false;
            this.in_TermDays.Size = new System.Drawing.Size(74, 41);
            this.in_TermDays.TabIndex = 3;
            this.in_TermDays.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chkOnlyNotOK
            // 
            this.chkOnlyNotOK.AutoSize = true;
            this.chkOnlyNotOK.Location = new System.Drawing.Point(296, 6);
            this.chkOnlyNotOK.Name = "chkOnlyNotOK";
            this.chkOnlyNotOK.Size = new System.Drawing.Size(87, 17);
            this.chkOnlyNotOK.TabIndex = 98;
            this.chkOnlyNotOK.Text = "only not OK  ";
            this.chkOnlyNotOK.UseVisualStyleBackColor = true;
            this.chkOnlyNotOK.CheckedChanged += new System.EventHandler(this.chkOnlyNotOK_CheckedChanged);
            // 
            // MasterData_v1_CustomerTerms_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Name = "MasterData_v1_CustomerTerms_Form";
            this.Text = "DEBT LIMITS";
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

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_TermDays;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_DebtLimit;
        private System.Windows.Forms.CheckBox chkOnlyNotOK;
    }
}