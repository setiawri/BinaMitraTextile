using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class PettyCashRecordsCategories_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "PETTY CASH CATEGORIES";
        private const int FORM_MINIMUMWIDTH = 400;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;
        private InputTextbox _inputTxtNotes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public PettyCashRecordsCategories_Form(FormMode startingMode)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH) 
        {
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = PettyCashRecordsCategory.COL_DB_Id;

            //Field Default
            col_grid_default.Visible = true;

            //Field Active
            col_grid_active.Visible = true;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", PettyCashRecordsCategory.COL_DB_Name, false);
            _inputTxtName.setMaxLength(50); //set max length
            col_grid_name.DataPropertyName = PettyCashRecordsCategory.COL_DB_Name; //set field's data property name in gridview

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", PettyCashRecordsCategory.COL_DB_Notes, 100, true, true, null);
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
            return PettyCashRecordsCategory.get(chkIncludeInactive.Checked, null, _inputTxtName.TextValue).DefaultView;
        }
        
        protected override void populateInputFields()
        {
            PettyCashRecordsCategory obj = new PettyCashRecordsCategory(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
        }

        protected override void update()
        {
            PettyCashRecordsCategory.update(selectedRowID(), _inputTxtName.TextValue, _inputTxtNotes.TextValue);
        }

        protected override void add()
        {
            PettyCashRecordsCategory.add(_inputTxtName.TextValue, _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && PettyCashRecordsCategory.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && PettyCashRecordsCategory.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            PettyCashRecordsCategory.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id)
        {
            PettyCashRecordsCategory.updateDefaultRow(id);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
