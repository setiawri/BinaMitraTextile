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
            this.barcode = new BarcodeLib.BarcodeControl();
            this.marker = new System.Windows.Forms.PictureBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.marker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // barcode
            // 
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcode.Location = new System.Drawing.Point(0, 0);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(123, 50);
            this.barcode.TabIndex = 41;
            // 
            // marker
            // 
            this.marker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.marker.BackgroundImage = global::BinaMitraTextile.Properties.Resources.handshake_32;
            this.marker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.marker.Location = new System.Drawing.Point(-26, 16);
            this.marker.Name = "marker";
            this.marker.Size = new System.Drawing.Size(15, 15);
            this.marker.TabIndex = 80;
            this.marker.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.marker);
            this.splitContainer.Panel1MinSize = 1;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.barcode);
            this.splitContainer.Panel2MinSize = 120;
            this.splitContainer.Size = new System.Drawing.Size(137, 50);
            this.splitContainer.SplitterDistance = 13;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 81;
            // 
            // BarcodeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "BarcodeUC";
            this.Size = new System.Drawing.Size(137, 50);
            ((System.ComponentModel.ISupportInitialize)(this.marker)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BarcodeLib.BarcodeControl barcode;
        private System.Windows.Forms.PictureBox marker;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}
