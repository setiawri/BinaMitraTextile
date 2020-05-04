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

            DBConnection.populatePorts(iddl_Ports);

            if (DBUtil.isSalesEnvironment)
            {
                rbLocalDB.Checked = true;
                rbDevDB.Visible = false;
                rbConnectAsServer.Visible = false;
            }
            else if (DBUtil.isDevEnvironment)
            {
                rbDevDB.Checked = true;
                _bypassLogin = true;
                itxt_ServerName.Visible = true;
            }
            else if (DBUtil.isServerEnvironment)
            {
                rbConnectAsServer.Checked = true;
                rbDevDB.Visible = false;
            }
            else
            {
                rbLiveDB.Checked = true;

                rbDevDB.Visible = false;
                rbConnectAsServer.Visible = false;
            }

            setLastConnectedPortNo();

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
                LIBUtil.Util.displayForm(null, new Container_Form(), true);
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
        #region EVENT HANDLERS
            
        private void Login_Form_Load(object sender, EventArgs e)
        {
            setupControls();
        }

        private void ChkShowConnectionProperties_CheckedChanged(object sender, EventArgs e)
        {
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

        private bool isConnectedToServer()
        {
            GlobalData.ConnectAsServer = rbConnectAsServer.Checked;
            GlobalData.ConnectToDevDB = rbDevDB.Checked;
            GlobalData.ConnectToLiveDB = rbLiveDB.Checked;
            GlobalData.ConnectToLocalLiveDB = rbLocalDB.Checked;
            if (iddl_Ports.hasSelectedValue())
                GlobalData.LiveConnectionPort = ((ConnectionPorts)iddl_Ports.SelectedItem).ToString().Replace("port","");
            else
                GlobalData.LiveConnectionPort = "";
            if (!itxt_ServerName.isEmpty())
                GlobalData.LiveConnectionServerName = itxt_ServerName.ValueText;
            else
                GlobalData.LiveConnectionServerName = "";
            DBUtil.setConnectionString();

            if (DBUtil.isDBConnectionAvailable())
                return true;
            else
                return false;
        }

        private void rbConnection_CheckedChanged(object sender, EventArgs e)
        {
            setLastConnectedPortNo();
            itxt_Username.focus();
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            if (isConnectedToServer())
                LIBUtil.Util.displayMessageBoxSuccess(DBUtil.connectionInfo());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.C) || keyData == (Keys.Control | Keys.C))
            {
                toggleConnectionProperties();
                iddl_Ports.focus();
            }
            else if (keyData == (Keys.Alt | Keys.L))
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
