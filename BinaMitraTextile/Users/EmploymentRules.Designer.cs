namespace BinaMitraTextile.Users
{
    partial class EmploymentRules
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 225);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jam Kerja:\r\n\r\nPenalti\r\n- terlambat < 2 jam: Rp.20rb\r\n- terlambat > 2 jam: 40rb\r\n-" +
    " absen 1 hari dengan ijin: 1 x (gaji+komisi 1 hari)\r\n- absen 1 hari tanpa ijin: " +
    "2 x (gaji+komisi 1 hari)\r\n";
            // 
            // EmploymentRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 504);
            this.Controls.Add(this.label1);
            this.Name = "EmploymentRules";
            this.Text = "EmploymentRules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}