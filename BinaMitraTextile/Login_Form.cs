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
            this.Text += DBUtil.appendTitleWithInfo();

            populateCBUsers();

            if (DBUtil.isDevEnvironment)
            {
                rbLiveDB.Focus();
                _bypassLogin = true;
                //lblConnectionType.Text = "3";
            }
            else
            {
                rbLiveDB.Visible = false;
                rbLiveDBLocal.Visible = false;
                cbUsers.Focus();

                //if (DBUtil.isSalesEnvironment)
                //    lblConnectionType.Text = "1";
                //else if (DBUtil.isServerEnvironment)
                //    lblConnectionType.Text = "2";
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
        
        private void rbDBConnection_CheckedChanged(object sender, EventArgs e)
        {
            GlobalData.ConnectToLiveDB = rbLiveDB.Checked;
            GlobalData.ConnectToLiveDBLocal = rbLiveDBLocal.Checked;
            if (!DBUtil.isDBConnectionAvailable())
            {
                GlobalData.ConnectToLiveDB = GlobalData.ConnectToLiveDBLocal = rbLiveDB.Checked = rbLiveDBLocal.Checked = false;
                rbLiveDB.Focus();
            }
            else
            {
                cbUsers.Focus();
            }
        }

        #endregion
        /*******************************************************************************************************/

    }
}
