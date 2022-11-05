using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace BinaMitraTextile.Sales
{
    public partial class ShippingLabels_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private static Sale _sale;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public ShippingLabels_Form(Guid SaleID)
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
                Label label = new Label();
                Font font = label.Font;
                font = new Font(font.FontFamily, 7);
                bool isOutOfBound = false;
                while (!isOutOfBound)
                {
                    label = new Label();
                    label.AutoSize = true;
                    label.Font = font;
                    label.Margin = new Padding(0, 0, 0, 0);
                    label.Padding = new Padding(5,5,5,5);
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Text += "DARI: CV. BINA MITRA TEXTILE";
                    label.Text += Environment.NewLine + "Jl. Mayor Sunarya Blok K No. 11A";
                    label.Text += Environment.NewLine + "Bandung, Jawa Barat";
                    label.Text += Environment.NewLine + "081.2240.44338";
                    label.Text += Environment.NewLine;
                    label.Text += Environment.NewLine + "TUJUAN: ";
                    label.Text += _sale.customer_info;

                    flpShippingLabels.Controls.Add(label);

                    isOutOfBound = (label.Location.Y + label.Size.Height) > flpShippingLabels.Height;
                    if (isOutOfBound)
                        flpShippingLabels.Controls.Remove(label);
                }
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
