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
    public partial class InputDateTimePicker : InputPanel
    {
        /*******************************************************************************************************/
        #region SETTINGS

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PROPERTIES

        public DateTime? Value { 
            get {
                if (!datetimepicker.Checked)
                    return null;
                else
                    return datetimepicker.Value; 
            } 
            set {
                if (value == null)
                    datetimepicker.Checked = false;
                else
                {
                    datetimepicker.Checked = true;
                    datetimepicker.Value = (DateTime)value;
                }
            } 
        }
        public bool TextError(string message) { return Tools.inputError<DateTimePicker>(datetimepicker, message); }
        
        public string SetFormat
        {
            get { return datetimepicker.CustomFormat; }
            set { datetimepicker.Format = DateTimePickerFormat.Custom; datetimepicker.CustomFormat = value; }
        }

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public InputDateTimePicker(bool showCheckbox)
        {
            InitializeComponent();
            datetimepicker.ShowCheckBox = showCheckbox;
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        public override void reset()
        {
            datetimepicker.Value = DateTime.Today;
            datetimepicker.Checked = false;
        }

        public override void focus()
        {
            datetimepicker.Focus();
        }

        public override void setAsDefaultTabbing()
        {
            this.TabIndex = 0;
            datetimepicker.TabIndex = 0;
        }

        public override void setLabelText(string text)
        {
            label.Text = text;
        }

        #endregion METHODS
        /*******************************************************************************************************/
    }
}
