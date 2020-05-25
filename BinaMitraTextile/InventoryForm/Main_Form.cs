using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile.InventoryForm
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private string[] fieldNamesForQuickSearch = { Inventory.COL_DB_CODE, Inventory.COL_COLOR_NAME, Inventory.COL_GRADE_NAME, Inventory.COL_PRODUCTSTORENAME, Inventory.COL_PRODUCT_WIDTH_NAME, Inventory.COL_DB_PACKINGLISTNO, Inventory.COL_VENDORINVOICENO };
        private FormMode _formMode = FormMode.Search;
        private Guid? _vendorID;
        private Guid _clickedInventoryID;
        private bool _isFormShown = false;

        public Guid browseSelection;
        protected CheckBox _selectCheckboxHeader;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form() : this(FormMode.Search, null)
        {
        }

        public Main_Form(FormMode formMode, Guid? vendorID)
        {
            InitializeComponent();

            _formMode = formMode;
            _vendorID = vendorID;
        }


        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            _isFormShown = true;

            _selectCheckboxHeader = Tools.addHeaderCheckbox(grid, col_grid_select, "_selectCheckboxHeader", selectCheckboxHeader_CheckedChanged);
            populatePageData();

            this.Activate();
            ptFilter.toggle();
            ptRowInfo.toggle();
            itxt_QuickSearch.focus();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            if (_formMode == FormMode.Browse)
            {
                flpButtons.Enabled = false;
                //splitContainer1.Panel1Collapsed = true;
            }

            lblRowInfoHeader.Text = "";

            Grade.populateInputControlCheckedListBox(iclb_Grades, false);
            ProductWidth.populateInputControlCheckedListBox(iclb_ProductWidths, false);
            ProductStoreName.populateInputControlCheckedListBox(iclb_ProductStoreNames, false);
            LengthUnit.populateInputControlCheckedListBox(iclb_LengthUnits, false);
            FabricColor.populateInputControlCheckedListBox(iclb_Colors, false);
            
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_active.DataPropertyName = Inventory.COL_DB_ACTIVE;
            col_grid_receiveDate.DataPropertyName = Inventory.COL_DB_RECEIVEDATE;
            col_grid_code.DataPropertyName = Inventory.COL_DB_CODE;
            col_grid_grade.DataPropertyName = Inventory.COL_GRADE_NAME;
            col_grid_product.DataPropertyName = Inventory.COL_PRODUCTSTORENAME;
            col_grid_productWidth.DataPropertyName = Inventory.COL_PRODUCT_WIDTH_NAME;
            col_grid_color.DataPropertyName = Inventory.COL_COLOR_NAME;
            col_grid_sellPrice.DataPropertyName = Inventory.COL_SELLPRICE;
            col_grid_buyPrice.DataPropertyName = Inventory.COL_DB_BUYPRICE;
            col_grid_unit.DataPropertyName = Inventory.COL_LENGTH_UNIT_NAME;
            col_grid_availablePcs.DataPropertyName = Inventory.COL_AVAILABLEQTY;
            col_grid_availableQty.DataPropertyName = Inventory.COL_AVAILABLEITEMLENGTH;
            col_grid_totalPcs.DataPropertyName = Inventory.COL_QTY;
            col_grid_totalQty.DataPropertyName = Inventory.COL_ITEMLENGTH;
            col_grid_PONo.DataPropertyName = Inventory.COL_PONo;
            col_grid_invoiceNo.DataPropertyName = Inventory.COL_VENDORINVOICENO;
            col_grid_packingListNo.DataPropertyName = Inventory.COL_DB_PACKINGLISTNO;
            col_grid_isConsignment.DataPropertyName = Inventory.COL_DB_IsConsignment;
            col_grid_OpnameMarker.DataPropertyName = Inventory.COL_DB_OpnameMarker;
            col_grid_code.Frozen = true;
            col_grid_buyPrice.Visible = false;

            gridSummary.AutoGenerateColumns = false;
            gridSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSummary_availablePcs.DataPropertyName = Inventory.COL_AVAILABLEQTY;
            col_gridSummary_availableQty.DataPropertyName = Inventory.COL_AVAILABLEITEMLENGTH;
            col_gridSummary_averagePrice.DataPropertyName = Inventory.COL_DB_BUYPRICE;
            col_gridSummary_grade.DataPropertyName = Inventory.COL_GRADE_NAME;
            col_gridSummary_Product_Id.DataPropertyName = Inventory.COL_PRODUCTID;
            col_gridSummary_StoreName.DataPropertyName = Inventory.COL_PRODUCTSTORENAME;
            col_gridSummary_unitName.DataPropertyName = Inventory.COL_LENGTH_UNIT_NAME;
            col_gridSummary_Width.DataPropertyName = Inventory.COL_PRODUCT_WIDTH_NAME;
            col_gridSummary_BuyValue.DataPropertyName = Inventory.COL_BUYVALUE;
            col_gridSummary_SellValue.DataPropertyName = Inventory.COL_SELLVALUE;

            gridSummaryByColor.AutoGenerateColumns = false;
            gridSummaryByColor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSummaryByColor_availablePcs.DataPropertyName = Inventory.COL_AVAILABLEQTY;
            col_gridSummaryByColor_AvailableQty.DataPropertyName = Inventory.COL_AVAILABLEITEMLENGTH;
            col_gridSummaryByColor_AveragePrice.DataPropertyName = Inventory.COL_DB_BUYPRICE;
            col_gridSummaryByColor_Grade.DataPropertyName = Inventory.COL_GRADE_NAME;
            col_gridSummaryByColor_ColorName.DataPropertyName = Inventory.COL_COLOR_NAME;
            col_gridSummaryByColor_ProductId.DataPropertyName = Inventory.COL_PRODUCTID;
            col_gridSummaryByColor_ProductStoreName.DataPropertyName = Inventory.COL_PRODUCTSTORENAME;
            col_gridSummaryByColor_UnitName.DataPropertyName = Inventory.COL_LENGTH_UNIT_NAME;
            col_gridSummaryByColor_ProductWidthName.DataPropertyName = Inventory.COL_PRODUCT_WIDTH_NAME;
            col_gridSummaryByColor_BuyValue.DataPropertyName = Inventory.COL_BUYVALUE;
            col_gridSummaryByColor_SellValue.DataPropertyName = Inventory.COL_SELLVALUE;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                chkShowHidden.Visible = false;
                pbLog.Enabled = false;
                chkRearrange.Visible = false;
                chkCalculateBuyValue.Visible = false;
                col_grid_isConsignment.Visible = false;

                col_gridSummary_averagePrice.Visible = false;
                col_gridSummary_BuyValue.Visible = false;
                col_gridSummary_SellValue.Visible = false;

                col_gridSummaryByColor_AveragePrice.Visible = false;
                col_gridSummaryByColor_BuyValue.Visible = false;
                col_gridSummaryByColor_SellValue.Visible = false;
            }

        }

        private void populatePageData()
        {
            populateGridview(true);
        }

        private void populateGridSummary()
        {
            if (pnlRowInfo.Visible && _isFormShown)
            {
                DataView dvw = Inventory.compileSummaryData(Util.getDataTable(grid.DataSource), false).DefaultView;
                dvw.Sort = string.Format("{0} ASC, {1} ASC, {2} ASC", Inventory.COL_GRADE_NAME, Inventory.COL_PRODUCTSTORENAME, Inventory.COL_PRODUCT_WIDTH_NAME);
                gridSummary.DataSource = dvw;

                DataView dvwByColor = Inventory.compileSummaryData(Util.getDataTable(grid.DataSource), true).DefaultView;
                dvwByColor.Sort = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC", Inventory.COL_GRADE_NAME, Inventory.COL_PRODUCTSTORENAME, Inventory.COL_PRODUCT_WIDTH_NAME, Inventory.COL_COLOR_NAME);
                gridSummaryByColor.DataSource = dvwByColor;
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void selectCheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            Tools.toggleCheckboxColumn(grid, col_grid_select, _selectCheckboxHeader);
            calculateSelections();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_grid_buyPrice))
            {
                pnlUpdateBuyPrice.Visible = true;
                _clickedInventoryID = (Guid)Util.getClickedRowValue(sender, e, col_grid_id);
                Inventory obj = new Inventory(_clickedInventoryID);
                in_BuyPrice.Value = obj.buy_price;
                in_BuyPrice.focus();
            }
            else if (_formMode == FormMode.Browse)
            {
                browseSelection = selectedRowID();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new InventoryForm.Add_Edit_Form());
            populateGridview(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new InventoryForm.Add_Edit_Form(selectedRowID()));
            populateGridview(true);
        }

        protected void chkIncludeInactive_CheckedChanged(object sender, EventArgs e)
        {
            populateGridview(true);
        }

        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.ProductPrices_Form(selectedRowID()));
            populateGridview(true);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new InventoryForm.Items_Form(selectedRowID()));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            iclb_LengthUnits.reset();
            iclb_Colors.reset();
            iclb_ProductStoreNames.reset();
            iclb_Grades.reset();
            iclb_ProductWidths.reset();

            populateGridview(true);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_select.Name))
            {
                Util.clickDataGridViewCheckbox(sender, e);
                calculateSelections();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_OpnameMarker.Name))
            {
                Inventory.updateOpnameMarker((Guid)Util.getClickedRowValue(sender, e, col_grid_id), Util.clickDataGridViewCheckbox(sender, e));
                populateGridview(true);
            }
            else if (GlobalData.UserAccount.role != Roles.User)
            {
                if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_active.Name))
                {
                    Inventory.updateActiveStatus(selectedRowID(), !(bool)((DataGridViewCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value);
                    populateGridview(true);
                }
                else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_isConsignment.Name))
                {
                    Inventory.updateIsConsignment(selectedRowID(), !(bool)((DataGridViewCheckBoxCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value);
                    populateGridview(true);
                }
            }
        }

        private void btnUpdateItemColor_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new InventoryForm.ItemColor_Update_Form());
        }

        private void btnRefreshPage_Click(object sender, EventArgs e)
        {
        }
        
        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
        #region FORM METHODS

        protected Guid selectedRowID()
        {
            return (Guid)grid.SelectedRows[0].Cells[col_grid_id.Name].Value;
        }

        private void updateModeButtonsAvailabilityForGridRow()
        {
            btnUpdate.Enabled = false;
            btnAddItems.Enabled = false;
            btnSetPrice.Enabled = false;
            pbLog.Enabled = false;

            if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
            {
                if (GlobalData.UserAccount.role != Roles.User)
                {
                    btnUpdate.Enabled = true;
                    pbLog.Enabled = true;
                }

                btnAddItems.Enabled = true;
                btnSetPrice.Enabled = true;
            }
        }
        
        private void populateGridview(bool reloadFromDB)
        {
            DataView dvw;
            if (!reloadFromDB)
                dvw = (DataView)grid.DataSource;
            else
            {
                dvw = Inventory.get(chkIncludeInactive.Checked, chkLast3Months.Checked,
                    null,
                    iclb_ProductStoreNames.getCheckedItemsInArrayTable(ProductStoreName.COL_DB_ID),
                    iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID),
                    iclb_ProductWidths.getCheckedItemsInArrayTable(ProductWidth.COL_DB_ID),
                    iclb_LengthUnits.getCheckedItemsInArrayTable(LengthUnit.COL_DB_ID),
                    iclb_Colors.getCheckedItemsInArrayTable(FabricColor.COL_DB_ID),
                    _vendorID,
                    null,
                    chkShowNotBookedOnly.Checked).DefaultView;
            }

            dvw.RowFilter = compileQuickSearchFilter();
            setGridviewDataSource(dvw);
            populateGridSummary();

            lblCounts.Visible = false;
        }

        private string compileQuickSearchFilter()
        {
            string filter = "";
            filter = Tools.compileQuickSearchFilter(itxt_QuickSearch.ValueText, fieldNamesForQuickSearch);
            //filter = Tools.append(filter, Tools.compileRowFilterString(clbGrades, Inventory.COL_DB_GRADEID, typeof(Guid)), "AND");
            //filter = Tools.append(filter, Tools.compileRowFilterString(clbProductWidths, Inventory.COL_DB_PRODUCTWIDTHID, typeof(Guid)), "AND");
            //filter = Tools.append(filter, Tools.compileRowFilterString(clbLengthUnits, Inventory.COL_DB_LENGTHUNITID, typeof(Guid)), "AND");
            //filter = Tools.append(filter, Tools.compileRowFilterString(clbProductStoreNames, Inventory.COL_PRODUCTSTORENAMEID, typeof(Guid)), "AND");
            //filter = Tools.append(filter, Tools.compileRowFilterString(clbColors, Inventory.COL_DB_COLORID, typeof(Guid)), "AND");
            return filter;
        }

        private void setGridviewDataSource(DataView dvw)
        {
            //detach event handlers to avoid triggering events
            grid.CellContentClick -= new System.Windows.Forms.DataGridViewCellEventHandler(grid_CellContentClick);

            Tools.saveGridviewKey(grid, col_grid_id.Name);

            Util.setGridviewDataSource(grid, dvw);

            Tools.selectGridviewPreviousKey(grid, col_grid_id.Name);

            //clear header checkboxes
            if(_selectCheckboxHeader != null) _selectCheckboxHeader.Checked = false;

            //reattach event handlers
            grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(grid_CellContentClick);
        }

        private void calculateSelections()
        {
            int qty = 0;
            decimal length = 0;
            decimal amount = 0;
            foreach(DataGridViewRow row in grid.Rows)
            {
                if(row.Cells[col_grid_select.Name].Value != null && (bool)row.Cells[col_grid_select.Name].Value)
                {
                    qty += Convert.ToInt16(row.Cells[col_grid_availablePcs.Name].Value);
                    length += Convert.ToDecimal(row.Cells[col_grid_availableQty.Name].Value);

                    if(chkCalculateBuyValue.Checked)
                        amount += Convert.ToDecimal(row.Cells[col_grid_availableQty.Name].Value) * Convert.ToDecimal(row.Cells[col_grid_buyPrice.Name].Value);
                    else
                        amount += Convert.ToDecimal(row.Cells[col_grid_availableQty.Name].Value) * Convert.ToDecimal(row.Cells[col_grid_sellPrice.Name].Value);
                }
            }
            lblCounts.Text = string.Format("Available: {0} pcs / {1:N2} = {2:N2}", qty, length, amount);
            lblCounts.Visible = true;
        }

        private void clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= clb_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += clb_ItemCheck;

            populateGridview(true);
        }
        
        private void CheckedListBox_ItemChecked(object sender, EventArgs e)
        {
            populateGridview(true);
        }

        private void chkLast3Months_CheckedChanged(object sender, EventArgs e)
        {
            populateGridview(true);
        }
        
        private void chkRearrange_CheckedChanged(object sender, EventArgs e)
        {
            int widthOffset = 0;
            chkShowHidden.Checked = chkRearrange.Checked;
            chkLast3Months.Checked = chkRearrange.Checked;
            chkIncludeInactive.Checked = chkRearrange.Checked;
            _selectCheckboxHeader.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_select.Width; col_grid_select.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_availablePcs.Width; col_grid_availablePcs.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_availableQty.Width; col_grid_availableQty.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_PONo.Width; col_grid_PONo.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_active.Width; col_grid_active.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_isConsignment.Width; col_grid_isConsignment.Visible = !chkRearrange.Checked;
            widthOffset += col_grid_OpnameMarker.Width; col_grid_OpnameMarker.Visible = !chkRearrange.Checked;
            if (chkRearrange.Checked)
            {
                grid.Sort(col_grid_code, ListSortDirection.Ascending);
                grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count-1;
                grid.ClearSelection();
                grid.Rows[grid.Rows.Count - 1].Selected = true;
                this.Width -= widthOffset;
            }
            else
            {
                grid.Sort(col_grid_code, ListSortDirection.Descending);
                grid.FirstDisplayedScrollingRowIndex = 0;
                grid.ClearSelection();
                grid.Rows[0].Selected = true;
                this.Width += widthOffset;
            }
        }

        private void chkShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            col_grid_buyPrice.Visible = chkShowHidden.Checked;
        }

        private void btnCancelUpdateBuyPrice_Click(object sender, EventArgs e)
        {
            in_BuyPrice.Value = 0;
            pnlUpdateBuyPrice.Visible = false;
        }

        private void btnUpdateBuyPrice_Click(object sender, EventArgs e)
        {
            Inventory.updateBuyPrice(_clickedInventoryID, in_BuyPrice.ValueDecimal);
            in_BuyPrice.Value = 0;
            pnlUpdateBuyPrice.Visible = false;
            populateGridview(true);
        }

        private void in_BuyPrice_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnUpdateBuyPrice.PerformClick();
        }

        private void btnClearQtyZeroes_Click(object sender, EventArgs e)
        {
            Inventory.deactivateQtyZeroes();
            populateGridview(true);
        }

        private void PtSummary_pictureBox_ClickEvent(object sender, EventArgs e)
        {
            populateGridSummary();
        }

        private void ChkShowNotBookedOnly_CheckedChanged(object sender, EventArgs e)
        {
            populateGridview(true);
        }

        private void PbLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(selectedRowID()));
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            populateGridview(true);
        }

        private void Itxt_QuickSearch_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                populateGridview(false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                if (Util.copyContentToClipboardIfGridview(this))
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION
        #endregion SUBMISSION
        /*******************************************************************************************************/

    }
}
