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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iddl_MoneyAccounts = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategoryAssignments = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.itxt_Description = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_MoneyAccounts_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_MoneyAccountCategories_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // iddl_MoneyAccounts
            // 
            this.iddl_MoneyAccounts.DisableTextInput = false;
            this.iddl_MoneyAccounts.HideFilter = true;
            this.iddl_MoneyAccounts.HideUpdateLink = true;
            this.iddl_MoneyAccounts.LabelText = "Account";
            this.iddl_MoneyAccounts.Location = new System.Drawing.Point(16, 13);
            this.iddl_MoneyAccounts.Margin = new System.Windows.Forms.Padding(5);
            this.iddl_MoneyAccounts.Name = "iddl_MoneyAccounts";
            this.iddl_MoneyAccounts.SelectedIndex = -1;
            this.iddl_MoneyAccounts.SelectedItem = null;
            this.iddl_MoneyAccounts.SelectedItemText = "";
            this.iddl_MoneyAccounts.SelectedValue = null;
            this.iddl_MoneyAccounts.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccounts.Size = new System.Drawing.Size(185, 50);
            this.iddl_MoneyAccounts.TabIndex = 0;
            this.iddl_MoneyAccounts.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccounts_SelectedIndexChanged);
            // 
            // iddl_MoneyAccountCategoryAssignments
            // 
            this.iddl_MoneyAccountCategoryAssignments.DisableTextInput = false;
            this.iddl_MoneyAccountCategoryAssignments.HideFilter = true;
            this.iddl_MoneyAccountCategoryAssignments.HideUpdateLink = true;
            this.iddl_MoneyAccountCategoryAssignments.LabelText = "Category";
            this.iddl_MoneyAccountCategoryAssignments.Location = new System.Drawing.Point(16, 70);
            this.iddl_MoneyAccountCategoryAssignments.Margin = new System.Windows.Forms.Padding(5);
            this.iddl_MoneyAccountCategoryAssignments.Name = "iddl_MoneyAccountCategoryAssignments";
            this.iddl_MoneyAccountCategoryAssignments.SelectedIndex = -1;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItem = null;
            this.iddl_MoneyAccountCategoryAssignments.SelectedItemText = "";
            this.iddl_MoneyAccountCategoryAssignments.SelectedValue = null;
            this.iddl_MoneyAccountCategoryAssignments.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategoryAssignments.Size = new System.Drawing.Size(185, 50);
            this.iddl_MoneyAccountCategoryAssignments.TabIndex = 1;
            // 
            // itxt_Description
            // 
            this.itxt_Description.IsBrowseMode = false;
            this.itxt_Description.LabelText = "Notes";
            this.itxt_Description.Location = new System.Drawing.Point(209, 15);
            this.itxt_Description.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_Description.MaxLength = 32767;
            this.itxt_Description.MultiLine = true;
            this.itxt_Description.Name = "itxt_Description";
            this.itxt_Description.PasswordChar = '\0';
            this.itxt_Description.RowCount = 4;
            this.itxt_Description.ShowDeleteButton = false;
            this.itxt_Description.ShowFilter = false;
            this.itxt_Description.ShowTextboxOnly = false;
            this.itxt_Description.Size = new System.Drawing.Size(542, 105);
            this.itxt_Description.TabIndex = 2;
            this.itxt_Description.ValueText = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(761, 70);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(151, 50);
            this.btnSubmit.TabIndex = 4;
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
            this.in_Amount.Location = new System.Drawing.Point(761, 12);
            this.in_Amount.Margin = new System.Windows.Forms.Padding(5);
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
            this.in_Amount.Size = new System.Drawing.Size(151, 50);
            this.in_Amount.TabIndex = 3;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Amount.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.in_Amount_onKeyDown);
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
            this.col_grid_Id,
            this.col_grid_MoneyAccounts_Name,
            this.col_grid_Timestamp,
            this.col_grid_No,
            this.col_grid_MoneyAccountCategories_Name,
            this.col_grid_Description,
            this.col_grid_Amount,
            this.col_grid_Approved});
            this.grid.Location = new System.Drawing.Point(16, 129);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(896, 143);
            this.grid.TabIndex = 6;
            this.grid.TabStop = false;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // col_grid_Id
            // 
            this.col_grid_Id.HeaderText = "Id";
            this.col_grid_Id.MinimumWidth = 6;
            this.col_grid_Id.Name = "col_grid_Id";
            this.col_grid_Id.ReadOnly = true;
            this.col_grid_Id.Visible = false;
            this.col_grid_Id.Width = 125;
            // 
            // col_grid_MoneyAccounts_Name
            // 
            this.col_grid_MoneyAccounts_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_MoneyAccounts_Name.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_MoneyAccounts_Name.HeaderText = "Account";
            this.col_grid_MoneyAccounts_Name.MinimumWidth = 50;
            this.col_grid_MoneyAccounts_Name.Name = "col_grid_MoneyAccounts_Name";
            this.col_grid_MoneyAccounts_Name.ReadOnly = true;
            this.col_grid_MoneyAccounts_Name.Width = 50;
            // 
            // col_grid_Timestamp
            // 
            this.col_grid_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Format = "dd/MM/yy";
            this.col_grid_Timestamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_Timestamp.HeaderText = "Date";
            this.col_grid_Timestamp.MinimumWidth = 40;
            this.col_grid_Timestamp.Name = "col_grid_Timestamp";
            this.col_grid_Timestamp.ReadOnly = true;
            this.col_grid_Timestamp.Width = 40;
            // 
            // col_grid_No
            // 
            this.col_grid_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_No.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_No.HeaderText = "No";
            this.col_grid_No.MinimumWidth = 50;
            this.col_grid_No.Name = "col_grid_No";
            this.col_grid_No.ReadOnly = true;
            this.col_grid_No.Width = 50;
            // 
            // col_grid_MoneyAccountCategories_Name
            // 
            this.col_grid_MoneyAccountCategories_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_MoneyAccountCategories_Name.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_grid_MoneyAccountCategories_Name.HeaderText = "Category";
            this.col_grid_MoneyAccountCategories_Name.MinimumWidth = 50;
            this.col_grid_MoneyAccountCategories_Name.Name = "col_grid_MoneyAccountCategories_Name";
            this.col_grid_MoneyAccountCategories_Name.ReadOnly = true;
            this.col_grid_MoneyAccountCategories_Name.Width = 50;
            // 
            // col_grid_Description
            // 
            this.col_grid_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_Description.HeaderText = "Description";
            this.col_grid_Description.MinimumWidth = 100;
            this.col_grid_Description.Name = "col_grid_Description";
            this.col_grid_Description.ReadOnly = true;
            this.col_grid_Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_grid_Amount
            // 
            this.col_grid_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.col_grid_Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_grid_Amount.HeaderText = "Amount";
            this.col_grid_Amount.MinimumWidth = 50;
            this.col_grid_Amount.Name = "col_grid_Amount";
            this.col_grid_Amount.ReadOnly = true;
            this.col_grid_Amount.Width = 50;
            // 
            // col_grid_Approved
            // 
            this.col_grid_Approved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_Approved.HeaderText = "OK";
            this.col_grid_Approved.MinimumWidth = 30;
            this.col_grid_Approved.Name = "col_grid_Approved";
            this.col_grid_Approved.ReadOnly = true;
            this.col_grid_Approved.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_Approved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_grid_Approved.Width = 30;
            // 
            // MoneyAccountItems_Add_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(924, 286);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.iddl_MoneyAccounts);
            this.Controls.Add(this.iddl_MoneyAccountCategoryAssignments);
            this.Controls.Add(this.itxt_Description);
            this.Controls.Add(this.in_Amount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MoneyAccountItems_Add_Form";
            this.Text = "SHIPPING EXPENSES";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategoryAssignments;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Description;
        public System.Windows.Forms.Button btnSubmit;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_MoneyAccounts_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_MoneyAccountCategories_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_Approved;
    }
}