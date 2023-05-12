namespace BinaMitraTextile.InventoryForm
{
    partial class VendorInvoices_Edit_Form
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.itxt_InvoiceNo = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_TOP = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.idtp_Timestamp = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.in_FakturPajak_PPN = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_FakturPajak_DPP = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.itxt_FakturPajak_No = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.lblDiffTotalPajakToAmount = new System.Windows.Forms.Label();
            this.itxt_FakturPajak_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.idtp_FakturPajak_Timestamp = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.btnRemoveFakturPajakFromVendorInvoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(128, 372);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(117, 34);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "SAVE";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.itxt_InvoiceNo);
            this.groupBox1.Controls.Add(this.in_Amount);
            this.groupBox1.Controls.Add(this.in_TOP);
            this.groupBox1.Controls.Add(this.idtp_Timestamp);
            this.groupBox1.Controls.Add(this.itxt_Notes);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(233, 346);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INVOICE";
            // 
            // itxt_InvoiceNo
            // 
            this.itxt_InvoiceNo.IsBrowseMode = false;
            this.itxt_InvoiceNo.LabelText = "Invoice No";
            this.itxt_InvoiceNo.Location = new System.Drawing.Point(9, 70);
            this.itxt_InvoiceNo.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_InvoiceNo.MaxLength = 32767;
            this.itxt_InvoiceNo.MultiLine = false;
            this.itxt_InvoiceNo.Name = "itxt_InvoiceNo";
            this.itxt_InvoiceNo.PasswordChar = '\0';
            this.itxt_InvoiceNo.RowCount = 1;
            this.itxt_InvoiceNo.ShowDeleteButton = false;
            this.itxt_InvoiceNo.ShowFilter = false;
            this.itxt_InvoiceNo.ShowTextboxOnly = false;
            this.itxt_InvoiceNo.Size = new System.Drawing.Size(215, 50);
            this.itxt_InvoiceNo.TabIndex = 1;
            this.itxt_InvoiceNo.ValueText = "";
            // 
            // in_Amount
            // 
            this.in_Amount.Checked = false;
            this.in_Amount.DecimalPlaces = 2;
            this.in_Amount.HideUpDown = false;
            this.in_Amount.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_Amount.LabelText = "Total Amount";
            this.in_Amount.Location = new System.Drawing.Point(9, 178);
            this.in_Amount.Margin = new System.Windows.Forms.Padding(4);
            this.in_Amount.MaximumValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.in_Amount.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Amount.Name = "in_Amount";
            this.in_Amount.ShowAllowDecimalCheckbox = false;
            this.in_Amount.ShowCheckbox = false;
            this.in_Amount.ShowTextboxOnly = false;
            this.in_Amount.Size = new System.Drawing.Size(215, 49);
            this.in_Amount.TabIndex = 3;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // in_TOP
            // 
            this.in_TOP.Checked = false;
            this.in_TOP.DecimalPlaces = 0;
            this.in_TOP.HideUpDown = false;
            this.in_TOP.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.in_TOP.LabelText = "TOP";
            this.in_TOP.Location = new System.Drawing.Point(9, 121);
            this.in_TOP.Margin = new System.Windows.Forms.Padding(5);
            this.in_TOP.MaximumValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.in_TOP.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_TOP.Name = "in_TOP";
            this.in_TOP.ShowAllowDecimalCheckbox = false;
            this.in_TOP.ShowCheckbox = false;
            this.in_TOP.ShowTextboxOnly = false;
            this.in_TOP.Size = new System.Drawing.Size(215, 49);
            this.in_TOP.TabIndex = 2;
            this.in_TOP.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // idtp_Timestamp
            // 
            this.idtp_Timestamp.Checked = true;
            this.idtp_Timestamp.CustomFormat = "dd/MM/yyyy";
            this.idtp_Timestamp.DefaultCheckedValue = false;
            this.idtp_Timestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_Timestamp.LabelText = "Date";
            this.idtp_Timestamp.Location = new System.Drawing.Point(9, 20);
            this.idtp_Timestamp.Margin = new System.Windows.Forms.Padding(5);
            this.idtp_Timestamp.Name = "idtp_Timestamp";
            this.idtp_Timestamp.ShowCheckBox = false;
            this.idtp_Timestamp.ShowDateTimePickerOnly = false;
            this.idtp_Timestamp.ShowUpAndDown = false;
            this.idtp_Timestamp.Size = new System.Drawing.Size(215, 50);
            this.idtp_Timestamp.TabIndex = 0;
            this.idtp_Timestamp.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_Timestamp.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            this.idtp_Timestamp.ValueChanged += new System.EventHandler(this.Idtp_Timestamp_ValueChanged);
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(9, 227);
            this.itxt_Notes.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(215, 106);
            this.itxt_Notes.TabIndex = 4;
            this.itxt_Notes.ValueText = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.in_FakturPajak_PPN);
            this.groupBox2.Controls.Add(this.in_FakturPajak_DPP);
            this.groupBox2.Controls.Add(this.itxt_FakturPajak_No);
            this.groupBox2.Controls.Add(this.lblDiffTotalPajakToAmount);
            this.groupBox2.Controls.Add(this.itxt_FakturPajak_Notes);
            this.groupBox2.Controls.Add(this.idtp_FakturPajak_Timestamp);
            this.groupBox2.Location = new System.Drawing.Point(273, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(233, 346);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FAKTUR PAJAK";
            // 
            // in_FakturPajak_PPN
            // 
            this.in_FakturPajak_PPN.Checked = false;
            this.in_FakturPajak_PPN.DecimalPlaces = 2;
            this.in_FakturPajak_PPN.HideUpDown = false;
            this.in_FakturPajak_PPN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_FakturPajak_PPN.LabelText = "PPN";
            this.in_FakturPajak_PPN.Location = new System.Drawing.Point(9, 178);
            this.in_FakturPajak_PPN.Margin = new System.Windows.Forms.Padding(5);
            this.in_FakturPajak_PPN.MaximumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            0});
            this.in_FakturPajak_PPN.MinimumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            -2147483648});
            this.in_FakturPajak_PPN.Name = "in_FakturPajak_PPN";
            this.in_FakturPajak_PPN.ShowAllowDecimalCheckbox = false;
            this.in_FakturPajak_PPN.ShowCheckbox = false;
            this.in_FakturPajak_PPN.ShowTextboxOnly = false;
            this.in_FakturPajak_PPN.Size = new System.Drawing.Size(215, 49);
            this.in_FakturPajak_PPN.TabIndex = 3;
            this.in_FakturPajak_PPN.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_FakturPajak_PPN.ValueChanged += new System.EventHandler(this.updateDiffTotalFakturPajakToAmount);
            // 
            // in_FakturPajak_DPP
            // 
            this.in_FakturPajak_DPP.Checked = false;
            this.in_FakturPajak_DPP.DecimalPlaces = 2;
            this.in_FakturPajak_DPP.HideUpDown = false;
            this.in_FakturPajak_DPP.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.in_FakturPajak_DPP.LabelText = "DPP";
            this.in_FakturPajak_DPP.Location = new System.Drawing.Point(9, 121);
            this.in_FakturPajak_DPP.Margin = new System.Windows.Forms.Padding(5);
            this.in_FakturPajak_DPP.MaximumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            0});
            this.in_FakturPajak_DPP.MinimumValue = new decimal(new int[] {
            -194313216,
            20,
            0,
            -2147483648});
            this.in_FakturPajak_DPP.Name = "in_FakturPajak_DPP";
            this.in_FakturPajak_DPP.ShowAllowDecimalCheckbox = false;
            this.in_FakturPajak_DPP.ShowCheckbox = false;
            this.in_FakturPajak_DPP.ShowTextboxOnly = false;
            this.in_FakturPajak_DPP.Size = new System.Drawing.Size(215, 49);
            this.in_FakturPajak_DPP.TabIndex = 2;
            this.in_FakturPajak_DPP.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_FakturPajak_DPP.ValueChanged += new System.EventHandler(this.In_FakturPajak_DPP_ValueChanged);
            // 
            // itxt_FakturPajak_No
            // 
            this.itxt_FakturPajak_No.IsBrowseMode = false;
            this.itxt_FakturPajak_No.LabelText = "Nomor FP";
            this.itxt_FakturPajak_No.Location = new System.Drawing.Point(9, 70);
            this.itxt_FakturPajak_No.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_FakturPajak_No.MaxLength = 32767;
            this.itxt_FakturPajak_No.MultiLine = false;
            this.itxt_FakturPajak_No.Name = "itxt_FakturPajak_No";
            this.itxt_FakturPajak_No.PasswordChar = '\0';
            this.itxt_FakturPajak_No.RowCount = 1;
            this.itxt_FakturPajak_No.ShowDeleteButton = true;
            this.itxt_FakturPajak_No.ShowFilter = false;
            this.itxt_FakturPajak_No.ShowTextboxOnly = false;
            this.itxt_FakturPajak_No.Size = new System.Drawing.Size(215, 50);
            this.itxt_FakturPajak_No.TabIndex = 1;
            this.itxt_FakturPajak_No.ValueText = "";
            // 
            // lblDiffTotalPajakToAmount
            // 
            this.lblDiffTotalPajakToAmount.Location = new System.Drawing.Point(56, 230);
            this.lblDiffTotalPajakToAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiffTotalPajakToAmount.Name = "lblDiffTotalPajakToAmount";
            this.lblDiffTotalPajakToAmount.Size = new System.Drawing.Size(168, 20);
            this.lblDiffTotalPajakToAmount.TabIndex = 4;
            this.lblDiffTotalPajakToAmount.Text = "lblDiffTotalPajakToAmount";
            this.lblDiffTotalPajakToAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // itxt_FakturPajak_Notes
            // 
            this.itxt_FakturPajak_Notes.IsBrowseMode = false;
            this.itxt_FakturPajak_Notes.LabelText = "Notes";
            this.itxt_FakturPajak_Notes.Location = new System.Drawing.Point(9, 227);
            this.itxt_FakturPajak_Notes.Margin = new System.Windows.Forms.Padding(5);
            this.itxt_FakturPajak_Notes.MaxLength = 32767;
            this.itxt_FakturPajak_Notes.MultiLine = true;
            this.itxt_FakturPajak_Notes.Name = "itxt_FakturPajak_Notes";
            this.itxt_FakturPajak_Notes.PasswordChar = '\0';
            this.itxt_FakturPajak_Notes.RowCount = 4;
            this.itxt_FakturPajak_Notes.ShowDeleteButton = false;
            this.itxt_FakturPajak_Notes.ShowFilter = false;
            this.itxt_FakturPajak_Notes.ShowTextboxOnly = false;
            this.itxt_FakturPajak_Notes.Size = new System.Drawing.Size(215, 106);
            this.itxt_FakturPajak_Notes.TabIndex = 4;
            this.itxt_FakturPajak_Notes.ValueText = "";
            // 
            // idtp_FakturPajak_Timestamp
            // 
            this.idtp_FakturPajak_Timestamp.Checked = true;
            this.idtp_FakturPajak_Timestamp.CustomFormat = "dd/MM/yyyy";
            this.idtp_FakturPajak_Timestamp.DefaultCheckedValue = false;
            this.idtp_FakturPajak_Timestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_FakturPajak_Timestamp.LabelText = "Date";
            this.idtp_FakturPajak_Timestamp.Location = new System.Drawing.Point(9, 20);
            this.idtp_FakturPajak_Timestamp.Margin = new System.Windows.Forms.Padding(5);
            this.idtp_FakturPajak_Timestamp.Name = "idtp_FakturPajak_Timestamp";
            this.idtp_FakturPajak_Timestamp.ShowCheckBox = false;
            this.idtp_FakturPajak_Timestamp.ShowDateTimePickerOnly = false;
            this.idtp_FakturPajak_Timestamp.ShowUpAndDown = false;
            this.idtp_FakturPajak_Timestamp.Size = new System.Drawing.Size(215, 50);
            this.idtp_FakturPajak_Timestamp.TabIndex = 0;
            this.idtp_FakturPajak_Timestamp.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_FakturPajak_Timestamp.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // btnRemoveFakturPajakFromVendorInvoice
            // 
            this.btnRemoveFakturPajakFromVendorInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFakturPajakFromVendorInvoice.Location = new System.Drawing.Point(251, 372);
            this.btnRemoveFakturPajakFromVendorInvoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveFakturPajakFromVendorInvoice.Name = "btnRemoveFakturPajakFromVendorInvoice";
            this.btnRemoveFakturPajakFromVendorInvoice.Size = new System.Drawing.Size(151, 34);
            this.btnRemoveFakturPajakFromVendorInvoice.TabIndex = 3;
            this.btnRemoveFakturPajakFromVendorInvoice.Text = "REMOVE FP";
            this.btnRemoveFakturPajakFromVendorInvoice.UseVisualStyleBackColor = true;
            this.btnRemoveFakturPajakFromVendorInvoice.Click += new System.EventHandler(this.BtnRemoveFakturPajakFromVendorInvoice_Click);
            // 
            // VendorInvoices_Edit_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(529, 414);
            this.Controls.Add(this.btnRemoveFakturPajakFromVendorInvoice);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VendorInvoices_Edit_Form";
            this.Text = "INVOICE";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_Timestamp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_FakturPajak_Timestamp;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_FakturPajak_Notes;
        private System.Windows.Forms.Button btnRemoveFakturPajakFromVendorInvoice;
        private System.Windows.Forms.Label lblDiffTotalPajakToAmount;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_InvoiceNo;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_TOP;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_FakturPajak_PPN;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_FakturPajak_DPP;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_FakturPajak_No;
    }
}