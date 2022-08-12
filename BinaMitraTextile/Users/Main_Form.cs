using LIBUtil;
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
    public partial class Main_Form : Form
    {
        /*******************************************************************************************************/

        #region CLASS VARIABLES

        private Guid _selected_UserAcounts_Id;

        const string BTN_TEXT_ADDNEW = "ADD NEW";
        const string BTN_TEXT_UPDATE = "UPDATE";

        #endregion CLASS VARIABLES

        /*******************************************************************************************************/

        #region INITIALIZATION

        public Main_Form()
        {
            InitializeComponent();

            grid.AutoGenerateColumns = false;
            col_grid_PercentCommission.DataPropertyName = UserAccount.COL_DB_PercentCommission;
            col_grid_GlobalPercentCommission.DataPropertyName = UserAccount.COL_DB_GlobalPercentComission;
            populateGrid();

            showNewForm();
            populateCBRoles();
        }

        private void populateCBRoles()
        {
            Tools.populateDropDownList(cbRoles, typeof(Roles));
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Settings.setGeneralSettings(this);
        }

        #endregion INITIALIZATION

        /*******************************************************************************************************/

        #region LIST

        private void populateGrid()
        {
            grid.DataSource = UserAccount.get(null, null, chkShowInactive.Checked).DefaultView;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        private void chkShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private bool isValidToDeactivate(Roles role)
        {
            if (role != Roles.Super)
                return true;

            DataTable dt = ((DataView)grid.DataSource).Table;
            int superusercount = Convert.ToInt16(dt.Compute(String.Format("COUNT({0})", UserAccount.COL_ROLE), 
                                                    String.Format("{0} = 1 AND {1} = {2}", DBUtil.COL_ACTIVE, UserAccount.COL_ROLE, (int)Roles.Super)));
            if (superusercount == 0)
            {
                //there is no active super user, active user must be more than one
                int usercount = Convert.ToInt16(dt.Compute(String.Format("COUNT({0})", UserAccount.COL_ROLE),
                                                        String.Format("{0} = 1", DBUtil.COL_ACTIVE)));
                return usercount > 1;
            }
            else 
            {
                //super user must be more than one
                return superusercount > 1;
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), active.Name))
            {
                DataGridViewCell chkCell = grid.Rows[e.RowIndex].Cells[active.Name];
                bool newStatus = !(bool)chkCell.Value;
                if (newStatus == false && !isValidToDeactivate(Tools.parseEnum<Roles>(grid.Rows[e.RowIndex].Cells[col_grid_role.Name].Value)))
                {
                    //prevent deactivating the last super user or last user
                    Tools.hasMessage("Cannot deactivate the only active super user or the last active user");
                }
                else
                {
                    UserAccount.updateActiveStatus((Guid)grid.Rows[e.RowIndex].Cells[UserAccount.COL_DB_ID].Value, newStatus);
                    populateGrid();
                }
            }
            else if(Util.isColumnMatch(sender, e, LinkName))
            {
                populateForm((Guid)grid.Rows[e.RowIndex].Cells[UserAccount.COL_DB_ID].Value);
            }

        }

        #endregion LIST

        /*******************************************************************************************************/

        #region ADD/UPDATE ITEM

        private void showNewForm()
        {
            btnSubmit.Text = BTN_TEXT_ADDNEW;
            clearForm();
        }

        private void populateForm(Guid id)
        {
            btnSubmit.Text = BTN_TEXT_UPDATE;
            UserAccount obj = new UserAccount(id);
            _selected_UserAcounts_Id = id;
            txtName.Text = obj.name;
            cbRoles.SelectedItem = obj.role;
            in_PercentCommission.Value = obj.percentCommission;
            in_GlobalPercentComission.Value = obj.GlobalPercentComission;
            txtNotes.Text = obj.notes;
            txtCurrentPassword.Enabled = true;
            itxt_PasswordReset.Enabled = btnResetPassword.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (btnSubmit.Text)
            {
                case BTN_TEXT_ADDNEW:
                    {
                        if (isInputFieldsValid(false))
                        {
                            UserAccount obj = new UserAccount(txtName.Text, txtNewPassword.Text, (Roles)cbRoles.SelectedValue, in_PercentCommission.ValueDecimal, in_GlobalPercentComission.ValueDecimal, txtNotes.Text);
                            if (obj.submitNew() != null)
                            {
                                Tools.hasMessage("The new data has been added");
                                clearForm();
                            }
                            populateGrid();
                            showNewForm();
                        }
                        break;
                    }
                case BTN_TEXT_UPDATE:
                    {
                        if (isInputFieldsValid(true))
                        {
                            UserAccount obj = new UserAccount(txtName.Text, null, (Roles)cbRoles.SelectedValue, in_PercentCommission.ValueDecimal, in_GlobalPercentComission.ValueDecimal, txtNotes.Text);
                            if (!string.IsNullOrEmpty(txtNewPassword.Text))
                                obj.HashedPassword = txtNewPassword.Text;

                            obj.id = _selected_UserAcounts_Id;
                            obj.update();
                            populateGrid();
                            showNewForm();
                        }
                        break;
                    }
            }
        }

        private Boolean isInputFieldsValid(bool isUpdate)
        {
            //trim
            txtName.Text = txtName.Text.Trim();
            txtNotes.Text = txtNotes.Text.Trim();

            if (string.IsNullOrEmpty(txtName.Text))
                return Tools.inputError<TextBox>(txtName, "Please provide name");
            else if (!isUpdate && UserAccount.isNameExist(txtName.Text))
                return Tools.inputError<TextBox>(txtName, "Name is already in the list"); //prevent duplicate name
            else if (cbRoles.SelectedValue == null)
                return Tools.inputError<ComboBox>(cbRoles, "Please select a role listed in the drop down list");
            else if(!isValidPassword(isUpdate))
            {
                return false;
            }
            return true;
        }

        private bool isValidPassword(bool isUpdate)
        {
            if (!isUpdate)
            {
                if (!isValidNewPassword()) return false;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNewPassword.Text))
                {
                    if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                    {
                        Tools.hasMessage("New password doesn't match the confirm textbox");
                        txtNewPassword.Text = "";
                        txtConfirmNewPassword.Text = "";
                        txtNewPassword.Focus();
                        return false;
                    }
                    if (!isValidCurrentPassword()) return false;
                }
            }

            return true;
        }

        private bool isValidCurrentPassword()
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
                return Tools.inputError<TextBox>(txtCurrentPassword, "Please write current password in 'current' textbox");
            else if (!(new UserAccount(_selected_UserAcounts_Id)).authenticated(txtCurrentPassword.Text))
                return Tools.inputError<TextBox>(txtCurrentPassword, "Incorrect current password. Please try again");

            return true;
        }

        private bool isValidNewPassword()
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
                return Tools.inputError<TextBox>(txtNewPassword, "Please provide new password");
            else if (txtNewPassword.Text.Length < UserAccount.PASSWORD_MIN_LENGTH)
                return Tools.inputError<TextBox>(txtNewPassword, "Minimum is 4 characters");
            else if (string.IsNullOrEmpty(txtConfirmNewPassword.Text))
                return Tools.inputError<TextBox>(txtConfirmNewPassword, "Please write password in 'confirm' textbox");
            else if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                return Tools.inputError<TextBox>(txtConfirmNewPassword, "Password does not match the one in 'confirm' textbox");

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            showNewForm();
        }

        private void clearForm()
        {
            txtName.Text = "";
            in_PercentCommission.reset();
            in_GlobalPercentComission.reset();
            txtNotes.Text = "";
            txtNewPassword.Text = "";
            txtConfirmNewPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtCurrentPassword.Enabled = false;
            itxt_PasswordReset.Enabled = btnResetPassword.Enabled = false;

            txtName.Focus();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            UserAccount.update_HashedPassword(_selected_UserAcounts_Id, itxt_PasswordReset.ValueText);
        }

        #endregion ADD/UPDATE ITEM


        /*******************************************************************************************************/

    }
}
