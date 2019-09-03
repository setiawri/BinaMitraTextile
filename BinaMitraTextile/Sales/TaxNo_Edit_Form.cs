using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class TaxNo_Edit_Form : Form
    {
        private Guid _id;

        public TaxNo_Edit_Form(Guid id)
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
            Sale obj = new Sale(_id);
            txtTaxNo.Text = obj.TaxNo;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                Sale.updateTaxNo(_id, Tools.wrapDBNullValue<string>(txtTaxNo.Text));
                this.Close();
            }
        }

        private bool isInputValid()
        {
            DBUtil.sanitize(txtTaxNo);

            return true;
        }
    }
}
