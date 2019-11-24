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
    public partial class ItemCheck_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES        
        
        DateTime _lastKeystroke = new DateTime(0);
        bool isScanner = false;

        public const string BARCODE_RESET = "RESET";

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION
        public ItemCheck_Form()
        {
            InitializeComponent();
        }

        private void ItemCheck_Submit_Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateGridDetail();
        }

        private void setupControls()
        {
            InventoryItemCheck.CheckCleanup();

            gridDetail.AutoGenerateColumns = false;
            col_gridDetails_inventoryItemID.DataPropertyName = InventoryItemCheck.COL_DB_INVENTORYITEMID;
            col_gridDetails_itemsellprice.DataPropertyName = InventoryItemCheck.COL_TAGPRICE;
            col_gridDetail_OpnameMarker.DataPropertyName = InventoryItemCheck.COL_OPNAMEMARKER;

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
            col_gridMissingItems_InventoryDate.DataPropertyName = "date";
            col_gridMissingItems_InventoryCode.DataPropertyName = "inventory_receivedate";
            col_gridMissingItems_Barcode.DataPropertyName = "barcode";
            col_gridMissingItems_ColorName.DataPropertyName = "color_name";
            col_gridMissingItems_GradeName.DataPropertyName = "grade_name";
            col_gridMissingItems_UnitName.DataPropertyName = "length_unit_name";
            col_gridMissingItems_ProductName.DataPropertyName = "product_store_name";
            col_gridMissingItems_ProductWidth.DataPropertyName = "product_width_name";
            col_gridMissingItems_ItemLength.DataPropertyName = "item_length";
            col_gridMissingItems_LastOpname.DataPropertyName = "last_opname";

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
            col_gridSummary_inventory_code.DataPropertyName = InventoryItem.COL_INVENTORY_CODE;
            DataView dvwItems = InventoryItemCheck.getAll(Tools.getDateTime(dtpStartDate1, false), Tools.getDateTime(dtpEndDate1, true), chkAllUsers.Checked, chkIgnoreSold.Checked).DefaultView;
            gridDetail.DataSource = filterData(dvwItems);
            DataTable dt = dvwItems.ToTable();
            Inventory.setCount(lblTotalCounts, dt.Rows.Count.ToString(), dt.Compute(String.Format("SUM({0})", InventoryItem.COL_LENGTH), "").ToString());
            if (!string.IsNullOrEmpty(lblTotalCounts.Text))
                lblTotalCounts.Text += string.Format(" ({0:N0} manual)", dt.Compute(String.Format("COUNT({0})", InventoryItem.COL_LENGTH), InventoryItemCheck.COL_DB_MANUALINPUT + "=1"));

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
            if(gridSummaryCheck.DataSource != null)
                gridSummaryCheck.DataSource = filterCompleteSummary((DataView)gridSummaryCheck.DataSource);
        }

        private void gridSummary1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridSummary_inventory_code.Name))
            {
                Tools.displayForm(new InventoryForm.Items_Form((Guid)gridSummaryCheck.Rows[e.RowIndex].Cells[col_gridSummary_inventoryID.Name].Value));
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
                addBarcode(!isScanner);
                isScanner = false;
            }

            _lastKeystroke = DateTime.Now;
        }

        private void addBarcode(bool isManualInput)
        {
            txtBarcode.Text = txtBarcode.Text.Trim();
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
                DataView list = (DataView)gridDetail.DataSource;
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

            LIBUtil.Util.displayMessageBoxError(InventoryItemCheck.submitNew(barcodeWithoutPrefix, isManualInput, chkIgnoreSold.Checked));

            if(!chkDoNotLoadList.Checked)
            {
                populateGridDetail();
                if (tcSummary.SelectedTab == tpSummary)
                    btnGenerateSummary.PerformClick();
            }

            txtBarcode.Text = "";
            txtBarcode.Focus();
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
            dtpStartDate1.Value = DBUtil.getServerTime();
            dtpEndDate1.Value = DBUtil.getServerTime();
            dtpEndDate1.Checked = false;
            gridDetail.DataSource = null;
            gridSummaryCheck.DataSource = null;
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
            populateGridDetail();
            txtBarcode.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnLoad1.PerformClick();
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
            if(tcSummary.SelectedTab == tpMissingInventoryItems)
                populateMissingInventoryItems();
        }

        private void BtnRefreshMissingInventoryItems_Click(object sender, EventArgs e)
        {
            populateMissingInventoryItems();
        }
        
        private void populateMissingInventoryItems()
        {
            gridMissingItems.DataSource = InventoryItemCheck.getMissing(Tools.getDate(dtpStartDate1, false));
        }

        private void ChkDoNotLoadList_CheckedChanged(object sender, EventArgs e)
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
