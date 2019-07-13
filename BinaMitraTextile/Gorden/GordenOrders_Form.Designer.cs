namespace BinaMitraTextile.Gorden
{
    partial class GordenOrders_Form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_items = new System.Windows.Forms.ToolStripMenuItem();
            this.gridOrders = new System.Windows.Forms.DataGridView();
            this.col_gridorders_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridorders_orderno = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridorders_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridorders_customername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridorders_orderamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridorders_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dropCustomers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.menu_details = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_new,
            this.menu_edit,
            this.menu_details,
            this.menu_items});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(458, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_new
            // 
            this.menu_new.Name = "menu_new";
            this.menu_new.Size = new System.Drawing.Size(43, 20);
            this.menu_new.Text = "New";
            this.menu_new.Click += new System.EventHandler(this.menu_new_Click);
            // 
            // menu_edit
            // 
            this.menu_edit.Name = "menu_edit";
            this.menu_edit.Size = new System.Drawing.Size(39, 20);
            this.menu_edit.Text = "Edit";
            this.menu_edit.Click += new System.EventHandler(this.menu_edit_Click);
            // 
            // menu_items
            // 
            this.menu_items.Name = "menu_items";
            this.menu_items.Size = new System.Drawing.Size(48, 20);
            this.menu_items.Text = "Items";
            this.menu_items.Click += new System.EventHandler(this.menu_items_Click);
            // 
            // gridOrders
            // 
            this.gridOrders.AllowUserToAddRows = false;
            this.gridOrders.AllowUserToDeleteRows = false;
            this.gridOrders.AllowUserToResizeRows = false;
            this.gridOrders.BackgroundColor = System.Drawing.Color.White;
            this.gridOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridorders_id,
            this.col_gridorders_orderno,
            this.col_gridorders_timestamp,
            this.col_gridorders_customername,
            this.col_gridorders_orderamount,
            this.col_gridorders_notes});
            this.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrders.Location = new System.Drawing.Point(0, 79);
            this.gridOrders.Margin = new System.Windows.Forms.Padding(2);
            this.gridOrders.MultiSelect = false;
            this.gridOrders.Name = "gridOrders";
            this.gridOrders.ReadOnly = true;
            this.gridOrders.RowHeadersVisible = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridOrders.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridOrders.RowTemplate.Height = 24;
            this.gridOrders.Size = new System.Drawing.Size(458, 393);
            this.gridOrders.TabIndex = 94;
            this.gridOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOrders_CellContentClick);
            // 
            // col_gridorders_id
            // 
            this.col_gridorders_id.HeaderText = "ID";
            this.col_gridorders_id.Name = "col_gridorders_id";
            this.col_gridorders_id.ReadOnly = true;
            this.col_gridorders_id.Visible = false;
            // 
            // col_gridorders_orderno
            // 
            this.col_gridorders_orderno.ActiveLinkColor = System.Drawing.Color.DarkOrange;
            this.col_gridorders_orderno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.col_gridorders_orderno.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridorders_orderno.HeaderText = "No";
            this.col_gridorders_orderno.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridorders_orderno.LinkColor = System.Drawing.Color.DarkOrange;
            this.col_gridorders_orderno.Name = "col_gridorders_orderno";
            this.col_gridorders_orderno.ReadOnly = true;
            this.col_gridorders_orderno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridorders_orderno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridorders_orderno.VisitedLinkColor = System.Drawing.Color.DarkOrange;
            this.col_gridorders_orderno.Width = 42;
            // 
            // col_gridorders_timestamp
            // 
            this.col_gridorders_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "dd/MM/yy HH:mm";
            this.col_gridorders_timestamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridorders_timestamp.HeaderText = "Date";
            this.col_gridorders_timestamp.Name = "col_gridorders_timestamp";
            this.col_gridorders_timestamp.ReadOnly = true;
            this.col_gridorders_timestamp.Width = 50;
            // 
            // col_gridorders_customername
            // 
            this.col_gridorders_customername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridorders_customername.HeaderText = "Customer";
            this.col_gridorders_customername.Name = "col_gridorders_customername";
            this.col_gridorders_customername.ReadOnly = true;
            this.col_gridorders_customername.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridorders_customername.Width = 71;
            // 
            // col_gridorders_orderamount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_gridorders_orderamount.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridorders_orderamount.HeaderText = "Amount";
            this.col_gridorders_orderamount.Name = "col_gridorders_orderamount";
            this.col_gridorders_orderamount.ReadOnly = true;
            // 
            // col_gridorders_notes
            // 
            this.col_gridorders_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridorders_notes.HeaderText = "Notes";
            this.col_gridorders_notes.Name = "col_gridorders_notes";
            this.col_gridorders_notes.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtOrderNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dropCustomers);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 55);
            this.panel1.TabIndex = 95;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(396, 3);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(56, 21);
            this.btnFilter.TabIndex = 114;
            this.btnFilter.Text = "FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(396, 27);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 21);
            this.btnClear.TabIndex = 115;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(248, 29);
            this.txtOrderNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(84, 20);
            this.txtOrderNo.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "No";
            // 
            // dropCustomers
            // 
            this.dropCustomers.FormattingEnabled = true;
            this.dropCustomers.Location = new System.Drawing.Point(248, 4);
            this.dropCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.dropCustomers.Name = "dropCustomers";
            this.dropCustomers.Size = new System.Drawing.Size(135, 21);
            this.dropCustomers.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 98;
            this.label1.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "From";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "ddd, dd/MM/yy";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(47, 5);
            this.dtStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtStart.Name = "dtStart";
            this.dtStart.ShowCheckBox = true;
            this.dtStart.Size = new System.Drawing.Size(134, 20);
            this.dtStart.TabIndex = 5;
            this.dtStart.Value = new System.DateTime(2014, 11, 15, 0, 0, 0, 0);
            // 
            // dtEnd
            // 
            this.dtEnd.Checked = false;
            this.dtEnd.CustomFormat = "ddd, dd/MM/yy";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(47, 29);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ShowCheckBox = true;
            this.dtEnd.Size = new System.Drawing.Size(134, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // menu_details
            // 
            this.menu_details.Name = "menu_details";
            this.menu_details.Size = new System.Drawing.Size(54, 20);
            this.menu_details.Text = "Details";
            this.menu_details.Click += new System.EventHandler(this.menu_details_Click);
            // 
            // GordenOrders_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 472);
            this.Controls.Add(this.gridOrders);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GordenOrders_Form";
            this.Text = "Gorden";
            this.Load += new System.EventHandler(this.Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_items;
        private System.Windows.Forms.ToolStripMenuItem menu_new;
        private System.Windows.Forms.DataGridView gridOrders;
        private System.Windows.Forms.ToolStripMenuItem menu_edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dropCustomers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridorders_id;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridorders_orderno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridorders_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridorders_customername;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridorders_orderamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridorders_notes;
        private System.Windows.Forms.ToolStripMenuItem menu_details;


    }
}