using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Test
{
    public partial class TestConnection : Form
    {
        int _timeoutLength = 0;
        int _connectionTime = 0;
        DateTime _startTime;

        public TestConnection(int timeoutLength, int connectionTime)
        {
            InitializeComponent();

            _timeoutLength = timeoutLength;
            _connectionTime = connectionTime;
            //GlobalData.ConnectionTestCompleted = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //test connection using sql
                Tools.pause(_connectionTime);
            }
            catch
            {
                //do not show error message
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if((DateTime.Now - _startTime).Seconds < _timeoutLength)
            {
                MessageBox.Show("Connection successful");
                //GlobalData.ConnectionTestCompleted = true;
                this.Close();
            }
            MessageBox.Show("Disposing BW1");
        }

        private void TestConnection_Load(object sender, EventArgs e)
        {
            _startTime = DateTime.Now;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++ )
            {
                Tools.pause(Convert.ToInt16(Math.Ceiling((float)_timeoutLength/10)));
                //if (GlobalData.ConnectionTestCompleted)
                //    break;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (!GlobalData.ConnectionTestCompleted)
            //{
            //    MessageBox.Show("Connection test failed");
            //    this.Close();
            //}
            //MessageBox.Show("Disposing BW2");
        }
    }
}
