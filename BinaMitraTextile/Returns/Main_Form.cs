using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.Returns
{
    public partial class Main_Form : Form
    {
        FormModes _startingMode = FormModes.Normal;
        Guid? _BrowsingForFakturPajak_Customers_Id = null;
        public Guid BrowsedItemSelectionId;

        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form()
        {
            InitializeComponent();
        }
        
        public Main_Form(FormModes startingMode, Guid BrowsingForFakturPajak_Customers_Id) : this()
        {
            _startingMode = startingMode;
            _BrowsingForFakturPajak_Customers_Id = BrowsingForFakturPajak_Customers_Id;

            if (_startingMode == FormModes.Browse)
            {
                pnlFilterAndButtons.Visible = false;
            }
        }

        private void btnReturnSale_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Returns.New_Form());
            populateGrid();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateGrid();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            idtp_StartDate.Value = DateTime.Now.AddMonths(-3);
            idtp_EndDate.Value = DateTime.Now;
            Customer.populateDropDownList(cbCustomers, true, false);

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_Checked.DataPropertyName = SaleReturn.COL_Checked;
            col_grid_FakturPajaks_No.DataPropertyName = SaleReturn.COL_FakturPajaks_No;
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

            if(_startingMode == FormModes.Browse)
                Util.setGridviewDataSource(grid, true, true, SaleReturn.get_by_BrowsingForFakturPajak_Customers_Id((Guid)_BrowsingForFakturPajak_Customers_Id));
            else
                Util.setGridviewDataSource(grid, true, true, SaleReturn.get(idtp_StartDate.ValueAsStartDateFilter, idtp_EndDate.ValueAsEndDateFilter, inventoryItemID, (Guid?)cbCustomers.SelectedValue, saleID));
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, hexbarcode))
            {
                Util.displayForm(null, new Returns.Print_Form((Guid)Util.getSelectedRowValue(sender, col_grid_id)));
            }
            else if(Util.isColumnMatch(sender, e, col_grid_Checked))
            {
                SaleReturn.updateCheckedStatus(LIBUtil.Util.getSelectedRowID(grid, col_grid_id), !LIBUtil.Util.getCheckboxValue(sender, e));
                populateGrid();
            }
        }

        private void Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //header row

            if (_startingMode == FormModes.Browse)
            {
                BrowsedItemSelectionId = (Guid)Util.getSelectedRowValue(sender, col_grid_id);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            txtInventoryItemBarcode.Text = "";
            Tools.resetDropDownList(cbCustomers);
        }

        #endregion FILTER CONTROLS

        /*******************************************************************************************************/
    }
}
