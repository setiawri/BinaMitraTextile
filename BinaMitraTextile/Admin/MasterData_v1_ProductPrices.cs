using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_ProductPrices : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Products_Storename;
        private DataGridViewColumn col_dgv_Grades_Name;
        private DataGridViewColumn col_dgv_ProductWidths_Name;
        private DataGridViewColumn col_dgv_LengthUnits_Name;
        private DataGridViewColumn col_dgv_FabricColors_Name;
        private DataGridViewColumn col_dgv_SellPrice;
        private DataGridViewColumn col_dgv_BuyPrice;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_Checked;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_ProductPrices() : this(FormModes.Add, null) { }
        public MasterData_v1_ProductPrices(Guid Inventory_Id) : this(FormModes.Add, Inventory_Id) { }
        public MasterData_v1_ProductPrices(FormModes startingMode, Guid? Inventory_Id) : base(startingMode, FORM_SHOWDATAONLOAD) 
        { 
            InitializeComponent(); 

        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setProductPrice()
        {
            iddl_FabricColors.Enabled
                = iddl_Grades.Enabled
                = iddl_LengthUnits.Enabled
                = iddl_ProductStoreNames.Enabled
                = iddl_ProductWidths.Enabled
                = !in_InventoryCode.Checked;

            btnDelete.Enabled = in_InventoryCode.Checked;
        }

        #endregion
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            setColumnsDataPropertyNames(ProductPrice.COL_DB_ID, null, null, null, null, null);

            ProductStoreName.populateInputControlDropDownList(iddl_ProductStoreNames, false);
            Grade.populateInputControlDropDownList(iddl_Grades, false);
            ProductWidth.populateInputControlDropDownList(iddl_ProductWidths, false);
            LengthUnit.populateInputControlDropDownList(iddl_LengthUnits, false);
            FabricColor.populateInputControlDropDownList(iddl_FabricColors, false);

            col_dgv_Products_Storename = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Products_Storename", iddl_ProductStoreNames.LabelText, ProductPrice.COL_PRODUCTSTORENAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Grades_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Grades_Name", iddl_Grades.LabelText, ProductPrice.COL_Grades_Name, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_ProductWidths_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_ProductWidths_Name", iddl_ProductWidths.LabelText, ProductPrice.COL_ProductWidths_Name, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_LengthUnits_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_LengthUnits_Name", iddl_LengthUnits.LabelText, ProductPrice.COL_LengthUnits_Name, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_FabricColors_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_FabricColors_Name", iddl_FabricColors.LabelText, ProductPrice.COL_COLORNAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_SellPrice = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_SellPrice", in_SellPrice.LabelText, ProductPrice.COL_DB_SELLPRICE, true, true, "N2", false, false, 60, DataGridViewContentAlignment.MiddleRight);
            col_dgv_BuyPrice = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_BuyPrice", in_BuyPrice.LabelText, ProductPrice.COL_DB_BuyPrice, true, true, "N2", false, false, 60, DataGridViewContentAlignment.MiddleRight);
            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, ProductPrice.COL_DB_NOTES, true, true, "", true, true, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_dgv_Checked = base.addColumn<DataGridViewCheckBoxCell>(dgv, "col_dgv_Checked", "OK", ProductPrice.COL_DB_Checked, true, true, "", false, false, 30, DataGridViewContentAlignment.MiddleLeft);            
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                Util.setControlsVisibility(false,
                    col_dgv_Checked,
                    col_dgv_BuyPrice,
                    in_BuyPrice,
                    chkOnlyNotOK,
                    btnDelete
                    );
            }
        }

        protected override void additionalSettings()
        {
        }

        protected override void clearInputFields()
        {
            in_InventoryCode.reset();
            iddl_ProductStoreNames.reset();
            iddl_Grades.reset();
            iddl_FabricColors.reset();
            iddl_LengthUnits.reset();
            iddl_ProductWidths.reset();
            in_SellPrice.reset();
            in_BuyPrice.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return ProductPrice.get(chkOnlyNotOK.Checked).DefaultView;
            else
                return ProductPrice.get(null,
                    (Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_Grades.SelectedValue, (Guid)iddl_ProductWidths.SelectedValue,
                    (Guid)iddl_LengthUnits.SelectedValue, null, (Guid)iddl_FabricColors.SelectedValue, chkOnlyNotOK.Checked).DefaultView;
        }

        protected override void populateInputFields()
        {
            ProductPrice obj = new ProductPrice(selectedRowID());
            in_InventoryCode.setValue((decimal)obj.Inventory_Code, obj.InventoryID);
            iddl_ProductStoreNames.SelectedValue = obj.ProductStoreNameID;
            iddl_Grades.SelectedValue = obj.GradeID;
            iddl_ProductWidths.SelectedValue = obj.ProductWidthID;
            iddl_LengthUnits.SelectedValue = obj.LengthUnitID;
            iddl_FabricColors.SelectedValue = obj.ColorID;
            in_BuyPrice.Value = obj.BuyPrice;
            in_SellPrice.Value = obj.TagPrice;
            itxt_Notes.ValueText = obj.Notes;

            setProductPrice();
        }

        protected override void update()
        {
            ProductPrice.update(selectedRowID(), (Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_Grades.SelectedValue, 
                (Guid)iddl_ProductWidths.SelectedValue,
                (Guid)iddl_LengthUnits.SelectedValue, in_SellPrice.ValueDecimal, itxt_Notes.ValueText, 
                in_InventoryCode.ValueGuid, (Guid?)iddl_FabricColors.SelectedValue,
                in_BuyPrice.ValueDecimal);
        }

        protected override void add()
        {
            ProductPrice.add((Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_Grades.SelectedValue,
                (Guid)iddl_ProductWidths.SelectedValue,
                (Guid)iddl_LengthUnits.SelectedValue, in_SellPrice.ValueDecimal, itxt_Notes.ValueText,
                in_InventoryCode.ValueGuid, (Guid?)iddl_FabricColors.SelectedValue,
                in_BuyPrice.ValueDecimal);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (!iddl_ProductStoreNames.hasSelectedValue())
                return iddl_ProductStoreNames.SelectedValueError("Please select product");
            else if (!iddl_Grades.hasSelectedValue())
                return iddl_Grades.SelectedValueError("Please select grade");
            else if (!iddl_ProductWidths.hasSelectedValue())
                return iddl_ProductWidths.SelectedValueError("Please select width");
            else if (!iddl_LengthUnits.hasSelectedValue())
                return iddl_LengthUnits.SelectedValueError("Please select unit");

            return true;
        }

        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form(selectedRowID()));
            txtQuickSearch.Focus();
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue) { }

        private void MasterData_v1_ProductPrices_Shown(object sender, EventArgs e)
        {
            ptInputPanel.PerformClick();
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_dgv_Checked))
            {
                //ProductPrice.updateCheckedStatus(GlobalData.UserAccount.id, (Guid)Util.getSelectedRowValue(sender, col_dgv_Id), !Util.getCheckboxValue(sender, e));
                populateGridViewDataSource(true);
            }
        }

        private void chkOnlyNotOK_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        private void in_InventoryCode_CheckedChanged(object sender, EventArgs e)
        {
            setProductPrice();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductPrice.delete(selectedRowID());
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS


        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
