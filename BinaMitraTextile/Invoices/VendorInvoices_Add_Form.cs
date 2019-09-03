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
    public partial class VendorInvoices_Add_Form : Form
    {
        public VendorInvoices_Add_Form()
        {
            InitializeComponent();

            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void populatePageData() { }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                VendorInvoice.add(txtInvoiceNo.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool isInputValid()
        {
            DBUtil.sanitize(txtInvoiceNo);

            if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
                return Tools.inputError<TextBox>(txtInvoiceNo, "Invalid Invoice number");
            else if (VendorInvoice.isInvoiceNoExist(null, txtInvoiceNo.Text))
                return Tools.inputError<TextBox>(txtInvoiceNo, "Invoice number already exists");

            return true;
        }
    }
}
