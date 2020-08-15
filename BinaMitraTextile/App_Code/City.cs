using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class City
    {        
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        //fields retrieved using stored procedure
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "city_name";
        public const string COL_DB_STATEID = "state_id";
        public const string COL_DB_ACTIVE = "active";

        public const string COL_STATENAME = "state_name";

        public const string FILTER_IncludeInactive = "include_inactive";

        //class object variables
        public Guid ID;
        public string Name = "";
        public Guid StateID;
        public Boolean Active = true;
        public string StateName = "";

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTOR METHODS

        public City(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            Name = dt.Rows[0][COL_DB_NAME].ToString();
            StateID = (Guid)dt.Rows[0][COL_DB_STATEID];
            Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
            StateName = dt.Rows[0][COL_STATENAME].ToString();
        }

        #endregion CONSTRUCTOR METHODS 
        /*******************************************************************************************************/
        #region DATABASE METHODS

        private static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("city_get", ID);
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null, null);
        }

        public static DataTable getByFilter(bool includeInactive, string nameFilter, Guid? stateID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "city_get_byFilter",
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(nameFilter)),
                new SqlQueryParameter(COL_DB_STATEID, SqlDbType.UniqueIdentifier, Util.wrapNullable(stateID))
            );
            return result.Datatable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("city_update_active", id, activeStatus);
        }

        public static bool isNameExist(string name, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "city_isNameExist",
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id))
                );
            return result.ValueBoolean;
        }

        public static Guid? add(string name, Guid stateID)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "city_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                new SqlQueryParameter(COL_DB_STATEID, SqlDbType.UniqueIdentifier, stateID)
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static void update(Guid id, string name, Guid stateID)
        {
            City objOld = new City(id);

            //generate log description
            string logDescription = "";
            if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
            if (objOld.StateID != stateID) logDescription = Tools.append(logDescription, String.Format("State: '{0}' to '{1}'", objOld.StateName, new State(stateID).Name), ",");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "city_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                    new SqlQueryParameter(COL_DB_STATEID, SqlDbType.UniqueIdentifier, stateID)
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(id, "Update: " + logDescription);
            }
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
