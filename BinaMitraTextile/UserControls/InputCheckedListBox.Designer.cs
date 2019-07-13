namespace BinaMitraTextile.UserControls
{
    partial class InputCheckedListBox
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
            this.checkedlistbox = new System.Windows.Forms.CheckedListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.chk = new System.Windows.Forms.CheckBox();
            this.sc = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).BeginInit();
            this.sc.Panel1.SuspendLayout();
            this.sc.Panel2.SuspendLayout();
            this.sc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(116, 22);
            this.label.TabIndex = 1;
            this.label.Text = "checkedlistbox";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkedlistbox
            // 
            this.checkedlistbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedlistbox.FormattingEnabled = true;
            this.checkedlistbox.Location = new System.Drawing.Point(0, 22);
            this.checkedlistbox.Name = "checkedlistbox";
            this.checkedlistbox.Size = new System.Drawing.Size(180, 59);
            this.checkedlistbox.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtFilter.Location = new System.Drawing.Point(116, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(35, 20);
            this.txtFilter.TabIndex = 0;
            // 
            // chk
            // 
            this.chk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chk.Location = new System.Drawing.Point(0, 0);
            this.chk.Name = "chk";
            this.chk.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chk.Size = new System.Drawing.Size(25, 22);
            this.chk.TabIndex = 0;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // sc
            // 
            this.sc.Dock = System.Windows.Forms.DockStyle.Top;
            this.sc.Location = new System.Drawing.Point(0, 0);
            this.sc.Name = "sc";
            // 
            // sc.Panel1
            // 
            this.sc.Panel1.Controls.Add(this.chk);
            // 
            // sc.Panel2
            // 
            this.sc.Panel2.Controls.Add(this.label);
            this.sc.Panel2.Controls.Add(this.txtFilter);
            this.sc.Size = new System.Drawing.Size(180, 22);
            this.sc.SplitterDistance = 25;
            this.sc.TabIndex = 19;
            // 
            // InputCheckedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkedlistbox);
            this.Controls.Add(this.sc);
            this.Name = "InputCheckedListBox";
            this.Size = new System.Drawing.Size(180, 81);
            this.sc.Panel1.ResumeLayout(false);
            this.sc.Panel2.ResumeLayout(false);
            this.sc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc)).EndInit();
            this.sc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.CheckedListBox checkedlistbox;
        public System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox chk;
        private System.Windows.Forms.SplitContainer sc;
    }
}
