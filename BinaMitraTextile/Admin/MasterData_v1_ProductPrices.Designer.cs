namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_ProductPrices
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
            this.iddl_Grades = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_ProductWidths = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_LengthUnits = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_FabricColors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.chkOnlyNotOK = new System.Windows.Forms.CheckBox();
            this.in_InventoryCode = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_BuyPrice = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.in_SellPrice = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.pnlRowInfo.SuspendLayout();
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
            this.scInputLeft.Panel1.Controls.Add(this.in_InventoryCode);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_Grades);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_ProductStoreNames);
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
            this.scInputRight.Panel1.Controls.Add(this.in_SellPrice);
            this.scInputRight.Panel1.Controls.Add(this.in_BuyPrice);
            this.scInputRight.Panel1.Controls.Add(this.itxt_Notes);
            this.scInputRight.Size = new System.Drawing.Size(375, 151);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.DarkOrange;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(779, 450);
            this.scMain.SplitterDistance = 200;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Size = new System.Drawing.Size(779, 26);
            this.pnlButtons.Controls.SetChildIndex(this.btnSearch, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnLog, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnAdd, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnDelete, 0);
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
            // col_dgv_Active
            // 
            this.col_dgv_Active.Width = 40;
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Location = new System.Drawing.Point(0, 149);
            this.pnlRowInfo.Size = new System.Drawing.Size(779, 100);
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(759, 21);
            // 
            // pnlRowInfoContent
            // 
            this.pnlRowInfoContent.Size = new System.Drawing.Size(779, 79);
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
            // in_InventoryCode
            // 
            this.in_InventoryCode.Checked = false;
            this.in_InventoryCode.DecimalPlaces = 0;
            this.in_InventoryCode.HideUpDown = false;
            this.in_InventoryCode.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_InventoryCode.LabelText = "Inventory Code";
            this.in_InventoryCode.Location = new System.Drawing.Point(3, 6);
            this.in_InventoryCode.MaximumValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.in_InventoryCode.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_InventoryCode.Name = "in_InventoryCode";
            this.in_InventoryCode.ShowAllowDecimalCheckbox = false;
            this.in_InventoryCode.ShowCheckbox = true;
            this.in_InventoryCode.ShowTextboxOnly = false;
            this.in_InventoryCode.Size = new System.Drawing.Size(103, 41);
            this.in_InventoryCode.TabIndex = 3;
            this.in_InventoryCode.Value = null;
            this.in_InventoryCode.CheckedChanged += new System.EventHandler(this.in_InventoryCode_CheckedChanged);
            // 
            // in_BuyPrice
            // 
            this.in_BuyPrice.Checked = false;
            this.in_BuyPrice.DecimalPlaces = 2;
            this.in_BuyPrice.HideUpDown = false;
            this.in_BuyPrice.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.in_BuyPrice.LabelText = "Buy Price";
            this.in_BuyPrice.Location = new System.Drawing.Point(94, 3);
            this.in_BuyPrice.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_BuyPrice.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_BuyPrice.Name = "in_BuyPrice";
            this.in_BuyPrice.ShowAllowDecimalCheckbox = false;
            this.in_BuyPrice.ShowCheckbox = false;
            this.in_BuyPrice.ShowTextboxOnly = false;
            this.in_BuyPrice.Size = new System.Drawing.Size(89, 41);
            this.in_BuyPrice.TabIndex = 8;
            this.in_BuyPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // in_SellPrice
            // 
            this.in_SellPrice.Checked = false;
            this.in_SellPrice.DecimalPlaces = 2;
            this.in_SellPrice.HideUpDown = false;
            this.in_SellPrice.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.in_SellPrice.LabelText = "Sell Price";
            this.in_SellPrice.Location = new System.Drawing.Point(3, 3);
            this.in_SellPrice.MaximumValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.in_SellPrice.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_SellPrice.Name = "in_SellPrice";
            this.in_SellPrice.ShowAllowDecimalCheckbox = false;
            this.in_SellPrice.ShowCheckbox = false;
            this.in_SellPrice.ShowTextboxOnly = false;
            this.in_SellPrice.Size = new System.Drawing.Size(89, 41);
            this.in_SellPrice.TabIndex = 9;
            this.in_SellPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(302, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MasterData_v1_ProductPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Mode = LIBUtil.FormModes.Add;
            this.Name = "MasterData_v1_ProductPrices";
            this.Text = "PRODUCT PRICES";
            this.Shown += new System.EventHandler(this.MasterData_v1_ProductPrices_Shown);
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
            this.pnlRowInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_ProductWidths;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Grades;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_ProductStoreNames;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_FabricColors;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_LengthUnits;
        private System.Windows.Forms.CheckBox chkOnlyNotOK;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_InventoryCode;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_SellPrice;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_BuyPrice;
        private System.Windows.Forms.Button btnDelete;
    }
}