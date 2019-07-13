namespace BinaMitraTextile.Reports
{
    partial class Financial_Overview_Form
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
            this.lblInventoryBuyValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkReceivablesAmount = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory Buy Value:";
            // 
            // lblInventoryBuyValue
            // 
            this.lblInventoryBuyValue.AutoSize = true;
            this.lblInventoryBuyValue.Location = new System.Drawing.Point(123, 38);
            this.lblInventoryBuyValue.Name = "lblInventoryBuyValue";
            this.lblInventoryBuyValue.Size = new System.Drawing.Size(106, 13);
            this.lblInventoryBuyValue.TabIndex = 1;
            this.lblInventoryBuyValue.Text = "lblInventoryBuyValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Receivables:";
            // 
            // lnkReceivablesAmount
            // 
            this.lnkReceivablesAmount.AutoSize = true;
            this.lnkReceivablesAmount.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkReceivablesAmount.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.lnkReceivablesAmount.Location = new System.Drawing.Point(123, 51);
            this.lnkReceivablesAmount.Name = "lnkReceivablesAmount";
            this.lnkReceivablesAmount.Size = new System.Drawing.Size(116, 13);
            this.lnkReceivablesAmount.TabIndex = 4;
            this.lnkReceivablesAmount.TabStop = true;
            this.lnkReceivablesAmount.Text = "lnkReceivablesAmount";
            this.lnkReceivablesAmount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReceivablesAmount_LinkClicked);
            // 
            // Financial_Overview_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 559);
            this.Controls.Add(this.lnkReceivablesAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblInventoryBuyValue);
            this.Controls.Add(this.label1);
            this.Name = "Financial_Overview_Form";
            this.Text = "Financial_Overview_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInventoryBuyValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkReceivablesAmount;
    }
}