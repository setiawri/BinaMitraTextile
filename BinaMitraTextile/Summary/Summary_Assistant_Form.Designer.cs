namespace BinaMitraTextile
{
    partial class Summary_Assistant_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.pnlFakturPajakRetur = new System.Windows.Forms.Panel();
            this.gridSaleInvoices = new System.Windows.Forms.DataGridView();
            this.col_gridSaleInvoices_Sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_hexbarcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridSaleInvoices_sale_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_sale_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_SaleAmount = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridSaleInvoices_FakturPajaks_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridSaleInvoices_FakturPajaks_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFakturPajakRetur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlFakturPajakRetur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.pnlFakturPajakRetur);
            this.scMain.Size = new System.Drawing.Size(726, 448);
            this.scMain.SplitterDistance = 363;
            this.scMain.TabIndex = 0;
            // 
            // pnlFakturPajakRetur
            // 
            this.pnlFakturPajakRetur.Controls.Add(this.gridSaleInvoices);
            this.pnlFakturPajakRetur.Controls.Add(this.lblFakturPajakRetur);
            this.pnlFakturPajakRetur.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFakturPajakRetur.Location = new System.Drawing.Point(0, 0);
            this.pnlFakturPajakRetur.Name = "pnlFakturPajakRetur";
            this.pnlFakturPajakRetur.Size = new System.Drawing.Size(363, 125);
            this.pnlFakturPajakRetur.TabIndex = 0;
            // 
            // gridSaleInvoices
            // 
            this.gridSaleInvoices.AllowUserToAddRows = false;
            this.gridSaleInvoices.AllowUserToDeleteRows = false;
            this.gridSaleInvoices.AllowUserToResizeRows = false;
            this.gridSaleInvoices.BackgroundColor = System.Drawing.Color.White;
            this.gridSaleInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSaleInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSaleInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSaleInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSaleInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridSaleInvoices_Sales_id,
            this.col_gridSaleInvoices_timestamp,
            this.col_gridSaleInvoices_hexbarcode,
            this.col_gridSaleInvoices_sale_qty,
            this.col_gridSaleInvoices_sale_length,
            this.col_gridSaleInvoices_SaleAmount,
            this.col_gridSaleInvoices_FakturPajaks_Id,
            this.col_gridSaleInvoices_FakturPajaks_No});
            this.gridSaleInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSaleInvoices.Location = new System.Drawing.Point(0, 23);
            this.gridSaleInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.gridSaleInvoices.MultiSelect = false;
            this.gridSaleInvoices.Name = "gridSaleInvoices";
            this.gridSaleInvoices.ReadOnly = true;
            this.gridSaleInvoices.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gridSaleInvoices.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gridSaleInvoices.RowTemplate.Height = 24;
            this.gridSaleInvoices.Size = new System.Drawing.Size(363, 102);
            this.gridSaleInvoices.TabIndex = 129;
            // 
            // col_gridSaleInvoices_Sales_id
            // 
            this.col_gridSaleInvoices_Sales_id.HeaderText = "id";
            this.col_gridSaleInvoices_Sales_id.Name = "col_gridSaleInvoices_Sales_id";
            this.col_gridSaleInvoices_Sales_id.ReadOnly = true;
            this.col_gridSaleInvoices_Sales_id.Visible = false;
            // 
            // col_gridSaleInvoices_timestamp
            // 
            this.col_gridSaleInvoices_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Format = "dd/MM/yy";
            this.col_gridSaleInvoices_timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridSaleInvoices_timestamp.HeaderText = "Date";
            this.col_gridSaleInvoices_timestamp.MinimumWidth = 50;
            this.col_gridSaleInvoices_timestamp.Name = "col_gridSaleInvoices_timestamp";
            this.col_gridSaleInvoices_timestamp.ReadOnly = true;
            this.col_gridSaleInvoices_timestamp.Width = 50;
            // 
            // col_gridSaleInvoices_hexbarcode
            // 
            this.col_gridSaleInvoices_hexbarcode.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_hexbarcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.col_gridSaleInvoices_hexbarcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridSaleInvoices_hexbarcode.HeaderText = "No";
            this.col_gridSaleInvoices_hexbarcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridSaleInvoices_hexbarcode.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_hexbarcode.MinimumWidth = 40;
            this.col_gridSaleInvoices_hexbarcode.Name = "col_gridSaleInvoices_hexbarcode";
            this.col_gridSaleInvoices_hexbarcode.ReadOnly = true;
            this.col_gridSaleInvoices_hexbarcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridSaleInvoices_hexbarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridSaleInvoices_hexbarcode.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            // 
            // col_gridSaleInvoices_sale_qty
            // 
            this.col_gridSaleInvoices_sale_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.col_gridSaleInvoices_sale_qty.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridSaleInvoices_sale_qty.HeaderText = "Pcs";
            this.col_gridSaleInvoices_sale_qty.MinimumWidth = 30;
            this.col_gridSaleInvoices_sale_qty.Name = "col_gridSaleInvoices_sale_qty";
            this.col_gridSaleInvoices_sale_qty.ReadOnly = true;
            this.col_gridSaleInvoices_sale_qty.Width = 30;
            // 
            // col_gridSaleInvoices_sale_length
            // 
            this.col_gridSaleInvoices_sale_length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.col_gridSaleInvoices_sale_length.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_gridSaleInvoices_sale_length.HeaderText = "Qty";
            this.col_gridSaleInvoices_sale_length.MinimumWidth = 30;
            this.col_gridSaleInvoices_sale_length.Name = "col_gridSaleInvoices_sale_length";
            this.col_gridSaleInvoices_sale_length.ReadOnly = true;
            this.col_gridSaleInvoices_sale_length.Width = 30;
            // 
            // col_gridSaleInvoices_SaleAmount
            // 
            this.col_gridSaleInvoices_SaleAmount.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.Format = "N0";
            this.col_gridSaleInvoices_SaleAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_gridSaleInvoices_SaleAmount.HeaderText = "Amount";
            this.col_gridSaleInvoices_SaleAmount.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.col_gridSaleInvoices_SaleAmount.LinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.MinimumWidth = 50;
            this.col_gridSaleInvoices_SaleAmount.Name = "col_gridSaleInvoices_SaleAmount";
            this.col_gridSaleInvoices_SaleAmount.ReadOnly = true;
            this.col_gridSaleInvoices_SaleAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridSaleInvoices_SaleAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridSaleInvoices_SaleAmount.VisitedLinkColor = System.Drawing.Color.SpringGreen;
            this.col_gridSaleInvoices_SaleAmount.Width = 50;
            // 
            // col_gridSaleInvoices_FakturPajaks_Id
            // 
            this.col_gridSaleInvoices_FakturPajaks_Id.HeaderText = "FakturPajaks_Id";
            this.col_gridSaleInvoices_FakturPajaks_Id.Name = "col_gridSaleInvoices_FakturPajaks_Id";
            this.col_gridSaleInvoices_FakturPajaks_Id.ReadOnly = true;
            this.col_gridSaleInvoices_FakturPajaks_Id.Visible = false;
            // 
            // col_gridSaleInvoices_FakturPajaks_No
            // 
            this.col_gridSaleInvoices_FakturPajaks_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_gridSaleInvoices_FakturPajaks_No.HeaderText = "FP";
            this.col_gridSaleInvoices_FakturPajaks_No.MinimumWidth = 30;
            this.col_gridSaleInvoices_FakturPajaks_No.Name = "col_gridSaleInvoices_FakturPajaks_No";
            this.col_gridSaleInvoices_FakturPajaks_No.ReadOnly = true;
            this.col_gridSaleInvoices_FakturPajaks_No.Width = 30;
            // 
            // lblFakturPajakRetur
            // 
            this.lblFakturPajakRetur.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFakturPajakRetur.Location = new System.Drawing.Point(0, 0);
            this.lblFakturPajakRetur.Name = "lblFakturPajakRetur";
            this.lblFakturPajakRetur.Size = new System.Drawing.Size(363, 23);
            this.lblFakturPajakRetur.TabIndex = 130;
            this.lblFakturPajakRetur.Text = "lblFakturPajakRetur";
            this.lblFakturPajakRetur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Summary2_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 448);
            this.Controls.Add(this.scMain);
            this.Name = "Summary2_Form";
            this.Text = "SUMMARY";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.scMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlFakturPajakRetur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSaleInvoices)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel pnlFakturPajakRetur;
        private System.Windows.Forms.DataGridView gridSaleInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_Sales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_timestamp;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridSaleInvoices_hexbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_sale_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_sale_length;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridSaleInvoices_SaleAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_FakturPajaks_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridSaleInvoices_FakturPajaks_No;
        private System.Windows.Forms.Label lblFakturPajakRetur;
    }
}