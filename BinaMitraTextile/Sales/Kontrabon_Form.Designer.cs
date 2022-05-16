namespace BinaMitraTextile.Sales
{
    partial class Kontrabon_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridKontrabon = new System.Windows.Forms.DataGridView();
            this.col_gridKontrabon_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Create_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Customers_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Customers_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Sent_Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_FollowUpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridKontrabon_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridKontrabon)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridKontrabon
            // 
            this.gridKontrabon.AllowUserToAddRows = false;
            this.gridKontrabon.AllowUserToDeleteRows = false;
            this.gridKontrabon.AllowUserToResizeRows = false;
            this.gridKontrabon.BackgroundColor = System.Drawing.Color.White;
            this.gridKontrabon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridKontrabon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridKontrabon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridKontrabon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKontrabon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridKontrabon_Id,
            this.col_gridKontrabon_Create_Timestamp,
            this.col_gridKontrabon_No,
            this.col_gridKontrabon_Customers_Id,
            this.col_gridKontrabon_Customers_Name,
            this.col_gridKontrabon_Amount,
            this.col_gridKontrabon_DueDate,
            this.col_gridKontrabon_Sent_Timestamp,
            this.col_gridKontrabon_FollowUpDate,
            this.col_gridKontrabon_Notes});
            this.gridKontrabon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKontrabon.Location = new System.Drawing.Point(0, 36);
            this.gridKontrabon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridKontrabon.MultiSelect = false;
            this.gridKontrabon.Name = "gridKontrabon";
            this.gridKontrabon.ReadOnly = true;
            this.gridKontrabon.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridKontrabon.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridKontrabon.RowTemplate.Height = 24;
            this.gridKontrabon.Size = new System.Drawing.Size(1067, 518);
            this.gridKontrabon.TabIndex = 114;
            // 
            // col_gridKontrabon_Id
            // 
            this.col_gridKontrabon_Id.HeaderText = "ID";
            this.col_gridKontrabon_Id.Name = "col_gridKontrabon_Id";
            this.col_gridKontrabon_Id.ReadOnly = true;
            this.col_gridKontrabon_Id.Visible = false;
            // 
            // col_gridKontrabon_Create_Timestamp
            // 
            this.col_gridKontrabon_Create_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Format = "dd/MM/yy";
            this.col_gridKontrabon_Create_Timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridKontrabon_Create_Timestamp.FillWeight = 50F;
            this.col_gridKontrabon_Create_Timestamp.HeaderText = "Date";
            this.col_gridKontrabon_Create_Timestamp.MinimumWidth = 40;
            this.col_gridKontrabon_Create_Timestamp.Name = "col_gridKontrabon_Create_Timestamp";
            this.col_gridKontrabon_Create_Timestamp.ReadOnly = true;
            this.col_gridKontrabon_Create_Timestamp.Width = 40;
            // 
            // col_gridKontrabon_No
            // 
            this.col_gridKontrabon_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridKontrabon_No.FillWeight = 50F;
            this.col_gridKontrabon_No.HeaderText = "No";
            this.col_gridKontrabon_No.MinimumWidth = 40;
            this.col_gridKontrabon_No.Name = "col_gridKontrabon_No";
            this.col_gridKontrabon_No.ReadOnly = true;
            this.col_gridKontrabon_No.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridKontrabon_No.Width = 40;
            // 
            // col_gridKontrabon_Customers_Id
            // 
            this.col_gridKontrabon_Customers_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridKontrabon_Customers_Id.HeaderText = "Customer ID";
            this.col_gridKontrabon_Customers_Id.Name = "col_gridKontrabon_Customers_Id";
            this.col_gridKontrabon_Customers_Id.ReadOnly = true;
            this.col_gridKontrabon_Customers_Id.Visible = false;
            // 
            // col_gridKontrabon_Customers_Name
            // 
            this.col_gridKontrabon_Customers_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridKontrabon_Customers_Name.HeaderText = "Customer";
            this.col_gridKontrabon_Customers_Name.MinimumWidth = 60;
            this.col_gridKontrabon_Customers_Name.Name = "col_gridKontrabon_Customers_Name";
            this.col_gridKontrabon_Customers_Name.ReadOnly = true;
            this.col_gridKontrabon_Customers_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridKontrabon_Customers_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_gridKontrabon_Customers_Name.Width = 60;
            // 
            // col_gridKontrabon_Amount
            // 
            this.col_gridKontrabon_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.col_gridKontrabon_Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridKontrabon_Amount.FillWeight = 50F;
            this.col_gridKontrabon_Amount.HeaderText = "Amount";
            this.col_gridKontrabon_Amount.MinimumWidth = 50;
            this.col_gridKontrabon_Amount.Name = "col_gridKontrabon_Amount";
            this.col_gridKontrabon_Amount.ReadOnly = true;
            this.col_gridKontrabon_Amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridKontrabon_Amount.Width = 50;
            // 
            // col_gridKontrabon_DueDate
            // 
            this.col_gridKontrabon_DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yy";
            this.col_gridKontrabon_DueDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridKontrabon_DueDate.HeaderText = "Due";
            this.col_gridKontrabon_DueDate.MinimumWidth = 30;
            this.col_gridKontrabon_DueDate.Name = "col_gridKontrabon_DueDate";
            this.col_gridKontrabon_DueDate.ReadOnly = true;
            this.col_gridKontrabon_DueDate.Width = 30;
            // 
            // col_gridKontrabon_Sent_Timestamp
            // 
            this.col_gridKontrabon_Sent_Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridKontrabon_Sent_Timestamp.HeaderText = "Sent";
            this.col_gridKontrabon_Sent_Timestamp.MinimumWidth = 30;
            this.col_gridKontrabon_Sent_Timestamp.Name = "col_gridKontrabon_Sent_Timestamp";
            this.col_gridKontrabon_Sent_Timestamp.ReadOnly = true;
            this.col_gridKontrabon_Sent_Timestamp.Width = 30;
            // 
            // col_gridKontrabon_FollowUpDate
            // 
            this.col_gridKontrabon_FollowUpDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridKontrabon_FollowUpDate.HeaderText = "FU";
            this.col_gridKontrabon_FollowUpDate.MinimumWidth = 30;
            this.col_gridKontrabon_FollowUpDate.Name = "col_gridKontrabon_FollowUpDate";
            this.col_gridKontrabon_FollowUpDate.ReadOnly = true;
            this.col_gridKontrabon_FollowUpDate.Width = 30;
            // 
            // col_gridKontrabon_Notes
            // 
            this.col_gridKontrabon_Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridKontrabon_Notes.HeaderText = "Notes";
            this.col_gridKontrabon_Notes.Name = "col_gridKontrabon_Notes";
            this.col_gridKontrabon_Notes.ReadOnly = true;
            // 
            // flpButtons
            // 
            this.flpButtons.BackColor = System.Drawing.SystemColors.Control;
            this.flpButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpButtons.Controls.Add(this.btnAdd);
            this.flpButtons.Controls.Add(this.btnLog);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpButtons.Location = new System.Drawing.Point(0, 0);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(1067, 36);
            this.flpButtons.TabIndex = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ADD NEW";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(109, 4);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(116, 28);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // Kontrabon_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.gridKontrabon);
            this.Controls.Add(this.flpButtons);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Kontrabon_Form";
            this.Text = "KONTRABON";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKontrabon)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridKontrabon;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Create_Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Customers_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Customers_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Sent_Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_FollowUpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridKontrabon_Notes;
    }
}