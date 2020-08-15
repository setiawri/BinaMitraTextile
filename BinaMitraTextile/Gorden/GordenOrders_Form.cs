using System;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.Gorden
{
    public partial class GordenOrders_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public GordenOrders_Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            Customer.populateDropDownList(dropCustomers, false, false);

            gridOrders.AutoGenerateColumns = false;
            gridOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridorders_id.DataPropertyName = GordenOrder.COL_DB_ID;
            col_gridorders_timestamp.DataPropertyName = GordenOrder.COL_DB_TIMESTAMP;
            col_gridorders_orderno.DataPropertyName = GordenOrder.COL_NOHEX;
            col_gridorders_customername.DataPropertyName = GordenOrder.COL_CUSTOMERNAME;
            col_gridorders_orderamount.DataPropertyName = GordenOrder.COL_ORDERAMOUNT;
            col_gridorders_notes.DataPropertyName = GordenOrder.COL_DB_NOTES;

            Customer.populateDropDownList(dropCustomers, false, true);
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
            populatePageData();
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {

            populatePageData();
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
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridorders_orderno.Name))
            {
                Tools.displayForm(this, new Gorden.GordenOrderPrint_Form((Guid)gridOrders.Rows[e.RowIndex].Cells[col_gridorders_id.Name].Value));
            }
        }

        private void menu_details_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new GordenOrderDetails_Form((Guid)gridOrders.SelectedRows[0].Cells[col_gridorders_id.Name].Value));
            populatePageData();
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
        #region FORM METHODS

        private void populateGridviews()
        {
            Tools.populateDataGridView(gridOrders, GordenOrder.get(null, Util.wrapNullable<int?>(txtOrderNo.Text), Util.wrapNullable<Guid?>(dropCustomers.SelectedValue), null));
        }

        #endregion
        /*******************************************************************************************************/
    }
}
