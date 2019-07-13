using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Reflection;

namespace BinaMitraTextile
{
    public class Tools
    {
        /*******************************************************************************************************/
        #region NULL MANIPULATORS

        public static T wrapDBNullValue<T>(object value)
        {
            object val = wrapNullable(value);
            if (val == null || val == DBNull.Value)
            {
                if (typeof(T) == typeof(Guid?))
                {
                    object obj = null;
                    return (T)obj;
                }
                else
                    return default(T);
            }
            else if (typeof(T) == typeof(Guid?))
                return (T)val;
            else if (Nullable.GetUnderlyingType(typeof(T)) != null)
                return (T)Convert.ChangeType(val, Nullable.GetUnderlyingType(typeof(T)));
            else
                return (T)Convert.ChangeType(val, typeof(T));
        }

        public static object wrapNullable(object value)
        {
            if (value != null && value.GetType() == typeof(string) && string.IsNullOrEmpty((string)value))
                return DBNull.Value;
            else
                return value ?? DBNull.Value;
        }

        #endregion NULL MANIPULATORS
        /*******************************************************************************************************/
        #region NUMBER MANIPULATORS

        public static bool isNumeric(string str)
        {
            decimal output;
            return Decimal.TryParse(str, out output);
        }

        public static bool isHexNumber(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static string getHex(int number, int length)
        {
            return number.ToString("X" + length);
        }

        public static int getInt(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        public static decimal zeroNonNumericString(object obj)
        {
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch { return 0; }
        }

        #endregion NUMBER MANIPULATORS
        /*******************************************************************************************************/
        #region BARCODE MANIPULATORS

        public static string IncrementBarcode(string hexNumber, int increment, int length)
        {
            return Regex.Replace(hexNumber, "[A-F|0-9]{" + length + "}", m => (Int32.Parse(m.Value, NumberStyles.HexNumber) + increment).ToString("X" + length));
        }

        #endregion BARCODE MANIPULATORS
        /*******************************************************************************************************/
        #region STRING MANIPULATORS

        public static string getYEsOrNo(bool value)
        {
            if (value)
                return "YES";
            else
                return "NO";

        }

        public static string trimInput(string Input)
        {
            return Input.Trim();
        }

        public static string append(string Text, string NewText, string Delimiter)
        {
            if (string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(NewText))
                return NewText.Trim();
            else if (string.IsNullOrEmpty(NewText))
                return Text.Trim();
            else
            {
                if (!string.IsNullOrEmpty(Text)) Text += " " + Delimiter + " ";
                return Text += NewText.Trim();
            }
        }

        public static string applyNewLines(string str)
        {
            if (str == null) return null;
            return str.Replace("\r\n", Environment.NewLine).Replace("\r", Environment.NewLine);
        }

        #endregion STRING MANIPULATORS
        /*******************************************************************************************************/
        #region DATATABLE METHODS

        public static DataRow getFirstRow(DataTable datatable)
        {
            if (datatable.Rows.Count == 0)
                return null;
            else
                return datatable.Rows[0];
        }
        
        public static DataTable setDataTablePrimaryKey(DataTable dt, string primaryKeyColumnName)
        {
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = dt.Columns[primaryKeyColumnName];
            dt.PrimaryKey = keyColumns;
            return dt;
        }

        public static void addColumn<T>(DataTable dt, string columnName, object defaultValue)
        {
            DataColumn dc = new DataColumn(columnName, typeof(T));

            if (typeof(T) == typeof(bool))
                dc.DefaultValue = Convert.ToBoolean(defaultValue);
            else if (typeof(T) == typeof(int))
                dc.DefaultValue = Convert.ToInt32(defaultValue);
            else if (typeof(T) == typeof(decimal))
                dc.DefaultValue = Convert.ToDecimal(defaultValue);

            dt.Columns.Add(dc);
        }

        public static DataRow findRow(DataTable dt, string primaryKeyColumnName, Guid keyValue)
        {
            return setDataTablePrimaryKey(dt, primaryKeyColumnName).Rows.Find(keyValue);
        }

        public static DataGridViewRow findRow(DataGridView grid, string columnName, Guid value)
        {
            return grid.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[columnName].Value.Equals(value))
                .First();
        }

        public static DataTable copyTable(DataTable dt)
        {
            return copyTableRows(dt, 0, dt.Rows.Count);
        }

        public static DataTable copyTableRows(DataTable dt, int startIdx, int rowCount)
        {
            DataTable result = dt.Clone();
            for (int i = startIdx; i < startIdx+rowCount; i++)
            {
                result.Rows.Add(dt.Rows[i].ItemArray);
            }
            return result;
        }

        public static decimal getSum(DataTable dt, string column, string filter)
        {
            if (dt == null) return 0;

            object sum = dt.Compute(String.Format("SUM({0})", column), filter);
            if (sum != DBNull.Value)
                return Convert.ToDecimal(sum.ToString());
            else
                return 0;
        }

        public static decimal getCount(DataTable dt, string column, string filter)
        {
            return Convert.ToDecimal(dt.Compute(String.Format("COUNT({0})", column), filter).ToString());
        }

        public static string compileQuickSearchFilter(string keyword, string[] fieldNames)
        {
            string filter = "";
            foreach (string word in keyword.Split())
            {
                if (!string.IsNullOrEmpty(word.Trim()))
                {
                    foreach (string fieldname in fieldNames)
                        filter = Tools.append(filter, string.Format("CONVERT({0},System.String) LIKE '%{1}%'", fieldname, word), "OR");
                }
            }
            return filter;
        }

        public static DataTable sortData(DataTable datatable, string column1Name, SortOrder? column1Direction, string column2Name, SortOrder? column2Direction)
        {
            DataView dvw = datatable.DefaultView;
            dvw.Sort = compileSortPhrase(column1Name, column1Direction, column2Name, column2Direction);
            return dvw.ToTable();
        }

        private static string compileSortPhrase(string column1Name, SortOrder? column1Direction, string column2Name, SortOrder? column2Direction)
        {
            string str = "";
            if (!string.IsNullOrEmpty(column1Name))
                str = Tools.append(str, string.Format("{0} {1}", column1Name, getDirectionString(column1Direction)), ",");
            if (!string.IsNullOrEmpty(column2Name))
                str = Tools.append(str, string.Format("{0} {1}", column2Name, getDirectionString(column2Direction)), ",");
            return str;
        }

        private static string getDirectionString(SortOrder? direction)
        {
            if (direction == SortOrder.Descending)
                return "DESC ";
            else
                return "ASC";
        }

        #endregion DATATABLE METHODS
        /*******************************************************************************************************/
        #region ENUM METHODS

        public static T parseEnum<T>(object value)
        {
            if (value == null)
                return default(T);

            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch
            {
                return GetEnumFromDescription<T>(value.ToString());
            }
        }

        public static T GetEnumFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }

        public static DataTable parseEnum<T>(DataTable dataTable, string targetColumnName, string enumIDColumn)
        {
            if(!dataTable.Columns.Contains(targetColumnName))
                Tools.addColumn<string>(dataTable, targetColumnName, "");

            foreach (DataRow dr in dataTable.Rows)
                if (dr[enumIDColumn] != DBNull.Value)
                    dr[targetColumnName] = Tools.GetEnumDescription((Enum)(object)Tools.parseEnum<T>(dr[enumIDColumn]));

            return dataTable;
        }

        public static IEnumerable<T> GetEnumItems<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetEnumDescription(Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        #endregion ENUM METHODS
        /*******************************************************************************************************/
        #region FORM CONTROL

        public static bool displayForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();

            return form.DialogResult == DialogResult.OK;
        }

        //public static void displayNonDialog(Form form)
        //{
        //    form.StartPosition = FormStartPosition.CenterScreen;
        //    form.Show();
        //}

        public static void displayForm(Form parentFormToHide, Form form)
        {
            parentFormToHide.Hide();
            displayForm(form);

            if(!parentFormToHide.IsDisposed)
                parentFormToHide.Show();
        }

        public static void hideControls(params object[] controls)
        {
            foreach (object obj in controls)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                    ((ToolStripMenuItem)obj).Visible = false;
                else if (obj.GetType() == typeof(Panel))
                    ((Panel)obj).Visible = false;
                else if (obj.GetType() == typeof(DataGridViewColumn))
                    ((DataGridViewColumn)obj).Visible = false;
            }
        }

        public static void disableControls(params object[] controls)
        {
            foreach (object obj in controls)
            {
                if (obj.GetType() == typeof(ToolStripMenuItem))
                    ((ToolStripMenuItem)obj).Enabled = false;
                else if (obj.GetType() == typeof(Panel))
                    ((Panel)obj).Enabled = false;
                else
                    ((Control)obj).Enabled = false;
            }
        }

        public static void disableResizing(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
        }

        #endregion FORM CONTROL
        /*******************************************************************************************************/
        #region DATETIMEPICKER CONTROL

        public static DateTime? getDateTime(DateTimePicker dateTimePicker, bool isEndDate)
        {
            if (dateTimePicker.Checked)
                if (isEndDate)
                    return dateTimePicker.Value.AddSeconds(1);
                else
                    return dateTimePicker.Value;
            else
                return null;
        }

        public static DateTime? getDate(DateTimePicker dateTimePicker, bool isEndDate)
        {
            if (dateTimePicker.Checked)
                if (isEndDate)
                    return dateTimePicker.Value.AddDays(1).Date;
                else
                    return dateTimePicker.Value.Date;
            else
                return null;
        }

        #endregion DATETIMEPICKER CONTROL
        /*******************************************************************************************************/
        #region MESSAGEBOX CONTROL

        public static bool okCancelMessage(string message)
        {
            DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.OKCancel);
            return result == DialogResult.OK;
        }

        public static bool hasMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return true;
            }
            return false;
        }

        public static bool showError(string message)
        {
            MessageBox.Show("ERROR: " + message);
            return false;
        }

        public static bool inputError<T>(object obj, string errorMessage)
        {
            hasMessage(errorMessage);
            if (typeof(T) == typeof(TextBox))
            {
                TextBox control = (TextBox)obj;
                control.SelectAll();
                control.Focus();
            }
            else if (typeof(T) == typeof(ComboBox))
            {
                ComboBox control = (ComboBox)obj;
                control.Focus();
            }
            else if (typeof(T) == typeof(DateTimePicker))
            {
                DateTimePicker control = (DateTimePicker)obj;
                control.Focus();
            }
            else if (typeof(T) == typeof(CheckedListBox))
            {
                CheckedListBox control = (CheckedListBox)obj;
                control.Focus();
            }

            return false;
        }

        #endregion MESSAGEBOX CONTROL
        /*******************************************************************************************************/
        #region CHECKED LISTBOX CONTROL

        public static void populateCheckedListBox(CheckedListBox clb, object data, string displayMember, string valueMember)
        {
            clb.DataSource = data;
            clb.DisplayMember = displayMember;
            clb.ValueMember = valueMember;
            clb.CheckOnClick = true;
            clb.ClearSelected();
        }

        public static string compileRowFilterString(CheckedListBox clb, string fieldName, Type type)
        {
            if (clb.CheckedItems.Count == 0)
                return "";
            else
                return string.Format("{0} IN ({1})", fieldName, compileDBFilterString(clb,fieldName,type));
        }

        public static string compileDBFilterString(CheckedListBox clb, string fieldName, Type type)
        {
            string filter = "";
            foreach (object item in clb.CheckedItems)
            {
                if (type == typeof(Guid))
                    filter = Tools.append(filter, string.Format("Convert('{0}', 'System.Guid')", ((DataRowView)item)[0].ToString()), ",");
                else if (type == typeof(string))
                    filter = Tools.append(filter, string.Format("'{0}'", ((DataRowView)item)[0].ToString()), ",");
            }
            return filter;
        }

        public static void clearCheckedItems(CheckedListBox clb)
        {
            setAllItems(clb, false);
            //foreach (int i in clb.CheckedIndices)
            //{
            //    clb.SetItemCheckState(i, CheckState.Unchecked);
            //}
        }

        public static DataTable createArrayTable()
        {
            DataTable datatable = new DataTable();
            Tools.addColumn<string>(datatable, DBUtil.TYPE_ARRAY_STR, "");
            Tools.addColumn<int>(datatable, DBUtil.TYPE_ARRAY_INT, 0);
            return datatable;
        }

        public static DataTable copySelectionToArrayTable(CheckedListBox clb, string columnName)
        {
            DataTable datatable = createArrayTable();
            foreach (object item in clb.CheckedItems)
                datatable.Rows.Add(new string[] { ((DataRowView)item)[columnName].ToString(), null });
            return datatable;
        }

        //public static DataTable copyValuesToArrayTable(Guid? value)
        //{
        //    DataTable datatable = createArrayTable();
        //    if(value != null) datatable.Rows.Add(new string[] { value.ToString(), null });
        //    return datatable;
        //}

        public static DataTable copyValuesToArrayTable(params Guid?[] values)
        {
            DataTable datatable = createArrayTable();
            foreach (Guid? value in values)
                if (value != null) datatable.Rows.Add(value.ToString(), null);
            return datatable;
        }
        
        public static DataTable copyIntToArrayTable(params int[] values)
        {
            DataTable datatable = createArrayTable();
            if(values != null)
                foreach(int value in values)
                    if (value != null) datatable.Rows.Add(null, value);
            return datatable;
        }

        public static void setAllItems(CheckedListBox clb, bool value)
        {
            for(int i=0; i<clb.Items.Count; i++)
                clb.SetItemChecked(i, value);
        }

        #endregion CHECKED LISTBOX CONTROL
        /*******************************************************************************************************/
        #region DROPDOWNLIST CONTROL

        public static object getValue(System.Windows.Forms.ComboBox dropdownlist)
        {
            if (!isDropdownlistSelected(dropdownlist))
                return null;
            else
                return dropdownlist.SelectedValue;
        }

        public static bool isDropdownlistSelected(System.Windows.Forms.ComboBox dropdownlist)
        {
            Guid selectedID = new Guid();
            return isDropdownlistSelected(dropdownlist, ref selectedID);
        }

        public static bool isDropdownlistSelected(System.Windows.Forms.ComboBox dropdownlist, ref Guid selectedID)
        {
            if (dropdownlist.SelectedIndex > -1 && Guid.TryParse(dropdownlist.SelectedValue.ToString(), out selectedID))
                return true;
            else
                return false;
        }

        public static void dropdownlistQuickFilter(System.Windows.Forms.ComboBox dropdownlist, System.Windows.Forms.TextBox txtSearch, string fieldName)
        {
            DataView dvw = (DataView)dropdownlist.DataSource;
            txtSearch.Text = txtSearch.Text.Trim();
            string searchKeyword = txtSearch.Text;

            if (string.IsNullOrEmpty(searchKeyword))
            {
                dvw.RowFilter = "";
            }
            else
            {
                dvw.RowFilter = String.Format("{0} LIKE '%{1}%'", fieldName, searchKeyword);
            }

            dropdownlist.DataSource = dvw;
        }

        public static void setDropDownList(ComboBox cb, object value)
        {
            if (value == null) 
                Tools.resetDropDownList(cb); 
            else 
                cb.SelectedValue = value;
        }

        public static void populateDropDownList(ComboBox cb, Type enumName)
        {
            populateDropDownList(cb, null, "", "", true);
            cb.DataSource = Enum.GetValues(enumName);
            resetDropDownList(cb);
        }

        public static void populateDropDownList(ComboBox cb, DataView dvw, string displayMember, string valueMember, bool showDefault)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDown;
            cb.AutoCompleteMode = AutoCompleteMode.Append;
            cb.AutoCompleteSource = AutoCompleteSource.ListItems;

            cb.TextChanged += new System.EventHandler(cb_TextChanged);

            cb.DataSource = dvw;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;

            if (dvw != null && showDefault & dvw.Table.Columns.Contains(DBUtil.COL_DEFAULT_ROW))
                Tools.selectDefaultItem(cb);
            else
                resetDropDownList(cb);
        }

        private static void cb_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (string.IsNullOrEmpty(cb.Text))
                cb.SelectedIndex = -1;
        }

        public static void resetDropDownList(ComboBox cb)
        {
            cb.SelectAll();
            cb.Text = "";
            cb.SelectedIndex = -1;
        }

        public static void selectDefaultItem(System.Windows.Forms.ComboBox cb)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SelectedIndex = i;
                if (Convert.ToBoolean(((System.Data.DataRowView)cb.SelectedItem)[DBUtil.COL_DEFAULT_ROW]) == true)
                    break;
            }
        }

        public static void setValue(ComboBox cb, Guid? value)
        {
            if (value == null) 
                Tools.resetDropDownList(cb); 
            else    
                cb.SelectedValue = value;
        }

        #endregion DROPDOWNLIST CONTROL
        /*******************************************************************************************************/
        #region BUTTON CONTROL
        
        /// <summary>
        /// Rearrange buttons in a panel based on tab order. Non-buttons are hidden. Panel is then aligned relative to the window width
        /// </summary>
        /// <param name="pnl">name of panel</param>
        /// <param name="alignment">alignment relative to the window width</param>
        public static void rearrangeButtonsInPanel(Panel pnl, HorizontalAlignment alignment)
        {
            int currentX = 0;
            int totalWidth = 0;
            foreach (Control ctrl in getSortedControlsInPanel(pnl))
            {
                if (ctrl.GetType() != typeof(Button) || !ctrl.Enabled)
                {
                    ctrl.Visible = false;
                }
                else
                {
                    ctrl.Visible = true;
                    ctrl.Location = new Point(currentX, 0);
                    currentX += Settings.BUTTON_GAP + ctrl.Size.Width;
                    totalWidth += Settings.BUTTON_GAP + ctrl.Size.Width;
                }
            }

            pnl.Width = totalWidth;
            if (alignment == HorizontalAlignment.Left)
                pnl.Location = new Point(Settings.BUTTON_GAP / 2, pnl.Location.Y);
            else if (alignment == HorizontalAlignment.Center)
                pnl.Location = new Point((pnl.FindForm().Width - totalWidth) / 2, pnl.Location.Y);
            else if (alignment == HorizontalAlignment.Right)
                pnl.Location = new Point((pnl.FindForm().Width - totalWidth), pnl.Location.Y);
        }

        public static void rearrangeButtonPanel(Panel pnl, HorizontalAlignment alignment)
        {

            //arrange visible buttons in panel
            int currentX = Settings.BUTTON_GAP;
            foreach (Control ctrl in getSortedControlsInPanel(pnl))
            {
                if (ctrl.GetType() == typeof(Button) && ctrl.Visible)
                {
                    pnl.Controls.Add(ctrl);
                    ctrl.Location = new Point(currentX, 0);
                    currentX += Settings.BUTTON_GAP + ctrl.Size.Width;
                }
            }
            pnl.Width = currentX;
            pnl.Location = new Point((pnl.Parent.Width - pnl.Width) / 2, 0);


            //int currentX = pnl.Parent.Location.X;
            //int totalWidth = 0;
            //foreach (Control ctrl in getSortedControlsInPanel(pnl))
            //{
            //    if (ctrl.GetType() != typeof(Button) || !ctrl.Visible)
            //    {
            //        ctrl.Visible = false;
            //    }
            //    else
            //    {
            //        ctrl.Visible = true;
            //        ctrl.Location = new Point(currentX, 0);
            //        currentX += Settings.BUTTON_GAP + ctrl.Size.Width;
            //        totalWidth += Settings.BUTTON_GAP + ctrl.Size.Width;
            //    }
            //}

            //pnl.Width = Settings.BUTTON_GAP + totalWidth;
            //if (alignment == HorizontalAlignment.Left)
            //    pnl.Location = new Point(Settings.BUTTON_GAP / 2, pnl.Location.Y);
            //else if (alignment == HorizontalAlignment.Center)
            //    pnl.Location = new Point((pnl.Parent.Width - totalWidth) / 2, pnl.Location.Y);
            //else if (alignment == HorizontalAlignment.Right)
            //    pnl.Location = new Point(pnl.Parent.Width - totalWidth - (Settings.BUTTON_GAP / 2), pnl.Location.Y);
        }

        public static void rearrangeButtonsInPanel(Panel pnl, HorizontalAlignment alignment, bool hideDisabledControls)
        {
            int currentX = pnl.Parent.Location.X;
            int totalWidth = 0;
            foreach (Control ctrl in getSortedControlsInPanel(pnl))
            {
                if (ctrl.GetType() != typeof(Button) || (hideDisabledControls && !ctrl.Enabled) || !ctrl.Visible)
                {
                    ctrl.Visible = false;
                }
                else
                {
                    ctrl.Visible = true;
                    ctrl.Location = new Point(currentX, 0);
                    currentX += Settings.BUTTON_GAP + ctrl.Size.Width;
                    totalWidth += Settings.BUTTON_GAP + ctrl.Size.Width;
                }
            }

            pnl.Width = Settings.BUTTON_GAP + totalWidth;
            if (alignment == HorizontalAlignment.Left)
                pnl.Location = new Point(Settings.BUTTON_GAP / 2, pnl.Location.Y);
            else if (alignment == HorizontalAlignment.Center)
                pnl.Location = new Point((pnl.Parent.Width - totalWidth) / 2, pnl.Location.Y);
            else if (alignment == HorizontalAlignment.Right)
                pnl.Location = new Point(pnl.Parent.Width - totalWidth - (Settings.BUTTON_GAP / 2), pnl.Location.Y);
        }

        public static List<Control> getSortedControlsInPanel(Panel pnl)
        {
            List<Control> controls = new List<Control>();
            foreach (Control ctrl in pnl.Controls)
            {
                controls.Add(ctrl);
            }
            controls.Sort(new Comparison<Control>(CompareTabIndex));
            return controls;
        }

        private static int CompareTabIndex(Control c1, Control c2)
        {
            return c1.TabIndex.CompareTo(c2.TabIndex);
        }

        #endregion BUTTON CONTROL
        /*******************************************************************************************************/
        #region DATAGRIDVIEW CONTROL

        public static void setColumnFormat(DataGridViewColumn column, string format, DataGridViewContentAlignment alignment)
        {
            column.DefaultCellStyle.Alignment = alignment;
            column.DefaultCellStyle.Format = format;
        }

        public static void disableSort(DataGridView grid)
        {
            grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        public static void setGridviewColumnWordwrap(DataGridViewColumn column)
        {
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public static void setGridviewDataSource(DataGridView grid, bool rememberRowPosition, bool reapplySort, object data)
        {
            //save top row index
            int topRowIndex = grid.FirstDisplayedScrollingRowIndex;
            int selectedRowIndex = -1;
            if (grid.Rows.Count > 0 && grid.SelectedRows.Count > 0)
                selectedRowIndex = grid.SelectedRows[0].Index;

            //save sorting
            DataGridViewColumn sortColumn = grid.SortedColumn;
            ListSortDirection sortOrder = ListSortDirection.Ascending;
            if (grid.SortOrder == SortOrder.Descending) sortOrder = ListSortDirection.Descending;

            //update datasource 
            grid.DataSource = data;

            //reapply sorting
            if (reapplySort && sortColumn != null)
                grid.Sort(sortColumn, sortOrder);

            //display top row index 
            if(rememberRowPosition)
                Tools.setFirstDisplayedScrollingRowIndex(grid, topRowIndex, selectedRowIndex);
        }

        public static void displayContextMenu(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex > -1)
            {
                grid.ClearSelection(); 
                grid.Rows[e.RowIndex].Selected = true;
            }
        }

        public static Guid getClickedRowID(DataGridView grid, DataGridViewColumn column, int rowIndex)
        {
            return (Guid)grid.Rows[rowIndex].Cells[column.Name].Value;
        }

        public static Guid getSelectedRowID(DataGridView grid, DataGridViewColumn column)
        {
            return (Guid)grid.SelectedRows[0].Cells[column.Name].Value;
        }

        public static DataGridViewColumn addColumn<T>(DataGridView gridview, string columnName, string headerText, string dataPropertyName, int columnWidth, bool readOnly, string format)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            column.CellTemplate = (DataGridViewCell)Activator.CreateInstance(typeof(T));
            column.Name = columnName;
            column.HeaderText = headerText;
            column.DataPropertyName = dataPropertyName;
            column.ReadOnly = readOnly;
            column.SortMode = DataGridViewColumnSortMode.Automatic;
            column.DefaultCellStyle.Format = format;

            column.MinimumWidth = 10;
            if(columnWidth == (int)MasterDataColumnWidth.Hidden)
                column.Visible = false;
            else if (columnWidth == (int)MasterDataColumnWidth.Fit)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            else if (columnWidth == (int)MasterDataColumnWidth.Fill)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            else
                column.Width = columnWidth;

            gridview.Columns.Add(column);
            return column;
        }

        public static void adjustGridviewForVScrollbar(Form form, bool allowWidenForm)
        {
            bool mustWidenForm = false;
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.GetType() == typeof(DataGridView))
                {
                    DataGridView grid = (DataGridView)ctrl;

                    //add space for vertical scrollbar if visible
                    foreach (var scroll in grid.Controls.OfType<VScrollBar>())
                    {
                        if (scroll.Visible && !hasGridSpaceForVScrollbar(grid))
                        {
                            grid.Width += Settings.GRIDVIEW_VSCROLLBAR_SPACE;
                            mustWidenForm = true;
                        }
                        else if (!scroll.Visible && hasGridSpaceForVScrollbar(grid))
                        {
                            grid.Width -= Settings.GRIDVIEW_VSCROLLBAR_SPACE;
                        }
                    }

                }
            }
            if (mustWidenForm && allowWidenForm)
                form.Width += Settings.GRIDVIEW_VSCROLLBAR_SPACE;
        }

        private static bool hasGridSpaceForVScrollbar(DataGridView grid)
        {
            if (grid.Width >= getVisibleColumnsTotalWidth(grid) + Settings.GRIDVIEW_VSCROLLBAR_SPACE)
                return true;
            else
                return false;
        }

        private static int getVisibleColumnsTotalWidth(DataGridView grid)
        {
            int width = 0;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible)
                {
                    if (col.GetType() == typeof(DataGridViewButtonColumn))
                        width += col.Width + 3; //there is additional width of 8 for each button columns. not sure why.
                    else
                        width += col.Width;
                }
            }
            return width;
        }

        public static void formatDeleteColumn(DataGridViewLinkColumn col)
        {
            col.UseColumnTextForLinkValue = true;
            col.LinkBehavior = LinkBehavior.NeverUnderline;
            col.VisitedLinkColor = Color.Red;
            col.LinkColor = Color.Red;
            col.Text = "X";
            col.ToolTipText = "delete";
            col.Width = 22;
            col.DefaultCellStyle.ForeColor = Color.Red;
            col.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, (float)8.0, FontStyle.Bold);
        }

        public static bool isCorrectColumn(object sender, DataGridViewCellEventArgs e, Type columnType, string columnName)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex > -1 && senderGrid.Columns[e.ColumnIndex].GetType() == columnType)
            {
                if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == columnName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void selectRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ((DataGridView)sender).Rows[e.RowIndex].Selected = true;
            }
        }

        public static void populateDataGridView(DataGridView datagridview, object data)
        {
            DataGridViewColumn sortColumn = datagridview.SortedColumn;
            SortOrder sortDirection = datagridview.SortOrder;

            datagridview.DataSource = data;

            if (sortDirection != SortOrder.None)
                datagridview.Sort(sortColumn, Tools.getListSortDirection(sortDirection));
        }

        public static void saveGridviewKey(DataGridView grid, string columnName)
        {
            if(grid.SelectedRows.Count > 0)
                if (grid.Columns.Contains(columnName))
                    if (grid.SelectedRows[0].Cells[columnName].Value != null)
                    GlobalData.TemporarySelectedGridviewValue = grid.SelectedRows[0].Cells[columnName].Value.ToString();
        }

        public static void selectGridviewPreviousKey(DataGridView grid, string columnName)
        {
            if (grid.Rows.Count > 0 && grid.Columns.Contains(columnName) && !string.IsNullOrEmpty(GlobalData.TemporarySelectedGridviewValue))
            {
                int rowIndex = -1;
                DataGridViewRow row = grid.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnName].Value.ToString().Equals(GlobalData.TemporarySelectedGridviewValue))
                    .FirstOrDefault();

                if (row == null)
                    rowIndex = 0;
                else
                    rowIndex = row.Index;

                grid.ClearSelection();
                if (rowIndex > -1)
                    grid.Rows[rowIndex].Selected = true;
            }
        }

        public static void clearWhenSelected(DataGridView grid)
        {
            grid.SelectionChanged += new System.EventHandler(clearOnSelectionChanged);
        }

        private static void clearOnSelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection(); //disable cell color change when user click on it
        }

        public static void setFirstDisplayedScrollingRowIndex(DataGridView grid, int topRowIndex, int selectedRowIndex)
        {
            if(grid.Rows.Count > 0 && topRowIndex > -1)
            {
                if (grid.Rows.Count >= topRowIndex)
                    grid.FirstDisplayedScrollingRowIndex = topRowIndex;
                else
                    topRowIndex = grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count - 1;
            }

            if (selectedRowIndex > -1 && grid.Rows.Count > 0)
            {
                grid.ClearSelection();
                if (selectedRowIndex < grid.Rows.Count)
                    grid.Rows[selectedRowIndex].Selected = true;
                else
                    grid.Rows[topRowIndex].Selected = true;
            }
        }
        
        /// <summary>
        ///     Must be called after a column is frozen (if there is any). Otherwise, calculation to hide header checkbox won't be accurate
        /// </summary>
        public static CheckBox addHeaderCheckbox(DataGridView grid, DataGridViewColumn column, string controlName, EventHandler checkedChangedHandler)
        {
            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = controlName;
            //datagridview[0, 0].ToolTipText = "sdfsdf";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.BackColor = Color.Transparent;

            setHeaderCheckboxLocation(grid, column, checkboxHeader);

            checkboxHeader.CheckedChanged += new EventHandler(checkedChangedHandler);

            //reposition checkbox if column width is changed
            grid.Controls.Add(checkboxHeader);
            grid.ColumnWidthChanged += (sender, e) => grid_ColumnWidthChanged(sender, e, column, checkboxHeader);

            //reposition checkbox if horizontal scrollbar is scrolled and hide if checkbox is positioned behind frozen columns
            grid.Scroll += (sender, e) => grid_Scroll_RepositionHeaderCheckboxLocation(sender, e, grid, column, checkboxHeader);

            return checkboxHeader;
        }

        public static void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e, DataGridViewColumn column, CheckBox checkboxHeader)
        {
            Tools.setHeaderCheckboxLocation((DataGridView)sender, column, checkboxHeader);
        }

        public static void setHeaderCheckboxLocation(DataGridView grid, DataGridViewColumn column, CheckBox checkboxHeader)
        {
            Rectangle rect = grid.GetCellDisplayRectangle(column.DisplayIndex, -1, false);
            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = rect.Location.Y + (rect.Height - checkboxHeader.Height) / 2 + 1;
            rect.X = rect.Location.X + (rect.Width - checkboxHeader.Width) / 2 + 2;
            checkboxHeader.Location = rect.Location;
        }

        public static void grid_Scroll_RepositionHeaderCheckboxLocation(object sender, ScrollEventArgs e, DataGridView grid, DataGridViewColumn column, CheckBox checkboxHeader)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                if (checkboxHeader.Location.X < 0)
                    checkboxHeader.Visible = false;
                else
                    checkboxHeader.Visible = true;

                Tools.setHeaderCheckboxLocation(grid, column, checkboxHeader);
            }
        }

        public static void toggleCheckboxColumn(DataGridView grid, DataGridViewColumn column, CheckBox headerCheckbox)
        {
            int idx = -1;
            if(grid.SelectedRows.Count > 0)
                idx = grid.SelectedRows[0].Index;
            grid.CurrentCell = null; //fix problem where previously manually toggled checkbox doesn't display new value when programmatically changed using header checkbox
            if (idx > -1)
                grid.Rows[idx].Selected = true;

            foreach (DataGridViewRow row in grid.Rows)
                row.Cells[column.Name].Value = headerCheckbox.Checked;

        }

        public static ListSortDirection getListSortDirection(SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    return ListSortDirection.Ascending;
                case SortOrder.Descending:
                    return ListSortDirection.Descending;
                default:
                    return ListSortDirection.Ascending;
            }
        }

        #endregion DATAGRIDVIEW CONTROL
        /*******************************************************************************************************/
        #region UPLOADED FILES

        public static string getUploadedFilepath(string filename)
        {
            string localpath = Path.Combine(Application.StartupPath, Settings.localFileFolderName);
            string localfilepath = Path.Combine(localpath, filename);
            string serverfilepath = Path.Combine(Settings.getUploadStoragePath(), filename);

            //check whether file is in local directory
            if (!File.Exists(localfilepath))
            {
                //download file to local directory
                if (File.Exists(serverfilepath))
                {
                    if (!Directory.Exists(localpath))
                        Directory.CreateDirectory(localpath);

                    File.Copy(serverfilepath, localfilepath, false);
                }
            }
            return localfilepath;
        }

        #endregion UPLOADED FILES
        /*******************************************************************************************************/
        #region THREADING

        public static void pause(decimal seconds)
        {
            System.Threading.Thread.Sleep((int)(seconds * 1000));
        }

        public static void startProgressDisplay(string displayText)
        {
            if(!SharedForms.ProgressDisplay.InUse)
            {
                SharedForms.ProgressDisplay.ActiveForm = Form.ActiveForm;
                SharedForms.ProgressDisplay.DisplayText = displayText;
                new Thread(SharedForms.ProgressDisplay.run).Start();
            }
            else
            {
                Tools.showError("Progress Display is in use. Please notifiy your administrator.");
            }
        }

        public static void stopProgressDisplay()
        {
            SharedForms.ProgressDisplay.signalToQuit();
            SharedForms.ProgressDisplay.ActiveForm.Focus();
        }

        #endregion THREADING
        /*******************************************************************************************************/
        #region TEXTBOX MANIPULATOR
        
        #endregion
        /*******************************************************************************************************/
    }
}
