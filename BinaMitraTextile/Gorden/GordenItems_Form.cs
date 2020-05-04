using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;
using LIBUtil;

namespace BinaMitraTextile.Gorden
{
    public class GordenItems_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "BAHAN GORDEN";
        private const int FORM_MINIMUMWIDTH = 1100;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputTextbox _inputTxtName;
        private InputEnumDropdownlist _inputDDLCategories;
        private InputDropdownlist _inputDDLVendors;
        private InputDropdownlist _inputDDLProductWidths;
        private InputDropdownlist _inputDDLRetailLengthUnits;
        private InputDropdownlist _inputDDLBulkLengthUnits;
        private InputTextbox _inputTxtBuyRetailPricePerUnit;
        private InputTextbox _inputTxtBuyBulkPricePerUnit;
        private InputTextbox _inputTxtSellRetailPricePerUnit;
        private InputTextbox _inputTxtSellBulkPricePerUnit;
        private InputTextbox _inputTxtNotes;

        private GordenItemCategories? _category;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public GordenItems_Form(FormMode startingMode, GordenItemCategories? category)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH)
        {
            _category = category;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            //disableFieldActive();
            DoNotClearInputAfterSubmission = true;

            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = GordenItem.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;

            //Field Name - textbox
            _inputTxtName = (InputTextbox)setupInputControl(new InputTextbox(), 0, "Name", GordenItem.COL_DB_NAME, false);
            _inputTxtName.setMaxLength(50); //set max length
            col_grid_name.DataPropertyName = GordenItem.COL_DB_NAME; //set field's data property name in gridview

            //Field Categories - dropdownlist
            _inputDDLCategories = (InputEnumDropdownlist)setupInputControl(new InputEnumDropdownlist(), 0, "Category", GordenItem.COL_CATEGORYNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            Tools.populateDropDownList(_inputDDLCategories.Dropdownlist, typeof(GordenItemCategories));

            //Field Vendor - dropdownlist
            _inputDDLVendors = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Vendor", GordenItem.COL_VENDORNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLVendors.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateVendors_LinkClicked); //add event handler for update link
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, false); //populate

            //Field Product Width - dropdownlist
            _inputDDLProductWidths = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Lebar cm", GordenItem.COL_PRODUCTWIDTHNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLProductWidths.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateProductWidths_LinkClicked); //add event handler for update link
            ProductWidth.populateDropDownList(_inputDDLProductWidths.Dropdownlist, false, false); //populate

            //Field Retail Length Units - dropdownlist
            _inputDDLRetailLengthUnits = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Retail Unit", GordenItem.COL_RETAILLENGTHUNITNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLRetailLengthUnits.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateLengthUnits_LinkClicked); //add event handler for update link
            LengthUnit.populateDropDownList(_inputDDLRetailLengthUnits.Dropdownlist, false, false); //populate

            //Field Buy Retail Price - textbox
            _inputTxtBuyRetailPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Buy Retail", GordenItem.COL_DB_BUYRETAILPRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, "N2");
            _inputTxtBuyRetailPricePerUnit.setMaxLength(10); //set max length

            //Field Sell Retail Price - textbox
            _inputTxtSellRetailPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Sell Retail", GordenItem.COL_DB_SELLRETAILPRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, "N2");
            _inputTxtSellRetailPricePerUnit.setMaxLength(10); //set max length

            //Field Bulk Length Units - dropdownlist
            _inputDDLBulkLengthUnits = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Roll Unit", GordenItem.COL_BULKLENGTHUNITNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLBulkLengthUnits.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateLengthUnits_LinkClicked); //add event handler for update link
            LengthUnit.populateDropDownList(_inputDDLBulkLengthUnits.Dropdownlist, false, false); //populate

            //Field Buy Bulk Price - textbox
            _inputTxtBuyBulkPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Buy Roll", GordenItem.COL_DB_BUYBULKPRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, "N2");
            _inputTxtBuyBulkPricePerUnit.setMaxLength(10); //set max length

            //Field Sell Bulk Price - textbox
            _inputTxtSellBulkPricePerUnit = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Sell Roll", GordenItem.COL_DB_SELLBULKPRICEPERUNIT, (int)MasterDataColumnWidth.Fit, true, false, "N2");
            _inputTxtSellBulkPricePerUnit.setMaxLength(10); //set max length

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", GordenItem.COL_DB_NOTES, 100, true, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(100); //set max length

            //set default control to focus
            DefaultInputToFocus = _inputTxtName;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                _inputTxtBuyRetailPricePerUnit.Visible = false;
                gridview.Columns[GordenItem.COL_DB_BUYRETAILPRICEPERUNIT].Visible = false;
                _inputTxtBuyBulkPricePerUnit.Visible = false;
                gridview.Columns[GordenItem.COL_DB_BUYBULKPRICEPERUNIT].Visible = false;
                _inputTxtSellRetailPricePerUnit.Visible = false;
                gridview.Columns[GordenItem.COL_DB_SELLRETAILPRICEPERUNIT].Visible = false;
            }
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return GordenItem.get(chkIncludeInactive.Checked, null, null, null, null, null, null, _category).DefaultView;
        }

        protected override void populateInputFields()
        {
            GordenItem obj = new GordenItem(selectedRowID());
            _inputTxtName.TextValue = obj.Name;
            _inputDDLCategories.SelectedValue = obj.CategoryEnumID;
            _inputDDLVendors.SelectedValue = obj.VendorID;
            _inputDDLProductWidths.SelectedValue = obj.ProductWidthID;
            _inputDDLRetailLengthUnits.SelectedValue = obj.RetailLengthUnitID;
            _inputDDLBulkLengthUnits.SelectedValue = obj.BulkLengthUnitID;
            _inputTxtBuyRetailPricePerUnit.TextValue = obj.BuyRetailPricePerUnit.ToString("N2");
            _inputTxtBuyBulkPricePerUnit.TextValue = obj.BuyBulkPricePerUnit.ToString("N2");
            _inputTxtSellRetailPricePerUnit.TextValue = obj.SellRetailPricePerUnit.ToString("N2");
            _inputTxtSellBulkPricePerUnit.TextValue = obj.SellBulkPricePerUnit.ToString("N2");
            _inputTxtNotes.TextValue = obj.Notes;
        }

        protected override void update()
        {
            GordenItem.update(selectedRowID(), _inputTxtName.TextValue, Tools.parseEnum<GordenItemCategories>(_inputDDLCategories.SelectedValue),
                (Guid)_inputDDLVendors.SelectedValue, (Guid)_inputDDLRetailLengthUnits.SelectedValue, (Guid)_inputDDLBulkLengthUnits.SelectedValue, (Guid?)_inputDDLProductWidths.SelectedValue,
                Tools.zeroNonNumericString(_inputTxtBuyRetailPricePerUnit.TextValue), Tools.zeroNonNumericString(_inputTxtBuyBulkPricePerUnit.TextValue), 
                Tools.zeroNonNumericString(_inputTxtSellRetailPricePerUnit.TextValue), Tools.zeroNonNumericString(_inputTxtSellBulkPricePerUnit.TextValue), _inputTxtNotes.TextValue);
        }

        protected override void add()
        {
            GordenItem.add(_inputTxtName.TextValue, Tools.parseEnum<GordenItemCategories>(_inputDDLCategories.SelectedValue),
                (Guid)_inputDDLVendors.SelectedValue, (Guid)_inputDDLRetailLengthUnits.SelectedValue, (Guid)_inputDDLBulkLengthUnits.SelectedValue, (Guid?)_inputDDLProductWidths.SelectedValue,
                Tools.zeroNonNumericString(_inputTxtBuyRetailPricePerUnit.TextValue), Tools.zeroNonNumericString(_inputTxtBuyBulkPricePerUnit.TextValue),
                Tools.zeroNonNumericString(_inputTxtSellRetailPricePerUnit.TextValue), Tools.zeroNonNumericString(_inputTxtSellBulkPricePerUnit.TextValue), _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (string.IsNullOrEmpty(_inputTxtName.TextValue))
                return _inputTxtName.TextError("Please provide name");
            else if ((Mode != FormMode.Update && GordenItem.isNameExist(_inputTxtName.TextValue, null))
                || (Mode == FormMode.Update && GordenItem.isNameExist(_inputTxtName.TextValue, selectedRowID())))
                return _inputTxtName.TextError("Name is already in the list");
            else if (_inputDDLCategories.SelectedValue == null)
                return _inputDDLCategories.SelectedValueError("Please select category");
            else if (_inputDDLVendors.SelectedValue == null)
                return _inputDDLVendors.SelectedValueError("Please select vendor");
            else if (_inputDDLRetailLengthUnits.SelectedValue == null)
                return _inputDDLRetailLengthUnits.SelectedValueError("Please select retail unit");
            else if (_inputDDLBulkLengthUnits.SelectedValue == null)
                return _inputDDLBulkLengthUnits.SelectedValueError("Please select bulk unit");
            else if (!string.IsNullOrWhiteSpace(_inputTxtBuyRetailPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtBuyRetailPricePerUnit.TextValue))
                return _inputTxtBuyRetailPricePerUnit.TextError("Invalid Buy Retail Price Per Unit");
            else if (!string.IsNullOrWhiteSpace(_inputTxtBuyBulkPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtBuyBulkPricePerUnit.TextValue))
                return _inputTxtBuyBulkPricePerUnit.TextError("Invalid Buy Bulk Price Per Unit");
            else if (!string.IsNullOrWhiteSpace(_inputTxtSellRetailPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtSellRetailPricePerUnit.TextValue))
                return _inputTxtSellRetailPricePerUnit.TextError("Invalid Sell Retail Price Per Unit");
            else if (!string.IsNullOrWhiteSpace(_inputTxtSellBulkPricePerUnit.TextValue) && !Tools.isNumeric(_inputTxtSellBulkPricePerUnit.TextValue))
                return _inputTxtSellBulkPricePerUnit.TextError("Invalid Sell Bulk Price Per Unit");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            GordenItem.updateActiveStatus(id, activeStatus);
        }

        protected override void updateDefaultRow(Guid id) { }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void lnkUpdateLengthUnits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.LengthUnits_Form(FormMode.New));
            LengthUnit.populateDropDownList(_inputDDLRetailLengthUnits.Dropdownlist, false, true);
            LengthUnit.populateDropDownList(_inputDDLBulkLengthUnits.Dropdownlist, false, true);
        }

        private void lnkUpdateVendors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Vendors_Form(FormModes.Add));
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, true);
        }

        private void lnkUpdateProductWidths_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.ProductWidths_Form(FormMode.New));
            ProductWidth.populateDropDownList(_inputDDLProductWidths.Dropdownlist, false, true);
        }
        
        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
