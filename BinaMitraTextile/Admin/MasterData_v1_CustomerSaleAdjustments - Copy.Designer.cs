namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_CustomerSaleAdjustments
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
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_ProductStoreNames = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_Grades = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_ProductWidths = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_LengthUnits = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_FabricColors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.in_Adjustment = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.chkOnlyNotOK = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.Panel1.SuspendLayout();
            this.scInputLeft.Panel2.SuspendLayout();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.Panel1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(779, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 177);
            this.pnlActionButtons.Size = new System.Drawing.Size(779, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Grades);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_ProductStoreNames);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Customers);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.iddl_FabricColors);
            this.scInputLeft.Panel2.Controls.Add(this.iddl_ProductWidths);
            this.scInputLeft.Panel2.Controls.Add(this.iddl_LengthUnits);
            this.scInputLeft.Size = new System.Drawing.Size(400, 151);
            this.scInputLeft.SplitterDistance = 200;
            // 
            // scInputRight
            // 
            // 
            // scInputRight.Panel1
            // 
            this.scInputRight.Panel1.Controls.Add(this.in_Adjustment);
            this.scInputRight.Panel1.Controls.Add(this.itxt_Notes);
            this.scInputRight.Size = new System.Drawing.Size(375, 151);
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(779, 450);
            this.scMain.SplitterDistance = 200;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(779, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(779, 151);
            this.scInputContainer.SplitterDistance = 400;
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkOnlyNotOK);
            this.pnlQuickSearch.Size = new System.Drawing.Size(749, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkOnlyNotOK, 0);
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(3, 48);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(180, 86);
            this.itxt_Notes.TabIndex = 0;
            this.itxt_Notes.ValueText = "";
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = true;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(3, 6);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedIndex = -1;
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedItemText = "";
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(180, 41);
            this.iddl_Customers.TabIndex = 0;
            // 
            // iddl_ProductStoreNames
            // 
            this.iddl_ProductStoreNames.DisableTextInput = false;
            this.iddl_ProductStoreNames.HideFilter = false;
            this.iddl_ProductStoreNames.HideUpdateLink = true;
            this.iddl_ProductStoreNames.LabelText = "Product";
            this.iddl_ProductStoreNames.Location = new System.Drawing.Point(3, 48);
            this.iddl_ProductStoreNames.Name = "iddl_ProductStoreNames";
            this.iddl_ProductStoreNames.SelectedIndex = -1;
            this.iddl_ProductStoreNames.SelectedItem = null;
            this.iddl_ProductStoreNames.SelectedItemText = "";
            this.iddl_ProductStoreNames.SelectedValue = null;
            this.iddl_ProductStoreNames.ShowDropdownlistOnly = false;
            this.iddl_ProductStoreNames.Size = new System.Drawing.Size(180, 41);
            this.iddl_ProductStoreNames.TabIndex = 1;
            // 
            // iddl_Grades
            // 
            this.iddl_Grades.DisableTextInput = false;
            this.iddl_Grades.HideFilter = false;
            this.iddl_Grades.HideUpdateLink = true;
            this.iddl_Grades.LabelText = "Grade";
            this.iddl_Grades.Location = new System.Drawing.Point(3, 90);
            this.iddl_Grades.Name = "iddl_Grades";
            this.iddl_Grades.SelectedIndex = -1;
            this.iddl_Grades.SelectedItem = null;
            this.iddl_Grades.SelectedItemText = "";
            this.iddl_Grades.SelectedValue = null;
            this.iddl_Grades.ShowDropdownlistOnly = false;
            this.iddl_Grades.Size = new System.Drawing.Size(180, 41);
            this.iddl_Grades.TabIndex = 2;
            // 
            // iddl_ProductWidths
            // 
            this.iddl_ProductWidths.DisableTextInput = false;
            this.iddl_ProductWidths.HideFilter = false;
            this.iddl_ProductWidths.HideUpdateLink = true;
            this.iddl_ProductWidths.LabelText = "Lebar";
            this.iddl_ProductWidths.Location = new System.Drawing.Point(3, 6);
            this.iddl_ProductWidths.Name = "iddl_ProductWidths";
            this.iddl_ProductWidths.SelectedIndex = -1;
            this.iddl_ProductWidths.SelectedItem = null;
            this.iddl_ProductWidths.SelectedItemText = "";
            this.iddl_ProductWidths.SelectedValue = null;
            this.iddl_ProductWidths.ShowDropdownlistOnly = false;
            this.iddl_ProductWidths.Size = new System.Drawing.Size(180, 41);
            this.iddl_ProductWidths.TabIndex = 3;
            // 
            // iddl_LengthUnits
            // 
            this.iddl_LengthUnits.DisableTextInput = false;
            this.iddl_LengthUnits.HideFilter = false;
            this.iddl_LengthUnits.HideUpdateLink = true;
            this.iddl_LengthUnits.LabelText = "Unit";
            this.iddl_LengthUnits.Location = new System.Drawing.Point(3, 48);
            this.iddl_LengthUnits.Name = "iddl_LengthUnits";
            this.iddl_LengthUnits.SelectedIndex = -1;
            this.iddl_LengthUnits.SelectedItem = null;
            this.iddl_LengthUnits.SelectedItemText = "";
            this.iddl_LengthUnits.SelectedValue = null;
            this.iddl_LengthUnits.ShowDropdownlistOnly = false;
            this.iddl_LengthUnits.Size = new System.Drawing.Size(180, 41);
            this.iddl_LengthUnits.TabIndex = 0;
            // 
            // iddl_FabricColors
            // 
            this.iddl_FabricColors.DisableTextInput = false;
            this.iddl_FabricColors.HideFilter = false;
            this.iddl_FabricColors.HideUpdateLink = true;
            this.iddl_FabricColors.LabelText = "Color";
            this.iddl_FabricColors.Location = new System.Drawing.Point(3, 90);
            this.iddl_FabricColors.Name = "iddl_FabricColors";
            this.iddl_FabricColors.SelectedIndex = -1;
            this.iddl_FabricColors.SelectedItem = null;
            this.iddl_FabricColors.SelectedItemText = "";
            this.iddl_FabricColors.SelectedValue = null;
            this.iddl_FabricColors.ShowDropdownlistOnly = false;
            this.iddl_FabricColors.Size = new System.Drawing.Size(180, 41);
            this.iddl_FabricColors.TabIndex = 1;
            // 
            // in_Adjustment
            // 
            this.in_Adjustment.Checked = false;
            this.in_Adjustment.DecimalPlaces = 0;
            this.in_Adjustment.HideUpDown = false;
            this.in_Adjustment.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.in_Adjustment.LabelText = "Adjustment";
            this.in_Adjustment.Location = new System.Drawing.Point(3, 6);
            this.in_Adjustment.MaximumValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.in_Adjustment.MinimumValue = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.in_Adjustment.Name = "in_Adjustment";
            this.in_Adjustment.ShowAllowDecimalCheckbox = false;
            this.in_Adjustment.ShowCheckbox = false;
            this.in_Adjustment.ShowTextboxOnly = false;
            this.in_Adjustment.Size = new System.Drawing.Size(180, 41);
            this.in_Adjustment.TabIndex = 2;
            this.in_Adjustment.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chkOnlyNotOK
            // 
            this.chkOnlyNotOK.AutoSize = true;
            this.chkOnlyNotOK.Location = new System.Drawing.Point(199, 6);
            this.chkOnlyNotOK.Name = "chkOnlyNotOK";
            this.chkOnlyNotOK.Size = new System.Drawing.Size(87, 17);
            this.chkOnlyNotOK.TabIndex = 97;
            this.chkOnlyNotOK.Text = "only not OK  ";
            this.chkOnlyNotOK.UseVisualStyleBackColor = true;
            this.chkOnlyNotOK.CheckedChanged += new System.EventHandler(this.chkOnlyNotOK_CheckedChanged);
            // 
            // MasterData_v1_CustomerSaleAdjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Name = "MasterData_v1_CustomerSaleAdjustments";
            this.Text = "SALE ADJUSTMENTS";
            this.Shown += new System.EventHandler(this.MasterData_v1_CustomerSaleAdjustments_Shown);
            this.panel1.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputLeft.Panel1.ResumeLayout(false);
            this.scInputLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            this.scInputRight.Panel1.ResumeLayout(false);
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
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_ProductWidths;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Grades;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_ProductStoreNames;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Adjustment;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_FabricColors;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_LengthUnits;
        private System.Windows.Forms.CheckBox chkOnlyNotOK;
    }
}