using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LIBUtil;

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
                iddl_Vendor.SelectedValue = new Inventory(items[0].InventoryID).VendorID;
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
            txtPONo.Text = PO.getNextPONo(); //default PO number
            dtpTarget.Value = DateTime.Now.AddDays(14); //default target date

            lblInfo.Text = "";
            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);
            Vendor.populateDropDownList(iddl_Vendor.Dropdownlist.combobox, false, true);

            gridPOItems.Enabled = false;
            gridPOItems.AutoGenerateColumns = false;
            gridPOItems.Rows.Add();
            Tools.formatDeleteColumn(col_gridPOItems_deleteRow);

            if(_formMode == FormMode.Update)
            {
                txtPONo.Enabled = false;
                iddl_Vendor.Enabled = false;
                txtNotes.Enabled = false;
                foreach (DataGridViewColumn column in gridPOItems.Columns)
                    if(column != col_gridPOItems_pricePerUnit)
                        column.ReadOnly = true;
            }

            calculateGrandTotal();

            if (GlobalData.UserAccount.role == Roles.User)
            {
                rbCustomer.Checked = true;
                rbVendor.Enabled = false;
            }
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
                var browseForm = new InventoryForm.Main_Form(FormMode.Browse, (Guid?)iddl_Vendor.SelectedValue);
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
            //calculate buy price
            decimal? buyPrice = 0;
            decimal buyPercentDiscount = 0;
            DataTable productPrices = ProductPrice.get(null, inventory.product_store_name_id, inventory.grade_id, inventory.product_width_id, inventory.length_unit_id, null, inventory.color_id, false);
            if (productPrices.Rows.Count > 0)
            {
                buyPercentDiscount = Util.wrapNullable<decimal?>(productPrices.Rows[0], ProductPrice.COL_DB_BuyPercentDiscount) ?? 0;
                buyPrice = Util.wrapNullable<decimal?>(productPrices.Rows[0], ProductPrice.COL_DB_BuyPrice);
            }
            else //get price without color
            {
                productPrices = ProductPrice.get(null, inventory.product_store_name_id, inventory.grade_id, inventory.product_width_id, inventory.length_unit_id, null, null, false);
                if (productPrices.Rows.Count > 0)
                {
                    buyPercentDiscount = Util.wrapNullable<decimal?>(productPrices.Rows[0], ProductPrice.COL_DB_BuyPercentDiscount) ?? 0;
                    buyPrice = Util.wrapNullable<decimal?>(productPrices.Rows[0], ProductPrice.COL_DB_BuyPrice);
                }
            }
            if(buyPrice == null || buyPrice == 0)
                buyPrice = inventory.buy_price;

            //populate row
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_productName.Name].Value = inventory.id;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_productName.Name].Value = inventory.product_name_vendor;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_widthName.Name].Value = inventory.product_width_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_gradeName.Name].Value = inventory.grade_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_colorName.Name].Value = inventory.color_name;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_unitName.Name].Value = inventory.length_unit_name;
            if (GlobalData.UserAccount.role == Roles.Super)
            {
                gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_buyPrice.Name].Value = buyPrice;
                gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_PercentDiscount.Name].Value = buyPercentDiscount;
            }
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_referencedInventoryID.Name].Value = inventory.id;
            gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_qty.Name].Value = qty;
            if(iddl_Vendor.Enabled)
            {
                gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_notes.Name].Value = notes ?? string.Empty;
                if (inventory.id != null)
                    gridPOItems.Rows[rowIndex].Cells[col_gridPOItems_notes.Name].Value += string.Format(" Last:{0:dd/MM/yy}", inventory.receive_date);
            }
            addNewRowIfNeeded(rowIndex);
        }

        private void gridPOItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_qty.Name) 
                || Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_pricePerUnit.Name)
                || Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_PercentDiscount.Name))
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

        private void iddl_Customers_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_Customers_Form(FormModes.Add), false);
            Customer.populateDropDownList(iddl_Customers.Dropdownlist.combobox, false, true);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rbVendor)
            {
                this.Text = "CREATE PURCHASE ORDER";
                iddl_Vendor.Enabled = true;
                iddl_Customers.Enabled = false;
            }
            else
            {
                this.Text = "CREATE SALES ORDER";
                iddl_Vendor.Enabled = false;
                iddl_Customers.Enabled = true;
            }
        }

        private void Iddl_Vendor_UpdateLink_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Admin.MasterData_v1_Vendors_Form(FormModes.Add), false);
            Vendor.populateDropDownList(iddl_Vendor.Dropdownlist.combobox, false, true);
        }

        private void iddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid selectedID;
            if ((iddl_Vendor.Enabled && iddl_Vendor.SelectedIndex > -1 && Guid.TryParse(iddl_Vendor.SelectedValue.ToString(), out selectedID))
                || (iddl_Customers.Enabled && iddl_Customers.SelectedIndex > -1 && Guid.TryParse(iddl_Customers.SelectedValue.ToString(), out selectedID)))
            {
                if(iddl_Vendor.Enabled)
                    lblInfo.Text = new Vendor(selectedID).Info;
                else
                    lblInfo.Text = new Customer(selectedID).Info;

                gridPOItems.Enabled = true;
            }
            else
            {
                lblInfo.Text = "";
                gridPOItems.Enabled = false;
            }
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                string productDescription = "";
                Guid poID = Guid.NewGuid();

                //compile data
                List<POItem> POItems = new List<POItem>();
                List<SaleOrderItem> saleOrderItems = new List<SaleOrderItem>();
                foreach (DataGridViewRow row in gridPOItems.Rows)
                {
                    if(isValidProductName(row) && isValidQty(row))
                    {
                        Guid? referencedInventoryID = null;
                        if(row.Cells[col_gridPOItems_referencedInventoryID.Name].Value != null)
                            referencedInventoryID = (Guid)row.Cells[col_gridPOItems_referencedInventoryID.Name].Value;

                        productDescription = compileProductDescription(
                                    row.Cells[col_gridPOItems_productName.Name].Value.ToString(),
                                    row.Cells[col_gridPOItems_widthName.Name].Value.ToString(),
                                    row.Cells[col_gridPOItems_gradeName.Name].Value.ToString(),
                                    row.Cells[col_gridPOItems_colorName.Name].Value.ToString());

                        //add each row to list
                        if (iddl_Vendor.Enabled)
                            POItems.Add(new POItem(
                                Guid.NewGuid(), 
                                poID,
                                row.Index + 1,       
                                productDescription,
                                Convert.ToDecimal(row.Cells[col_gridPOItems_qty.Name].Value),
                                row.Cells[col_gridPOItems_unitName.Name].Value.ToString(),
                                Convert.ToDecimal(row.Cells[col_gridPOItems_pricePerUnit.Name].Value),
                                Util.wrapNullable<string>(row.Cells[col_gridPOItems_notes.Name].Value),
                                referencedInventoryID));
                        else
                            saleOrderItems.Add(new SaleOrderItem(
                                Guid.NewGuid(),
                                poID,
                                row.Index + 1,
                                productDescription,
                                Convert.ToDecimal(row.Cells[col_gridPOItems_qty.Name].Value),
                                row.Cells[col_gridPOItems_unitName.Name].Value.ToString(),
                                Convert.ToDecimal(row.Cells[col_gridPOItems_pricePerUnit.Name].Value),
                                Util.wrapNullable<string>(row.Cells[col_gridPOItems_notes.Name].Value),
                                referencedInventoryID));
                    }
                }
                if (iddl_Vendor.Enabled && PO.submitNew(poID, (Guid)iddl_Vendor.SelectedValue, lblInfo.Text, POItems, txtNotes.Text.Trim(), dtpTarget.Value, txtPONo.Text) != null)
                {
                    Tools.displayForm(new POs.Print_Form(poID));
                    this.Close();
                }
                else if (SaleOrder.add(poID, (Guid)iddl_Customers.SelectedValue, lblInfo.Text, saleOrderItems, txtNotes.Text.Trim(), dtpTarget.Value, txtPONo.Text))
                    this.Close();
                
            }
        }

        public string compileProductDescription(string productName, string widthName, string gradeName, string colorName)
        {
            string description = productName;
            description = Tools.append(description, "Lebar: " + widthName, " ");
            description = Tools.append(description, "Grade: " + gradeName, Environment.NewLine);
            description = Tools.append(description, "Warna: " + colorName, " ");

            return description;
        }

        private bool isInputValid()
        {
            //sanitize inputs
            txtPONo.Text = DBUtil.sanitize(txtPONo.Text);
            txtNotes.Text = DBUtil.sanitize(txtNotes.Text);

            if (string.IsNullOrEmpty(txtPONo.Text) && iddl_Vendor.Enabled)
                return Tools.inputError<TextBox>(txtPONo, "PO Number is required");
            else if (PO.isPONoExist(txtPONo.Text))
                return Tools.inputError<TextBox>(txtPONo, "PO Number already exists");
            else if (iddl_Vendor.Enabled && iddl_Vendor.SelectedIndex == -1)
                return iddl_Vendor.SelectedValueError("Please select a vendor");
            else if (iddl_Customers.Enabled && iddl_Customers.SelectedIndex == -1)
                return iddl_Customers.SelectedValueError("Please select a customer");

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

        private void Add_Edit_Form_Shown(object sender, EventArgs e) 
        {
        }

        private void Add_Edit_Form_Load(object sender, EventArgs e)
        {
        }

        private void gridPOItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewTextBoxColumn), col_gridPOItems_PercentDiscount.Name))
            {
                decimal buyPrice = Util.getClickedRowValue<decimal>(sender, e, col_gridPOItems_buyPrice);
                decimal percentDiscount = Util.zeroNonNumericString(Util.getClickedCellValue(sender, e));
                Util.setRowValue(sender, e, col_gridPOItems_pricePerUnit, buyPrice * (1 - percentDiscount/100));
            }
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/

    }
}
