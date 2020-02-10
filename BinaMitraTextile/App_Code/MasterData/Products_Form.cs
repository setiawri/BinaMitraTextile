using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

namespace BinaMitraTextile.MasterData
{
    public class Products_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "PRODUCTS";
        private const int FORM_MINIMUMWIDTH = 600;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputDropdownlist _inputDDLStoreNames;
        private InputTextbox _inputTxtNameVendor;
        private InputDropdownlist _inputDDLVendors;
        private InputTextbox _inputTxtPercentageOfPercentCommission;
        private InputTextbox _inputTxtNotes;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Products_Form(FormMode startingMode)
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
            col_grid_id.DataPropertyName = Product.COL_DB_ID;

            //Field Active
            col_grid_active.Visible = true;

            //Field Default
            col_grid_default.Visible = false;


            //Field Name/Store - dropdownlist
            _inputDDLStoreNames = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Name (Store)", Product.COL_STORENAME, 0, true, false, null);
            _inputDDLStoreNames.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateProductStoreNames_LinkClicked); //add event handler for update link
            ProductStoreName.populateDropDownList(_inputDDLStoreNames.Dropdownlist, false, true); //populate

            //Field Name/Vendor - textbox
            _inputTxtNameVendor = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name (Vendor)", Product.COL_DB_NAMEVENDOR, false);
            _inputTxtNameVendor.setMaxLength(20); //set max length
            col_grid_name.DataPropertyName = Product.COL_DB_NAMEVENDOR; //set field's data property name in gridview
            col_grid_name.HeaderText = "Name (Vendor)";

            //Field Vendor - dropdownlist
            _inputDDLVendors = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Vendor", Product.COL_VENDORNAME, 0, true, false, null);
            _inputDDLVendors.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateVendors_LinkClicked); //add event handler for update link
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, true); //populate

            //Field Percentage of Percent Commission - textbox
            _inputTxtPercentageOfPercentCommission = (InputTextbox)setupInputControl(new InputTextbox(), 0, "% Of %", Product.COL_DB_PercentageOfPercentCommission, 50, true, true, "N2");
            _inputTxtPercentageOfPercentCommission.setMaxLength(5); //set max length

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Notes", Product.COL_DB_NOTES, 100, true, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(100); //set max length
            gridview.Columns[Product.COL_DB_NOTES].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //set default control to focus
            DefaultInputToFocus = _inputTxtNameVendor;
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            if (!_inputDDLVendors.isValidSelectedValue())
                return false;
            else if (!_inputDDLStoreNames.isValidSelectedValue())
                return false;

            return true; 
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return Product.get(chkIncludeInactive.Checked, _inputDDLStoreNames.SelectedValue, _inputTxtNameVendor.TextValue, _inputDDLVendors.SelectedValue).DefaultView;
        }
        
        protected override void populateInputFields()
        {
            Product obj = new Product(selectedRowID());
            _inputDDLStoreNames.SelectedValue = obj.StoreNameID;
            _inputTxtNameVendor.TextValue = obj.NameVendor;
            _inputDDLVendors.SelectedValue = obj.VendorID;
            _inputTxtPercentageOfPercentCommission.TextValue = obj.PercentageOfPercentCommission.ToString("N2");
            _inputTxtNotes.TextValue = obj.Notes;
        }

        protected override void update()
        {
            Product.update(selectedRowID(), (Guid)_inputDDLStoreNames.SelectedValue, _inputTxtNameVendor.TextValue, (Guid)_inputDDLVendors.SelectedValue, LIBUtil.Util.zeroNonNumericString(_inputTxtPercentageOfPercentCommission.TextValue), null, _inputTxtNotes.TextValue);
        }

        protected override void add()
        {
            Product.add((Guid)_inputDDLStoreNames.SelectedValue, _inputTxtNameVendor.TextValue, (Guid)_inputDDLVendors.SelectedValue, LIBUtil.Util.zeroNonNumericString(_inputTxtPercentageOfPercentCommission.TextValue), null, _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtNameVendor.TextValue))
                return _inputTxtNameVendor.TextError("Please provide name (vendor)");
            else if (_inputDDLStoreNames.SelectedValue == null)
                return _inputDDLStoreNames.SelectedValueError("Please select a name (store) listed in the drop down list");
            else if (_inputDDLVendors.SelectedValue == null)
                return _inputDDLVendors.SelectedValueError("Please select a vendor listed in the drop down list");
            else if ((Mode != FormMode.Update && Product.isNameCombinationExist((Guid)_inputDDLStoreNames.SelectedValue, _inputTxtNameVendor.TextValue, (Guid)_inputDDLVendors.SelectedValue, null))
                || (Mode == FormMode.Update && Product.isNameCombinationExist((Guid)_inputDDLStoreNames.SelectedValue, _inputTxtNameVendor.TextValue, (Guid)_inputDDLVendors.SelectedValue, selectedRowID())))
                return _inputDDLStoreNames.SelectedValueError("Name (store) combination with name (vendor) is already in the list");
            else if (_inputTxtPercentageOfPercentCommission.isEmpty() || !LIBUtil.Util.isNumeric(_inputTxtPercentageOfPercentCommission.TextValue))
                return _inputTxtPercentageOfPercentCommission.TextError("Invalid number");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            Product.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id) { }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void lnkUpdateProductStoreNames_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.ProductStoreNames_Form(FormMode.New));
            ProductStoreName.populateDropDownList(_inputDDLStoreNames.Dropdownlist, false, true);
        }

        private void lnkUpdateVendors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.Vendors_Form(FormMode.New));
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
