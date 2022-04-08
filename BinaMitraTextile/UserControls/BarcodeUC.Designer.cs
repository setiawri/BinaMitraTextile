namespace BinaMitraTextile
{
    partial class BarcodeUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMarker = new System.Windows.Forms.PictureBox();
            this.barcode = new BarcodeLib.BarcodeControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbMarker)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMarker
            // 
            this.pbMarker.BackgroundImage = global::BinaMitraTextile.Properties.Resources.handshake_32;
            this.pbMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMarker.Location = new System.Drawing.Point(79, 38);
            this.pbMarker.Name = "pbMarker";
            this.pbMarker.Size = new System.Drawing.Size(20, 20);
            this.pbMarker.TabIndex = 118;
            this.pbMarker.TabStop = false;
            // 
            // barcode
            // 
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcode.Location = new System.Drawing.Point(0, 0);
            this.barcode.Margin = new System.Windows.Forms.Padding(5);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(183, 56);
            this.barcode.TabIndex = 0;
            // 
            // BarcodeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbMarker);
            this.Controls.Add(this.barcode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarcodeUC";
            this.Size = new System.Drawing.Size(183, 56);
            ((System.ComponentModel.ISupportInitialize)(this.pbMarker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMarker;
        private BarcodeLib.BarcodeControl barcode;
    }
}
