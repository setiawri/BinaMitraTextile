namespace BinaMitraTextile
{
    partial class Login_Form
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.chkLiveDB = new System.Windows.Forms.CheckBox();
            this.chkLiveDBLocal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(108, 66);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(184, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 91;
            this.label4.Text = "password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 90;
            this.label2.Text = "User";
            // 
            // cbUsers
            // 
            this.cbUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(108, 36);
            this.cbUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(184, 24);
            this.cbUsers.TabIndex = 2;
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Location = new System.Drawing.Point(307, 41);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(0, 17);
            this.lblConnectionType.TabIndex = 94;
            // 
            // chkLiveDB
            // 
            this.chkLiveDB.AutoSize = true;
            this.chkLiveDB.Location = new System.Drawing.Point(233, 10);
            this.chkLiveDB.Name = "chkLiveDB";
            this.chkLiveDB.Size = new System.Drawing.Size(59, 21);
            this.chkLiveDB.TabIndex = 1;
            this.chkLiveDB.Text = "LIVE";
            this.chkLiveDB.UseVisualStyleBackColor = true;
            this.chkLiveDB.CheckedChanged += new System.EventHandler(this.chkDBConnection_CheckedChanged);
            // 
            // chkLiveDBLocal
            // 
            this.chkLiveDBLocal.AutoSize = true;
            this.chkLiveDBLocal.Location = new System.Drawing.Point(108, 10);
            this.chkLiveDBLocal.Name = "chkLiveDBLocal";
            this.chkLiveDBLocal.Size = new System.Drawing.Size(108, 21);
            this.chkLiveDBLocal.TabIndex = 0;
            this.chkLiveDBLocal.Text = "LOCAL LIVE";
            this.chkLiveDBLocal.UseVisualStyleBackColor = true;
            this.chkLiveDBLocal.CheckedChanged += new System.EventHandler(this.chkDBConnection_CheckedChanged);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 122);
            this.Controls.Add(this.chkLiveDBLocal);
            this.Controls.Add(this.chkLiveDB);
            this.Controls.Add(this.lblConnectionType);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.CheckBox chkLiveDB;
        private System.Windows.Forms.CheckBox chkLiveDBLocal;
    }
}