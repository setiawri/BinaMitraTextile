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
            this.gbConnectionProperties = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.rbConnectAsServer = new System.Windows.Forms.RadioButton();
            this.rbDevDB = new System.Windows.Forms.RadioButton();
            this.rbLiveDB = new System.Windows.Forms.RadioButton();
            this.rbLocalDB = new System.Windows.Forms.RadioButton();
            this.itxt_Port = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.itxt_Password = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.itxt_Username = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.gbConnectionProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnectionProperties
            // 
            this.gbConnectionProperties.Controls.Add(this.btnTestConnection);
            this.gbConnectionProperties.Controls.Add(this.rbConnectAsServer);
            this.gbConnectionProperties.Controls.Add(this.rbDevDB);
            this.gbConnectionProperties.Controls.Add(this.rbLiveDB);
            this.gbConnectionProperties.Controls.Add(this.rbLocalDB);
            this.gbConnectionProperties.Controls.Add(this.itxt_Port);
            this.gbConnectionProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbConnectionProperties.Location = new System.Drawing.Point(0, 76);
            this.gbConnectionProperties.Name = "gbConnectionProperties";
            this.gbConnectionProperties.Size = new System.Drawing.Size(255, 62);
            this.gbConnectionProperties.TabIndex = 98;
            this.gbConnectionProperties.TabStop = false;
            this.gbConnectionProperties.Text = "Connection Properties";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(203, 14);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(46, 23);
            this.btnTestConnection.TabIndex = 103;
            this.btnTestConnection.Text = "TEST";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // rbConnectAsServer
            // 
            this.rbConnectAsServer.AutoSize = true;
            this.rbConnectAsServer.Location = new System.Drawing.Point(123, 37);
            this.rbConnectAsServer.Name = "rbConnectAsServer";
            this.rbConnectAsServer.Size = new System.Drawing.Size(86, 17);
            this.rbConnectAsServer.TabIndex = 101;
            this.rbConnectAsServer.Text = "AS SERVER";
            this.rbConnectAsServer.UseVisualStyleBackColor = true;
            this.rbConnectAsServer.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbDevDB
            // 
            this.rbDevDB.AutoSize = true;
            this.rbDevDB.Location = new System.Drawing.Point(123, 18);
            this.rbDevDB.Name = "rbDevDB";
            this.rbDevDB.Size = new System.Drawing.Size(47, 17);
            this.rbDevDB.TabIndex = 100;
            this.rbDevDB.Text = "DEV";
            this.rbDevDB.UseVisualStyleBackColor = true;
            this.rbDevDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbLiveDB
            // 
            this.rbLiveDB.AutoSize = true;
            this.rbLiveDB.Location = new System.Drawing.Point(59, 37);
            this.rbLiveDB.Name = "rbLiveDB";
            this.rbLiveDB.Size = new System.Drawing.Size(48, 17);
            this.rbLiveDB.TabIndex = 99;
            this.rbLiveDB.Text = "LIVE";
            this.rbLiveDB.UseVisualStyleBackColor = true;
            this.rbLiveDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbLocalDB
            // 
            this.rbLocalDB.AutoSize = true;
            this.rbLocalDB.Location = new System.Drawing.Point(59, 18);
            this.rbLocalDB.Name = "rbLocalDB";
            this.rbLocalDB.Size = new System.Drawing.Size(59, 17);
            this.rbLocalDB.TabIndex = 98;
            this.rbLocalDB.Text = "LOCAL";
            this.rbLocalDB.UseVisualStyleBackColor = true;
            this.rbLocalDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // itxt_Port
            // 
            this.itxt_Port.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Port.IsBrowseMode = false;
            this.itxt_Port.LabelText = "Port";
            this.itxt_Port.Location = new System.Drawing.Point(7, 14);
            this.itxt_Port.MaxLength = 32767;
            this.itxt_Port.MultiLine = false;
            this.itxt_Port.Name = "itxt_Port";
            this.itxt_Port.PasswordChar = '\0';
            this.itxt_Port.RowCount = 1;
            this.itxt_Port.ShowDeleteButton = false;
            this.itxt_Port.ShowFilter = false;
            this.itxt_Port.ShowTextboxOnly = false;
            this.itxt_Port.Size = new System.Drawing.Size(46, 40);
            this.itxt_Port.TabIndex = 95;
            this.itxt_Port.TabStop = false;
            this.itxt_Port.ValueText = "";
            // 
            // itxt_Password
            // 
            this.itxt_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Password.IsBrowseMode = false;
            this.itxt_Password.LabelText = "password";
            this.itxt_Password.Location = new System.Drawing.Point(130, 18);
            this.itxt_Password.MaxLength = 32767;
            this.itxt_Password.MultiLine = false;
            this.itxt_Password.Name = "itxt_Password";
            this.itxt_Password.PasswordChar = '*';
            this.itxt_Password.RowCount = 1;
            this.itxt_Password.ShowDeleteButton = false;
            this.itxt_Password.ShowFilter = false;
            this.itxt_Password.ShowTextboxOnly = false;
            this.itxt_Password.Size = new System.Drawing.Size(90, 40);
            this.itxt_Password.TabIndex = 1;
            this.itxt_Password.ValueText = "";
            this.itxt_Password.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // itxt_Username
            // 
            this.itxt_Username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Username.IsBrowseMode = false;
            this.itxt_Username.LabelText = "username";
            this.itxt_Username.Location = new System.Drawing.Point(34, 18);
            this.itxt_Username.MaxLength = 32767;
            this.itxt_Username.MultiLine = false;
            this.itxt_Username.Name = "itxt_Username";
            this.itxt_Username.PasswordChar = '\0';
            this.itxt_Username.RowCount = 1;
            this.itxt_Username.ShowDeleteButton = false;
            this.itxt_Username.ShowFilter = false;
            this.itxt_Username.ShowTextboxOnly = false;
            this.itxt_Username.Size = new System.Drawing.Size(90, 40);
            this.itxt_Username.TabIndex = 0;
            this.itxt_Username.ValueText = "";
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 138);
            this.Controls.Add(this.gbConnectionProperties);
            this.Controls.Add(this.itxt_Password);
            this.Controls.Add(this.itxt_Username);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.gbConnectionProperties.ResumeLayout(false);
            this.gbConnectionProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Username;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Password;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Port;
        private System.Windows.Forms.GroupBox gbConnectionProperties;
        private System.Windows.Forms.RadioButton rbConnectAsServer;
        private System.Windows.Forms.RadioButton rbDevDB;
        private System.Windows.Forms.RadioButton rbLiveDB;
        private System.Windows.Forms.RadioButton rbLocalDB;
        private System.Windows.Forms.Button btnTestConnection;
    }
}