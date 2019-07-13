namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_ToDoList_Form
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
            this.itxt_Description = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_Customers = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_Vendors = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.chkIncludeCompleted = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.Panel1.SuspendLayout();
            this.scInputLeft.Panel2.SuspendLayout();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).BeginInit();
            this.scInputContainer.Panel1.SuspendLayout();
            this.scInputContainer.Panel2.SuspendLayout();
            this.scInputContainer.SuspendLayout();
            this.pnlQuickSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(800, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 177);
            this.pnlActionButtons.Size = new System.Drawing.Size(800, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.itxt_Description);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.iddl_Vendors);
            this.scInputLeft.Panel2.Controls.Add(this.iddl_Customers);
            this.scInputLeft.Size = new System.Drawing.Size(500, 151);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(296, 151);
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(800, 484);
            this.scMain.SplitterDistance = 200;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(800, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(800, 151);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Controls.Add(this.chkIncludeCompleted);
            this.pnlQuickSearch.Size = new System.Drawing.Size(770, 28);
            this.pnlQuickSearch.Controls.SetChildIndex(this.txtQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.lnkClearQuickSearch, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeInactive, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.label1, 0);
            this.pnlQuickSearch.Controls.SetChildIndex(this.chkIncludeCompleted, 0);
            // 
            // itxt_Description
            // 
            this.itxt_Description.IsBrowseMode = false;
            this.itxt_Description.LabelText = "Description";
            this.itxt_Description.Location = new System.Drawing.Point(3, 3);
            this.itxt_Description.MaxLength = 32767;
            this.itxt_Description.MultiLine = true;
            this.itxt_Description.Name = "itxt_Description";
            this.itxt_Description.PasswordChar = '\0';
            this.itxt_Description.RowCount = 6;
            this.itxt_Description.ShowDeleteButton = false;
            this.itxt_Description.ShowTextboxOnly = false;
            this.itxt_Description.Size = new System.Drawing.Size(243, 116);
            this.itxt_Description.TabIndex = 0;
            this.itxt_Description.ValueText = "";
            // 
            // iddl_Customers
            // 
            this.iddl_Customers.DisableTextInput = false;
            this.iddl_Customers.HideFilter = false;
            this.iddl_Customers.HideUpdateLink = false;
            this.iddl_Customers.LabelText = "Customer";
            this.iddl_Customers.Location = new System.Drawing.Point(3, 3);
            this.iddl_Customers.Name = "iddl_Customers";
            this.iddl_Customers.SelectedItem = null;
            this.iddl_Customers.SelectedValue = null;
            this.iddl_Customers.ShowDropdownlistOnly = false;
            this.iddl_Customers.Size = new System.Drawing.Size(180, 41);
            this.iddl_Customers.TabIndex = 0;
            this.iddl_Customers.UpdateLink_Click += new System.EventHandler(this.iddl_Customers_UpdateLink_Click);
            // 
            // iddl_Vendors
            // 
            this.iddl_Vendors.DisableTextInput = false;
            this.iddl_Vendors.HideFilter = false;
            this.iddl_Vendors.HideUpdateLink = false;
            this.iddl_Vendors.LabelText = "Vendor";
            this.iddl_Vendors.Location = new System.Drawing.Point(3, 50);
            this.iddl_Vendors.Name = "iddl_Vendors";
            this.iddl_Vendors.SelectedItem = null;
            this.iddl_Vendors.SelectedValue = null;
            this.iddl_Vendors.ShowDropdownlistOnly = false;
            this.iddl_Vendors.Size = new System.Drawing.Size(180, 41);
            this.iddl_Vendors.TabIndex = 1;
            this.iddl_Vendors.UpdateLink_Click += new System.EventHandler(this.iddl_Vendors_UpdateLink_Click);
            // 
            // chkIncludeCompleted
            // 
            this.chkIncludeCompleted.AutoSize = true;
            this.chkIncludeCompleted.Location = new System.Drawing.Point(199, 7);
            this.chkIncludeCompleted.Name = "chkIncludeCompleted";
            this.chkIncludeCompleted.Size = new System.Drawing.Size(103, 17);
            this.chkIncludeCompleted.TabIndex = 14;
            this.chkIncludeCompleted.Text = "show completed";
            this.chkIncludeCompleted.UseVisualStyleBackColor = true;
            this.chkIncludeCompleted.CheckedChanged += new System.EventHandler(this.chkIncludeCompleted_CheckedChanged);
            // 
            // ToDoList_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Name = "ToDoList_Form";
            this.Text = "TO DO LIST";
            this.panel1.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputLeft.Panel1.ResumeLayout(false);
            this.scInputLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).EndInit();
            this.scInputRight.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.scInputContainer.Panel1.ResumeLayout(false);
            this.scInputContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputContainer)).EndInit();
            this.scInputContainer.ResumeLayout(false);
            this.pnlQuickSearch.ResumeLayout(false);
            this.pnlQuickSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Description;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Customers;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Vendors;
        private System.Windows.Forms.CheckBox chkIncludeCompleted;
    }
}