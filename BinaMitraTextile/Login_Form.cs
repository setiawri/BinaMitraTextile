using System;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile
{
    public partial class Login_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private bool _bypassLogin = false;
        private string _title = "LOGIN";

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/

        #region INITIALIZATION

        public Login_Form()
        {
            InitializeComponent();
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
            this.Text += " " + Settings.APPVERSION;

            //setup connection string in libutil
            DBConnection.populatePorts(iddl_Ports);

            if (DBUtil.isSalesEnvironment)
            {
                rbLocalDB.Checked = true;
                rbDevDB.Visible = false;
                rbConnectAsServer.Visible = false;
                itxt_ServerName.ValueText = DBUtil.ServerName_LiveLocal;
            }
            else if (DBUtil.isDevEnvironment)
            {
                rbDevDB.Checked = true;
                _bypassLogin = true;
                itxt_ServerName.ValueText = DBUtil.ServerName_DEV;
            }
            else if (DBUtil.isServerEnvironment)
            {
                rbConnectAsServer.Checked = true;
                rbDevDB.Visible = false;
                itxt_ServerName.ValueText = DBUtil.ServerName_LiveForServer;
            }
            else
            {
                rbLiveDB.Checked = true;

                rbDevDB.Visible = false;
                rbConnectAsServer.Visible = false;
                itxt_ServerName.ValueText = DBUtil.ServerName_Live;
            }
            itxt_DatabaseName.ValueText = Settings.SQL_DATABASENAME;
            setLastConnectedPortNo();
            updateServerNameAndDatabaseName();

            toggleConnectionProperties();
            itxt_Username.focus();
        }

        private void setLastConnectedPortNo()
        {
            if (rbLiveDB.Checked || rbLocalDB.Checked)
                iddl_Ports.SelectedItem = Settings.LastConnectedPortNo;
            else
                iddl_Ports.reset();
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/
        #region AUTHENTICATION

        private void authenticate()
        {
            GlobalData.UserAccount = UserAccount.authenticate(itxt_Username.ValueText, itxt_Password.ValueText, _bypassLogin);

            if (GlobalData.UserAccount != null)
            {
                if(rbLiveDB.Checked || rbLocalDB.Checked)
                    Settings.LastConnectedPortNo = (ConnectionPorts)iddl_Ports.SelectedItem;

                this.Hide();
                Util.displayForm(null, new Container_Form(), true);
                this.Show();
                this.Close();
            }
            else
            {
                itxt_Password.ValueText = "";
                itxt_Password.focus();
            }
        }

        #endregion AUTHENTICATION
        /*******************************************************************************************************/
        #region METHODS

        private bool isConnectedToServer()
        {
            GlobalData.ConnectAsServer = rbConnectAsServer.Checked;
            GlobalData.ConnectToDevDB = rbDevDB.Checked;
            GlobalData.ConnectToLiveDB = rbLiveDB.Checked;
            GlobalData.ConnectToLocalLiveDB = rbLocalDB.Checked;

            updateServerNameAndDatabaseName();

            return DBUtil.isDBConnectionAvailable();
        }

        private void setServerName()
        {
            if (rbLocalDB.Checked)
                itxt_ServerName.ValueText = DBUtil.ServerName_LiveLocal;
            else if (rbConnectAsServer.Checked)
                itxt_ServerName.ValueText = DBUtil.ServerName_LiveForServer;
            else if (rbDevDB.Checked)
                itxt_ServerName.ValueText = DBUtil.ServerName_DEV;
            else
                itxt_ServerName.ValueText = DBUtil.ServerName_Live;
        }

        private void updateServerNameAndDatabaseName()
        {
            string servername = itxt_ServerName.ValueText;
            if (iddl_Ports.hasSelectedValue())
                servername += ((ConnectionPorts)iddl_Ports.SelectedItem).ToString().Replace("port", ",");
            DBConnection.update(servername, itxt_DatabaseName.ValueText);
        }

        #endregion
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Login_Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!isConnectedToServer())
                    itxt_Password.focus();
                else
                {
                    if (Settings.hasLatestAppVersion())
                        authenticate();
                    else
                        Util.displayMessageBoxError("Please update app to latest version.");
                }
            }
        }

        private void rbConnection_CheckedChanged(object sender, EventArgs e)
        {
            setServerName();
            setLastConnectedPortNo();
            itxt_Username.focus();
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            if (isConnectedToServer())
                Util.displayMessageBoxSuccess(DBConnection.ConnectionInfo);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C))
            {
                toggleConnectionProperties();
                iddl_Ports.focus();
            }
            else if (keyData == (Keys.Control | Keys.L))
            {
                if (!gbConnectionProperties.Visible)
                    toggleConnectionProperties();

                if (!rbLocalDB.Checked && !rbLiveDB.Checked)
                    rbLocalDB.Checked = true;
                else if (rbLocalDB.Checked)
                    rbLiveDB.Checked = true;
                else if (rbLiveDB.Checked)
                    rbLocalDB.Checked = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void toggleConnectionProperties()
        {
            if (gbConnectionProperties.Visible)
            {
                gbConnectionProperties.Visible = false;
                this.Height -= gbConnectionProperties.Height;
            }
            else
            {
                gbConnectionProperties.Visible = true;
                this.Height += gbConnectionProperties.Height;
            }

            itxt_Username.focus();
        }

        private void Iddl_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            itxt_Password.focus();
        }

        private void Login_Form_Shown(object sender, EventArgs e)
        {
            if (_bypassLogin && !string.IsNullOrEmpty(Settings.autologinusername))
            {
                itxt_Username.ValueText = Settings.autologinusername;
                if (isConnectedToServer())
                    authenticate();
            }
        }

        #endregion
        /*******************************************************************************************************/

    }
}
