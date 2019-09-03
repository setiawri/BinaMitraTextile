using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile
{
    public partial class Template_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Template_Form()
        {
            InitializeComponent();

            setupControls();
            populatePageData();
        }

        private void Form_Load(object sender, EventArgs e) { }

        private void setupControls()
        {
            //grid.AutoGenerateColumns = false;
            //grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grid.Columns[Method.Name].DataPropertyName = SalePayment.COL_METHODNAME;
        }

        private void populatePageData()
        {

        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        #endregion LIST
        /*******************************************************************************************************/
        #region FORM METHODS
        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS
        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
