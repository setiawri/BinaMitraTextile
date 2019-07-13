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

namespace BinaMitraTextile.Returns
{
    public partial class Print_Form : Form
    {
        /*******************************************************************************************************/

        #region CLASS VARIABLES

        private SaleReturn _saleReturn;

        #endregion CLASS VARIABLES

        /*******************************************************************************************************/

        #region INITIALIZATION

        public Print_Form(Guid SaleReturnID)
        {
            InitializeComponent();

            _saleReturn = new SaleReturn(SaleReturnID);
            setupControls();
            populatePage();

            Tools.rearrangeButtonsInPanel(pnlButtons, HorizontalAlignment.Center);
            Tools.disableResizing(this);
        }

        private void setupControls()
        {
            this.Text += DBUtil.appendTitleWithInfo();

            grid.AutoGenerateColumns = false;
            Tools.clearWhenSelected(grid);
            col_grid_priceperunit.DataPropertyName = SaleReturn.COL_PRICEPERUNIT;
        }

        private void populatePage()
        {
            lblReturnNo.Text = _saleReturn.barcode;
            lblDate.Text = String.Format("{0:dd/MM/yy hh:mm}", _saleReturn.time_stamp);

            //customer info
            lblCustomerInfo.Text = _saleReturn.customer_info;

            //sale summary
            grid.AutoGenerateColumns = false;
            DataTable dt = SaleItem.getReturnedItemSummary(_saleReturn.id);
            grid.DataSource = dt;

            Inventory.setAmount(lblTotalAmount, dt.Compute(String.Format("SUM({0})", SaleItem.COL_SUBTOTAL), "").ToString());
            Inventory.setCount(lblTotalCounts, dt.Compute(String.Format("SUM({0})", SaleItem.COL_QTY), "").ToString(), dt.Compute(String.Format("SUM({0})", SaleItem.COL_LENGTH), "").ToString());

            //notes
            lblNotes.Text = _saleReturn.notes;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //Tools.adjustGridviewForVScrollbar(this,true);
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void btnPackingList_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Sales.PackingList_Form(_saleReturn));
        }

        #endregion
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LIBUtil.Util.print(false, false, pnlPrint);
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/


    }
}
