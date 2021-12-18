using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class Vendor
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "vendor_name";
        public const string COL_DB_ADDRESS = "address";
        public const string COL_DB_PHONE1 = "phone1";
        public const string COL_DB_PHONE2 = "phone2";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_usesFakturPajak = "usesFakturPajak";

        public const string FILTER_IncludeInactive = "include_inactive";

        public Guid ID;
        public string Name = null;
        public string Address = "";
        public string Phone1 = "";
        public string Phone2 = "";
        public Boolean Active = true;
        public string Notes = "";
        public bool UsesFakturPajak = false;

        public string Info
        {
            get
            {
                string info = Name;

                if (!string.IsNullOrEmpty(Address))
                    info += Environment.NewLine + Address;

                string phones = Tools.append(Phone1, Phone2, ",");
                if (!string.IsNullOrEmpty(phones))
                    info += Environment.NewLine + phones;

                return info;
            }
        }

        public Vendor(Guid? id)
        {
            if(id != null)
            {
                ID = (Guid)id;
                DataRow row = Util.getFirstRow(get(ID, true, null));
                Name = row[COL_DB_NAME].ToString();
                Address = row[COL_DB_ADDRESS].ToString();
                Phone1 = row[COL_DB_PHONE1].ToString();
                Phone2 = row[COL_DB_PHONE2].ToString();
                Active = Util.wrapNullable<bool>(row, COL_DB_ACTIVE);
                UsesFakturPajak = Util.wrapNullable<bool>(row, COL_DB_usesFakturPajak);
                Notes = row[COL_DB_NOTES].ToString();
            }
        }

        public static Guid? add(string name, string address, string phone1, string phone2, string notes)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "vendor_new",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                new SqlQueryParameter(COL_DB_ADDRESS, SqlDbType.VarChar, address),
                new SqlQueryParameter(COL_DB_PHONE1, SqlDbType.VarChar, phone1),
                new SqlQueryParameter(COL_DB_PHONE2, SqlDbType.VarChar, phone2),
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

        public static bool isNameExist(string Name, Guid? id)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                false, false, false, true, false,
                "vendor_isNameExist",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(id)),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Name)
                );
            return result.ValueBoolean;
        }

        public static DataTable get(Guid? Id, bool includeInactive, string name)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "vendor_get",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter(FILTER_IncludeInactive, SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(name))
            );
            return result.Datatable;
        }
        
        public static void update(Guid id, string name, string address, string phone1, string phone2, string notes)
        {
            Vendor objOld = new Vendor(id);

            //generate log description
            string logDescription = "";
            if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
            if (objOld.Address != address) logDescription = Tools.append(logDescription, String.Format("Address: '{0}' to '{1}'", objOld.Address, address), ",");
            if (objOld.Phone1 != phone1) logDescription = Tools.append(logDescription, String.Format("Phone 1: '{0}' to '{1}'", objOld.Phone1, phone1), ",");
            if (objOld.Phone2 != phone2) logDescription = Tools.append(logDescription, String.Format("Phone 2: '{0}' to '{1}'", objOld.Phone2, phone2), ",");
            logDescription = Util.appendChange(logDescription, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "vendor_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, name),
                    new SqlQueryParameter(COL_DB_ADDRESS, SqlDbType.VarChar, address),
                    new SqlQueryParameter(COL_DB_PHONE1, SqlDbType.VarChar, phone1),
                    new SqlQueryParameter(COL_DB_PHONE2, SqlDbType.VarChar, phone2),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submitUpdate(id, logDescription);
            }
        }

        public static void update_UsesFakturPajak(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "vendor_update_usesFakturPajak",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_usesFakturPajak, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Uses Faktur Pajak to: {0}", Value));
        }

        public static void updateActiveStatus(Guid id, Boolean activeStatus)
        {
            DBUtil.updateActiveStatus("vendor_update_active", id, activeStatus);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, get(null, includeInactive, null).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(get(null, includeInactive, null).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

    }
}
