using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;

namespace BinaMitraTextile.Sales
{
    public partial class PackingList_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private static Sale _sale;
        private static SaleReturn _saleReturn;
        private DataTable _data;

        private const int MAX_ITEMS_PER_COLUMN = 15;
        private const int MAX_ITEMS_PER_PAGE = MAX_ITEMS_PER_COLUMN * 3;

        private int _currentPageNo = 1;
        private int _totalPageCount = 1;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public PackingList_Form(Guid SaleID)
        {
            InitializeComponent();

            _sale = new Sale(SaleID);
            Tools.disableResizing(this);
        }

        public PackingList_Form(SaleReturn saleReturn)
        {
            InitializeComponent();

            _saleReturn = saleReturn;
            Tools.disableResizing(this);
        }

        private void populatePage()
        {
            if(_sale != null)
            {
                lblInvoiceNo.Text = _sale.barcode;
                lblTransportName.Text = _sale.TransportName;

                lblDate.Text = String.Format("{0:dd/MM/yy hh:mm}", _sale.time_stamp);
                lblCustomerInfo.Text = _sale.customer_info;

                //list of item barcodes
                _data = Tools.sortData(_sale.sale_items, SaleItem.COL_INVENTORYCODE, SortOrder.Ascending, SaleItem.COL_BARCODE, SortOrder.Ascending);
            }
            else
            {
                lblInvoiceNo.Text = _saleReturn.barcode;
                lblDate.Text = String.Format("{0:dd/MM/yy hh:mm}", _saleReturn.time_stamp);
                lblCustomerInfo.Text = _saleReturn.customer_info;

                _data = Tools.sortData(SaleItem.getReturnedItems(_saleReturn.id), SaleReturn.COL_INVENTORYCODE, SortOrder.Ascending, SaleReturn.COL_BARCODE, SortOrder.Ascending);
            }
            
            _totalPageCount = (int)Math.Ceiling((decimal)_data.Rows.Count / MAX_ITEMS_PER_PAGE);
            populateGrids();

            Inventory.setCount(lblTotalCounts, _data.Rows.Count.ToString(), _data.Compute(String.Format("SUM({0})", InventoryItem.COL_LENGTH), "").ToString());
            lblTotalCounts.Text = "Total: " + lblTotalCounts.Text;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            populatePage();
            //Tools.adjustGridviewForVScrollbar(this,true);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LISTS

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        private void populateGrids()
        {
            //fill up left columns first before filling up the next column
            int startIdx = (_currentPageNo-1) * MAX_ITEMS_PER_PAGE;
            fillGrid(grid1, _data, startIdx);
            fillGrid(grid2, _data, startIdx + grid1.Rows.Count);
            fillGrid(grid3, _data, startIdx + grid1.Rows.Count + grid2.Rows.Count);
            setPaging(_data.Rows.Count);

            lblPageCount.Text = string.Format("Halaman {0}/{1}", _currentPageNo, _totalPageCount);

            //divide items into 3 columns evenly
            //int countPerColumn = (int)Math.Floor((double)dt.Rows.Count / 3);
            //int firstColumnCount = dt.Rows.Count - (countPerColumn * 2);
            //grid1.AutoGenerateColumns = false;
            //grid1.DataSource = Tools.copyTableRows(dt, 0, firstColumnCount);
            //grid2.AutoGenerateColumns = false;
            //grid2.DataSource = Tools.copyTableRows(dt, firstColumnCount, countPerColumn);
            //grid3.AutoGenerateColumns = false;
            //grid3.DataSource = Tools.copyTableRows(dt, firstColumnCount + countPerColumn, countPerColumn);
        }

        #endregion LISTS
        /*******************************************************************************************************/
        #region FORM METHODS
            
        private void setPaging(int intRowCount)
        {
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            if (intRowCount > MAX_ITEMS_PER_PAGE)
            {
                if (_currentPageNo < _totalPageCount)
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                if (_currentPageNo > 1)
                {
                    btnFirst.Enabled = true;
                    btnPrevious.Enabled = true;
                }
            }
            //Tools.rearrangeButtonsInPanel(pnlButtons, HorizontalAlignment.Center);
        }

        private void fillGrid(DataGridView grid, DataTable dt, int startIdx)
        {
            grid.AutoGenerateColumns = false;
            if ((dt.Rows.Count - startIdx) >= MAX_ITEMS_PER_COLUMN)
            {
                grid.DataSource = Tools.copyTableRows(dt, startIdx, MAX_ITEMS_PER_COLUMN);
            }
            else
            {
                grid.DataSource = Tools.copyTableRows(dt, startIdx, dt.Rows.Count - startIdx);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPageNo += 1;
            populateGrids();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentPageNo -= 1;
            populateGrids();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            _currentPageNo = 1;
            populateGrids();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            while (btnNext.Enabled)
                btnNext.PerformClick();
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!chkPrintAllPages.Checked)
                LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
            else
            {
                _currentPageNo = 1;
                populateGrids();
                LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
                while (btnNext.Enabled)
                {
                    btnNext.PerformClick();
                    LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
                }
            }
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
