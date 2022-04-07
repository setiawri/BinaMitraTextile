using System;
using System.Data;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.InventoryForm
{
    public partial class StockOpname_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES        

        DateTime _lastKeystroke = new DateTime(0);
        bool isScanner = false;

        public const string BARCODE_RESET = "RESET";

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION
        public StockOpname_Form()
        {
            InitializeComponent();
        }

        private void ItemCheck_Submit_Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateGridDetail();
            txtItemLocation.Text = getItemLocation();
        }

        private void ItemCheck_Submit_Form_Shown(object sender, EventArgs e)
        {
            Grade.populateInputControlCheckedListBox(iclb_Grades, false);
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            InventoryItemCheck.CheckCleanup();

            lblMessage.Text = "";
            in_Floor.Enabled = false;
            in_Rack.Enabled = false;
            in_Row.Enabled = false;
            in_Column.Enabled = false;

            gridDetail.AutoGenerateColumns = false;
            col_gridDetails_inventoryItemID.DataPropertyName = InventoryItemCheck.COL_DB_INVENTORYITEMID;
            col_gridDetails_itemsellprice.DataPropertyName = InventoryItemCheck.COL_TAGPRICE;
            col_gridDetail_OpnameMarker.DataPropertyName = InventoryItemCheck.COL_OPNAMEMARKER;
            col_gridDetail_ItemLocation.DataPropertyName = InventoryItemCheck.COL_DB_ItemLocation;
            col_gridDetail_inventory_Id.DataPropertyName = InventoryItemCheck.COL_INVENTORYID;

            gridSummaryCheck.AutoGenerateColumns = false;
            col_gridSummary_inventoryID.DataPropertyName = InventoryItemCheck.COL_INVENTORYID;

            dgvSummary.AutoGenerateColumns = false;
            dgvSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_dgvSummary_code.DataPropertyName = "code";
            col_dgvSummary_color_name.DataPropertyName = "color_name";
            col_dgvSummary_grade_name.DataPropertyName = "grade_name";
            col_dgvSummary_length_unit_name.DataPropertyName = "length_unit_name";
            col_dgvSummary_product_store_name.DataPropertyName = "product_store_name";
            col_dgvSummary_product_width_name.DataPropertyName = "product_width_name";
            col_dgvSummary_total_length.DataPropertyName = "total_item_length";
            col_dgvSummary_total_qty.DataPropertyName = "total_item_qty";

            gridMissingItems.AutoGenerateColumns = false;
            gridMissingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridMissingItems_InventoryDate.DataPropertyName = "inventory_receivedate";
            col_gridMissingItems_InventoryCode.DataPropertyName = "inventory_code";
            col_gridMissingItems_Inventory_Id.DataPropertyName = "inventory_id";
            col_gridMissingItems_Barcode.DataPropertyName = "barcode";
            col_gridMissingItems_ColorName.DataPropertyName = "color_name";
            col_gridMissingItems_GradeName.DataPropertyName = "grade_name";
            col_gridMissingItems_UnitName.DataPropertyName = "length_unit_name";
            col_gridMissingItems_ProductName.DataPropertyName = "product_store_name";
            col_gridMissingItems_ProductWidth.DataPropertyName = "product_width_name";
            col_gridMissingItems_ItemLength.DataPropertyName = "item_length";
            col_gridMissingItems_LastOpname.DataPropertyName = "last_opname";
            col_gridMissingItems_ItemLocation.DataPropertyName = "ItemLocation";

            resetFilters();

            createTooltip(chkCheckListBeforeSubmit, "Yang di scan akan di cek ke list barcode. Gunakan kalau opname lebih dari 1 hari.");
        }

        public static void createTooltip(Control control, string message)
        {
            ToolTip toolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(control, message);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void populateGridDetail()
        {
            col_gridSummary_inventory_code.DataPropertyName = InventoryItem.COL_DB_INVENTORY_CODE;
            DataView dvwItems = InventoryItemCheck.getAll(Tools.getDateTime(dtpStartDate1, false), Tools.getDateTime(dtpEndDate1, true), chkAllUsers.Checked, chkIgnoreSold.Checked).DefaultView;
            gridDetail.DataSource = filterData(dvwItems);
            DataTable dt = dvwItems.ToTable();
            Inventory.setCount(lblTotalCounts, dt.Rows.Count.ToString(), dt.Compute(String.Format("SUM({0})", InventoryItem.COL_DB_LENGTH), "").ToString());
            if (!string.IsNullOrEmpty(lblTotalCounts.Text))
                lblTotalCounts.Text += string.Format(" ({0:N0} manual)", dt.Compute(String.Format("COUNT({0})", InventoryItem.COL_DB_LENGTH), InventoryItemCheck.COL_DB_MANUALINPUT + "=1"));

            //populateGridSummary();
        }

        private void populateGridSummary()
        {
            DataTable dt = gridDetail.DataSource as DataTable;
            gridSummaryCheck.DataSource = InventoryItemCheck.compileSummaryData(dt);
            //Inventory.setCount(lblTotalCounts, dt.Rows.Count.ToString(), dt.Compute(String.Format("SUM({0})", InventoryItem.COL_LENGTH), "").ToString());
        }

        private DataView filterData(DataView dvw)
        {
            dvw.RowFilter = string.Format(" {0} > '{1}' ", InventoryItemCheck.COL_TIMESTAMP, Tools.getDateTime(dtpStartDate1, false));

            if (dtpEndDate1.Checked)
            {
                dvw.RowFilter = Tools.append(dvw.RowFilter, string.Format(" {0} < '{1}' ", InventoryItemCheck.COL_TIMESTAMP, Tools.getDateTime(dtpEndDate1, false)), " AND ");
            }

            return dvw;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        private void btnCompareToInventory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            chkIgnoreSold.Checked = false;
            populateGridDetail();
            col_gridSummary_inventory_code.DataPropertyName = Inventory.COL_DB_CODE;
            gridSummaryCheck.DataSource = filterCompleteSummary(InventoryItemCheck.compileCompleteData(((DataView)gridDetail.DataSource).Table).DefaultView);
            Cursor.Current = Cursors.Default;
        }

        private DataView filterCompleteSummary(DataView dvw)
        {
            string filter = "";
            if (chkExcludeZeroDiffsFromCompleteSummary.Checked)
            {
                filter = string.Format("{0} > 0 OR {0} < 0 OR {1} > 0 OR {1} < 0", InventoryItemCheck.COL_COUNT_DIFF_QTY, InventoryItemCheck.COL_COUNT_DIFF_LENGTH);
            }
            dvw.RowFilter = filter;
            return dvw;
        }

        private void chkExcludeZeroDiffsFromCompleteSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (gridSummaryCheck.DataSource != null)
                gridSummaryCheck.DataSource = filterCompleteSummary((DataView)gridSummaryCheck.DataSource);
        }

        private void gridSummary1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridSummary_inventory_code.Name))
            {
                Tools.displayForm(new InventoryForm.Items_Form((Guid)LIBUtil.Util.getClickedRowValue(sender, e, col_gridSummary_inventoryID)));
            }
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            // check timing to identify barcode scanner
            double delay = (DateTime.Now - _lastKeystroke).TotalMilliseconds;
            if (delay < Settings.barcodeScannerDelay)
                isScanner = true;

            if (e.KeyData == Keys.Enter)
            {
                txtBarcode.Text = txtBarcode.Text.Trim();
                if (!chkRequestBarcode.Checked)
                    addBarcode(!isScanner);
                else
                {
                    string request = string.Format("Barcode request at {0}: {1}", txtItemLocation.Text, InventoryItem.getBarcodeWithoutPrefix(txtBarcode.Text));
                    ToDo.add(request, null, null);
                    chkRequestBarcode.Checked = false;
                    lblMessage.Text = request;
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                }

                isScanner = false;
            }

            _lastKeystroke = DateTime.Now;
        }

        private void addBarcode(bool isManualInput)
        {
            string barcodeInput = txtBarcode.Text;
            if (string.IsNullOrEmpty(barcodeInput))
                return;
            else if (barcodeInput == BARCODE_RESET)
            {
                btnReset1.PerformClick();
                txtBarcode.Text = "";
                txtBarcode.Focus();
                return;
            }

            string barcodeWithoutPrefix = InventoryItem.getBarcodeWithoutPrefix(barcodeInput);

            //in case opname span more than 1 day, the checkbox can be used to verify the barcode is not in the list of loaded scans from previous days
            if (chkCheckListBeforeSubmit.Checked)
            {
                DataView list = Util.getDataTable(gridDetail.DataSource).Copy().DefaultView;                   
                list.RowFilter = string.Format("{0} = '{1}'", InventoryItemCheck.COL_BARCODE, barcodeWithoutPrefix);
                if (list.Count > 0)
                {
                    LIBUtil.Util.displayMessageBoxError("Sudah ada di list");
                    return;
                }
            }

            if (isManualInput)
            {
                Settings.nonBarcodeScannerSound.Play();
                if (LIBUtil.Util.displayMessageBoxYesNo("Tidak terdeteksi menggunakan scanner. Coba lagi?"))
                    return;
            }

            displayMessage(InventoryItemCheck.submitNew(barcodeWithoutPrefix, isManualInput, chkRescanToday.Checked, chkIgnoreSold.Checked, txtItemLocation.Text));
            

            if (!chkDoNotLoadList.Checked)
            {
                populateGridDetail();
                if (tcSummary.SelectedTab == tpSummary)
                    btnGenerateSummary.PerformClick();
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void displayMessage(string message)
        {
            lblMessage.Text = message;
            LIBUtil.Util.displayMessageBoxError(message);
            lblMessage.Text = "";
        }

        private string record(DateTime start)
        {
            return Environment.NewLine + "elapsed: " + (DateTime.Now - start);
        }
        
        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS

        private void resetFilters()
        {
            dtpStartDate1.Value = Util.getServerTime();
            dtpEndDate1.Value = Util.getServerTime();
            dtpEndDate1.Checked = false;
            gridDetail.DataSource = null;
            gridSummaryCheck.DataSource = null;
            gridMissingItems.DataSource = null;
            dgvSummary.DataSource = null;
            lblTotalCounts.Text = "";
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            resetFilters();
            txtBarcode.Focus();
        }

        private void btnLoad1_Click(object sender, EventArgs e)
        {
            gridSummaryCheck.DataSource = null;
            gridMissingItems.DataSource = null;
            populateGridDetail();
            txtBarcode.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnLoad1.PerformClick();
            txtBarcode.Focus();
        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            dgvSummary.DataSource = InventoryItemCheck.getSummary(Tools.getDateTime(dtpStartDate1, false), Tools.getDateTime(dtpEndDate1, true), chkAllUsers.Checked);
            txtBarcode.Focus();
        }

        private void btnDeleteTodayData_Click(object sender, EventArgs e)
        {
            if(LIBUtil.Util.displayMessageBoxYesNo("Are you sure?"))
            {
                InventoryItemCheck.deleteTodayData();
                populateGridDetail();
                dgvSummary.DataSource = null;
            }
            txtBarcode.Focus();
        }

        private void chkIgnoreSold_CheckedChanged(object sender, EventArgs e)
        {
            lblSoldItemsExcluded.Visible = !chkIgnoreSold.Checked;
            txtBarcode.Focus();
        }

        private void btnDeleteIgnoreSold_Click(object sender, EventArgs e)
        {
            if (LIBUtil.Util.displayMessageBoxYesNo("Are you sure?"))
            {
                InventoryItemCheck.deleteIgnoreSold();
                gridDetail.DataSource = null;
                gridSummaryCheck.DataSource = null;
                lblTotalCounts.Text = "";
                btnLoad1.PerformClick();
            }
            txtBarcode.Focus();
        }

        private void chkShowDeleteTodayData_CheckedChanged(object sender, EventArgs e)
        {
            btnDeleteTodayData.Visible = chkShowDeleteTodayData.Checked;
        }

        private void dtpStartDate1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TcSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tcSummary.SelectedTab == tpMissingInventoryItems && gridMissingItems.RowCount == 0)
                populateMissingInventoryItems();
            txtBarcode.Focus();
        }

        private void BtnRefreshMissingInventoryItems_Click(object sender, EventArgs e)
        {
            populateMissingInventoryItems();
        }
        
        private void populateMissingInventoryItems()
        {
            gridMissingItems.DataSource = InventoryItemCheck.getMissing(Tools.getDate(dtpStartDate1, false), iclb_Grades.getCheckedItemsInArrayTable(Grade.COL_DB_ID));
        }

        private void ChkDoNotLoadList_CheckedChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void BtnItemLocation_Click(object sender, EventArgs e)
        {
            if (sender == btnFloorLess)
                updateLocation(in_Floor, false);
            else if (sender == btnFloorMore)
                updateLocation(in_Floor, true);
            else if (sender == btnRackLess)
                updateLocation(in_Rack, false);
            else if (sender == btnRackMore)
                updateLocation(in_Rack, true);
            else if (sender == btnRowLess)
                updateLocation(in_Row, false);
            else if (sender == btnRowMore)
                updateLocation(in_Row, true);
            else if (sender == btnColumnLess)
                updateLocation(in_Column, false);
            else if (sender == btnColumnMore)
                updateLocation(in_Column, true);

            txtItemLocation.Text = getItemLocation();
            txtBarcode.Focus();
        }

        private void updateLocation(LIBUtil.Desktop.UserControls.InputControl_Numeric input, bool isIncrease)
        {
            if (input.Value == 9 && isIncrease)
                input.Value = 1;
            else if (input.Value == 1 && !isIncrease)
                input.Value = 9;
            else if (isIncrease)
                input.Value += 1;
            else
                input.Value -= 1;
        }

        private string getItemLocation()
        {
            if (chkNonRack.Checked)
                return string.Format("{0}{1}", in_Floor.ValueInt, in_Rack.ValueInt);
            else
                return string.Format("{0}{1}{2}{3}", in_Floor.ValueInt, in_Rack.ValueInt, in_Row.ValueInt, in_Column.ValueInt);
        }

        private void ChkNonRack_CheckedChanged(object sender, EventArgs e)
        {
            btnRowLess.Enabled = !chkNonRack.Checked;
            btnRowMore.Enabled = !chkNonRack.Checked;
            btnColumnLess.Enabled = !chkNonRack.Checked;
            btnColumnMore.Enabled = !chkNonRack.Checked;

            txtItemLocation.Text = getItemLocation();
            txtBarcode.Focus();
        }

        private void ChkCheckListBeforeSubmit_CheckedChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void GridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LIBUtil.Util.isColumnMatch(sender, e, col_gridDetail_barcode))
                LIBUtil.Util.displayForm(null, new InventoryForm.Items_Form((Guid)LIBUtil.Util.getRowValue(gridDetail.Rows[e.RowIndex], col_gridDetail_inventory_Id)));
        }

        private void ChkRescanToday_CheckedChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void GridMissingItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridMissingItems_InventoryCode.Name))
            {                
                Tools.displayForm(new InventoryForm.Items_Form((Guid)LIBUtil.Util.getClickedRowValue(sender, e, col_gridMissingItems_Inventory_Id)));
            }
        }

        private void Iclb_Grades_Item_Checked(object sender, EventArgs e)
        {
            populateMissingInventoryItems();
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

        private void chkRequestBarcode_CheckedChanged(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION
        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region PRINT METHODS
        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
