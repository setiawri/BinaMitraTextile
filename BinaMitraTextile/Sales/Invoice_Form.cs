using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class Invoice_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private Sale _sale;
        private DataTable _data;
        private bool _isGenerate = false;
        public bool isGenerated = false;
        private DataTable _saleItems;
        private decimal _totalSale = 0;

        private const int MAX_ITEMS_PER_PAGE = 12;

        private int _currentPageNo = 1;
        private int _totalPageCount = 1;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Invoice_Form(Guid saleID) : this(new Sale(saleID), SaleItem.getItems(saleID), false) {}

        public Invoice_Form(Sale Sale, DataTable _dataSaleItems, bool IsGenerate)
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);

            _sale = Sale;
            _isGenerate = IsGenerate;
            _saleItems = _dataSaleItems;

            col_griditems_price.DataPropertyName = InventoryItem.COL_SALE_ADJUSTEDPRICE;
            col_grid_inventory_color_name.DataPropertyName = InventoryItem.COL_INVENTORYCOLORNAME;

            PettyCashRecordsCategory.populateDropDownList(iddl_PettyCashCategories.Dropdownlist.combobox, false, true);
            rbCash.Checked = true;

            iddl_PaymentMethods.populate(typeof(PaymentMethod));
            iddl_PaymentMethods.SelectedItem = PaymentMethod.Cash;

            populatePage();

            if (_isGenerate)
            {
                btnPackingList.Enabled = false;
                pnlSubmit1.Visible = true;
                pnlSubmit2.Visible = true;
                btnPrint.Enabled = false;
                btnEdit.Enabled = true;
                btnPayment.Enabled = false;
                btnAddNotes.Enabled = false;
            }
            else
            {
                //barcode.DataToEncode = _sale.barcode;
                lblInvoiceNo.Text = _sale.barcode;
                btnPackingList.Enabled = true;
                pnlSubmit1.Visible = false;
                pnlSubmit2.Visible = false;
                btnPrint.Enabled = true;
                btnEdit.Enabled = false;
                btnPayment.Enabled = true;
                btnAddNotes.Enabled = true;
            }

            Tools.disableResizing(this);

            grid.AutoGenerateColumns = false;
        }

        private void populatePage()
        {
            if (_sale.ReturnedToSupplier)
                this.Text = lblTitle.Text = "RETUR VENDOR";
            else
                this.Text = "INVOICE";

            lblInvoiceNo.Text = "";
            lblDate.Text = String.Format("Date: {0:dd/MM/yy hh:mm}", _sale.time_stamp);

            //customer info
            lblCustomerInfo.Text = _sale.customer_info;

            //sale summary
            grid.AutoGenerateColumns = false;
            if (_isGenerate)
            {
                _data = _saleItems;
                _data = Sale.compileSummaryData(_data);
            }
            else
            {
                _data = SaleItem.getItemSummary(_sale.id);
            }

            //sort
            DataView dvw = _data.DefaultView;
            dvw.Sort = InventoryItem.COL_INVENTORY_CODE + " ASC";
            _data = dvw.ToTable();

            //grid.DataSource = _data;
            _totalPageCount = (int)Math.Ceiling((decimal)_data.Rows.Count / MAX_ITEMS_PER_PAGE);
            populateGrids();

            _totalSale = Convert.ToDecimal(_data.Compute(String.Format("SUM({0})", InventoryItem.COL_SALE_SUBTOTAL), ""));

            lblShippingCost.Text = string.Format("Angkutan {0}: {1:N0}", _sale.TransportName, _sale.ShippingCost);

            Inventory.setAmount(lblTotalSale, _totalSale.ToString());
            Inventory.setAmount(lblGrandTotal, (_totalSale + _sale.ShippingCost).ToString());
            Inventory.setCount(lblTotalCounts, 
                _data.Compute(String.Format("SUM({0})", InventoryItem.COL_SALE_QTY), "").ToString(), 
                _data.Compute(String.Format("SUM({0})", InventoryItem.COL_LENGTH), "").ToString());

            txtNotes.Text = Tools.applyNewLines(_sale.notes);

            if (_isGenerate)
            {
                decimal totalDue = _totalSale + _sale.ShippingCost;
                txtPaymentAmount.Text = totalDue.ToString("N0");
                rbCash1.Text = ((Math.Ceiling(totalDue / 10000) * 10000) - 5000).ToString("N0");
                if (LIBUtil.Util.zeroNonNumericString(rbCash1.Text) < LIBUtil.Util.zeroNonNumericString(txtPaymentAmount.Text))
                    rbCash1.Text = txtPaymentAmount.Text;
                rbCash2.Text = (Math.Ceiling(totalDue / 10000) * 10000).ToString("N0");
                rbCash3.Text = ((Math.Ceiling(totalDue / 100000) * 100000) - 50000).ToString("N0");
                if (LIBUtil.Util.zeroNonNumericString(rbCash3.Text) < LIBUtil.Util.zeroNonNumericString(txtPaymentAmount.Text))
                {
                    rbCash3.Text = rbCash2.Text;
                    rbCash2.Text = rbCash1.Text;
                    rbCash1.Text = txtPaymentAmount.Text;
                }
                rbCash4.Text = (Math.Ceiling(totalDue / 100000) * 100000).ToString("N0");
            }
        }

        private void populateGrids()
        {
            int startIdx = (_currentPageNo - 1) * MAX_ITEMS_PER_PAGE;

            if ((_data.Rows.Count - startIdx) >= MAX_ITEMS_PER_PAGE)
            {
                grid.DataSource = Tools.copyTableRows(_data, startIdx, MAX_ITEMS_PER_PAGE);
            }
            else
            {
                grid.DataSource = Tools.copyTableRows(_data, startIdx, _data.Rows.Count - startIdx);
            }

            setPaging(_data.Rows.Count);

            lblPageCount.Text = string.Format("Page {0}/{1}", _currentPageNo, _totalPageCount);
        }

        private void setPaging(int intRowCount)
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            if (intRowCount > MAX_ITEMS_PER_PAGE)
            {
                if (_currentPageNo < _totalPageCount)
                    btnNext.Enabled = true;

                if (_currentPageNo > 1)
                    btnPrevious.Enabled = true;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //Tools.adjustGridviewForVScrollbar(this,true);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region FORM METHODS

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPackingList_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Sales.PackingList_Form(_sale.id));
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var form = new Invoices.Payment_Form(typeof(Sale), _sale.id);
            Tools.displayForm(form);
            if (form.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new SharedForms.Add_Notes_Form(_sale.id, Sale.PROC_ADDNOTES));
            _sale = new Sale(_sale.id);
            populatePage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPageNo += 1;
            populateGrids();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentPageNo -= 1;
            populateGrids();
        }

        private void chkHidePrices_CheckedChanged(object sender, EventArgs e)
        {
            col_griditems_price.Visible = !chkHidePrices.Checked;
            col_griditems_subtotal.Visible = !chkHidePrices.Checked;
            lblTotalSale.Visible = !chkHidePrices.Checked;
            lblShippingCost.Visible = !chkHidePrices.Checked;
            lblGrandTotal.Visible = !chkHidePrices.Checked;

            if (!chkHidePrices.Checked)
                lblTitle.Text = "INVOICE";
            else
                lblTitle.Text = "SURAT JALAN";
        }

        private void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, false, true);
            calculateChange();
        }

        private void rbCash1_CheckedChanged(object sender, EventArgs e)
        {
            selectPaymentAmount(sender);
        }

        private void rbCash2_CheckedChanged(object sender, EventArgs e)
        {
            selectPaymentAmount(sender);
        }

        private void rbCash3_CheckedChanged(object sender, EventArgs e)
        {
            selectPaymentAmount(sender);
        }

        private void rbCash4_CheckedChanged(object sender, EventArgs e)
        {
            selectPaymentAmount(sender);
        }

        private void txtPaymentAmount_Click(object sender, EventArgs e)
        {
            rbCash1.Checked = false;
            rbCash2.Checked = false;
            rbCash3.Checked = false;
            rbCash4.Checked = false;
            txtPaymentAmount.Text = "";
        }

        private void selectPaymentAmount(object radiobutton)
        {
            txtPaymentAmount.Text = ((RadioButton)radiobutton).Text;
            calculateChange();
        }

        private void calculateChange()
        {
            if (pnlSubmit1.Visible && (PaymentMethod)iddl_PaymentMethods.SelectedValue == PaymentMethod.Cash)
            {
                lblPayment.Visible = true;
                decimal change = Tools.zeroNonNumericString(txtPaymentAmount.Text) - (_totalSale + _sale.ShippingCost);
                if(change < 0)
                {
                    lblPayment.Text = string.Format("CASH: {0}, Kurang: {1:N0}", txtPaymentAmount.Text, change);
                    lblPayment.ForeColor = Color.Red;
                }
                else
                {
                    lblPayment.Text = string.Format("CASH: {0}, Kembali: {1:N0}", txtPaymentAmount.Text, change);
                    lblPayment.ForeColor = Color.Black;
                }
            }
            else
            {
                lblPayment.Visible = false;
            }
        }

        private void cbPaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateChange();
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(submit())
            {
                pnlSubmit1.Visible = false;
                pnlSubmit2.Visible = false;
                btnPrint.Enabled = true;
                btnPackingList.Enabled = true;
                btnEdit.Enabled = false;
                btnPayment.Enabled = true;
                isGenerated = true;
            }
        }

        private bool submit()
        {
            if (!iddl_PettyCashCategories.hasSelectedValue())
                return iddl_PettyCashCategories.SelectedValueError("Pilih Kategori");
            else if (!iddl_PaymentMethods.hasSelectedValue())
                return iddl_PaymentMethods.SelectedValueError("Pilih Metode Pembayaran");
            else if (!Tools.hasMessage(_sale.submitNew(_saleItems)))
            {
                //barcode.DataToEncode = _sale.barcode;
                lblInvoiceNo.Text = _sale.barcode;

                //record petty cash
                decimal paymentAmount = Tools.zeroNonNumericString(txtPaymentAmount.Text);
                PaymentMethod paymentMethod = (PaymentMethod)iddl_PaymentMethods.SelectedValue;
                if (paymentMethod == PaymentMethod.Cash)
                {
                    bool isFullPayment = false;
                    if (paymentAmount >= _totalSale + _sale.ShippingCost)
                    {
                        //Tools.displayForm(new SharedForms.Verify_Form("KEMBALI", string.Format("Rp. {0:N0}", paymentAmount - (_totalSale + _sale.ShippingCost)), SharedForms.VerifyFormFontSize.Medium));
                        paymentAmount = _totalSale + _sale.ShippingCost;
                        isFullPayment = true;
                    }

                    Guid paymentId = Payment.add(_sale.id, (PaymentMethod)iddl_PaymentMethods.SelectedValue, paymentAmount, null);
                    Guid pettyCashRecordId = PettyCashRecord.add((Guid)iddl_PettyCashCategories.SelectedValue, paymentAmount, string.Format("{0}", _sale.barcode));

                    if (isFullPayment)
                    {
                        Payment.updateCheckedStatus(paymentId, true);
                        PettyCashRecord.updateCheckedStatus(pettyCashRecordId, true);
                    }
                }
                else
                {
                    Guid pettyCashRecordId = PettyCashRecord.add((Guid)iddl_PettyCashCategories.SelectedValue, 0, string.Format("{0} {1} {2:N0}", _sale.barcode, Tools.GetEnumDescription((PaymentMethod)iddl_PaymentMethods.SelectedValue), lblGrandTotal.Text));
                    if (paymentMethod == PaymentMethod.Hutang || paymentMethod == PaymentMethod.Transfer || paymentMethod == PaymentMethod.EDC)
                        PettyCashRecord.updateCheckedStatus(pettyCashRecordId, true);

                    Tools.hasMessage("The sale has been submitted"); //only shows this message here. Cash payments shows form kembalian
                }


                return true;
            }
            else
                return false;
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!chkPrintAllPages.Checked)
                LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
            else
            {
                _currentPageNo = 1;
                populateGrids();
                LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
                while (btnNext.Enabled)
                {
                    btnNext.PerformClick();
                    LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
                }
            }
        }

        private void rbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            iddl_PaymentMethods.SelectedItem = PaymentMethod.Transfer;
            iddl_PettyCashCategories.SelectedItemText = "Penjualan Non-Tunai";
        }

        private void rbHutang_CheckedChanged(object sender, EventArgs e)
        {
            iddl_PaymentMethods.SelectedItem = PaymentMethod.Hutang;
            iddl_PettyCashCategories.SelectedItemText = "Penjualan Non-Tunai";
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            iddl_PaymentMethods.SelectedItem = PaymentMethod.Cash;
            iddl_PettyCashCategories.SelectedItemText = "Penjualan Tunai";
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/


    }
}
