namespace BinaMitraTextile.Logs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.itxt_QuickSearch = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
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
            this.col_grid_Timestamp,
            this.col_grid_Username,
            this.col_grid_Description});
            this.grid.Enabled = false;
            this.grid.Location = new System.Drawing.Point(15, 46);
            this.grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(867, 434);
            this.grid.TabIndex = 4;
            // 
            // col_grid_Timestamp
            // 
            this.col_grid_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.col_grid_Timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_Timestamp.HeaderText = "Timestamp";
            this.col_grid_Timestamp.MinimumWidth = 60;
            this.col_grid_Timestamp.Name = "col_grid_Timestamp";
            this.col_grid_Timestamp.ReadOnly = true;
            this.col_grid_Timestamp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_Timestamp.Width = 60;
            // 
            // col_grid_Username
            // 
            this.col_grid_Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.col_grid_Username.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_Username.HeaderText = "User";
            this.col_grid_Username.MinimumWidth = 30;
            this.col_grid_Username.Name = "col_grid_Username";
            this.col_grid_Username.ReadOnly = true;
            this.col_grid_Username.Width = 30;
            // 
            // col_grid_Description
            // 
            this.col_grid_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_grid_Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_grid_Description.HeaderText = "Description";
            this.col_grid_Description.Name = "col_grid_Description";
            this.col_grid_Description.ReadOnly = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(497, 14);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(305, 20);
            this.txtDescription.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(809, 12);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // itxt_QuickSearch
            // 
            this.itxt_QuickSearch.IsBrowseMode = false;
            this.itxt_QuickSearch.LabelText = "textbox";
            this.itxt_QuickSearch.Location = new System.Drawing.Point(57, 12);
            this.itxt_QuickSearch.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_QuickSearch.MaxLength = 32767;
            this.itxt_QuickSearch.MultiLine = false;
            this.itxt_QuickSearch.Name = "itxt_QuickSearch";
            this.itxt_QuickSearch.PasswordChar = '\0';
            this.itxt_QuickSearch.RowCount = 1;
            this.itxt_QuickSearch.ShowDeleteButton = false;
            this.itxt_QuickSearch.ShowFilter = false;
            this.itxt_QuickSearch.ShowTextboxOnly = true;
            this.itxt_QuickSearch.Size = new System.Drawing.Size(79, 26);
            this.itxt_QuickSearch.TabIndex = 5;
            this.itxt_QuickSearch.ValueText = "";
            this.itxt_QuickSearch.onTextChanged += new System.EventHandler(this.itxt_QuickSearch_onTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // Main_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(897, 494);
            this.Controls.Add(this.itxt_QuickSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.Text = "LOG";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_QuickSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_Description;
    }
}