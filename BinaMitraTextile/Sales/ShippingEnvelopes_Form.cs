using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class ShippingEnvelopes_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private static Sale _sale;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public ShippingEnvelopes_Form(Guid SaleID)
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);
            _sale = new Sale(SaleID);
            Tools.disableResizing(this);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            populatePage();
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region FORM METHODS

        private void populatePage()
        {
            if (_sale != null)
            {
                lblShippingAddress.Text = _sale.customer_info;
            }
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LIBUtil.Util.print(chkShowPrintDialog.Checked, chkShowPrintDialog.Checked, pnlPrint);
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
