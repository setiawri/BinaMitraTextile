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

namespace BinaMitraTextile.Gorden
{
    public partial class GordenOrderPrint_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        Guid _orderItemID;

        DataTable _orderItems = null;
        private int _currentPageNo = 1;
        private int _totalPageCount = -1;
        private List<int> _pagingStartIdx = new List<int>();

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public GordenOrderPrint_Form(Guid id)
        {
            InitializeComponent();
            _orderItemID = id;
        }
        
        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            this.Text += DBUtil.appendTitleWithInfo();
            Tools.disableResizing(this);

            //grid.Enabled = false;
            grid.AutoGenerateColumns = false;
            Tools.clearWhenSelected(grid);
            col_gridmain_id.DataPropertyName = GordenOrderItem.COL_DB_ID;
            col_gridmain_lineno.DataPropertyName = GordenOrderItem.COL_DB_LINENO;
            col_gridmain_description.DataPropertyName = GordenOrderItem.COL_DB_DESCRIPTION;
            Tools.setGridviewColumnWordwrap(col_gridmain_description);
            col_gridmain_qty.DataPropertyName = GordenOrderItem.COL_DB_QTY;
            col_gridmain_priceperunit.DataPropertyName = GordenOrderItem.COL_DB_SELLAMOUNTPERUNIT;
            col_gridmain_notes.DataPropertyName = GordenOrderItem.COL_DB_NOTES;
            col_gridmain_subtotal.DataPropertyName = GordenOrderItem.COL_SUBTOTAL;
        }

        private void populatePageData()
        {
            GordenOrder order = new GordenOrder(_orderItemID);

            lblNo.Text = order.NoHex;
            lblDate.Text = String.Format("{0:dd/MM/yy hh:mm}", order.Timestamp);

            //customer info
            lblCustomerInfo.Text = order.CustomerInfo;

            //notes
            lblNotes.Text = order.Notes;

            _orderItems = GordenOrderItem.getItems(_orderItemID);
            Tools.populateDataGridView(grid, _orderItems);

            lblTotalAmount.Text = string.Format("Total: Rp. {0:N2}", Tools.getSum(_orderItems, GordenOrderItem.COL_SUBTOTAL, ""));

            populatePagingStartIdx();
            setPaging(1);
        }

        #endregion
        /*******************************************************************************************************/
        #region FORM METHODS

        private void setPaging(int pageNo)
        {
            _currentPageNo = pageNo;
            lblPageCount.Text = string.Format("Halaman {0}/{1}", _currentPageNo, _totalPageCount);

            //set buttons visibility
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            if (_currentPageNo < _totalPageCount)
                btnNext.Enabled = true;
            if (_currentPageNo > 1)
                btnPrevious.Enabled = true;

            //setting to allow changing visibility of datagridview rows 
            CurrencyManager manager = (CurrencyManager)BindingContext[grid.DataSource];
            manager.SuspendBinding();

            //display rows
            hideAllRows();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index >= _pagingStartIdx[_currentPageNo - 1])
                {
                    if (_pagingStartIdx.Count > _currentPageNo)
                        if (row.Index == _pagingStartIdx[_currentPageNo])
                            break;

                    row.Visible = true;
                }
            }

            manager.ResumeBinding();
        }

        private void populatePagingStartIdx()
        {
            int pageCount = 1;
            _pagingStartIdx.Add(0);
            if (grid.Rows.Count > 1)
            {
                //setting to allow changing visibility of datagridview rows 
                CurrencyManager manager = (CurrencyManager)BindingContext[grid.DataSource];
                manager.SuspendBinding();

                hideAllRows();

                //iterate through rows and save the starting row index of every page
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!isVerticalScrollBarVisible())
                        row.Visible = true;
                    
                    if(isVerticalScrollBarVisible())
                    {
                        pageCount++;
                        _pagingStartIdx.Add(row.Index);

                        hideAllRows();
                        row.Visible = true;
                    }
                }
                
                manager.ResumeBinding();
            }
            _totalPageCount = pageCount;
        }

        private void hideAllRows()
        {
            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = false;
        }

        private void setRowVisibility(DataGridViewRow row, bool visible)
        {
            CurrencyManager manager = (CurrencyManager)BindingContext[grid.DataSource];
            manager.SuspendBinding();
            row.Visible = visible;
            manager.ResumeBinding();
        }

        private bool isVerticalScrollBarVisible()
        {
            bool isVisible = false;
            foreach (var scroll in grid.Controls.OfType<VScrollBar>())
                isVisible = scroll.Visible;

            return isVisible;
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void chkWorkOrder_CheckedChanged(object sender, EventArgs e)
        {
            lblCustomerInfo.Visible = !chkWorkOrder.Checked;
            col_gridmain_priceperunit.Visible = !chkWorkOrder.Checked;
            col_gridmain_subtotal.Visible = !chkWorkOrder.Checked;
            lblTotalAmount.Visible = !chkWorkOrder.Checked;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            setPaging(_currentPageNo - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            setPaging(_currentPageNo + 1);
        }

        #endregion
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/


    }
}
