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
            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            
            
        }
        
        private void populatePageData()
        {
            VendorInvoice obj = new VendorInvoice(_id);
            lblActualValue.Text = obj.TotalActualValue.ToString("N2");
            txtInvoiceNo.Text = obj.InvoiceNo;
            txtTaxNo.Text = obj.TaxNo;
            txtDPP.Text = obj.TaxDPP.ToString("N2");
            txtTOP.Text = obj.TOP.ToString("N2");
            txtNotes.Text = obj.Notes;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                VendorInvoice.update(_id, txtInvoiceNo.Text, txtTaxNo.Text, Tools.zeroNonNumericString(txtDPP.Text), 
                    Convert.ToInt32(txtTOP.Text), chkSetorTunai.Checked, txtNotes.Text);
                this.Close();
            }
        }

        private bool isInputValid()
        {
            DBUtil.sanitize(txtInvoiceNo, txtTaxNo, txtDPP, txtTOP, txtNotes);

            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
                return Tools.inputError<TextBox>(txtInvoiceNo, "Invalid Invoice number");
            else if (VendorInvoice.isInvoiceNoExist(_id, txtInvoiceNo.Text))
                return Tools.inputError<TextBox>(txtInvoiceNo, "Invoice number already exists");
            else if (!Tools.isNumeric(txtDPP.Text))
                return Tools.inputError<TextBox>(txtDPP, "Invalid DPP");
            else if (string.IsNullOrWhiteSpace(txtTOP.Text) || !Tools.isNumeric(txtTOP.Text))
                return Tools.inputError<TextBox>(txtDPP, "Invalid TOP");

            return true;
        }
    }
}
