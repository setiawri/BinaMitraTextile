using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class Transports_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "ANGKUTAN";
        private const int FORM_MINIMUMWIDTH = 650;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;
        private InputTextbox _inputTxtPhone1;
        private InputTextbox _inputTxtPhone2;
        private InputTextbox _inputTxtAddress;
        private InputTextbox _inputTxtNotes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Transports_Form(FormMode startingMode)
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
            col_grid_id.DataPropertyName = Transport.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", Transport.COL_DB_NAME, false);
            _inputTxtName.setMaxLength(50); //set max length
            col_grid_name.DataPropertyName = Transport.COL_DB_NAME; //set field's data property name in gridview

            //Field Phone1 - textbox
            _inputTxtPhone1 = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Phone 1", Transport.COL_DB_PHONE1, 0, true, false, null);
            _inputTxtPhone1.setMaxLength(20); //set max length

            //Field Phone2 - textbox
            _inputTxtPhone2 = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Phone 2", Transport.COL_DB_PHONE2, 0, true, false, null);
            _inputTxtPhone2.setMaxLength(20); //set max length

            //Field Address - textbox
            _inputTxtAddress = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Address", Transport.COL_DB_ADDRESS, 100, true, false, null);
            _inputTxtAddress.setToMultiline(4);
            _inputTxtAddress.setMaxLength(100); //set max length

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", Transport.COL_DB_NOTES, 100, true, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(100); //set max length

            //set default control to focus
            DefaultInputToFocus = _inputTxtName;
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return Transport.getByFilter(chkIncludeInactive.Checked, _inputTxtName.TextValue).DefaultView;
        }

        protected override void populateInputFields()
        {
            Transport obj = new Transport(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
            _inputTxtAddress.TextValue = obj.Address;
            _inputTxtNotes.TextValue = obj.Notes;
            _inputTxtPhone1.TextValue = obj.Phone1;
            _inputTxtPhone2.TextValue = obj.Phone2;
        }

        protected override void update()
        {
            Transport.update(selectedRowID(), _inputTxtName.TextValue, _inputTxtAddress.TextValue, _inputTxtPhone1.TextValue, _inputTxtPhone2.TextValue, _inputTxtNotes.TextValue);
        }

        protected override void add()
        {
            Transport.add(_inputTxtName.TextValue, _inputTxtAddress.TextValue, _inputTxtPhone1.TextValue, _inputTxtPhone2.TextValue, _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && Transport.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && Transport.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            Transport.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id) { }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
