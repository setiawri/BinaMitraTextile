using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class Customers_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "CUSTOMERS";
        private const int FORM_MINIMUMWIDTH = 750;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;
        private InputTextbox _inputTxtPhone1;
        private InputTextbox _inputTxtPhone2;
        private InputTextbox _inputTxtAddress;
        private InputDropdownlist _inputDDLCities;
        private InputDropdownlist _inputDDLTransports;
        private InputTextbox _inputTxtNotes;
        private InputDropdownlist _inputDDLSales;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Customers_Form(FormMode startingMode)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH)
        {
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            disableFieldActive();

            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = Customer.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", Customer.COL_DB_NAME, false);
            _inputTxtName.setMaxLength(50); //set max length
            col_grid_name.DataPropertyName = Customer.COL_DB_NAME; //set field's data property name in gridview

            //Field Phone1 - textbox
            _inputTxtPhone1 = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Phone 1", Customer.COL_DB_PHONE1, 0, true, false, null);
            _inputTxtPhone1.setMaxLength(20); //set max length

            //Field Phone2 - textbox
            _inputTxtPhone2 = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Phone 2", Customer.COL_DB_PHONE2, 0, true, false, null);
            _inputTxtPhone2.setMaxLength(20); //set max length

            //Field City - dropdownlist
            _inputDDLCities = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "City", Customer.COL_CITYNAME, 0, true, false, null);
            _inputDDLCities.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateCity_LinkClicked); //add event handler for update link
            City.populateDropDownList(_inputDDLCities.Dropdownlist, false, true); //populate

            //Field Address - textbox
            _inputTxtAddress = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Address", Customer.COL_DB_ADDRESS, 100, true, false, null);
            _inputTxtAddress.setToMultiline(4);

            //Field Transport - dropdownlist
            _inputDDLTransports = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 2, "Angkutan", Customer.COL_DEFAULTTRANSPORTNAME, 100, true, false, null);
            _inputDDLTransports.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateTransports_LinkClicked); //add event handler for update link
            Transport.populateDropDownList(_inputDDLTransports.Dropdownlist, false, true); //populate

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", Customer.COL_DB_NOTES, 100, true, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(100); //set max length

            //Field Sales - dropdownlist
            _inputDDLSales = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Sales", Customer.COL_SALESUSERNAME, 0, true, false, null);
            UserAccount.populateDropDownList(_inputDDLSales.Dropdownlist, false, true); //populate

            //set default control to focus
            DefaultInputToFocus = _inputTxtName;

            if (GlobalData.UserAccount.role == Roles.User)
            {
                _inputDDLSales.Visible = false;
            }
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            if (!_inputDDLCities.isValidSelectedValue())
                return false;

            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return Customer.getByFilter(chkIncludeInactive.Checked, _inputTxtName.TextValue, _inputDDLCities.SelectedValue, _inputDDLTransports.SelectedValue).DefaultView;
        }

        protected override void populateInputFields()
        {
            Customer obj = new Customer(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
            _inputDDLCities.SelectedValue = obj.CityID;
            _inputDDLTransports.SelectedValue = obj.DefaultTransportID;
            _inputTxtAddress.TextValue = obj.Address;
            _inputTxtNotes.TextValue = obj.Notes;
            _inputTxtPhone1.TextValue = obj.Phone1;
            _inputTxtPhone2.TextValue = obj.Phone2;
            _inputDDLSales.SelectedValue = obj.SalesUserID;
        }

        protected override void update()
        {
            Customer.update(selectedRowID(), _inputTxtName.TextValue, _inputTxtAddress.TextValue, (Guid)_inputDDLCities.SelectedValue, (Guid?)_inputDDLTransports.SelectedValue, _inputTxtPhone1.TextValue, _inputTxtPhone2.TextValue, _inputTxtNotes.TextValue, (Guid?)_inputDDLSales.SelectedValue);
        }

        protected override void add()
        {
            Customer.add(_inputTxtName.TextValue, _inputTxtAddress.TextValue, (Guid)_inputDDLCities.SelectedValue, (Guid?)_inputDDLTransports.SelectedValue, _inputTxtPhone1.TextValue, _inputTxtPhone2.TextValue, _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && Customer.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && Customer.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");
            else if (_inputDDLCities.SelectedValue == null)
                return _inputDDLCities.SelectedValueError("Please select a state listed in the drop down list");
            //else if (Mode == FormMode.Update && _inputDDLSales.SelectedValue == null)
            //    return _inputDDLSales.SelectedValueError("Please select a sales person listed in the drop down list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            Customer.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id) { }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void lnkUpdateCity_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.Cities_Form(FormMode.New));
            City.populateDropDownList(_inputDDLCities.Dropdownlist, false, true); 

        }

        private void lnkUpdateTransports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.Transports_Form(FormMode.New));
            Transport.populateDropDownList(_inputDDLTransports.Dropdownlist, false, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
