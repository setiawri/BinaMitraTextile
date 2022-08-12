using System;
using System.Windows.Forms;
using System.Drawing;

using LIBUtil;

namespace BinaMitraTextile.POs
{
    public partial class MasterData_v1_Status_Form : LIBUtil.Desktop.Forms.MasterData_v1_Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const bool FORM_SHOWDATAONLOAD = true;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private DataGridViewColumn col_PONo;
        private DataGridViewColumn col_Timestamp;
        private DataGridViewColumn col_Age;
        private DataGridViewColumn col_ProductDescription;
        private DataGridViewColumn col_OrderQty;
        private DataGridViewColumn col_UnitName;
        private DataGridViewColumn col_ReceivedQty;
        private DataGridViewColumn col_PendingQty;
        private DataGridViewColumn col_PendingQtyValue;
        private DataGridViewColumn col_PriorityNo;
        private DataGridViewColumn col_PriorityQty;
        private DataGridViewColumn col_ExpectedDeliveryDate;
        private DataGridViewColumn col_ExpectedDeliveryDayCount;
        private DataGridViewColumn col_Customers_Name;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public MasterData_v1_Status_Form() : this(FormModes.Search) { }
        public MasterData_v1_Status_Form(FormModes startingMode) : base(startingMode, FORM_SHOWDATAONLOAD) { InitializeComponent(); }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region METHODS

        #endregion
        /*******************************************************************************************************/
        #region OVERRIDE METHODS

        protected override void setupFields()
        {
            enableFieldStatus<POItemStatus>();
            
            setColumnsDataPropertyNames(POItem.COL_DB_ID, null, POItem.COL_STATUSNAME, POItem.COL_DB_STATUSENUMID, null, null);
            btnAdd.Enabled = false;
            pbLog.Visible = false;
            
            iddl_POItemStatus.populate<POItemStatus>();

            col_ProductDescription = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_ProductDescription", "Description", POItem.COL_DB_PRODUCTDESCRIPTION, true, true, "", true, true, 100, DataGridViewContentAlignment.TopLeft);
            col_ProductDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_PONo = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_PONo", "PO", POItem.COL_PONO, true, true, "", true, false, 50, DataGridViewContentAlignment.MiddleCenter);
            col_Timestamp = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_Timestamp", "Date", POItem.COL_TIMESTAMP, true, true, "dd/MM/yy", false, false, 40, DataGridViewContentAlignment.MiddleCenter);
            col_Age = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_Age", "Age", POItem.COL_AGE, true, true, "", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_OrderQty = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_OrderQty", "Order", POItem.COL_DB_QTY, true, true, "N0", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_UnitName = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_UnitName", "Unit", POItem.COL_DB_UNITNAME, true, true, "", true, false, 30, DataGridViewContentAlignment.MiddleLeft);
            col_ReceivedQty = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_ReceivedQty", "Terima", POItem.COL_RECEIVEDQTY, true, true, "N0", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            col_PendingQty = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_PendingQty", "Sisa", POItem.COL_PENDINGQTY, true, true, "N0", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            col_PendingQtyValue = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_PendingQtyValue", "Value", POItem.COL_PENDINGQTYVALUE, true, false, "N0", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            col_PriorityNo = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_PriorityNo", "Priority", POItem.COL_DB_PriorityNo, true, true, "", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            Util.updateForeColorAndStyle(col_PriorityNo, Color.DarkBlue, FontStyle.Bold);
            col_PriorityQty = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_PriorityQty", "Qty", POItem.COL_DB_PriorityQty, true, true, "N0", false, false, 40, DataGridViewContentAlignment.MiddleRight);
            Util.updateForeColorAndStyle(col_PriorityQty, Color.DarkBlue, FontStyle.Bold);
            col_ExpectedDeliveryDate = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_ExpectedDeliveryDate", "Delivery", POItem.COL_DB_ExpectedDeliveryDate, true, true, "ddd dd/MM", false, false, 50, DataGridViewContentAlignment.MiddleCenter);
            Util.updateForeColorAndStyle(col_ExpectedDeliveryDate, Color.DarkOrange, FontStyle.Bold);
            col_dgv_StatusName.DisplayIndex = col_ExpectedDeliveryDate.DisplayIndex - 1;
            Util.updateForeColorAndStyle(col_dgv_StatusName, Color.DarkOrange, FontStyle.Bold);
            col_ExpectedDeliveryDayCount = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_ExpectedDeliveryDayCount", "Due", POItem.COL_DB_ExpectedDeliveryDayCount, true, true, "N0", false, false, 30, DataGridViewContentAlignment.MiddleRight);
            col_Customers_Name = base.addColumn<DataGridViewTextBoxCell>(dgv, "col_Customers_Name", "Customer", POItem.COL_SaleOrderItems_Customers_Name, true, false, "", false, false, 50, DataGridViewContentAlignment.MiddleLeft);
        }

        protected override void setupControlsBasedOnRoles()
        {
            if (GlobalData.UserAccount.role != Roles.User)
            {
                chkShowHidden.Visible = true;
            }
        }

        protected override void additionalSettings()
        {
        }

        protected override void clearInputFields()
        {
            iddl_POItemStatus.reset();
            in_PriorityNo.reset();
            in_PriorityQty.reset();
            idtp_ExpectedDeliveryDate.reset();

            //not updateable
            iddl_POItemStatus.Enabled = true;
        }

        protected override bool isValidToPopulateGridViewDataSource()
        {
            return true;
        }

        protected override System.Data.DataView loadGridviewDataSource()
        {
            return LIBUtil.Util.sortData(POItem.getIncompleteItems(), POItem.COL_DB_PriorityNo, SortOrder.Ascending, POItem.COL_PONO, SortOrder.Ascending).DefaultView;
        }

        protected override void populateInputFields()
        {
            POItem obj = new POItem(selectedRowID());
            iddl_POItemStatus.SelectedValue = obj.Status;
            in_PriorityNo.Value = obj.PriorityNo;
            in_PriorityQty.Value = obj.PriorityQty;
            idtp_ExpectedDeliveryDate.Value = obj.ExpectedDeliveryDate;

            //not updateable
            iddl_POItemStatus.Enabled = false;
        }

        protected override void update()
        {
            POItem.update(GlobalData.UserAccount.id, selectedRowID(), in_PriorityNo.ValueInt, in_PriorityQty.ValueInt, idtp_ExpectedDeliveryDate.Value);
        }

        protected override void add()
        {
        }

        protected override Boolean isInputFieldsValid()
        {
            return true;
        }

        protected override void btnLog_Click(object sender, EventArgs e)
        {
            Util.displayForm(null, new Logs.Main_Form(selectedRowID()));
            itxt_QuickSearch.Focus();
        }

        protected override void updateDefaultRow(Guid id) { }

        protected override void updateCheckbox1Column(Guid id, Boolean newValue) { }

        private void MasterData_v1_CustomerSaleAdjustments_Shown(object sender, EventArgs e)
        {
            scContent.Panel2Collapsed = true;
            ptInputPanel.PerformClick();
        }

        protected override void virtual_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected override void changeStatus_Click(object sender, EventArgs args)
        {
            POItem.updateStatus(selectedRowID(), Tools.parseEnum<POItemStatus>(sender.ToString()));
            base.changeStatus_Click(sender, args);
        }

        private void chkShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            col_PendingQtyValue.Visible = chkShowHidden.Checked;
        }

        private void ChkShowCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            col_Customers_Name.Visible = chkShowCustomerName.Checked;
            if(chkShowCustomerName.Checked)
                this.Width += 100;
            else
                this.Width -= 100;
        }

        #endregion METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS


        #endregion EVENT HANDLERS
        /*******************************************************************************************************/
    }
}
