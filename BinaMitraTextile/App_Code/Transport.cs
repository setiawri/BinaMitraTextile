﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class Transport
    {
        public static string connectionString = DBUtil.connectionString;

        public const string COL_DB_ID = "id";
        public const string COL_DB_NAME = "name";
        public const string COL_DB_ADDRESS = "address";
        public const string COL_DB_PHONE1 = "phone1";
        public const string COL_DB_PHONE2 = "phone2";
        public const string COL_DB_ACTIVE = "active";
        public const string COL_DB_NOTES = "notes";

        public Guid ID;
        public string Name = "";
        public string Address = "";
        public string Phone1 = "";
        public string Phone2 = "";
        public Boolean Active = true;
        public string Notes = "";

        public Transport(Guid? id)
        {
            if (id != null) constructor((Guid)id);
        }

        public Transport(Guid id)
        {
            constructor(id);
        }

        private void constructor(Guid id)
        {
            ID = id;
            DataTable dt = getRow(ID);
            Name = dt.Rows[0][COL_DB_NAME].ToString();
            Address = dt.Rows[0][COL_DB_ADDRESS].ToString();
            Phone1 = dt.Rows[0][COL_DB_PHONE1].ToString();
            Phone2 = dt.Rows[0][COL_DB_PHONE2].ToString();
            Active = (Boolean)dt.Rows[0][COL_DB_ACTIVE];
            Notes = dt.Rows[0][COL_DB_NOTES].ToString();
        }

        public static void add(string name, string address, string phone1, string phone2, string notes)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                using (SqlCommand cmd = new SqlCommand("transport_new", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@" + COL_DB_ADDRESS, SqlDbType.VarChar).Value = address;
                    cmd.Parameters.Add("@" + COL_DB_PHONE1, SqlDbType.VarChar).Value = phone1;
                    cmd.Parameters.Add("@" + COL_DB_PHONE2, SqlDbType.VarChar).Value = phone2;
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(conn, id, "Item created");
                }
                Tools.hasMessage("Item created");
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public string compileData()
        {
            string data = Name;

            if (!string.IsNullOrEmpty(Address))
                data += Environment.NewLine + Address;

            string phones = Tools.append(Phone1, Phone2, ",");
            if (!string.IsNullOrEmpty(phones))
                data += Environment.NewLine + phones;

            return data;
        }

        public static bool isNameExist(string name, Guid? id)
        {
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("transport_isNameExist", conn))
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
            return DBUtil.getRows("transport_get", ID);
        }

        public static DataTable getByFilter(bool includeInactive)
        {
            return getByFilter(includeInactive, null);
        }

        public static DataTable getByFilter(bool includeInactive, string nameFilter)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
            using (SqlCommand cmd = new SqlCommand("transport_get_byFilter", conn))
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

        public static void update(Guid id, string name, string address, string phone1, string phone2, string notes)
        {
            try
            {
                Transport objOld = new Transport(id);

                //generate log description
                string logDescription = "";
                if (objOld.Name != name) logDescription = Tools.append(logDescription, String.Format("Name: '{0}' to '{1}'", objOld.Name, name), ",");
                if (objOld.Address != address) logDescription = Tools.append(logDescription, String.Format("Address: '{0}' to '{1}'", objOld.Address, address), ",");
                if (objOld.Phone1 != phone1) logDescription = Tools.append(logDescription, String.Format("Phone 1: '{0}' to '{1}'", objOld.Phone1, phone1), ",");
                if (objOld.Phone2 != phone2) logDescription = Tools.append(logDescription, String.Format("Phone 2: '{0}' to '{1}'", objOld.Phone2, phone2), ",");
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");

                if (string.IsNullOrEmpty(logDescription))
                {
                    Tools.showError("No changes to record");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
                    using (SqlCommand cmd = new SqlCommand("transport_update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_NAME, SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@" + COL_DB_ADDRESS, SqlDbType.VarChar).Value = address;
                        cmd.Parameters.Add("@" + COL_DB_PHONE1, SqlDbType.VarChar).Value = phone1;
                        cmd.Parameters.Add("@" + COL_DB_PHONE2, SqlDbType.VarChar).Value = phone2;
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = notes;

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(conn, id, "Update: " + logDescription);
                    }
                    Tools.hasMessage("Item updated");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }
        
        public static string updateActiveStatus(Guid id, Boolean activeStatus)
        {
            return DBUtil.updateActiveStatus("transport_update_active", id, activeStatus);
        }

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist, bool includeInactive, bool showDefault)
        {
            Tools.populateDropDownList(dropdownlist, getByFilter(includeInactive).DefaultView, COL_DB_NAME, COL_DB_ID, showDefault);
        }

    }
}
