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
    public partial class InputDropdownlist : InputPanel
    {
        /*******************************************************************************************************/
        #region PROPERTIES

        public Guid? SelectedValue { get { return (Guid?)combobox.SelectedValue; } set { if (value == null) Tools.resetDropDownList(combobox); else combobox.SelectedValue = value; } }

        public bool SelectedValueError(string message) { return Tools.inputError<ComboBox>(combobox, message); }

        public bool isValidSelectedValue()
        {
            if (SelectedValue == null && !string.IsNullOrEmpty(combobox.Text))
                return Tools.inputError<ComboBox>(combobox, "Please select an item from the list or delete text from the dropdownlist");
            return true;
        }

        public ComboBox Dropdownlist { get { return combobox; } }

        public LinkLabel UpdateLink { get { return linklabel; } }

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public InputDropdownlist()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        public override void reset()
        {
            Tools.resetDropDownList(combobox);
        }

        public override void focus()
        {
            combobox.Focus();
        }

        public override void setAsDefaultTabbing()
        {
            this.TabIndex = 0;
            combobox.TabIndex = 0;
        }

        public override void setLabelText(string text)
        {
            label.Text = text;
        }

        #endregion METHODS
        /*******************************************************************************************************/
    }
}
