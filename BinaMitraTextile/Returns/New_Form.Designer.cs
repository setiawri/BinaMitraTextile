namespace BinaMitraTextile.Returns
{
    partial class New_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridSummary = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalCounts = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.DeleteRow = new System.Windows.Forms.DataGridViewLinkColumn();
            this.barcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.inventory_code = new System.Windows.Forms.DataGridViewLinkColumn();
            this.product_name_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_width_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LengthUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adjustment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeNameSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Add Barcode (Alt+A)";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(117, 7);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(96, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteRow,
            this.barcode,
            this.inventory_code,
            this.product_name_store,
            this.GradeName,
            this.product_width_name,
            this.Color,
            this.Length,
            this.LengthUnitName,
            this.SellPrice,
            this.Adjustment,
            this.Subtotal,
            this.id});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle9;
            this.grid.Location = new System.Drawing.Point(13, 30);
            this.grid.Margin = new System.Windows.Forms.Padding(2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(950, 266);
            this.grid.TabIndex = 96;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // gridSummary
            // 
            this.gridSummary.AllowUserToAddRows = false;
            this.gridSummary.AllowUserToDeleteRows = false;
            this.gridSummary.AllowUserToResizeRows = false;
            this.gridSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSummary.BackgroundColor = System.Drawing.Color.White;
            this.gridSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn2,
            this.dataGridViewTextBoxColumn1,
            this.GradeNameSummary,
            this.dataGridViewTextBoxColumn2,
            this.ColorSummary,
            this.qty,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7});
            this.gridSummary.Location = new System.Drawing.Point(11, 300);
            this.gridSummary.Margin = new System.Windows.Forms.Padding(2);
            this.gridSummary.MultiSelect = false;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.ReadOnly = true;
            this.gridSummary.RowHeadersVisible = false;
            this.gridSummary.RowTemplate.Height = 24;
            this.gridSummary.Size = new System.Drawing.Size(640, 210);
            this.gridSummary.TabIndex = 109;
            this.gridSummary.SelectionChanged += new System.EventHandler(this.gridSummary_SelectionChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(655, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 110;
            this.label3.Text = "Customer:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(741, 300);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(135, 20);
            this.lblCustomerName.TabIndex = 111;
            this.lblCustomerName.Text = "lblCustomerName";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(659, 448);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(305, 32);
            this.lblTotalAmount.TabIndex = 113;
            this.lblTotalAmount.Text = "GrandTotal";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCounts.Location = new System.Drawing.Point(659, 422);
            this.lblTotalCounts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(304, 20);
            this.lblTotalCounts.TabIndex = 112;
            this.lblTotalCounts.Text = "TotalCounts";
            this.lblTotalCounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(876, 482);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 28);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(663, 327);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 117;
            this.label8.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(699, 327);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(263, 86);
            this.txtNotes.TabIndex = 1;
            // 
            // DeleteRow
            // 
            this.DeleteRow.HeaderText = "";
            this.DeleteRow.Name = "DeleteRow";
            this.DeleteRow.ReadOnly = true;
            this.DeleteRow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteRow.Text = "X";
            this.DeleteRow.UseColumnTextForLinkValue = true;
            this.DeleteRow.Width = 40;
            // 
            // barcode
            // 
            this.barcode.ActiveLinkColor = System.Drawing.Color.Orange;
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "Barcode";
            this.barcode.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.barcode.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.barcode.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.barcode.Width = 50;
            // 
            // inventory_code
            // 
            this.inventory_code.ActiveLinkColor = System.Drawing.Color.Orange;
            this.inventory_code.DataPropertyName = "inventory_code";
            this.inventory_code.HeaderText = "Code";
            this.inventory_code.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.inventory_code.Name = "inventory_code";
            this.inventory_code.ReadOnly = true;
            this.inventory_code.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inventory_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.inventory_code.VisitedLinkColor = System.Drawing.Color.CornflowerBlue;
            this.inventory_code.Width = 60;
            // 
            // product_name_store
            // 
            this.product_name_store.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.product_name_store.DataPropertyName = "product_store_name";
            this.product_name_store.HeaderText = "Product";
            this.product_name_store.Name = "product_name_store";
            this.product_name_store.ReadOnly = true;
            // 
            // GradeName
            // 
            this.GradeName.DataPropertyName = "grade_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GradeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.GradeName.HeaderText = "Grade";
            this.GradeName.Name = "GradeName";
            this.GradeName.ReadOnly = true;
            // 
            // product_width_name
            // 
            this.product_width_name.DataPropertyName = "length_width_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.product_width_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.product_width_name.HeaderText = "Lebar (cm)";
            this.product_width_name.Name = "product_width_name";
            this.product_width_name.ReadOnly = true;
            this.product_width_name.Width = 30;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "color_name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Color.DefaultCellStyle = dataGridViewCellStyle4;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "item_length";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Length.DefaultCellStyle = dataGridViewCellStyle5;
            this.Length.HeaderText = "Qty";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.Width = 60;
            // 
            // LengthUnitName
            // 
            this.LengthUnitName.DataPropertyName = "length_unit_name";
            this.LengthUnitName.HeaderText = "Unit";
            this.LengthUnitName.Name = "LengthUnitName";
            this.LengthUnitName.ReadOnly = true;
            this.LengthUnitName.Width = 50;
            // 
            // SellPrice
            // 
            this.SellPrice.DataPropertyName = "sell_price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.SellPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.SellPrice.HeaderText = "Price/Unit";
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.ReadOnly = true;
            // 
            // Adjustment
            // 
            this.Adjustment.DataPropertyName = "adjustment";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Adjustment.DefaultCellStyle = dataGridViewCellStyle7;
            this.Adjustment.HeaderText = "Adj/unit";
            this.Adjustment.Name = "Adjustment";
            this.Adjustment.ReadOnly = true;
            this.Adjustment.Width = 60;
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "subtotal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.DataPropertyName = "inventory_code";
            this.dataGridViewLinkColumn2.HeaderText = "Code";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            this.dataGridViewLinkColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "product_store_name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Product";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // GradeNameSummary
            // 
            this.GradeNameSummary.DataPropertyName = "grade_name";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GradeNameSummary.DefaultCellStyle = dataGridViewCellStyle11;
            this.GradeNameSummary.HeaderText = "Grade";
            this.GradeNameSummary.Name = "GradeNameSummary";
            this.GradeNameSummary.ReadOnly = true;
            this.GradeNameSummary.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "length_width_name";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn2.HeaderText = "Lebar (cm)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // ColorSummary
            // 
            this.ColorSummary.DataPropertyName = "color_name";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColorSummary.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColorSummary.HeaderText = "Color";
            this.ColorSummary.Name = "ColorSummary";
            this.ColorSummary.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qty.DefaultCellStyle = dataGridViewCellStyle14;
            this.qty.HeaderText = "Pcs";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "item_length";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn3.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "length_unit_name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "subtotal";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn7.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // New_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 521);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalCounts);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridSummary);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.grid);
            this.Name = "New_Form";
            this.Text = "Return Items";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridView gridSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalCounts;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteRow;
        private System.Windows.Forms.DataGridViewLinkColumn barcode;
        private System.Windows.Forms.DataGridViewLinkColumn inventory_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_width_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adjustment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeNameSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    }
}