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
    public partial class InputTextbox : InputPanel
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const int ROWHEIGHT = 14;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PROPERTIES

        public string TextValue { get { return DBUtil.sanitize(textbox.Text); } set { textbox.Text = DBUtil.sanitize(value); } }
        public int TextMaxLength { get { return textbox.MaxLength; } set { textbox.MaxLength = value; } }
        public bool TextError(string message) { return Tools.inputError<TextBox>(textbox, message); }
        
        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS
        
        public InputTextbox()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        public void setToMultiline(int rowCount)
        {
            if(rowCount > 1)
            {
                int additionalHeight = (rowCount - 1) * ROWHEIGHT;
                textbox.Multiline = true;
                this.Height += additionalHeight;
                textbox.Height += additionalHeight;
            }
        }

        public override void reset()
        {
            textbox.Text = "";
        }

        public override void focus()
        {
            textbox.Focus();
        }

        public override void setAsDefaultTabbing()
        {
            this.TabIndex = 0;
            textbox.TabIndex = 0;
        }

        public void setMaxLength(int maxlength)
        {
            textbox.MaxLength = maxlength;
        }

        public override void setLabelText(string text)
        {
            label.Text = text;
        }

        public bool isEmpty() { 
            return string.IsNullOrWhiteSpace(DBUtil.sanitize(textbox.Text));
        }

        #endregion METHODS
        /*******************************************************************************************************/
    }
}
