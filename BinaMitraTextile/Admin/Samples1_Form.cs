using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;
using BinaMitraTextile.MasterData;
using System.Data;

namespace BinaMitraTextile.Admin
{
    public class Samples1_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "SAMPLES";
        private const int FORM_MINIMUMWIDTH = 900;
        private const bool FORM_SHOWDATAONLOAD = false;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtSampleNo;
        private InputTextbox _inputTxtStorageName;
        private InputTextbox _inputTxtVendorName;
        private InputTextbox _inputTxtVendorInfo;
        private InputTextbox _inputTxtDescription;
        private InputDateTimePicker _inputDtpPriceDate;
        private InputTextbox _inputTxtPricePerUnit;
        private InputTextbox _inputTxtSellPricePerUnit;
        private InputDropdownlist _inputDDLLengthUnits;
        private InputDateTimePicker _inputDtpDiscontinueDate;
        private InputTextbox _inputTxtNotes;
        
        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Samples1_Form(FormMode startingMode)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH) 
        {
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            col_grid_name.Visible = false;
            disableFieldActive();
            //DoNotClearInputAfterSubmission = true;

            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = Sample.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;

            //Field Sample No - textbox
            _inputTxtSampleNo = (InputTextbox)setupInputControl(new InputTextbox(), 0, "No", Sample.COL_DB_SAMPLENO, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtSampleNo.Enabled = false;

            //Field Storage Name - textbox
            _inputTxtStorageName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Loc", Sample.COL_DB_STORAGENAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtStorageName.setMaxLength(30); //set max length

            //Field Description - textbox
            _inputTxtDescription = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Description", Sample.COL_DB_DESCRIPTION, (int)MasterDataColumnWidth.Fill, true, false, null);
            _inputTxtDescription.setToMultiline(4);
            Tools.setGridviewColumnWordwrap(gridview.Columns["Description"]);

            //Field Discontinue Date - textbox
            _inputDtpDiscontinueDate = (InputDateTimePicker)setupInputControl(new InputDateTimePicker(true), 1, "Discontinue Date", Sample.COL_DB_DISCONTINUEDATE, (int)MasterDataColumnWidth.Fit, true, true, null);
            _inputDtpDiscontinueDate.SetFormat = "ddd, dd/MM/yy";

            //Field Price Date - textbox
            _inputDtpPriceDate = (InputDateTimePicker)setupInputControl(new InputDateTimePicker(true), 1, "Price Date", Sample.COL_DB_PRICEDATE, (int)MasterDataColumnWidth.Fit, true, true, null);
            _inputDtpPriceDate.SetFormat = "ddd, dd/MM/yy";

            //Field Price Per Unit - textbox
            _inputTxtPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Buy Price/Unit", Sample.COL_DB_PRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtPricePerUnit.setMaxLength(10); //set max length

            //Field Length Units - dropdownlist
            _inputDDLLengthUnits = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Unit", Sample.COL_LENGTHUNITNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLLengthUnits.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateLengthUnits_LinkClicked); //add event handler for update link
            LengthUnit.populateDropDownList(_inputDDLLengthUnits.Dropdownlist, false, true); //populate

            //Field Sell Price Per Unit - textbox
            _inputTxtSellPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Sell Price/Unit", Sample.COL_DB_SELLPRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtSellPricePerUnit.setMaxLength(10); //set max length

            //Field Vendor Name - textbox
            _inputTxtVendorName = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Vendor Name", Sample.COL_DB_VENDORNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtVendorName.setMaxLength(30); //set max length
            gridview.Columns[2].Visible = false;

            //Field Vendor Info - textbox
            _inputTxtVendorInfo = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Vendor Info", Sample.COL_DB_VENDORINFO, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtVendorInfo.setToMultiline(4);

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", Sample.COL_DB_NOTES, 100, false, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(300); //set max length
            Tools.setGridviewColumnWordwrap(gridview.Columns["Notes"]);

            //set default control to focus
            DefaultInputToFocus = _inputTxtStorageName;

            clearInputFields(); //clear dropdownlists

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                _inputDtpPriceDate.Visible = false;
                _inputTxtPricePerUnit.Visible = false;
                _inputTxtNotes.Visible = false;
                _inputTxtVendorInfo.Visible = false;
                gridview.Columns[Sample.COL_DB_PRICEDATE].Visible = false;
                gridview.Columns[Sample.COL_DB_PRICEPERUNIT].Visible = false;
                gridview.Columns[Sample.COL_DB_NOTES].Visible = false;
                gridview.Columns[Sample.COL_DB_VENDORINFO].Visible = false;
            }
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true; 
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormMode.New)
                return Sample.get(null, null, null, null).DefaultView;
            else
                return Sample.get(_inputTxtStorageName.TextValue, _inputTxtVendorName.TextValue, _inputTxtVendorInfo.TextValue, _inputTxtDescription.TextValue).DefaultView;
        }
        
        protected override void populateInputFields()
        {
            Sample obj = new Sample(selectedRowID());
            _inputTxtSampleNo.TextValue = obj.SampleNo.ToString();
            _inputTxtStorageName.TextValue = obj.StorageName;
            _inputTxtVendorName.TextValue = obj.VendorName;
            _inputTxtVendorInfo.TextValue = obj.VendorInfo;
            _inputTxtDescription.TextValue = obj.Description;
            _inputTxtSellPricePerUnit.TextValue = Tools.zeroNonNumericString(obj.SellPricePerUnit).ToString();
            _inputDDLLengthUnits.SelectedValue = obj.LengthUnitID;
            _inputDtpPriceDate.Value = obj.PriceDate;
            _inputTxtPricePerUnit.TextValue = string.Format("{0:N2}", obj.PricePerUnit);
            _inputDtpDiscontinueDate.Value = obj.DiscontinueDate;
            _inputTxtNotes.TextValue = obj.Notes;
        }

        protected override void update()
        {
            Sample.update(selectedRowID(), _inputTxtStorageName.TextValue, _inputTxtVendorName.TextValue, _inputTxtVendorInfo.TextValue, _inputTxtDescription.TextValue, 
                _inputDtpPriceDate.Value, DBUtil.parseData<decimal?>(_inputTxtPricePerUnit.TextValue), _inputDtpDiscontinueDate.Value, _inputTxtNotes.TextValue, 
                _inputDDLLengthUnits.SelectedValue, DBUtil.parseData<decimal?>(_inputTxtSellPricePerUnit.TextValue));
        }

        protected override void add()
        {
            Sample.add(_inputTxtStorageName.TextValue, _inputTxtVendorName.TextValue, _inputTxtVendorInfo.TextValue, _inputTxtDescription.TextValue,
                _inputDtpPriceDate.Value, DBUtil.parseData<decimal?>(_inputTxtPricePerUnit.TextValue), _inputDtpDiscontinueDate.Value, _inputTxtNotes.TextValue,
                _inputDDLLengthUnits.SelectedValue, DBUtil.parseData<decimal?>(_inputTxtSellPricePerUnit.TextValue));
        }

        protected override Boolean isInputFieldsValid()
        {
            if (_inputTxtStorageName.isEmpty())
                return _inputTxtStorageName.TextError("Please enter storage name");
            else if (_inputTxtVendorName.isEmpty())
                return _inputTxtVendorName.TextError("Please enter vendor name");
            else if (_inputTxtDescription.isEmpty())
                return _inputTxtDescription.TextError("Please enter description");
            else if (!string.IsNullOrWhiteSpace(_inputTxtPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtPricePerUnit.TextValue))
                return _inputTxtPricePerUnit.TextError("Invalid Buy Price Per Unit");
            else if (!string.IsNullOrWhiteSpace(_inputTxtSellPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtSellPricePerUnit.TextValue))
                return _inputTxtSellPricePerUnit.TextError("Invalid Sell Price Per Unit");

            return true;
        }

        protected override void showUserHiddenControls()
        {
            gridview.Columns[2].Visible = !gridview.Columns[2].Visible;
            base.showUserHiddenControls();
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void lnkUpdateLengthUnits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.LengthUnits_Form(FormMode.New));
            LengthUnit.populateDropDownList(_inputDDLLengthUnits.Dropdownlist, false, true);
        }
        
        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
