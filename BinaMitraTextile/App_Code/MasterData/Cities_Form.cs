using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class Cities_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "CITIES";
        private const int FORM_MINIMUMWIDTH = 400;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;
        private InputDropdownlist _inputDDLStates;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Cities_Form(FormMode startingMode)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH) 
        {
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = City.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;

            //Field Active
            col_grid_active.Visible = true;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", City.COL_DB_NAME, false);
            _inputTxtName.setMaxLength(50); //set max length
            col_grid_name.DataPropertyName = City.COL_DB_NAME; //set field's data property name in gridview

            //Field State - dropdownlist
            _inputDDLStates = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "State", City.COL_STATENAME, -1, true, false, null);
            _inputDDLStates.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateStates_LinkClicked); //add event handler for update link
            State.populateDropDownList(_inputDDLStates.Dropdownlist, false, true); //populate

            //set default control to focus
            DefaultInputToFocus = _inputTxtName;
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            if (!_inputDDLStates.isValidSelectedValue())
                return false;

            return true; 
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return City.getByFilter(chkIncludeInactive.Checked, _inputTxtName.TextValue, _inputDDLStates.SelectedValue).DefaultView;
        }
        
        protected override void populateInputFields()
        {
            City obj = new City(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
            _inputDDLStates.SelectedValue = obj.StateID;
        }

        protected override void update()
        {
            City.update(selectedRowID(), _inputTxtName.TextValue, (Guid)_inputDDLStates.SelectedValue);
        }

        protected override void add()
        {
            City.add(_inputTxtName.TextValue, (Guid)_inputDDLStates.SelectedValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && City.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && City.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");
            else if (_inputDDLStates.SelectedValue == null)
                return _inputDDLStates.SelectedValueError("Please select a state listed in the drop down list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            City.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id) { }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void lnkUpdateStates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.States_Form(FormMode.New));
            State.populateDropDownList(_inputDDLStates.Dropdownlist, false, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
