using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.POs
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public Guid browseItemSelection;
        public string browseItemDescription;
        public string browseItemPricePerUnit;

        private FormMode _formMode = FormMode.Search;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form() : this(FormMode.Search) { }

        public Main_Form(FormMode formMode)
        {
            InitializeComponent();

            _formMode = formMode;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            if (_formMode == FormMode.Search)
            {
                Vendor.populateDropDownList(cbVendors, false, true);
                Tools.populateDropDownList(cbStatus, typeof(POItemStatus));
                ProductStoreName.populateDropDownList(cbProductStoreNames, false, false);
            }
            else if(_formMode == FormMode.Browse)
            {
                //scMain.Panel1Collapsed = true;
                scMain.Visible = false;
            }

            gridPO.AutoGenerateColumns = false;
            gridPO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPO_id.DataPropertyName = PO.COL_DB_ID;
            col_gridPO_po_no.DataPropertyName = PO.COL_DB_PONO;
            col_gridPO_timestamp.DataPropertyName = PO.COL_DB_TIMESTAMP;
            col_gridPO_vendorID.DataPropertyName = PO.COL_DB_VENDORID;
            col_gridPO_amount.DataPropertyName = PO.COL_AMOUNT;
            col_gridPO_vendor_name.DataPropertyName = PO.COL_VENDORNAME;
            col_gridPO_notes.DataPropertyName = PO.COL_DB_NOTES;

            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPOItems_productDescription.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col_gridPOItems_id.DataPropertyName = POItem.COL_DB_ID;
            col_gridPOItems_no.DataPropertyName = POItem.COL_DB_LINENO;
            col_gridPOItems_date.DataPropertyName = POItem.COL_TIMESTAMP;
            col_gridPOItems_productDescription.DataPropertyName = POItem.COL_DB_PRODUCTDESCRIPTION;
            col_gridPOItems_notes.DataPropertyName = POItem.COL_DB_NOTES;
            col_gridPOItems_qty.DataPropertyName = POItem.COL_DB_QTY;
            col_gridPOItems_unitName.DataPropertyName = POItem.COL_DB_UNITNAME;
            col_gridPOItems_receivedQty.DataPropertyName = POItem.COL_RECEIVEDQTY;
            col_gridPOItems_pricePerUnit.DataPropertyName = POItem.COL_DB_PRICEPERUNIT;
            col_gridPOItems_subtotal.DataPropertyName = POItem.COL_SUBTOTAL;
            col_gridPOItems_statusEnumID.DataPropertyName = POItem.COL_DB_STATUSENUMID;
            col_gridPOItems_status_name.DataPropertyName = POItem.COL_STATUSNAME;
            col_gridPOItems_po_no.DataPropertyName = POItem.COL_PONO;

            addStatusContextMenu(col_gridPOItems_status_name);

            if(GlobalData.UserAccount.role == Roles.User)
            {
                col_gridPO_amount.Visible = false;
                col_gridPOItems_pricePerUnit.Visible = false;
                col_gridPOItems_subtotal.Visible = false;
                col_gridPOItems_notes.Visible = false;
            }

            dtpStart.Checked = true;
            dtpStart.Value = DateTime.Today.AddMonths(-3);
            dtpEnd.Checked = false;
        }

        private void populatePageData()
        {
            if (_formMode == FormMode.Search)
            {
                populateGridPO();
            }
            else if (_formMode == FormMode.Browse)
            {
                gridPOItems.DataSource = POItem.getIncompleteItems();
                col_gridPOItems_date.Visible = true;
                col_gridPOItems_no.Visible = false;
                col_gridPOItems_status_name.Visible = false;
                col_gridPOItems_productDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void gridPO_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = gridPO.HitTest(e.X, e.Y);
                gridPO.ClearSelection();
                gridPO.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void gridPO_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                    gridPO.Rows[e.RowIndex].Selected = true;
            }
        }

        private void gridPOItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.displayContextMenu(sender, e);
        }

        public void addStatusContextMenu(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (POItemStatus status in Tools.GetEnumItems<POItemStatus>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, changeStatus_Click));
        }

        public void changeStatus_Click(object sender, EventArgs args)
        {
            POItem.updateStatus(selectedPOItemsRowID(), Tools.parseEnum<POItemStatus>(sender.ToString()));
            populateGridPOItems();
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new POs.Add_Edit_Form());
            populateGridPO();
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS

        private void updateModeButtonsAvailabilityForGridRow()
        {
            btnLog.Enabled = false;

            if (gridPO.Rows.Count > 0 && gridPO.SelectedRows.Count > 0)
            {
                btnLog.Enabled = true;
            }
        }
        
        private void populateGridPO()
        {
            gridPO.SelectionChanged -= new System.EventHandler(gridPO_SelectionChanged); //detach event handler

            DateTime? dtStart = null;
            DateTime? dtEnd = null;
            if(_formMode != FormMode.Browse)
            {
                dtStart = Tools.getDate(dtpStart, false);
                dtEnd = Tools.getDate(dtpEnd, true);
            }

            gridPO.DataSource = PO.get(null, DBUtil.sanitize(txtPONo), (Guid?)cbVendors.SelectedValue,
                dtStart, dtEnd, (Guid?)cbProductStoreNames.SelectedValue, DBUtil.sanitizeAndNullifyIfEmpty(txtInvoiceNo),
                DBUtil.sanitizeAndNullifyIfEmpty(txtPackingListNo), _formMode == FormMode.Browse);
            
            populateGridPOItems();
            
            gridPO.SelectionChanged += new System.EventHandler(gridPO_SelectionChanged); //reattach event handler
        }

        private void populateGridPOItems()
        {
            if(gridPO.SelectedRows.Count > 0)
                gridPOItems.DataSource = POItem.getItems(selectedRowID());
            else
                gridPOItems.DataSource = null;
        }

        protected Guid selectedRowID()
        {
            return (Guid)gridPO.SelectedRows[0].Cells[col_gridPO_id.Name].Value;
        }

        protected Guid selectedPOItemsRowID()
        {
            return (Guid)gridPOItems.SelectedRows[0].Cells[col_gridPOItems_id.Name].Value;
        }

        private void gridPO_SelectionChanged(object sender, EventArgs e)
        {
            populateGridPOItems();
        }

        private void gridPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
                Tools.displayForm(new POs.Print_Form((Guid)gridPO.Rows[e.RowIndex].Cells[col_gridPO_id.Name].Value));
        }

        private void gridPOItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && _formMode == FormMode.Browse)
            {
                DataGridViewRow row = gridPOItems.Rows[e.RowIndex];
                browseItemSelection = (Guid)row.Cells[col_gridPOItems_id.Name].Value; 
                browseItemDescription = string.Format("[{0}] {1}", row.Cells[col_gridPOItems_po_no.Name].Value.ToString(), row.Cells[col_gridPOItems_productDescription.Name].Value.ToString());
                browseItemPricePerUnit = row.Cells[col_gridPOItems_pricePerUnit.Name].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(selectedRowID()));
        }

        private void gridPO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            updateModeButtonsAvailabilityForGridRow();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateGridPO();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPONo.Text = "";
            txtPackingListNo.Text = "";
            txtInvoiceNo.Text = "";
            Tools.resetDropDownList(cbProductStoreNames);
            Tools.resetDropDownList(cbStatus);
            Tools.resetDropDownList(cbVendors);
            dtpEnd.Checked = false;
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
