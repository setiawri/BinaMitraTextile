using System;
using System.Windows.Forms;

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
            populatePageData();
        }

        private void setupControls()
        {
            this.Text += DBUtil.appendTitleWithInfo();

            if(_formMode == FormMode.Browse)
            {
                //scMain.Panel1Collapsed = true;
                scMain.Visible = false;
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

            gridSold.AutoGenerateColumns = false;
            gridSold.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSold_InventoryItems_Id.DataPropertyName = SaleItem.COL_INVENTORY_ITEM_ID;
            col_gridSold_InventoryItems_ItemLength.DataPropertyName = SaleItem.COL_LENGTH;
            col_gridSold_InventoryItems_Barcode.DataPropertyName = SaleItem.COL_BARCODE;
            col_gridSold_Sales_No.DataPropertyName = SaleItem.COL_Sales_Barcode;
            col_gridSold_Sales_Timestamp.DataPropertyName = SaleItem.COL_Sales_Timestamp;
            col_gridSold_Sales_Id.DataPropertyName = SaleItem.COL_DB_sale_id;
            col_gridSold_Inventory_Code.DataPropertyName = SaleItem.COL_INVENTORYCODE;

            gridBooked.AutoGenerateColumns = false;
            gridBooked.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridBooked_InventoryItems_Barcode.DataPropertyName = InventoryItem.COL_BARCODE;
            col_gridBooked_InventoryItems_Id.DataPropertyName = InventoryItem.COL_ID;
            col_gridBooked_InventoryItems_ItemLength.DataPropertyName = InventoryItem.COL_LENGTH;
            col_gridBooked_Inventory_Code.DataPropertyName = InventoryItem.COL_INVENTORY_CODE;

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
            SaleOrderItem.updateStatus(selectedPOItemsRowID(), Tools.parseEnum<SaleOrderItemStatus>(sender.ToString()));
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

            gridSaleOrders.DataSource = SaleOrder.get(null, null, txtCustomerPONo.Text.Trim(), dtStart, dtEnd, _formMode == FormMode.Browse || chkShowIncompleteOnly.Checked);
            
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

        protected Guid selectedPOItemsRowID()
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
            if(gridSaleOrderItems.SelectedRows.Count > 0)
                populateGridSoldAndBooked((Guid)LIBUtil.Util.getSelectedRowValue(sender, col_gridSaleOrderItems_Id));
        }

        private void populateGridSoldAndBooked(Guid saleOrderItems_Id)
        {
            gridSold.DataSource = SaleItem.getSold(null, null, saleOrderItems_Id);
            gridBooked.DataSource = InventoryItem.get_Booked(saleOrderItems_Id);
        }

        private void GridSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridSold_Sales_No.Name))
            {
                Sale sale = new Sale(new Guid(gridSold.Rows[e.RowIndex].Cells[col_gridSold_Sales_Id.Name].Value.ToString()));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
            }
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
