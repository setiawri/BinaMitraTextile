using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.SharedForms
{
    public enum VerifyFormFontSize
    {
        Small = 18,
        Medium = 40,
        Large = 72
    }

    public partial class Verify_Form : Form
    {
        private decimal _pauseInSeconds = 0;

        public Verify_Form(string Code, string Length, VerifyFormFontSize fontSize)
        {
            InitializeComponent();

            Settings.setGeneralSettings(this);
            lblCode.Text = string.Format("[{0}]", Code);
            lblLength.Text = Length;

            //set font
            Font font = lblCode.Font;
            lblCode.Font = new Font(font.FontFamily, (int)fontSize);
            lblLength.Font = new Font(font.FontFamily, (int)fontSize);

            Tools.rearrangeButtonsInPanel(pnlButtons, HorizontalAlignment.Center);

            btnClose.Focus();
        }

        public Verify_Form(string Code, string Length) : this(Code, Length, VerifyFormFontSize.Large) { }

        public Verify_Form(string Code, string Length, decimal pauseInSeconds)
            : this(Code, Length, VerifyFormFontSize.Large)
        {
            _pauseInSeconds = pauseInSeconds;
            bgwCloseWindow.RunWorkerAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwCloseWindow_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep((int)(_pauseInSeconds * 1000));
        }

        private void bgwCloseWindow_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnClose.PerformClick();
        }

    }
}
