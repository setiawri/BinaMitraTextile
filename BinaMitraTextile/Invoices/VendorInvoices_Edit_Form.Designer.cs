namespace BinaMitraTextile.Invoices
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
            this.in_TOP = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_Amount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.itxt_InvoiceNo = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.idtp_Timestamp = new LIBUtil.Desktop.UserControls.InputControl_DateTimePicker();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(68, 297);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 28);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "SAVE";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            this.in_TOP.Location = new System.Drawing.Point(32, 106);
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
            this.in_TOP.Size = new System.Drawing.Size(161, 40);
            this.in_TOP.TabIndex = 2;
            this.in_TOP.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
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
            this.in_Amount.Location = new System.Drawing.Point(32, 152);
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
            this.in_Amount.Size = new System.Drawing.Size(161, 40);
            this.in_Amount.TabIndex = 3;
            this.in_Amount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // itxt_InvoiceNo
            // 
            this.itxt_InvoiceNo.IsBrowseMode = false;
            this.itxt_InvoiceNo.LabelText = "Invoice No";
            this.itxt_InvoiceNo.Location = new System.Drawing.Point(32, 59);
            this.itxt_InvoiceNo.MaxLength = 32767;
            this.itxt_InvoiceNo.MultiLine = false;
            this.itxt_InvoiceNo.Name = "itxt_InvoiceNo";
            this.itxt_InvoiceNo.PasswordChar = '\0';
            this.itxt_InvoiceNo.RowCount = 1;
            this.itxt_InvoiceNo.ShowDeleteButton = false;
            this.itxt_InvoiceNo.ShowFilter = false;
            this.itxt_InvoiceNo.ShowTextboxOnly = false;
            this.itxt_InvoiceNo.Size = new System.Drawing.Size(161, 41);
            this.itxt_InvoiceNo.TabIndex = 1;
            this.itxt_InvoiceNo.ValueText = "";
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(32, 198);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(161, 86);
            this.itxt_Notes.TabIndex = 4;
            this.itxt_Notes.ValueText = "";
            // 
            // idtp_Timestamp
            // 
            this.idtp_Timestamp.Checked = true;
            this.idtp_Timestamp.CustomFormat = "dd/MM/yyyy";
            this.idtp_Timestamp.DefaultCheckedValue = false;
            this.idtp_Timestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.idtp_Timestamp.LabelText = "Date";
            this.idtp_Timestamp.Location = new System.Drawing.Point(32, 12);
            this.idtp_Timestamp.Name = "idtp_Timestamp";
            this.idtp_Timestamp.ShowCheckBox = false;
            this.idtp_Timestamp.ShowDateTimePickerOnly = false;
            this.idtp_Timestamp.ShowUpAndDown = false;
            this.idtp_Timestamp.Size = new System.Drawing.Size(161, 41);
            this.idtp_Timestamp.TabIndex = 0;
            this.idtp_Timestamp.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.idtp_Timestamp.ValueTimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // VendorInvoices_Edit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 336);
            this.Controls.Add(this.idtp_Timestamp);
            this.Controls.Add(this.itxt_Notes);
            this.Controls.Add(this.itxt_InvoiceNo);
            this.Controls.Add(this.in_Amount);
            this.Controls.Add(this.in_TOP);
            this.Controls.Add(this.btnSubmit);
            this.Name = "VendorInvoices_Edit_Form";
            this.Text = "INVOICE";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_TOP;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Amount;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_InvoiceNo;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_DateTimePicker idtp_Timestamp;
    }
}