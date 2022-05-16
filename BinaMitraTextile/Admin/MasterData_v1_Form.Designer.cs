namespace BinaMitraTextile
{
    partial class MasterData_v1_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlInputContainer = new System.Windows.Forms.Panel();
            this.gbInputFields = new System.Windows.Forms.GroupBox();
            this.pnlActionButtonsContainer = new System.Windows.Forms.Panel();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.scInputMain = new System.Windows.Forms.SplitContainer();
            this.scInputLeft = new System.Windows.Forms.SplitContainer();
            this.scInputRight = new System.Windows.Forms.SplitContainer();
            this.chkIncludeInactive = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridview = new System.Windows.Forms.DataGridView();
            this.col_grid_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_default = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_statusenumid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_grid_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_grid_checkbox1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlModeButtons = new System.Windows.Forms.Panel();
            this.btnAction6 = new System.Windows.Forms.Button();
            this.btnAction5 = new System.Windows.Forms.Button();
            this.btnAction4 = new System.Windows.Forms.Button();
            this.btnAction3 = new System.Windows.Forms.Button();
            this.btnAction2 = new System.Windows.Forms.Button();
            this.btnAction1 = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.pnlGridviewContainer = new System.Windows.Forms.Panel();
            this.pnlGridview = new System.Windows.Forms.Panel();
            this.pnlQuickFilters = new System.Windows.Forms.Panel();
            this.btnShowUserHiddenControls = new System.Windows.Forms.Button();
            this.btnShowInput = new System.Windows.Forms.Button();
            this.btnHideInput = new System.Windows.Forms.Button();
            this.lnkClearQuickSearch = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.pnlInputContainer.SuspendLayout();
            this.gbInputFields.SuspendLayout();
            this.pnlActionButtonsContainer.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputMain)).BeginInit();
            this.scInputMain.Panel1.SuspendLayout();
            this.scInputMain.Panel2.SuspendLayout();
            this.scInputMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).BeginInit();
            this.scInputLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).BeginInit();
            this.scInputRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.pnlModeButtons.SuspendLayout();
            this.pnlGridviewContainer.SuspendLayout();
            this.pnlGridview.SuspendLayout();
            this.pnlQuickFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInputContainer
            // 
            this.pnlInputContainer.Controls.Add(this.gbInputFields);
            this.pnlInputContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputContainer.Location = new System.Drawing.Point(0, 34);
            this.pnlInputContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInputContainer.Name = "pnlInputContainer";
            this.pnlInputContainer.Size = new System.Drawing.Size(1333, 378);
            this.pnlInputContainer.TabIndex = 1;
            // 
            // gbInputFields
            // 
            this.gbInputFields.Controls.Add(this.pnlActionButtonsContainer);
            this.gbInputFields.Controls.Add(this.scInputMain);
            this.gbInputFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInputFields.Location = new System.Drawing.Point(0, 0);
            this.gbInputFields.Margin = new System.Windows.Forms.Padding(4);
            this.gbInputFields.Name = "gbInputFields";
            this.gbInputFields.Padding = new System.Windows.Forms.Padding(4);
            this.gbInputFields.Size = new System.Drawing.Size(1333, 378);
            this.gbInputFields.TabIndex = 0;
            this.gbInputFields.TabStop = false;
            // 
            // pnlActionButtonsContainer
            // 
            this.pnlActionButtonsContainer.Controls.Add(this.pnlActionButtons);
            this.pnlActionButtonsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionButtonsContainer.Location = new System.Drawing.Point(4, 342);
            this.pnlActionButtonsContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActionButtonsContainer.Name = "pnlActionButtonsContainer";
            this.pnlActionButtonsContainer.Size = new System.Drawing.Size(1325, 32);
            this.pnlActionButtonsContainer.TabIndex = 2;
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlActionButtons.Controls.Add(this.btnSubmit);
            this.pnlActionButtons.Controls.Add(this.btnCancel);
            this.pnlActionButtons.Controls.Add(this.btnReset);
            this.pnlActionButtons.Location = new System.Drawing.Point(401, 4);
            this.pnlActionButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(505, 28);
            this.pnlActionButtons.TabIndex = 9;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(9, 2);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(155, 27);
            this.btnSubmit.TabIndex = 93;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(343, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 27);
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(176, 2);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 27);
            this.btnReset.TabIndex = 94;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // scInputMain
            // 
            this.scInputMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInputMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scInputMain.IsSplitterFixed = true;
            this.scInputMain.Location = new System.Drawing.Point(4, 19);
            this.scInputMain.Margin = new System.Windows.Forms.Padding(0);
            this.scInputMain.MinimumSize = new System.Drawing.Size(1067, 0);
            this.scInputMain.Name = "scInputMain";
            // 
            // scInputMain.Panel1
            // 
            this.scInputMain.Panel1.Controls.Add(this.scInputLeft);
            // 
            // scInputMain.Panel2
            // 
            this.scInputMain.Panel2.Controls.Add(this.scInputRight);
            this.scInputMain.Size = new System.Drawing.Size(1325, 355);
            this.scInputMain.SplitterDistance = 496;
            this.scInputMain.SplitterWidth = 5;
            this.scInputMain.TabIndex = 0;
            this.scInputMain.TabStop = false;
            // 
            // scInputLeft
            // 
            this.scInputLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInputLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scInputLeft.IsSplitterFixed = true;
            this.scInputLeft.Location = new System.Drawing.Point(0, 0);
            this.scInputLeft.Margin = new System.Windows.Forms.Padding(0);
            this.scInputLeft.MinimumSize = new System.Drawing.Size(533, 0);
            this.scInputLeft.Name = "scInputLeft";
            this.scInputLeft.Size = new System.Drawing.Size(533, 355);
            this.scInputLeft.SplitterDistance = 248;
            this.scInputLeft.SplitterWidth = 5;
            this.scInputLeft.TabIndex = 0;
            this.scInputLeft.TabStop = false;
            // 
            // scInputRight
            // 
            this.scInputRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scInputRight.Location = new System.Drawing.Point(0, 0);
            this.scInputRight.Margin = new System.Windows.Forms.Padding(0);
            this.scInputRight.MinimumSize = new System.Drawing.Size(533, 0);
            this.scInputRight.Name = "scInputRight";
            this.scInputRight.Size = new System.Drawing.Size(824, 355);
            this.scInputRight.SplitterDistance = 401;
            this.scInputRight.SplitterWidth = 5;
            this.scInputRight.TabIndex = 1;
            this.scInputRight.TabStop = false;
            // 
            // chkIncludeInactive
            // 
            this.chkIncludeInactive.AutoSize = true;
            this.chkIncludeInactive.Location = new System.Drawing.Point(277, 7);
            this.chkIncludeInactive.Margin = new System.Windows.Forms.Padding(4);
            this.chkIncludeInactive.Name = "chkIncludeInactive";
            this.chkIncludeInactive.Size = new System.Drawing.Size(106, 20);
            this.chkIncludeInactive.TabIndex = 8;
            this.chkIncludeInactive.TabStop = false;
            this.chkIncludeInactive.Text = "show inactive";
            this.chkIncludeInactive.UseVisualStyleBackColor = true;
            this.chkIncludeInactive.CheckedChanged += new System.EventHandler(this.chkIncludeInactive_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(204, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 98;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(104, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 97;
            this.btnAdd.Text = "ADD NEW";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(4, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 96;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridview
            // 
            this.gridview.AllowUserToAddRows = false;
            this.gridview.AllowUserToDeleteRows = false;
            this.gridview.AllowUserToResizeRows = false;
            this.gridview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_grid_id,
            this.col_grid_default,
            this.col_grid_statusenumid,
            this.col_grid_statusname,
            this.col_grid_active,
            this.col_grid_name,
            this.col_grid_checkbox1});
            this.gridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridview.Location = new System.Drawing.Point(0, 0);
            this.gridview.Margin = new System.Windows.Forms.Padding(4);
            this.gridview.Name = "gridview";
            this.gridview.RowHeadersVisible = false;
            this.gridview.RowHeadersWidth = 51;
            this.gridview.Size = new System.Drawing.Size(1333, 244);
            this.gridview.TabIndex = 8;
            this.gridview.TabStop = false;
            this.gridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview_CellContentClick);
            this.gridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview_CellDoubleClick);
            this.gridview.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridview_CellMouseDown);
            this.gridview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridview_DataBindingComplete);
            this.gridview.SelectionChanged += new System.EventHandler(this.gridview_SelectionChanged);
            // 
            // col_grid_id
            // 
            this.col_grid_id.HeaderText = "ID";
            this.col_grid_id.MinimumWidth = 6;
            this.col_grid_id.Name = "col_grid_id";
            this.col_grid_id.ReadOnly = true;
            this.col_grid_id.Visible = false;
            this.col_grid_id.Width = 125;
            // 
            // col_grid_default
            // 
            this.col_grid_default.DataPropertyName = "default_row";
            this.col_grid_default.HeaderText = "Default";
            this.col_grid_default.MinimumWidth = 6;
            this.col_grid_default.Name = "col_grid_default";
            this.col_grid_default.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_grid_default.Width = 40;
            // 
            // col_grid_statusenumid
            // 
            this.col_grid_statusenumid.DataPropertyName = "status_enum_id";
            this.col_grid_statusenumid.HeaderText = "Status ID";
            this.col_grid_statusenumid.MinimumWidth = 6;
            this.col_grid_statusenumid.Name = "col_grid_statusenumid";
            this.col_grid_statusenumid.Visible = false;
            this.col_grid_statusenumid.Width = 125;
            // 
            // col_grid_statusname
            // 
            this.col_grid_statusname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_grid_statusname.DataPropertyName = "status_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_grid_statusname.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_grid_statusname.HeaderText = "Status";
            this.col_grid_statusname.MinimumWidth = 6;
            this.col_grid_statusname.Name = "col_grid_statusname";
            this.col_grid_statusname.Visible = false;
            // 
            // col_grid_active
            // 
            this.col_grid_active.DataPropertyName = "active";
            this.col_grid_active.HeaderText = "Active";
            this.col_grid_active.MinimumWidth = 6;
            this.col_grid_active.Name = "col_grid_active";
            this.col_grid_active.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_grid_active.Width = 40;
            // 
            // col_grid_name
            // 
            this.col_grid_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_grid_name.HeaderText = "Name";
            this.col_grid_name.MinimumWidth = 6;
            this.col_grid_name.Name = "col_grid_name";
            this.col_grid_name.ReadOnly = true;
            // 
            // col_grid_checkbox1
            // 
            this.col_grid_checkbox1.HeaderText = "";
            this.col_grid_checkbox1.MinimumWidth = 6;
            this.col_grid_checkbox1.Name = "col_grid_checkbox1";
            this.col_grid_checkbox1.Visible = false;
            this.col_grid_checkbox1.Width = 125;
            // 
            // pnlModeButtons
            // 
            this.pnlModeButtons.Controls.Add(this.btnAction6);
            this.pnlModeButtons.Controls.Add(this.btnAction5);
            this.pnlModeButtons.Controls.Add(this.btnAction4);
            this.pnlModeButtons.Controls.Add(this.btnAction3);
            this.pnlModeButtons.Controls.Add(this.btnAction2);
            this.pnlModeButtons.Controls.Add(this.btnAction1);
            this.pnlModeButtons.Controls.Add(this.btnLog);
            this.pnlModeButtons.Controls.Add(this.btnUpdate);
            this.pnlModeButtons.Controls.Add(this.btnAdd);
            this.pnlModeButtons.Controls.Add(this.btnSearch);
            this.pnlModeButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModeButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlModeButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlModeButtons.Name = "pnlModeButtons";
            this.pnlModeButtons.Size = new System.Drawing.Size(1333, 34);
            this.pnlModeButtons.TabIndex = 0;
            this.pnlModeButtons.TabStop = true;
            // 
            // btnAction6
            // 
            this.btnAction6.Enabled = false;
            this.btnAction6.Location = new System.Drawing.Point(928, 4);
            this.btnAction6.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction6.Name = "btnAction6";
            this.btnAction6.Size = new System.Drawing.Size(100, 28);
            this.btnAction6.TabIndex = 105;
            this.btnAction6.Text = "btnAction6";
            this.btnAction6.UseVisualStyleBackColor = true;
            this.btnAction6.Click += new System.EventHandler(this.btnAction6_Click);
            // 
            // btnAction5
            // 
            this.btnAction5.Enabled = false;
            this.btnAction5.Location = new System.Drawing.Point(820, 4);
            this.btnAction5.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction5.Name = "btnAction5";
            this.btnAction5.Size = new System.Drawing.Size(100, 28);
            this.btnAction5.TabIndex = 104;
            this.btnAction5.Text = "btnAction5";
            this.btnAction5.UseVisualStyleBackColor = true;
            this.btnAction5.Click += new System.EventHandler(this.btnAction5_Click);
            // 
            // btnAction4
            // 
            this.btnAction4.Enabled = false;
            this.btnAction4.Location = new System.Drawing.Point(712, 4);
            this.btnAction4.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction4.Name = "btnAction4";
            this.btnAction4.Size = new System.Drawing.Size(100, 28);
            this.btnAction4.TabIndex = 103;
            this.btnAction4.Text = "btnAction4";
            this.btnAction4.UseVisualStyleBackColor = true;
            this.btnAction4.Click += new System.EventHandler(this.btnAction4_Click);
            // 
            // btnAction3
            // 
            this.btnAction3.Enabled = false;
            this.btnAction3.Location = new System.Drawing.Point(604, 4);
            this.btnAction3.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction3.Name = "btnAction3";
            this.btnAction3.Size = new System.Drawing.Size(100, 28);
            this.btnAction3.TabIndex = 102;
            this.btnAction3.Text = "btnAction3";
            this.btnAction3.UseVisualStyleBackColor = true;
            this.btnAction3.Click += new System.EventHandler(this.btnAction3_Click);
            // 
            // btnAction2
            // 
            this.btnAction2.Enabled = false;
            this.btnAction2.Location = new System.Drawing.Point(504, 4);
            this.btnAction2.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction2.Name = "btnAction2";
            this.btnAction2.Size = new System.Drawing.Size(100, 28);
            this.btnAction2.TabIndex = 101;
            this.btnAction2.Text = "btnAction2";
            this.btnAction2.UseVisualStyleBackColor = true;
            this.btnAction2.Click += new System.EventHandler(this.btnAction2_Click);
            // 
            // btnAction1
            // 
            this.btnAction1.Enabled = false;
            this.btnAction1.Location = new System.Drawing.Point(404, 4);
            this.btnAction1.Margin = new System.Windows.Forms.Padding(4);
            this.btnAction1.Name = "btnAction1";
            this.btnAction1.Size = new System.Drawing.Size(100, 28);
            this.btnAction1.TabIndex = 100;
            this.btnAction1.Text = "btnAction1";
            this.btnAction1.UseVisualStyleBackColor = true;
            this.btnAction1.Click += new System.EventHandler(this.btnAction1_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(304, 4);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(100, 28);
            this.btnLog.TabIndex = 99;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // pnlGridviewContainer
            // 
            this.pnlGridviewContainer.Controls.Add(this.pnlGridview);
            this.pnlGridviewContainer.Controls.Add(this.pnlQuickFilters);
            this.pnlGridviewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridviewContainer.Location = new System.Drawing.Point(0, 412);
            this.pnlGridviewContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGridviewContainer.Name = "pnlGridviewContainer";
            this.pnlGridviewContainer.Size = new System.Drawing.Size(1333, 278);
            this.pnlGridviewContainer.TabIndex = 0;
            // 
            // pnlGridview
            // 
            this.pnlGridview.Controls.Add(this.gridview);
            this.pnlGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridview.Location = new System.Drawing.Point(0, 34);
            this.pnlGridview.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGridview.Name = "pnlGridview";
            this.pnlGridview.Size = new System.Drawing.Size(1333, 244);
            this.pnlGridview.TabIndex = 12;
            // 
            // pnlQuickFilters
            // 
            this.pnlQuickFilters.Controls.Add(this.btnShowUserHiddenControls);
            this.pnlQuickFilters.Controls.Add(this.btnShowInput);
            this.pnlQuickFilters.Controls.Add(this.btnHideInput);
            this.pnlQuickFilters.Controls.Add(this.lnkClearQuickSearch);
            this.pnlQuickFilters.Controls.Add(this.chkIncludeInactive);
            this.pnlQuickFilters.Controls.Add(this.label1);
            this.pnlQuickFilters.Controls.Add(this.txtQuickSearch);
            this.pnlQuickFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlQuickFilters.Margin = new System.Windows.Forms.Padding(4);
            this.pnlQuickFilters.Name = "pnlQuickFilters";
            this.pnlQuickFilters.Size = new System.Drawing.Size(1333, 34);
            this.pnlQuickFilters.TabIndex = 0;
            // 
            // btnShowUserHiddenControls
            // 
            this.btnShowUserHiddenControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowUserHiddenControls.Location = new System.Drawing.Point(1213, 5);
            this.btnShowUserHiddenControls.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowUserHiddenControls.Name = "btnShowUserHiddenControls";
            this.btnShowUserHiddenControls.Size = new System.Drawing.Size(31, 27);
            this.btnShowUserHiddenControls.TabIndex = 98;
            this.btnShowUserHiddenControls.Text = "-";
            this.btnShowUserHiddenControls.UseVisualStyleBackColor = true;
            this.btnShowUserHiddenControls.Visible = false;
            this.btnShowUserHiddenControls.Click += new System.EventHandler(this.btnShowUserHiddenControls_Click);
            // 
            // btnShowInput
            // 
            this.btnShowInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowInput.Location = new System.Drawing.Point(1247, 5);
            this.btnShowInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowInput.Name = "btnShowInput";
            this.btnShowInput.Size = new System.Drawing.Size(83, 27);
            this.btnShowInput.TabIndex = 97;
            this.btnShowInput.Text = "SHOW";
            this.btnShowInput.UseVisualStyleBackColor = true;
            this.btnShowInput.Visible = false;
            this.btnShowInput.Click += new System.EventHandler(this.btnShowInput_Click);
            // 
            // btnHideInput
            // 
            this.btnHideInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideInput.Location = new System.Drawing.Point(1247, 5);
            this.btnHideInput.Margin = new System.Windows.Forms.Padding(4);
            this.btnHideInput.Name = "btnHideInput";
            this.btnHideInput.Size = new System.Drawing.Size(83, 27);
            this.btnHideInput.TabIndex = 96;
            this.btnHideInput.Text = "HIDE";
            this.btnHideInput.UseVisualStyleBackColor = true;
            this.btnHideInput.Click += new System.EventHandler(this.btnHideInput_Click);
            // 
            // lnkClearQuickSearch
            // 
            this.lnkClearQuickSearch.ActiveLinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.AutoSize = true;
            this.lnkClearQuickSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClearQuickSearch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkClearQuickSearch.LinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.Location = new System.Drawing.Point(252, 10);
            this.lnkClearQuickSearch.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lnkClearQuickSearch.Name = "lnkClearQuickSearch";
            this.lnkClearQuickSearch.Size = new System.Drawing.Size(15, 13);
            this.lnkClearQuickSearch.TabIndex = 11;
            this.lnkClearQuickSearch.TabStop = true;
            this.lnkClearQuickSearch.Text = "X";
            this.lnkClearQuickSearch.VisitedLinkColor = System.Drawing.Color.DarkOrange;
            this.lnkClearQuickSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearQuickSearch_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quick Search:";
            // 
            // txtQuickSearch
            // 
            this.txtQuickSearch.Location = new System.Drawing.Point(104, 5);
            this.txtQuickSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(145, 22);
            this.txtQuickSearch.TabIndex = 0;
            this.txtQuickSearch.TextChanged += new System.EventHandler(this.txtQuickSearch_TextChanged);
            // 
            // MasterData_v1_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1333, 690);
            this.Controls.Add(this.pnlGridviewContainer);
            this.Controls.Add(this.pnlInputContainer);
            this.Controls.Add(this.pnlModeButtons);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(527, 728);
            this.Name = "MasterData_v1_Form";
            this.Text = "MasterData_v1_Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlInputContainer.ResumeLayout(false);
            this.gbInputFields.ResumeLayout(false);
            this.pnlActionButtonsContainer.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.scInputMain.Panel1.ResumeLayout(false);
            this.scInputMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputMain)).EndInit();
            this.scInputMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputLeft)).EndInit();
            this.scInputLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scInputRight)).EndInit();
            this.scInputRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.pnlModeButtons.ResumeLayout(false);
            this.pnlGridviewContainer.ResumeLayout(false);
            this.pnlGridview.ResumeLayout(false);
            this.pnlQuickFilters.ResumeLayout(false);
            this.pnlQuickFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlInputContainer;
        public System.Windows.Forms.GroupBox gbInputFields;
        public System.Windows.Forms.Panel pnlActionButtonsContainer;
        public System.Windows.Forms.Panel pnlActionButtons;
        public System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.SplitContainer scInputMain;
        public System.Windows.Forms.SplitContainer scInputLeft;
        public System.Windows.Forms.CheckBox chkIncludeInactive;
        public System.Windows.Forms.SplitContainer scInputRight;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Panel pnlModeButtons;
        public System.Windows.Forms.Button btnLog;
        public System.Windows.Forms.Panel pnlGridviewContainer;
        public System.Windows.Forms.TextBox txtQuickSearch;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel pnlGridview;
        public System.Windows.Forms.Panel pnlQuickFilters;
        public System.Windows.Forms.LinkLabel lnkClearQuickSearch;
        public System.Windows.Forms.DataGridView gridview;
        public System.Windows.Forms.Button btnAction1;
        public System.Windows.Forms.Button btnAction2;
        public System.Windows.Forms.Button btnAction3;
        public System.Windows.Forms.Button btnAction4;
        public System.Windows.Forms.DataGridViewTextBoxColumn col_grid_id;
        public System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_default;
        public System.Windows.Forms.DataGridViewTextBoxColumn col_grid_statusenumid;
        public System.Windows.Forms.DataGridViewTextBoxColumn col_grid_statusname;
        public System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_active;
        public System.Windows.Forms.DataGridViewTextBoxColumn col_grid_name;
        public System.Windows.Forms.DataGridViewCheckBoxColumn col_grid_checkbox1;
        public System.Windows.Forms.Button btnHideInput;
        public System.Windows.Forms.Button btnShowInput;
        public System.Windows.Forms.Button btnShowUserHiddenControls;
        public System.Windows.Forms.Button btnAction5;
        public System.Windows.Forms.Button btnAction6;
    }
}