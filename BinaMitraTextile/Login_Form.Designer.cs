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
            this.rbLiveDB = new System.Windows.Forms.RadioButton();
            this.rbLiveDBLocal = new System.Windows.Forms.RadioButton();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(81, 54);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(139, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "User";
            // 
            // cbUsers
            // 
            this.cbUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(81, 29);
            this.cbUsers.Margin = new System.Windows.Forms.Padding(2);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(139, 21);
            this.cbUsers.TabIndex = 2;
            // 
            // rbLiveDB
            // 
            this.rbLiveDB.AutoSize = true;
            this.rbLiveDB.Location = new System.Drawing.Point(81, 7);
            this.rbLiveDB.Name = "rbLiveDB";
            this.rbLiveDB.Size = new System.Drawing.Size(48, 17);
            this.rbLiveDB.TabIndex = 92;
            this.rbLiveDB.TabStop = true;
            this.rbLiveDB.Text = "LIVE";
            this.rbLiveDB.UseVisualStyleBackColor = true;
            this.rbLiveDB.CheckedChanged += new System.EventHandler(this.rbDBConnection_CheckedChanged);
            // 
            // rbLiveDBLocal
            // 
            this.rbLiveDBLocal.AutoSize = true;
            this.rbLiveDBLocal.Location = new System.Drawing.Point(135, 7);
            this.rbLiveDBLocal.Name = "rbLiveDBLocal";
            this.rbLiveDBLocal.Size = new System.Drawing.Size(85, 17);
            this.rbLiveDBLocal.TabIndex = 93;
            this.rbLiveDBLocal.TabStop = true;
            this.rbLiveDBLocal.Text = "LOCAL LIVE";
            this.rbLiveDBLocal.UseVisualStyleBackColor = true;
            this.rbLiveDBLocal.CheckedChanged += new System.EventHandler(this.rbDBConnection_CheckedChanged);
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Location = new System.Drawing.Point(230, 33);
            this.lblConnectionType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(0, 13);
            this.lblConnectionType.TabIndex = 94;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 99);
            this.Controls.Add(this.lblConnectionType);
            this.Controls.Add(this.rbLiveDBLocal);
            this.Controls.Add(this.rbLiveDB);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbUsers);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.RadioButton rbLiveDB;
        private System.Windows.Forms.RadioButton rbLiveDBLocal;
        private System.Windows.Forms.Label lblConnectionType;
    }
}