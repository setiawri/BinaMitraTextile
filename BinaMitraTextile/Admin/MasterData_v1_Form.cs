using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using BinaMitraTextile.UserControls;
using LIBUtil;

namespace BinaMitraTextile
{
    public partial class MasterData_v1_Form : Form
    {
        /*******************************************************************************************************/
        #region SETTINGS

        private const string BUTTONTEXT_SUBMIT_SEARCH = "SUBMIT SEARCH";
        private const string BUTTONTEXT_SUBMIT_NEW = "SUBMIT NEW";
        private const string BUTTONTEXT_SUBMIT_UPDATE = "SUBMIT UPDATE";

        private Size FORM_DEFAULTSIZE = new Size(830, 600);
        private const int INPUT_CONTROL_MARGIN = 10;
        private const int INPUT_CONTROL_VERTICAL_PADDING = 5;
        private const int INPUT_CONTROL_WIDTH = 180;
        private Color MODEBUTTON_COLOR_DEFAULT = Color.Black;
        private Color MODEBUTTON_COLOR_ACTIVE = Color.DarkOrange;

        #endregion SETTINGS
        /*******************************************************************************************************/
        #region PROTECTED VARIABLES

        protected List<Panel> InputColumns = new List<Panel>();
        protected List<InputPanel> _inputToClear = new List<InputPanel>();
        protected List<string> FieldnamesForQuickSearch = new List<string>();
        protected InputPanel DefaultInputToFocus;
        protected List<InputPanel> _inputToDisableOnSearch = new List<InputPanel>();
        protected List<InputPanel> _inputToDisableOnUpdate = new List<InputPanel>();
        protected int tabCounter = 0;
        protected bool DoNotClearInputAfterSubmission = false;

        #endregion PROTECTED VARIABLES
        /*******************************************************************************************************/
        #region PROPERTIES

        public FormMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                changeFormMode();
            }
        }
        private FormMode _mode = FormMode.Search;

        public Guid browseItemSelection;

        #endregion PROPERTIES
        /*******************************************************************************************************/
        #region PRIVATE VARIABLES

        private FormMode _startingMode = FormMode.Search;
        private bool _showDataOnLoad = false;

        #endregion PRIVATE VARIABLES
        /*******************************************************************************************************/
        #region INITIALIZATION

        public MasterData_v1_Form(string formTitle, FormMode startingMode, bool showDataOnLoad, int formMinimumWidth)
        {
            InitializeComponent();

            this.Text = formTitle;
            this.MinimumSize = new Size(formMinimumWidth, this.MinimumSize.Height);
            _startingMode = startingMode;
            _showDataOnLoad = showDataOnLoad;

            setupControls();
            setupFields();

            Tools.rearrangeButtonsInPanel(pnlModeButtons, HorizontalAlignment.Center);
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);
            this.Size = FORM_DEFAULTSIZE;

            gridview.AutoGenerateColumns = false;
            gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridview.MultiSelect = false;

            InputColumns.Add(scInputLeft.Panel1);
            InputColumns.Add(scInputLeft.Panel2);
            InputColumns.Add(scInputRight.Panel1);
            InputColumns.Add(scInputRight.Panel2);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if(_showDataOnLoad) btnSubmit.PerformClick();
            Mode = _startingMode;
            DefaultInputToFocus.focus();

            if (_startingMode == FormMode.Browse)
            {
                pnlModeButtons.Visible = false;
                pnlInputContainer.Visible = false;
                col_grid_active.Visible = false;
                col_grid_default.Visible = false;
                col_grid_checkbox1.Visible = false;
                txtQuickSearch.Select();
            }
        }

        #endregion INITIALIZATION
        /*******************************************************************************************************/
        #region VIRTUAL METHODS

        protected virtual void setupFields() { }
        protected virtual DataView loadGridviewDataSource() { return null; }
        protected virtual bool isValidToPopulateGridViewDataSource() { return false; }
        protected virtual void populateInputFields() { }
        protected virtual Boolean isInputFieldsValid() { return false; }
        protected virtual void update() { }
        protected virtual void add() { }
        protected virtual void updateActiveStatus(Guid id, Boolean activeStatus) { }
        protected virtual void updateDefaultRow(Guid id) { }
        protected virtual void changeStatus_Click(object sender, EventArgs args) { populateGridViewDataSource(true); }
        protected virtual void updateCheckboxColumn(Guid id, bool newValue) { }
        protected virtual void executeAction1() { populateGridViewDataSource(true); }
        protected virtual void executeAction2() { populateGridViewDataSource(true); }
        protected virtual void executeAction3() { populateGridViewDataSource(true); }
        protected virtual void executeAction4() { populateGridViewDataSource(true); }
        protected virtual void executeAction5() { populateGridViewDataSource(true); }
        protected virtual void executeAction6() { populateGridViewDataSource(true); }
        protected virtual void showUserHiddenControls() { }

        #endregion VIRTUAL METHODS
        /*******************************************************************************************************/
        #region PROTECTED METHODS

        protected InputPanel setupInputControl(InputPanel formControl, int inputContainerColumnIndex, string fieldTitle, string fieldDBName, int gridviewColumnWidth, bool isReadOnly, bool disableOnSearch, string format)
        {
            setupInputControl(formControl, inputContainerColumnIndex, fieldTitle, fieldDBName, disableOnSearch);
            Tools.addColumn<DataGridViewTextBoxCell>(gridview, fieldDBName, fieldTitle, fieldDBName, gridviewColumnWidth, isReadOnly, format); //add field to gridview
            return formControl;
        }

        protected InputPanel setupInputControl(InputPanel formControl, int inputContainerColumnIndex, string fieldTitle, string fieldDBName, bool disableOnSearch)
        {
            formControl.TabIndex = tabCounter++;
            formControl.Visible = true; //set to visible
            formControl.setLabelText(fieldTitle); //set label text in control
            _inputToClear.Add(formControl); //add field to list of input to clear
            if (disableOnSearch) _inputToDisableOnSearch.Add(formControl); //add field to list of input to hide on search
            FieldnamesForQuickSearch.Add(fieldDBName); //add field name to quick search list
            InputColumns[inputContainerColumnIndex].Controls.Add(formControl); //add to input field container
            return formControl;
        }

        protected void clearInputFields()
        {
            foreach (InputPanel inputPanel in _inputToClear)
                inputPanel.reset();
        }

        protected void populateInputFieldsForUpdate()
        {
            if (gridview.SelectedRows.Count > 0)
                populateInputFields();
        }

        protected Guid selectedRowID()
        {
            return (Guid)gridview.SelectedRows[0].Cells[col_grid_id.Name].Value;
        }

        protected void disableFieldActive()
        {
            col_grid_active.Visible = false;
            chkIncludeInactive.Visible = false;
        }

        protected void enableFieldStatus<T>()
        {
            col_grid_statusname.Visible = true;
            addStatusContextMenu<T>(col_grid_statusname);
        }

        #endregion PROTECTED METHODS
        /*******************************************************************************************************/
        #region PRIVATE METHODS

        private void changeFormMode()
        {
            //reset button colors
            btnSearch.ForeColor = MODEBUTTON_COLOR_DEFAULT;
            btnAdd.ForeColor = MODEBUTTON_COLOR_DEFAULT;
            btnUpdate.ForeColor = MODEBUTTON_COLOR_DEFAULT;

            switch(_mode)
            {
                case FormMode.Search:
                    btnSubmit.Text = BUTTONTEXT_SUBMIT_SEARCH;
                    btnCancel.Visible = false;
                    btnSearch.ForeColor = MODEBUTTON_COLOR_ACTIVE;
                    updateGridviewColumnToDisable(_inputToDisableOnUpdate, true, false);
                    updateGridviewColumnToDisable(_inputToDisableOnSearch, false, true);
                    break;
                case FormMode.New:
                    btnSubmit.Text = BUTTONTEXT_SUBMIT_NEW;
                    btnCancel.Visible = true;
                    btnAdd.ForeColor = MODEBUTTON_COLOR_ACTIVE;
                    updateGridviewColumnToDisable(_inputToDisableOnSearch, true, false);
                    updateGridviewColumnToDisable(_inputToDisableOnUpdate, true, false);
                    break;
                case FormMode.Update:
                    btnSubmit.Text = BUTTONTEXT_SUBMIT_UPDATE;
                    btnCancel.Visible = true;
                    btnUpdate.ForeColor = MODEBUTTON_COLOR_ACTIVE;
                    updateGridviewColumnToDisable(_inputToDisableOnSearch, true, false);
                    updateGridviewColumnToDisable(_inputToDisableOnUpdate, false, false);
                    break;
            }

            updateModeButtonsAvailabilityForGridRow();
            arrangeInputPanelsAndResizeForm();
            Tools.rearrangeButtonPanel(pnlActionButtons, HorizontalAlignment.Center);
            focusFirstInputPanel();
        }

        private void focusFirstInputPanel()
        {
            foreach(Control control in InputColumns[0].Controls)
                if (control.Visible && control.Enabled && (control.GetType() == typeof(InputTextbox)
                    || control.GetType() == typeof(InputDropdownlist)
                    || control.GetType() == typeof(InputEnumDropdownlist) 
                    || control.GetType() == typeof(InputDateTimePicker)))
                {
                    control.Select();
                    break;
                }
        }
        
        private void updateGridviewColumnToDisable(List<InputPanel> inputToDisable, bool enabled, bool reset)
        {
            foreach (InputPanel input in inputToDisable)
            {
                input.Enabled = enabled;
                if (reset)
                    input.reset();
            }
        }

        private void updateModeButtonsAvailabilityForGridRow()
        {
            if (gridview.Rows.Count > 0 && gridview.SelectedRows.Count > 0)
            {
                btnLog.Enabled = true;
                //if (GlobalData.UserAccount.role != Roles.Super)
                //    btnUpdate.Enabled = false;
                //else
                    btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnLog.Enabled = false;
            }
        }

        private void arrangeInputPanelsAndResizeForm()
        {
            int X = INPUT_CONTROL_MARGIN;
            int Y;
            int calculatedInputPanelHeight = 0;
            int formWidth = X;
            bool isColumnHaveContent;
            foreach (Panel column in InputColumns)
            {
                Y = 0;
                isColumnHaveContent = false;
                foreach(Control control in column.Controls)
                {
                    if (control.Visible)
                    {
                        if (control.GetType() == typeof(InputTextbox)
                            || control.GetType() == typeof(InputDropdownlist)
                            || control.GetType() == typeof(InputEnumDropdownlist) 
                            || control.GetType() == typeof(InputDateTimePicker))
                        {
                            control.Width = INPUT_CONTROL_WIDTH;
                            control.Location = new Point(X, Y);
                            Y += control.Height + INPUT_CONTROL_VERTICAL_PADDING;
                            isColumnHaveContent = true;
                        }
                    }
                    else
                    {
                        control.Location = new Point(-1 * control.Width, 0); //place control outside the form
                    }
                }
                Y += 3*INPUT_CONTROL_MARGIN;
                if (Y > calculatedInputPanelHeight)
                    calculatedInputPanelHeight = Y;

                if (isColumnHaveContent)
                    formWidth += column.Width + INPUT_CONTROL_MARGIN;
            }

            pnlInputContainer.Height = calculatedInputPanelHeight + pnlActionButtonsContainer.Height;
            this.Width = formWidth;
        }

        protected virtual void populateGridViewDataSource(bool reloadFromDB)
        {
            if (isValidToPopulateGridViewDataSource())
            {
                DataView dvw;
                if (reloadFromDB)
                    dvw = loadGridviewDataSource();
                else
                    dvw = (DataView)gridview.DataSource;

                dvw.RowFilter = Tools.compileQuickSearchFilter(txtQuickSearch.Text.Trim(), FieldnamesForQuickSearch.ToArray());
                setGridviewDataSource(dvw);
            }

            if (gridview.Rows.Count == 0) btnUpdate.Enabled = false;
        }

        private void setGridviewDataSource(DataView dvw)
        {
            //detach event handlers to avoid triggering events
            gridview.CellContentClick -= new System.Windows.Forms.DataGridViewCellEventHandler(gridview_CellContentClick);
            gridview.SelectionChanged -= new System.EventHandler(gridview_SelectionChanged);

            //Tools.populateDataGridView(gridview, dvw);
            Tools.setGridviewDataSource(gridview, true, true, dvw);

            //reattach event handlers
            gridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(gridview_CellContentClick);
            gridview.SelectionChanged += new System.EventHandler(gridview_SelectionChanged);
        }

        #endregion PRIVATE METHODS
        /*******************************************************************************************************/
        #region EVENT HANDLERS

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            setInputPanelVisibility(true);
            clearInputFields();
            Mode = FormMode.Search;
            DefaultInputToFocus.focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            setInputPanelVisibility(true);
            Mode = FormMode.New;
            clearInputFields();
            DefaultInputToFocus.focus();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            setInputPanelVisibility(true);
            Mode = FormMode.Update;
            populateInputFieldsForUpdate();
            DefaultInputToFocus.focus();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Tools.displayForm(new Logs.Main_Form(selectedRowID()));
            DefaultInputToFocus.focus();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case FormMode.Search:
                    break;
                case FormMode.New:
                    if (!isInputFieldsValid())
                        return;
                    add();
                    if(!DoNotClearInputAfterSubmission) clearInputFields();
                    break;
                case FormMode.Update:
                    if (!isInputFieldsValid())
                        return;
                    update();
                    clearInputFields();
                    break;
            }

            populateGridViewDataSource(true);
            if (Mode == FormMode.Update)
            {
                btnUpdate.PerformClick();
            }
            DefaultInputToFocus.focus();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update)
                btnUpdate.PerformClick();
            else
                clearInputFields();

            DefaultInputToFocus.focus();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        protected void chkIncludeInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update)
                btnSearch.PerformClick();

            populateGridViewDataSource(true);
        }

        protected void txtQuickSearch_TextChanged(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update)
            {
                btnSearch.PerformClick();
                txtQuickSearch.Focus();
            }

            populateGridViewDataSource(false);
        }

        protected void lnkClearQuickSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtQuickSearch.Text = "";
        }

        private void gridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            updateModeButtonsAvailabilityForGridRow();
        }

        protected void gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridview.SelectionMode == DataGridViewSelectionMode.CellSelect)
            {
                Clipboard.SetText(Util.getClickedCellValue(sender, e).ToString());
                gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridview.Rows[e.RowIndex].Selected = true;
                return;
            }

            if (e.RowIndex == -1)
                updateModeButtonsAvailabilityForGridRow(); 
            
            if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_active.Name))
            {
                DataGridViewRow row = gridview.Rows[e.RowIndex];
                updateActiveStatus((Guid)row.Cells[col_grid_id.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                clearInputFields();
                populateGridViewDataSource(true);
                if (Mode == FormMode.Update) btnUpdate.PerformClick();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_default.Name))
            {
                DataGridViewRow row = gridview.Rows[e.RowIndex];
                updateDefaultRow((Guid)row.Cells[col_grid_id.Name].Value);
                clearInputFields();
                populateGridViewDataSource(true);
                if (Mode == FormMode.Update) btnUpdate.PerformClick();
            }
            else if (Tools.isCorrectColumn(sender, e, typeof(DataGridViewCheckBoxColumn), col_grid_checkbox1.Name))
            {
                DataGridViewRow row = gridview.Rows[e.RowIndex];
                updateCheckboxColumn((Guid)row.Cells[col_grid_id.Name].Value, !(bool)((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value);
                clearInputFields();
                populateGridViewDataSource(true);
                if (Mode == FormMode.Update) btnUpdate.PerformClick();
            }
        }

        protected void gridview_SelectionChanged(object sender, EventArgs e)
        {
            if (Mode == FormMode.Update)
            {
                populateInputFieldsForUpdate();
                DefaultInputToFocus.focus();
            }
        }

        private void btnAction1_Click(object sender, EventArgs e)
        {
            executeAction1();
        }

        private void btnAction2_Click(object sender, EventArgs e)
        {
            executeAction2();
        }

        private void btnAction3_Click(object sender, EventArgs e)
        {
            executeAction3();
        }

        private void btnAction4_Click(object sender, EventArgs e)
        {
            executeAction4();
        }

        private void btnAction5_Click(object sender, EventArgs e)
        {
            executeAction5();
        }

        private void btnAction6_Click(object sender, EventArgs e)
        {
            executeAction6();
        }

        private void gridview_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                    gridview.Rows[e.RowIndex].Selected = true;
            }
        }

        public void addStatusContextMenu<T>(DataGridViewColumn column)
        {
            column.ContextMenuStrip = new ContextMenuStrip();
            foreach (T status in Tools.GetEnumItems<T>())
                column.ContextMenuStrip.Items.Add(new ToolStripMenuItem(Tools.GetEnumDescription((Enum)(object)status), null, changeStatus_Click));
        }

        private void gridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(_startingMode == FormMode.Browse)
            {
                browseItemSelection = (Guid)gridview.Rows[e.RowIndex].Cells[col_grid_id.Name].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(btnLog.Enabled)
            {
                btnLog.PerformClick();
            }
        }

        private void btnShowInput_Click(object sender, EventArgs e)
        {
            setInputPanelVisibility(true);
        }

        private void btnHideInput_Click(object sender, EventArgs e)
        {
            setInputPanelVisibility(false);
        }

        private void setInputPanelVisibility(bool value)
        {
            pnlInputContainer.Visible = value;
            btnShowInput.Visible = !value;
            btnHideInput.Visible = value;
        }

        private void btnShowUserHiddenControls_Click(object sender, EventArgs e)
        {
            showUserHiddenControls();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.C) && gridview.Focused)
            {
                gridview.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion EVENT HANDLERS
        /*******************************************************************************************************/

    }
}
