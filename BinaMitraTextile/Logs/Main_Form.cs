using System;
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

        public Main_Form(Guid associatedID)
        {
            InitializeComponent();

            _id = associatedID;

            setupControls();
            populatePageData();
        }

        private void setupControls()
        {
            grid.AutoGenerateColumns = false;
        }

        private void populatePageData()
        {
            DataView dvw = ActivityLog.getAll(_id).DefaultView;
            dvw.RowFilter = Tools.compileQuickSearchFilter(itxt_QuickSearch.ValueText, FieldnamesForQuickSearch.ToArray());

            grid.DataSource = dvw;
            grid.ClearSelection();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            grid.ClearSelection();
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
