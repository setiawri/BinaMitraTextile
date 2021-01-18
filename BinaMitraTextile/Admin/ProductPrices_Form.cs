using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.Admin
{
    public partial class ProductPrices_Form : Form
    {
        /*******************************************************************************************************/

        #region CLASS VARIABLES

        private ProductPrice _productPrice;
        private Inventory _inventory;

        const string BTN_TEXT_ADDNEW = "ADD NEW";
        const string BTN_TEXT_UPDATE = "UPDATE";

        private const string COL_ID = "id";
        private const string COL_PRODUCTSTORENAME = "product_store_name";

        #endregion CLASS VARIABLES

        /*******************************************************************************************************/

        #region INITIALIZATION

        public ProductPrices_Form() : this(null)
        {
        }

        public ProductPrices_Form(Guid? inventoryID)
        {
            InitializeComponent();

            if(inventoryID != null) _inventory = new Inventory((Guid)inventoryID);
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            ProductStoreName.populateDropDownList(cbProductStoreNames, false, false);
            Grade.populateDropDownList(cbGrades, false, false);
            ProductWidth.populateDropDownList(cbProductWidths, false, false);
            LengthUnit.populateDropDownList(cbLengthUnits, false, false);
            FabricColor.populateDropDownList(cbColors, false, false);

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_colorname.DataPropertyName = ProductPrice.COL_COLORNAME;
            col_grid_Checked.DataPropertyName = ProductPrice.COL_DB_Checked;
            col_grid_BuyPrice.DataPropertyName = ProductPrice.COL_DB_BuyPrice;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_grid_Checked.Visible = false;
                chkOnlyNotOK.Visible = false;
                in_BuyPrice.Visible = false;
                col_grid_BuyPrice.Visible = false;
                btnDelete.Enabled = false;
            }
        }

        private void populatePageData()
        {
            populateGrid();
            grid.Sort(col_grid_productStoreName, ListSortDirection.Ascending);

            if(_inventory != null)
            {
                Guid? productPriceID = ProductPrice.getByCombination(null, null, null, null, _inventory.id, null);
                if (productPriceID != null)
                {
                    _productPrice = new ProductPrice((Guid)productPriceID);
                    chkUseInventoryID.Checked = true;
                }
                else
                {
                    productPriceID = ProductPrice.getByCombination(_inventory.product_store_name_id, _inventory.grade_id, _inventory.product_width_id, _inventory.length_unit_id, null, (Guid?)cbColors.SelectedValue);
                    if (productPriceID != null)
                    {
                        _productPrice = new ProductPrice((Guid)productPriceID);
                    }
                }
            }

            setMode();
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/

        #region LIST

        private void populateGrid()
        {
            DataView dvw = ProductPrice.get(chkOnlyNotOK.Checked).DefaultView;
            dvw.RowFilter = Tools.compileQuickSearchFilter(itxt_QuickSearch.ValueText.Trim(), new string[] { ProductPrice.COL_PRODUCTSTORENAME, ProductPrice.COL_COLORNAME, ProductPrice.COL_DB_SELLPRICE } );

            Util.setGridviewDataSource(grid, true, true, dvw);
        }
        
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Util.isColumnMatch(sender, e, col_grid_Checked))
            {
                ProductPrice.update_Checked((Guid)Util.getSelectedRowValue(grid, col_grid_id), !Util.getCheckboxValue(sender, e));
                populateGrid();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_grid_productStoreName.Name))
            {
                clearForm();
                _productPrice = new ProductPrice(Util.getClickedRowValue<Guid>(sender, e, col_grid_id));
                if (_productPrice.InventoryID != null)
                    _inventory = new Inventory((Guid)_productPrice.InventoryID);
                else
                    _inventory = null;

                setMode();
            }
            else if(Util.isColumnMatch(sender, e, col_grid_IsSelected))
            {
                gbNonSelectionPanel.Visible = false;
                gbSelectionPanel.Visible = true;
                Util.clickDataGridViewCheckbox(sender, e);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form((Guid)((DataGridView)sender).Rows[e.RowIndex].Cells[col_grid_id.Name].Value));
        }

        #endregion LIST

        /*******************************************************************************************************/

        #region ADD/UPDATE ITEM
        
        private void setInputAvailability(bool enable)
        {
            cbProductStoreNames.Enabled = enable;
            cbGrades.Enabled = enable;
            cbProductWidths.Enabled = enable;
            cbLengthUnits.Enabled = enable;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductPrice obj;
            if (isInputFieldsValid(btnSubmit.Text == BTN_TEXT_UPDATE))
            {
                if (chkUseInventoryID.Checked)
                    obj = new ProductPrice(null, null, null, null, Tools.zeroNonNumericString(txtTagPrice.Text), txtNotes.Text, _inventory.id, null, in_BuyPrice.Value);
                else
                    obj = new ProductPrice((Guid)cbProductStoreNames.SelectedValue, (Guid)cbGrades.SelectedValue, (Guid)cbProductWidths.SelectedValue, (Guid)cbLengthUnits.SelectedValue, Tools.zeroNonNumericString(txtTagPrice.Text), txtNotes.Text, null, (Guid?)cbColors.SelectedValue, in_BuyPrice.Value);

                if(btnSubmit.Text == BTN_TEXT_ADDNEW)
                {
                    if (obj.submitNew() != null)
                    {
                        clearForm();
                        setInputAvailability(true);
                        populateGrid();
                    }
                }
                else
                {
                    obj.ID = _productPrice.ID;
                    ProductPrice.update(obj.ID, obj.ProductStoreNameID, obj.GradeID, obj.ProductWidthID, obj.LengthUnitID, obj.TagPrice, obj.Notes, obj.InventoryID, obj.ColorID, obj.BuyPrice);
                    populateGrid();
                }
            }
        }

        private Boolean isInputFieldsValid(bool isUpdate)
        {
            txtTagPrice.Text = txtTagPrice.Text.Trim();
            txtNotes.Text = txtNotes.Text.Trim();

            if (string.IsNullOrEmpty(txtTagPrice.Text))
                return Tools.inputError<TextBox>(txtTagPrice, "Please provide price");
            else if (!Tools.isNumeric(txtTagPrice.Text))
                return Tools.inputError<TextBox>(txtTagPrice, "Invalid price");

            if(!chkUseInventoryID.Checked)
            {
                if (cbProductStoreNames.SelectedValue == null)
                    return Tools.inputError<ComboBox>(cbProductStoreNames, "Please select a product listed in the drop down list");
                else if (cbProductWidths.SelectedValue == null)
                    return Tools.inputError<ComboBox>(cbProductWidths, "Please select a width listed in the drop down list");
                else if (cbLengthUnits.SelectedValue == null)
                    return Tools.inputError<ComboBox>(cbLengthUnits, "Please select a length unit listed in the drop down list");
            }

            Guid? productPriceID = null;
            if (_productPrice != null) productPriceID = _productPrice.ID;

            Guid? inventoryID = null;
            if (_inventory != null) inventoryID = _inventory.id;

            if (!isUpdate && ProductPrice.isCombinationExist((Guid?)cbProductStoreNames.SelectedValue, (Guid?)cbGrades.SelectedValue, (Guid?)cbProductWidths.SelectedValue, (Guid?)cbLengthUnits.SelectedValue, productPriceID, inventoryID, (Guid?)cbColors.SelectedValue))
                return Tools.inputError<ComboBox>(cbProductStoreNames, "Price for the inventory code / combination is already in the list");

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
            setMode();
        }

        private void clearForm()
        {
            _inventory = null;
            _productPrice = null;
            chkUseInventoryID.Checked = false;
            txtInventoryCode.Text = "";
            chkUseInventoryID.Enabled = false;
            txtTagPrice.Text = "";
            in_BuyPrice.reset();
            txtNotes.Text = "";

            Tools.resetDropDownList(cbGrades);
            Tools.resetDropDownList(cbLengthUnits);
            Tools.resetDropDownList(cbProductStoreNames);
            Tools.resetDropDownList(cbProductWidths);
            Tools.resetDropDownList(cbColors);
            //setInputAvailability(true);

            cbProductStoreNames.Focus();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productPrice.delete();
            clearForm();
            populateGrid();
            setMode();
        }


        private void setUpdateMode()
        {
            btnSubmit.Text = BTN_TEXT_UPDATE;
            btnSubmit.ForeColor = Color.Orange;
            btnDelete.Enabled = true;
            setInputAvailability(false);
        }

        private void setNewMode()
        {
            btnSubmit.Text = BTN_TEXT_ADDNEW;
            btnSubmit.ForeColor = Color.Black;
            btnDelete.Enabled = false;
            if (_inventory == null)
                setInputAvailability(true);
            else
                setInputAvailability(false);
        }

        private void setMode()
        {
            if (_inventory == null)
            {
                if(_productPrice == null)
                    clearForm();
                else
                {
                    if(_productPrice.InventoryID != null)
                    {
                        _inventory = new Inventory((Guid)_productPrice.InventoryID);
                        txtInventoryCode.Text = _inventory.code.ToString();
                    }
                    //setInputAvailability(false);
                }
            }
            else
            {
                //if (_productPrice != null)
                //    setInputAvailability(false);
                //else
                //    setInputAvailability(true);
            }

            txtTagPrice.Text = "";
            txtNotes.Text = "";
            if(_productPrice != null)
            {
                if (_productPrice.InventoryID != null) chkUseInventoryID.Checked = true;
                cbProductStoreNames.SelectedValue = Util.wrapNullable(_productPrice.ProductStoreNameID);
                cbGrades.SelectedValue = Util.wrapNullable(_productPrice.GradeID);
                cbProductWidths.SelectedValue = Util.wrapNullable(_productPrice.ProductWidthID);
                cbLengthUnits.SelectedValue = Util.wrapNullable(_productPrice.LengthUnitID);
                cbColors.SelectedValue = Util.wrapNullable(_productPrice.ColorID);
                txtTagPrice.Text = _productPrice.TagPrice.ToString();
                in_BuyPrice.Value = _productPrice.BuyPrice;
                txtNotes.Text = _productPrice.Notes;
            }
            if(_inventory != null)
            {
                txtInventoryCode.Text = _inventory.code.ToString();
                cbProductStoreNames.SelectedValue = _inventory.product_store_name_id;
                cbGrades.SelectedValue = _inventory.grade_id;
                cbProductWidths.SelectedValue = _inventory.product_width_id;
                cbLengthUnits.SelectedValue = _inventory.length_unit_id;
                cbColors.SelectedValue = _inventory.color_id;
            }

            if (chkUseInventoryID.Checked)
            {
                if (_productPrice == null)
                    setNewMode();
                else
                {
                    if (_productPrice.InventoryID == null)
                        setNewMode();
                    else
                        setUpdateMode();
                }
            }
            else
            {
                if(_productPrice == null)
                {
                    setNewMode();
                }
                else
                {
                    if (_productPrice.InventoryID == null)
                        setUpdateMode();
                    else
                        setNewMode();
                }
            }
        }

        private void chkUseInventoryID_CheckedChanged(object sender, EventArgs e)
        {
            if(_inventory != null)
            {
                Guid? productPriceID = null;
                if (chkUseInventoryID.Checked)
                    productPriceID = ProductPrice.getByCombination(null,null,null,null, _inventory.id, null);
                else
                    productPriceID = ProductPrice.getByCombination(_inventory.product_store_name_id, _inventory.grade_id, _inventory.product_width_id, _inventory.length_unit_id, null, (Guid?)cbColors.SelectedValue);

                if (productPriceID != null)
                    _productPrice = new ProductPrice((Guid)productPriceID);
                else
                    _productPrice = null;

                setMode();
            }
        }

        private void btnCancelSelections_Click(object sender, EventArgs e)
        {
            resetSelections();
        }

        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            //create id list of selected rows
            List<Guid?> ProductPrice_Ids = new List<Guid?>();
            foreach(DataGridViewRow row in grid.Rows)
            {
                if(Util.getCheckboxValue(row, col_grid_IsSelected.Index))
                {
                    grid.ClearSelection();
                    row.Selected = true;
                    ProductPrice_Ids.Add((Guid)Util.getSelectedRowValue(grid, col_grid_id));
                }
            }

            ProductPrice.update(ProductPrice_Ids, in_Price.ValueDecimal);

            resetSelections();
        }

        private void resetSelections()
        {
            gbNonSelectionPanel.Visible = true;
            gbSelectionPanel.Visible = false;
            in_Price.reset();
            populateGrid();
        }

        private void itxt_QuickSearch_onTextChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void chkOnlyNotOK_CheckedChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/

    }
}
