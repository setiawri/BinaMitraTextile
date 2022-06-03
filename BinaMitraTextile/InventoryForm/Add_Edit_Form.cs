using System;
using System.Windows.Forms;

namespace BinaMitraTextile.InventoryForm
{
    public partial class Add_Edit_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private Guid _id;
        private FormMode _formMode = FormMode.New;
        private Guid? _browsedProductID;

        private decimal buyPriceBeforePOItemChecked = 0;

        #endregion CLASS VARIABLES
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

        public Add_Edit_Form(Guid id) : this(FormMode.Update, id) { }

        public Add_Edit_Form() : this(FormMode.New, null) { }
        
        private void Add_Edit_Form_Load(object sender, EventArgs e)
        {
            txtPackingListNo.Focus();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            Grade.populateDropDownList(cbGrades, false, true);
            ProductWidth.populateDropDownList(cbProductWidths, false, true);
            LengthUnit.populateDropDownList(cbLengthUnits, false, true);
            FabricColor.populateDropDownList(cbColors, false, true);
            VendorInvoice.populateInputControlDropDownList(iddl_VendorInvoices, true);

            //set window title
            switch (_formMode)
            {
                case FormMode.New:
                    this.Text = "ADD NEW INVENTORY";
                    lblCode.Visible = false;
                    txtCode.Visible = false;
                    break;
                case FormMode.Update:
                    this.Text = "UPDATE INVENTORY";
                    break;
            }

            if(GlobalData.UserAccount.role != Roles.Super)
            {
                lblBuyPrice.Visible = false;
                txtBuyPrice.Visible = false;
                this.Height -= 60;
            }
        }

        private void populatePageData()
        {
            if (_formMode == FormMode.Update)
            {
                Inventory obj = new Inventory(_id);
                txtCode.Text = obj.code.ToString();
                txtPackingListNo.Text = obj.PackingListNo;

                if (obj.VendorInvoiceID == null)
                    iddl_VendorInvoices.reset();
                else
                    iddl_VendorInvoices.SelectedValue = obj.VendorInvoiceID;

                cbColors.SelectedValue = obj.color_id;
                cbGrades.SelectedValue = obj.grade_id;
                cbLengthUnits.SelectedValue = obj.length_unit_id;
                _browsedProductID = obj.product_id;
                populateProductName(obj.product_store_name, obj.product_name_vendor);
                cbProductWidths.SelectedValue = obj.product_width_id;
                txtPackingListNo.Text = obj.PackingListNo;
                if(obj.POItemID != null)
                    itxt_POItemID.setValue(string.Format("[{0}] {1}", obj.PONo, obj.POItemDescription), obj.POItemID);
                txtNotes.Text = obj.notes;
                txtBuyPrice.Text = obj.buy_price.ToString();
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region FORM METHODS
        
        private void chkPOItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPOItem.Checked)
                txtBuyPrice.Text = LIBUtil.Util.zeroNonNumericString(buyPriceBeforePOItemChecked).ToString();
            else
            {
                buyPriceBeforePOItemChecked = LIBUtil.Util.zeroNonNumericString(txtBuyPrice.Text);
                txtBuyPrice.Text = "0";
            }
        }

        private void populateProductName(string productStoreName, string productVendorName)
        {
            txtProductName.Text = string.Format("{0}: {1}", productStoreName, productVendorName);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            switch (_formMode)
            {
                case FormMode.New:
                    Tools.resetDropDownList(cbColors);
                    Tools.resetDropDownList(cbGrades);
                    Tools.resetDropDownList(cbLengthUnits);
                    Tools.resetDropDownList(cbProductWidths);
                    txtNotes.Text = "";
                    txtBuyPrice.Text = "";
                    chkPOItem.Checked = false;
                    break;
                case FormMode.Update:
                    populatePageData();
                    break;
            }
        }
        
        private void txtProductName_Click(object sender, EventArgs e)
        {
            Admin.MasterData_v1_Products_Form form = new Admin.MasterData_v1_Products_Form(LIBUtil.FormModes.Browse);
            Tools.displayForm(form);
            if (form.DialogResult == DialogResult.OK)
            {
                _browsedProductID = form.BrowsedItemSelectionId;
                Product obj = new Product(form.BrowsedItemSelectionId);
                populateProductName(obj.StoreName, obj.NameVendor);

                chkPOItem.Checked = false;
            }
            cbGrades.Focus();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Admin.MasterData_v1_Products_Form(LIBUtil.FormModes.Add));
            _browsedProductID = null;
            txtProductName.Text = "";
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.Grades_Form(FormMode.New));
            Grade.populateDropDownList(cbGrades, false, true);
        }

        private void btnAddProductWidth_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.ProductWidths_Form(FormMode.New));
            ProductWidth.populateDropDownList(cbProductWidths, false, true);
        }

        private void btnAddLengthUnit_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.LengthUnits_Form(FormMode.New));
            LengthUnit.populateDropDownList(cbLengthUnits, false, true);
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new MasterData.FabricColors_Form(FormMode.New));
            FabricColor.populateDropDownList(cbColors, false, true);
        }

        private void btnAddVendorInvoice_Click(object sender, EventArgs e)
        {
            if(Tools.displayForm(new InventoryForm.VendorInvoices_Add_Form()))
            {
                VendorInvoice.populateInputControlDropDownList(iddl_VendorInvoices, true);
                iddl_VendorInvoices.SelectedIndex = 0;
            }
        }

        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isInputFieldsValid())
            {
                Inventory inventory = new Inventory(
                    Tools.zeroNonNumericString(txtBuyPrice.Text.Trim()),
                    (Guid)cbGrades.SelectedValue,
                    (Guid)_browsedProductID,
                    (Guid)cbProductWidths.SelectedValue,
                    (Guid)cbLengthUnits.SelectedValue,
                    (Guid)cbColors.SelectedValue,
                    txtNotes.Text.Trim(),
                    itxt_POItemID.ValueGuid,
                    txtPackingListNo.Text.Trim(),
                    (Guid?)iddl_VendorInvoices.SelectedValue,
                    Convert.ToInt32(Tools.zeroNonNumericString(txtCode.Text)));
                if(_id != null && _id != new Guid())
                    inventory.id = _id;


                switch (_formMode)
                {
                    case FormMode.New:
                        if (inventory.buy_price == 0)
                        {
                            Guid? ProductPrices_Id = ProductPrice.getByCombination(inventory.product_store_name_id, inventory.grade_id, inventory.product_width_id, inventory.length_unit_id, null, inventory.color_id);
                            if(ProductPrices_Id == null)
                                ProductPrices_Id = ProductPrice.getByCombination(inventory.product_store_name_id, inventory.grade_id, inventory.product_width_id, inventory.length_unit_id, null, null);

                            if(ProductPrices_Id != null)
                                inventory.buy_price = new ProductPrice((Guid)ProductPrices_Id).BuyPrice ?? 0;
                        }

                        if (inventory.submitNew() != null)
                        {
                            //Tools.hasMessage("The new data has been added"); 
                            this.Close();
                        }
                        break;
                    case FormMode.Update:
                        if (inventory.update())
                            this.Close();
                        break;
                }
            }
        }

        private bool isInputFieldsValid()
        {
            txtBuyPrice.Text = DBUtil.sanitize(txtBuyPrice.Text);
            txtNotes.Text = DBUtil.sanitize(txtNotes.Text);
            txtPackingListNo.Text = DBUtil.sanitize(txtPackingListNo.Text);

            if (!string.IsNullOrEmpty(txtBuyPrice.Text) && !Tools.isNumeric(txtBuyPrice.Text))
                return Tools.inputError<TextBox>(txtBuyPrice, "Invalid buy price");
            else if (!iddl_VendorInvoices.hasSelectedValue())
                return iddl_VendorInvoices.SelectedValueError("Please select an invoice");
            else if (cbGrades.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbGrades, "Please select a grade listed in the drop down list");
            else if (_browsedProductID == null)
                return Tools.inputError<TextBox>(txtProductName, "Please select a product");
            else if (cbProductWidths.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbProductWidths, "Please select a width listed in the drop down list");
            else if (cbLengthUnits.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbLengthUnits, "Please select a length unit listed in the drop down list");
            else if (cbColors.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbColors, "Please select a color listed in the drop down list");
            else if (_formMode == FormMode.Update && Inventory.isCodeExist(DBUtil.sanitize(txtCode), _id))
                return Tools.inputError<TextBox>(txtCode, "Code already exists. Please use a different number");

            return true;
        }

        private void cbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkPOItem.Checked = false;
        }

        private void cbProductWidths_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkPOItem.Checked = false;
        }

        private void cbLengthUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkPOItem.Checked = false;
        }

        private void Itxt_POItemID_isBrowseMode_Clicked(object sender, EventArgs e)
        {
            POs.Main_Form form = new POs.Main_Form(FormMode.Browse);
            Tools.displayForm(form);
            if (form.DialogResult == DialogResult.OK)
            {
                itxt_POItemID.setValue(form.browseItemDescription, form.browseItemSelection);

                decimal poItemPricePerUnit = LIBUtil.Util.zeroNonNumericString(form.browseItemPricePerUnit.ToString());
                txtBuyPrice.Text = poItemPricePerUnit.ToString();

                if (!chkPOItem.Checked && poItemPricePerUnit > 0)
                    buyPriceBeforePOItemChecked = poItemPricePerUnit;
            }
            txtCode.Focus();

            //automatically fill out form
            if (_formMode == FormMode.New)
            {
                if (itxt_POItemID.ValueGuid != null)
                { 
                    Guid? inventoryID = new POItem((Guid)itxt_POItemID.ValueGuid).ReferencedInventoryID;
                    if (inventoryID != null)
                    {
                        Inventory obj = new Inventory((Guid)inventoryID);
                        _browsedProductID = obj.product_id;
                        populateProductName(obj.product_store_name, obj.product_name_vendor);
                        cbGrades.SelectedValue = obj.grade_id;
                        cbProductWidths.SelectedValue = obj.product_width_id;
                        cbLengthUnits.SelectedValue = obj.length_unit_id;
                        cbColors.SelectedValue = obj.color_id;

                        chkPOItem.Checked = true;
                    }
                }
            }
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/
    }
}
