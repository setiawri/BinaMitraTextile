namespace BinaMitraTextile.Users
{
    partial class Main_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.chkShowInactive = new System.Windows.Forms.CheckBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.in_GlobalPercentComission = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.itxt_PasswordReset = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_PercentCommission = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.label8 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LinkName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_grid_role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_PercentCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_GlobalPercentCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Current";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "minimum 4 characters";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(307, 174);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(177, 174);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(124, 25);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "ADD NEW";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 104;
            this.label5.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(63, 75);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(181, 61);
            this.txtNotes.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "Role";
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(63, 44);
            this.cbRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(183, 21);
            this.cbRoles.TabIndex = 1;
            // 
            // chkShowInactive
            // 
            this.chkShowInactive.AutoSize = true;
            this.chkShowInactive.Location = new System.Drawing.Point(15, 219);
            this.chkShowInactive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkShowInactive.Name = "chkShowInactive";
            this.chkShowInactive.Size = new System.Drawing.Size(91, 17);
            this.chkShowInactive.TabIndex = 1;
            this.chkShowInactive.Text = "show inactive";
            this.chkShowInactive.UseVisualStyleBackColor = true;
            this.chkShowInactive.CheckedChanged += new System.EventHandler(this.chkShowInactive_CheckedChanged);
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(369, 102);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCurrentPassword.MaxLength = 30;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(181, 20);
            this.txtCurrentPassword.TabIndex = 5;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.active,
            this.LinkName,
            this.col_grid_role,
            this.col_grid_PercentCommission,
            this.col_grid_GlobalPercentCommission});
            this.grid.Location = new System.Drawing.Point(15, 245);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(573, 258);
            this.grid.TabIndex = 98;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(369, 73);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfirmNewPassword.MaxLength = 30;
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(181, 20);
            this.txtConfirmNewPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "Confirm";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(369, 44);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPassword.MaxLength = 30;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(181, 20);
            this.txtNewPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "New Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 17);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.in_GlobalPercentComission);
            this.groupBox1.Controls.Add(this.btnResetPassword);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.itxt_PasswordReset);
            this.groupBox1.Controls.Add(this.in_PercentCommission);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbRoles);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCurrentPassword);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtConfirmNewPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(573, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // in_GlobalPercentComission
            // 
            this.in_GlobalPercentComission.Checked = false;
            this.in_GlobalPercentComission.DecimalPlaces = 2;
            this.in_GlobalPercentComission.HideUpDown = false;
            this.in_GlobalPercentComission.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.in_GlobalPercentComission.LabelText = "numeric";
            this.in_GlobalPercentComission.Location = new System.Drawing.Point(140, 140);
            this.in_GlobalPercentComission.Margin = new System.Windows.Forms.Padding(5);
            this.in_GlobalPercentComission.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_GlobalPercentComission.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_GlobalPercentComission.Name = "in_GlobalPercentComission";
            this.in_GlobalPercentComission.ShowAllowDecimalCheckbox = false;
            this.in_GlobalPercentComission.ShowCheckbox = false;
            this.in_GlobalPercentComission.ShowTextboxOnly = true;
            this.in_GlobalPercentComission.Size = new System.Drawing.Size(104, 30);
            this.in_GlobalPercentComission.TabIndex = 113;
            this.in_GlobalPercentComission.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(476, 132);
            this.btnResetPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(76, 28);
            this.btnResetPassword.TabIndex = 112;
            this.btnResetPassword.Text = "RESET";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(301, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "Reset to";
            // 
            // itxt_PasswordReset
            // 
            this.itxt_PasswordReset.IsBrowseMode = false;
            this.itxt_PasswordReset.LabelText = "textbox";
            this.itxt_PasswordReset.Location = new System.Drawing.Point(369, 133);
            this.itxt_PasswordReset.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_PasswordReset.MaxLength = 32767;
            this.itxt_PasswordReset.MultiLine = false;
            this.itxt_PasswordReset.Name = "itxt_PasswordReset";
            this.itxt_PasswordReset.PasswordChar = '\0';
            this.itxt_PasswordReset.RowCount = 1;
            this.itxt_PasswordReset.ShowDeleteButton = false;
            this.itxt_PasswordReset.ShowFilter = false;
            this.itxt_PasswordReset.ShowTextboxOnly = true;
            this.itxt_PasswordReset.Size = new System.Drawing.Size(100, 26);
            this.itxt_PasswordReset.TabIndex = 110;
            this.itxt_PasswordReset.ValueText = "qwerty";
            // 
            // in_PercentCommission
            // 
            this.in_PercentCommission.Checked = false;
            this.in_PercentCommission.DecimalPlaces = 2;
            this.in_PercentCommission.HideUpDown = false;
            this.in_PercentCommission.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.in_PercentCommission.LabelText = "numeric";
            this.in_PercentCommission.Location = new System.Drawing.Point(63, 140);
            this.in_PercentCommission.Margin = new System.Windows.Forms.Padding(5);
            this.in_PercentCommission.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_PercentCommission.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_PercentCommission.Name = "in_PercentCommission";
            this.in_PercentCommission.ShowAllowDecimalCheckbox = false;
            this.in_PercentCommission.ShowCheckbox = false;
            this.in_PercentCommission.ShowTextboxOnly = true;
            this.in_PercentCommission.Size = new System.Drawing.Size(71, 30);
            this.in_PercentCommission.TabIndex = 109;
            this.in_PercentCommission.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "%";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // active
            // 
            this.active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.active.DataPropertyName = "active";
            this.active.HeaderText = "Active";
            this.active.MinimumWidth = 50;
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.active.Width = 50;
            // 
            // LinkName
            // 
            this.LinkName.ActiveLinkColor = System.Drawing.Color.Orange;
            this.LinkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LinkName.DataPropertyName = "username";
            this.LinkName.HeaderText = "Name";
            this.LinkName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkName.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.LinkName.MinimumWidth = 100;
            this.LinkName.Name = "LinkName";
            this.LinkName.ReadOnly = true;
            this.LinkName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LinkName.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            // 
            // col_grid_role
            // 
            this.col_grid_role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_role.DataPropertyName = "rolename";
            this.col_grid_role.HeaderText = "Role";
            this.col_grid_role.MinimumWidth = 50;
            this.col_grid_role.Name = "col_grid_role";
            this.col_grid_role.ReadOnly = true;
            this.col_grid_role.Width = 50;
            // 
            // col_grid_PercentCommission
            // 
            this.col_grid_PercentCommission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_PercentCommission.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_grid_PercentCommission.HeaderText = "%";
            this.col_grid_PercentCommission.MinimumWidth = 30;
            this.col_grid_PercentCommission.Name = "col_grid_PercentCommission";
            this.col_grid_PercentCommission.ReadOnly = true;
            this.col_grid_PercentCommission.Width = 30;
            // 
            // col_grid_GlobalPercentCommission
            // 
            this.col_grid_GlobalPercentCommission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_grid_GlobalPercentCommission.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_grid_GlobalPercentCommission.HeaderText = "%Global";
            this.col_grid_GlobalPercentCommission.MinimumWidth = 60;
            this.col_grid_GlobalPercentCommission.Name = "col_grid_GlobalPercentCommission";
            this.col_grid_GlobalPercentCommission.ReadOnly = true;
            this.col_grid_GlobalPercentCommission.Width = 60;
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(603, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkShowInactive);
            this.Controls.Add(this.grid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main_Form";
            this.Text = "USER ACCOUNTS";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.CheckBox chkShowInactive;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PercentCommission;
        private System.Windows.Forms.Label label9;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_PasswordReset;
        private System.Windows.Forms.Button btnResetPassword;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_GlobalPercentComission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn active;
        private System.Windows.Forms.DataGridViewLinkColumn LinkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_role;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_PercentCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_GlobalPercentCommission;
    }
}