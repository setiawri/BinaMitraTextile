namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_Products_Form
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
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_ProductStoreNames = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_PercentageOfPercentCommission = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.iddl_Vendors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_MaxCommissionAmount = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.itxt_NameVendor = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.panel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.Panel1.SuspendLayout();
            this.scInputLeft.Panel2.SuspendLayout();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).BeginInit();
            this.scInputContainer.Panel1.SuspendLayout();
            this.scInputContainer.Panel2.SuspendLayout();
            this.scInputContainer.SuspendLayout();
            this.pnlQuickSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(800, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 157);
            this.pnlActionButtons.Size = new System.Drawing.Size(800, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.iddl_ProductStoreNames);
            this.scInputLeft.Panel1.Controls.Add(this.itxt_NameVendor);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Vendors);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.in_MaxCommissionAmount);
            this.scInputLeft.Panel2.Controls.Add(this.in_PercentageOfPercentCommission);
            this.scInputLeft.Panel2.Controls.Add(this.itxt_Notes);
            this.scInputLeft.Size = new System.Drawing.Size(500, 131);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(296, 131);
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(800, 484);
            this.scMain.SplitterDistance = 180;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(800, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(800, 131);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Size = new System.Drawing.Size(770, 28);
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(2, 42);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(242, 86);
            this.itxt_Notes.TabIndex = 0;
            this.itxt_Notes.ValueText = "";
            // 
            // iddl_ProductStoreNames
            // 
            this.iddl_ProductStoreNames.DisableTextInput = false;
            this.iddl_ProductStoreNames.HideFilter = false;
            this.iddl_ProductStoreNames.HideUpdateLink = false;
            this.iddl_ProductStoreNames.LabelText = "Name (Store)";
            this.iddl_ProductStoreNames.Location = new System.Drawing.Point(3, 3);
            this.iddl_ProductStoreNames.Name = "iddl_ProductStoreNames";
            this.iddl_ProductStoreNames.SelectedIndex = -1;
            this.iddl_ProductStoreNames.SelectedItem = null;
            this.iddl_ProductStoreNames.SelectedItemText = "";
            this.iddl_ProductStoreNames.SelectedValue = null;
            this.iddl_ProductStoreNames.ShowDropdownlistOnly = false;
            this.iddl_ProductStoreNames.Size = new System.Drawing.Size(243, 41);
            this.iddl_ProductStoreNames.TabIndex = 0;
            this.iddl_ProductStoreNames.UpdateLink_Click += new System.EventHandler(this.iddl_StoreName_UpdateLink_Click);
            // 
            // in_PercentageOfPercentCommission
            // 
            this.in_PercentageOfPercentCommission.Checked = false;
            this.in_PercentageOfPercentCommission.DecimalPlaces = 2;
            this.in_PercentageOfPercentCommission.HideUpDown = false;
            this.in_PercentageOfPercentCommission.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.in_PercentageOfPercentCommission.LabelText = "% of % Commission";
            this.in_PercentageOfPercentCommission.Location = new System.Drawing.Point(4, 3);
            this.in_PercentageOfPercentCommission.MaximumValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_PercentageOfPercentCommission.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_PercentageOfPercentCommission.Name = "in_PercentageOfPercentCommission";
            this.in_PercentageOfPercentCommission.ShowAllowDecimalCheckbox = false;
            this.in_PercentageOfPercentCommission.ShowCheckbox = false;
            this.in_PercentageOfPercentCommission.ShowTextboxOnly = false;
            this.in_PercentageOfPercentCommission.Size = new System.Drawing.Size(118, 41);
            this.in_PercentageOfPercentCommission.TabIndex = 3;
            this.in_PercentageOfPercentCommission.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // iddl_Vendors
            // 
            this.iddl_Vendors.DisableTextInput = false;
            this.iddl_Vendors.HideFilter = false;
            this.iddl_Vendors.HideUpdateLink = false;
            this.iddl_Vendors.LabelText = "Vendor";
            this.iddl_Vendors.Location = new System.Drawing.Point(3, 87);
            this.iddl_Vendors.Name = "iddl_Vendors";
            this.iddl_Vendors.SelectedIndex = -1;
            this.iddl_Vendors.SelectedItem = null;
            this.iddl_Vendors.SelectedItemText = "";
            this.iddl_Vendors.SelectedValue = null;
            this.iddl_Vendors.ShowDropdownlistOnly = false;
            this.iddl_Vendors.Size = new System.Drawing.Size(243, 41);
            this.iddl_Vendors.TabIndex = 4;
            // 
            // in_MaxCommissionAmount
            // 
            this.in_MaxCommissionAmount.Checked = false;
            this.in_MaxCommissionAmount.DecimalPlaces = 0;
            this.in_MaxCommissionAmount.HideUpDown = false;
            this.in_MaxCommissionAmount.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.in_MaxCommissionAmount.LabelText = "Max Commission";
            this.in_MaxCommissionAmount.Location = new System.Drawing.Point(126, 3);
            this.in_MaxCommissionAmount.MaximumValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.in_MaxCommissionAmount.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.in_MaxCommissionAmount.Name = "in_MaxCommissionAmount";
            this.in_MaxCommissionAmount.ShowAllowDecimalCheckbox = false;
            this.in_MaxCommissionAmount.ShowCheckbox = true;
            this.in_MaxCommissionAmount.ShowTextboxOnly = false;
            this.in_MaxCommissionAmount.Size = new System.Drawing.Size(118, 41);
            this.in_MaxCommissionAmount.TabIndex = 4;
            this.in_MaxCommissionAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // itxt_NameVendor
            // 
            this.itxt_NameVendor.IsBrowseMode = false;
            this.itxt_NameVendor.LabelText = "Name (Vendor)";
            this.itxt_NameVendor.Location = new System.Drawing.Point(3, 43);
            this.itxt_NameVendor.MaxLength = 32767;
            this.itxt_NameVendor.MultiLine = false;
            this.itxt_NameVendor.Name = "itxt_NameVendor";
            this.itxt_NameVendor.PasswordChar = '\0';
            this.itxt_NameVendor.RowCount = 1;
            this.itxt_NameVendor.ShowDeleteButton = false;
            this.itxt_NameVendor.ShowFilter = false;
            this.itxt_NameVendor.ShowTextboxOnly = false;
            this.itxt_NameVendor.Size = new System.Drawing.Size(243, 41);
            this.itxt_NameVendor.TabIndex = 4;
            this.itxt_NameVendor.ValueText = "";
            // 
            // MasterData_v1_Products_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Name = "MasterData_v1_Products_Form";
            this.Text = "PRODUCTS";
            this.panel1.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputLeft.Panel1.ResumeLayout(false);
            this.scInputLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).EndInit();
            this.scInputRight.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.scInputContainer.Panel1.ResumeLayout(false);
            this.scInputContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).EndInit();
            this.scInputContainer.ResumeLayout(false);
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_ProductStoreNames;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_PercentageOfPercentCommission;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Vendors;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_MaxCommissionAmount;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_NameVendor;
    }
}