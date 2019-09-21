using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
            toggleConnectionProperties();
            itxt_Username.focus();
        }

        private void setLastConnectedPortNo()
        {
            if (rbLiveDB.Checked || rbLocalDB.Checked)
                itxt_Port.ValueText = Settings.LastConnectedPortNo;
            else
                itxt_Port.ValueText = "";

            if(!itxt_Port.isEmpty())
            {
                if (itxt_Port.ValueText == rbPort1433.Text)
                    rbPort1433.Checked = true;
                else if(itxt_Port.ValueText == rbPort1434.Text)
                    rbPort1434.Checked = true;
                else if (itxt_Port.ValueText == rbPort1435.Text)
                    rbPort1435.Checked = true;
            }
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/
        #region AUTHENTICATION

        private void authenticate()
        {
            LIBUtil.Util.sanitize(itxt_Username.textbox, itxt_Password.textbox);
            GlobalData.UserAccount = UserAccount.authenticate(itxt_Username.ValueText, itxt_Password.ValueText, _bypassLogin);

            if (GlobalData.UserAccount != null)
            {
                if(rbLiveDB.Checked || rbLocalDB.Checked)
                    Settings.LastConnectedPortNo = itxt_Port.ValueText;

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
                if (isConnectedToServer())
                    authenticate();
                else
                    itxt_Password.focus();
            }
        }

        private bool isConnectedToServer()
        {
            GlobalData.ConnectAsServer = rbConnectAsServer.Checked;
            GlobalData.ConnectToDevDB = rbDevDB.Checked;
            GlobalData.ConnectToLiveDB = rbLiveDB.Checked;
            GlobalData.ConnectToLocalLiveDB = rbLocalDB.Checked;
            GlobalData.LiveConnectionPort = itxt_Port.ValueText;
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
            else
                LIBUtil.Util.displayMessageBoxError("Connection Failed: " + DBUtil.connectionInfo());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.C) || keyData == (Keys.Control | Keys.C))
            {
                toggleConnectionProperties();
                itxt_Port.focus();
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

        private void Itxt_Port_onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                itxt_Password.focus();

        }
        private void RbPort_CheckedChanged(object sender, EventArgs e)
        {
            itxt_Port.ValueText = ((RadioButton)sender).Text;
            itxt_Password.focus();
        }

        #endregion
        /*******************************************************************************************************/

    }
}
