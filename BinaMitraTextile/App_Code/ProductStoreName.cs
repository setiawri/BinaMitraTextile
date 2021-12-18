using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class ProductStoreName
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "name";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";

        public const string FILTER_IncludeInactive = "include_inactive";

        public Guid ID;
        public string Name = "";
        public string Notes = "";
        public Boolean Active = true;

        public ProductStoreName(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            Name = dt.Rows[0][COL_DB_NAME].ToString();
            Notes = dt.Rows[0][COL_DB_NOTES].ToString();
            Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
        }

        public static Guid? add(string name, string notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "productstorename_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submitCreate(Id);
                return Id;
            }
        }

        public static bool isNameExist(string name, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "productstorename_isNameExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name)
                );
            return result.ValueBoolean;
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("productstorename_get", ID);
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null);
        }

        public static DataTable getByFilter(bool includeInactive, string name)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "productstorename_get_byFilter",
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(name))
            );
            return result.Datatable;        
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("productstorename_update_active", id, activeStatus);
        }

        public static void update(Guid id, string name, string notes)
        {
            ProductStoreName objOld = new ProductStoreName(id);

            //generate log description
            string logDescription = "";
            if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
            logDescription = Util.appendChange(logDescription, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "productstorename_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(id, logDescription);
            }
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
