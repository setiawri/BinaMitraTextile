using System;
using System.Data;
using System.Data.SqlClient;
using LIBUtil;

namespace BinaMitraTextile
{
    public class Sample
    {
        public const string COL_DB_ID = "id";
        public const string COL_DB_SAMPLENO = "sample_no";
        public const string COL_DB_STORAGENAME = "storage_name";
        public const string COL_DB_VENDORNAME = "vendor_name";
        public const string COL_DB_VENDORINFO = "vendor_info";
        public const string COL_DB_DESCRIPTION = "description";
        public const string COL_DB_PRICEDATE = "price_date";
        public const string COL_DB_PRICEPERUNIT = "price_per_unit";
        public const string COL_DB_DISCONTINUEDATE = "discontinue_date";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_LENGTHUNITID = "lengthunit_id";
        public const string COL_DB_SELLPRICEPERUNIT = "sell_price_per_unit";

        public const string COL_LENGTHUNITNAME = "lengthunit_name";

        public Guid ID;
        public int SampleNo;
        public string StorageName = "";
        public string VendorName = "";
        public string VendorInfo = "";
        public string Description = "";
        public DateTime? PriceDate;
        public decimal? PricePerUnit;
        public DateTime? DiscontinueDate;
        public string Notes = "";
        public decimal? SellPricePerUnit;
        public Guid? LengthUnitID;

        public string LengthUnitName;

        public Sample() { }

        public Sample(Guid id)
        {
            ID = id;
            DataRow row = getRow(ID).Rows[0];
            SampleNo = DBUtil.parseData<int>(row, COL_DB_SAMPLENO);
            StorageName = DBUtil.parseData<string>(row, COL_DB_STORAGENAME);
            VendorName = DBUtil.parseData<string>(row, COL_DB_VENDORNAME);
            VendorInfo = DBUtil.parseData<string>(row, COL_DB_VENDORINFO);
            Description = DBUtil.parseData<string>(row, COL_DB_DESCRIPTION);
            PriceDate = DBUtil.parseData<DateTime?>(row, COL_DB_PRICEDATE);
            PricePerUnit = DBUtil.parseData<decimal?>(row, COL_DB_PRICEPERUNIT);
            DiscontinueDate = DBUtil.parseData<DateTime?>(row, COL_DB_DISCONTINUEDATE);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
            SellPricePerUnit = DBUtil.parseData<decimal?>(row, COL_DB_SELLPRICEPERUNIT);
            LengthUnitID = DBUtil.parseData<Guid?>(row, COL_DB_LENGTHUNITID);

            LengthUnitName = DBUtil.parseData<string>(row, COL_LENGTHUNITNAME);

        }

        public static void add(string storageName, string vendorName, string vendorInfo, string description, DateTime? priceDate, decimal? pricePerUnit, DateTime? discontinueDate, string notes, Guid? lengthUnitID, decimal? sellPricePerUnit)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sample_add", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STORAGENAME, SqlDbType.VarChar).Value = storageName;
                    cmd.Parameters.Add("@" + COL_DB_VENDORNAME, SqlDbType.VarChar).Value = vendorName;
                    cmd.Parameters.Add("@" + COL_DB_VENDORINFO, SqlDbType.VarChar).Value = vendorInfo;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_PRICEDATE, SqlDbType.DateTime).Value = Tools.wrapNullable(priceDate);
                    cmd.Parameters.Add("@" + COL_DB_PRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(pricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_DISCONTINUEDATE, SqlDbType.DateTime).Value = Tools.wrapNullable(discontinueDate);
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(lengthUnitID);
                    cmd.Parameters.Add("@" + COL_DB_SELLPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellPricePerUnit);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "New item added");
                }
            } catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static void update(Guid id, string storageName, string vendorName, string vendorInfo, string description, DateTime? priceDate, decimal? pricePerUnit, DateTime? discontinueDate, string notes, Guid? lengthUnitID, decimal? sellPricePerUnit)
        {
            try
            {
                Sample objOld = new Sample(id);

                //generate log description
                string logDescription = "";
                if (objOld.StorageName != storageName) { logDescription = Tools.append(logDescription, String.Format("Storage Name: '{0}' to '{1}'", objOld.StorageName, storageName), ","); }
                if (objOld.VendorName != vendorName) logDescription = Tools.append(logDescription, String.Format("Vendor Name: '{0}' to '{1}'", objOld.VendorName, vendorName), ",");
                if (objOld.VendorInfo != vendorInfo) logDescription = Tools.append(logDescription, String.Format("Vendor Info: '{0}' to '{1}'", objOld.VendorInfo, vendorInfo), ",");
                if (objOld.Description != description) logDescription = Tools.append(logDescription, String.Format("Description: '{0}' to '{1}'", objOld.Description, description), ",");
                if (objOld.PriceDate != priceDate) { logDescription = Tools.append(logDescription, String.Format("Price Date: '{0:MM/dd/yy}' to '{1:MM/dd/yy}'", objOld.PriceDate, priceDate), ","); }
                if (objOld.PricePerUnit != pricePerUnit) { logDescription = Tools.append(logDescription, String.Format("Price Per Unit: '{0:N2}' to '{1:N2}'", objOld.PricePerUnit, pricePerUnit), ","); }
                if (objOld.DiscontinueDate != discontinueDate) { logDescription = Tools.append(logDescription, String.Format("Discontinue Date: '{0:MM/dd/yy}' to '{1:MM/dd/yy}'", objOld.DiscontinueDate, discontinueDate), ","); }
                if (objOld.Notes != notes) logDescription = Tools.append(logDescription, String.Format("Notes: '{0}' to '{1}'", objOld.Notes, notes), ",");
                logDescription = ActivityLog.appendChange(logDescription, objOld.SellPricePerUnit, sellPricePerUnit, "Sell Price: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.LengthUnitName, new LengthUnit(lengthUnitID).Name, "Unit: '{0}' to '{1}'");

                using (SqlCommand cmd = new SqlCommand("sample_update", DBConnection.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STORAGENAME, SqlDbType.VarChar).Value = storageName;
                    cmd.Parameters.Add("@" + COL_DB_VENDORNAME, SqlDbType.VarChar).Value = vendorName;
                    cmd.Parameters.Add("@" + COL_DB_VENDORINFO, SqlDbType.VarChar).Value = vendorInfo;
                    cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@" + COL_DB_PRICEDATE, SqlDbType.DateTime).Value = Tools.wrapNullable(priceDate);
                    cmd.Parameters.Add("@" + COL_DB_PRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(pricePerUnit);
                    cmd.Parameters.Add("@" + COL_DB_DISCONTINUEDATE, SqlDbType.DateTime).Value = Tools.wrapNullable(discontinueDate);
                    cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);
                    cmd.Parameters.Add("@" + COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(lengthUnitID);
                    cmd.Parameters.Add("@" + COL_DB_SELLPRICEPERUNIT, SqlDbType.Decimal).Value = Tools.wrapNullable(sellPricePerUnit);

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, String.Format("Item updated: {0}", logDescription));
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("sample_get", ID);
        }

        public static DataTable get(string storageName, string vendorName, string vendorInfo, string description)
        {
            //Tools.startProgressDisplay("Donwloading data...");

            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("sample_get_byFilter", DBConnection.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_STORAGENAME, SqlDbType.VarChar).Value = Tools.wrapNullable(storageName);
                cmd.Parameters.Add("@" + COL_DB_VENDORNAME, SqlDbType.VarChar).Value = Tools.wrapNullable(vendorName);
                cmd.Parameters.Add("@" + COL_DB_VENDORINFO, SqlDbType.VarChar).Value = Tools.wrapNullable(vendorInfo);
                cmd.Parameters.Add("@" + COL_DB_DESCRIPTION, SqlDbType.VarChar).Value = Tools.wrapNullable(description);

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            //Tools.stopProgressDisplay();

            return dataTable;
        }
    }
}
