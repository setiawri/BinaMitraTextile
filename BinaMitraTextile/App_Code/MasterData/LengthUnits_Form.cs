using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class LengthUnits_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "SATUAN";
        private const int FORM_MINIMUMWIDTH = 400;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public LengthUnits_Form(FormMode startingMode)
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
            col_grid_id.DataPropertyName = LengthUnit.COL_DB_ID;

            //Field Active
            col_grid_active.Visible = true;

            //Field Default
            col_grid_default.Visible = true;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", LengthUnit.COL_DB_NAME, false);
            _inputTxtName.setMaxLength(20); //set max length
            col_grid_name.DataPropertyName = LengthUnit.COL_DB_NAME; //set field's data property name in gridview

            //set default control to focus
            DefaultInputToFocus = _inputTxtName;
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true; 
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return LengthUnit.getByFilter(chkIncludeInactive.Checked, _inputTxtName.TextValue).DefaultView;
        }
        
        protected override void populateInputFields()
        {
            LengthUnit obj = new LengthUnit(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
        }

        protected override void update()
        {
            LengthUnit.update(selectedRowID(), _inputTxtName.TextValue);
        }

        protected override void add()
        {
            LengthUnit.add(_inputTxtName.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && LengthUnit.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && LengthUnit.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            LengthUnit.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id)
        {
            LengthUnit.updateDefaultRow(id);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
