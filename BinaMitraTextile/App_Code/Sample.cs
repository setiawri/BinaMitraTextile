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

        public static Guid? add(string storageName, string vendorName, string vendorInfo, string description, DateTime? priceDate, decimal? pricePerUnit, DateTime? discontinueDate, string notes, Guid? lengthUnitID, decimal? sellPricePerUnit)
        {
            Guid Id = Guid.NewGuid();
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.ExecuteNonQuery,
                "sample_add",
                new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, Id),
                new SqlQueryParameter(COL_DB_STORAGENAME, SqlDbType.VarChar, storageName),
                new SqlQueryParameter(COL_DB_VENDORNAME, SqlDbType.VarChar, vendorName),
                new SqlQueryParameter(COL_DB_VENDORINFO, SqlDbType.VarChar, vendorInfo),
                new SqlQueryParameter(COL_DB_DESCRIPTION, SqlDbType.VarChar, description),
                new SqlQueryParameter(COL_DB_PRICEDATE, SqlDbType.DateTime, Util.wrapNullable(priceDate)),
                new SqlQueryParameter(COL_DB_PRICEPERUNIT, SqlDbType.Decimal, Util.wrapNullable(pricePerUnit)),
                new SqlQueryParameter(COL_DB_DISCONTINUEDATE, SqlDbType.DateTime, Util.wrapNullable(discontinueDate)),
                new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(lengthUnitID)),
                new SqlQueryParameter(COL_DB_SELLPRICEPERUNIT, SqlDbType.Decimal, Util.wrapNullable(sellPricePerUnit)),
                new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
            );

            if (!result.IsSuccessful)
                return null;
            else
            {
                ActivityLog.submit(Id, "Added");
                return Id;
            }
        }

        public static void update(Guid id, string storageName, string vendorName, string vendorInfo, string description, DateTime? priceDate, decimal? pricePerUnit, DateTime? discontinueDate, string notes, Guid? lengthUnitID, decimal? sellPricePerUnit)
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

            if (!string.IsNullOrEmpty(logDescription))
            {
                SqlQueryResult result = DBConnection.query(
                    false,
                    DBConnection.ActiveSqlConnection,
                    QueryTypes.ExecuteNonQuery,
                    "sample_update",
                    new SqlQueryParameter(COL_DB_ID, SqlDbType.UniqueIdentifier, id),
                    new SqlQueryParameter(COL_DB_STORAGENAME, SqlDbType.VarChar, storageName),
                    new SqlQueryParameter(COL_DB_VENDORNAME, SqlDbType.VarChar, vendorName),
                    new SqlQueryParameter(COL_DB_VENDORINFO, SqlDbType.VarChar, vendorInfo),
                    new SqlQueryParameter(COL_DB_DESCRIPTION, SqlDbType.VarChar, description),
                    new SqlQueryParameter(COL_DB_PRICEDATE, SqlDbType.DateTime, Util.wrapNullable(priceDate)),
                    new SqlQueryParameter(COL_DB_PRICEPERUNIT, SqlDbType.Decimal, Util.wrapNullable(pricePerUnit)),
                    new SqlQueryParameter(COL_DB_DISCONTINUEDATE, SqlDbType.DateTime, Util.wrapNullable(discontinueDate)),
                    new SqlQueryParameter(COL_DB_LENGTHUNITID, SqlDbType.UniqueIdentifier, Util.wrapNullable(lengthUnitID)),
                    new SqlQueryParameter(COL_DB_SELLPRICEPERUNIT, SqlDbType.Decimal, Util.wrapNullable(sellPricePerUnit)),
                    new SqlQueryParameter(COL_DB_NOTES, SqlDbType.VarChar, Util.wrapNullable(notes))
                );

                if (result.IsSuccessful)
                    ActivityLog.submit(id, "Update: " + logDescription);
            }
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("sample_get", ID);
        }

        public static DataTable get(string storageName, string vendorName, string vendorInfo, string description)
        {
            SqlQueryResult result = DBConnection.query(
                false,
                DBConnection.ActiveSqlConnection,
                QueryTypes.FillByAdapter,
                "sample_get_byFilter",
                new SqlQueryParameter(COL_DB_STORAGENAME, SqlDbType.VarChar, Util.wrapNullable(storageName)),
                new SqlQueryParameter(COL_DB_VENDORNAME, SqlDbType.VarChar, Util.wrapNullable(vendorName)),
                new SqlQueryParameter(COL_DB_VENDORINFO, SqlDbType.VarChar, Util.wrapNullable(vendorInfo)),
                new SqlQueryParameter(COL_DB_DESCRIPTION, SqlDbType.VarChar, Util.wrapNullable(description))
            );
            return result.Datatable;
        }
    }
}
