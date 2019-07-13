using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.UserControls
{
    public partial class InputCheckedListBox : InputPanel
    {
        /*******************************************************************************************************/
        #region PROPERTIES

        public bool noItemSelectedError(string message) { return Tools.inputError<CheckedListBox>(checkedlistbox, message); }

        public bool hasItemSelected() { return checkedlistbox.CheckedItems.Count > 0; }

        public CheckedListBox CheckedListBox { get { return checkedlistbox; } }

        public TextBox FilterText { get { return txtFilter; } }

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public InputCheckedListBox()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        public override void reset()
        {
            Tools.setAllItems(checkedlistbox, false);
        }

        public override void focus()
        {
            txtFilter.Focus();
        }

        public override void setAsDefaultTabbing()
        {
            this.TabIndex = 0;
            txtFilter.TabIndex = 0;
            checkedlistbox.TabIndex = 1;
            chk.TabIndex = 2;
        }

        public override void setLabelText(string text)
        {
            label.Text = text;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            Tools.setAllItems(checkedlistbox, chk.Checked);
        }

        public void populate(object data, string displayMember, string valueMember)
        {
            Tools.populateCheckedListBox(checkedlistbox, data, displayMember, valueMember);
        }

        public DataTable getSelectedInArrayTable(string columnName) { return Tools.copySelectionToArrayTable(checkedlistbox, columnName); }

        public string getDataViewRowFilter(string fieldName, Type type) { return Tools.compileRowFilterString(checkedlistbox, fieldName, type); }

        public string getDBFilterString(string fieldName, Type type) { return Tools.compileDBFilterString(checkedlistbox, fieldName, type); }

        #endregion METHODS
        /*******************************************************************************************************/
    }
}
