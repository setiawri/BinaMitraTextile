using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Gorden
{
    public partial class Gorden_Add_Edit_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        Guid _gordenOrderID = Guid.NewGuid();
        DataTable _gordenOrderItems = GordenOrderItem.get();
        List<GordenOrderItemMaterial> _gordenOrderItemMaterialsList = new List<GordenOrderItemMaterial>();
        string _customerInfo = "";

        #endregion
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Gorden_Add_Edit_Form()
        {
            InitializeComponent();
        }
                
        private void setupControls()
        {
            GordenItem.populateDropDownList(dropFabrics, false, GordenItemCategories.Gorden);
            GordenItem.populateDropDownList(dropVitrages, false, GordenItemCategories.Vitrage);
            GordenItem.populateDropDownList(dropRings, false, GordenItemCategories.Ring, GordenItemCategories.SmokeRing, GordenItemCategories.KawatRoda);
            GordenItem.populateDropDownList(dropRails1, false, GordenItemCategories.Rel);
            GordenItem.populateDropDownList(dropRails2, false, GordenItemCategories.Rel);
            GordenItem.populateDropDownList(dropKaki, false, GordenItemCategories.KakiRel);
            GordenItem.populateDropDownList(dropHooks, false, GordenItemCategories.Hook);
            GordenItem.populateDropDownList(dropTasels, false, GordenItemCategories.Tasel);

            gridmain.AutoGenerateColumns = false;
            gridmain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_gridmain_id.DataPropertyName = GordenOrderItem.COL_DB_ID;
            col_gridmain_lineno.DataPropertyName = GordenOrderItem.COL_DB_LINENO;
            col_gridmain_description.DataPropertyName = GordenOrderItem.COL_DB_DESCRIPTION;
            Tools.setGridviewColumnWordwrap(col_gridmain_description);
            col_gridmain_qty.DataPropertyName = GordenOrderItem.COL_DB_QTY;
            col_gridmain_priceperunit.DataPropertyName = GordenOrderItem.COL_DB_SELLAMOUNTPERUNIT;
            col_gridmain_notes.DataPropertyName = GordenOrderItem.COL_DB_NOTES;
            col_gridmain_subtotal.DataPropertyName = GordenOrderItem.COL_SUBTOTAL;

            Customer.populateDropDownList(dropCustomers, false, true);
            lblCustomerInfo.Text = _customerInfo;
        }

        private void populatePageData()
        {
            resetInput();
            calculateGrandTotal();
        }

        private void Gorden_Add_Edit_Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();
        }

        #endregion
        /*******************************************************************************************************/
        #region ITEM CALCULATIONS

        private void compileMaterialsAndCalculateSubtotal() 
        { 
            decimal subTotal = 0;
            string description = "";
            compileMaterialsAndCalculateSubtotal(null, ref subTotal, ref description); 
        }

        private List<GordenOrderItemMaterial> compileMaterialsAndCalculateSubtotal(Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            DBUtil.sanitize(txtItemHeight, txtItemWidth);

            List<GordenOrderItemMaterial> materials = new List<GordenOrderItemMaterial>();
            subTotal = 0;

            if (Tools.isDropdownlistSelected(dropFabrics))
            {
                description = Tools.append(description, string.Format("Ukuran: {0:N2} x {1:N2} meter", txtItemHeight.Text, txtItemWidth.Text), Environment.NewLine);

                decimal fabricQty = addFabric(ref materials, gordenOrderItemID, ref subTotal, ref description);
                decimal ringQty = addRing(ref materials, gordenOrderItemID, ref subTotal, ref description);
                addKaki(ref materials, gordenOrderItemID, ref subTotal, ref description);
                addRail(ref materials, gordenOrderItemID, ref subTotal, dropRails1, ref description);
                addVitrage(ref materials, gordenOrderItemID, ref subTotal, ref description);
                addRail(ref materials, gordenOrderItemID, ref subTotal, dropRails2, ref description);
                addHook(ref materials, gordenOrderItemID, ref subTotal, ref description);
            }

            setItemTotal(subTotal);
            return materials;
        }

        private decimal addFabric(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            decimal qty = 0;
            if (Tools.isDropdownlistSelected(dropFabrics))
            {
                GordenItem item = new GordenItem((Guid)dropFabrics.SelectedValue);

                //calculate usage
                if (item.ProductWidthInMeter < (decimal)2.4)
                {
                    qty = (Tools.zeroNonNumericString(txtItemWidth.Text) * 2) * (Tools.zeroNonNumericString(txtItemHeight.Text) + (decimal)0.25);
                }
                else
                {
                    qty = (Tools.zeroNonNumericString(txtItemWidth.Text) * 3) + (decimal)0.25;
                }

                //calculate tali
                if (rbTali.Checked)
                    qty += (decimal)0.2;

                subTotal += qty * item.SellRetailPricePerUnit;
                description = Tools.append(description, string.Format("{0}", dropFabrics.Text.Trim(), item.ProductWidthInMeter), Environment.NewLine);
                if (chkSplitGorden.Checked)
                    description = Tools.append(description, "- BAGI 2", "");

                DBUtil.sanitize(txtFabricColorCode);
                if (!string.IsNullOrWhiteSpace(txtFabricColorCode.Text))
                    description = Tools.append(description, string.Format("(Warna: {0})", DBUtil.sanitize(txtFabricColorCode)), " ");

                description = Tools.append(description, string.Format("Tali: {0}", Tools.getYEsOrNo(rbTali.Checked)), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
            return qty;
        }

        private void addVitrage(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            decimal qty = 0;
            if (Tools.isDropdownlistSelected(dropVitrages))
            {
                GordenItem item = new GordenItem((Guid)dropVitrages.SelectedValue);

                qty = (Tools.zeroNonNumericString(txtItemWidth.Text) * 3) + (decimal)0.25; //sama dengan perhitungan kain lebar > 2.4m

                subTotal += qty * item.SellRetailPricePerUnit;
                if (Tools.isDropdownlistSelected(dropVitrages)) description = Tools.append(description, string.Format("Vitrage: {0}", dropVitrages.Text, item.ProductWidthInMeter), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
        }

        private void addKaki(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            decimal qty = Tools.zeroNonNumericString(txtItemWidth.Text);
            if (Tools.isDropdownlistSelected(dropKaki))
            {
                GordenItem item = new GordenItem((Guid)dropKaki.SelectedValue);

                subTotal += qty * item.SellRetailPricePerUnit;
                if (Tools.isDropdownlistSelected(dropKaki)) description = Tools.append(description, string.Format("Kaki: {0:N2} mtr {1}", txtItemWidth.Text, dropKaki.Text), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
        }

        private void addRail(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ComboBox drop, ref string description)
        {
            decimal qty = Tools.zeroNonNumericString(txtItemWidth.Text);
            if (Tools.isDropdownlistSelected(drop))
            {
                GordenItem item = new GordenItem((Guid)drop.SelectedValue);

                subTotal += qty * item.SellRetailPricePerUnit;
                if (Tools.isDropdownlistSelected(drop)) description = Tools.append(description, string.Format("Rel: {0:N2} mtr {1}", txtItemWidth.Text, drop.Text), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
        }

        private decimal addRing(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            decimal qty = 0;
            if (Tools.isDropdownlistSelected(dropRings))
            {
                GordenItem item = new GordenItem((Guid)dropRings.SelectedValue);
                decimal width = Tools.zeroNonNumericString(txtItemWidth.Text);

                //fabric lebar dibawah dan diatas 2.4meter berbeda cara hitung nya. Tetapi disini disamakan saja dengan lebar kain 2.4meter dan dibulatkan ke atas.
                //Perbedaan sekitar kelebihan 1-2 lubang dianggap biaya. Perbedaan karena potongan lebar 1.20meter menyebabkan jumlah lubang yang diperlukan menjadi lebih.
                if (item.CategoryEnumID == GordenItemCategories.SmokeRing)
                    qty = Math.Ceiling(width * 3 * 8);
                else if (item.CategoryEnumID == GordenItemCategories.Ring)
                    qty = Math.Ceiling(width * 3 * 10);
                else
                    qty = Math.Ceiling(width * 3 * 10);

                subTotal += qty * item.SellRetailPricePerUnit;
                description = Tools.append(description, string.Format("Rings: {0}", dropRings.Text), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
            return qty;
        }

        //private void addKawatRoda(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, decimal ringQty, ref string description)
        //{
        //    decimal qty = ringQty;
        //    if (Tools.isDropdownlistSelected(dropKawatRoda) && new GordenItem((Guid)dropRings.SelectedValue).CategoryEnumID == GordenItemCategories.Ring)
        //    {
        //        GordenItem item = new GordenItem((Guid)dropKawatRoda.SelectedValue);

        //        subTotal += qty * item.SellRetailPricePerUnit;
        //        description = Tools.append(description, string.Format("Kawat: {0}", dropKawatRoda.Text), Environment.NewLine);
        //        materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
        //    }
        //}

        private void addHook(ref List<GordenOrderItemMaterial> materials, Guid? gordenOrderItemID, ref decimal subTotal, ref string description)
        {
            decimal qty = 2;
            if (Tools.isDropdownlistSelected(dropHooks))
            {
                GordenItem item = new GordenItem((Guid)dropHooks.SelectedValue);

                subTotal += qty * item.SellRetailPricePerUnit;
                description = Tools.append(description, string.Format("Hook: {0:N0} x {1}", qty, dropHooks.Text), Environment.NewLine);
                materials.Add(new GordenOrderItemMaterial(gordenOrderItemID, item.ID, qty, null));
            }
        }

        private void setItemTotal(decimal value)
        {
            lblItemTotal.Text = value.ToString("N2");
        }

        #endregion
        /*******************************************************************************************************/
        #region FORM METHODS

        private bool isItemInputValid()
        {
            if (!Tools.isNumeric(txtItemHeight.Text))
                return Tools.inputError<TextBox>(txtItemHeight, "Isi tinggi");
            else if (!Tools.isNumeric(txtItemWidth.Text))
                return Tools.inputError<TextBox>(txtItemWidth, "Isi lebar");
            else if (dropFabrics.SelectedIndex == -1)
                return Tools.inputError<ComboBox>(dropFabrics, "Pilih bahan gorden");
            else if ((rbTali.Checked || rbTasel.Checked) && dropHooks.SelectedIndex < 0 && !Tools.okCancelMessage("Order Tali/Tasel tapi tidak memilih hook. Lanjutkan? Klik cancel untuk memilih hook."))
            {
                dropHooks.Focus();
                return false;
            }
            else if (Tools.zeroNonNumericString(txtItemQty.Text) == 0)
                return Tools.inputError<TextBox>(txtItemQty, "Isi jumlah untuk item ini");

            return true;
        }

        private void insertItem()
        {
            Guid gordenOrderItemID = Guid.NewGuid();
            decimal sellAmountPerUnit = 0;
            string itemDescription = "";

            //add materials to list
            _gordenOrderItemMaterialsList.Concat(compileMaterialsAndCalculateSubtotal(gordenOrderItemID, ref sellAmountPerUnit, ref itemDescription));

            //add order item to datatable
            DataRow row = _gordenOrderItems.NewRow();
            _gordenOrderItems.Rows.Add(row);
            row[GordenOrderItem.COL_DB_ID] = gordenOrderItemID;
            row[GordenOrderItem.COL_DB_GORDENORDERID] = _gordenOrderID;
            row[GordenOrderItem.COL_DB_LINENO] = _gordenOrderItems.Rows.Count;
            row[GordenOrderItem.COL_DB_DESCRIPTION] = itemDescription;
            row[GordenOrderItem.COL_DB_QTY] = Tools.zeroNonNumericString(txtItemQty.Text);
            row[GordenOrderItem.COL_DB_SELLAMOUNTPERUNIT] = sellAmountPerUnit;
            row[GordenOrderItem.COL_SUBTOTAL] = Tools.zeroNonNumericString(txtItemQty.Text) * Tools.zeroNonNumericString(row[GordenOrderItem.COL_DB_SELLAMOUNTPERUNIT]);
            row[GordenOrderItem.COL_DB_NOTES] = Tools.wrapNullable(txtItemNotes.Text);

            gridmain.DataSource = _gordenOrderItems;
            resetInput();

            calculateGrandTotal();
        }

        private void resetInput()
        {

            Tools.resetDropDownList(dropFabrics);
            Tools.resetDropDownList(dropVitrages);
            Tools.resetDropDownList(dropRails1);
            Tools.resetDropDownList(dropRails2);
            Tools.resetDropDownList(dropRings);
            Tools.resetDropDownList(dropHooks);

            txtFabricColorCode.Text = "";
            rbNoTali.Checked = true;
            txtItemHeight.Text = "";
            txtItemWidth.Text = "";
            Tools.resetDropDownList(dropTasels);

            txtItemQty.Text = "1";
            lblItemTotal.Text = "";
        }

        private bool isInputValid()
        {
            if (gridmain.Rows.Count == 0)
                return Tools.showError("Minimal harus ada satu item untuk order");
            else if (dropCustomers.SelectedIndex == -1)
                return Tools.inputError<ComboBox>(dropCustomers, "Pilih pelanggan");

            return true;
        }

        private void removeSelectedOrderItem()
        {
            int topRowIndex = gridmain.FirstDisplayedScrollingRowIndex;
            int selectedRowIndex = gridmain.SelectedRows[0].Index;
            DataRow row = _gordenOrderItems.Rows[selectedRowIndex];
            Guid gordenOrderItemID = DBUtil.parseData<Guid>(row, GordenOrderItem.COL_DB_ID);
            _gordenOrderItems.Rows.RemoveAt(selectedRowIndex);
            gridmain.DataSource = _gordenOrderItems;
            Tools.setFirstDisplayedScrollingRowIndex(gridmain, topRowIndex, selectedRowIndex);

            removeMaterials(gordenOrderItemID);
        }

        private void removeMaterials(Guid gordenOrderItemID)
        {
            //remove related materials
            GordenOrderItemMaterial material;
            for (int i = _gordenOrderItemMaterialsList.Count - 1; i > -1; i--)
            {
                material = _gordenOrderItemMaterialsList[i];
                if (material.GordenOrderItemID == gordenOrderItemID)
                    _gordenOrderItemMaterialsList.Remove(material);
            }
        }

        private void calculateGrandTotal()
        {
            lblTotalAmount.Text = string.Format("Rp. {0:N2}", Tools.getSum((DataTable)gridmain.DataSource, GordenOrderItem.COL_SUBTOTAL, ""));
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void dropTasels_SelectedIndexChanged(object sender, EventArgs e)
        {
            rbTasel.Checked = true;
        }

        private void itemInputChanged(object sender, EventArgs e)
        {
            if(sender.GetType() == typeof(TextBox))
                LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, true, false);
            lblItemTotal.Text = "";
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (isItemInputValid())
                insertItem();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                GordenOrder.add(_gordenOrderID, (Guid)dropCustomers.SelectedValue, lblCustomerInfo.Text, Tools.zeroNonNumericString(txtGlobalDiscountAmount.Text), 
                    Tools.zeroNonNumericString(txtOtherCosts.Text), txtNotes.Text,
                    _gordenOrderItems, _gordenOrderItemMaterialsList);

                //open invoice
                Tools.displayForm(this, new Gorden.GordenOrderPrint_Form(_gordenOrderID));

                this.Close();
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            Tools.dropdownlistQuickFilter(dropCustomers, txtCustomerSearch, Customer.COL_DB_NAME);
        }

        private void dropCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid selectedID = new Guid();
            if(Tools.isDropdownlistSelected((ComboBox)sender, ref selectedID))
                lblCustomerInfo.Text = new Customer(selectedID).compileData();
            else
                lblCustomerInfo.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(gridmain.SelectedRows.Count > -1)
            {
                removeSelectedOrderItem();
            }
        }

        private void btnCalculateItemSubtotal_Click(object sender, EventArgs e)
        {
            compileMaterialsAndCalculateSubtotal();
        }

        #endregion
        /*******************************************************************************************************/
    }
}
