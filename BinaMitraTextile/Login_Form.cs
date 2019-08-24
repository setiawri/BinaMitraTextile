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

            setupControls();
        }

        private void setupControls()
        {
            this.Text = _title + DBUtil.appendTitleWithInfo();

            populateCBUsers();

            if(DBUtil.isSalesEnvironment)
            {
                chkLiveDB.Visible = false;
                chkLiveDBLocal.Visible = false;
                cbUsers.Focus();
            }
            else
            {
                chkLiveDBLocal.Focus();

                if(DBUtil.isDevEnvironment)
                    _bypassLogin = true;
            }
        }

        private void populateCBUsers()
        {
            Tools.populateDropDownList(cbUsers, UserAccount.getAll(false).DefaultView, UserAccount.COL_DB_NAME, UserAccount.COL_DB_ID, false);
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/
        #region AUTHENTICATION

        private void authenticate()
        {
            if (cbUsers.SelectedValue == null)
            {
                if (((DataView)cbUsers.DataSource).Count == 0) //allow creation of first user
                {
                    cbUsers.Text = "";
                    txtPassword.Text = "";
                    Tools.displayForm(new Users.Main_Form());
                    populateCBUsers();
                    cbUsers.Focus();
                }
                else
                {
                    Tools.hasMessage("Select a user from the drop down list");
                    cbUsers.Focus();
                }
            }
            else
            {
                UserAccount user = new UserAccount((Guid)cbUsers.SelectedValue);
                
                if (_bypassLogin || user.authenticated(txtPassword.Text.Trim()))
                {
                    cbUsers.Text = "";
                    txtPassword.Text = "";
                    GlobalData.UserAccount = user;
                    Tools.displayForm(this, new Main_Form());
                    if(!this.IsDisposed)
                    {
                        populateCBUsers();
                        cbUsers.Focus();
                    }
                    this.Close();
                }
                else
                {
                    Tools.hasMessage("Invalid password");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                authenticate();
        }

        #endregion AUTHENTICATION
        /*******************************************************************************************************/
        #region EVENT HANDLERS
        
        private void chkDBConnection_CheckedChanged(object sender, EventArgs e)
        {
            this.chkLiveDB.CheckedChanged -= new System.EventHandler(this.chkDBConnection_CheckedChanged);
            this.chkLiveDBLocal.CheckedChanged -= new System.EventHandler(this.chkDBConnection_CheckedChanged);
            
            if (sender == chkLiveDBLocal)
                chkLiveDB.Checked = false;
            else
                chkLiveDBLocal.Checked = false;

            GlobalData.ConnectToLiveDB = chkLiveDB.Checked;
            GlobalData.ConnectToLiveDBLocal = chkLiveDBLocal.Checked;
            if (!DBUtil.isDBConnectionAvailable())
            {
                GlobalData.ConnectToLiveDB = GlobalData.ConnectToLiveDBLocal = chkLiveDB.Checked = chkLiveDBLocal.Checked = false;
                chkLiveDBLocal.Focus();
            }
            else
            {
                cbUsers.Focus();
            }

            this.chkLiveDB.CheckedChanged += new System.EventHandler(this.chkDBConnection_CheckedChanged);
            this.chkLiveDBLocal.CheckedChanged += new System.EventHandler(this.chkDBConnection_CheckedChanged);

            this.Text = _title + DBUtil.appendTitleWithInfo();
        }
        #endregion
        /*******************************************************************************************************/

    }
}
