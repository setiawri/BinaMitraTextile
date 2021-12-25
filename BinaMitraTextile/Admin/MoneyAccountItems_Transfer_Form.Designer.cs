namespace BinaMitraTextile.Admin
{
    partial class MoneyAccountItems_Transfer_Form
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
            this.iddl_MoneyAccounts_From = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategoryAssignments_From = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.itxt_Description_From = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.iddl_MoneyAccounts_To = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategoryAssignments_To = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.label1 = new System.Windows.Forms.Label();
            this.itxt_Description_To = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.SuspendLayout();
            // 
            // iddl_MoneyAccounts_From
            // 
            this.iddl_MoneyAccounts_From.DisableTextInput = false;
            this.iddl_MoneyAccounts_From.HideFilter = true;
            this.iddl_MoneyAccounts_From.HideUpdateLink = true;
            this.iddl_MoneyAccounts_From.LabelText = "Account";
            this.iddl_MoneyAccounts_From.Location = new System.Drawing.Point(13, 18);
            this.iddl_MoneyAccounts_From.Name = "iddl_MoneyAccounts_From";
            this.iddl_MoneyAccounts_From.SelectedIndex = -1;
            this.iddl_MoneyAccounts_From.SelectedItem = null;
            this.iddl_MoneyAccounts_From.SelectedItemText = "";
            this.iddl_MoneyAccounts_From.SelectedValue = null;
            this.iddl_MoneyAccounts_From.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccounts_From.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccounts_From.TabIndex = 0;
            this.iddl_MoneyAccounts_From.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccounts_SelectedIndexChanged);
            // 
            // iddl_MoneyAccountCategoryAssignments_From
            // 
            this.iddl_MoneyAccountCategoryAssignments_From.DisableTextInput = false;
            this.iddl_MoneyAccountCategoryAssignments_From.HideFilter = true;
            this.iddl_MoneyAccountCategoryAssignments_From.HideUpdateLink = true;
            this.iddl_MoneyAccountCategoryAssignments_From.LabelText = "Category";
            this.iddl_MoneyAccountCategoryAssignments_From.Location = new System.Drawing.Point(13, 63);
            this.iddl_MoneyAccountCategoryAssignments_From.Name = "iddl_MoneyAccountCategoryAssignments_From";
            this.iddl_MoneyAccountCategoryAssignments_From.SelectedIndex = -1;
            this.iddl_MoneyAccountCategoryAssignments_From.SelectedItem = null;
            this.iddl_MoneyAccountCategoryAssignments_From.SelectedItemText = "";
            this.iddl_MoneyAccountCategoryAssignments_From.SelectedValue = null;
            this.iddl_MoneyAccountCategoryAssignments_From.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategoryAssignments_From.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccountCategoryAssignments_From.TabIndex = 1;
            // 
            // itxt_Description_From
            // 
            this.itxt_Description_From.IsBrowseMode = false;
            this.itxt_Description_From.LabelText = "Notes";
            this.itxt_Description_From.Location = new System.Drawing.Point(13, 110);
            this.itxt_Description_From.MaxLength = 32767;
            this.itxt_Description_From.MultiLine = true;
            this.itxt_Description_From.Name = "itxt_Description_From";
            this.itxt_Description_From.PasswordChar = '\0';
            this.itxt_Description_From.RowCount = 4;
            this.itxt_Description_From.ShowDeleteButton = false;
            this.itxt_Description_From.ShowFilter = false;
            this.itxt_Description_From.ShowTextboxOnly = false;
            this.itxt_Description_From.Size = new System.Drawing.Size(139, 86);
            this.itxt_Description_From.TabIndex = 2;
            this.itxt_Description_From.ValueText = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(171, 207);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(103, 41);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // in_Amount
            // 
            this.in_Amount.Checked = false;
            this.in_Amount.DecimalPlaces = 0;
            this.in_Amount.HideUpDown = true;
            this.in_Amount.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_Amount.LabelText = "Amount";
            this.in_Amount.Location = new System.Drawing.Point(171, 64);
            this.in_Amount.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_Amount.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Amount.Name = "in_Amount";
            this.in_Amount.ShowAllowDecimalCheckbox = false;
            this.in_Amount.ShowCheckbox = false;
            this.in_Amount.ShowTextboxOnly = false;
            this.in_Amount.Size = new System.Drawing.Size(103, 41);
            this.in_Amount.TabIndex = 3;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Amount.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.in_Amount_onKeyDown);
            // 
            // iddl_MoneyAccounts_To
            // 
            this.iddl_MoneyAccounts_To.DisableTextInput = false;
            this.iddl_MoneyAccounts_To.HideFilter = true;
            this.iddl_MoneyAccounts_To.HideUpdateLink = true;
            this.iddl_MoneyAccounts_To.LabelText = "Account";
            this.iddl_MoneyAccounts_To.Location = new System.Drawing.Point(292, 18);
            this.iddl_MoneyAccounts_To.Name = "iddl_MoneyAccounts_To";
            this.iddl_MoneyAccounts_To.SelectedIndex = -1;
            this.iddl_MoneyAccounts_To.SelectedItem = null;
            this.iddl_MoneyAccounts_To.SelectedItemText = "";
            this.iddl_MoneyAccounts_To.SelectedValue = null;
            this.iddl_MoneyAccounts_To.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccounts_To.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccounts_To.TabIndex = 4;
            this.iddl_MoneyAccounts_To.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccounts_To_SelectedIndexChanged);
            // 
            // iddl_MoneyAccountCategoryAssignments_To
            // 
            this.iddl_MoneyAccountCategoryAssignments_To.DisableTextInput = false;
            this.iddl_MoneyAccountCategoryAssignments_To.HideFilter = true;
            this.iddl_MoneyAccountCategoryAssignments_To.HideUpdateLink = true;
            this.iddl_MoneyAccountCategoryAssignments_To.LabelText = "Category";
            this.iddl_MoneyAccountCategoryAssignments_To.Location = new System.Drawing.Point(292, 63);
            this.iddl_MoneyAccountCategoryAssignments_To.Name = "iddl_MoneyAccountCategoryAssignments_To";
            this.iddl_MoneyAccountCategoryAssignments_To.SelectedIndex = -1;
            this.iddl_MoneyAccountCategoryAssignments_To.SelectedItem = null;
            this.iddl_MoneyAccountCategoryAssignments_To.SelectedItemText = "";
            this.iddl_MoneyAccountCategoryAssignments_To.SelectedValue = null;
            this.iddl_MoneyAccountCategoryAssignments_To.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategoryAssignments_To.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccountCategoryAssignments_To.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "TO  >>";
            // 
            // itxt_Description_To
            // 
            this.itxt_Description_To.IsBrowseMode = false;
            this.itxt_Description_To.LabelText = "Notes";
            this.itxt_Description_To.Location = new System.Drawing.Point(292, 110);
            this.itxt_Description_To.MaxLength = 32767;
            this.itxt_Description_To.MultiLine = true;
            this.itxt_Description_To.Name = "itxt_Description_To";
            this.itxt_Description_To.PasswordChar = '\0';
            this.itxt_Description_To.RowCount = 4;
            this.itxt_Description_To.ShowDeleteButton = false;
            this.itxt_Description_To.ShowFilter = false;
            this.itxt_Description_To.ShowTextboxOnly = false;
            this.itxt_Description_To.Size = new System.Drawing.Size(139, 86);
            this.itxt_Description_To.TabIndex = 6;
            this.itxt_Description_To.ValueText = "";
            // 
            // MoneyAccountItems_Transfer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 267);
            this.Controls.Add(this.itxt_Description_To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iddl_MoneyAccounts_To);
            this.Controls.Add(this.iddl_MoneyAccountCategoryAssignments_To);
            this.Controls.Add(this.iddl_MoneyAccounts_From);
            this.Controls.Add(this.iddl_MoneyAccountCategoryAssignments_From);
            this.Controls.Add(this.itxt_Description_From);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.in_Amount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MoneyAccountItems_Transfer_Form";
            this.Text = "MONEY TRANSFER";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts_From;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategoryAssignments_From;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Description_From;
        public System.Windows.Forms.Button btnSubmit;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts_To;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategoryAssignments_To;
        private System.Windows.Forms.Label label1;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Description_To;
    }
}