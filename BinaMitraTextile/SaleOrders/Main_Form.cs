using System;
using System.Windows.Forms;

using System.Data;
using System.Collections.Generic;
using LIBUtil;

namespace BinaMitraTextile.SaleOrders
{
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public Guid browseItemSelection;
        public string browseItemDescription;
        public Guid browseItemCustomers_Id;

        private FormMode _formMode = FormMode.Search;
        private Guid? _Customers_Id;
        protected CheckBox _selectCheckboxHeader;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Main_Form() : this(FormMode.Search, null) { }

        public Main_Form(FormMode formMode, Guid? Customers_Id)
        {
            InitializeComponent();

            _formMode = formMode;
            _Customers_Id = Customers_Id;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            _selectCheckboxHeader = Tools.addHeaderCheckbox(gridInventoryItems, col_gridInventoryItems_Select, "_selectCheckboxHeader", selectCheckboxHeader_CheckedChanged);
            _selectCheckboxHeader.Click += new System.EventHandler(this._selectCheckboxHeader_Clieck);
            ptDetails.toggle();
            populatePageData();
        }

        private void setupControls()
        {
            if (_formMode == FormMode.Browse)
            {
                //scMain.Panel1Collapsed = true;
                scMain.Visible = false;
                ptDetails.Visible = false;
            }
            else
            {
                col_gridSaleOrderItems_CustomerName.Visible = false;
                col_gridSaleOrderItems_CustomerPONo.Visible = false;
            }

            gridSaleOrders.AutoGenerateColumns = false;
            gridSaleOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleOrders_id.DataPropertyName = SaleOrder.COL_DB_Id;
            col_gridSaleOrders_CustomerPONo.DataPropertyName = SaleOrder.COL_DB_CustomerPONo;
            col_gridSaleOrders_Timestamp.DataPropertyName = SaleOrder.COL_DB_Timestamp;
            col_gridSaleOrders_Customers_Id.DataPropertyName = SaleOrder.COL_DB_Customers_Id;
            col_gridSaleOrders_Amount.DataPropertyName = SaleOrder.COL_Amount;
            col_gridSaleOrders_Customers_Name.DataPropertyName = SaleOrder.COL_Customers_Name;
            col_gridSaleOrders_Notes.DataPropertyName = SaleOrder.COL_DB_Notes;
            col_gridSaleOrders_TargetDate.DataPropertyName = SaleOrder.COL_DB_TargetDate;

            gridSaleOrderItems.AutoGenerateColumns = false;
            gridSaleOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleOrderItems_Id.DataPropertyName = SaleOrderItem.COL_DB_Id;
            col_gridSaleOrderItems_CustomerPONo.DataPropertyName = SaleOrderItem.COL_CustomerPONo;
            col_gridSaleOrderItems_LineNo.DataPropertyName = SaleOrderItem.COL_DB_LineNo;
            col_gridSaleOrderItems_ProductDescription.DataPropertyName = SaleOrderItem.COL_DB_ProductDescription;
            col_gridSaleOrderItems_ProductDescription.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col_gridSaleOrderItems_Notes.DataPropertyName = SaleOrderItem.COL_DB_Notes;
            col_gridSaleOrderItems_Qty.DataPropertyName = SaleOrderItem.COL_DB_Qty;
            col_gridSaleOrderItems_ShippedQty.DataPropertyName = SaleOrderItem.COL_ShippedQty;
            col_gridSaleOrderItems_BookedQty.DataPropertyName = SaleOrderItem.COL_BookedQty;
            col_gridSaleOrderItems_RemainingQty.DataPropertyName = SaleOrderItem.COL_RemainingQty;
            col_gridSaleOrderItems_UnitName.DataPropertyName = SaleOrderItem.COL_DB_UnitName;
            col_gridSaleOrderItems_PricePerUnit.DataPropertyName = SaleOrderItem.COL_DB_PricePerUnit;
            col_gridSaleOrderItems_Subtotal.DataPropertyName = SaleOrderItem.COL_Subtotal;
            col_gridSaleOrderItems_StatusEnumID.DataPropertyName = SaleOrderItem.COL_DB_Status_enum_id;
            col_gridSaleOrderItems_Status_Name.DataPropertyName = SaleOrderItem.COL_StatusName;
            col_gridSaleOrderItems_Customers_Id.DataPropertyName = SaleOrderItem.COL_Customers_Id;
            col_gridSaleOrderItems_CustomerName.DataPropertyName = SaleOrderItem.COL_CustomerName;
            col_gridSaleOrderItems_POQty.DataPropertyName = SaleOrderItem.COL_POQty;

            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPOItems_PONo.DataPropertyName = POItem.COL_PONO;
            col_gridPOItems_id.DataPropertyName = POItem.COL_DB_ID;
            col_gridPOItems_LineNo.DataPropertyName = POItem.COL_DB_LINENO;
            col_gridPOItems_Qty.DataPropertyName = POItem.COL_DB_QTY;
            col_gridPOItems_Timestamp.DataPropertyName = POItem.COL_TIMESTAMP;
            col_gridPOItems_ReceivedQty.DataPropertyName = POItem.COL_RECEIVEDQTY;
            col_gridPOItems_RemainingQty.DataPropertyName = POItem.COL_PENDINGQTY;

            gridSales.AutoGenerateColumns = false;
            gridSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSales_Sales_Id.DataPropertyName = Sale.COL_ID;
            col_gridSales_Sales_Timestamp.DataPropertyName = Sale.COL_DB_Timestamp;
            col_gridSales_Sales_No.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSales_Sales_TotalQty.DataPropertyName = Sale.COL_totalQty;
            col_gridSales_Notes.DataPropertyName = Sale.COL_DB_Notes;

            gridInventory.AutoGenerateColumns = false;
            gridInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridInventory_Id.DataPropertyName = Inventory.COL_DB_ID;
            col_gridInventory_Code.DataPropertyName = Inventory.COL_DB_CODE;
            col_gridInventory_length.DataPropertyName = Inventory.COL_ITEMLENGTH;
            col_gridInventory_Notes.DataPropertyName = Inventory.COL_DB_NOTES;

            gridInventoryItems.AutoGenerateColumns = false;
            gridInventoryItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridInventoryItems_Id.DataPropertyName = InventoryItem.COL_ID;
            col_InventoryItems_Inventory_Code.DataPropertyName = InventoryItem.COL_INVENTORY_CODE;
            col_gridInventoryItems_barcode.DataPropertyName = InventoryItem.COL_BARCODE;
            col_gridInventoryItems_item_length.DataPropertyName = InventoryItem.COL_LENGTH;
            col_gridInventoryItems_Notes.DataPropertyName = InventoryItem.COL_NOTES;

            addStatusContextMenu(col_gridSaleOrderItems_Status_Name);

            if (GlobalData.UserAccount.role == Roles.User)
            {

            }

            dtpStart.Checked = true;
            dtpStart.Value = DateTime.Today.AddMonths(-3);
            dtpEnd.Checked = false;
        }

        private void populatePageData()
        {
            if (_formMode == FormMode.Search)
            {
                populateGridSaleOrders();
                if (gridSaleOrders.SelectedRows.Count > 0)
                    populateGridSaleOrderItems();
            }
            else if (_formMode == FormMode.Browse)
            {
                gridSaleOrderItems.DataSource = SaleOrderItem.get(null, null, _Customers_Id, true);
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void GridSaleOrderItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.displayContextMenu(sender, e);
        }

        public void addStatusContextMenu(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (SaleOrderItemStatus status in Tools.GetEnumItems<SaleOrderItemStatus>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, changeStatus_Click));
        }

        public void changeStatus_Click(object sender, EventArgs args)
        {
            SaleOrderItem.updateStatus(selectedSaleOrderItemsRowId(), Tools.parseEnum<SaleOrderItemStatus>(sender.ToString()));
            populateGridSaleOrderItems();
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new POs.Add_Edit_Form());
            populateGridSaleOrders();
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS

        private void updateModeButtonsAvailabilityForGridRow()
        {
            btnLog.Enabled = false;

            if (gridSaleOrders.Rows.Count > 0 && gridSaleOrders.SelectedRows.Count > 0)
            {
                btnLog.Enabled = true;
            }
        }
        
        private void populateGridSaleOrders()
        {
            gridSaleOrders.SelectionChanged -= new System.EventHandler(GridSaleOrders_SelectionChanged); //detach event handler

            DateTime? dtStart = null;
            DateTime? dtEnd = null;
            if(_formMode != FormMode.Browse)
            {
                dtStart = Tools.getDate(dtpStart, false);
                dtEnd = Tools.getDate(dtpEnd, true);
            }
            Util.setGridviewDataSource(gridSaleOrders, true, true, SaleOrder.get(null, null, txtCustomerPONo.Text.Trim(), dtStart, dtEnd, _formMode == FormMode.Browse || chkShowIncompleteOnly.Checked));
            
            gridSaleOrders.SelectionChanged += new System.EventHandler(GridSaleOrders_SelectionChanged); //reattach event handler
        }

        private void populateGridSaleOrderItems()
        {
            if(gridSaleOrders.SelectedRows.Count > 0)
                gridSaleOrderItems.DataSource = SaleOrderItem.get(selectedRowID(), null, _Customers_Id, false);
            else
                gridSaleOrderItems.DataSource = null;
        }

        protected Guid selectedRowID()
        {
            return (Guid)gridSaleOrders.SelectedRows[0].Cells[col_gridSaleOrders_id.Name].Value;
        }

        protected Guid selectedSaleOrderItemsRowId()
        {
            return (Guid)gridSaleOrderItems.SelectedRows[0].Cells[col_gridSaleOrderItems_Id.Name].Value;
        }

        private void GridSaleOrders_SelectionChanged(object sender, EventArgs e)
        {
            populateGridSaleOrderItems();
        }

        private void GridSaleOrderItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && _formMode == FormMode.Browse)
            {
                DataGridViewRow row = gridSaleOrderItems.Rows[e.RowIndex];
                browseItemSelection = (Guid)row.Cells[col_gridSaleOrderItems_Id.Name].Value; 
                browseItemDescription = string.Format("{0} Line {1}", row.Cells[col_gridSaleOrderItems_CustomerPONo.Name].Value.ToString(), row.Cells[col_gridSaleOrderItems_LineNo.Name].Value.ToString());
                browseItemCustomers_Id = (Guid)row.Cells[col_gridSaleOrderItems_Customers_Id.Name].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(selectedRowID()));
        }

        private void GridSaleOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            updateModeButtonsAvailabilityForGridRow();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            populateGridSaleOrders();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerPONo.Text = "";
            dtpEnd.Checked = false;
        }

        private void GridSaleOrderItems_SelectionChanged(object sender, EventArgs e)
        {
            populateGridDetails();
        }

        private void populateGridDetails()
        {
            if (gridSaleOrderItems.SelectedRows.Count > 0 && pnlDetails.Visible)
            {
                Guid saleOrderItems_Id = (Guid)LIBUtil.Util.getSelectedRowValue(gridSaleOrderItems, col_gridSaleOrderItems_Id);

                populateGridPOItems(saleOrderItems_Id);

                DataTable dtSales = Sale.get_by_SaleOrderItems_Id(saleOrderItems_Id);
                gridSales.DataSource = dtSales;
                lblSales.Text = string.Format("Sales ({0:N2})", LIBUtil.Util.compute(dtSales, "SUM", Sale.COL_totalQty, ""));

                DataTable dtInventory = Inventory.get_by_SaleOrderItems_Id(saleOrderItems_Id);
                gridInventory.DataSource = dtInventory;
                lblInventory.Text = string.Format("Inventory ({0:N2})", Util.compute(dtInventory, "SUM", Inventory.COL_ITEMLENGTH, ""));
            }
        }

        private Guid getSelectedSaleOrderItemId()
        {
            return (Guid)LIBUtil.Util.getSelectedRowValue(gridSaleOrderItems, col_gridSaleOrderItems_Id);
        }

        private void populateGridPOItems(Guid saleOrderItems_Id)
        {
            DataTable dtPOItems = POItem.get_by_SaleOrderItems_Id(saleOrderItems_Id);
            gridPOItems.DataSource = dtPOItems;
            lblPOItems.Text = string.Format("PO ({0:N2})", LIBUtil.Util.compute(dtPOItems, "SUM", POItem.COL_DB_QTY, ""));
        }

        private void GridSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridSales_Sales_No.Name))
            {
                Sale sale = new Sale(new Guid(gridSales.Rows[e.RowIndex].Cells[col_gridSales_Sales_Id.Name].Value.ToString()));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
            }
        }

        private void populateGridInventoryItems(Guid? sales_Id, Guid? inventory_Id)
        {
            DataTable dt = InventoryItem.get(null, null, (Guid)Util.getSelectedRowValue(gridSaleOrderItems, col_gridSaleOrderItems_Id), sales_Id, inventory_Id);
            gridInventoryItems.DataSource = dt;

            if (sales_Id != null)
                lblInventoryItems.Text = "Shipped";
            else
                lblInventoryItems.Text = "Booked";

            lblInventoryItems.Text += string.Format(" ({0:N2})", Util.compute(dt, "SUM", InventoryItem.COL_LENGTH, ""));

            btnRemoveSOFromInventoryItems.Enabled = false;
            if (_selectCheckboxHeader != null) _selectCheckboxHeader.Checked = false;
        }

        private void GridSales_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
                populateGridInventoryItems((Guid)LIBUtil.Util.getSelectedRowValue(sender, col_gridSales_Sales_Id), null);
        }

        private void GridInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
                populateGridInventoryItems(null, (Guid)LIBUtil.Util.getSelectedRowValue(sender, col_gridInventory_Id));
        }

        private void selectCheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            Tools.toggleCheckboxColumn(gridInventoryItems, col_gridInventoryItems_Select, _selectCheckboxHeader);
        }

        private void GridInventoryItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_gridInventoryItems_Select.Name))
            {
                Util.clickDataGridViewCheckbox(sender, e);
                updateRemoveSaleOrderItems_IdButton();
            }
        }

        private void _selectCheckboxHeader_Clieck(object sender, EventArgs e)
        {
            btnRemoveSOFromInventoryItems.Enabled = _selectCheckboxHeader.Checked;
        }

        private void updateRemoveSaleOrderItems_IdButton()
        {
            btnRemoveSOFromInventoryItems.Enabled = false;
            if (gridInventoryItems != null)
                foreach (DataGridViewRow row in gridInventoryItems.Rows)
                    if (Util.getCheckboxValue(row, col_gridInventoryItems_Select))
                        btnRemoveSOFromInventoryItems.Enabled = true;
        }

        private void GridSaleOrders_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridSaleOrders_TargetDate))
            {
                pnlUpdateTargetDate.Visible = true;
                idtp_SaleOrders_TargetDate.Value = (DateTime)Util.getSelectedRowValue(gridSaleOrders, col_gridSaleOrders_TargetDate);
            }
            else
            {
                Tools.displayForm(new Logs.Main_Form(selectedRowID()));
            }
        }

        private void BtnUpdateTargetDate_Click(object sender, EventArgs e)
        {
            SaleOrder.updateTargetDate(Util.getSelectedRowID(gridSaleOrders, col_gridSaleOrders_id), (DateTime)idtp_SaleOrders_TargetDate.Value);
            pnlUpdateTargetDate.Visible = false;
            populateGridSaleOrders();
        }

        private void BtnCancelUpdateTargetDate_Click(object sender, EventArgs e)
        {
            pnlUpdateTargetDate.Visible = false;
        }

        private void GridSaleOrderItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(_formMode != FormMode.Browse)
                Tools.displayForm(new Logs.Main_Form(selectedSaleOrderItemsRowId()));
        }

        private void PtDetails_pictureBox_ClickEvent(object sender, EventArgs e)
        {
            populateGridDetails();
        }

        private void BtnRemoveSOFromPOItem_Click(object sender, EventArgs e)
        {
            if(gridPOItems.SelectedRows.Count > 0)
            {
                POItem.updateSaleOrderItem((Guid)Util.getSelectedRowValue(gridPOItems, col_gridPOItems_id), null, null);
                populateGridPOItems(getSelectedSaleOrderItemId());
            }
        }

        private void BtnRemoveSOFromInventoryItems_Click(object sender, EventArgs e)
        {
            List<Guid> InventoryItemIdList = new List<Guid>();

            DataTable dt = (DataTable)gridInventoryItems.DataSource;
            foreach (DataRow dr in dt.Rows)
                InventoryItemIdList.Add((Guid)dr[InventoryItem.COL_ID]);

            InventoryItem.updateSaleOrderItem(InventoryItemIdList, null, null);

            populateGridSaleOrderItems();
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
