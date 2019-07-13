namespace BinaMitraTextile.Invoices
{
    partial class VendorInvoices_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scButtonsAndFilters = new System.Windows.Forms.SplitContainer();
            this.btnSupplierDebits = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.scData = new System.Windows.Forms.SplitContainer();
            this.gridvendorinvoice = new System.Windows.Forms.DataGridView();
            this.gridinventory = new System.Windows.Forms.DataGridView();
            this.col_gridinventory_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_receivedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_gradename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_productwidthname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_colorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_buyprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_unitname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridinventory_packinglistno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_invoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_taxno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_dpp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_totaldppppn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_totalactualvalue = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_gridvendorinvoice_top = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_isdue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_gridvendorinvoice_PayableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_statusenumid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridvendorinvoice_statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scButtonsAndFilters)).BeginInit();
            this.scButtonsAndFilters.Panel1.SuspendLayout();
            this.scButtonsAndFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scData)).BeginInit();
            this.scData.Panel1.SuspendLayout();
            this.scData.Panel2.SuspendLayout();
            this.scData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridvendorinvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridinventory)).BeginInit();
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
            this.scMain.Panel1.Controls.Add(this.scButtonsAndFilters);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scData);
            this.scMain.Size = new System.Drawing.Size(908, 564);
            this.scMain.SplitterDistance = 227;
            this.scMain.TabIndex = 0;
            // 
            // scButtonsAndFilters
            // 
            this.scButtonsAndFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scButtonsAndFilters.Location = new System.Drawing.Point(0, 0);
            this.scButtonsAndFilters.Name = "scButtonsAndFilters";
            this.scButtonsAndFilters.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scButtonsAndFilters.Panel1
            // 
            this.scButtonsAndFilters.Panel1.Controls.Add(this.btnSupplierDebits);
            this.scButtonsAndFilters.Panel1.Controls.Add(this.btnLog);
            this.scButtonsAndFilters.Panel1.Controls.Add(this.btnUpdate);
            this.scButtonsAndFilters.Size = new System.Drawing.Size(227, 564);
            this.scButtonsAndFilters.SplitterDistance = 49;
            this.scButtonsAndFilters.TabIndex = 0;
            // 
            // btnSupplierDebits
            // 
            this.btnSupplierDebits.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnSupplierDebits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierDebits.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSupplierDebits.Location = new System.Drawing.Point(70, 10);
            this.btnSupplierDebits.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierDebits.Name = "btnSupplierDebits";
            this.btnSupplierDebits.Size = new System.Drawing.Size(87, 28);
            this.btnSupplierDebits.TabIndex = 115;
            this.btnSupplierDebits.Text = "DEBITS";
            this.btnSupplierDebits.UseVisualStyleBackColor = true;
            this.btnSupplierDebits.Click += new System.EventHandler(this.btnSupplierDebits_Click);
            // 
            // btnLog
            // 
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLog.Location = new System.Drawing.Point(157, 10);
            this.btnLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(59, 28);
            this.btnLog.TabIndex = 114;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(11, 10);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(59, 28);
            this.btnUpdate.TabIndex = 113;
            this.btnUpdate.Text = "EDIT";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // scData
            // 
            this.scData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scData.Location = new System.Drawing.Point(0, 0);
            this.scData.Name = "scData";
            this.scData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scData.Panel1
            // 
            this.scData.Panel1.Controls.Add(this.gridvendorinvoice);
            // 
            // scData.Panel2
            // 
            this.scData.Panel2.Controls.Add(this.gridinventory);
            this.scData.Size = new System.Drawing.Size(677, 564);
            this.scData.SplitterDistance = 350;
            this.scData.TabIndex = 7;
            // 
            // gridvendorinvoice
            // 
            this.gridvendorinvoice.AllowUserToAddRows = false;
            this.gridvendorinvoice.AllowUserToDeleteRows = false;
            this.gridvendorinvoice.AllowUserToResizeRows = false;
            this.gridvendorinvoice.BackgroundColor = System.Drawing.Color.White;
            this.gridvendorinvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridvendorinvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridvendorinvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridvendorinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridvendorinvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridvendorinvoice_id,
            this.col_gridvendorinvoice_timestamp,
            this.col_gridvendorinvoice_invoiceno,
            this.col_gridvendorinvoice_vendorname,
            this.col_gridvendorinvoice_taxno,
            this.col_gridvendorinvoice_dpp,
            this.col_gridvendorinvoice_totaldppppn,
            this.col_gridvendorinvoice_totalactualvalue,
            this.col_gridvendorinvoice_top,
            this.col_gridvendorinvoice_isdue,
            this.col_gridvendorinvoice_PayableAmount,
            this.col_gridvendorinvoice_notes,
            this.col_gridvendorinvoice_statusenumid,
            this.col_gridvendorinvoice_statusname});
            this.gridvendorinvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridvendorinvoice.Location = new System.Drawing.Point(0, 0);
            this.gridvendorinvoice.Name = "gridvendorinvoice";
            this.gridvendorinvoice.RowHeadersVisible = false;
            this.gridvendorinvoice.Size = new System.Drawing.Size(677, 350);
            this.gridvendorinvoice.TabIndex = 6;
            this.gridvendorinvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridvendorinvoice_CellContentClick);
            this.gridvendorinvoice.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_CellMouseDown);
            this.gridvendorinvoice.SelectionChanged += new System.EventHandler(this.gridvendorinvoice_SelectionChanged);
            // 
            // gridinventory
            // 
            this.gridinventory.AllowUserToAddRows = false;
            this.gridinventory.AllowUserToDeleteRows = false;
            this.gridinventory.AllowUserToResizeRows = false;
            this.gridinventory.BackgroundColor = System.Drawing.Color.White;
            this.gridinventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridinventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridinventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridinventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridinventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridinventory_id,
            this.col_gridinventory_receivedate,
            this.col_gridinventory_code,
            this.col_gridinventory_gradename,
            this.col_gridinventory_productname,
            this.col_gridinventory_productwidthname,
            this.col_gridinventory_colorname,
            this.col_gridinventory_buyprice,
            this.col_gridinventory_unitname,
            this.col_gridinventory_packinglistno});
            this.gridinventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridinventory.Location = new System.Drawing.Point(0, 0);
            this.gridinventory.Name = "gridinventory";
            this.gridinventory.RowHeadersVisible = false;
            this.gridinventory.Size = new System.Drawing.Size(677, 210);
            this.gridinventory.TabIndex = 6;
            // 
            // col_gridinventory_id
            // 
            this.col_gridinventory_id.HeaderText = "id";
            this.col_gridinventory_id.Name = "col_gridinventory_id";
            this.col_gridinventory_id.ReadOnly = true;
            this.col_gridinventory_id.Visible = false;
            // 
            // col_gridinventory_receivedate
            // 
            this.col_gridinventory_receivedate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "dd/MM/yy";
            this.col_gridinventory_receivedate.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_gridinventory_receivedate.HeaderText = "Date";
            this.col_gridinventory_receivedate.Name = "col_gridinventory_receivedate";
            this.col_gridinventory_receivedate.ReadOnly = true;
            this.col_gridinventory_receivedate.Width = 50;
            // 
            // col_gridinventory_code
            // 
            this.col_gridinventory_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridinventory_code.DefaultCellStyle = dataGridViewCellStyle10;
            this.col_gridinventory_code.HeaderText = "Code";
            this.col_gridinventory_code.Name = "col_gridinventory_code";
            this.col_gridinventory_code.ReadOnly = true;
            this.col_gridinventory_code.Width = 52;
            // 
            // col_gridinventory_gradename
            // 
            this.col_gridinventory_gradename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridinventory_gradename.DefaultCellStyle = dataGridViewCellStyle11;
            this.col_gridinventory_gradename.HeaderText = "Grade";
            this.col_gridinventory_gradename.Name = "col_gridinventory_gradename";
            this.col_gridinventory_gradename.ReadOnly = true;
            this.col_gridinventory_gradename.Width = 55;
            // 
            // col_gridinventory_productname
            // 
            this.col_gridinventory_productname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridinventory_productname.HeaderText = "Product";
            this.col_gridinventory_productname.MinimumWidth = 100;
            this.col_gridinventory_productname.Name = "col_gridinventory_productname";
            this.col_gridinventory_productname.ReadOnly = true;
            // 
            // col_gridinventory_productwidthname
            // 
            this.col_gridinventory_productwidthname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridinventory_productwidthname.DefaultCellStyle = dataGridViewCellStyle12;
            this.col_gridinventory_productwidthname.HeaderText = "Lebar (cm)";
            this.col_gridinventory_productwidthname.Name = "col_gridinventory_productwidthname";
            this.col_gridinventory_productwidthname.ReadOnly = true;
            this.col_gridinventory_productwidthname.Width = 74;
            // 
            // col_gridinventory_colorname
            // 
            this.col_gridinventory_colorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridinventory_colorname.DefaultCellStyle = dataGridViewCellStyle13;
            this.col_gridinventory_colorname.HeaderText = "Color";
            this.col_gridinventory_colorname.Name = "col_gridinventory_colorname";
            this.col_gridinventory_colorname.ReadOnly = true;
            this.col_gridinventory_colorname.Width = 52;
            // 
            // col_gridinventory_buyprice
            // 
            this.col_gridinventory_buyprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            this.col_gridinventory_buyprice.DefaultCellStyle = dataGridViewCellStyle14;
            this.col_gridinventory_buyprice.HeaderText = "Buy Price";
            this.col_gridinventory_buyprice.Name = "col_gridinventory_buyprice";
            this.col_gridinventory_buyprice.ReadOnly = true;
            this.col_gridinventory_buyprice.Width = 69;
            // 
            // col_gridinventory_unitname
            // 
            this.col_gridinventory_unitname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_gridinventory_unitname.DefaultCellStyle = dataGridViewCellStyle15;
            this.col_gridinventory_unitname.HeaderText = "Unit";
            this.col_gridinventory_unitname.Name = "col_gridinventory_unitname";
            this.col_gridinventory_unitname.ReadOnly = true;
            this.col_gridinventory_unitname.Width = 47;
            // 
            // col_gridinventory_packinglistno
            // 
            this.col_gridinventory_packinglistno.HeaderText = "Packing List";
            this.col_gridinventory_packinglistno.Name = "col_gridinventory_packinglistno";
            this.col_gridinventory_packinglistno.ReadOnly = true;
            this.col_gridinventory_packinglistno.Width = 80;
            // 
            // col_gridvendorinvoice_id
            // 
            this.col_gridvendorinvoice_id.DataPropertyName = "id";
            this.col_gridvendorinvoice_id.HeaderText = "id";
            this.col_gridvendorinvoice_id.Name = "col_gridvendorinvoice_id";
            this.col_gridvendorinvoice_id.ReadOnly = true;
            this.col_gridvendorinvoice_id.Visible = false;
            // 
            // col_gridvendorinvoice_timestamp
            // 
            this.col_gridvendorinvoice_timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Format = "dd/MM/yy";
            this.col_gridvendorinvoice_timestamp.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridvendorinvoice_timestamp.HeaderText = "Date";
            this.col_gridvendorinvoice_timestamp.Name = "col_gridvendorinvoice_timestamp";
            this.col_gridvendorinvoice_timestamp.ReadOnly = true;
            this.col_gridvendorinvoice_timestamp.Width = 50;
            // 
            // col_gridvendorinvoice_invoiceno
            // 
            this.col_gridvendorinvoice_invoiceno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_gridvendorinvoice_invoiceno.HeaderText = "Invoice No";
            this.col_gridvendorinvoice_invoiceno.Name = "col_gridvendorinvoice_invoiceno";
            this.col_gridvendorinvoice_invoiceno.ReadOnly = true;
            this.col_gridvendorinvoice_invoiceno.Width = 75;
            // 
            // col_gridvendorinvoice_vendorname
            // 
            this.col_gridvendorinvoice_vendorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_gridvendorinvoice_vendorname.HeaderText = "Vendor";
            this.col_gridvendorinvoice_vendorname.Name = "col_gridvendorinvoice_vendorname";
            this.col_gridvendorinvoice_vendorname.Width = 60;
            // 
            // col_gridvendorinvoice_taxno
            // 
            this.col_gridvendorinvoice_taxno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.col_gridvendorinvoice_taxno.HeaderText = "Tax No";
            this.col_gridvendorinvoice_taxno.Name = "col_gridvendorinvoice_taxno";
            this.col_gridvendorinvoice_taxno.ReadOnly = true;
            this.col_gridvendorinvoice_taxno.Width = 59;
            // 
            // col_gridvendorinvoice_dpp
            // 
            this.col_gridvendorinvoice_dpp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.col_gridvendorinvoice_dpp.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridvendorinvoice_dpp.HeaderText = "DPP";
            this.col_gridvendorinvoice_dpp.Name = "col_gridvendorinvoice_dpp";
            this.col_gridvendorinvoice_dpp.ReadOnly = true;
            this.col_gridvendorinvoice_dpp.Visible = false;
            this.col_gridvendorinvoice_dpp.Width = 49;
            // 
            // col_gridvendorinvoice_totaldppppn
            // 
            this.col_gridvendorinvoice_totaldppppn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.col_gridvendorinvoice_totaldppppn.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridvendorinvoice_totaldppppn.HeaderText = "Total Tax";
            this.col_gridvendorinvoice_totaldppppn.Name = "col_gridvendorinvoice_totaldppppn";
            this.col_gridvendorinvoice_totaldppppn.ReadOnly = true;
            this.col_gridvendorinvoice_totaldppppn.Width = 67;
            // 
            // col_gridvendorinvoice_totalactualvalue
            // 
            this.col_gridvendorinvoice_totalactualvalue.ActiveLinkColor = System.Drawing.Color.Lime;
            this.col_gridvendorinvoice_totalactualvalue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.col_gridvendorinvoice_totalactualvalue.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_gridvendorinvoice_totalactualvalue.HeaderText = "Actual";
            this.col_gridvendorinvoice_totalactualvalue.LinkColor = System.Drawing.Color.Lime;
            this.col_gridvendorinvoice_totalactualvalue.Name = "col_gridvendorinvoice_totalactualvalue";
            this.col_gridvendorinvoice_totalactualvalue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridvendorinvoice_totalactualvalue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridvendorinvoice_totalactualvalue.VisitedLinkColor = System.Drawing.Color.Lime;
            this.col_gridvendorinvoice_totalactualvalue.Width = 57;
            // 
            // col_gridvendorinvoice_top
            // 
            this.col_gridvendorinvoice_top.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridvendorinvoice_top.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_gridvendorinvoice_top.HeaderText = "TOP";
            this.col_gridvendorinvoice_top.Name = "col_gridvendorinvoice_top";
            this.col_gridvendorinvoice_top.ReadOnly = true;
            this.col_gridvendorinvoice_top.Width = 48;
            // 
            // col_gridvendorinvoice_isdue
            // 
            this.col_gridvendorinvoice_isdue.HeaderText = "Due";
            this.col_gridvendorinvoice_isdue.Name = "col_gridvendorinvoice_isdue";
            this.col_gridvendorinvoice_isdue.ReadOnly = true;
            this.col_gridvendorinvoice_isdue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_gridvendorinvoice_isdue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_gridvendorinvoice_isdue.Width = 30;
            // 
            // col_gridvendorinvoice_PayableAmount
            // 
            this.col_gridvendorinvoice_PayableAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.col_gridvendorinvoice_PayableAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_gridvendorinvoice_PayableAmount.HeaderText = "Payable";
            this.col_gridvendorinvoice_PayableAmount.Name = "col_gridvendorinvoice_PayableAmount";
            this.col_gridvendorinvoice_PayableAmount.ReadOnly = true;
            this.col_gridvendorinvoice_PayableAmount.Width = 63;
            // 
            // col_gridvendorinvoice_notes
            // 
            this.col_gridvendorinvoice_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridvendorinvoice_notes.HeaderText = "Notes";
            this.col_gridvendorinvoice_notes.Name = "col_gridvendorinvoice_notes";
            this.col_gridvendorinvoice_notes.ReadOnly = true;
            // 
            // col_gridvendorinvoice_statusenumid
            // 
            this.col_gridvendorinvoice_statusenumid.HeaderText = "Status Enum ID";
            this.col_gridvendorinvoice_statusenumid.Name = "col_gridvendorinvoice_statusenumid";
            this.col_gridvendorinvoice_statusenumid.ReadOnly = true;
            this.col_gridvendorinvoice_statusenumid.Visible = false;
            // 
            // col_gridvendorinvoice_statusname
            // 
            this.col_gridvendorinvoice_statusname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridvendorinvoice_statusname.HeaderText = "Status";
            this.col_gridvendorinvoice_statusname.Name = "col_gridvendorinvoice_statusname";
            this.col_gridvendorinvoice_statusname.ReadOnly = true;
            this.col_gridvendorinvoice_statusname.Width = 57;
            // 
            // VendorInvoices_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 564);
            this.Controls.Add(this.scMain);
            this.Name = "VendorInvoices_Form";
            this.Text = "Vendor Invoices";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scButtonsAndFilters.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scButtonsAndFilters)).EndInit();
            this.scButtonsAndFilters.ResumeLayout(false);
            this.scData.Panel1.ResumeLayout(false);
            this.scData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scData)).EndInit();
            this.scData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridvendorinvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridinventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scButtonsAndFilters;
        private System.Windows.Forms.DataGridView gridvendorinvoice;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.SplitContainer scData;
        private System.Windows.Forms.DataGridView gridinventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_receivedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_gradename;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_productwidthname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_colorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_buyprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_unitname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridinventory_packinglistno;
        private System.Windows.Forms.Button btnSupplierDebits;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_invoiceno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_taxno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_dpp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_totaldppppn;
        private System.Windows.Forms.DataGridViewLinkColumn col_gridvendorinvoice_totalactualvalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_top;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_gridvendorinvoice_isdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_PayableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_statusenumid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridvendorinvoice_statusname;
    }
}