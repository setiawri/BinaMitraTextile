﻿using System;
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
    public partial class New_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        const string COL_DELETE = "DeleteRow";

        private Guid? _customerID = null, _Vendors_Id = null;
        private decimal _totalAmount = 0;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public New_Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //Tools.adjustGridviewForVScrollbar(this,true);
            setupControls();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            grid.AutoGenerateColumns = false;
            col_grid_SaleOrderItemDescription.DataPropertyName = SaleItem.COL_SaleOrderItemDescription;

            gridSummary.AutoGenerateColumns = false;

            Inventory.setAmount(lblTotalAmount, "0");
            Inventory.setCount(lblTotalCounts, "0", "0");
            btnSubmit.Enabled = false;

            txtBarcode.Focus();

            txtBarcode.MaxLength = Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length + 3;

            Tools.formatDeleteColumn(DeleteRow);

            lblCustomerName.Text = "";
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isSaleReturnValid())
            {
                SaleReturn obj = new SaleReturn(txtNotes.Text, (DataTable)grid.DataSource);
                if (obj.submitNew() != null)
                {
                    if(_customerID != null)
                    {
                        CustomerCredit.submitNew((Guid)_customerID, _totalAmount, null, string.Format("Credit from Sale Return " + obj.barcode), PaymentMethod.Cash, false);
                        Tools.hasMessage("Credit sudah dibuat sejumlah " + lblTotalAmount.Text);
                    }
                    this.Close();
                }
            }
        }

        private bool isSaleReturnValid()
        {
            txtNotes.Text = txtNotes.Text.Trim();
            DataTable dt = (DataTable)grid.DataSource;
            if (dt.Rows.Count == 0)
                return Tools.inputError<TextBox>(txtBarcode, "Please add an item");
            else if (string.IsNullOrEmpty(txtNotes.Text))
                return Tools.inputError<TextBox>(txtNotes, "Berikan keterangan kenapa di retur di kotak notes");

            return true;
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region LIST - ITEMS

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), DeleteRow.Name))
            {
                DataTable dt = (DataTable)grid.DataSource;
                dt.Rows[e.RowIndex].Delete();
                dt.AcceptChanges();
                grid.DataSource = dt;
                recalculateNumbers();

                if (dt.Rows.Count == 0)
                {
                    _customerID = _Vendors_Id = null;
                    lblCustomerName.Text = "";
                }
            }
        }

        #endregion LIST - ITEMS
        /*******************************************************************************************************/
        #region LIST - SUMMARY

        private void updateSummaryList()
        {
            gridSummary.DataSource = SaleReturn.compileSummaryData((DataTable)grid.DataSource);
        }

        private void gridSummary_SelectionChanged(object sender, EventArgs e)
        {
            gridSummary.ClearSelection(); //disable cell color change when user click on it
        }

        #endregion LIST - SUMMARY
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                addBarcode();
        }

        private void addBarcode()
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
                return;

            string barcode = InventoryItem.getBarcodeWithoutPrefix(txtBarcode.Text.Trim());

            if (!InventoryItem.isBarcodeExist(barcode))
            {
                Tools.hasMessage(barcode.ToString() + " is not found in database");
            }
            else if (InventoryItem.isBarcodeValidForSale(barcode))
            {
                Tools.hasMessage(barcode.ToString() + " has not been sold yet");
            }
            else
            {
                DataTable dt;
                if (grid.DataSource == null)
                {
                    dt = SaleItem.getItemForReturn(barcode);
                    if(dt.Rows[0][SaleItem.COL_CUSTOMERID] != DBNull.Value)
                    {
                        _customerID = (Guid)dt.Rows[0][SaleItem.COL_CUSTOMERID];
                        lblCustomerName.Text = dt.Rows[0][SaleItem.COL_CUSTOMERNAME].ToString();
                    }
                    else
                    {
                        _Vendors_Id = (Guid)dt.Rows[0][SaleItem.COL_DB_Vendors_Id];
                        lblCustomerName.Text = dt.Rows[0][SaleItem.COL_Vendors_Name].ToString();
                    }
                }
                else
                {
                    dt = Tools.setDataTablePrimaryKey((DataTable)grid.DataSource, SaleItem.COL_ID);
                    foreach (DataRow dr in SaleItem.getItemForReturn(barcode).Rows)
                    {
                        if (dt.Rows.Contains(dr[SaleItem.COL_ID]))
                            Tools.hasMessage(dr[SaleItem.COL_BARCODE].ToString() + " is already in the list");
                        else if (_customerID != null && (Guid)dr[SaleItem.COL_CUSTOMERID] != _customerID)
                            Tools.hasMessage(barcode.ToString() + " was sold to a different customer: " + dr[SaleItem.COL_CUSTOMERNAME].ToString());
                        else if (_Vendors_Id != null && (Guid)dr[SaleItem.COL_DB_Vendors_Id] != _Vendors_Id)
                            Tools.hasMessage(barcode.ToString() + " was returned to a different vendor: " + dr[SaleItem.COL_Vendors_Name].ToString());
                        else
                            dt.Rows.Add(dr.ItemArray);
                    }
                }

                grid.DataSource = dt;
                recalculateNumbers();
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region CALCULATIONS

        private void recalculateNumbers()
        {
            DataTable dt = (DataTable)grid.DataSource;

            //update grand total

            _totalAmount = Tools.zeroNonNumericString(dt.Compute(String.Format("SUM({0})", SaleItem.COL_SUBTOTAL), ""));
            Inventory.setAmount(lblTotalAmount, _totalAmount.ToString());

            //update total counts
            Inventory.setCount(lblTotalCounts, dt.Rows.Count.ToString(), dt.Compute(String.Format("SUM({0})", SaleItem.COL_LENGTH), "").ToString());

            //disable/enable generate button
            if (dt.Rows.Count > 0)
            {
                btnSubmit.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
            }
            grid.DataSource = dt;

            updateSummaryList();
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

        #endregion CALCULATIONS

        /*******************************************************************************************************/
    }
}
