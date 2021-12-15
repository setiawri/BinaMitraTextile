﻿namespace BinaMitraTextile.Admin
{
    partial class MasterData_v1_MoneyAccountCategoryAssignments_Form
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
            this.itxt_Notes = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_MoneyAccounts_Id = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.iddl_MoneyAccountCategories = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
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
            this.pnlRowInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(800, 28);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 127);
            this.pnlActionButtons.Size = new System.Drawing.Size(800, 23);
            // 
            // scInputLeft
            // 
            // 
            // scInputLeft.Panel1
            // 
            this.scInputLeft.Panel1.Controls.Add(this.iddl_MoneyAccountCategories);
            this.scInputLeft.Panel1.Controls.Add(this.iddl_MoneyAccounts_Id);
            // 
            // scInputLeft.Panel2
            // 
            this.scInputLeft.Panel2.Controls.Add(this.itxt_Notes);
            this.scInputLeft.Size = new System.Drawing.Size(500, 101);
            // 
            // scInputRight
            // 
            this.scInputRight.Size = new System.Drawing.Size(296, 101);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.DarkOrange;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            // 
            // scMain
            // 
            this.scMain.Size = new System.Drawing.Size(800, 484);
            this.scMain.SplitterDistance = 150;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Size = new System.Drawing.Size(800, 26);
            // 
            // scInputContainer
            // 
            this.scInputContainer.Size = new System.Drawing.Size(800, 101);
            // 
            // pnlQuickSearch
            // 
            this.pnlQuickSearch.Size = new System.Drawing.Size(770, 28);
            // 
            // pnlRowInfo
            // 
            this.pnlRowInfo.Location = new System.Drawing.Point(0, 233);
            this.pnlRowInfo.Size = new System.Drawing.Size(800, 100);
            // 
            // pnlRowInfoHeader
            // 
            this.pnlRowInfoHeader.Size = new System.Drawing.Size(780, 21);
            // 
            // pnlRowInfoContent
            // 
            this.pnlRowInfoContent.Size = new System.Drawing.Size(800, 79);
            // 
            // itxt_Notes
            // 
            this.itxt_Notes.IsBrowseMode = false;
            this.itxt_Notes.LabelText = "Notes";
            this.itxt_Notes.Location = new System.Drawing.Point(5, 5);
            this.itxt_Notes.MaxLength = 32767;
            this.itxt_Notes.MultiLine = true;
            this.itxt_Notes.Name = "itxt_Notes";
            this.itxt_Notes.PasswordChar = '\0';
            this.itxt_Notes.RowCount = 4;
            this.itxt_Notes.ShowDeleteButton = false;
            this.itxt_Notes.ShowFilter = false;
            this.itxt_Notes.ShowTextboxOnly = false;
            this.itxt_Notes.Size = new System.Drawing.Size(242, 86);
            this.itxt_Notes.TabIndex = 0;
            this.itxt_Notes.ValueText = "";
            // 
            // iddl_MoneyAccounts_Id
            // 
            this.iddl_MoneyAccounts_Id.DisableTextInput = false;
            this.iddl_MoneyAccounts_Id.HideFilter = false;
            this.iddl_MoneyAccounts_Id.HideUpdateLink = false;
            this.iddl_MoneyAccounts_Id.LabelText = "Account";
            this.iddl_MoneyAccounts_Id.Location = new System.Drawing.Point(4, 6);
            this.iddl_MoneyAccounts_Id.Name = "iddl_MoneyAccounts_Id";
            this.iddl_MoneyAccounts_Id.SelectedIndex = -1;
            this.iddl_MoneyAccounts_Id.SelectedItem = null;
            this.iddl_MoneyAccounts_Id.SelectedItemText = "";
            this.iddl_MoneyAccounts_Id.SelectedValue = null;
            this.iddl_MoneyAccounts_Id.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccounts_Id.Size = new System.Drawing.Size(242, 41);
            this.iddl_MoneyAccounts_Id.TabIndex = 5;
            this.iddl_MoneyAccounts_Id.UpdateLink_Click += new System.EventHandler(this.iddl_MoneyAccounts_Id_UpdateLink_Click);
            // 
            // iddl_MoneyAccountCategories
            // 
            this.iddl_MoneyAccountCategories.DisableTextInput = false;
            this.iddl_MoneyAccountCategories.HideFilter = false;
            this.iddl_MoneyAccountCategories.HideUpdateLink = false;
            this.iddl_MoneyAccountCategories.LabelText = "Category";
            this.iddl_MoneyAccountCategories.Location = new System.Drawing.Point(4, 50);
            this.iddl_MoneyAccountCategories.Name = "iddl_MoneyAccountCategories";
            this.iddl_MoneyAccountCategories.SelectedIndex = -1;
            this.iddl_MoneyAccountCategories.SelectedItem = null;
            this.iddl_MoneyAccountCategories.SelectedItemText = "";
            this.iddl_MoneyAccountCategories.SelectedValue = null;
            this.iddl_MoneyAccountCategories.ShowDropdownlistOnly = false;
            this.iddl_MoneyAccountCategories.Size = new System.Drawing.Size(242, 41);
            this.iddl_MoneyAccountCategories.TabIndex = 6;
            // 
            // MasterData_v1_MoneyAccountCategoryAssignments_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Mode = LIBUtil.FormModes.Add;
            this.Name = "MasterData_v1_MoneyAccountCategoryAssignments_Form";
            this.Text = "MONEY ACCOUNT CATEGORIES ASSIGNMENT";
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
            this.pnlRowInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Notes;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccounts_Id;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_MoneyAccountCategories;
    }
}