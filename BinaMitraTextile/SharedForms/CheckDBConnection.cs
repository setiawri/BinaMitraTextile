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
    public partial class CheckDBConnection : Form
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        private const int TIMEOUT = 50;

        private int _timerCounter = 0;

        public bool isDBConnectionAvailable = false;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public CheckDBConnection()
        {
            InitializeComponent();

            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 100; //raise event every 0.1 second
        }

        private void populatePageData()
        {

        }

        private void Form_Load(object sender, EventArgs e) 
        {
            DBUtil.ConnectionTestCompleted = false;
            timer1.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        #endregion INITIALIZATION

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Tools.pause(11);
            DBUtil.testDBConnection();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DBUtil.ConnectionTestCompleted = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DBUtil.ConnectionTestCompleted)
            {
                timer1.Stop();
                isDBConnectionAvailable = true;
                this.Close();
            }
            else if (_timerCounter == TIMEOUT)
            {
                timer1.Stop();
                isDBConnectionAvailable = false;
                
                MessageBox.Show("There is a problem connecting to the database. Please contact your administrator and try again."
                    + Environment.NewLine + Environment.NewLine + DBUtil.connectionInfo());
                this.Close();
            }
            else 
            {
                _timerCounter++;
                progressBar1.Value = _timerCounter * 100 / TIMEOUT;
            }

        }
        /*******************************************************************************************************/
    }
}
