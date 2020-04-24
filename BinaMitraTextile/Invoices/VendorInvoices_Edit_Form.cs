using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Invoices
{
    public partial class VendorInvoices_Edit_Form : Form
    {
        private Guid _id;

        public VendorInvoices_Edit_Form(Guid id)
        {
            InitializeComponent();

            _id = id;
        }

        private void setupControls()
        {
            
            
        }
        
        private void populatePageData()
        {
            VendorInvoice obj = new VendorInvoice(_id);
            idtp_Timestamp.Value = obj.Timestamp;
            itxt_InvoiceNo.ValueText = obj.InvoiceNo;
            in_TOP.Value = obj.TOP;
            in_Amount.Value = obj.Amount;
            itxt_Notes.ValueText = obj.Notes;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                VendorInvoice.update(_id, (DateTime)idtp_Timestamp.ValueAsStartDateFilter, itxt_InvoiceNo.ValueText, in_Amount.ValueDecimal, in_TOP.ValueInt, itxt_Notes.ValueText);
                this.Close();
            }
        }

        private bool isInputValid()
        {
            if (itxt_InvoiceNo.isEmpty())
                return itxt_InvoiceNo.isValueError("Invalid Invoice No");
            else if (VendorInvoice.isInvoiceNoExist(_id, itxt_InvoiceNo.ValueText))
                return itxt_InvoiceNo.isValueError("Invalid Invoice No already exists");

            return true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        private void Form_Shown(object sender, EventArgs e)
        {

        }
    }
}
