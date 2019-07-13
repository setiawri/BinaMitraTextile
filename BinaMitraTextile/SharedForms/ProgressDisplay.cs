using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BinaMitraTextile.SharedForms
{
    public partial class ProgressDisplay : Form
    {
        private int _counter = 0;
        private const int DEFAULT_SECONDS_TIMEOUT = 10;
        private const decimal DEFAULT_SECONDS_INTERVAL = (decimal)0.1;
        private const string DEFAULT_TIMEOUT_TEXT = "Operation timed out";

        private string _timeoutText = "Timed out";

        public static bool InUse = false;
        public static string DisplayText = "";
        public static bool SignalToQuit = true;

        public static Form ActiveForm;

        public ProgressDisplay() : this(DEFAULT_SECONDS_TIMEOUT, DEFAULT_SECONDS_INTERVAL, DEFAULT_TIMEOUT_TEXT) { }

        public ProgressDisplay(int secondsTimeout, decimal secondsInterval, string timeoutText)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            setLabelText();
            _timeoutText = timeoutText;
            timer1.Interval = (int)Math.Ceiling(secondsInterval * 1000);
            _counter = (int)Math.Ceiling(secondsTimeout / secondsInterval);
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
            start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ProgressDisplay.SignalToQuit)
            {
                stop(string.Empty);
            }
            else if(_counter == 0)
            {
                stop(_timeoutText);
            }
            _counter--;
        }

        private void setLabelText()
        {
            lblMessage.Text = ProgressDisplay.DisplayText;
            if (this.Width < lblMessage.Width)
                this.Width = lblMessage.Width;
            lblMessage.Left = (this.Width - lblMessage.Width) / 2; //center label 

        }

        private void start()
        {
            ProgressDisplay.SignalToQuit = false;
            ProgressDisplay.InUse = true;
            timer1.Start();
        }

        private void stop(string errorText)
        {
            timer1.Stop();
            ProgressDisplay.InUse = false;
            if (!string.IsNullOrEmpty(errorText))
                Tools.showError(errorText);
            this.Close();
        }

        public static void signalToQuit()
        {
            ProgressDisplay.SignalToQuit = true;
        }

        public static void run()
        {
            Tools.displayForm(new SharedForms.ProgressDisplay());
        }

    }
}
