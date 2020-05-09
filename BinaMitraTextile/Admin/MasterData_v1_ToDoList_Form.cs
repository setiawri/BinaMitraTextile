using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_ToDoList_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Timestamp;
        private DataGridViewColumn col_dgv_Description;
        private DataGridViewColumn col_dgv_Customers_Name;
        private DataGridViewColumn col_dgv_Vendors_Name;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_ToDoList_Form() : this(FormModes.Add) { }
        public MasterData_v1_ToDoList_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            enableFieldStatus<ToDoStatus>();
            setColumnsDataPropertyNames(ToDo.COL_DB_ID, null, ToDo.COL_STATUSNAME, ToDo.COL_DB_STATUSENUMID, null, null);
            col_dgv_Timestamp = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Timestamp", "Date", ToDo.COL_DB_TIMESTAMP, true, true, "dd/MM/yy", false, true, null, DataGridViewContentAlignment.MiddleCenter);
            col_dgv_Description = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Description", itxt_Description.LabelText, ToDo.COL_DB_DESCRIPTION, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_dgv_Customers_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Name", iddl_Customers.LabelText, ToDo.COL_CUSTOMERNAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Vendors_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Vendors_Name", iddl_Vendors.LabelText, ToDo.COL_VENDORNAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);

            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);
            Vendor.populateDropDownList(iddl_Vendors.Dropdownlist.combobox, false, true);

            ptInputPanel.PerformClick();
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            itxt_Description.reset();
            iddl_Customers.reset();
            iddl_Vendors.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return ToDo.get(itxt_Description.ValueText, (Guid?)iddl_Customers.SelectedValue, (Guid?)iddl_Vendors.SelectedValue, chkIncludeCompleted.Checked).DefaultView;
        }

        protected override void populateInputFields()
        {
            ToDo obj = new ToDo(selectedRowID());
            itxt_Description.ValueText = obj.Description;
            iddl_Customers.SelectedValue = obj.CustomerID;
            iddl_Vendors.SelectedValue = obj.VendorID;
        }

        protected override void update()
        {
            ToDo.update(selectedRowID(), itxt_Description.ValueText, (Guid?)iddl_Customers.SelectedValue, (Guid?)iddl_Vendors.SelectedValue);
        }

        protected override void add()
        {
            ToDo.add(itxt_Description.ValueText, (Guid?)iddl_Customers.SelectedValue, (Guid?)iddl_Vendors.SelectedValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(itxt_Description.ValueText))
                return itxt_Description.isValueError("Please provide description");
            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override string getSelectedItemDescription(int rowIndex)
        {
            return string.Format("{0}",
                Util.getSelectedRowValue(dgv, col_dgv_Description)
                );
        }

        protected override void changeStatus_Click(object sender, EventArgs args)
        {
            ToDo.updateStatus(selectedRowID(), Tools.parseEnum<ToDoStatus>(sender.ToString()));
            base.changeStatus_Click(sender, args);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void iddl_Customers_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_Customers_Form(FormModes.Add), false);
            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);
        }

        private void iddl_Vendors_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_Vendors_Form(FormModes.Add), false);
            Vendor.populateDropDownList(iddl_Vendors.Dropdownlist.combobox, false, true);
        }

        private void chkIncludeCompleted_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
