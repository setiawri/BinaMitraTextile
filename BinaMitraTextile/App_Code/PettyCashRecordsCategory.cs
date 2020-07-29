using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class PettyCashRecordsCategory
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public string Name;
        public string Notes = "";
        public bool Active;


        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region DATABASE FIELDS

        public const string COL_DB_Id = "Id";
        public const string COL_DB_Name = "Name";
        public const string COL_DB_Notes = "Notes";
        public const string COL_DB_Active = "Active";

        public const string COL_FILTER_Include_Inactive = "Include_Inactive";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public PettyCashRecordsCategory() { }
        public PettyCashRecordsCategory(Guid id)
        {
            DataRow row = get(id);
            ID = id;
            Name = DBUtil.parseData<string>(row, COL_DB_Name);
            Notes = DBUtil.parseData<string>(row, COL_DB_Notes);
            Active = DBUtil.parseData<bool>(row, COL_DB_Active);
        }

        #endregion CONSTRUCTOR METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        
        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("PettyCashRecordsCategories_isNameExist", DBConnection.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_Name, SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static void add(string name, string notes)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("PettyCashRecordsCategories_add", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Name, SqlDbType.VarChar).Value = Tools.wrapNullable(name);
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataRow get(Guid id) { return Tools.getFirstRow(get(true, id, null)); }

        public static DataTable get(bool includeInactive, Guid? id, string name)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("PettyCashRecordsCategories_get", DBConnection.ActiveSqlConnection))
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_FILTER_Include_Inactive, SqlDbType.Bit).Value = includeInactive;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                    cmd.Parameters.Add("@" + COL_DB_Name, SqlDbType.VarChar).Value = Tools.wrapNullable(name);

                    adapter.SelectCommand = cmd;
                    adapter.Fill(datatable);
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }

            return datatable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("PettyCashRecordsCategories_update_active", id, activeStatus);
        }

        public static void updateDefaultRow(Guid id)
        {
            DBUtil.updateDefaultRow("PettyCashRecordsCategories_update_default", id, "Set as new default item");
        }

        public static void update(Guid id, string name, string notes)
        {
            try
            {
                PettyCashRecordsCategory objOld = new PettyCashRecordsCategory(id);
                string log = "";
                log = ActivityLog.appendChange(log, objOld.Name, name, "Name: '{0}' to '{1}'");
                log = ActivityLog.appendChange(log, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                using (SqlCommand cmd = new SqlCommand("PettyCashRecordsCategories_update", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_Id, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_Name, SqlDbType.VarChar).Value = Tools.wrapNullable(name);
                    cmd.Parameters.Add("@" + COL_DB_Notes, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Update: " + log);
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, get(false, null, null).DefaultView, COL_DB_Name, COL_DB_Id, showDefault);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(get(includeInactive, null, null).DefaultView, COL_DB_Name, COL_DB_Id, null);
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}

