namespace BinaMitraTextile.Gorden
{
    partial class GordenOrderDetails_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.scGridviews = new System.Windows.Forms.SplitContainer();
            this.col_gridmain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_statusenumid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_lineno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_priceperunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scGridviews)).BeginInit();
            this.scGridviews.Panel1.SuspendLayout();
            this.scGridviews.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 55);
            this.panel1.TabIndex = 95;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(624, 11);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(353, 32);
            this.lblTotalAmount.TabIndex = 130;
            this.lblTotalAmount.Text = "lblTotalAmount";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 21);
            this.button1.TabIndex = 116;
            this.button1.Text = "DELETE";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 11);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 21);
            this.btnAdd.TabIndex = 114;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(135, 11);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 21);
            this.btnClear.TabIndex = 115;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridmain_id,
            this.col_gridmain_statusenumid,
            this.col_gridmain_status,
            this.col_gridmain_lineno,
            this.col_gridmain_description,
            this.col_gridmain_qty,
            this.col_gridmain_priceperunit,
            this.col_gridmain_subtotal,
            this.col_gridmain_notes});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(500, 417);
            this.grid.TabIndex = 135;
            // 
            // scGridviews
            // 
            this.scGridviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGridviews.Location = new System.Drawing.Point(0, 55);
            this.scGridviews.Name = "scGridviews";
            // 
            // scGridviews.Panel1
            // 
            this.scGridviews.Panel1.Controls.Add(this.grid);
            this.scGridviews.Size = new System.Drawing.Size(988, 417);
            this.scGridviews.SplitterDistance = 500;
            this.scGridviews.TabIndex = 136;
            // 
            // col_gridmain_id
            // 
            this.col_gridmain_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridmain_id.HeaderText = "ID";
            this.col_gridmain_id.Name = "col_gridmain_id";
            this.col_gridmain_id.ReadOnly = true;
            this.col_gridmain_id.Visible = false;
            this.col_gridmain_id.Width = 24;
            // 
            // col_gridmain_statusenumid
            // 
            this.col_gridmain_statusenumid.HeaderText = "Status Enum ID";
            this.col_gridmain_statusenumid.Name = "col_gridmain_statusenumid";
            this.col_gridmain_statusenumid.ReadOnly = true;
            this.col_gridmain_statusenumid.Visible = false;
            // 
            // col_gridmain_status
            // 
            this.col_gridmain_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridmain_status.HeaderText = "Status";
            this.col_gridmain_status.Name = "col_gridmain_status";
            this.col_gridmain_status.ReadOnly = true;
            this.col_gridmain_status.Width = 62;
            // 
            // col_gridmain_lineno
            // 
            this.col_gridmain_lineno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridmain_lineno.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridmain_lineno.HeaderText = "No";
            this.col_gridmain_lineno.Name = "col_gridmain_lineno";
            this.col_gridmain_lineno.ReadOnly = true;
            this.col_gridmain_lineno.Width = 46;
            // 
            // col_gridmain_description
            // 
            this.col_gridmain_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.col_gridmain_description.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridmain_description.HeaderText = "Description";
            this.col_gridmain_description.Name = "col_gridmain_description";
            this.col_gridmain_description.ReadOnly = true;
            this.col_gridmain_description.Width = 85;
            // 
            // col_gridmain_qty
            // 
            this.col_gridmain_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridmain_qty.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridmain_qty.HeaderText = "Qty";
            this.col_gridmain_qty.Name = "col_gridmain_qty";
            this.col_gridmain_qty.ReadOnly = true;
            this.col_gridmain_qty.Width = 48;
            // 
            // col_gridmain_priceperunit
            // 
            this.col_gridmain_priceperunit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_gridmain_priceperunit.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_gridmain_priceperunit.HeaderText = "Price/Unit";
            this.col_gridmain_priceperunit.Name = "col_gridmain_priceperunit";
            this.col_gridmain_priceperunit.ReadOnly = true;
            this.col_gridmain_priceperunit.Width = 80;
            // 
            // col_gridmain_subtotal
            // 
            this.col_gridmain_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_gridmain_subtotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_gridmain_subtotal.HeaderText = "Subtotal";
            this.col_gridmain_subtotal.Name = "col_gridmain_subtotal";
            this.col_gridmain_subtotal.ReadOnly = true;
            this.col_gridmain_subtotal.Width = 71;
            // 
            // col_gridmain_notes
            // 
            this.col_gridmain_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridmain_notes.HeaderText = "Notes";
            this.col_gridmain_notes.Name = "col_gridmain_notes";
            this.col_gridmain_notes.ReadOnly = true;
            // 
            // GordenOrderDetails_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 472);
            this.Controls.Add(this.scGridviews);
            this.Controls.Add(this.panel1);
            this.Name = "GordenOrderDetails_Form";
            this.Text = "Gorden";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.scGridviews.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scGridviews)).EndInit();
            this.scGridviews.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.SplitContainer scGridviews;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_statusenumid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_lineno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_priceperunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_notes;


    }
}