using System;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class MasterData_v1_Customers_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;
        private const bool FORM_SHOWPROGRESSBARONPOPULATE = true;
        private const int FORM_TIMERTIMEOUTSECONDS = 1;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_Name;
        private DataGridViewColumn col_dgv_Phone1;
        private DataGridViewColumn col_dgv_Phone2;
        private DataGridViewColumn col_dgv_City;
        private DataGridViewColumn col_dgv_Address;
        private DataGridViewColumn col_dgv_Transport;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_SalesUserAccount;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_Customers_Form() : this(FormModes.Add) { }
        public MasterData_v1_Customers_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD, FORM_SHOWPROGRESSBARONPOPULATE, FORM_TIMERTIMEOUTSECONDS) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion METHODS
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            setColumnsDataPropertyNames(Customer.COL_DB_ID, Customer.COL_DB_ACTIVE, null, null, null, Customer.COL_DB_usesFakturPajak);
            col_dgv_Checkbox1.HeaderText = "FP";
            col_dgv_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Name", itxt_Name.LabelText, Customer.COL_DB_NAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Phone1 = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Phone1", itxt_Phone1.LabelText, Customer.COL_DB_PHONE1, true, true, "", true, false, 70, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Phone2 = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Phone2", itxt_Phone2.LabelText, Customer.COL_DB_PHONE2, true, true, "", true, false, 70, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_City = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_City", iddl_Cities.LabelText, Customer.COL_CITYNAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Address = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Address", itxt_Address.LabelText, Customer.COL_DB_ADDRESS, true, true, "", true, true, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Transport = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Transport", iddl_Transports.LabelText, Customer.COL_DEFAULTTRANSPORTNAME, true, true, "", true, false, 60, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_SalesUserAccount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_SalesUserAccount", iddl_Sales_UserAccounts.LabelText, Customer.COL_SALESUSERNAME, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, Customer.COL_DB_NOTES, true, true, "", true, true, null, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Transport.populateInputControlDropDownList(iddl_Transports, true);
            City.populateInputControlDropDownList(iddl_Cities, true);
            UserAccount.populateInputControlDropDownList(iddl_Sales_UserAccounts, true);

            InputToDisableOnSearch.Add(itxt_Phone1);
            InputToDisableOnSearch.Add(itxt_Phone2);
            InputToDisableOnSearch.Add(itxt_Address);
            InputToDisableOnSearch.Add(itxt_Notes);

            ptInputPanel.PerformClick();
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                iddl_Sales_UserAccounts.Visible = false;
            }
        }

        protected override void additionalSettings() { }

        protected override void clearInputFields()
        {
            itxt_Name.reset();
            itxt_Phone1.reset();
            itxt_Phone2.reset();
            iddl_Cities.reset();
            itxt_Address.reset();
            iddl_Transports.reset();
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormModes.Add)
                return Customer.get(null, chkIncludeInactive.Checked, null, null, null).DefaultView;
            else
                return Customer.get(null, chkIncludeInactive.Checked, itxt_Name.ValueText, (Guid?)iddl_Cities.SelectedValue, (Guid?)iddl_Transports.SelectedValue).DefaultView;
        }

        protected override void populateInputFields()
        {
            Customer obj = new Customer(selectedRowID());
            itxt_Name.ValueText = obj.Name;
            itxt_Phone1.ValueText = obj.Phone1;
            itxt_Phone2.ValueText = obj.Phone2;
            iddl_Cities.SelectedValue = obj.CityID;
            itxt_Address.ValueText = obj.Address;
            iddl_Transports.SelectedValue = obj.DefaultTransportID;
            itxt_Notes.ValueText = obj.Notes;
            iddl_Sales_UserAccounts.SelectedValue = obj.SalesUserID;
        }

        protected override void update()
        {
            Customer.update(selectedRowID(), itxt_Name.ValueText, itxt_Address.ValueText, (Guid)iddl_Cities.SelectedValue, (Guid?)iddl_Transports.SelectedValue, itxt_Phone1.ValueText, itxt_Phone2.ValueText, itxt_Notes.ValueText, (Guid?)iddl_Sales_UserAccounts.SelectedValue);
        }

        protected override void add()
        {
            Customer.add(itxt_Name.ValueText, itxt_Address.ValueText, (Guid)iddl_Cities.SelectedValue, (Guid?)iddl_Transports.SelectedValue, itxt_Phone1.ValueText, itxt_Phone2.ValueText, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (itxt_Name.isEmpty())
                return itxt_Name.isValueError("Please provide name");
            else if ((Mode != FormModes.Update && Customer.isNameExist(itxt_Name.ValueText, null))
                || (Mode == FormModes.Update && Customer.isNameExist(itxt_Name.ValueText, selectedRowID())))
                return itxt_Name.isValueError("Name is already in the list");            
            else if (!iddl_Cities.hasSelectedValue())
                return iddl_Cities.SelectedValueError("Please select a city");

            return true;
        }
        
        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form((Guid)Util.getSelectedRowValue(dgv, col_dgv_Id)), false);
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateActiveStatus(Guid id, bool activeStatus)
        {
            Customer.updateActiveStatus(id, activeStatus);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue)
        {
            Customer.update_UsesFakturPajak(id, newValue);
        }

        #endregion OVERRIDE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Iddl_Cities_UpdateLink_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Cities_Form(FormMode.New));
            City.populateInputControlDropDownList(iddl_Cities, true);
        }

        private void Iddl_Transports_UpdateLink_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Transports_Form(FormMode.New));
            Transport.populateInputControlDropDownList(iddl_Transports, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
