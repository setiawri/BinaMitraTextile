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
            this.itxt_DatabaseName = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.itxt_ServerName = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.rbDevDB = new System.Windows.Forms.RadioButton();
            this.rbConnectAsServer = new System.Windows.Forms.RadioButton();
            this.rbLiveDB = new System.Windows.Forms.RadioButton();
            this.rbLocalDB = new System.Windows.Forms.RadioButton();
            this.itxt_Password = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.itxt_Username = new LIBUtil.Desktop.UserControls.InputControl_Textbox();
            this.iddl_Ports = new LIBUtil.Desktop.UserControls.InputControl_Dropdownlist();
            this.gbConnectionProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnectionProperties
            // 
            this.gbConnectionProperties.Controls.Add(this.iddl_Ports);
            this.gbConnectionProperties.Controls.Add(this.itxt_DatabaseName);
            this.gbConnectionProperties.Controls.Add(this.itxt_ServerName);
            this.gbConnectionProperties.Controls.Add(this.btnTestConnection);
            this.gbConnectionProperties.Controls.Add(this.rbDevDB);
            this.gbConnectionProperties.Controls.Add(this.rbConnectAsServer);
            this.gbConnectionProperties.Controls.Add(this.rbLiveDB);
            this.gbConnectionProperties.Controls.Add(this.rbLocalDB);
            this.gbConnectionProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbConnectionProperties.Location = new System.Drawing.Point(0, 85);
            this.gbConnectionProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbConnectionProperties.Name = "gbConnectionProperties";
            this.gbConnectionProperties.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbConnectionProperties.Size = new System.Drawing.Size(360, 166);
            this.gbConnectionProperties.TabIndex = 98;
            this.gbConnectionProperties.TabStop = false;
            // 
            // itxt_DatabaseName
            // 
            this.itxt_DatabaseName.IsBrowseMode = false;
            this.itxt_DatabaseName.LabelText = "DATABASE";
            this.itxt_DatabaseName.Location = new System.Drawing.Point(12, 102);
            this.itxt_DatabaseName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itxt_DatabaseName.MaxLength = 32767;
            this.itxt_DatabaseName.MultiLine = false;
            this.itxt_DatabaseName.Name = "itxt_DatabaseName";
            this.itxt_DatabaseName.PasswordChar = '\0';
            this.itxt_DatabaseName.RowCount = 1;
            this.itxt_DatabaseName.ShowDeleteButton = false;
            this.itxt_DatabaseName.ShowFilter = false;
            this.itxt_DatabaseName.ShowTextboxOnly = false;
            this.itxt_DatabaseName.Size = new System.Drawing.Size(229, 50);
            this.itxt_DatabaseName.TabIndex = 108;
            this.itxt_DatabaseName.ValueText = "";
            // 
            // itxt_ServerName
            // 
            this.itxt_ServerName.IsBrowseMode = false;
            this.itxt_ServerName.LabelText = "SERVER";
            this.itxt_ServerName.Location = new System.Drawing.Point(12, 52);
            this.itxt_ServerName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itxt_ServerName.MaxLength = 32767;
            this.itxt_ServerName.MultiLine = false;
            this.itxt_ServerName.Name = "itxt_ServerName";
            this.itxt_ServerName.PasswordChar = '\0';
            this.itxt_ServerName.RowCount = 1;
            this.itxt_ServerName.ShowDeleteButton = false;
            this.itxt_ServerName.ShowFilter = false;
            this.itxt_ServerName.ShowTextboxOnly = false;
            this.itxt_ServerName.Size = new System.Drawing.Size(229, 50);
            this.itxt_ServerName.TabIndex = 107;
            this.itxt_ServerName.ValueText = "";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(249, 110);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(97, 43);
            this.btnTestConnection.TabIndex = 103;
            this.btnTestConnection.Text = "TEST";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // rbDevDB
            // 
            this.rbDevDB.AutoSize = true;
            this.rbDevDB.Location = new System.Drawing.Point(291, 23);
            this.rbDevDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDevDB.Name = "rbDevDB";
            this.rbDevDB.Size = new System.Drawing.Size(53, 20);
            this.rbDevDB.TabIndex = 100;
            this.rbDevDB.Text = "DEV";
            this.rbDevDB.UseVisualStyleBackColor = true;
            this.rbDevDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbConnectAsServer
            // 
            this.rbConnectAsServer.AutoSize = true;
            this.rbConnectAsServer.Location = new System.Drawing.Point(168, 23);
            this.rbConnectAsServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbConnectAsServer.Name = "rbConnectAsServer";
            this.rbConnectAsServer.Size = new System.Drawing.Size(102, 20);
            this.rbConnectAsServer.TabIndex = 101;
            this.rbConnectAsServer.Text = "AS SERVER";
            this.rbConnectAsServer.UseVisualStyleBackColor = true;
            this.rbConnectAsServer.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbLiveDB
            // 
            this.rbLiveDB.AutoSize = true;
            this.rbLiveDB.Location = new System.Drawing.Point(96, 23);
            this.rbLiveDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbLiveDB.Name = "rbLiveDB";
            this.rbLiveDB.Size = new System.Drawing.Size(53, 20);
            this.rbLiveDB.TabIndex = 99;
            this.rbLiveDB.Text = "LIVE";
            this.rbLiveDB.UseVisualStyleBackColor = true;
            this.rbLiveDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // rbLocalDB
            // 
            this.rbLocalDB.AutoSize = true;
            this.rbLocalDB.Location = new System.Drawing.Point(12, 23);
            this.rbLocalDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbLocalDB.Name = "rbLocalDB";
            this.rbLocalDB.Size = new System.Drawing.Size(67, 20);
            this.rbLocalDB.TabIndex = 98;
            this.rbLocalDB.Text = "LOCAL";
            this.rbLocalDB.UseVisualStyleBackColor = true;
            this.rbLocalDB.CheckedChanged += new System.EventHandler(this.rbConnection_CheckedChanged);
            // 
            // itxt_Password
            // 
            this.itxt_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Password.IsBrowseMode = false;
            this.itxt_Password.LabelText = "password";
            this.itxt_Password.Location = new System.Drawing.Point(184, 22);
            this.itxt_Password.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itxt_Password.MaxLength = 32767;
            this.itxt_Password.MultiLine = false;
            this.itxt_Password.Name = "itxt_Password";
            this.itxt_Password.PasswordChar = '*';
            this.itxt_Password.RowCount = 1;
            this.itxt_Password.ShowDeleteButton = false;
            this.itxt_Password.ShowFilter = false;
            this.itxt_Password.ShowTextboxOnly = false;
            this.itxt_Password.Size = new System.Drawing.Size(120, 49);
            this.itxt_Password.TabIndex = 1;
            this.itxt_Password.ValueText = "";
            this.itxt_Password.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // itxt_Username
            // 
            this.itxt_Username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Username.IsBrowseMode = false;
            this.itxt_Username.LabelText = "username";
            this.itxt_Username.Location = new System.Drawing.Point(56, 22);
            this.itxt_Username.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.itxt_Username.MaxLength = 32767;
            this.itxt_Username.MultiLine = false;
            this.itxt_Username.Name = "itxt_Username";
            this.itxt_Username.PasswordChar = '\0';
            this.itxt_Username.RowCount = 1;
            this.itxt_Username.ShowDeleteButton = false;
            this.itxt_Username.ShowFilter = false;
            this.itxt_Username.ShowTextboxOnly = false;
            this.itxt_Username.Size = new System.Drawing.Size(120, 49);
            this.itxt_Username.TabIndex = 0;
            this.itxt_Username.ValueText = "";
            this.itxt_Username.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // iddl_Ports
            // 
            this.iddl_Ports.DisableTextInput = false;
            this.iddl_Ports.HideFilter = true;
            this.iddl_Ports.HideUpdateLink = true;
            this.iddl_Ports.LabelText = "PORT";
            this.iddl_Ports.Location = new System.Drawing.Point(249, 50);
            this.iddl_Ports.Margin = new System.Windows.Forms.Padding(5);
            this.iddl_Ports.Name = "iddl_Ports";
            this.iddl_Ports.SelectedIndex = -1;
            this.iddl_Ports.SelectedItem = null;
            this.iddl_Ports.SelectedItemText = "";
            this.iddl_Ports.SelectedValue = null;
            this.iddl_Ports.ShowDropdownlistOnly = false;
            this.iddl_Ports.Size = new System.Drawing.Size(97, 50);
            this.iddl_Ports.TabIndex = 109;
            // 
            // Login_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(360, 251);
            this.Controls.Add(this.gbConnectionProperties);
            this.Controls.Add(this.itxt_Password);
            this.Controls.Add(this.itxt_Username);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.Shown += new System.EventHandler(this.Login_Form_Shown);
            this.gbConnectionProperties.ResumeLayout(false);
            this.gbConnectionProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Username;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_Password;
        private System.Windows.Forms.GroupBox gbConnectionProperties;
        private System.Windows.Forms.RadioButton rbConnectAsServer;
        private System.Windows.Forms.RadioButton rbDevDB;
        private System.Windows.Forms.RadioButton rbLiveDB;
        private System.Windows.Forms.RadioButton rbLocalDB;
        private System.Windows.Forms.Button btnTestConnection;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_ServerName;
        private LIBUtil.Desktop.UserControls.InputControl_Textbox itxt_DatabaseName;
        private LIBUtil.Desktop.UserControls.InputControl_Dropdownlist iddl_Ports;
    }
}