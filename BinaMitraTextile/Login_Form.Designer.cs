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
            this.rbPort1433 = new System.Windows.Forms.RadioButton();
            this.pnlPorts = new System.Windows.Forms.Panel();
            this.rbPort1434 = new System.Windows.Forms.RadioButton();
            this.rbPort1435 = new System.Windows.Forms.RadioButton();
            this.gbConnectionProperties.SuspendLayout();
            this.pnlPorts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnectionProperties
            // 
            this.gbConnectionProperties.Controls.Add(this.pnlPorts);
            this.gbConnectionProperties.Controls.Add(this.btnTestConnection);
            this.gbConnectionProperties.Controls.Add(this.rbConnectAsServer);
            this.gbConnectionProperties.Controls.Add(this.rbDevDB);
            this.gbConnectionProperties.Controls.Add(this.rbLiveDB);
            this.gbConnectionProperties.Controls.Add(this.rbLocalDB);
            this.gbConnectionProperties.Controls.Add(this.itxt_Port);
            this.gbConnectionProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbConnectionProperties.Location = new System.Drawing.Point(0, 70);
            this.gbConnectionProperties.Name = "gbConnectionProperties";
            this.gbConnectionProperties.Size = new System.Drawing.Size(255, 100);
            this.gbConnectionProperties.TabIndex = 98;
            this.gbConnectionProperties.TabStop = false;
            this.gbConnectionProperties.Text = "Connection Properties";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(7, 60);
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
            this.rbConnectAsServer.Location = new System.Drawing.Point(122, 83);
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
            this.rbDevDB.Location = new System.Drawing.Point(59, 83);
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
            this.rbLiveDB.Location = new System.Drawing.Point(122, 63);
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
            this.rbLocalDB.Location = new System.Drawing.Point(59, 63);
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
            this.itxt_Port.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.Itxt_Port_onKeyDown);
            // 
            // itxt_Password
            // 
            this.itxt_Password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.itxt_Password.IsBrowseMode = false;
            this.itxt_Password.LabelText = "password";
            this.itxt_Password.Location = new System.Drawing.Point(130, 13);
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
            this.itxt_Username.Location = new System.Drawing.Point(34, 13);
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
            this.itxt_Username.onKeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // rbPort1433
            // 
            this.rbPort1433.AutoSize = true;
            this.rbPort1433.Location = new System.Drawing.Point(3, 3);
            this.rbPort1433.Name = "rbPort1433";
            this.rbPort1433.Size = new System.Drawing.Size(49, 17);
            this.rbPort1433.TabIndex = 104;
            this.rbPort1433.Text = "1433";
            this.rbPort1433.UseVisualStyleBackColor = true;
            this.rbPort1433.CheckedChanged += new System.EventHandler(this.RbPort_CheckedChanged);
            // 
            // pnlPorts
            // 
            this.pnlPorts.Controls.Add(this.rbPort1435);
            this.pnlPorts.Controls.Add(this.rbPort1434);
            this.pnlPorts.Controls.Add(this.rbPort1433);
            this.pnlPorts.Location = new System.Drawing.Point(56, 31);
            this.pnlPorts.Name = "pnlPorts";
            this.pnlPorts.Size = new System.Drawing.Size(187, 23);
            this.pnlPorts.TabIndex = 105;
            // 
            // rbPort1434
            // 
            this.rbPort1434.AutoSize = true;
            this.rbPort1434.Location = new System.Drawing.Point(52, 3);
            this.rbPort1434.Name = "rbPort1434";
            this.rbPort1434.Size = new System.Drawing.Size(49, 17);
            this.rbPort1434.TabIndex = 105;
            this.rbPort1434.Text = "1434";
            this.rbPort1434.UseVisualStyleBackColor = true;
            this.rbPort1434.CheckedChanged += new System.EventHandler(this.RbPort_CheckedChanged);
            // 
            // rbPort1435
            // 
            this.rbPort1435.AutoSize = true;
            this.rbPort1435.Location = new System.Drawing.Point(101, 3);
            this.rbPort1435.Name = "rbPort1435";
            this.rbPort1435.Size = new System.Drawing.Size(49, 17);
            this.rbPort1435.TabIndex = 106;
            this.rbPort1435.Text = "1435";
            this.rbPort1435.UseVisualStyleBackColor = true;
            this.rbPort1435.CheckedChanged += new System.EventHandler(this.RbPort_CheckedChanged);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 170);
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
            this.pnlPorts.ResumeLayout(false);
            this.pnlPorts.PerformLayout();
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
        private System.Windows.Forms.Panel pnlPorts;
        private System.Windows.Forms.RadioButton rbPort1435;
        private System.Windows.Forms.RadioButton rbPort1434;
        private System.Windows.Forms.RadioButton rbPort1433;
    }
}