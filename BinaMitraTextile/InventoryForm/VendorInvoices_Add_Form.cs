using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.InventoryForm
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
            Settings.setGeneralSettings(this);
            this.DialogResult = DialogResult.Cancel;
        }

        private void populatePageData() { }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                VendorInvoice.add(itxt_VendorInvoices_No.ValueText, (Guid)iddl_Vendors.SelectedValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool isInputValid()
        {
            if (itxt_VendorInvoices_No.isEmpty())
                return itxt_VendorInvoices_No.isValueError("Invalid Invoice number");
            else if (!iddl_Vendors.isValidSelectedValue())
                return iddl_Vendors.SelectedValueError("Invalid Vendor");
            else if (VendorInvoice.isInvoiceNoExist(null, itxt_VendorInvoices_No.ValueText))
                return itxt_VendorInvoices_No.isValueError("Invoice number already exists");

            return true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Vendor.populateInputControlDropDownList(iddl_Vendors, true);
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            itxt_VendorInvoices_No.focus();
        }
    }
}
