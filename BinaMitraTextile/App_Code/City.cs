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
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("city_get_byFilter", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@include_inactive", SqlDbType.Bit).Value = includeInactive;
                cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = Tools.wrapNullable(nameFilter);
                cmd.Parameters.Add("@" + COL_DB_STATEID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(stateID);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("city_update_active", id, activeStatus);
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("city_isNameExist", DBConnection.ActiveSqlConnection))
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

        public static void add(string name, Guid stateID)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("city_new", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@" + COL_DB_STATEID, SqlDbType.UniqueIdentifier).Value = stateID;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid id, string name, Guid stateID)
        {
            try
            {
                City objOld = new City(id);

                //generate log description
                string logDescription = "";
                if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
                if (objOld.StateID != stateID) logDescription = Tools.append(logDescription, String.Format("State: '{0}' to '{1}'", objOld.StateName, new State(stateID).Name), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("city_update", DBConnection.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@city_name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@state_id", SqlDbType.UniqueIdentifier).Value = stateID;

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
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
