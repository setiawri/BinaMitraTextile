using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_Vendors_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Name;
        private DataGridViewColumn col_dgv_Phone1;
        private DataGridViewColumn col_dgv_Phone2;
        private DataGridViewColumn col_dgv_Address;
        private DataGridViewColumn col_dgv_Notes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_Vendors_Form() : this(FormModes.Add) { }
        public MasterData_v1_Vendors_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            setColumnsDataPropertyNames(Vendor.COL_DB_ID, Vendor.COL_DB_ACTIVE, null, null, null, Vendor.COL_DB_usesFakturPajak);
            col_dgv_Checkbox1.HeaderText = "FP";
            col_dgv_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Name", itxt_Name.LabelText, Vendor.COL_DB_NAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Phone1 = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Phone1", itxt_Phone1.LabelText, Vendor.COL_DB_PHONE1, true, true, "", true, false, 70, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Phone2 = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Phone2", itxt_Phone2.LabelText, Vendor.COL_DB_PHONE2, true, true, "", true, false, 70, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Address = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Address", itxt_Address.LabelText, Vendor.COL_DB_ADDRESS, true, true, "", true, true, 100, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, Vendor.COL_DB_NOTES, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            InputToDisableOnSearch.Add(itxt_Notes);
            InputToDisableOnSearch.Add(itxt_Phone1);
            InputToDisableOnSearch.Add(itxt_Phone2);
            InputToDisableOnSearch.Add(itxt_Address);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            itxt_Name.reset();
            itxt_Phone1.reset();
            itxt_Phone2.reset();
            itxt_Address.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return Vendor.get(null, chkIncludeInactive.Checked, null).DefaultView;
            else
                return Vendor.get(null, chkIncludeInactive.Checked, itxt_Name.ValueText).DefaultView;
        }

        protected override void populateInputFields()
        {
            Vendor obj = new Vendor(selectedRowID());
            itxt_Name.ValueText = obj.Name;
            itxt_Phone1.ValueText = obj.Phone1;
            itxt_Phone2.ValueText = obj.Phone2;
            itxt_Address.ValueText = obj.Address;
            itxt_Notes.ValueText = obj.Notes;
        }

        protected override void update()
        {
            Vendor.update(selectedRowID(), itxt_Name.ValueText, itxt_Address.ValueText, itxt_Phone1.ValueText, itxt_Phone2.ValueText, itxt_Notes.ValueText);
        }

        protected override void add()
        {
            Vendor.add(itxt_Name.ValueText, itxt_Address.ValueText, itxt_Phone1.ValueText, itxt_Phone2.ValueText, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (itxt_Name.isEmpty())
                return itxt_Name.isValueError("Please input name");
            else if ((Mode != FormModes.Update && Vendor.isNameExist(itxt_Name.ValueText, null))
                || (Mode == FormModes.Update && Vendor.isNameExist(itxt_Name.ValueText, selectedRowID())))
                return itxt_Name.isValueError("Name is already in the list");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            Vendor.updateActiveStatus(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue)
        {
            Vendor.update_UsesFakturPajak(id, newValue);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
