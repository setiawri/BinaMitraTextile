using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BinaMitraTextile.SharedForms
{
    public partial class Add_Notes_Form : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private Guid _id;
        private string _storedProcedureName;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public Add_Notes_Form(Guid id, string storedProcedureName)
        {
            InitializeComponent();

            _id = id;
            _storedProcedureName = storedProcedureName;
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region LIST
        #endregion LIST
        /*******************************************************************************************************/
        #region ADD/UPDATE ITEM
        #endregion ADD/UPDATE ITEM
        /*******************************************************************************************************/
        #region FORM METHODS
        #endregion FORM METHODS
        /*******************************************************************************************************/
        #region SUBMISSION

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                DBUtil.addNotes(_storedProcedureName, _id, txtNotes.Text);
                this.Close();
            }
        }

        private bool isInputValid()
        {
            txtNotes.Text = DBUtil.sanitize(txtNotes.Text);

            if (string.IsNullOrEmpty(txtNotes.Text))
                return Tools.inputError<TextBox>(txtNotes, "Please provide the notes");

            return true;
        }

        #endregion SUBMISSION
        /*******************************************************************************************************/
        #region PRINT METHODS
        #endregion PRINT METHODS
        /*******************************************************************************************************/

    }
}
