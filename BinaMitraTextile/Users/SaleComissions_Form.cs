using System;
using System.Windows.Forms;
using LIBUtil;

namespace BinaMitraTextile.Users
{
    public partial class SaleComissions_Form : Form
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

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public SaleComissions_Form() : this(null) { }
        public SaleComissions_Form(Guid? Id) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        private void setupControlsBasedOnRoles()
        {
            if(GlobalData.UserAccount.role != Roles.Super)
            {
                idtp_GeneratePeriod.Visible = false;
                btnGenerate.Visible = false;
                col_grid_Users_Username.Visible = false;
                col_grid_GlobalPercentComission.Visible = false;
                col_grid_Amount.Visible = false;
                col_grid_CorrectionAmount.Visible = false;
                col_grid_CorrectionNotes.Visible = false;

                this.Width -= (col_grid_Users_Username.Width + col_grid_GlobalPercentComission.Width 
                    + col_grid_Amount.Width + col_grid_CorrectionAmount.Width + col_grid_CorrectionNotes.Width);
            }
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            idtp_StartPeriod.Value = DateTime.Now.AddMonths(-12);
            idtp_GeneratePeriod.Value = DateTime.Now;

            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            col_grid_Id.DataPropertyName = SaleComission.COL_DB_Id;
            col_grid_Users_Username.DataPropertyName = SaleComission.COL_Users_Username;
            col_grid_Period.DataPropertyName = SaleComission.COL_DB_Period;
            col_grid_GlobalPercentComission.DataPropertyName = SaleComission.COL_DB_GlobalPercentComission;
            col_grid_Amount.DataPropertyName = SaleComission.COL_DB_Amount;
            col_grid_CorrectionAmount.DataPropertyName = SaleComission.COL_DB_CorrectionAmount;
            col_grid_CorrectionNotes.DataPropertyName = SaleComission.COL_DB_CorrectionNotes;
            col_grid_TotalAmount.DataPropertyName = SaleComission.COL_DB_Amount;
            col_grid_PaymentDate.DataPropertyName = SaleComission.COL_DB_PaymentDate;
        }

        private void populatePageData()
        {
            populateGrid();
        }

        private void populateGrid()
        {
            if(GlobalData.UserAccount.role != Roles.Super)
                grid.DataSource = SaleComission.get(GlobalData.UserAccount.id, idtp_StartPeriod.getFirstDayOfSelectedMonth());
            else
                grid.DataSource = SaleComission.get(idtp_StartPeriod.getFirstDayOfSelectedMonth());
        }

        private void resetUpdatePanel()
        {
            in_CorrectionAmount.reset();
            itxt_CorrectionNotes.reset();
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
            ptHeader.toggle();
            populatePageData();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaleComission.generate(idtp_GeneratePeriod.getFirstDayOfSelectedMonth());
            populateGrid();
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(GlobalData.UserAccount.role == Roles.Super)
            {
                SaleComission obj = new SaleComission(Util.getSelectedRowID(sender, col_grid_Id));
                in_CorrectionAmount.Value = obj.CorrectionAmount;
                itxt_CorrectionNotes.ValueText = obj.CorrectionNotes;
                idtp_PaymentDate.Value = obj.PaymentDate;
                pnlUpdate.Visible = true;
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            pnlUpdate.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(SaleComission.update(Util.getSelectedRowID(grid, col_grid_Id), in_CorrectionAmount.ValueInt, itxt_CorrectionNotes.ValueText, idtp_PaymentDate.Value))
            {
                pnlUpdate.Visible = false;
                populateGrid();
            }
        }

        private void pbLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(Util.getSelectedRowID(grid, col_grid_Id)));
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
