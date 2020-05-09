using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;

namespace BinaMitraTextile.POs
{
    public partial class Print_Form : Form
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES

        private Guid _id;

        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES        
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Print_Form(Guid id)
        {
            InitializeComponent();

            _id = id;

            setupControls();
            populatePageData();
        }

        private void Form_Load(object sender, EventArgs e) 
        {
            gridPOItems.ClearSelection();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            Tools.disableResizing(this);

            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridPOItems_id.DataPropertyName = POItem.COL_DB_ID;
            col_gridPOItems_no.DataPropertyName = POItem.COL_DB_LINENO;
            col_gridPOItems_productDescription.DataPropertyName = POItem.COL_DB_PRODUCTDESCRIPTION;
            col_gridPOItems_qty.DataPropertyName = POItem.COL_DB_QTY;
            col_gridPOItems_unitName.DataPropertyName = POItem.COL_DB_UNITNAME;
            col_gridPOItems_pricePerUnit.DataPropertyName = POItem.COL_DB_PRICEPERUNIT;
            col_gridPOItems_subtotal.DataPropertyName = POItem.COL_SUBTOTAL;
            col_gridPOItems_notes.DataPropertyName = POItem.COL_DB_NOTES;

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_gridPOItems_pricePerUnit.Visible = false;
                col_gridPOItems_subtotal.Visible = false;
                lblTotalAmount.Visible = false;
            }
        }

        private void populatePageData()
        {
            PO po = new PO(_id);
            lblPONo.Text = po.PONo;
            lblVendorInfo.Text = po.VendorInfo;
            lblDate.Text = string.Format("{0:dd/MM/yy}", po.Timestamp);
            lblNotes.Text = Tools.applyNewLines(po.Notes);

            DataTable datatable = POItem.getItems(_id);
            gridPOItems.DataSource = datatable;
            foreach (DataGridViewRow row in gridPOItems.Rows)
            {
                row.Cells[col_gridPOItems_productDescription.Name].Value += Environment.NewLine + row.Cells[col_gridPOItems_notes.Name].Value.ToString();
            }

            lblTotalAmount.Text = String.Format("Rp. {0:n2}", po.Amount);
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region FORM METHODS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                btnPrint.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region PRINT METHODS

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LIBUtil.Util.print(true, false, pnlPrint);
        }

        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
