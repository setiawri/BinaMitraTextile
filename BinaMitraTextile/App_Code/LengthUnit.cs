using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class LengthUnit
    {
        public static string connectionString = DBUtil.connectionString;

        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "length_unit_name";
        public const string COL_DB_ACTIVE = "active";
        
        public Guid ID;
        public string Name = "";
        public Boolean Active = true;
        
        public LengthUnit(Guid? id) { }

        public LengthUnit(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            Name = dt.Rows[0][COL_DB_NAME].ToString();
            Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
        }

        public static void add(string name)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("lengthunit_new", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;

                    conn.Open();
                    cmd.ExecuteNonQuery();


                    ActivityLog.submit(conn, id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("lengthunit_isNameExist", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("lengthunit_get", ID);
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null);
        }

        public static DataTable getByFilter(bool includeInactive, string nameFilter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("lengthunit_get_byFilter", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = Tools.wrapNullable(nameFilter);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("lengthunit_update_active", id, activeStatus);
        }

        public static void updateDefaultRow(Guid id)
        {
            DBUtil.updateDefaultRow("lengthunit_update_default", id, "Set as new default item");
        }

        public static void update(Guid id, string name)
        {
            try
            {
                LengthUnit objOld = new LengthUnit(id);

                //generate log description
                string logDescription = "";
                if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                    using (SqlCommand cmd = new SqlCommand("lengthunit_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(conn, id, "Update: " + logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

        public static void populateCheckedListBox(System.Windows.Forms.CheckedListBox checkedlistbox, bool includeInactive)
        {
            Tools.populateCheckedListBox(checkedlistbox, getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID);
        }

        public static void populateInputControlCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool includeInactive)
        {
            checkedlistbox.populate(getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

    }
}
