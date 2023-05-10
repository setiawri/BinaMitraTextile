namespace BinaMitraTextile.Sales
{
    partial class ShippingEnvelopes_Form
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlPrint = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.pnlPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(325, 405);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 36);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlPrint
            // 
            this.pnlPrint.Controls.Add(this.label3);
            this.pnlPrint.Controls.Add(this.lblShippingAddress);
            this.pnlPrint.Controls.Add(this.label8);
            this.pnlPrint.Controls.Add(this.label1);
            this.pnlPrint.Location = new System.Drawing.Point(11, 10);
            this.pnlPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(756, 360);
            this.pnlPrint.TabIndex = 148;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 149;
            this.label3.Text = "KEPADA:";
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingAddress.Location = new System.Drawing.Point(3, 118);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(516, 227);
            this.lblShippingAddress.TabIndex = 148;
            this.lblShippingAddress.Text = "lblShippingAddress";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 70);
            this.label8.TabIndex = 147;
            this.label8.Text = "CV. BINA MITRA TEXTILE\r\nJl. Mayor Sunarya Blok K No. 11A\r\nBandung, Jawa Barat\r\n08" +
    "1.2240.44338\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 146;
            this.label1.Text = "DARI:";
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowPrintDialog.AutoSize = true;
            this.chkShowPrintDialog.Location = new System.Drawing.Point(326, 387);
            this.chkShowPrintDialog.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(78, 17);
            this.chkShowPrintDialog.TabIndex = 149;
            this.chkShowPrintDialog.Text = "Print dialog";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // ShippingEnvelopes_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 456);
            this.Controls.Add(this.chkShowPrintDialog);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.btnPrint);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ShippingEnvelopes_Form";
            this.Text = "SHIPPING ENVELOPES";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlPrint;
        private System.Windows.Forms.CheckBox chkShowPrintDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}