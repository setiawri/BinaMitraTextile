using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LIBUtil;
using LIBUtil.Desktop.UserControls;

namespace BinaMitraTextile.Admin
{
    public partial class Calculator_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region PROPERTIES

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private bool _isFormShown = false;

        private List<InputControl> _calculatorFields;
        private int _calculatorBalance;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public Calculator_Form() : this(0) { }
        public Calculator_Form(int initialBalance) 
        { 
            InitializeComponent(); 
            
            _calculatorBalance = initialBalance; 
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {

        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            _calculatorFields = new List<InputControl>() { in_100rb, in_50rb, in_20rb, in_10rb, in_5rb, in_2rb, in_1rb, in_500, in_200, in_100 };
        }

        private void populatePageData()
        {
        }

        private void updateCalculatorQty(Label label, decimal qty)
        {
            if (qty % 1 == 0)
                label.Text = qty + " x";
            else
                label.Text = "ERR";
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            setupControlsBasedOnRoles();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            _isFormShown = true;
            populatePageData();
            btnResetCalculator.PerformClick();
        }


        private void btnResetCalculator_Click(object sender, EventArgs e)
        {
            foreach (InputControl_Numeric input in _calculatorFields)
                input.Value = 0;

            lblCalculatorBalance.Text = string.Format("Balance: {0:N0}", _calculatorBalance);
            lblCalculatorBalanceDiff.Text = string.Format("{0:N0}", _calculatorBalance);
            in_100rb.focus();
        }

        private void in_Calculator_ValueChanged(object sender, EventArgs e)
        {
            //calculate total and diff
            decimal value = 0;
            foreach (InputControl_Numeric input in _calculatorFields)
                value += input.ValueInt;
            lblCalculatorTotal.Text = string.Format("{0:N0}", value);
            lblCalculatorBalanceDiff.Text = string.Format("{0:N0}", _calculatorBalance - value);

            //calculate qty
            value = ((InputControl_Numeric)sender).ValueInt;
            if (sender == in_100rb)
                updateCalculatorQty(lbl100rb, value / 100000);
            else if (sender == in_50rb)
                updateCalculatorQty(lbl50rb, value / 50000);
            else if (sender == in_20rb)
                updateCalculatorQty(lbl20rb, value / 20000);
            else if (sender == in_10rb)
                updateCalculatorQty(lbl10rb, value / 10000);
            else if (sender == in_5rb)
                updateCalculatorQty(lbl5rb, value / 5000);
            else if (sender == in_2rb)
                updateCalculatorQty(lbl2rb, value / 2000);
            else if (sender == in_1rb)
                updateCalculatorQty(lbl1rb, value / 1000);
            else if (sender == in_500)
                updateCalculatorQty(lbl500, value / 500);
            else if (sender == in_200)
                updateCalculatorQty(lbl200, value / 200);
            else if (sender == in_100)
                updateCalculatorQty(lbl100, value / 100);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
