﻿namespace BinaMitraTextile.InventoryForm
{
    partial class Items_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Items_Form));
            this.label2 = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLengthUnit = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_gridInventoryItems_lastOpname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_colorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_SaleOrderItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInventoryID = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.gbForm = new System.Windows.Forms.GroupBox();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.cbColors = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblReceived = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.gbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Barcode";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(66, 21);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(57, 13);
            this.lblBarcode.TabIndex = 7;
            this.lblBarcode.Text = "lblBarcode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(67, 36);
            this.txtLength.Margin = new System.Windows.Forms.Padding(2);
            this.txtLength.MaxLength = 7;
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(47, 20);
            this.txtLength.TabIndex = 0;
            this.txtLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLength_KeyDown);
            // 
            // lblLengthUnit
            // 
            this.lblLengthUnit.AutoSize = true;
            this.lblLengthUnit.Location = new System.Drawing.Point(117, 39);
            this.lblLengthUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLengthUnit.Name = "lblLengthUnit";
            this.lblLengthUnit.Size = new System.Drawing.Size(69, 13);
            this.lblLengthUnit.TabIndex = 14;
            this.lblLengthUnit.Text = "lblLengthUnit";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(67, 166);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(85, 25);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            this.col_grid_id,
            this.Barcode,
            this.Length,
            this.Sold,
            this.col_gridInventoryItems_lastOpname,
            this.col_grid_colorname,
            this.col_grid_SaleOrderItemDescription,
            this.col_grid_notes});
            this.grid.Location = new System.Drawing.Point(276, 16);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(628, 483);
            this.grid.TabIndex = 1;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // col_grid_id
            // 
            this.col_grid_id.HeaderText = "ID";
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            // 
            // Barcode
            // 
            this.Barcode.ActiveLinkColor = System.Drawing.Color.Orange;
            this.Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Barcode.DataPropertyName = "barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.Barcode.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.Barcode.MinimumWidth = 50;
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Barcode.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.Barcode.Width = 50;
            // 
            // Length
            // 
            this.Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Length.DataPropertyName = "item_length";
            this.Length.HeaderText = "Length";
            this.Length.MinimumWidth = 50;
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 50;
            // 
            // Sold
            // 
            this.Sold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Sold.DataPropertyName = "isSold";
            this.Sold.HeaderText = "Sold";
            this.Sold.MinimumWidth = 30;
            this.Sold.Name = "Sold";
            this.Sold.ReadOnly = true;
            this.Sold.Width = 30;
            // 
            // col_gridInventoryItems_lastOpname
            // 
            this.col_gridInventoryItems_lastOpname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Format = "dd/MM/yy HH:mm";
            this.col_gridInventoryItems_lastOpname.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridInventoryItems_lastOpname.HeaderText = "Opname";
            this.col_gridInventoryItems_lastOpname.MinimumWidth = 50;
            this.col_gridInventoryItems_lastOpname.Name = "col_gridInventoryItems_lastOpname";
            this.col_gridInventoryItems_lastOpname.ReadOnly = true;
            this.col_gridInventoryItems_lastOpname.Width = 50;
            // 
            // col_grid_colorname
            // 
            this.col_grid_colorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_colorname.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_grid_colorname.HeaderText = "Color";
            this.col_grid_colorname.MinimumWidth = 50;
            this.col_grid_colorname.Name = "col_grid_colorname";
            this.col_grid_colorname.ReadOnly = true;
            this.col_grid_colorname.Width = 50;
            // 
            // col_grid_SaleOrderItemDescription
            // 
            this.col_grid_SaleOrderItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.col_grid_SaleOrderItemDescription.HeaderText = "SO";
            this.col_grid_SaleOrderItemDescription.MinimumWidth = 30;
            this.col_grid_SaleOrderItemDescription.Name = "col_grid_SaleOrderItemDescription";
            this.col_grid_SaleOrderItemDescription.ReadOnly = true;
            this.col_grid_SaleOrderItemDescription.Width = 30;
            // 
            // col_grid_notes
            // 
            this.col_grid_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_notes.HeaderText = "Notes";
            this.col_grid_notes.Name = "col_grid_notes";
            this.col_grid_notes.ReadOnly = true;
            // 
            // lblInventoryID
            // 
            this.lblInventoryID.AutoSize = true;
            this.lblInventoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryID.Location = new System.Drawing.Point(16, 16);
            this.lblInventoryID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInventoryID.Name = "lblInventoryID";
            this.lblInventoryID.Size = new System.Drawing.Size(182, 31);
            this.lblInventoryID.TabIndex = 55;
            this.lblInventoryID.Text = "lblInventoryID";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(97, 159);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarcode.MaxLength = 36;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(68, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "New Barcode";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(90, 52);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(123, 26);
            this.lblCount.TabIndex = 61;
            this.lblCount.Text = "lblAvailable";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbForm
            // 
            this.gbForm.Controls.Add(this.btnAddColor);
            this.gbForm.Controls.Add(this.cbColors);
            this.gbForm.Controls.Add(this.label7);
            this.gbForm.Controls.Add(this.label4);
            this.gbForm.Controls.Add(this.label2);
            this.gbForm.Controls.Add(this.txtNotes);
            this.gbForm.Controls.Add(this.lblBarcode);
            this.gbForm.Controls.Add(this.btnSubmit);
            this.gbForm.Controls.Add(this.label3);
            this.gbForm.Controls.Add(this.lblLengthUnit);
            this.gbForm.Controls.Add(this.txtLength);
            this.gbForm.Location = new System.Drawing.Point(20, 180);
            this.gbForm.Margin = new System.Windows.Forms.Padding(2);
            this.gbForm.Name = "gbForm";
            this.gbForm.Padding = new System.Windows.Forms.Padding(2);
            this.gbForm.Size = new System.Drawing.Size(237, 209);
            this.gbForm.TabIndex = 1;
            this.gbForm.TabStop = false;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddColor.BackColor = System.Drawing.Color.Transparent;
            this.btnAddColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddColor.BackgroundImage")));
            this.btnAddColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddColor.Enabled = false;
            this.btnAddColor.FlatAppearance.BorderSize = 0;
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.Location = new System.Drawing.Point(208, 62);
            this.btnAddColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(15, 16);
            this.btnAddColor.TabIndex = 128;
            this.btnAddColor.UseVisualStyleBackColor = false;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // cbColors
            // 
            this.cbColors.Enabled = false;
            this.cbColors.FormattingEnabled = true;
            this.cbColors.Location = new System.Drawing.Point(67, 60);
            this.cbColors.Margin = new System.Windows.Forms.Padding(2);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(137, 21);
            this.cbColors.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 63);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Warna roll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(67, 85);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(137, 50);
            this.txtNotes.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Color:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(94, 97);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(41, 13);
            this.lblColor.TabIndex = 64;
            this.lblColor.Text = "lblColor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Available:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(94, 110);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(45, 13);
            this.lblWidth.TabIndex = 67;
            this.lblWidth.Text = "lblWidth";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Lebar:";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(94, 123);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(46, 13);
            this.lblGrade.TabIndex = 69;
            this.lblGrade.Text = "lblGrade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 68;
            this.label9.Text = "Grade:";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Location = new System.Drawing.Point(94, 136);
            this.lblReceiveDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(80, 13);
            this.lblReceiveDate.TabIndex = 71;
            this.lblReceiveDate.Text = "lblReceiveDate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Received:";
            // 
            // lblReceived
            // 
            this.lblReceived.AutoSize = true;
            this.lblReceived.Location = new System.Drawing.Point(94, 84);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(63, 13);
            this.lblReceived.TabIndex = 73;
            this.lblReceived.Text = "lblReceived";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "Received:";
            // 
            // Items_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 511);
            this.Controls.Add(this.lblReceived);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblReceiveDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbForm);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.lblInventoryID);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Items_Form";
            this.Text = "INVENTORY ITEMS";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.gbForm.ResumeLayout(false);
            this.gbForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLengthUnit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblInventoryID;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbColors;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Label lblReceived;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        private System.Windows.Forms.DataGridViewLinkColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridInventoryItems_lastOpname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_colorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_SaleOrderItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_grid_notes;
    }
}