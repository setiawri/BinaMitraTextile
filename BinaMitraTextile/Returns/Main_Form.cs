using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Returns
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form()
        {
            InitializeComponent();

            setupControls();
            populateGrid();
        }

        private void btnReturnSale_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Returns.New_Form());
            populateGrid();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //Tools.adjustGridviewForVScrollbar(this,true);
        }

        private void setupControls()
        {
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_Checked.DataPropertyName = SaleReturn.COL_Checked;
            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_grid_Checked.Visible = false;
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void populateGrid()
        {
            //sale barcode
            Guid? saleID = null;
            txtBarcode.Text = txtBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                if (!Tools.isHexNumber(txtBarcode.Text))
                {
                    Tools.hasMessage(String.Format("{0} is an invalid invoice barcode", txtBarcode.Text));
                    txtBarcode.Focus();
                }
                else
                {
                    try
                    {
                        saleID = Sale.getIDByBarcode(txtBarcode.Text);
                    }
                    catch (Exception ex)
                    {
                        Tools.hasMessage(String.Format("{0} does not exist in database", txtBarcode.Text));
                        return;
                    }
                }
            }

            //item barcode
            Guid? inventoryItemID = null;
            txtInventoryItemBarcode.Text = txtInventoryItemBarcode.Text.Trim();
            if (!string.IsNullOrEmpty(txtInventoryItemBarcode.Text))
            {
                if (!InventoryItem.isValidBarcode(txtInventoryItemBarcode.Text))
                {
                    txtInventoryItemBarcode.Focus();
                }
                else
                {
                    try
                    {
                        inventoryItemID = InventoryItem.getIDByBarcode(InventoryItem.getBarcodeWithoutPrefix(txtInventoryItemBarcode.Text));
                    }
                    catch (Exception ex)
                    {
                        Tools.hasMessage(String.Format("{0} does not exist in database", txtBarcode.Text));
                        return;
                    }
                }
            }

            grid.DataSource = SaleReturn.getAll(Tools.getDate(dtStart, false), Tools.getDate(dtEnd, true), inventoryItemID, (Guid?)cbCustomers.SelectedValue, saleID, false);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), hexbarcode.Name))
            {
                Tools.displayForm(new Returns.Print_Form(new Guid(grid.Rows[e.RowIndex].Cells[col_grid_id.Name].Value.ToString())));
            }
            else if(LIBUtil.Util.isColumnMatch(sender, e, col_grid_Checked))
            {
                SaleReturn.updateCheckedStatus(LIBUtil.Util.getSelectedRowID(grid, col_grid_id), !LIBUtil.Util.getCheckboxValue(sender, e));
                populateGrid();
            }
        }

        #endregion LIST

        /*******************************************************************************************************/
        #region FILTER CONTROLS

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            dtStart.Checked = false;
            dtEnd.Checked = false;
            txtInventoryItemBarcode.Text = "";
            Tools.resetDropDownList(cbCustomers);
        }

        #endregion FILTER CONTROLS

        /*******************************************************************************************************/
    }
}
