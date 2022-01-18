using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.Sales
{
    public partial class Add_Edit_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        const string TEMPSAVE_COL_TEXT = "Text";
        const string TEMPSAVE_COL_MASTER = "MasterTable";
        const string TEMPSAVE_COL_SUMMARY = "SummaryTable";
        const string TEMPSAVE_COL_CUSTOMER = "CustomerID";
        const string TEMPSAVE_COL_NOTES = "Notes";

        private DataTable _dtTemporarySaves = GlobalData.TemporarySaleTables;
        private FormMode _formMode = FormMode.New;
        private Guid? _saleID = null;
        private Guid? _browseItemCustomerId = null;

        protected CheckBox _gridSelectCheckboxHeader;
        protected CheckBox _gridSummarySelectCheckboxHeader;

        private bool isFormShown = false;
        
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Add_Edit_Form(FormMode mode, Guid? saleID)
        {
            InitializeComponent();
            
            _formMode = mode;
            _saleID = saleID;
        }

        public Add_Edit_Form(Guid saleID) : this(FormMode.Update, saleID) { }

        public Add_Edit_Form() : this(FormMode.New, null) { }

        private void Form_Shown(object sender, EventArgs e)
        {
            isFormShown = true;

            _gridSelectCheckboxHeader = Tools.addHeaderCheckbox(grid, col_grid_select, "_gridSelectCheckboxHeader", selectGridCheckboxHeader_CheckedChanged);
            _gridSummarySelectCheckboxHeader = Tools.addHeaderCheckbox(gridSummary, col_gridSummary_select, "_gridSummarySelectCheckboxHeader", selectGridSummaryCheckboxHeader_CheckedChanged);

            iddl_Customers.focus();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_adjustedprice.DataPropertyName = SaleItem.COL_SALE_ADJUSTEDPRICE;
            col_grid_productstorename.DataPropertyName = SaleItem.COL_PRODUCTSTORENAME;
            col_grid_productwidthname.DataPropertyName = SaleItem.COL_PRODUCTWIDTHNAME;
            col_grid_colorname.DataPropertyName = SaleItem.COL_INVENTORYCOLORNAME;
            col_grid_id.DataPropertyName = SaleItem.COL_ID;
            col_grid_SaleOrderItemDescription.DataPropertyName = SaleItem.COL_SaleOrderItemDescription;

            gridSummary.AutoGenerateColumns = false;
            col_gridsummary_priceperunit.DataPropertyName = SaleItem.COL_SALE_ADJUSTEDPRICE;
            col_gridSummary_inventory_color_name.DataPropertyName = SaleItem.COL_INVENTORYCOLORNAME;

            Inventory.setAmount(lblTotalAmount, "0");
            Inventory.setCount(lblTotalCounts, "0", "0");
            Inventory.setCount(lblSelectedTotal, "0", "0");
            btnSubmit.Enabled = false;
            btnReset.Enabled = false;

            Transport.populateDropDownList(cbTransports, false, true);
            populateVendors();
            populateCustomers();
            rbCustomer.Checked = true;
            setRadioButtonEnability(rbCustomer);

            itxt_AddBarcode.MaxLength = Settings.itemBarcodeLength + Settings.itemBarcodeMandatoryPrefix.Length + 3; //3 for split items

            populateCbTemporarySaves();
            
            if(_formMode == FormMode.Update)
            {
                Tools.disableControls(itxt_AddBarcode, cbTemporarySaves, btnSaveSale, btnClearForm, btnRemoveSelected, txtNotes);
                btnSubmit.Text = "UPDATE";

                if (GlobalData.UserAccount.role != Roles.Super)
                    Tools.disableControls(in_PriceAdjustSelected, in_ShippingCost, cbTransports, rbCustomer, rbVendor, iddl_Customers, iddl_Vendors);
            }
        }

        private void populatePageData()
        {
            if(_formMode == FormMode.Update)
            {
                Sale sale = new Sale((Guid)_saleID);
                setGridDataSource(sale.sale_items);

                recalculateNumbers();

                txtNotes.Text = sale.notes;
                if (sale.TransportID != null) cbTransports.SelectedValue = sale.TransportID;
                in_ShippingCost.Value = sale.ShippingCost;

                iddl_Customers.SelectedValue = sale.customer_id;
                iddl_Vendors.SelectedValue = sale.Vendors_Id;                
                rbCustomer.Checked = (sale.customer_id != null);
                setRadioButtonEnability(rbCustomer);
            }
        }
        
        private void setGridDataSource(DataTable dt)
        {
            grid.DataSource = dt;

            //clear header checkboxes
            if (_gridSelectCheckboxHeader != null) _gridSelectCheckboxHeader.Checked = false;

            //if a row has sales order, disable customer selection
            if (_formMode == FormMode.Update && GlobalData.UserAccount.role != Roles.Super)
                rbCustomer.Enabled = rbVendor.Enabled = iddl_Customers.Enabled = iddl_Vendors.Enabled = false;
            else if(dt != null)
            {
                if(rbCustomer.Checked)
                    setRadioButtonEnability(rbCustomer);
                else
                    setRadioButtonEnability(rbVendor);
                foreach (DataRow dr in dt.Rows)
                    if ((_formMode == FormMode.Update && dr[SaleItem.COL_SaleOrderItems_Id] != DBNull.Value)
                        || dr[InventoryItem.COL_DB_SaleOrderItems_Id] != DBNull.Value)
                        rbCustomer.Enabled = rbVendor.Enabled = iddl_Customers.Enabled = iddl_Vendors.Enabled = false;
            }
        }

        private void setGridSummaryDataSource(DataTable dt)
        {
            gridSummary.DataSource = dt;

            //clear header checkboxes
            if (_gridSummarySelectCheckboxHeader != null) _gridSummarySelectCheckboxHeader.Checked = false;

        }

        private void populateCbTemporarySaves()
        {
            if (_dtTemporarySaves.Columns.Count == 0)
            {
                Tools.addColumn<string>(_dtTemporarySaves, TEMPSAVE_COL_TEXT, null);
                Tools.addColumn<DataTable>(_dtTemporarySaves, TEMPSAVE_COL_MASTER, null);
                Tools.addColumn<DataTable>(_dtTemporarySaves, TEMPSAVE_COL_SUMMARY, null);
                Tools.addColumn<Guid>(_dtTemporarySaves, TEMPSAVE_COL_CUSTOMER, null);
                Tools.addColumn<string>(_dtTemporarySaves, TEMPSAVE_COL_NOTES, null);
                _dtTemporarySaves = Tools.setDataTablePrimaryKey(_dtTemporarySaves, TEMPSAVE_COL_TEXT);
            }
            Tools.populateDropDownList(cbTemporarySaves, _dtTemporarySaves.DefaultView, TEMPSAVE_COL_TEXT, TEMPSAVE_COL_TEXT, false);
            cbTemporarySaves.SelectedIndex = -1;
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region SHORTCUT KEYS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                itxt_AddBarcode.focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion SHORTCUT KEYS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_formMode == FormMode.New)
            {
                if (isSaleValid())
                {
                    Guid? Customers_Id = null;
                    Guid? Vendors_Id = null;
                    if (rbVendor.Checked)
                        Vendors_Id = (Guid?)iddl_Vendors.SelectedValue;
                    else
                        Customers_Id = (Guid?)iddl_Customers.SelectedValue;

                    Sale obj = new Sale(Customers_Id, Vendors_Id, (Guid?)cbTransports.SelectedValue, in_ShippingCost.ValueDecimal, rbVendor.Checked, Util.wrapNullable<string>(txtNotes.Text));
                    var form = new Sales.Invoice_Form(obj, (DataTable)grid.DataSource, true);
                    Tools.displayForm(form);
                    if(form.isGenerated == true)
                    {
                        //remove from temporary save table if it was used
                        if (cbTemporarySaves.SelectedIndex > -1)
                        {
                            int idx = cbTemporarySaves.SelectedIndex;
                            cbTemporarySaves.SelectedIndex = -1;
                            _dtTemporarySaves.Rows[idx].Delete();
                        }

                        this.Close();
                    }
                }
            }
            else if (_formMode == FormMode.Update && isSaleValidForUpdate())
            {
                Guid? Customers_Id = null;
                Guid? Vendors_Id = null;
                if (rbVendor.Checked)
                    Vendors_Id = (Guid?)iddl_Vendors.SelectedValue;
                else
                    Customers_Id = (Guid?)iddl_Customers.SelectedValue;
                DBUtil.sanitize(txtNotes);
                if(Sale.update((Guid)_saleID, Customers_Id, Vendors_Id, (DataTable)grid.DataSource, (Guid?)cbTransports.SelectedValue, in_ShippingCost.ValueDecimal, txtNotes.Text))
                    this.Close();
            }
        }

        private bool isSaleValid()
        {
            DataTable dt = (DataTable)grid.DataSource;
            if (dt.Rows.Count == 0)
                return itxt_AddBarcode.isValueError("Please add an item");
            else if (rbCustomer.Checked && !iddl_Customers.hasSelectedValue())
                return iddl_Customers.SelectedValueError("Please select Customer");
            else if (rbVendor.Checked && !iddl_Vendors.hasSelectedValue())
                return iddl_Vendors.SelectedValueError("Please select Vendor");
            else if (!allItemHasPrice())
            {
                Tools.hasMessage("An item does not have a price. Please update by clicking the link in the 'code' column");
                return false;
            }

            return true;
        }

        private bool isSaleValidForUpdate()
        {
            return true;
        }

        private bool allItemHasPrice()
        {
            foreach (DataRow dr in ((DataTable)grid.DataSource).Rows)
            {
                if (string.IsNullOrEmpty(dr[InventoryItem.COL_SALE_SELLPRICE].ToString()))
                    return false;
            }
            return true;
        }


        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region LIST - ITEMS

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LIBUtil.Util.isColumnMatch(sender, e, col_grid_select))
            {
                bool isChecked = LIBUtil.Util.clickDataGridViewCheckbox(sender, e);
                DataTable dtItems = (DataTable)grid.DataSource;
                LIBUtil.Util.setDataTablePrimaryKey(dtItems, InventoryItem.COL_DB_ID);
                DataRow dr = dtItems.Rows.Find(LIBUtil.Util.getSelectedRowValue(grid, col_grid_id));
                dr[InventoryItem.COL_SALE_SELECTED] = isChecked;
                dr.AcceptChanges();

                recalculateSelectedCounts(dtItems);
            }
        }

        private void setSelectCheckboxes(DataGridView gridview, DataGridViewColumn column, bool isChecked)
        {
            foreach (DataGridViewRow row in gridview.Rows)
                row.Cells[column.Name].Value = isChecked;
        }

        private void updateList()
        {
            if (_formMode == FormMode.New)
            {
                DataTable dt = (DataTable)grid.DataSource;

                Guid[] id_array = dt.AsEnumerable().Select(s => s.Field<Guid>(InventoryItem.COL_DB_ID)).ToArray<Guid>();
                decimal?[] adjustment_array = dt.AsEnumerable().Select(s => Util.wrapNullable<decimal?>(s.Field<decimal?>(InventoryItem.COL_SALE_ADJUSTMENT))).ToArray<decimal?>();
                bool[] selection_array = dt.AsEnumerable().Select(s => s.Field<bool>(InventoryItem.COL_SALE_SELECTED)).ToArray<bool>();
                dt = InventoryItem.getRowsForSale(id_array, DBUtil.parseData<Guid?>(iddl_Customers.SelectedValue));                

                //reapply adjustments and selections
                int idx = -1;
                foreach (DataRow dr in dt.Rows)
                {
                    idx = Array.IndexOf(id_array, (Guid)dr[InventoryItem.COL_DB_ID]);
                    dr[InventoryItem.COL_SALE_ADJUSTMENT] = adjustment_array[idx];
                    dr[InventoryItem.COL_SALE_SELECTED] = selection_array[idx];
                }

                setGridDataSource(dt);
            }

            applyCustomerSaleAdjustment();

            //calculations
            recalculateNumbers();
            recalculateSelectedCounts((DataTable)grid.DataSource);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            updateList();
        }

        #endregion LIST - ITEMS
        /*******************************************************************************************************/
        #region LIST - SUMMARY

        private void updateSummaryList()
        {
            setGridSummaryDataSource(Sale.compileSummaryData((DataTable)grid.DataSource));
        }

        private void gridSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_gridSummary_select.Name))
            {
                bool isChecked = !(bool)gridSummary.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                DataTable dtSummary = (DataTable)gridSummary.DataSource;
                dtSummary.Rows[e.RowIndex][InventoryItem.COL_SALE_SELECTED] = isChecked;
                string inventoryCode = gridSummary.Rows[e.RowIndex].Cells[gridSummaryCode.Name].Value.ToString();

                DataTable dtItems = (DataTable)grid.DataSource;
                foreach (DataRow dr in dtItems.Rows)
                {
                    if(dr[InventoryItem.COL_DB_INVENTORY_CODE].ToString() == inventoryCode)
                        dr[InventoryItem.COL_SALE_SELECTED] = isChecked;
                }

                setGridDataSource(dtItems);
                setGridSummaryDataSource(dtSummary);
                recalculateSelectedCounts(dtItems);
            }
        }

        private void gridSummary_SelectionChanged(object sender, EventArgs e)
        {
            gridSummary.ClearSelection(); //disable cell color change when user click on it
        }

        #endregion LIST - SUMMARY
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM

        private void itxt_AddBarcode_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                addBarcode();
        }

        private void addBarcode()
        {
            if (itxt_AddBarcode.isEmpty())
                return;

            string barcodeWithoutPrefix = InventoryItem.getBarcodeWithoutPrefix(itxt_AddBarcode.ValueText);
            InventoryItem item = new InventoryItem(barcodeWithoutPrefix);

            if (!InventoryItem.isBarcodeExist(barcodeWithoutPrefix))
                Tools.hasMessage(barcodeWithoutPrefix + " is not found in database");
            else if (item.isSold)
                Tools.hasMessage(barcodeWithoutPrefix + " has already been sold");
            else if(item.SaleOrderItems_Id != null && iddl_Customers.SelectedValue != null && item.SaleOrders_Customers_Id != (Guid?)iddl_Customers.SelectedValue)
                Tools.hasMessage(barcodeWithoutPrefix + " has sale order " + item.SaleOrderItemDescription + " for customer: " + item.SaleOrderItemCustomerName);
            else
            {
                DataTable dt;
                if (grid.DataSource == null)
                {
                    dt = InventoryItem.getRowForSale(barcodeWithoutPrefix, DBUtil.parseData<Guid?>(iddl_Customers.SelectedValue));
                    Tools.displayForm(new SharedForms.Verify_Form(dt.Rows[0][InventoryItem.COL_DB_INVENTORY_CODE].ToString(), dt.Rows[0][InventoryItem.COL_DB_LENGTH].ToString()));
                }
                else
                {
                    dt = Tools.setDataTablePrimaryKey((DataTable)grid.DataSource, InventoryItem.COL_DB_ID);
                    foreach (DataRow dr in InventoryItem.getRowForSale(barcodeWithoutPrefix, DBUtil.parseData<Guid?>(iddl_Customers.SelectedValue)).Rows)
                    {
                        if (dt.Rows.Contains(dr[InventoryItem.COL_DB_ID]))
                            Tools.hasMessage(dr[InventoryItem.COL_DB_BARCODE].ToString() + " is already in the list");
                        else
                        {
                            Tools.displayForm(new SharedForms.Verify_Form(dr[InventoryItem.COL_DB_INVENTORY_CODE].ToString(), dr[InventoryItem.COL_DB_LENGTH].ToString()));
                            dt.Rows.Add(dr.ItemArray);
                        }
                    }
                }

                if (iddl_Customers.SelectedValue == null && item.SaleOrders_Customers_Id != null)
                    iddl_Customers.SelectedValue = item.SaleOrders_Customers_Id;

                setGridDataSource(dt);
                applyCustomerSaleAdjustment();
                recalculateNumbers();

                //select newly added item
                foreach(DataGridViewRow row in grid.Rows)
                    if (row.Cells[col_grid_barcode.Name].Value.ToString() == barcodeWithoutPrefix)
                        row.Selected = true;
            }

            itxt_AddBarcode.reset();
            itxt_AddBarcode.focus();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            setSelectCheckboxes(gridSummary, col_gridSummary_select, false);

            DataTable dt = (DataTable)grid.DataSource;
            DataRow dr;
            for (int i = dt.Rows.Count-1; i >= 0; i--)
            {
                dr = dt.Rows[i];
                if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
                {
                    dr.Delete();
                }
            }
            dt.AcceptChanges();
            setGridDataSource(dt);
            recalculateNumbers();
            itxt_AddBarcode.focus();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            itxt_AddBarcode.reset();
        }

        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region CUSTOMER CONTROLS

        private void populateCustomers()
        {
            Customer.populateInputControlDropDownList(iddl_Customers, false);
        }

        private void populateVendors()
        {
            Vendor.populateInputControlDropDownList(iddl_Vendors, true);
        }

        private void Iddl_Customers_UpdateLink_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Customers_Form(FormModes.Add));
            populateCustomers();
        }

        private void Iddl_Vendors_UpdateLink_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Vendors_Form(FormModes.Add));
            populateVendors();
        }

        private void Iddl_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!iddl_Customers.hasSelectedValue())
                Tools.resetDropDownList(cbTransports);
            else if(isFormShown)
            {
                Guid? id = new Customer((Guid?)iddl_Customers.SelectedValue).DefaultTransportID;
                if (id != null)
                    cbTransports.SelectedValue = (Guid)id;
            }
        }

        private void applyCustomerSaleAdjustment()
        {
            //if(_dtCustomerSaleAdjustment != null && _dtCustomerSaleAdjustment.Rows.Count > 0)
            //{
            //    DataTable dt = (DataTable)grid.DataSource;
            //    DataRow[] rows;
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        if (dr[InventoryItem.COL_SALE_ADJUSTMENT] == "")
            //        {
            //            rows = _dtCustomerSaleAdjustment.Select(string.Format("", CustomerSaleAdjustment.COL_DB_PRODUCSTORENAMEID));
            //            dr[InventoryItem.COL_SALE_ADJUSTMENT] = "";
            //        }
            //    }
            //    setGridDataSource(dt);
            //}
        }

        private void resetCustomerSaleAdjustments()
        {
            //DataTable dt = (DataTable)grid.DataSource;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
            //        dr[InventoryItem.COL_SALE_ADJUSTMENT] = "";
            //}
            //setGridDataSource(dt);
            //applyCustomerSaleAdjustment();
            //recalculateNumbers();
        }

        #endregion CUSTOMER CONTROLS
        /*******************************************************************************************************/
        #region CALCULATIONS

        private void recalculateNumbers()
        {
            DataTable dt = (DataTable)grid.DataSource;

            foreach (DataRow dr in dt.Rows)
            {
                //update final price
                dr[InventoryItem.COL_SALE_ADJUSTEDPRICE] = String.Format("{0}",
                    (Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_SELLPRICE].ToString())
                    + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_ADJUSTMENT])));
                
                //update subtotals
                dr[InventoryItem.COL_SALE_SUBTOTAL] = String.Format("{0}", 
                    Convert.ToDecimal(dr[InventoryItem.COL_DB_LENGTH]) 
                    * (Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_SELLPRICE].ToString())
                    + Tools.zeroNonNumericString(dr[InventoryItem.COL_SALE_ADJUSTMENT])));
            }

            //update grand total
            Inventory.setAmount(lblTotalAmount, dt.Compute(String.Format("SUM({0})", InventoryItem.COL_SALE_SUBTOTAL), "").ToString());

            //update total counts
            Inventory.setCount(lblTotalCounts, dt.Rows.Count.ToString(), dt.Compute(String.Format("SUM({0})", InventoryItem.COL_DB_LENGTH), "").ToString());

            //update selected counts
            recalculateSelectedCounts(dt);

            //disable/enable generate button
            if (dt.Rows.Count > 0)
            {
                btnSubmit.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                btnSubmit.Enabled = false;
                btnReset.Enabled = false;
            }
            setGridDataSource(dt);

            updateSummaryList();
        }

        private void recalculateSelectedCounts(DataTable dt)
        {
            Inventory.setCountAndAmount(lblSelectedTotal,
                dt.Compute(String.Format("COUNT({0})", InventoryItem.COL_DB_LENGTH), String.Format("{0} = 1", InventoryItem.COL_SALE_SELECTED)).ToString(),
                dt.Compute(String.Format("SUM({0})", InventoryItem.COL_DB_LENGTH), String.Format("{0} = 1", InventoryItem.COL_SALE_SELECTED)).ToString(),
                dt.Compute(String.Format("SUM({0})", InventoryItem.COL_SALE_SUBTOTAL), String.Format("{0} = 1", InventoryItem.COL_SALE_SELECTED)).ToString());            
        }

        #endregion CALCULATIONS
        /*******************************************************************************************************/
        #region ADJUSTMENT CONTROL

        private void In_PriceAdjustSelected_Leave(object sender, EventArgs e)
        {
            in_PriceAdjustSelected.Value = 0;
        }

        private void In_PriceAdjustSelected_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                decimal adjustment = in_PriceAdjustSelected.ValueDecimal;
                if(adjustment > 0)
                {
                    MessageBox.Show("Warning: Adjustment bernilai positif. Adjustment bukan discount?");
                }

                DataTable dt = (DataTable)grid.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
                    {
                        dr[InventoryItem.COL_SALE_ADJUSTMENT] = adjustment;

                        //only mark if a discount
                        dr[InventoryItem.COL_SALE_isManualAdjustment] = adjustment < 0;
                    }
                }
                in_PriceAdjustSelected.Value = 0;
                setGridDataSource(dt);

                recalculateNumbers();
                itxt_AddBarcode.focus();
            }
        }

        #endregion ADJUSTMENT CONTROL
        /*******************************************************************************************************/
        #region TEMPORARY SAVES

        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            string name = cbTemporarySaves.Text.Trim();

            //validation
            if (string.IsNullOrEmpty(name))
            {
                Tools.hasMessage("Please provide a name");
                cbTemporarySaves.Focus();
            }
            else
            {
                DataRow dr = _dtTemporarySaves.Rows.Find(name);
                bool isNew = false;
                if (dr == null)
                {
                    isNew = true;
                    dr = _dtTemporarySaves.NewRow();
                    dr[TEMPSAVE_COL_TEXT] = name;
                }

                //populate data
                dr[TEMPSAVE_COL_MASTER] = Tools.copyTable((DataTable)grid.DataSource);
                dr[TEMPSAVE_COL_SUMMARY] = Tools.copyTable((DataTable)gridSummary.DataSource);
                if(iddl_Customers.hasSelectedValue()) dr[TEMPSAVE_COL_CUSTOMER] = iddl_Customers.SelectedValue;
                dr[TEMPSAVE_COL_NOTES] = txtNotes.Text.Trim();
                
                if (isNew)
                    _dtTemporarySaves.Rows.Add(dr);

                cbTemporarySaves.SelectedValue = name;

                Tools.hasMessage("Data has been saved");
            }

            itxt_AddBarcode.focus();
        }

        private void cbTemporarySaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTemporarySaves.SelectedIndex == -1)
            {
                clearForm();
            }
            else
            {
                DataRow dr = _dtTemporarySaves.Rows[cbTemporarySaves.SelectedIndex];
                setGridDataSource(Tools.copyTable((DataTable)dr[TEMPSAVE_COL_MASTER]));
                setGridSummaryDataSource(Tools.copyTable((DataTable)dr[TEMPSAVE_COL_SUMMARY]));
                if(dr[TEMPSAVE_COL_CUSTOMER] != DBNull.Value) iddl_Customers.SelectedValue = (Guid)dr[TEMPSAVE_COL_CUSTOMER];
                txtNotes.Text = dr[TEMPSAVE_COL_NOTES].ToString();

                recalculateNumbers();
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            clearForm();
        }


        private void cbTemporarySaves_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSaveSale.PerformClick();
        }

        #endregion TEMPORARY SAVES
        /*******************************************************************************************************/
        #region FORM METHODS

        private void clearForm()
        {
            cbTemporarySaves.SelectedIndex = -1;
            setGridDataSource(null);
            setGridSummaryDataSource(null);
            Inventory.setAmount(lblTotalAmount, "0");
            Inventory.setCount(lblTotalCounts, "0", "0");

            iddl_Customers.reset();
            iddl_Vendors.reset();
            rbVendor.Checked = true;
            setRadioButtonEnability(rbVendor);

            itxt_AddBarcode.focus();
        }

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Transports_Form(FormMode.New));
            Transport.populateDropDownList(cbTransports, false, true);
        }

        private void txtShippingCost_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, false, false);
        }

        private void selectGridCheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            Tools.toggleCheckboxColumn(grid, col_grid_select, _gridSelectCheckboxHeader);
            recalculateSelectedCounts((DataTable)grid.DataSource);
        }

        private void selectGridSummaryCheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            _gridSelectCheckboxHeader.Checked = _gridSummarySelectCheckboxHeader.Checked;
            Tools.toggleCheckboxColumn(gridSummary, col_gridSummary_select, _gridSummarySelectCheckboxHeader);
            recalculateSelectedCounts((DataTable)grid.DataSource);
        }

        private void btnSplitItem_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
                LIBUtil.Util.displayMessageBoxError("Pilih item untuk di split");
            else
            {
                Guid selectedRowId = LIBUtil.Util.getSelectedRowID(grid, col_grid_id);
                var form = new Sales.InventoryItems_Split_Form(selectedRowId);
                LIBUtil.Util.displayForm(null, form);

                //subtitute item with the new split item
                InventoryItem newInventoryItemId = form.NewInventoryItemId;
                setSelectCheckboxes(grid, col_grid_select, false); //remove all selected checkboxes
                grid.SelectedRows[0].Cells[col_grid_select.Name].Value = true; //select the original item that was split
                btnRemoveSelected.PerformClick(); //remove from list
                                                  //add the new split item to the list
                itxt_AddBarcode.ValueText = Settings.itemBarcodeMandatoryPrefix + newInventoryItemId.barcode;
                addBarcode();
            }
        }

        private void Iddl_SaleOrderItems_isBrowseMode_Clicked(object sender, EventArgs e)
        {
            SaleOrders_Form form = new SaleOrders_Form(FormMode.Browse, (Guid?)iddl_Customers.SelectedValue);
            Tools.displayForm(form);
            if (form.DialogResult == DialogResult.OK)
            {
                itxt_SaleOrderItems.ValueGuid = form.browseItemSelection;
                itxt_SaleOrderItems.ValueText = form.browseItemDescription;
                _browseItemCustomerId = form.browseItemCustomers_Id;
            }            
        }

        private void BtnApplySaleOrderItem_Click(object sender, EventArgs e)
        {
            List<Guid> InventoryItemIdList = new List<Guid>();

            DataTable dt = (DataTable)grid.DataSource;
            foreach (DataRow dr in dt.Rows)
                if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
                    if (_formMode == FormMode.Update)
                        InventoryItemIdList.Add((Guid)dr[SaleItem.COL_INVENTORY_ITEM_ID]);
                    else
                        InventoryItemIdList.Add((Guid)dr[InventoryItem.COL_DB_ID]);

            if (InventoryItemIdList.Count == 0)
                LIBUtil.Util.displayMessageBoxError("Select item to update");
            else
            {
                if (InventoryItem.updateSaleOrderItem(InventoryItemIdList, itxt_SaleOrderItems.ValueGuid, itxt_SaleOrderItems.ValueText))
                { 
                    if (_formMode == FormMode.Update)
                        setGridDataSource(new Sale((Guid)_saleID).sale_items); //load data from database
                    else
                    {
                        //manually update list since it is not saved in database yet
                        //foreach (DataRow dr in dt.Rows)
                        //    if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
                        //    {
                        //        dr[InventoryItem.COL_DB_SaleOrderItems_Id] = LIBUtil.Util.wrapNullable(itxt_SaleOrderItems.ValueGuid);
                        //        dr[InventoryItem.COL_SaleOrderItemDescription] = itxt_SaleOrderItems.ValueText;
                        //    }
                        //setGridDataSource(dt);


                        //remove from list and re insert to make sure price is correct (price in po vs price with discount or normal price)
                        List<string> barcodeList = new List<string>();
                        for(int i=dt.Rows.Count-1; i>=0; i--)
                        {
                            DataRow dr = dt.Rows[i];
                            if ((bool)dr[InventoryItem.COL_SALE_SELECTED])
                            {
                                barcodeList.Add(dr[InventoryItem.COL_DB_BARCODE].ToString());
                                dr.Delete();
                            }
                        }
                        dt.AcceptChanges();
                        foreach(string barcode in barcodeList)
                        {
                            itxt_AddBarcode.ValueText = Settings.itemBarcodeMandatoryPrefix + barcode;
                            addBarcode();
                        }
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (barcodeList.Contains(LIBUtil.Util.getRowValue(row, col_grid_barcode)))
                                LIBUtil.Util.setCheckboxValue(row, col_grid_select, true);
                        }
                    }
                }

                if (_formMode == FormMode.Update && GlobalData.UserAccount.role != Roles.Super)
                    rbCustomer.Enabled = iddl_Customers.Enabled = false;
                else if (iddl_Customers.SelectedValue == null && itxt_SaleOrderItems.ValueGuid != null)
                {
                    bool isCustomerSelectionEnabled = iddl_Customers.Enabled;
                    rbCustomer.Enabled = iddl_Customers.Enabled = true;
                    iddl_Customers.SelectedValue = _browseItemCustomerId;
                    rbCustomer.Enabled = iddl_Customers.Enabled = isCustomerSelectionEnabled;
                }

                LIBUtil.Util.displayMessageBoxSuccess("Updated");
            }
        }

        private void setRadioButtonEnability(object sender)
        {
            if (sender == rbVendor)
                rbCustomer.Checked = iddl_Customers.Enabled = !((RadioButton)sender).Checked;
            else
                rbVendor.Checked = iddl_Vendors.Enabled = !((RadioButton)sender).Checked;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            setRadioButtonEnability(sender);
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
    }
}
