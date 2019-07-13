namespace BinaMitraTextile.UserControls
{
    partial class InputEnumDropdownlist
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
            this.label = new System.Windows.Forms.Label();
            this.combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(66, 13);
            this.label.TabIndex = 1;
            this.label.Text = "dropdownlist";
            // 
            // combobox
            // 
            this.combobox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.combobox.FormattingEnabled = true;
            this.combobox.Location = new System.Drawing.Point(0, 14);
            this.combobox.Name = "combobox";
            this.combobox.Size = new System.Drawing.Size(180, 21);
            this.combobox.TabIndex = 2;
            // 
            // InputEnumDropdownlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combobox);
            this.Controls.Add(this.label);
            this.Name = "InputEnumDropdownlist";
            this.Size = new System.Drawing.Size(180, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox combobox;
    }
}
