namespace BinaMitraTextile.Gorden
{
    partial class GordenOrderPrint_Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.pnlPrint = new System.Windows.Forms.Panel();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_gridmain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_lineno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_priceperunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.chkWorkOrder = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 130;
            this.label3.Text = "GORDEN ORDER";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(310, 25);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(127, 28);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(496, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 57);
            this.label8.TabIndex = 129;
            this.label8.Text = "Jl. Mayor Sunarya Blok K No. 11A\r\nBandung, Jawa Barat\r\nsimpati/whatsapp: 081.2240" +
    ".44338\r\npin bb: 74E4F9D9, bina.mitra.textile@gmail.com";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(56, 71);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(46, 15);
            this.lblDate.TabIndex = 127;
            this.lblDate.Text = "lblDate";
            // 
            // lblNotes
            // 
            this.lblNotes.Location = new System.Drawing.Point(58, 454);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(348, 61);
            this.lblNotes.TabIndex = 118;
            this.lblNotes.Text = "lblNotes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 454);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Notes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 126;
            this.label4.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 119;
            this.label2.Text = "CV. BINA MITRA TEXTILE";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(410, 454);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(322, 32);
            this.lblTotalAmount.TabIndex = 115;
            this.lblTotalAmount.Text = "GrandTotal";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPrint
            // 
            this.pnlPrint.Controls.Add(this.lblPageCount);
            this.pnlPrint.Controls.Add(this.grid);
            this.pnlPrint.Controls.Add(this.lblNo);
            this.pnlPrint.Controls.Add(this.label3);
            this.pnlPrint.Controls.Add(this.label8);
            this.pnlPrint.Controls.Add(this.lblDate);
            this.pnlPrint.Controls.Add(this.lblNotes);
            this.pnlPrint.Controls.Add(this.label1);
            this.pnlPrint.Controls.Add(this.label4);
            this.pnlPrint.Controls.Add(this.lblCustomerInfo);
            this.pnlPrint.Controls.Add(this.label2);
            this.pnlPrint.Controls.Add(this.lblTotalAmount);
            this.pnlPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrint.Location = new System.Drawing.Point(0, 0);
            this.pnlPrint.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(746, 521);
            this.pnlPrint.TabIndex = 113;
            // 
            // lblPageCount
            // 
            this.lblPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCount.Location = new System.Drawing.Point(643, 499);
            this.lblPageCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(89, 16);
            this.lblPageCount.TabIndex = 156;
            this.lblPageCount.Text = "lblPageCount";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
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
            this.col_gridmain_lineno,
            this.col_gridmain_description,
            this.col_gridmain_qty,
            this.col_gridmain_priceperunit,
            this.col_gridmain_subtotal,
            this.col_gridmain_notes});
            this.grid.Location = new System.Drawing.Point(19, 104);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(713, 340);
            this.grid.TabIndex = 134;
            // 
            // col_gridmain_id
            // 
            this.col_gridmain_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridmain_id.HeaderText = "ID";
            this.col_gridmain_id.Name = "col_gridmain_id";
            this.col_gridmain_id.ReadOnly = true;
            this.col_gridmain_id.Visible = false;
            // 
            // col_gridmain_lineno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridmain_lineno.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridmain_lineno.HeaderText = "No";
            this.col_gridmain_lineno.Name = "col_gridmain_lineno";
            this.col_gridmain_lineno.ReadOnly = true;
            this.col_gridmain_lineno.Width = 30;
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
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.Location = new System.Drawing.Point(16, 42);
            this.lblNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(74, 16);
            this.lblNo.TabIndex = 133;
            this.lblNo.Text = "lblOrderNo";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.Location = new System.Drawing.Point(178, 22);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(314, 80);
            this.lblCustomerInfo.TabIndex = 120;
            this.lblCustomerInfo.Text = "lblCustomerInfo";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.chkShowPrintDialog);
            this.pnlButtons.Controls.Add(this.btnPrevious);
            this.pnlButtons.Controls.Add(this.chkWorkOrder);
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 521);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(746, 58);
            this.pnlButtons.TabIndex = 0;
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.AutoSize = true;
            this.chkShowPrintDialog.Location = new System.Drawing.Point(385, 5);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(77, 17);
            this.chkShowPrintDialog.TabIndex = 116;
            this.chkShowPrintDialog.Text = "print dialog";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(209, 25);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(97, 28);
            this.btnPrevious.TabIndex = 114;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // chkWorkOrder
            // 
            this.chkWorkOrder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkWorkOrder.AutoSize = true;
            this.chkWorkOrder.Location = new System.Drawing.Point(310, 5);
            this.chkWorkOrder.Name = "chkWorkOrder";
            this.chkWorkOrder.Size = new System.Drawing.Size(76, 17);
            this.chkWorkOrder.TabIndex = 1;
            this.chkWorkOrder.Text = "work order";
            this.chkWorkOrder.UseVisualStyleBackColor = true;
            this.chkWorkOrder.CheckedChanged += new System.EventHandler(this.chkWorkOrder_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(441, 25);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 28);
            this.btnNext.TabIndex = 115;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // GordenOrderPrint_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(746, 579);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.pnlButtons);
            this.Name = "GordenOrderPrint_Form";
            this.Text = "GORDEN";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel pnlPrint;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.CheckBox chkWorkOrder;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_lineno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_priceperunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_notes;
        private System.Windows.Forms.CheckBox chkShowPrintDialog;
    }
}