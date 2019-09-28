using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    class FabricColor
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "color_name";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_ALLOW2NDCOLOR = "allow_2nd_color";
        
        public Guid ID;
        public string Name = "";
        public bool Active = true;
        public bool Allow2ndColor = false;

        public FabricColor(Guid? id)
        {
            if(id != null)
            {
                ID = (Guid)id;
                DataTable dt = getRow(ID);
                Name = dt.Rows[0][COL_DB_NAME].ToString();
                Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
                Allow2ndColor = DBUtil.parseData<bool>(dt.Rows[0], COL_DB_ALLOW2NDCOLOR);
            }
        }

        public static void add(string name)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("color_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("color_isNameExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;
                
                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("color_get", ID);
        }
        
        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null);
        }

        public static DataTable getByFilter(bool includeInactive, string nameFilter)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("color_get_byFilter", DBUtil.ActiveSqlConnection))
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
            DBUtil.updateActiveStatus("color_update_active", id, activeStatus);
        }

        public static void updateDefaultRow(Guid id)
        {
            DBUtil.updateDefaultRow("color_update_default", id, "Set as new default item");
        }

        public static void updateAllow2ndColor(Guid id, bool newValue)
        {
            using (SqlCommand cmd = new SqlCommand("color_update_allow2ndcolor", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("@new_value", SqlDbType.Bit).Value = newValue;

                cmd.ExecuteNonQuery();

                ActivityLog.submit(id, "Allow 2nd color changed to: " + newValue.ToString().ToLower());
            }
        }

        public static void update(Guid id, string name)
        {
            try
            {
                FabricColor objOld = new FabricColor(id);

                //generate log description
                string logDescription = "";
                if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("color_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + logDescription);
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

        public static void populateInputControlCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool includeInactive)
        {
            checkedlistbox.populate(getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID);
        }

        public static void populateCheckedListBox(System.Windows.Forms.CheckedListBox checkedlistbox, bool includeInactive)
        {
            Tools.populateCheckedListBox(checkedlistbox, getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

    }
}
