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
    public partial class VendorInvoices_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public VendorInvoices_Form()
        {
            InitializeComponent();
            
            setupControls();
            populatePageData();
        }

        public void setupControls()
        {
            gridvendorinvoice.AutoGenerateColumns = false;
            gridvendorinvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridvendorinvoice_id.DataPropertyName = VendorInvoice.COL_DB_ID;
            col_gridvendorinvoice_timestamp.DataPropertyName = VendorInvoice.COL_DB_TIMESTAMP;
            col_gridvendorinvoice_invoiceno.DataPropertyName = VendorInvoice.COL_DB_INVOICENO;
            col_gridvendorinvoice_vendorname.DataPropertyName = VendorInvoice.COL_VendorName;
            col_gridvendorinvoice_taxno.DataPropertyName = VendorInvoice.COL_DB_TAXNO;
            col_gridvendorinvoice_dpp.DataPropertyName = VendorInvoice.COL_DB_TAXDPP;
            col_gridvendorinvoice_totaldppppn.DataPropertyName = VendorInvoice.COL_TOTALDPPPPN;
            col_gridvendorinvoice_totalactualvalue.DataPropertyName = VendorInvoice.COL_TOTALACTUALVALUE;
            col_gridvendorinvoice_notes.DataPropertyName = VendorInvoice.COL_DB_NOTES;
            col_gridvendorinvoice_statusenumid.DataPropertyName = VendorInvoice.COL_DB_STATUSENUMID;
            col_gridvendorinvoice_statusname.DataPropertyName = VendorInvoice.COL_STATUSNAME;
            col_gridvendorinvoice_top.DataPropertyName = VendorInvoice.COL_DB_TOP;
            col_gridvendorinvoice_isdue.DataPropertyName = VendorInvoice.COL_ISDUE;
            col_gridvendorinvoice_PayableAmount.DataPropertyName = VendorInvoice.COL_PayableAmount;

            addStatusContextMenu(col_gridvendorinvoice_statusname);

            gridinventory.AutoGenerateColumns = false;
            Tools.clearWhenSelected(gridinventory);
            col_gridinventory_id.DataPropertyName = Inventory.COL_DB_ID;
            col_gridinventory_receivedate.DataPropertyName = Inventory.COL_DB_RECEIVEDATE;
            col_gridinventory_code.DataPropertyName = Inventory.COL_DB_CODE;
            col_gridinventory_gradename.DataPropertyName = Inventory.COL_GRADE_NAME;
            col_gridinventory_productname.DataPropertyName = Inventory.COL_PRODUCTSTORENAME;
            col_gridinventory_productwidthname.DataPropertyName = Inventory.COL_PRODUCT_WIDTH_NAME;
            col_gridinventory_colorname.DataPropertyName = Inventory.COL_COLOR_NAME;
            col_gridinventory_buyprice.DataPropertyName = Inventory.COL_DB_BUYPRICE;
            col_gridinventory_unitname.DataPropertyName = Inventory.COL_LENGTH_UNIT_NAME;
            col_gridinventory_packinglistno.DataPropertyName = Inventory.COL_DB_PACKINGLISTNO;
        }

        public void populatePageData()
        {
            populateGridVendorInvoice();

            if (gridvendorinvoice.Rows.Count > 0)
            {
                btnLog.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnLog.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new VendorInvoices_Edit_Form(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
            populatePageData();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
        }

        private void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Tools.displayContextMenu(sender, e);
        }

        public void addStatusContextMenu(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (VendorInvoiceStatus status in Tools.GetEnumItems<VendorInvoiceStatus>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription(status), null, changeStatus_Click));
        }

        public void changeStatus_Click(object sender, EventArgs args)
        {
            VendorInvoice.updateStatus(Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id), Tools.parseEnum<VendorInvoiceStatus>(sender.ToString()));
            populateGridVendorInvoice();
        }

        private void gridvendorinvoice_SelectionChanged(object sender, EventArgs e)
        {
            if(gridvendorinvoice.SelectedRows.Count > 0)
                Tools.setGridviewDataSource(gridinventory, false, false, Inventory.getAll(true, false, null, null, null, null, null, null, null, Tools.getSelectedRowID(gridvendorinvoice, col_gridvendorinvoice_id)));
        }

        private void btnSupplierDebits_Click(object sender, EventArgs e)
        {
            Tools.displayForm(this, new Invoices.VendorDebits_Form());
        }

        private void gridvendorinvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridvendorinvoice_PayableAmount.Name))
            {
                var form = new Invoices.Payment_Form(typeof(VendorInvoice), new Guid(gridvendorinvoice.Rows[e.RowIndex].Cells[col_gridvendorinvoice_id.Name].Value.ToString()));
                Tools.displayForm(form);
                if (form.DialogResult == DialogResult.OK)
                {
                    populatePageData();
                }
            }
        }

        #endregion
        /*******************************************************************************************************/
        #region FORM METHODS

        private void populateGridVendorInvoice()
        {
            Tools.setGridviewDataSource(gridvendorinvoice, true, true, VendorInvoice.get(null, null, true));
        }

        #endregion
        /*******************************************************************************************************/
    }
}
