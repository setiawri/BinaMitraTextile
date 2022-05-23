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
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.label1 = new System.Windows.Forms.Label();
            this.iddl_SalePayment_MoneyAccounts = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategories_PenjualanTunai = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.SuspendLayout();
            // 
            // iddl_SalePayment_MoneyAccountCategoryAssignments_Cash
            // 
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.DisableTextInput = false;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.HideFilter = true;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.HideUpdateLink = true;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.LabelText = "Category for CASH";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Location = new System.Drawing.Point(225, 53);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Name = "iddl_SalePayment_MoneyAccountCategoryAssignments_Cash";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedIndex = -1;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedItem = null;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedItemText = "";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedValue = null;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.ShowDropdownlistOnly = false;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.Size = new System.Drawing.Size(201, 58);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.TabIndex = 1;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_Cash_SelectedIndexChanged);
            // 
            // iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe
            // 
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.DisableTextInput = false;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.HideFilter = true;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.HideUpdateLink = true;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.LabelText = "Category for Transfer / Owe";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Location = new System.Drawing.Point(435, 53);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Name = "iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedIndex = -1;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedItem = null;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedItemText = "";
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedValue = null;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.ShowDropdownlistOnly = false;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.Size = new System.Drawing.Size(219, 58);
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.TabIndex = 2;
            this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccountCategories_SalePayment_TransferOwe_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "SALE PAYMENTS";
            // 
            // iddl_SalePayment_MoneyAccounts
            // 
            this.iddl_SalePayment_MoneyAccounts.DisableTextInput = false;
            this.iddl_SalePayment_MoneyAccounts.HideFilter = true;
            this.iddl_SalePayment_MoneyAccounts.HideUpdateLink = true;
            this.iddl_SalePayment_MoneyAccounts.LabelText = "Money Account";
            this.iddl_SalePayment_MoneyAccounts.Location = new System.Drawing.Point(16, 53);
            this.iddl_SalePayment_MoneyAccounts.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.iddl_SalePayment_MoneyAccounts.Name = "iddl_SalePayment_MoneyAccounts";
            this.iddl_SalePayment_MoneyAccounts.SelectedIndex = -1;
            this.iddl_SalePayment_MoneyAccounts.SelectedItem = null;
            this.iddl_SalePayment_MoneyAccounts.SelectedItemText = "";
            this.iddl_SalePayment_MoneyAccounts.SelectedValue = null;
            this.iddl_SalePayment_MoneyAccounts.ShowDropdownlistOnly = false;
            this.iddl_SalePayment_MoneyAccounts.Size = new System.Drawing.Size(201, 58);
            this.iddl_SalePayment_MoneyAccounts.TabIndex = 4;
            this.iddl_SalePayment_MoneyAccounts.SelectedIndexChanged += new System.EventHandler(this.iddl_SalePayment_MoneyAccounts_SelectedIndexChanged);
            // 
            // iddl_MoneyAccountCategories_PenjualanTunai
            // 
            this.iddl_MoneyAccountCategories_PenjualanTunai.DisableTextInput = false;
            this.iddl_MoneyAccountCategories_PenjualanTunai.HideFilter = true;
            this.iddl_MoneyAccountCategories_PenjualanTunai.HideUpdateLink = true;
            this.iddl_MoneyAccountCategories_PenjualanTunai.LabelText = "Category for Penjualan Tunai";
            this.iddl_MoneyAccountCategories_PenjualanTunai.Location = new System.Drawing.Point(16, 111);
            this.iddl_MoneyAccountCategories_PenjualanTunai.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.iddl_MoneyAccountCategories_PenjualanTunai.Name = "iddl_MoneyAccountCategories_PenjualanTunai";
            this.iddl_MoneyAccountCategories_PenjualanTunai.SelectedIndex = -1;
            this.iddl_MoneyAccountCategories_PenjualanTunai.SelectedItem = null;
            this.iddl_MoneyAccountCategories_PenjualanTunai.SelectedItemText = "";
            this.iddl_MoneyAccountCategories_PenjualanTunai.SelectedValue = null;
            this.iddl_MoneyAccountCategories_PenjualanTunai.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategories_PenjualanTunai.Size = new System.Drawing.Size(229, 58);
            this.iddl_MoneyAccountCategories_PenjualanTunai.TabIndex = 5;
            this.iddl_MoneyAccountCategories_PenjualanTunai.SelectedIndexChanged += new System.EventHandler(this.iddl_MoneyAccountCategories_PenjualanTunai_SelectedIndexChanged);
            // 
            // Settings_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(733, 340);
            this.Controls.Add(this.iddl_MoneyAccountCategories_PenjualanTunai);
            this.Controls.Add(this.iddl_SalePayment_MoneyAccounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe);
            this.Controls.Add(this.iddl_SalePayment_MoneyAccountCategoryAssignments_Cash);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Settings_Form";
            this.Text = "SETTINGS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_SalePayment_MoneyAccountCategoryAssignments_Cash;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_SalePayment_MoneyAccountCategoryAssignments_TransferOwe;
        private System.Windows.Forms.Label label1;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_SalePayment_MoneyAccounts;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategories_PenjualanTunai;
    }
}