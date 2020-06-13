using System;
using System.Collections.Generic;

using System.Windows.Forms;
using BinaMitraTextile.UserControls;

using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public class StockLevel_Form : MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string FORM_TITLE = "STOCK LEVEL INVENTORY";
        private const int FORM_MINIMUMWIDTH = 900;
        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        //INPUT FIELDS
        private InputDropdownlist _inputDDLVendors;
        private InputDropdownlist _inputDDLProducts;
        private InputDropdownlist _inputDDLGrades;
        private InputDropdownlist _inputDDLProductWidths;
        private InputDropdownlist _inputDDLLengthUnits;
        private InputDropdownlist _inputDDLColors;
        private InputTextbox _inputTxtQty;
        private InputTextbox _inputTxtOrderLotQty;
        private InputTextbox _inputTxtNotes;
        private InputTextbox _inputTxtPONotes;

        public DataGridViewColumn col_grid_newQty;
        public DataGridViewColumn col_grid_remainingQty;
        public DataGridViewColumn col_grid_orderQty;
        public DataGridViewColumn col_grid_bookedQty;
        public DataGridViewColumn col_grid_lastOrderInventoryID;
        public DataGridViewColumn col_grid_lastOrderTimestamp;

        private Dictionary<Guid, int> _orderQty = new Dictionary<Guid, int>();

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public StockLevel_Form(FormMode startingMode)
            : base(FORM_TITLE, startingMode, FORM_SHOWDATAONLOAD, FORM_MINIMUMWIDTH) 
        {
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            DoNotClearInputAfterSubmission = true;

            col_grid_name.Visible = false;
            disableFieldActive();

            btnAction1.Enabled = true;
            btnAction1.Text = "DELETE";
            btnAction1.Width = 100;

            btnAction2.Enabled = true;
            btnAction2.Text = "CLEAR QTY";
            btnAction2.Width = 100;

            btnAction3.Enabled = true;
            btnAction3.Text = "CREATE PO";
            btnAction3.Width = 100;

            btnAction4.Enabled = true;
            btnAction4.Text = "HIDE COLUMNS";
            btnAction4.Width = 120;

            btnAction5.Enabled = true;
            btnAction5.Text = "-";
            btnAction5.Width = 30;

            btnAction6.Enabled = true;
            btnAction6.Text = "+";
            btnAction6.Width = 30;

            //NOTES: must use inputColumns sequentially from the first one to the next. Otherwise calculation of the form width will be off

            //Field ID
            col_grid_id.DataPropertyName = InventoryStockLevel.COL_DB_ID;

            //Field Default
            col_grid_default.Visible = false;


            //Filter Vendor - dropdownlist
            _inputDDLVendors = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Vendor", InventoryStockLevel.COL_VENDORNAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, true); //populate
            _inputDDLVendors.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateVendors_LinkClicked); //add event handler for update link
            _inputDDLVendors.Dropdownlist.SelectedIndexChanged += new System.EventHandler(this.cbVendors_SelectedIndexChanged);
            _inputDDLVendors.Dropdownlist.TextChanged += new System.EventHandler(this.cbVendors_TextChanged);

            //Field Name/Store - dropdownlist
            _inputDDLProducts = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Product", InventoryStockLevel.COL_PRODUCTSTORENAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLProducts.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateProducts_LinkClicked); //add event handler for update link
            _inputDDLProducts.Enabled = false;

            //Field Grades - dropdownlist
            _inputDDLGrades = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Grade", InventoryStockLevel.COL_GRADE_NAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLGrades.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateGrades_LinkClicked); //add event handler for update link
            Grade.populateDropDownList(_inputDDLGrades.Dropdownlist, false, true); //populate

            //Field Product Widths - dropdownlist
            _inputDDLProductWidths = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 0, "Lebar", InventoryStockLevel.COL_PRODUCT_WIDTH_NAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLGrades.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateProductWidths_LinkClicked); //add event handler for update link
            ProductWidth.populateDropDownList(_inputDDLProductWidths.Dropdownlist, false, true); //populate

            //Field Color - dropdownlist
            _inputDDLColors = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Color", InventoryStockLevel.COL_COLOR_NAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLColors.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateColors_LinkClicked); //add event handler for update link
            FabricColor.populateDropDownList(_inputDDLColors.Dropdownlist, false, true); //populate

            //Field Length Units - dropdownlist
            _inputDDLLengthUnits = (InputDropdownlist)setupInputControl(new InputDropdownlist(), 1, "Unit", InventoryStockLevel.COL_LENGTH_UNIT_NAME, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputDDLLengthUnits.UpdateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkUpdateLengthUnits_LinkClicked); //add event handler for update link
            LengthUnit.populateDropDownList(_inputDDLLengthUnits.Dropdownlist, false, true); //populate

            //Field Lot Qty - textbox
            _inputTxtOrderLotQty = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Lot Qty", InventoryStockLevel.COL_DB_ORDERLOTQTY, (int)MasterDataColumnWidth.Fit, true, false, null);
            _inputTxtOrderLotQty.setMaxLength(5); //set max length

            //Field Qty - textbox
            _inputTxtQty = (InputTextbox)setupInputControl(new InputTextbox(), 1, "Min Qty", InventoryStockLevel.COL_DB_QTY, 40, true, false, null);
            _inputTxtQty.setMaxLength(5); //set max length

            //add columns
            col_grid_remainingQty = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_remainingQty", "Stock", InventoryStockLevel.COL_REMAININGSTOCKQTY, 40, true, null); //add field to gridview
            col_grid_bookedQty = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_bookedQty", "Booked", InventoryStockLevel.COL_BOOKEDQTY, 50, true, null); //add field to gridview
            col_grid_orderQty = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_orderQty", "Pending", InventoryStockLevel.COL_PENDINGDELIVERYQTY, 50, true, null); //add field to gridview
            col_grid_newQty = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_newQty", "Order", InventoryStockLevel.COL_NEWORDER_QTY, 40, false, null); //add field to gridview
            col_grid_lastOrderInventoryID = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_referencedInventoryID", "", InventoryStockLevel.COL_LASTORDERINVENTORYID, 40, true, null); //add field to gridview
            col_grid_lastOrderInventoryID.Visible = false;
            col_grid_lastOrderTimestamp = Tools.addColumn<DataGridViewTextBoxCell>(gridview, "col_grid_lastOrderTimestamp", "", InventoryStockLevel.COL_LASTORDERTIMESTAMP, 40, true, null); //add field to gridview
            col_grid_lastOrderTimestamp.Visible = false;

            //Field PO Notes - textbox
            _inputTxtPONotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "PO Notes", InventoryStockLevel.COL_DB_PONOTES, (int)MasterDataColumnWidth.Fit, false, true, null);
            _inputTxtPONotes.setToMultiline(4);
            _inputTxtPONotes.setMaxLength(50); //set max length

            //Field Notes - textbox
            _inputTxtNotes = (InputTextbox)setupInputControl(new InputTextbox(), 2, "Notes", InventoryStockLevel.COL_DB_NOTES, 100, false, true, null);
            _inputTxtNotes.setToMultiline(4);
            _inputTxtNotes.setMaxLength(100); //set max length
            gridview.Columns[InventoryStockLevel.COL_DB_NOTES].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //set default control to focus
            DefaultInputToFocus = _inputDDLVendors;

            clearInputFields(); //clear dropdownlists

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                btnAction1.Enabled = false;
                btnAction3.Enabled = false;
                gridview.Columns[InventoryStockLevel.COL_DB_PONOTES].Visible = false;
            }
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            if (!_inputDDLVendors.isValidSelectedValue())
                return false;
            else if (!_inputDDLGrades.isValidSelectedValue())
                return false;
            else if (!_inputDDLProducts.isValidSelectedValue())
                return false;
            else if (!_inputDDLProductWidths.isValidSelectedValue())
                return false;
            else if (!_inputDDLLengthUnits.isValidSelectedValue())
                return false;
            else if (!_inputDDLColors.isValidSelectedValue())
                return false;

            return true; 
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            if (Mode == FormMode.New)
                return InventoryStockLevel.getAll(null,null,null,null,null,null,false).DefaultView;
            else
                return InventoryStockLevel.getAll(_inputDDLGrades.SelectedValue, _inputDDLProducts.SelectedValue, _inputDDLProductWidths.SelectedValue,
                    _inputDDLLengthUnits.SelectedValue, _inputDDLColors.SelectedValue, _inputDDLVendors.SelectedValue, false).DefaultView;
        }

        protected override void populateGridViewDataSource(bool reloadFromDB)
        {
            base.populateGridViewDataSource(reloadFromDB);

            if(_orderQty.Count > 0)
                applyOrderQty();
        }

        private void saveOrderQty()
        {
            _orderQty.Clear();
            foreach(DataGridViewRow row in gridview.Rows)
                _orderQty.Add((Guid)row.Cells[col_grid_id.Name].Value, Convert.ToInt32(row.Cells[col_grid_newQty.Name].Value));
        }

        private void saveOrderQty(Guid key, int value)
        {
            _orderQty[key] = value;
        }

        private void applyOrderQty()
        {
            foreach (DataGridViewRow row in gridview.Rows)
                if(_orderQty.ContainsKey((Guid)row.Cells[col_grid_id.Name].Value))
                   row.Cells[col_grid_newQty.Name].Value = _orderQty[(Guid)row.Cells[col_grid_id.Name].Value];
        }

        protected override void populateInputFields()
        {
            InventoryStockLevel obj = new InventoryStockLevel(selectedRowID());
            _inputDDLVendors.SelectedValue = obj.VendorID;
            _inputDDLProducts.SelectedValue = obj.ProductID;
            _inputDDLGrades.SelectedValue = obj.GradeID;
            _inputDDLProductWidths.SelectedValue = obj.ProductWidthID;
            _inputDDLLengthUnits.SelectedValue = obj.LengthUnitID;
            _inputDDLColors.SelectedValue = obj.ColorID;
            _inputTxtOrderLotQty.TextValue = obj.OrderLotQty.ToString();
            _inputTxtQty.TextValue = obj.Qty.ToString();
            _inputTxtPONotes.TextValue = obj.PONotes;
            _inputTxtNotes.TextValue = obj.Notes;
        }

        protected override void update()
        {
            saveOrderQty();
            InventoryStockLevel.update(selectedRowID(), (Guid)_inputDDLGrades.SelectedValue, (Guid)_inputDDLProducts.SelectedValue,(Guid)_inputDDLProductWidths.SelectedValue,
                    (Guid)_inputDDLLengthUnits.SelectedValue, (Guid)_inputDDLColors.SelectedValue, Convert.ToInt32(Tools.zeroNonNumericString(_inputTxtQty.TextValue)),
                    Convert.ToInt32(Tools.zeroNonNumericString(_inputTxtOrderLotQty.TextValue)), _inputTxtPONotes.TextValue, _inputTxtNotes.TextValue);
        }

        protected override void add()
        {
            saveOrderQty();
            InventoryStockLevel.add((Guid)_inputDDLGrades.SelectedValue, (Guid)_inputDDLProducts.SelectedValue,(Guid)_inputDDLProductWidths.SelectedValue,
                    (Guid)_inputDDLLengthUnits.SelectedValue, (Guid)_inputDDLColors.SelectedValue, Convert.ToInt32(Tools.zeroNonNumericString(_inputTxtQty.TextValue)),
                    Convert.ToInt32(Tools.zeroNonNumericString(_inputTxtOrderLotQty.TextValue)), _inputTxtPONotes.TextValue, _inputTxtNotes.TextValue);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (_inputDDLProducts.SelectedValue == null)
                return _inputDDLProducts.SelectedValueError("Please select product");
            else if (_inputDDLGrades.SelectedValue == null)
                return _inputDDLGrades.SelectedValueError("Please select grade");
            else if (_inputDDLProductWidths.SelectedValue == null)
                return _inputDDLProductWidths.SelectedValueError("Please select width");
            else if (_inputDDLLengthUnits.SelectedValue == null)
                return _inputDDLLengthUnits.SelectedValueError("Please select unit");
            else if (_inputDDLColors.SelectedValue == null)
                return _inputDDLColors.SelectedValueError("Please select color");
            else if ((Mode != FormMode.Update && InventoryStockLevel.isCombinationExist(null, (Guid)_inputDDLGrades.SelectedValue, (Guid)_inputDDLProducts.SelectedValue, (Guid)_inputDDLProductWidths.SelectedValue,
                                                                (Guid)_inputDDLLengthUnits.SelectedValue, (Guid)_inputDDLColors.SelectedValue))
                || (Mode == FormMode.Update && InventoryStockLevel.isCombinationExist(selectedRowID(), (Guid)_inputDDLGrades.SelectedValue, (Guid)_inputDDLProducts.SelectedValue, (Guid)_inputDDLProductWidths.SelectedValue,
                                                                (Guid)_inputDDLLengthUnits.SelectedValue, (Guid)_inputDDLColors.SelectedValue)))
                return _inputDDLProducts.SelectedValueError("Combination is already in the list");
            else if (!Tools.isNumeric(_inputTxtOrderLotQty.TextValue))
                return _inputTxtQty.TextError("Invalid qty. Harus lebih dari 0.");
            else if (!string.IsNullOrEmpty(_inputTxtQty.TextValue) && !Tools.isNumeric(_inputTxtQty.TextValue))
                return _inputTxtQty.TextError("Invalid qty");

            return true;
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void executeAction1()
        {
            Tools.hasMessage(InventoryStockLevel.delete(selectedRowID()));
            base.executeAction1();
        }

        protected override void executeAction2()
        {
            foreach(DataGridViewRow row in gridview.Rows)
                row.Cells[col_grid_newQty.Name].Value = 0;

            
            saveOrderQty();
        }

        protected override void executeAction3()
        {
            int qty = 0; 
            Guid id; 
            Guid emptyGuid = new Guid();
            List<POItemToOrder> items = new List<POItemToOrder>();
            foreach (DataGridViewRow row in gridview.Rows)
            {
                qty = (int)Tools.zeroNonNumericString(row.Cells[col_grid_newQty.Name].Value);
                id = Tools.wrapDBNullValue<Guid>(row.Cells[col_grid_lastOrderInventoryID.Name].Value);
                if (id != emptyGuid && qty > 0)
                    items.Add(new POItemToOrder() { InventoryID = id, Qty = qty, PONotes = DBUtil.parseData<string>(row.Cells[InventoryStockLevel.COL_DB_PONOTES].Value) });
            }

            //create PO
            if (items.Count == 0)
                Tools.showError("No item to generate");
            else
                Tools.displayForm(new POs.Add_Edit_Form(items));
        }

        protected override void executeAction4()
        {
            col_grid_newQty.Visible = !col_grid_newQty.Visible;
            col_grid_remainingQty.Visible = !col_grid_remainingQty.Visible;
            gridview.Columns[InventoryStockLevel.COL_DB_QTY].Visible = !gridview.Columns[InventoryStockLevel.COL_DB_QTY].Visible;
            gridview.Columns[InventoryStockLevel.COL_DB_ORDERLOTQTY].Visible = !gridview.Columns[InventoryStockLevel.COL_DB_ORDERLOTQTY].Visible;
            gridview.Columns[InventoryStockLevel.COL_DB_NOTES].Visible = !gridview.Columns[InventoryStockLevel.COL_DB_NOTES].Visible;
            gridview.Columns[InventoryStockLevel.COL_DB_PONOTES].Visible = !gridview.Columns[InventoryStockLevel.COL_DB_PONOTES].Visible;
        }

        protected override void executeAction5()
        {
            int newValue =
                Convert.ToInt32(Util.getSelectedRowValue(gridview, col_grid_newQty)) -
                Convert.ToInt32(Util.getSelectedRowValue(gridview, gridview.Columns[InventoryStockLevel.COL_DB_ORDERLOTQTY]));
            
            if (newValue >= 0)
                Util.setSelectedRowValue(gridview, col_grid_newQty, newValue);

            saveOrderQty((Guid)Util.getSelectedRowValue(gridview, col_grid_id), newValue);
        }

        protected override void executeAction6()
        {
            int newValue =
                Convert.ToInt32(Util.getSelectedRowValue(gridview, col_grid_newQty)) +
                Convert.ToInt32(Util.getSelectedRowValue(gridview, gridview.Columns[InventoryStockLevel.COL_DB_ORDERLOTQTY]));

            if (newValue >= 0)
                Util.setSelectedRowValue(gridview, col_grid_newQty, newValue);

            saveOrderQty((Guid)Util.getSelectedRowValue(gridview, col_grid_id), newValue);
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void cbVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inputDDLVendors.Dropdownlist.SelectedIndex > -1)
            {
                Product.populateDropDownList(_inputDDLProducts.Dropdownlist, false, true, _inputDDLVendors.SelectedValue); //populate
                _inputDDLProducts.Enabled = true;
            }
            else
            {
                Tools.resetDropDownList(_inputDDLProducts.Dropdownlist);
                _inputDDLProducts.Enabled = false;
            }
        }
        
        private void cbVendors_TextChanged(object sender, EventArgs e)
        {
            Tools.resetDropDownList(_inputDDLProducts.Dropdownlist);
            _inputDDLProducts.Enabled = false;
        }

        private void lnkUpdateVendors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Vendors_Form(FormModes.Add));
            Vendor.populateDropDownList(_inputDDLVendors.Dropdownlist, false, true);
        }
        
        private void lnkUpdateProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Products_Form(FormModes.Add));
            Product.populateDropDownList(_inputDDLProducts.Dropdownlist, false, true, null);
        }

        private void lnkUpdateGrades_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.Grades_Form(FormMode.New));
            Grade.populateDropDownList(_inputDDLGrades.Dropdownlist, false, true);
        }
        
        private void lnkUpdateProductWidths_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.ProductWidths_Form(FormMode.New));
            ProductWidth.populateDropDownList(_inputDDLProductWidths.Dropdownlist, false, true);
        }
        
        private void lnkUpdateLengthUnits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.LengthUnits_Form(FormMode.New));
            LengthUnit.populateDropDownList(_inputDDLLengthUnits.Dropdownlist, false, true);
        }
        
        private void lnkUpdateColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new MasterData.FabricColors_Form(FormMode.New));
            FabricColor.populateDropDownList(_inputDDLColors.Dropdownlist, false, true);
        }
        
        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
