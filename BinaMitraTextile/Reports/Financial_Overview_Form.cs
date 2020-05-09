using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Reports
{
    public partial class Financial_Overview_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Financial_Overview_Form()
        {
            InitializeComponent();

            setupControls();
            populatePageData();
        }

        private void Form_Load(object sender, EventArgs e) { }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
        }

        private void populatePageData()
        {
            FinancialOverview overview = Financial.getOverview();
            lblInventoryBuyValue.Text = overview.InventoryBuyValue.ToString("N2");
            lnkReceivablesAmount.Text = overview.ReceivableAmount.ToString("N2");
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM
        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS

        private void lnkReceivablesAmount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.displayForm(new Sales.Main_Form(true));
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION
        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region PRINT METHODS
        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
