using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class InventoryItems_Split_Form : Form
    {
        /*******************************************************************************************************/
        #region VARIABLES

        public InventoryItem NewInventoryItemId;

        private InventoryItem _inventoryItem;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public InventoryItems_Split_Form(Guid id)
        {
            InitializeComponent();

            _inventoryItem = new InventoryItem(id);
            lblBarcode.Text = _inventoryItem.barcode;
            lblProductStoreName.Text = _inventoryItem.ProductStoreName;
            lblCode.Text = _inventoryItem.code;

            lblColor.Text = _inventoryItem.InventoryColorName;
            lblGrade.Text = _inventoryItem.Grades_Name;
            lblWidth.Text = _inventoryItem.ProductWidths_Name;
            lblQty.Text = string.Format("{0:N2} {1}", _inventoryItem.item_length, _inventoryItem.LengthUnitName);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region FORM METHODS
        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                NewInventoryItemId = _inventoryItem.split(in_splitQty.ValueDecimal);
                this.Close();
            }
        }

        private bool isInputValid()
        {
            if (in_splitQty.Value == 0)
                return in_splitQty.isValueError("Isi panjang potongan");
            if(in_splitQty.Value > _inventoryItem.item_length)
                return in_splitQty.isValueError("Panjang potongan tidak bisa melebihi panjang roll");

            return true;
        }

        private void itxt_SplitQty_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSubmit.PerformClick();
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/

    }
}
