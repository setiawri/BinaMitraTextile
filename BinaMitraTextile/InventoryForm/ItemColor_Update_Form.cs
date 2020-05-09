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
    public partial class ItemColor_Update_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        InventoryItem _inventoryItem;
        Inventory _inventory;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public ItemColor_Update_Form()
        {
            InitializeComponent();

            setupControls();
        }

        private void Form_Load(object sender, EventArgs e) { }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            FabricColor.populateDropDownList(cbColors, false, true);
            Tools.resetDropDownList(cbColors);

            pnlItem.Enabled = false;
            lblBarcode.Text = "";
            lblColor.Text = "";
            lblGrade.Text = "";
            lblItemInfo.Text = "";
            lblWidth.Text = "";
        }

        private void populatePageData()
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
                return;

            _inventoryItem = new InventoryItem(InventoryItem.getBarcodeWithoutPrefix(txtBarcode.Text));

            if (_inventoryItem.inventory_id == Guid.Empty)
            {
                Tools.showError("Item is not in database");
                pnlItem.Enabled = false;
            }
            else if(!new FabricColor(new Inventory(_inventoryItem.inventory_id).color_id).Allow2ndColor)
            {
                Tools.showError(string.Format("Warna inventory '{0}' tidak diperbolehkan mempunyai warna lain untuk masing-masing roll", new Inventory(_inventoryItem.inventory_id).color_name));
                pnlItem.Enabled = false;
            }
            else
            {
                pnlItem.Enabled = true;

                _inventory = new Inventory(_inventoryItem.inventory_id);

                lblBarcode.Text = _inventoryItem.barcode;
                lblItemInfo.Text = String.Format("[{0}] {1} {2}", _inventoryItem.code.ToString(), _inventoryItem.item_length, _inventoryItem.LengthUnitName);
                lblWidth.Text = _inventory.product_width_name;
                lblGrade.Text = _inventory.grade_name;
                lblColor.Text = _inventory.color_name;
                Tools.setDropDownList(cbColors, _inventoryItem.ColorID);
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _inventoryItem.ColorID = (Guid?)cbColors.SelectedValue;
            _inventoryItem.update();

            txtBarcode.Focus();
        }

        #endregion EVENT HANDLERS

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Enter)
            {
                if (!InventoryItem.isValidBarcode(txtBarcode.Text.Trim()))
                {
                    txtBarcode.Focus();
                }
                else
                {
                    populatePageData();
                    cbColors.Focus();

                    txtBarcode.Text = "";
                }
            }
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.FabricColors_Form(FormMode.New));
            FabricColor.populateDropDownList(cbColors, false, true);
        }
        /*******************************************************************************************************/
        #region FORM METHODS
        #endregion FORM METHODS
        /*******************************************************************************************************/
    }

}
