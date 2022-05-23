using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_Products_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_ProductStoreName;
        private DataGridViewColumn col_dgv_NameVendor;
        private DataGridViewColumn col_dgv_Vendors_Name;
        private DataGridViewColumn col_dgv_PercentageOfPercentCommission;
        private DataGridViewColumn col_dgv_MaxCommissionAmount;
        private DataGridViewColumn col_dgv_Active;
        private DataGridViewColumn col_dgv_Notes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_Products_Form() : this(FormModes.Add) { }
        public MasterData_v1_Products_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);
            scContent.Panel2Collapsed = true;

            setColumnsDataPropertyNames(Product.COL_DB_ID, Product.COL_DB_ACTIVE, null, null, null, null);
            col_dgv_ProductStoreName = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_ProductStoreName", iddl_ProductStoreNames.LabelText, Product.COL_STORENAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_NameVendor = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_NameVendor", itxt_NameVendor.LabelText, Product.COL_DB_NAMEVENDOR, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Vendors_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Vendors_Name", iddl_Vendors.LabelText, Product.COL_VENDORNAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_PercentageOfPercentCommission = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_PercentageOfPercentCommission", "%of%", Product.COL_DB_PercentageOfPercentCommission, true, true, "N2", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            col_dgv_MaxCommissionAmount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MaxCommission", "Max", Product.COL_DB_MaxCommissionAmount, true, true, "N0", false, false, 30, DataGridViewContentAlignment.MiddleRight);

            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, Product.COL_DB_NOTES, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ProductStoreName.populateInputControlDropDownList(iddl_ProductStoreNames, true);
            Vendor.populateDropDownList(iddl_Vendors.Dropdownlist.combobox, false, true);

            InputToDisableOnSearch.Add(in_PercentageOfPercentCommission);
            InputToDisableOnSearch.Add(in_MaxCommissionAmount);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                InputToDisablePermanently.Add(in_PercentageOfPercentCommission);
                InputToDisablePermanently.Add(in_MaxCommissionAmount);
                //in_PercentageOfPercentCommission.Visible = false;
                //in_MaxCommissionAmount.Visible = false;
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            iddl_ProductStoreNames.reset();
            itxt_NameVendor.reset();
            in_PercentageOfPercentCommission.reset();
            in_PercentageOfPercentCommission.Value = 100;
            in_MaxCommissionAmount.reset();
            iddl_Vendors.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return Product.get(chkIncludeInactive.Checked, null, null, null).DefaultView;
            else
                return Product.get(chkIncludeInactive.Checked, (Guid?)iddl_ProductStoreNames.SelectedValue, itxt_NameVendor.ValueText, (Guid?)iddl_Vendors.SelectedValue).DefaultView;
        }

        protected override void populateInputFields()
        {
            Product obj = new Product(selectedRowID());
            iddl_ProductStoreNames.SelectedValue = obj.StoreNameID;
            itxt_NameVendor.ValueText = obj.NameVendor;
            iddl_Vendors.SelectedValue = obj.VendorID;
            in_PercentageOfPercentCommission.Value = obj.PercentageOfPercentCommission;
            in_MaxCommissionAmount.Value = obj.MaxCommissionAmount;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            Product.update(selectedRowID(), (Guid)iddl_ProductStoreNames.SelectedValue, itxt_NameVendor.ValueText, (Guid)iddl_Vendors.SelectedValue, in_PercentageOfPercentCommission.ValueDecimal, in_MaxCommissionAmount.Value, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            Product.add((Guid)iddl_ProductStoreNames.SelectedValue, itxt_NameVendor.ValueText, (Guid)iddl_Vendors.SelectedValue, in_PercentageOfPercentCommission.ValueDecimal, in_MaxCommissionAmount.Value, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (!iddl_ProductStoreNames.hasSelectedValue())
                return iddl_ProductStoreNames.SelectedValueError("Please select a product name (store)");
            else if (itxt_NameVendor.isEmpty())
                return iddl_ProductStoreNames.SelectedValueError("Please input product name (vendor)");
            else if (!iddl_Vendors.hasSelectedValue())
                return iddl_ProductStoreNames.SelectedValueError("Please select a vendor");
            else if ((Mode != FormModes.Update && Product.isNameCombinationExist((Guid)iddl_ProductStoreNames.SelectedValue, itxt_NameVendor.ValueText, (Guid)iddl_Vendors.SelectedValue, null))
                || (Mode == FormModes.Update && Product.isNameCombinationExist((Guid)iddl_ProductStoreNames.SelectedValue, itxt_NameVendor.ValueText, (Guid)iddl_Vendors.SelectedValue, selectedRowID())))
                return iddl_ProductStoreNames.SelectedValueError("Product Name (Store) combination with Product Name (Vendor) and Vendor is already in the list");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            Product.updateActiveStatus(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void iddl_StoreName_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new MasterData.ProductStoreNames_Form(FormMode.New), false);
            ProductStoreName.populateDropDownList(iddl_ProductStoreNames.Dropdownlist.combobox, false, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
