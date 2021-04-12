using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    class FabricColor
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "color_name";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_ALLOW2NDCOLOR = "allow_2nd_color";

        public const string FILTER_IncludeInactive = "include_inactive";

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

        public static Guid add(string name)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "color_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name)
            );

            if (result.IsSuccessful)
                ActivityLog.submitCreate(Id);

            return Id;
        }

        public static bool isNameExist(string name, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "color_isNameExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name)
                );
            return result.ValueBoolean;
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
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "color_get_byFilter",
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(nameFilter))
            );
            return result.Datatable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("color_update_active", id, activeStatus);
        }

        public static void updateDefaultRow(Guid id)
        {
            DBUtil.updateDefaultRow("color_update_default", id, "Set as new default item");
        }

        public static void updateAllow2ndColor(Guid Id, bool newValue)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "color_update_allow2ndcolor",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter("new_value", SqlDbType.Bit, newValue)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, "Allow 2nd color changed to: " + newValue.ToString().ToLower());
        }

        public static void update(Guid Id, string name)
        {
            FabricColor objOld = new FabricColor(Id);

            //generate log description
            string logDescription = "";
            if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "color_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name)
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(Id, logDescription);
            }
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
