﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using LIBUtil;
using LIBUtil.Desktop.UserControls;

namespace BinaMitraTextile
{
    public class Customer
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "customer_name";
        public const string COL_DB_ADDRESS = "address";
        public const string COL_DB_CITYID = "city_id";
        public const string COL_DB_PHONE1 = "phone1";
        public const string COL_DB_PHONE2 = "phone2";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_DEFAULTTRANSPORTID = "default_transport_id";
        public const string COL_DB_SALESUSERID = "sales_user_id";
        public const string COL_DB_usesFakturPajak = "usesFakturPajak";

        public const string COL_CITYNAME = "city_name";
        public const string COL_STATENAME = "state_name";
        public const string COL_DEFAULTTRANSPORTNAME = "default_transport_name";
        public const string COL_SALESUSERNAME = "sales_user_name";
         
        public Guid ID;
        public string Name = null;
        public string Address = "";
        public Guid CityID;
        public Guid? DefaultTransportID;
        public string Phone1 = "";
        public string Phone2 = "";
        public Boolean Active = true;
        public string Notes = "";
        public Guid SalesUserID;
        public bool UsesFakturPajak = false;

        public string CityName = "";
        public string StateName = "";
        public string DefaultTransportName = "";
        public string SalesUserName;

        public string Info
        {
            get
            {
                string info = Name;

                if (!string.IsNullOrEmpty(Address))
                    info += Environment.NewLine + Address;

                string cityAndState = Tools.append(CityName, StateName, ",");
                if (!string.IsNullOrEmpty(cityAndState))
                    info += Environment.NewLine + cityAndState;

                string phones = Tools.append(Phone1, Phone2, ",");
                if (!string.IsNullOrEmpty(phones))
                    info += Environment.NewLine + phones;

                return info;
            }
        }

        public Customer(Guid? id)
        {
            if(id != null)
            {
                ID = (Guid)id;
                DataRow row = get(ID);
                Name = row[COL_DB_NAME].ToString();
                Address = row[COL_DB_ADDRESS].ToString();
                CityID = (Guid)row[COL_DB_CITYID];
                DefaultTransportID = DBUtil.parseData<Guid?>(row, COL_DB_DEFAULTTRANSPORTID);
                Phone1 = row[COL_DB_PHONE1].ToString();
                Phone2 = row[COL_DB_PHONE2].ToString();
                Active = (Boolean)row[COL_DB_ACTIVE];
                Notes = row[COL_DB_NOTES].ToString();
                SalesUserID = DBUtil.parseData<Guid>(row, COL_DB_SALESUSERID);
                UsesFakturPajak = Util.wrapNullable<bool>(row, COL_DB_usesFakturPajak);

                CityName = row[COL_CITYNAME].ToString();
                StateName = row[COL_STATENAME].ToString();
                DefaultTransportName = DBUtil.parseData<string>(row, COL_DEFAULTTRANSPORTNAME);
                SalesUserName = DBUtil.parseData<string>(row, COL_SALESUSERNAME);
            }
        }

        public static void add(string name, string address, Guid cityID, Guid? defaultTransportID, string phone1, string phone2, string notes)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlCommand cmd = new SqlCommand("customer_new", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@" + COL_DB_ADDRESS, SqlDbType.VarChar).Value = address;
                    cmd.Parameters.Add("@" + COL_DB_CITYID, SqlDbType.UniqueIdentifier).Value = cityID;
                    cmd.Parameters.Add("@" + COL_DB_DEFAULTTRANSPORTID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(defaultTransportID);
                    cmd.Parameters.Add("@" + COL_DB_PHONE1, SqlDbType.VarChar).Value = phone1;
                    cmd.Parameters.Add("@" + COL_DB_PHONE2, SqlDbType.VarChar).Value = phone2;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;
                    cmd.Parameters.Add("@" + COL_DB_SALESUSERID, SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlCommand cmd = new SqlCommand("customer_isNameExist", DBConnection.ActiveSqlConnection))
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

        public static DataRow get(Guid Id) { return Util.getFirstRow(get(Id, true, null, null, null)); }
        public static DataTable get(bool includeInactive)
        {
            return get(null, includeInactive, null, null, null);
        }

        public static DataTable get(Guid? Id, bool includeInactive, string nameFilter, Guid? cityID, Guid? transportID)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "customer_get",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Util.wrapNullable(Id)),
                new SqlQueryParameter("include_inactive", SqlDbType.Bit, includeInactive),
                new SqlQueryParameter(COL_DB_NAME, SqlDbType.VarChar, Util.wrapNullable(nameFilter)),
                new SqlQueryParameter(COL_DB_CITYID, SqlDbType.UniqueIdentifier, Util.wrapNullable(cityID)),
                new SqlQueryParameter(COL_DB_DEFAULTTRANSPORTID, SqlDbType.UniqueIdentifier, Util.wrapNullable(transportID))
                );
            return result.Datatable;
        }

        public static void update(Guid id, string name, string address, Guid cityID, Guid? defaultTransportID, string phone1, string phone2, string notes, Guid? salesUserID)
        {
            try
            {
                Customer objOld = new Customer(id);

                //generate log description
                string logDescription = "";
                if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
                if (objOld.Address != address) logDescription = Tools.append(logDescription, String.Format("Address: '{0}' to '{1}'", objOld.Address, address), ",");
                if (objOld.CityID != cityID) logDescription = Tools.append(logDescription, String.Format("City: '{0}' to '{1}'", objOld.CityName, new City(cityID).Name), ",");
                logDescription = ActivityLog.appendChange(logDescription, objOld.DefaultTransportName, new Transport(defaultTransportID).Name, "Angkutan: '{0}' to '{1}'");
                if (objOld.Phone1 != phone1) logDescription = Tools.append(logDescription, String.Format("Phone 1: '{0}' to '{1}'", objOld.Phone1, phone1), ",");
                if (objOld.Phone2 != phone2) logDescription = Tools.append(logDescription, String.Format("Phone 2: '{0}' to '{1}'", objOld.Phone2, phone2), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");
                logDescription = ActivityLog.appendChange(logDescription, objOld.SalesUserName, new UserAccount(salesUserID).name, "Sales: '{0}' to '{1}'");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("customer_update", DBConnection.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@" + COL_DB_ADDRESS, SqlDbType.VarChar).Value = address;
                        cmd.Parameters.Add("@" + COL_DB_CITYID, SqlDbType.UniqueIdentifier).Value = cityID;
                        cmd.Parameters.Add("@" + COL_DB_DEFAULTTRANSPORTID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(defaultTransportID);
                        cmd.Parameters.Add("@" + COL_DB_PHONE1, SqlDbType.VarChar).Value = phone1;
                        cmd.Parameters.Add("@" + COL_DB_PHONE2, SqlDbType.VarChar).Value = phone2;
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;
                        cmd.Parameters.Add("@" + COL_DB_SALESUSERID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(salesUserID);

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }
        
        public static string updateActiveStatus(Guid id, Boolean activeStatus)
        {
            return DBUtil.updateActiveStatus("customer_update_active", id, activeStatus);
        }

        public static void update_UsesFakturPajak(Guid Id, bool Value)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "customer_update_usesFakturPajak",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_usesFakturPajak, SqlDbType.Bit, Value)
            );

            if (result.IsSuccessful)
                ActivityLog.submit(Id, String.Format("Uses Faktur Pajak to: {0}", Value));
        }

        public static decimal getCreditBalance(Guid customerID)
        {
            return CustomerCredit.getBalance(customerID);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, get(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

        public static void populateInputControlDropDownList(LIBUtil.Desktop.UserControls.InputControl_Dropdownlist control, bool includeInactive)
        {
            control.populate(get(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, null);
        }

        public static void populateInputControlCheckedListBox(LIBUtil.Desktop.UserControls.InputControl_CheckedListBox checkedlistbox, bool includeInactive)
        {
            checkedlistbox.populate(get(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID);
        }
    }
}
