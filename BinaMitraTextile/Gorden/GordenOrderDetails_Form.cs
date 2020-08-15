using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Gorden
{
    public partial class GordenOrderDetails_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private GordenOrder _order;

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public GordenOrderDetails_Form(Guid id)
        {
            InitializeComponent();

            _order = new GordenOrder(id);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
        }

        private void populatePageData()
        {
            populateGridviews();
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void menu_items_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Gorden.GordenItems_Form(FormMode.New, null));
        }

        private void menu_new_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Gorden.Gorden_Add_Edit_Form());
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateGridviews();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void gridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridorders_orderno.Name))
            //{
            //    Tools.displayForm(this, new Gorden.GordenOrderPrint_Form((Guid)gridOrders.Rows[e.RowIndex].Cells[col_gridorders_id.Name].Value));
            //}
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
        #region FORM METHODS

        private void populateGridviews()
        {
            //Tools.populateDataGridView(gridOrders, GordenOrder.get(null, Util.wrapNullable<int?>(txtOrderNo.Text), Util.wrapNullable<Guid?>(dropCustomers.SelectedValue), null));
        }

        #endregion
        /*******************************************************************************************************/
    }
}
