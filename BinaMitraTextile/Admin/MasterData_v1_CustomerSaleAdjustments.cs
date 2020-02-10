using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_CustomerSaleAdjustments : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_UserAccounts_Name;
        private DataGridViewColumn col_dgv_Products_Storename;
        private DataGridViewColumn col_dgv_Grades_Name;
        private DataGridViewColumn col_dgv_ProductWidths_Name;
        private DataGridViewColumn col_dgv_LengthUnits_Name;
        private DataGridViewColumn col_dgv_FabricColors_Name;
        private DataGridViewColumn col_dgv_Adjustment;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_Checked;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_CustomerSaleAdjustments() : this(FormModes.Add) { }
        public MasterData_v1_CustomerSaleAdjustments(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            disableFieldActive();

            setColumnsDataPropertyNames(CustomerSaleAdjustment.COL_DB_ID, null, null, null, null, null);

            Customer.populateInputControlDropDownList(iddl_Customers, false);
            ProductStoreName.populateInputControlDropDownList(iddl_ProductStoreNames, false);
            Grade.populateInputControlDropDownList(iddl_Grades, false);
            ProductWidth.populateInputControlDropDownList(iddl_ProductWidths, false);
            LengthUnit.populateInputControlDropDownList(iddl_LengthUnits, false);
            FabricColor.populateInputControlDropDownList(iddl_FabricColors, false);

            col_dgv_UserAccounts_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_UserAccounts_Name", iddl_Customers.LabelText, CustomerSaleAdjustment.COL_CUSTOMERNAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Products_Storename = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Products_Storename", iddl_ProductStoreNames.LabelText, CustomerSaleAdjustment.COL_PRODUCTSTORENAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Grades_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Grades_Name", iddl_Grades.LabelText, CustomerSaleAdjustment.COL_GRADE_NAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_ProductWidths_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_ProductWidths_Name", iddl_ProductWidths.LabelText, CustomerSaleAdjustment.COL_PRODUCT_WIDTH_NAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_LengthUnits_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_LengthUnits_Name", iddl_LengthUnits.LabelText, CustomerSaleAdjustment.COL_LENGTH_UNIT_NAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_FabricColors_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_FabricColors_Name", iddl_FabricColors.LabelText, CustomerSaleAdjustment.COL_COLOR_NAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Adjustment = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Adjustment", in_Adjustment.LabelText, CustomerSaleAdjustment.COL_DB_ADJUSTMENTPERUNIT, true, true, "", false, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, CustomerSaleAdjustment.COL_DB_NOTES, true, true, "", true, true, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_dgv_Checked = base.addColumn<DataGridViewCheckBoxCell>(dgv, "col_dgv_Checked", "OK", CustomerSaleAdjustment.COL_DB_Checked, true, true, "", false, false, 30, DataGridViewContentAlignment.MiddleLeft);
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                chkOnlyNotOK.Visible = false;
                col_dgv_Checked.Visible = false;
            }
        }

        protected override void additionalSettings()
        {
        }

        protected override void clearInputFields()
        {
            iddl_Customers.reset();
            iddl_ProductStoreNames.reset();
            iddl_Grades.reset();
            iddl_FabricColors.reset();
            iddl_LengthUnits.reset();
            iddl_ProductWidths.reset();
            in_Adjustment.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return CustomerSaleAdjustment.getAll(null, null, null, null, null, null, chkOnlyNotOK.Checked).DefaultView;
            else
                return CustomerSaleAdjustment.getAll((Guid)iddl_Customers.SelectedValue, (Guid)iddl_Grades.SelectedValue,
                    (Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_ProductWidths.SelectedValue,
                    (Guid)iddl_LengthUnits.SelectedValue, (Guid)iddl_FabricColors.SelectedValue, chkOnlyNotOK.Checked).DefaultView;
        }

        protected override void populateInputFields()
        {
            CustomerSaleAdjustment obj = new CustomerSaleAdjustment(selectedRowID());
            iddl_Customers.SelectedValue = obj.CustomerID;
            iddl_ProductStoreNames.SelectedValue = obj.ProductStoreNameID;
            iddl_Grades.SelectedValue = obj.GradeID;
            iddl_ProductWidths.SelectedValue = obj.ProductWidthID;
            iddl_LengthUnits.SelectedValue = obj.LengthUnitID;
            iddl_FabricColors.SelectedValue = obj.ColorID;
            in_Adjustment.Value = obj.AdjustmentPerUnit;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            CustomerSaleAdjustment.update(selectedRowID(), (Guid)iddl_Customers.SelectedValue, (Guid)iddl_Grades.SelectedValue, 
                (Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_ProductWidths.SelectedValue,
                (Guid)iddl_LengthUnits.SelectedValue, (Guid?)iddl_FabricColors.SelectedValue, 
                in_Adjustment.ValueDecimal, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            CustomerSaleAdjustment.add((Guid)iddl_Customers.SelectedValue, (Guid)iddl_Grades.SelectedValue,
                (Guid)iddl_ProductStoreNames.SelectedValue, (Guid)iddl_ProductWidths.SelectedValue,
                (Guid)iddl_LengthUnits.SelectedValue, (Guid?)iddl_FabricColors.SelectedValue,
                in_Adjustment.ValueDecimal, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (!iddl_Customers.hasSelectedValue())
                return iddl_Customers.SelectedValueError("Please select customer");
            else if (!iddl_ProductStoreNames.hasSelectedValue())
                return iddl_ProductStoreNames.SelectedValueError("Please select product");
            else if (!iddl_Grades.hasSelectedValue())
                return iddl_Grades.SelectedValueError("Please select grade");
            else if (!iddl_ProductWidths.hasSelectedValue())
                return iddl_ProductWidths.SelectedValueError("Please select width");
            else if (!iddl_LengthUnits.hasSelectedValue())
                return iddl_LengthUnits.SelectedValueError("Please select unit");
            else if ((Mode != FormModes.Update && CustomerSaleAdjustment.isCombinationExist(null, (Guid)iddl_Customers.SelectedValue, 
                                                        (Guid)iddl_Grades.SelectedValue, (Guid)iddl_ProductStoreNames.SelectedValue, 
                                                        (Guid)iddl_ProductWidths.SelectedValue,
                                                        (Guid)iddl_LengthUnits.SelectedValue, (Guid?)iddl_FabricColors.SelectedValue))
                || (Mode == FormModes.Update && CustomerSaleAdjustment.isCombinationExist(selectedRowID(), (Guid)iddl_Customers.SelectedValue, 
                                                        (Guid)iddl_Grades.SelectedValue, (Guid)iddl_ProductStoreNames.SelectedValue, 
                                                        (Guid)iddl_ProductWidths.SelectedValue,
                                                        (Guid)iddl_LengthUnits.SelectedValue, (Guid?)iddl_FabricColors.SelectedValue)))
                return iddl_ProductStoreNames.SelectedValueError("Combination is already in the list");

            return true;
        }

        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form(selectedRowID()));
            txtQuickSearch.Focus();
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue) { }

        private void MasterData_v1_CustomerSaleAdjustments_Shown(object sender, EventArgs e)
        {
            ptInputPanel.PerformClick();
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_dgv_Checked))
            {
                CustomerSaleAdjustment.updateCheckedStatus(GlobalData.UserAccount.id, (Guid)Util.getSelectedRowValue(sender, col_dgv_Id), !Util.getCheckboxValue(sender, e));
                populateGridViewDataSource(true);
            }
        }

        private void chkOnlyNotOK_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS


        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
