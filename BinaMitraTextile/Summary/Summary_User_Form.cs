using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using LIBUtil;

namespace BinaMitraTextile
{
    public partial class Summary_User_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES


        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Summary_User_Form()
        {
            InitializeComponent();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_gridPOItems_statusname.Visible = false;
                btnShowHidden.Visible = false;
            }

            if(GlobalData.UserAccount.role == Roles.Assistant)
            {
                ////disable to be hidden in rearrange
                //btnRefresh.Enabled = false;
                //btnShowHidden.Enabled = false;
                //Tools.rearrangeButtonsInPanel(scButtonsAndReceivables.Panel1, HorizontalAlignment.Left);

                //scButtonsAndReceivables.Panel2Collapsed = true;
                //scMain.Panel2Collapsed = true;
                //this.Width = 300;
                //this.Height = 200;
            }

            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPOItems_productDescription.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            col_gridPOItems_id.DataPropertyName = POItem.COL_DB_ID;
            col_gridPOItems_pono.DataPropertyName = POItem.COL_PONO;
            col_gridPOItems_timestamp.DataPropertyName = POItem.COL_TIMESTAMP;
            col_gridPOItems_productDescription.DataPropertyName = POItem.COL_DB_PRODUCTDESCRIPTION;
            col_gridPOItems_notes.DataPropertyName = POItem.COL_DB_NOTES;
            col_gridPOItems_qty.DataPropertyName = POItem.COL_DB_QTY;
            col_gridPOItems_unitName.DataPropertyName = POItem.COL_DB_UNITNAME;
            col_gridPOItems_receivedQty.DataPropertyName = POItem.COL_RECEIVEDQTY;
            col_gridPOItems_poid.DataPropertyName = POItem.COL_DB_POID;
            col_gridPOItems_statusenumid.DataPropertyName = POItem.COL_DB_STATUSENUMID;
            col_gridPOItems_statusname.DataPropertyName = POItem.COL_STATUSNAME;
            col_gridPOItems_PricePerUnit.DataPropertyName = POItem.COL_DB_PRICEPERUNIT;
            col_gridPOItems_Age.DataPropertyName = POItem.COL_AGE;
            col_gridPOItems_PendingQtyValue.DataPropertyName = POItem.COL_PENDINGQTYVALUE;
            col_gridPOItems_SaleOrderItems_CustomerPONo.DataPropertyName = POItem.COL_SaleOrderItems_CustomerPONo;

            addStatusContextMenu(col_gridPOItems_statusname);

            gridReceivables.AutoGenerateColumns = false;
            gridReceivables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridReceivables_saleID.DataPropertyName = Sale.COL_ID;
            col_gridReceivables_saleBarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridReceivables_customerName.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_gridReceivables_amount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridReceivables_daysElapsed.DataPropertyName = Sale.COL_DAYSELAPSED;
            col_gridReceivables_CustomerTerms_TermDays.DataPropertyName = Sale.COL_CustomerTerms_TermDays;
            col_gridReceivables_RemainingTermDays.DataPropertyName = Sale.COL_RemainingTermDays;

            dgvReceivablesSummary.AutoGenerateColumns = false;
            dgvReceivablesSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_dgvReceivables_CustomerName.DataPropertyName = Sale.COL_CUSTOMERNAME;
            col_dgvReceivables_Amount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_dgvReceivablesSummary_CustomerTerms_DebtLimit.DataPropertyName = Sale.COL_CustomerTerms_DebtLimit;
            col_dgvReceivablesSummary_RemainingDebtLimit.DataPropertyName = Sale.COL_RemainingDebtLimit;

            gridStockLevel.AutoGenerateColumns = false;
            gridStockLevel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridstocklevel_id.DataPropertyName = InventoryStockLevel.COL_DB_ID;
            col_gridstocklevel_vendorname.DataPropertyName = InventoryStockLevel.COL_VENDORNAME;
            col_gridstocklevel_productstorename.DataPropertyName = InventoryStockLevel.COL_PRODUCTSTORENAME;
            col_gridstocklevel_gradename.DataPropertyName = InventoryStockLevel.COL_GRADE_NAME;
            col_gridstocklevel_productwidthname.DataPropertyName = InventoryStockLevel.COL_PRODUCT_WIDTH_NAME;
            col_gridstocklevel_colorname.DataPropertyName = InventoryStockLevel.COL_COLOR_NAME;
            col_gridstocklevel_lengthunitname.DataPropertyName = InventoryStockLevel.COL_LENGTH_UNIT_NAME;
            col_gridstocklevel_stockqty.DataPropertyName = InventoryStockLevel.COL_REMAININGSTOCKQTY;
            col_gridstocklevel_pendingqty.DataPropertyName = InventoryStockLevel.COL_PENDINGDELIVERYQTY;
            col_gridstocklevel_newqty.DataPropertyName = InventoryStockLevel.COL_NEWORDER_QTY;
        }

        private void populatePageData()
        {
            DataTable dtReceivables;
            if(GlobalData.UserAccount.role == Roles.User)
                dtReceivables = Sale.get_ReceivablesOnly(true);
            else
                dtReceivables = Sale.get_ReceivablesOnly(false);

            Util.setGridviewDataSource(gridReceivables, dtReceivables);
            gridReceivables.Sort(col_gridReceivables_RemainingTermDays, ListSortDirection.Ascending);
            lblTotalDaftarPiutang.Text = string.Format("{0:N0}", LIBUtil.Util.compute(dtReceivables, "SUM", Sale.COL_RECEIVABLEAMOUNT, ""));

            populateReceivablesSummary(dtReceivables);

            populateIncompletePO();

            Util.setGridviewDataSource(gridStockLevel, InventoryStockLevel.getAll(null, null, null, null, null, null, true));
        }

        private void populateIncompletePO()
        {
            DataTable dtPOItems = new DataTable();
            Util.setGridviewDataSource(gridPOItems, dtPOItems = POItem.getIncompleteItems());
            lblTotalIncompletePO.Text = string.Format("{0:N0}", LIBUtil.Util.compute(dtPOItems, "SUM", POItem.COL_PENDINGQTYVALUE, ""));
        }

        private void populateReceivablesSummary(DataTable dtReceivables)
        {
            DataTable dtReceivablesSummary = new DataTable();
            Util.addColumnToTable<string>(dtReceivablesSummary, Sale.COL_CUSTOMERNAME, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_CustomerTerms_DebtLimit, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_RECEIVABLEAMOUNT, null);
            Util.addColumnToTable<decimal>(dtReceivablesSummary, Sale.COL_RemainingDebtLimit, null);
            Util.setDataTablePrimaryKey(dtReceivablesSummary, Sale.COL_CUSTOMERNAME);

            DataRow existing;
            object remainingDebtLimit;
            foreach(DataRow row in dtReceivables.Rows)
            {
                existing = dtReceivablesSummary.Rows.Find(Util.wrapNullable<string>(row, Sale.COL_CUSTOMERNAME));
                if (existing == null)
                {
                    remainingDebtLimit = row[Sale.COL_CustomerTerms_DebtLimit];
                    if (remainingDebtLimit != DBNull.Value)
                        remainingDebtLimit = Util.zeroNonNumericString(remainingDebtLimit) - Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);

                    dtReceivablesSummary.Rows.Add(row[Sale.COL_CUSTOMERNAME].ToString(), row[Sale.COL_CustomerTerms_DebtLimit], row[Sale.COL_RECEIVABLEAMOUNT], remainingDebtLimit);
                }
                else
                {
                    existing[Sale.COL_RECEIVABLEAMOUNT] = Util.zeroNonNumericString(existing[Sale.COL_RECEIVABLEAMOUNT]) + Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);
                    if(existing[Sale.COL_RemainingDebtLimit] != DBNull.Value)
                        existing[Sale.COL_RemainingDebtLimit] = Util.zeroNonNumericString(existing[Sale.COL_RemainingDebtLimit]) - Util.zeroNonNumericString(row[Sale.COL_RECEIVABLEAMOUNT]);
                }
            }

            Util.setGridviewDataSource(dgvReceivablesSummary, dtReceivablesSummary);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region CLASS METHODS

        private void btnNewSale_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Sales.Add_Edit_Form());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populatePageData();
        }

        private void gridPOItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (Util.isColumnMatch(sender, e, col_gridPOItems_SaleOrderItems_CustomerPONo))
            {
                Sales.SaleOrders_Form form = new Sales.SaleOrders_Form(FormMode.Browse, null);
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    POItem.updateSaleOrderItem((Guid)Util.getSelectedRowValue(sender, col_gridPOItems_id), form.browseItemSelection, form.browseItemDescription);
                    populateIncompletePO();
                }
            }
            else if (e.RowIndex > -1 && GlobalData.UserAccount.role != Roles.User)
            {
                Tools.displayForm(new POs.Print_Form((Guid)gridPOItems.Rows[e.RowIndex].Cells[col_gridPOItems_poid.Name].Value));
            }
        }

        private void gridReceivables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridReceivables_saleBarcode.Name))
            {
                Tools.displayForm(new Sales.Invoice_Form((Guid)gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value));
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridReceivables_amount.Name))
            {
                //var form = new Sales.Payment_Form(new Guid(gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value.ToString()));
                var form = new Invoices.Payment_Form(typeof(Sale), new Guid(gridReceivables.Rows[e.RowIndex].Cells[col_gridReceivables_saleID.Name].Value.ToString()));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populatePageData();
                }
            }
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
            populatePageData();
        }

        protected Guid selectedPOItemsRowID()
        {
            return (Guid)gridPOItems.SelectedRows[0].Cells[col_gridPOItems_id.Name].Value;
        }

        private void gridPOItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                    gridPOItems.Rows[e.RowIndex].Selected = true;
            }
        }

        private void gridStockLevel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Util.displayMDIChild(new Admin.StockLevel_Form(FormMode.New));
        }

        private void btnShowHidden_Click(object sender, EventArgs e)
        {
            bool value = !col_gridPOItems_PricePerUnit.Visible;
            col_gridPOItems_PricePerUnit.Visible = value;
            col_gridPOItems_PendingQtyValue.Visible = value;
            lblTotalDaftarPiutang.Visible = value;
            lblTotalIncompletePO.Visible = value;
        }

        private void lnkIncompletePO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Util.displayMDIChild(new POs.MasterData_v1_Status_Form());
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void Main_Form_Shown(object sender, EventArgs e)
        {
            Form form = new Admin.MasterData_v1_ToDoList_Form();

            form.TopLevel = false;
            scIncompletePOAndTodoList.Panel2.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        private void BtnRemoveSO_Click(object sender, EventArgs e)
        {
            if(LIBUtil.Util.displayMessageBoxYesNo("Hapus SO?"))
            {
                POItem.updateSaleOrderItem((Guid)Util.getSelectedRowValue(gridPOItems, col_gridPOItems_id), null, null);
                populateIncompletePO();
            }
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region ----

        #endregion
        /*******************************************************************************************************/
    }
}
