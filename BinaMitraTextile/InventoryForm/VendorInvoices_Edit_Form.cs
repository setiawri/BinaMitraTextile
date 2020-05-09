using System;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.InventoryForm
{
    public partial class VendorInvoices_Edit_Form : Form
    {
        VendorInvoice _vendorInvoice = null;
        FakturPajak _fakturPajak = null;

        public VendorInvoices_Edit_Form(Guid id)
        {
            InitializeComponent();

            _vendorInvoice = new VendorInvoice(id);
            if (_vendorInvoice.FakturPajaks_Id != null)
                _fakturPajak = new FakturPajak(_vendorInvoice.FakturPajaks_Id);
            btnRemoveFakturPajakFromVendorInvoice.Enabled = (_vendorInvoice.FakturPajaks_Id != null);
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
        }
        
        private void populatePageData()
        {            
            idtp_Timestamp.Value = _vendorInvoice.Timestamp;
            itxt_InvoiceNo.ValueText = _vendorInvoice.InvoiceNo;
            in_TOP.Value = _vendorInvoice.TOP;
            in_Amount.Value = _vendorInvoice.Amount;
            itxt_Notes.ValueText = _vendorInvoice.Notes;

            populateFakturPajak();
        }

        private void populateFakturPajak()
        {
            if (_fakturPajak == null)
                resetFakturPajakData();
            else
            {
                idtp_FakturPajak_Timestamp.Value = _fakturPajak.Timestamp;
                itxt_FakturPajak_No.ValueText = _fakturPajak.No;
                in_FakturPajak_DPP.Value = _fakturPajak.DPP;
                in_FakturPajak_PPN.Value = _fakturPajak.PPN;
                itxt_FakturPajak_Notes.ValueText = _fakturPajak.Notes;
            }
        }

        private void resetFakturPajakData()
        {
            idtp_FakturPajak_Timestamp.Value = _vendorInvoice.Timestamp;
            itxt_FakturPajak_No.ValueText = "";
            in_FakturPajak_DPP.Value = 0;
            in_FakturPajak_PPN.Value = 0;
            itxt_FakturPajak_Notes.ValueText = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                VendorInvoice.update(_vendorInvoice.ID, (DateTime)idtp_Timestamp.ValueAsStartDateFilter, itxt_InvoiceNo.ValueText, in_Amount.ValueDecimal, in_TOP.ValueInt, itxt_Notes.ValueText);

                if (_fakturPajak != null) //edit assigned FP
                    FakturPajak.update(_fakturPajak.Id, (DateTime)idtp_Timestamp.ValueAsStartDateFilter, null, _vendorInvoice.Vendors_Id, itxt_FakturPajak_No.ValueText, in_FakturPajak_DPP.ValueDecimal, in_FakturPajak_PPN.ValueDecimal, itxt_FakturPajak_Notes.ValueText);
                else if (!itxt_FakturPajak_No.isEmpty()) //add new FP
                {
                    Guid FakturPajaks_Id = FakturPajak.add((DateTime)idtp_Timestamp.ValueAsStartDateFilter, null, _vendorInvoice.Vendors_Id, itxt_FakturPajak_No.ValueText, in_FakturPajak_DPP.ValueDecimal, in_FakturPajak_PPN.ValueDecimal, itxt_FakturPajak_Notes.ValueText);
                    VendorInvoice.update_FakturPajaks_Id(_vendorInvoice.ID, FakturPajaks_Id);
                }

                this.Close();
            }
        }

        private bool isInputValid()
        {
            if (itxt_InvoiceNo.isEmpty())
                return itxt_InvoiceNo.isValueError("Invalid Invoice No");
            else if (VendorInvoice.isInvoiceNoExist(_vendorInvoice.ID, itxt_InvoiceNo.ValueText))
                return itxt_InvoiceNo.isValueError("Invoice No already exists");
            
            if(_fakturPajak != null) //edit assigned FP
            {
                if (itxt_FakturPajak_No.isEmpty())
                    return itxt_FakturPajak_No.isValueError("Please provide No");
                else if (FakturPajak.isNoExist(_fakturPajak.Id, itxt_FakturPajak_No.ValueText))
                    return itxt_FakturPajak_No.isValueError("FP No already exists");
            }
            else if (!itxt_FakturPajak_No.isEmpty()) //add new FP
            {
                if (FakturPajak.isNoExist(null, itxt_FakturPajak_No.ValueText))
                    return itxt_FakturPajak_No.isValueError("FP No already exists");
            }

            return true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            populatePageData();
        }

        private void BtnRemoveFakturPajakFromVendorInvoice_Click(object sender, EventArgs e)
        {
            if(Util.displayMessageBoxYesNo("Remove FP connection to this Invoice? FP is NOT deleted"))
            {
                VendorInvoice.update_FakturPajaks_Id(_vendorInvoice.ID, null);
                _vendorInvoice = new VendorInvoice(_vendorInvoice.ID);
                if (_vendorInvoice.FakturPajaks_Id == null)
                    _fakturPajak = null;
                else
                    _fakturPajak = new FakturPajak(_vendorInvoice.FakturPajaks_Id);
                btnRemoveFakturPajakFromVendorInvoice.Enabled = (_vendorInvoice.FakturPajaks_Id != null);
                populateFakturPajak();
            }
        }

        private void In_FakturPajak_DPP_ValueChanged(object sender, EventArgs e)
        {
            in_FakturPajak_PPN.Value = Math.Floor(in_FakturPajak_DPP.ValueDecimal / 10);
        }

        private void Idtp_Timestamp_ValueChanged(object sender, EventArgs e)
        {
            idtp_FakturPajak_Timestamp.Value = idtp_Timestamp.Value;
        }
    }
}
