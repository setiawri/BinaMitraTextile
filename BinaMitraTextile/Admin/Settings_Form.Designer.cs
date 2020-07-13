namespace BinaMitraTextile.Admin
{
    partial class Settings_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "To auto post to petty cash for Sale Invoice Shipping Expense";
            // 
            // iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense
            // 
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.DisableTextInput = false;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.HideFilter = true;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.HideUpdateLink = true;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.LabelText = "Petty Cash Category";
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.Location = new System.Drawing.Point(12, 12);
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.Name = "iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense";
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedIndex = -1;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedItem = null;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedItemText = "";
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedValue = null;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.ShowDropdownlistOnly = false;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.Size = new System.Drawing.Size(186, 41);
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.TabIndex = 0;
            this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense.SelectedIndexChanged += new System.EventHandler(this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense_SelectedIndexChanged);
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense);
            this.Name = "Settings_Form";
            this.Text = "SETTINGS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_PettyCashCategories_for_SaleInvoices_ShippingExpense;
        private System.Windows.Forms.Label label1;
    }
}