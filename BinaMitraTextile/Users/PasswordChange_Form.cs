using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Users
{
    public partial class PasswordChange_Form : Form
    {
        public PasswordChange_Form()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DBUtil.sanitize(txtCurrentPassword, txtNewPassword, txtConfirmPassword);
            
            if(isInputValid())
            {
                GlobalData.UserAccount.HashedPassword = txtNewPassword.Text;
                if(!Tools.hasMessage(GlobalData.UserAccount.update()))
                    this.Close();
            }
        }

        private bool isInputValid()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) || !GlobalData.UserAccount.authenticated(txtCurrentPassword.Text))
                return Tools.inputError<TextBox>(txtCurrentPassword, "Invalid Current Password");
            else if(string.IsNullOrWhiteSpace(txtNewPassword.Text) || !UserAccount.isValidNewPassword(txtNewPassword.Text))
                return Tools.inputError<TextBox>(txtNewPassword, "Invalid New Password");
            else if (txtConfirmPassword.Text != txtNewPassword.Text)
                return Tools.inputError<TextBox>(txtConfirmPassword, "Invalid Confirm Password");

            return true;
        }
    }
}
