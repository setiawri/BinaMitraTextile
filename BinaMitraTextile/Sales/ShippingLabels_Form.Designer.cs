namespace BinaMitraTextile.Sales
{
    partial class ShippingLabels_Form
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
            this.flpShippingLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.chkShowPrintDialog = new System.Windows.Forms.CheckBox();
            this.in_Qty = new LIBUtil.Desktop.UserControls.InputControl_Numeric();
            this.pnlPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(367, 562);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 36);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlPrint
            // 
            this.pnlPrint.Controls.Add(this.flpShippingLabels);
            this.pnlPrint.Location = new System.Drawing.Point(11, 10);
            this.pnlPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(756, 526);
            this.pnlPrint.TabIndex = 148;
            // 
            // flpShippingLabels
            // 
            this.flpShippingLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpShippingLabels.Location = new System.Drawing.Point(0, 0);
            this.flpShippingLabels.Margin = new System.Windows.Forms.Padding(0);
            this.flpShippingLabels.Name = "flpShippingLabels";
            this.flpShippingLabels.Size = new System.Drawing.Size(756, 526);
            this.flpShippingLabels.TabIndex = 0;
            // 
            // chkShowPrintDialog
            // 
            this.chkShowPrintDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowPrintDialog.AutoSize = true;
            this.chkShowPrintDialog.Location = new System.Drawing.Point(362, 544);
            this.chkShowPrintDialog.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowPrintDialog.Name = "chkShowPrintDialog";
            this.chkShowPrintDialog.Size = new System.Drawing.Size(78, 17);
            this.chkShowPrintDialog.TabIndex = 1;
            this.chkShowPrintDialog.Text = "Print dialog";
            this.chkShowPrintDialog.UseVisualStyleBackColor = true;
            // 
            // in_Qty
            // 
            this.in_Qty.Checked = false;
            this.in_Qty.DecimalPlaces = 0;
            this.in_Qty.HideUpDown = false;
            this.in_Qty.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.in_Qty.LabelText = "Labels Qty";
            this.in_Qty.Location = new System.Drawing.Point(283, 542);
            this.in_Qty.Margin = new System.Windows.Forms.Padding(4);
            this.in_Qty.MaximumValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.in_Qty.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.in_Qty.Name = "in_Qty";
            this.in_Qty.ShowAllowDecimalCheckbox = false;
            this.in_Qty.ShowCheckbox = false;
            this.in_Qty.ShowTextboxOnly = false;
            this.in_Qty.Size = new System.Drawing.Size(76, 50);
            this.in_Qty.TabIndex = 0;
            this.in_Qty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ShippingLabels_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 613);
            this.Controls.Add(this.in_Qty);
            this.Controls.Add(this.chkShowPrintDialog);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.btnPrint);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ShippingLabels_Form";
            this.Text = "SHIPPING LABELS";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlPrint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlPrint;
        private System.Windows.Forms.CheckBox chkShowPrintDialog;
        private System.Windows.Forms.FlowLayoutPanel flpShippingLabels;
        private LIBUtil.Desktop.UserControls.InputControl_Numeric in_Qty;
    }
}