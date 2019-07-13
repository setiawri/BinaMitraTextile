using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.POs
{
    public partial class Add_Edit_Form : Form
    {
        /*******************************************************************************************************/
        #region VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region PUBLIC VARIABLES
        #endregion PUBLIC VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #region CLASS VARIABLES

        private Guid _vendorID;
        private Guid _id;
        private FormMode _formMode = FormMode.New;

        #endregion CLASS VARIABLES
        /*-----------------------------------------------------------------------------------------------------*/
        #endregion VARIABLES        
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Add_Edit_Form(FormMode mode, Guid? id)
        {
            InitializeComponent();

            _formMode = mode;
            if (id != null) _id = (Guid)id;
            setupControls();
            populatePageData();
        }

        public Add_Edit_Form(List<POItemToOrder> items) : this(FormMode.New, null) 
        {
            if (items.Count > 0)
            {
                cbVendors.SelectedValue = new Inventory(items[0].InventoryID).VendorID;
                for (int i = 0; i < items.Count; i++)
                {
                    addItem(new Inventory(items[i].InventoryID), items[i].Qty, i, items[i].PONotes);
                    calculateSubtotal(i);
                }

                calculateGrandTotal();
            }
        }

        public Add_Edit_Form(Guid id) : this(FormMode.Update, id) { }

        public Add_Edit_Form() : this(FormMode.New, null) { }

        private void Form_Load(object sender, EventArgs e) { }

        private void setupControls()
        {
            this.Text += DBUtil.appendTitleWithInfo();

            txtPONo.Text = PO.getNextPONo(); //default PO number
            dtpTarget.Value = DateTime.Now.AddDays(14); //default target date

            populateDropVendors();
            lblVendorInfo.Text = "";

            gridPOItems.Enabled = false;
            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.Rows.Add();
            Tools.formatDeleteColumn(col_gridPOItems_deleteRow);

            if(_formMode == FormMode.Update)
            {
                txtPONo.Enabled = false;
                cbVendors.Enabled = false;
                txtNotes.Enabled = false;
                foreach (DataGridViewColumn column in gridPOItems.Columns)
                    if(column != col_gridPOItems_pricePerUnit)
                        column.ReadOnly = true;
            }

            calculateGrandTotal();
        }

        private void populateDropVendors()
        {
            Vendor.populateDropDownList(cbVendors, false, true);
        }

        private void populatePageData()
        {
            
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST

        private void gridPOItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridPOItems_findInventory.Name))
            {
                var browseForm = new InventoryForm.Main_Form(FormMode.Browse, (Guid?)cbVendors.SelectedValue);
                Tools.displayForm(browseForm);
                if (browseForm.DialogResult == DialogResult.OK)
                {
                    addItem(new Inventory(browseForm.browseSelection), 0, e.RowIndex, null);
                }
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewLinkColumn), col_gridPOItems_deleteRow.Name))
            {
                addNewRowIfNeeded(e.RowIndex);
                gridPOItems.Rows.Remove(gridPOItems.Rows[e.RowIndex]);
            }
        }

        private void addItem(Inventory inventory, int qty, int rowIndex, string notes)
        {
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_productName.Name].Value = inventory.id;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_productName.Name].Value = inventory.product_name_vendor;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_widthName.Name].Value = inventory.product_width_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_gradeName.Name].Value = inventory.grade_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_colorName.Name].Value = inventory.color_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_unitName.Name].Value = inventory.length_unit_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_pricePerUnit.Name].Value = inventory.buy_price;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_referencedInventoryID.Name].Value = inventory.id;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_qty.Name].Value = qty;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_notes.Name].Value = notes ?? string.Empty;
            if (inventory.id != null)
                gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_notes.Name].Value += string.Format(" Last:{0:dd/MM/yy}", inventory.receive_date);
            addNewRowIfNeeded(rowIndex);
        }

        private void gridPOItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_qty.Name) || Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_pricePerUnit.Name))
            {
                calculateSubtotal(e.RowIndex);
                calculateGrandTotal();
            }
            addNewRowIfNeeded(e.RowIndex);
        }

        private void addNewRowIfNeeded(int currentRowIndex)
        {
            if (currentRowIndex == gridPOItems.Rows.Count - 2)
            {
                gridPOItems.Rows.Add();
            }
        }

        private void calculateSubtotal(int rowIndex)
        {
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_subtotal.Name].Value =
                Tools.zeroNonNumericString(gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_qty.Name].Value)
                * Tools.zeroNonNumericString(gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_pricePerUnit.Name].Value);
        }

        #endregion LIST
        /*******************************************************************************************************/
        #region FORM METHODS
        
        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Vendors_Form(FormMode.New));
            populateDropVendors();
        }

        private void cbVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid selectedVendorID;
            if (cbVendors.SelectedIndex > -1 && Guid.TryParse(cbVendors.SelectedValue.ToString(), out selectedVendorID))
            {
                lblVendorInfo.Text = new Vendor(selectedVendorID).Info;
                gridPOItems.Enabled = true;
                if(selectedVendorID != _vendorID)
                {
                    gridPOItems.Rows.Clear();
                    gridPOItems.Rows.Add();
                    _vendorID = selectedVendorID;
                }
            }
            else
            {
                lblVendorInfo.Text = "";
                gridPOItems.Enabled = false;
            }
        }

        private void calculateGrandTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in gridPOItems.Rows)
            {
                if (isValidProductName(row) && isValidQty(row))
                    total += Convert.ToDecimal(row.Cells[col_gridPOItems_subtotal.Name].Value);
            }
            lblTotalAmount.Text = string.Format("Total: {0:N2}", total);
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                Guid poID = Guid.NewGuid();

                //compile data
                List<POItem> items = new List<POItem>();
                foreach (DataGridViewRow row in gridPOItems.Rows)
                {
                    if(isValidProductName(row) && isValidQty(row))
                    {
                        Guid? referencedInventoryID = null;
                        if(row.Cells[col_gridPOItems_referencedInventoryID.Name].Value != null)
                            referencedInventoryID = (Guid)row.Cells[col_gridPOItems_referencedInventoryID.Name].Value;

                        items.Add(new POItem(
                            Guid.NewGuid(), 
                            poID,
                            row.Index + 1,
                            POItem.compileProductDescription(
                                row.Cells[col_gridPOItems_productName.Name].Value.ToString(),
                                row.Cells[col_gridPOItems_widthName.Name].Value.ToString(), 
                                row.Cells[col_gridPOItems_gradeName.Name].Value.ToString(), 
                                row.Cells[col_gridPOItems_colorName.Name].Value.ToString()),
                                Convert.ToDecimal(row.Cells[col_gridPOItems_qty.Name].Value),
                                row.Cells[col_gridPOItems_unitName.Name].Value.ToString(),
                                Convert.ToDecimal(row.Cells[col_gridPOItems_pricePerUnit.Name].Value),
                                Tools.wrapDBNullValue<string>(row.Cells[col_gridPOItems_notes.Name].Value),
                                referencedInventoryID));
                    }
                }
                if (!Tools.hasMessage(PO.submitNew(poID, (Guid)cbVendors.SelectedValue, lblVendorInfo.Text, items, txtNotes.Text.Trim(), dtpTarget.Value, txtPONo.Text)))
                {
                    Tools.displayForm(new POs.Print_Form(poID));
                    this.Close();
                }
            }
        }

        private bool isInputValid()
        {
            //sanitize inputs
            txtPONo.Text = DBUtil.sanitize(txtPONo.Text);
            txtNotes.Text = DBUtil.sanitize(txtNotes.Text);

            if (string.IsNullOrEmpty(txtPONo.Text))
                return Tools.inputError<TextBox>(txtPONo, "PO Number is required");
            else if (PO.isPONoExist(txtPONo.Text))
                return Tools.inputError<TextBox>(txtPONo, "PO Number already exists");
            else if (cbVendors.SelectedIndex == -1)
                return Tools.inputError<CheckBox>(cbVendors, "Please select a vendor");

            //validate items
            bool isValid = true;
            bool hasValidLine = false;
            bool validProductName, validQty;
            foreach (DataGridViewRow row in gridPOItems.Rows)
            {
                row.Cells[col_gridPOItems_productName.Name].ErrorText = "";
                row.Cells[col_gridPOItems_qty.Name].ErrorText = "";

                validProductName = isValidProductName(row);
                validQty = isValidQty(row);

                if (!hasValidLine && validProductName && validQty)
                    hasValidLine = true;

                if (!validProductName && !validQty)
                {
                    continue;
                }
                else
                {
                    if (!validProductName)
                    {
                        row.Cells[col_gridPOItems_productName.Name].ErrorText = "missing description";
                        isValid = false;
                    }
                    else if (!validQty)
                    {
                        row.Cells[col_gridPOItems_qty.Name].ErrorText = "invalid qty";
                        isValid = false;
                    }
                }
            }

            if (!isValid)
                return Tools.showError("Please fix errors to continue");
            else if (!hasValidLine)
                return Tools.showError("Please add a valid item to continue");

            return true;
        }

        private bool isValidProductName(DataGridViewRow row)
        {
            return row.Cells[col_gridPOItems_productName.Name].Value != null && !string.IsNullOrEmpty(row.Cells[col_gridPOItems_productName.Name].Value.ToString().Trim());
        }

        private bool isValidQty(DataGridViewRow row)
        {
            return row.Cells[col_gridPOItems_qty.Name].Value != null && Tools.isNumeric(row.Cells[col_gridPOItems_qty.Name].Value.ToString());
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/

    }
}
