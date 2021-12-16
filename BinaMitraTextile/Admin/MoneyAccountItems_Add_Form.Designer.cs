namespace BinaMitraTextile.Admin
{
    partial class MoneyAccountItems_Add_Form
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
            this.iddl_MoneyAccounts = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategoryAssignments = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.itxt_ShippingExpenseNotes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.btnUpdateShippingExpense = new System.Windows.Forms.Button();
            this.in_ShippingExpense = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.SuspendLayout();
            // 
            // iddl_MoneyAccounts
            // 
            this.iddl_MoneyAccounts.DisableTextInput = false;
            this.iddl_MoneyAccounts.HideFilter = true;
            this.iddl_MoneyAccounts.HideUpdateLink = true;
            this.iddl_MoneyAccounts.LabelText = "Account";
            this.iddl_MoneyAccounts.Location = new System.Drawing.Point(13, 12);
            this.iddl_MoneyAccounts.Name = "iddl_MoneyAccounts";
            this.iddl_MoneyAccounts.SelectedIndex = -1;
            this.iddl_MoneyAccounts.SelectedItem = null;
            this.iddl_MoneyAccounts.SelectedItemText = "";
            this.iddl_MoneyAccounts.SelectedValue = null;
            this.iddl_MoneyAccounts.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccounts.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccounts.TabIndex = 0;
            this.iddl_MoneyAccounts.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccounts_SelectedIndexChanged);
            // 
            // iddl_MoneyAccountCategoryAssignments
            // 
            this.iddl_MoneyAccountCategoryAssignments.DisableTextInput = false;
            this.iddl_MoneyAccountCategoryAssignments.HideFilter = true;
            this.iddl_MoneyAccountCategoryAssignments.HideUpdateLink = true;
            this.iddl_MoneyAccountCategoryAssignments.LabelText = "Category";
            this.iddl_MoneyAccountCategoryAssignments.Location = new System.Drawing.Point(13, 57);
            this.iddl_MoneyAccountCategoryAssignments.Name = "iddl_MoneyAccountCategoryAssignments";
            this.iddl_MoneyAccountCategoryAssignments.SelectedIndex = -1;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItem = null;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItemText = "";
            this.iddl_MoneyAccountCategoryAssignments.SelectedValue = null;
            this.iddl_MoneyAccountCategoryAssignments.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategoryAssignments.Size = new System.Drawing.Size(139, 41);
            this.iddl_MoneyAccountCategoryAssignments.TabIndex = 1;
            // 
            // itxt_ShippingExpenseNotes
            // 
            this.itxt_ShippingExpenseNotes.IsBrowseMode = false;
            this.itxt_ShippingExpenseNotes.LabelText = "Notes";
            this.itxt_ShippingExpenseNotes.Location = new System.Drawing.Point(158, 12);
            this.itxt_ShippingExpenseNotes.MaxLength = 32767;
            this.itxt_ShippingExpenseNotes.MultiLine = true;
            this.itxt_ShippingExpenseNotes.Name = "itxt_ShippingExpenseNotes";
            this.itxt_ShippingExpenseNotes.PasswordChar = '\0';
            this.itxt_ShippingExpenseNotes.RowCount = 4;
            this.itxt_ShippingExpenseNotes.ShowDeleteButton = false;
            this.itxt_ShippingExpenseNotes.ShowFilter = false;
            this.itxt_ShippingExpenseNotes.ShowTextboxOnly = false;
            this.itxt_ShippingExpenseNotes.Size = new System.Drawing.Size(177, 86);
            this.itxt_ShippingExpenseNotes.TabIndex = 4;
            this.itxt_ShippingExpenseNotes.ValueText = "";
            // 
            // btnUpdateShippingExpense
            // 
            this.btnUpdateShippingExpense.Location = new System.Drawing.Point(214, 122);
            this.btnUpdateShippingExpense.Name = "btnUpdateShippingExpense";
            this.btnUpdateShippingExpense.Size = new System.Drawing.Size(70, 23);
            this.btnUpdateShippingExpense.TabIndex = 5;
            this.btnUpdateShippingExpense.Text = "UPDATE";
            this.btnUpdateShippingExpense.UseVisualStyleBackColor = true;
            this.btnUpdateShippingExpense.Click += new System.EventHandler(this.btnUpdateShippingExpense_Click);
            // 
            // in_ShippingExpense
            // 
            this.in_ShippingExpense.Checked = false;
            this.in_ShippingExpense.DecimalPlaces = 0;
            this.in_ShippingExpense.HideUpDown = true;
            this.in_ShippingExpense.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_ShippingExpense.LabelText = "Shipping Expense";
            this.in_ShippingExpense.Location = new System.Drawing.Point(13, 104);
            this.in_ShippingExpense.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_ShippingExpense.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_ShippingExpense.Name = "in_ShippingExpense";
            this.in_ShippingExpense.ShowAllowDecimalCheckbox = false;
            this.in_ShippingExpense.ShowCheckbox = false;
            this.in_ShippingExpense.ShowTextboxOnly = false;
            this.in_ShippingExpense.Size = new System.Drawing.Size(139, 41);
            this.in_ShippingExpense.TabIndex = 3;
            this.in_ShippingExpense.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_ShippingExpense.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.in_ShippingExpense_onKeyDown);
            // 
            // MoneyAccountItems_Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 306);
            this.Controls.Add(this.iddl_MoneyAccounts);
            this.Controls.Add(this.iddl_MoneyAccountCategoryAssignments);
            this.Controls.Add(this.itxt_ShippingExpenseNotes);
            this.Controls.Add(this.btnUpdateShippingExpense);
            this.Controls.Add(this.in_ShippingExpense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MoneyAccountItems_Add_Form";
            this.Text = "EXPENSES";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategoryAssignments;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_ShippingExpenseNotes;
        public System.Windows.Forms.Button btnUpdateShippingExpense;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_ShippingExpense;
    }
}