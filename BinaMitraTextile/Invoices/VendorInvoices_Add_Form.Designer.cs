namespace BinaMitraTextile.Invoices
{
    partial class VendorInvoices_Add_Form
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
            this.itxt_VendorInvoices_No = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_Vendors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(112, 132);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 28);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "SAVE";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // itxt_VendorInvoices_No
            // 
            this.itxt_VendorInvoices_No.IsBrowseMode = false;
            this.itxt_VendorInvoices_No.LabelText = "Nomor Faktur";
            this.itxt_VendorInvoices_No.Location = new System.Drawing.Point(66, 26);
            this.itxt_VendorInvoices_No.MaxLength = 32767;
            this.itxt_VendorInvoices_No.MultiLine = false;
            this.itxt_VendorInvoices_No.Name = "itxt_VendorInvoices_No";
            this.itxt_VendorInvoices_No.PasswordChar = '\0';
            this.itxt_VendorInvoices_No.RowCount = 1;
            this.itxt_VendorInvoices_No.ShowDeleteButton = false;
            this.itxt_VendorInvoices_No.ShowFilter = false;
            this.itxt_VendorInvoices_No.ShowTextboxOnly = false;
            this.itxt_VendorInvoices_No.Size = new System.Drawing.Size(180, 41);
            this.itxt_VendorInvoices_No.TabIndex = 0;
            this.itxt_VendorInvoices_No.ValueText = "";
            // 
            // iddl_Vendors
            // 
            this.iddl_Vendors.DisableTextInput = false;
            this.iddl_Vendors.HideFilter = false;
            this.iddl_Vendors.HideUpdateLink = false;
            this.iddl_Vendors.LabelText = "Vendor";
            this.iddl_Vendors.Location = new System.Drawing.Point(66, 73);
            this.iddl_Vendors.Name = "iddl_Vendors";
            this.iddl_Vendors.SelectedIndex = -1;
            this.iddl_Vendors.SelectedItem = null;
            this.iddl_Vendors.SelectedItemText = "";
            this.iddl_Vendors.SelectedValue = null;
            this.iddl_Vendors.ShowDropdownlistOnly = false;
            this.iddl_Vendors.Size = new System.Drawing.Size(180, 41);
            this.iddl_Vendors.TabIndex = 1;
            // 
            // VendorInvoices_Add_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 175);
            this.Controls.Add(this.iddl_Vendors);
            this.Controls.Add(this.itxt_VendorInvoices_No);
            this.Controls.Add(this.btnSubmit);
            this.Name = "VendorInvoices_Add_Form";
            this.Text = "CREATE VENDOR INVOICE";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSubmit;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_VendorInvoices_No;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Vendors;
    }
}