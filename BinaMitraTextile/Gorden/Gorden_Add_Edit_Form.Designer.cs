namespace BinaMitraTextile.Gorden
{
    partial class Gorden_Add_Edit_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gorden_Add_Edit_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtItemWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemHeight = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.dropVitrages = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dropRails1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dropFabrics = new System.Windows.Forms.ComboBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFabricColorCode = new System.Windows.Forms.TextBox();
            this.chkSplitGorden = new System.Windows.Forms.CheckBox();
            this.btnCalculateItemSubtotal = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.rbNoTali = new System.Windows.Forms.RadioButton();
            this.rbTali = new System.Windows.Forms.RadioButton();
            this.rbTasel = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.dropHooks = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dropTasels = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dropRings = new System.Windows.Forms.ComboBox();
            this.dropRails2 = new System.Windows.Forms.ComboBox();
            this.lblItemTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemNotes = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.txtCustomerSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dropCustomers = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOtherCosts = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGlobalDiscountAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gridmain = new System.Windows.Forms.DataGridView();
            this.col_gridmain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_lineno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_priceperunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gridmain_notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.dropKaki = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(71, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 132);
            this.panel1.TabIndex = 9;
            // 
            // txtItemWidth
            // 
            this.txtItemWidth.Location = new System.Drawing.Point(121, 7);
            this.txtItemWidth.MaxLength = 6;
            this.txtItemWidth.Name = "txtItemWidth";
            this.txtItemWidth.Size = new System.Drawing.Size(46, 20);
            this.txtItemWidth.TabIndex = 1;
            this.txtItemWidth.TextChanged += new System.EventHandler(this.itemInputChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "lebar (m)";
            // 
            // txtItemHeight
            // 
            this.txtItemHeight.Location = new System.Drawing.Point(15, 76);
            this.txtItemHeight.MaxLength = 6;
            this.txtItemHeight.Name = "txtItemHeight";
            this.txtItemHeight.Size = new System.Drawing.Size(50, 20);
            this.txtItemHeight.TabIndex = 0;
            this.txtItemHeight.TextChanged += new System.EventHandler(this.itemInputChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 60);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(53, 13);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Tinggi (m)";
            // 
            // dropVitrages
            // 
            this.dropVitrages.FormattingEnabled = true;
            this.dropVitrages.Location = new System.Drawing.Point(229, 83);
            this.dropVitrages.Name = "dropVitrages";
            this.dropVitrages.Size = new System.Drawing.Size(142, 21);
            this.dropVitrages.TabIndex = 5;
            this.dropVitrages.SelectedIndexChanged += new System.EventHandler(this.itemInputChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Vitrage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Rel 1";
            // 
            // dropRails1
            // 
            this.dropRails1.FormattingEnabled = true;
            this.dropRails1.Location = new System.Drawing.Point(417, 6);
            this.dropRails1.Name = "dropRails1";
            this.dropRails1.Size = new System.Drawing.Size(142, 21);
            this.dropRails1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Gorden";
            // 
            // dropFabrics
            // 
            this.dropFabrics.FormattingEnabled = true;
            this.dropFabrics.Location = new System.Drawing.Point(229, 6);
            this.dropFabrics.Name = "dropFabrics";
            this.dropFabrics.Size = new System.Drawing.Size(142, 21);
            this.dropFabrics.TabIndex = 2;
            this.dropFabrics.SelectedIndexChanged += new System.EventHandler(this.itemInputChanged);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(751, 131);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(69, 23);
            this.btnAddItem.TabIndex = 15;
            this.btnAddItem.Text = "ADD";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtItemQty
            // 
            this.txtItemQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemQty.Location = new System.Drawing.Point(716, 133);
            this.txtItemQty.MaxLength = 2;
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(29, 20);
            this.txtItemQty.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(687, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "Qty";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dropKaki);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtFabricColorCode);
            this.panel2.Controls.Add(this.chkSplitGorden);
            this.panel2.Controls.Add(this.btnCalculateItemSubtotal);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.rbNoTali);
            this.panel2.Controls.Add(this.rbTali);
            this.panel2.Controls.Add(this.rbTasel);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.dropHooks);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.dropTasels);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.dropRings);
            this.panel2.Controls.Add(this.dropRails2);
            this.panel2.Controls.Add(this.lblItemTotal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtItemNotes);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lbl);
            this.panel2.Controls.Add(this.txtItemQty);
            this.panel2.Controls.Add(this.txtItemHeight);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAddItem);
            this.panel2.Controls.Add(this.txtItemWidth);
            this.panel2.Controls.Add(this.dropVitrages);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dropRails1);
            this.panel2.Controls.Add(this.dropFabrics);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 173);
            this.panel2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 164;
            this.label11.Text = "warna:";
            // 
            // txtFabricColorCode
            // 
            this.txtFabricColorCode.Location = new System.Drawing.Point(332, 31);
            this.txtFabricColorCode.MaxLength = 6;
            this.txtFabricColorCode.Name = "txtFabricColorCode";
            this.txtFabricColorCode.Size = new System.Drawing.Size(39, 20);
            this.txtFabricColorCode.TabIndex = 163;
            // 
            // chkSplitGorden
            // 
            this.chkSplitGorden.AutoSize = true;
            this.chkSplitGorden.Checked = true;
            this.chkSplitGorden.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSplitGorden.Location = new System.Drawing.Point(229, 33);
            this.chkSplitGorden.Name = "chkSplitGorden";
            this.chkSplitGorden.Size = new System.Drawing.Size(55, 17);
            this.chkSplitGorden.TabIndex = 162;
            this.chkSplitGorden.Text = "bagi 2";
            this.chkSplitGorden.UseVisualStyleBackColor = true;
            // 
            // btnCalculateItemSubtotal
            // 
            this.btnCalculateItemSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculateItemSubtotal.Location = new System.Drawing.Point(751, 102);
            this.btnCalculateItemSubtotal.Name = "btnCalculateItemSubtotal";
            this.btnCalculateItemSubtotal.Size = new System.Drawing.Size(69, 23);
            this.btnCalculateItemSubtotal.TabIndex = 14;
            this.btnCalculateItemSubtotal.Text = "HITUNG";
            this.btnCalculateItemSubtotal.UseVisualStyleBackColor = true;
            this.btnCalculateItemSubtotal.Click += new System.EventHandler(this.btnCalculateItemSubtotal_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(3, 145);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(26, 23);
            this.btnRemove.TabIndex = 156;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // rbNoTali
            // 
            this.rbNoTali.AutoSize = true;
            this.rbNoTali.Checked = true;
            this.rbNoTali.Location = new System.Drawing.Point(229, 107);
            this.rbNoTali.Name = "rbNoTali";
            this.rbNoTali.Size = new System.Drawing.Size(51, 17);
            this.rbNoTali.TabIndex = 8;
            this.rbNoTali.TabStop = true;
            this.rbNoTali.Text = "None";
            this.rbNoTali.UseVisualStyleBackColor = true;
            // 
            // rbTali
            // 
            this.rbTali.AutoSize = true;
            this.rbTali.Location = new System.Drawing.Point(229, 127);
            this.rbTali.Name = "rbTali";
            this.rbTali.Size = new System.Drawing.Size(42, 17);
            this.rbTali.TabIndex = 9;
            this.rbTali.Text = "Tali";
            this.rbTali.UseVisualStyleBackColor = true;
            // 
            // rbTasel
            // 
            this.rbTasel.AutoSize = true;
            this.rbTasel.Location = new System.Drawing.Point(229, 150);
            this.rbTasel.Name = "rbTasel";
            this.rbTasel.Size = new System.Drawing.Size(14, 13);
            this.rbTasel.TabIndex = 5;
            this.rbTasel.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(378, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 154;
            this.label17.Text = "Hook";
            // 
            // dropHooks
            // 
            this.dropHooks.FormattingEnabled = true;
            this.dropHooks.Location = new System.Drawing.Point(417, 147);
            this.dropHooks.Name = "dropHooks";
            this.dropHooks.Size = new System.Drawing.Size(142, 21);
            this.dropHooks.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(190, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 152;
            this.label16.Text = "Tasel";
            // 
            // dropTasels
            // 
            this.dropTasels.FormattingEnabled = true;
            this.dropTasels.Location = new System.Drawing.Point(246, 147);
            this.dropTasels.Name = "dropTasels";
            this.dropTasels.Size = new System.Drawing.Size(125, 21);
            this.dropTasels.TabIndex = 10;
            this.dropTasels.SelectedIndexChanged += new System.EventHandler(this.dropTasels_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(379, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 146;
            this.label14.Text = "Rel 2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(194, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 143;
            this.label13.Text = "Ring";
            // 
            // dropRings
            // 
            this.dropRings.FormattingEnabled = true;
            this.dropRings.Location = new System.Drawing.Point(229, 56);
            this.dropRings.Name = "dropRings";
            this.dropRings.Size = new System.Drawing.Size(142, 21);
            this.dropRings.TabIndex = 3;
            // 
            // dropRails2
            // 
            this.dropRails2.FormattingEnabled = true;
            this.dropRails2.Location = new System.Drawing.Point(417, 33);
            this.dropRails2.Name = "dropRails2";
            this.dropRails2.Size = new System.Drawing.Size(142, 21);
            this.dropRails2.TabIndex = 7;
            // 
            // lblItemTotal
            // 
            this.lblItemTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTotal.Location = new System.Drawing.Point(568, 96);
            this.lblItemTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemTotal.Name = "lblItemTotal";
            this.lblItemTotal.Size = new System.Drawing.Size(177, 32);
            this.lblItemTotal.TabIndex = 132;
            this.lblItemTotal.Text = "lblSubtotal";
            this.lblItemTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Notes";
            // 
            // txtItemNotes
            // 
            this.txtItemNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemNotes.Location = new System.Drawing.Point(568, 23);
            this.txtItemNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemNotes.MaxLength = 500;
            this.txtItemNotes.Multiline = true;
            this.txtItemNotes.Name = "txtItemNotes";
            this.txtItemNotes.Size = new System.Drawing.Size(252, 70);
            this.txtItemNotes.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCustomerInfo);
            this.panel3.Controls.Add(this.btnAddCustomer);
            this.panel3.Controls.Add(this.txtCustomerSearch);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.dropCustomers);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtOtherCosts);
            this.panel3.Controls.Add(this.txtNotes);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtGlobalDiscountAmount);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblTotalAmount);
            this.panel3.Controls.Add(this.btnSubmit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 488);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(832, 135);
            this.panel3.TabIndex = 127;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(195, 31);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(242, 94);
            this.lblCustomerInfo.TabIndex = 136;
            this.lblCustomerInfo.Text = "lblCustomerInfo";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCustomer.BackgroundImage")));
            this.btnAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Location = new System.Drawing.Point(248, 7);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(15, 16);
            this.btnAddCustomer.TabIndex = 135;
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomerSearch
            // 
            this.txtCustomerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCustomerSearch.Location = new System.Drawing.Point(395, 5);
            this.txtCustomerSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerSearch.Name = "txtCustomerSearch";
            this.txtCustomerSearch.Size = new System.Drawing.Size(42, 20);
            this.txtCustomerSearch.TabIndex = 132;
            this.txtCustomerSearch.TextChanged += new System.EventHandler(this.txtCustomerSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "Customer";
            // 
            // dropCustomers
            // 
            this.dropCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dropCustomers.FormattingEnabled = true;
            this.dropCustomers.Location = new System.Drawing.Point(267, 5);
            this.dropCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.dropCustomers.Name = "dropCustomers";
            this.dropCustomers.Size = new System.Drawing.Size(124, 21);
            this.dropCustomers.TabIndex = 3;
            this.dropCustomers.SelectedIndexChanged += new System.EventHandler(this.dropCustomers_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 129;
            this.label9.Text = "Notes";
            // 
            // txtOtherCosts
            // 
            this.txtOtherCosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOtherCosts.Location = new System.Drawing.Point(88, 5);
            this.txtOtherCosts.MaxLength = 13;
            this.txtOtherCosts.Name = "txtOtherCosts";
            this.txtOtherCosts.Size = new System.Drawing.Size(99, 20);
            this.txtOtherCosts.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNotes.Location = new System.Drawing.Point(10, 71);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(177, 54);
            this.txtNotes.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 131;
            this.label8.Text = "Biaya Lain-lain";
            // 
            // txtGlobalDiscountAmount
            // 
            this.txtGlobalDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGlobalDiscountAmount.Location = new System.Drawing.Point(88, 31);
            this.txtGlobalDiscountAmount.MaxLength = 13;
            this.txtGlobalDiscountAmount.Name = "txtGlobalDiscountAmount";
            this.txtGlobalDiscountAmount.Size = new System.Drawing.Size(99, 20);
            this.txtGlobalDiscountAmount.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 126;
            this.label7.Text = "Discount (Rp)";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(467, 58);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(353, 32);
            this.lblTotalAmount.TabIndex = 129;
            this.lblTotalAmount.Text = "lblTotalAmount";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(732, 94);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 31);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // gridmain
            // 
            this.gridmain.AllowUserToAddRows = false;
            this.gridmain.AllowUserToDeleteRows = false;
            this.gridmain.AllowUserToResizeRows = false;
            this.gridmain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridmain.BackgroundColor = System.Drawing.Color.White;
            this.gridmain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridmain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridmain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_gridmain_id,
            this.col_gridmain_lineno,
            this.col_gridmain_description,
            this.col_gridmain_qty,
            this.col_gridmain_priceperunit,
            this.col_gridmain_subtotal,
            this.col_gridmain_notes});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridmain.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridmain.Location = new System.Drawing.Point(0, 173);
            this.gridmain.Margin = new System.Windows.Forms.Padding(2);
            this.gridmain.MultiSelect = false;
            this.gridmain.Name = "gridmain";
            this.gridmain.ReadOnly = true;
            this.gridmain.RowHeadersVisible = false;
            this.gridmain.RowTemplate.Height = 24;
            this.gridmain.Size = new System.Drawing.Size(832, 315);
            this.gridmain.TabIndex = 128;
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
            this.col_gridmain_lineno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_gridmain_lineno.HeaderText = "No";
            this.col_gridmain_lineno.Name = "col_gridmain_lineno";
            this.col_gridmain_lineno.ReadOnly = true;
            this.col_gridmain_lineno.Width = 42;
            // 
            // col_gridmain_description
            // 
            this.col_gridmain_description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.col_gridmain_description.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_gridmain_description.HeaderText = "Description";
            this.col_gridmain_description.Name = "col_gridmain_description";
            this.col_gridmain_description.ReadOnly = true;
            this.col_gridmain_description.Width = 77;
            // 
            // col_gridmain_qty
            // 
            this.col_gridmain_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.col_gridmain_qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_gridmain_qty.HeaderText = "Qty";
            this.col_gridmain_qty.Name = "col_gridmain_qty";
            this.col_gridmain_qty.ReadOnly = true;
            this.col_gridmain_qty.Width = 45;
            // 
            // col_gridmain_priceperunit
            // 
            this.col_gridmain_priceperunit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.col_gridmain_priceperunit.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_gridmain_priceperunit.HeaderText = "Price/Unit";
            this.col_gridmain_priceperunit.Name = "col_gridmain_priceperunit";
            this.col_gridmain_priceperunit.ReadOnly = true;
            this.col_gridmain_priceperunit.Width = 71;
            // 
            // col_gridmain_subtotal
            // 
            this.col_gridmain_subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_gridmain_subtotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_gridmain_subtotal.HeaderText = "Subtotal";
            this.col_gridmain_subtotal.Name = "col_gridmain_subtotal";
            this.col_gridmain_subtotal.ReadOnly = true;
            this.col_gridmain_subtotal.Width = 64;
            // 
            // col_gridmain_notes
            // 
            this.col_gridmain_notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gridmain_notes.HeaderText = "Notes";
            this.col_gridmain_notes.Name = "col_gridmain_notes";
            this.col_gridmain_notes.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(379, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 166;
            this.label12.Text = "Kaki";
            // 
            // dropKaki
            // 
            this.dropKaki.FormattingEnabled = true;
            this.dropKaki.Location = new System.Drawing.Point(417, 60);
            this.dropKaki.Name = "dropKaki";
            this.dropKaki.Size = new System.Drawing.Size(142, 21);
            this.dropKaki.TabIndex = 165;
            // 
            // Gorden_Add_Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 623);
            this.Controls.Add(this.gridmain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Gorden_Add_Edit_Form";
            this.Text = "Gorden Order";
            this.Load += new System.EventHandler(this.Gorden_Add_Edit_Form_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtItemWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemHeight;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox dropVitrages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dropRails1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dropFabrics;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtItemQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView gridmain;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtOtherCosts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGlobalDiscountAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtItemNotes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblItemTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox dropTasels;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox dropRings;
        private System.Windows.Forms.ComboBox dropRails2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox dropHooks;
        private System.Windows.Forms.RadioButton rbTali;
        private System.Windows.Forms.RadioButton rbTasel;
        private System.Windows.Forms.RadioButton rbNoTali;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.TextBox txtCustomerSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dropCustomers;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCalculateItemSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_lineno;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_priceperunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gridmain_notes;
        private System.Windows.Forms.CheckBox chkSplitGorden;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFabricColorCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox dropKaki;
    }
}