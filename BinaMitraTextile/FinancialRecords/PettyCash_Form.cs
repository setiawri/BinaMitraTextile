using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LIBUtil.Desktop.UserControls;

namespace BinaMitraTextile.FinancialRecords
{
    public partial class PettyCash_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private FormMode _formMode = FormMode.New;
        private Guid _idToUpdate;

        private List<InputControl> _calculatorFields;
        private int _calculatorBalance;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public PettyCash_Form()
        {
            InitializeComponent();
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControls()
        {
            this.Text = "PETTY CASH";
            this.Text += DBUtil.appendTitleWithInfo();

            //set filter to last 30 days
            idtp_FilterStart.Value = DateTime.Now.Date.AddDays(-30);
            idtp_FilterEnd.Value = DateTime.Now.Date;
            
            PettyCashRecordsCategory.populateDropDownList(dropFilterCategories, false, false);
            PettyCashRecordsCategory.populateDropDownList(dropCategories, false, false);

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            Tools.setColumnFormat(col_grid_amount, "N2", DataGridViewContentAlignment.MiddleRight);
            Tools.setColumnFormat(col_grid_balance, "N2", DataGridViewContentAlignment.MiddleRight);
            //Tools.setGridviewColumnWordwrap(col_grid_notes);
            Tools.disableSort(grid);
            col_grid_amount.DataPropertyName = PettyCashRecord.COL_DB_Amount;
            col_grid_balance.DataPropertyName = PettyCashRecord.COL_Balance;
            col_grid_categoryname.DataPropertyName = PettyCashRecord.COL_PettyCashRecordsCategories_Name;
            col_grid_no.DataPropertyName = PettyCashRecord.COL_DB_No;
            col_grid_notes.DataPropertyName = PettyCashRecord.COL_DB_Notes;
            col_grid_timestamp.DataPropertyName = PettyCashRecord.COL_DB_Timestamp;
            col_grid_id.DataPropertyName = PettyCashRecord.COL_DB_Id;
            col_grid_IsChecked.DataPropertyName = PettyCashRecord.COL_DB_IsChecked;
            
            dropCategories.Focus();

            //Calculator Fields
            _calculatorFields = new List<InputControl>() { in_100rb, in_50rb, in_20rb, in_10rb, in_5rb, in_2rb, in_1rb, in_500, in_200, in_100 };

            if (GlobalData.UserAccount.role != Roles.Super)
            {
                col_grid_IsChecked.Visible = false;
                btnUpdate.Visible = false;
            }
        }
		
        private void populateData()
        {
            LIBUtil.Util.setGridviewDataSource(grid, true, false, 
                PettyCashRecord.get(
                    null,
                    idtp_FilterStart.ValueAsStartDateFilter,
                    idtp_FilterEnd.ValueAsEndDateFilter,
                    (Guid?)Tools.getValue(dropFilterCategories), 
                    null,
                    chkOnlyNotChecked.Checked
                )
            );

            if (Tools.isDropdownlistSelected(dropFilterCategories))
                col_grid_balance.Visible = false;
            else
                col_grid_balance.Visible = true;
        }

		private void resetData()
		{
		
		}

        private bool isInputValid()
        {
            if (!Tools.isDropdownlistSelected(dropCategories))
                return Tools.inputError<ComboBox>(dropCategories, "Pilih Kategori");
            return true;
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        private void Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populateData();
        }

        private void btnAddPettyCashRecord_Click(object sender, EventArgs e)
        {
            if(isInputValid())
            {
                if(_formMode == FormMode.New)
                    PettyCashRecord.add((Guid)dropCategories.SelectedValue, in_Amount.Value, txtNotes.Text);
                else
                    PettyCashRecord.update(_idToUpdate, (Guid)dropCategories.SelectedValue, in_Amount.Value, txtNotes.Text);

                resetInput();
                populateData();
            }
        }

        private void resetInput()
        {
            _formMode = FormMode.New;
            in_Amount.reset();
            txtNotes.Text = string.Empty;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            col_grid_balance.Visible = !chkOnlyNotChecked.Checked;
            populateData();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            LIBUtil.Desktop.UserControls.InputControl_Textbox.showInNumeric((TextBox)sender, true, true);
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Tools.getClickedRowID(grid, col_grid_id, e.RowIndex)));
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LIBUtil.Util.isColumnMatch(sender, e, col_grid_IsChecked))
            {
                int firstIndex = grid.FirstDisplayedScrollingRowIndex;
                DataGridViewRow row = grid.Rows[e.RowIndex];
                PettyCashRecord.updateCheckedStatus((Guid)row.Cells[col_grid_id.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                populateData();
                Tools.setFirstDisplayedScrollingRowIndex((DataGridView)sender, firstIndex, e.RowIndex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                _formMode = FormMode.Update;
                _idToUpdate = LIBUtil.Util.getSelectedRowID(grid, col_grid_id);
                PettyCashRecord obj = new PettyCashRecord(_idToUpdate);
                dropCategories.SelectedValue = obj.PettyCashRecordsCategories_Id;
                in_Amount.Value = obj.Amount;
                txtNotes.Text = obj.Notes;
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if(_formMode == FormMode.Update)
                resetInput();
        }

        private void PettyCash_Form_Shown(object sender, EventArgs e)
        {
            panelToggle1.toggle();
        }

        private void chkOnlyNotChecked_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            pnlCalculator.Visible = !pnlCalculator.Visible;
            if(pnlCalculator.Visible)
                btnResetCalculator.PerformClick();
        }

        private void btnResetCalculator_Click(object sender, EventArgs e)
        {
            foreach (InputControl_Numeric input in _calculatorFields)
                input.Value = 0;

            _calculatorBalance = (int)LIBUtil.Util.zeroNonNumericString(grid.Rows[0].Cells[col_grid_balance.Name].Value);
            lblCalculatorBalance.Text = string.Format("Balance: {0:N0}", _calculatorBalance);
            lblCalculatorBalanceDiff.Text = string.Format("{0:N0}", _calculatorBalance);
            in_100rb.focus();
        }

        private void btnCloseCalculator_Click(object sender, EventArgs e)
        {
            pnlCalculator.Visible = false;
        }

        private void in_Calculator_ValueChanged(object sender, EventArgs e)
        {
            //calculate total and diff
            decimal value = 0;
            foreach(InputControl_Numeric input in _calculatorFields)
                value += input.ValueInt;
            lblCalculatorTotal.Text = string.Format("{0:N0}", value);
            lblCalculatorBalanceDiff.Text = string.Format("{0:N0}", _calculatorBalance - value);

            //calculate qty
            value = ((InputControl_Numeric)sender).ValueInt;
            if (sender == in_100rb)
                updateCalculatorQty(lbl100rb, value/100000);
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

        private void updateCalculatorQty(Label label, decimal qty)
        {
            if(qty%1 == 0)
                label.Text = qty + " x";
            else
                label.Text = "ERR";
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
