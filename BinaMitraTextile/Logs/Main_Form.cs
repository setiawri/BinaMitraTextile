﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaMitraTextile.Logs
{
    public partial class Main_Form : Form
    {
        private Guid _id;
        private List<string> FieldnamesForQuickSearch = new List<string>() { ActivityLog.COL_DB_Description };

        public Main_Form(Guid? associatedID)
        {
            InitializeComponent();

            if (_id == null)
                this.Close();
            else
                _id = (Guid)associatedID;
        }

        private void setupControls()
        {
            Settings.setGeneralSettings(this);

            grid.AutoGenerateColumns = false;
            col_grid_Timestamp.DataPropertyName = ActivityLog.COL_DB_Timestamp;
            col_grid_Username.DataPropertyName = ActivityLog.COL_Username;
            col_grid_Description.DataPropertyName = ActivityLog.COL_DB_Description;
            LIBUtil.Util.setGridviewColumnWordwrap(col_grid_Description, null);
        }

        private void populatePageData()
        {
            DataView dvw = ActivityLog.getAll(_id).DefaultView;
            dvw.RowFilter = Tools.compileQuickSearchFilter(itxt_QuickSearch.ValueText, FieldnamesForQuickSearch.ToArray());

            grid.DataSource = dvw;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            setupControls();
            populatePageData();

            txtDescription.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBUtil.sanitize(txtDescription);
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                Tools.inputError<TextBox>(txtDescription, "Please provide description");
            }
            else
            {
                ActivityLog.submit(_id, txtDescription.Text);
                populatePageData();
                txtDescription.Text = "";
                txtDescription.Focus();
            }
        }

        private void itxt_QuickSearch_onTextChanged(object sender, EventArgs e)
        {
            populatePageData();
        }
    }
}
