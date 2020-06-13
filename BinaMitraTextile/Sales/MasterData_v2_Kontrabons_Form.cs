using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.Sales
{
    public partial class MasterData_v2_Kontrabons_Form : LIBUtil.Desktop.Forms.MasterData_v2_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;
        private const int DEFAULT_ROWINFOSIZE = 220;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_dgv_No;
        private DataGridViewColumn col_dgv_Timestamp;
        private DataGridViewColumn col_dgv_Customers_Id;
        private DataGridViewColumn col_dgv_Customers_Name;
        private DataGridViewColumn col_dgv_Amount;
        private DataGridViewColumn col_dgv_ReturnDate;
        private DataGridViewColumn col_dgv_Notes;
        private DataGridViewColumn col_dgv_AssignedAmount;
        private DataGridViewColumn col_dgv_AmountDifference;

        private Guid? _lastSelectedKontrabons_Id = null;

        private const string TABTITLE_FakturPajaks = "Faktur Pajak";
        private const string TABTITLE_SaleInvoices = "Sale Invoices";
        private const string TABTITLE_SaleReturns = "Sale Returns";

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v2_Kontrabons_Form() : this(FormModes.Add) { }
        public MasterData_v2_Kontrabons_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void populateGridFakturPajaks(bool repopulateGridKontrabon)
        {
            DataTable data = FakturPajak.get_by_Kontrabons_Id((Guid)_lastSelectedKontrabons_Id);
            Util.setGridviewDataSource(gridFakturPajaks, data);

            tpFakturPajaks.Text = string.Format("{0}: {1:N2}", TABTITLE_FakturPajaks, Util.compute(data, "SUM", FakturPajak.COL_TotalAmount, ""));
            if (repopulateGridKontrabon)
                populateGridViewDataSource(true);
        }

        private void populateGridSaleInvoices(bool repopulateGridKontrabon)
        {
            DataTable data = Sale.get_by_Kontrabons_Id((Guid)_lastSelectedKontrabons_Id);
            Util.setGridviewDataSource(gridSaleInvoices, false, false, data);

            tpSaleInvoices.Text = string.Format("{0}: {1:N2}", TABTITLE_SaleInvoices, Util.compute(data, "SUM", Sale.COL_SALEAMOUNT, ""));
            if (repopulateGridKontrabon)
                populateGridViewDataSource(true);
        }

        private void populateGridReturns(bool repopulateGridKontrabon)
        {
            DataTable data = SaleReturn.get_by_Kontrabons_Id((Guid)_lastSelectedKontrabons_Id);
            Util.setGridviewDataSource(gridReturns, false, false, data);
            tpSaleReturns.Text = string.Format("{0}: {1:N2}", TABTITLE_SaleReturns, -1 * Util.compute(data, "SUM", SaleReturn.COL_RETURNAMOUNT, ""));
            if (repopulateGridKontrabon)
                populateGridViewDataSource(true);
        }

        #endregion
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            Settings.setGeneralSettings(this);

            setColumnsDataPropertyNames(Kontrabon.COL_DB_Id, null, null, null, null, Kontrabon.COL_DB_Approved);
            col_dgv_Checkbox1.HeaderText = "Lock";

            col_dgv_No = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_No", "No", Kontrabon.COL_DB_No, true, true, "", true, false, 20, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Timestamp = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Timestamp", idtp_Timestamp.LabelText, Kontrabon.COL_DB_Timestamp, true, true, "", false, false, 40, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Customers_Id = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Id", "Customers_Id", Kontrabon.COL_DB_Customers_Id, true, false, "", false, false, 50, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Customers_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Customers_Name", iddl_Customers.LabelText, Kontrabon.COL_Customers_Name, true, true, "", true, false, 55, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Amount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Amount", in_Amount.LabelText, Kontrabon.COL_DB_Amount, true, true, "N2", false, false, 50, DataGridViewContentAlignment.MiddleRight);
            col_dgv_ReturnDate = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_ReturnDate", "Return", Kontrabon.COL_DB_ReturnDate, true, true, "", false, false, 40, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_AssignedAmount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_AssignedAmount", "Assigned", Kontrabon.COL_AssignedAmount, true, true, "N2", false, false, 50, DataGridViewContentAlignment.MiddleRight);
            col_dgv_AmountDifference = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_MissingAmount", "Diff", Kontrabon.COL_AmountDifference, true, true, "N2", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            Util.updateForeColor(col_dgv_AmountDifference, Color.Red);
            Util.updateFontStyle(col_dgv_AmountDifference, FontStyle.Bold);

            col_dgv_Notes = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_dgv_Notes", itxt_Notes.LabelText, FakturPajak.COL_DB_Notes, true, true, "", true, false, 30, DataGridViewContentAlignment.MiddleLeft);
            col_dgv_Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            gridFakturPajaks.AutoGenerateColumns = false;
            gridFakturPajaks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridFakturPajaks_Id.DataPropertyName = FakturPajak.COL_DB_Id;
            col_gridFakturPajaks_No.DataPropertyName = FakturPajak.COL_DB_No;
            col_gridFakturPajaks_Timestamp.DataPropertyName = FakturPajak.COL_DB_Timestamp;
            col_gridFakturPajaks_DPP.DataPropertyName = FakturPajak.COL_DB_DPP;
            col_gridFakturPajaks_PPN.DataPropertyName = FakturPajak.COL_DB_PPN;
            col_gridFakturPajaks_Amount.DataPropertyName = FakturPajak.COL_TotalAmount;
            col_gridFakturPajaks_Notes.DataPropertyName = FakturPajak.COL_DB_Notes;

            gridSaleInvoices.AutoGenerateColumns = false;
            gridSaleInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridSaleInvoices_hexbarcode.DataPropertyName = Sale.COL_HEXBARCODE;
            col_gridSaleInvoices_ReceivableAmount.DataPropertyName = Sale.COL_RECEIVABLEAMOUNT;
            col_gridSaleInvoices_returnedamount.DataPropertyName = Sale.COL_RETURNEDAMOUNT;
            col_gridSaleInvoices_SaleAmount.DataPropertyName = Sale.COL_SALEAMOUNT;
            col_gridSaleInvoices_Sales_id.DataPropertyName = Sale.COL_ID;
            col_gridSaleInvoices_sale_length.DataPropertyName = Sale.COL_SALELENGTH;
            col_gridSaleInvoices_sale_qty.DataPropertyName = Sale.COL_SALEQTY;
            col_gridSaleInvoices_shippingcost.DataPropertyName = Sale.COL_DB_SHIPPINGCOST;
            col_gridSaleInvoices_timestamp.DataPropertyName = Sale.COL_DB_Timestamp;

            gridReturns.AutoGenerateColumns = false;
            gridReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridReturns_customer_name.DataPropertyName = SaleReturn.COL_Customers_Name;
            col_gridReturns_hexbarcode.DataPropertyName = SaleReturn.COL_HEXBARCODE;
            col_gridReturns_id.DataPropertyName = SaleReturn.COL_ID;
            col_gridReturns_sale_amount.DataPropertyName = SaleReturn.COL_RETURNAMOUNT;
            col_gridReturns_sale_length.DataPropertyName = SaleReturn.COL_SaleLength;
            col_gridReturns_sale_qty.DataPropertyName = SaleReturn.COL_SaleQty;
            col_gridReturns_Timestamp.DataPropertyName = SaleReturn.COL_DB_Timestamp;

            idtp_Timestamp.Value = DateTime.Now;
            idtp_ReturnDate.Value = DateTime.Now;
            Customer.populateInputControlDropDownList(iddl_Customers, true);

            idtp_StartDate.Value = DateTime.Now.AddMonths(-3);
            idtp_EndDate.Value = DateTime.Now;
            idtp_StartDate.Checked = false;
            idtp_EndDate.Checked = false;

            InputToDisableOnAdd.Add(idtp_StartDate);
            InputToDisableOnAdd.Add(idtp_EndDate);

            InputToDisableOnUpdate.Add(idtp_StartDate);
            InputToDisableOnUpdate.Add(idtp_EndDate);

            InputToDisableOnSearch.Add(idtp_Timestamp);
            InputToDisableOnSearch.Add(in_Amount);
            InputToDisableOnSearch.Add(idtp_ReturnDate);
            InputToDisableOnSearch.Add(itxt_Notes);
        }

        protected override void setupControlsBasedOnRoles()
        {
            //Helper.hideIfNoAccess(GlobalData.FakturPajak, btnRoles, FakturPajakAccessEnum.FakturPajakRoles_AddUpdate);
        }

        protected override void additionalSettings()
        {
        }

        protected override void clearInputFields()
        {
            itxt_No.reset();
            idtp_Timestamp.Value = DateTime.Now;
            iddl_Customers.reset();
            in_Amount.Value = 0;
            idtp_ReturnDate.Value = DateTime.Now;
            itxt_Notes.reset();
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return Kontrabon.get(null, itxt_No.ValueText, (Guid?)iddl_Customers.SelectedValue, idtp_StartDate.ValueAsStartDateFilter, idtp_EndDate.ValueAsEndDateFilter, chkShowOnlyApproved.Checked, false).DefaultView;
        }

        protected override void populateInputFields()
        {
            Kontrabon obj = new Kontrabon(selectedRowID());
            idtp_Timestamp.Value = obj.Timestamp;
            itxt_No.ValueText = obj.No;
            in_Amount.Value = obj.Amount;
            idtp_ReturnDate.Value = obj.ReturnDate;
            itxt_Notes.ValueText = obj.Notes;
            iddl_Customers.SelectedValue = obj.Customers_Id;
        }

        protected override void add()
        {
            Kontrabon.add((DateTime)idtp_Timestamp.ValueAsStartDateFilter, (Guid)iddl_Customers.SelectedValue, itxt_No.ValueText, in_Amount.ValueDecimal, idtp_ReturnDate.ValueAsStartDateFilter, itxt_Notes.ValueText);
        }

        protected override void update()
        {
            Kontrabon.update(selectedRowID(), (DateTime)idtp_Timestamp.ValueAsStartDateFilter, (Guid)iddl_Customers.SelectedValue, itxt_No.ValueText, in_Amount.ValueDecimal, idtp_ReturnDate.ValueAsStartDateFilter, itxt_Notes.ValueText);
        }

        protected override Boolean isInputFieldsValid()
        {
            if (itxt_No.isEmpty())
                return itxt_No.isValueError("Please provide No");
            else if (!iddl_Customers.hasSelectedValue())
                return iddl_Customers.SelectedValueError("Please select Customer");
            else if ((Mode != FormModes.Update && Kontrabon.isNoExist(null, itxt_No.ValueText))
                || (Mode == FormModes.Update && Kontrabon.isNoExist(selectedRowID(), itxt_No.ValueText)))
                return itxt_No.isValueError("No is already in the list");

            return true;
        }

        protected override void updateActiveStatus(Guid id, Boolean activeStatus)
        {
        }

        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form(selectedRowID()));
            txtQuickSearch.Focus();
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue)
        {
            Kontrabon.update_Approved(id, newValue);
            setButtonsVisibility(!newValue);
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_lastSelectedKontrabons_Id != (Guid?)Util.getSelectedRowValue(sender, col_dgv_Id))
                resetRowInfo();
        }

        protected override void dgv_CellDoubleClick()
        {
            _lastSelectedKontrabons_Id = (Guid)Util.getSelectedRowValue(dgv, col_dgv_Id);
            lblRowInfoHeader.Text = string.Format("Kontrabon No: {0}", Util.getSelectedRowValue(dgv, col_dgv_No));

            populateGridFakturPajaks(false);
            populateGridSaleInvoices(false);
            populateGridReturns(false);

            if (!ptRowInfo.isPanelVisible())
                ptRowInfo.PerformClick();

            setButtonsVisibility(!(bool)Util.getSelectedRowValue(dgv, col_dgv_Checkbox1));
        }

        private void setButtonsVisibility(bool value)
        {
            btnAddSales.Enabled =
                btnAddReturns.Enabled =
                col_gridReturns_removeKontrabons_Id.Visible =
                col_gridSaleInvoices_removeKontrabons_Id.Visible =
                col_gridFakturPajaks_removeKontrabons_Id.Visible = value;
        }

        private void resetRowInfo()
        {
            lblRowInfoHeader.Text = "";
            Util.setGridviewDataSource(gridSaleInvoices, null);
            Util.setGridviewDataSource(gridReturns, null);
            Util.setGridviewDataSource(gridFakturPajaks, null);
            tpSaleInvoices.Text = TABTITLE_SaleInvoices;
            tpFakturPajaks.Text = TABTITLE_FakturPajaks;
            tpSaleReturns.Text = TABTITLE_SaleReturns;
            setButtonsVisibility(false);
        }

        private void updateRowInfo()
        {
            populateGridSaleInvoices(false);
            populateGridReturns(false);
            populateGridFakturPajaks(false);
            populateGridViewDataSource(true); //repopulate to recalculate numbers
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Shown(object sender, EventArgs e)
        {
            ptInputPanel.PerformClick(); //by default close the panel;
            showRowInfo(DEFAULT_ROWINFOSIZE);
        }

        private void BtnAddSales_Click(object sender, EventArgs e)
        {
            if (_lastSelectedKontrabons_Id == null)
                Util.displayMessageBoxError("Double click kontrabon");
            else
            {
                Sales.Main_Form form = new Sales.Main_Form(FormModes.Browse, Util.wrapNullable<Guid?>(Util.getSelectedRowValue(dgv, col_dgv_Customers_Id)), Util.wrapNullable<Guid?>(Util.getSelectedRowValue(dgv, col_dgv_Customers_Id)));
                Util.displayForm(null, form);
                if (form.DialogResult == DialogResult.OK)
                {
                    Sale.update_Kontrabons_Id(form.BrowsedItemSelectionId, (Guid)_lastSelectedKontrabons_Id);
                    populateGridSaleInvoices(true);
                }
            }
        }

        private void BtnAddReturns_Click(object sender, EventArgs e)
        {
            if (_lastSelectedKontrabons_Id == null)
                Util.displayMessageBoxError("Double click kontrabon");
            else
            {
                if (!Util.selectedItemIsNotNull(dgv, col_dgv_Customers_Id))
                    Util.displayMessageBoxError("Invalid Customer");
                else
                {
                    Returns.Main_Form form = new Returns.Main_Form(FormModes.Browse, (Guid)Util.getSelectedRowValue(dgv, col_dgv_Customers_Id));
                    Util.displayForm(null, form);
                    if (form.DialogResult == DialogResult.OK)
                    {
                        SaleReturn.update_Kontrabons_Id(form.BrowsedItemSelectionId, (Guid)_lastSelectedKontrabons_Id);
                        populateGridReturns(true);
                    }
                }
            }
        }

        private void BtnAddFakturPajaks_Click(object sender, EventArgs e)
        {
            if (_lastSelectedKontrabons_Id == null)
                Util.displayMessageBoxError("Double click kontrabon");
            else
            {
                SharedForms.MasterData_v1_FakturPajaks_Form form = new SharedForms.MasterData_v1_FakturPajaks_Form(FormModes.Browse, (Guid)Util.getSelectedRowValue(dgv, col_dgv_Customers_Id));
                Util.displayForm(null, form);
                if (form.DialogResult == DialogResult.OK)
                {
                    FakturPajak.update_Kontrabons_Id(form.BrowsedItemSelectionId, _lastSelectedKontrabons_Id);
                    updateRowInfo();
                }
            }
        }

        private void GridSaleInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_removeKontrabons_Id))
            {
                Sale.update_Kontrabons_Id((Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id), null);
                updateRowInfo();
            }
            else if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_hexbarcode))
            {
                Sale sale = new Sale((Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id));
                var form = new Sales.Invoice_Form(sale, SaleItem.getItems(sale.id), false);
                Tools.displayForm(form);
            }
            else if (Util.isColumnMatch(sender, e, col_gridSaleInvoices_SaleAmount))
            {
                var form = new Invoices.Payment_Form(typeof(Sale), (Guid)Util.getSelectedRowValue(sender, col_gridSaleInvoices_Sales_id));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populateGridSaleInvoices(true);
                }
            }
        }

        private void GridReturns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridReturns_hexbarcode))
            {
                Util.displayForm(null, new Returns.Print_Form(Util.getSelectedRowID(sender, col_gridReturns_id)));
            }
            else if (Util.isColumnMatch(sender, e, col_gridReturns_removeKontrabons_Id))
            {
                SaleReturn.update_Kontrabons_Id((Guid)Util.getSelectedRowValue(sender, col_gridReturns_id), null);
                updateRowInfo();
            }
        }

        private void GridFakturPajaks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Util.isColumnMatch(sender, e, col_gridFakturPajaks_removeKontrabons_Id))
            {
                FakturPajak.update_Kontrabons_Id((Guid)Util.getSelectedRowValue(sender, col_gridFakturPajaks_Id), null);
                updateRowInfo();
            }
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        private void ChkShowCompleted_CheckedChanged(object sender, EventArgs e)
        {
            populateGridViewDataSource(true);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
