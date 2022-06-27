using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.InventoryForm
{
    public partial class Items_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        const string BTN_TEXT_ADDNEW = "ADD NEW";
        const string BTN_TEXT_UPDATE = "UPDATE";
        const string COL_BARCODE = "Barcode";

        private Guid _id;

        Inventory _inventory;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/

        #region INITIALIZATION

        public Items_Form(Guid inventoryID)
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);

            _inventory = new Inventory(inventoryID);
            lblInventoryID.Text = String.Format("{0} - {1}", _inventory.code.ToString(), _inventory.product_store_name);
            lblLengthUnit.Text = _inventory.length_unit_name;
            lblColor.Text = _inventory.color_name;
            lblGrade.Text = _inventory.grade_name;
            lblWidth.Text = _inventory.product_width_name;
            lblReceiveDate.Text = string.Format("{0:dd/MM/yy HH:mm}", _inventory.receive_date);
            if (new FabricColor(_inventory.color_id).Allow2ndColor)
            {
                cbColors.Enabled = true;
                btnAddColor.Enabled = true;
            }

            FabricColor.populateDropDownList(cbColors, false, true);
            disableForm();

            grid.AutoGenerateColumns = false;
            col_grid_id.DataPropertyName = InventoryItem.COL_DB_ID;
            col_grid_lastOpname.DataPropertyName = InventoryItem.COL_LASTOPNAME;
            col_grid_ItemLocation.DataPropertyName = InventoryItemCheck.COL_DB_ItemLocation;
            col_grid_colorname.DataPropertyName = InventoryItem.COL_INVENTORYITEMCOLORNAME;
            col_grid_notes.DataPropertyName = InventoryItem.COL_DB_NOTES;
            col_grid_SaleOrderItemDescription.DataPropertyName = InventoryItem.COL_SaleOrderItemDescription;
            col_grid_Sales_Hexbarcode.DataPropertyName = InventoryItem.COL_Sales_Hexbarcode;
            col_grid_Sales_Id.DataPropertyName = InventoryItem.COL_Sales_Id;
            populateGrid();

            txtBarcode.MaxLength = Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length;
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/

        #region LIST

        private void populateGrid()
        {
            DataTable dt = InventoryItem.getItems(_inventory.id);
            grid.DataSource = dt;
            Inventory.setCount(lblCount,
                dt.Compute(String.Format("COUNT({0})", InventoryItem.COL_DB_LENGTH), String.Format("{0} IS NULL OR {0} = 0", InventoryItem.COL_IS_SOLD)).ToString(),
                dt.Compute(String.Format("SUM({0})", InventoryItem.COL_DB_LENGTH), String.Format("{0} IS NULL OR {0} = 0", InventoryItem.COL_IS_SOLD)).ToString());
            Inventory.setCount(lblReceived,
                dt.Compute(String.Format("COUNT({0})", InventoryItem.COL_DB_LENGTH),"").ToString(),
                dt.Compute(String.Format("SUM({0})", InventoryItem.COL_DB_LENGTH), "").ToString());
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), COL_BARCODE))
            {
                enableForm(grid.Rows[e.RowIndex].Cells[COL_BARCODE].Value.ToString(), true);
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_grid_Sales_Hexbarcode.Name))
            {
                Tools.displayForm(new Sales.Invoice_Form((Guid)LIBUtil.Util.getClickedRowValue(sender, e, col_grid_Sales_Id)));
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //display item details
            Tools.displayForm(new Logs.Main_Form(new Guid(grid.Rows[e.RowIndex].Cells[col_grid_id.Name].Value.ToString())));
        }

        #endregion LIST

        /*******************************************************************************************************/

        #region ADD/UPDATE ITEM

        private void txtLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSubmit.PerformClick();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtBarcode.Text) && InventoryItem.isValidNewBarcode(txtBarcode.Text.Trim()))
                {
                    enableForm(InventoryItem.getBarcodeWithoutPrefix(txtBarcode.Text), false);
                }
            }
        }

        private void disableForm()
        {
            Tools.resetDropDownList(cbColors);
            txtBarcode.Text = "";
            lblBarcode.Text = "";
            txtLength.Text = "";
            gbForm.Enabled = false;
            txtBarcode.Focus();
            btnSubmit.Text = BTN_TEXT_ADDNEW;
        }

        private void enableForm(string barcodeWithoutPrefix, bool isUpdate)
        {
            txtBarcode.Text = "";
            lblBarcode.Text = barcodeWithoutPrefix;
            txtLength.Enabled = true;           
            txtLength.Text = "";
            gbForm.Enabled = true;
            txtNotes.Text = "";
            txtLength.Focus();

            if (isUpdate)
            {
                InventoryItem obj = new InventoryItem(barcodeWithoutPrefix);
                _id = obj.id;
                txtLength.Text = obj.item_length.ToString();
                Tools.setValue(cbColors, obj.ColorID);
                txtNotes.Text = obj.notes;
                btnSubmit.Text = BTN_TEXT_UPDATE;
                if (GlobalData.UserAccount.role != Roles.Super)
                {
                    txtLength.Enabled = false;                    
                }
            }
            else
            {
                _id = Guid.NewGuid();
                btnSubmit.Text = BTN_TEXT_ADDNEW;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (btnSubmit.Text)
            {
                case BTN_TEXT_ADDNEW:
                    {
                        if (isInputFieldsValid(false))
                        {
                            InventoryItem inventoryItem = new InventoryItem(_id, _inventory.id, Convert.ToDecimal(txtLength.Text), lblBarcode.Text, (Guid?)cbColors.SelectedValue, txtNotes.Text.Trim());
                            if (inventoryItem.submitNew() != null)
                            {
                                populateGrid();
                                disableForm();
                            }
                        }
                        break;
                    }
                case BTN_TEXT_UPDATE:
                    {
                        if (isInputFieldsValid(true))
                        {
                            InventoryItem inventoryItem = new InventoryItem(_id, _inventory.id, Convert.ToDecimal(txtLength.Text), lblBarcode.Text, (Guid?)cbColors.SelectedValue, txtNotes.Text.Trim());
                            if (inventoryItem.update())
                            {
                                populateGrid();
                                disableForm();
                            }
                        }
                        break;
                    }
            }
        }

        private Boolean isInputFieldsValid(bool isUpdate)
        {
            txtBarcode.Text = txtBarcode.Text.Trim();
            txtLength.Text = txtLength.Text.Trim();

            if (!Tools.isNumeric(txtLength.Text))
                return Tools.inputError<TextBox>(txtLength, "Invalid length");
            else if (!isUpdate && InventoryItem.isBarcodeExist(lblBarcode.Text))
                return Tools.inputError<TextBox>(txtBarcode, "Barcode already exist in database");

            return true;
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.FabricColors_Form(FormMode.New));
            FabricColor.populateDropDownList(cbColors, false, true);
        }

        private void BtnRemoveSaleOrderItems_Click(object sender, EventArgs e)
        {
            List<Guid> InventoryItemIdList = new List<Guid>();

            DataTable dt = (DataTable)grid.DataSource;
            foreach (DataRow dr in dt.Rows)
                InventoryItemIdList.Add((Guid)dr[SaleItem.COL_INVENTORY_ITEM_ID]);

            if (InventoryItem.updateSaleOrderItem(InventoryItemIdList, null, null))
            {
                //manually update list since it is not saved in database yet
                foreach (DataRow dr in dt.Rows)
                    dr[SaleItem.COL_SaleOrderItemDescription] = DBNull.Value;

                grid.DataSource = dt;
            }
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/

    }
}
