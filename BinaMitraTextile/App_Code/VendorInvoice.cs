using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace BinaMitraTextile
{
    public enum VendorInvoiceStatus
    {
        New,
        Cancelled,
        [Description("Paid Partial")]
        PaidPartial,
        [Description("Paid Full")]
        PaidFull
    };

    public class VendorInvoice
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES

        public Guid ID;
        public DateTime Timestamp;
        public string InvoiceNo;
        public string Notes;
        public string TaxNo;
        public decimal TaxDPP;
        public VendorInvoiceStatus Status;
        public int TOP;
        public bool SetorTunai;
        public Guid? VendorId;

        public decimal TotalDppPPN;
        public decimal TotalActualValue;
        public string VendorName;

        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_ID = "id";
        public const string COL_DB_TIMESTAMP = "timestamp";
        public const string COL_DB_STATUSENUMID = "status_enum_id";
        public const string COL_DB_INVOICENO = "invoice_no";
        public const string COL_DB_NOTES = "notes";
        public const string COL_DB_TAXNO = "tax_no";
        public const string COL_DB_TAXDPP = "tax_dpp";
        public const string COL_DB_TOP = "top";
        public const string COL_DB_SetorTunai = "SetorTunai";

        public const string COL_STATUSNAME = "status_name";
        public const string COL_TOTALDPPPPN = "total_dpp_ppn";
        public const string COL_TOTALACTUALVALUE = "total_actual_value";
        public const string COL_ISDUE = "is_due";
        public const string COL_PASTDUE = "pastdue";
        public const string COL_PayableAmount = "PayableAmount";
        public const string COL_VendorName = "VendorName";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public VendorInvoice(Guid id)
        {
            DataRow row = get(id, null, true).Rows[0];
            ID = id;
            Timestamp = DBUtil.parseData<DateTime>(row, COL_DB_TIMESTAMP);
            InvoiceNo = DBUtil.parseData<string>(row, COL_DB_INVOICENO);
            TaxNo = DBUtil.parseData<string>(row, COL_DB_TAXNO);
            TaxDPP = DBUtil.parseData<decimal>(row, COL_DB_TAXDPP);
            Notes = DBUtil.parseData<string>(row, COL_DB_NOTES);
            Status = Tools.parseEnum<VendorInvoiceStatus>(DBUtil.parseData<Int16>(row, COL_DB_STATUSENUMID));
            TOP = DBUtil.parseData<int>(row, COL_DB_TOP);
            SetorTunai = DBUtil.parseData<bool>(row, COL_DB_SetorTunai);

            TotalDppPPN = DBUtil.parseData<decimal>(row, COL_TOTALDPPPPN);
            TotalActualValue = DBUtil.parseData<decimal>(row, COL_TOTALACTUALVALUE);
            VendorName = DBUtil.parseData<string>(row, COL_VendorName);
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        public static bool isInvoiceNoExist(Guid? id, string invoiceNo)
        {
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_isInvoiceNoExist", DBUtil.ActiveSqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_INVOICENO, SqlDbType.VarChar).Value = invoiceNo;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Bit);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return Convert.ToBoolean(return_value.Value);
            }
        }

        public static Guid? get(string invoiceNumber)
        {
            Guid? id;
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_get_by_invoiceNo", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_INVOICENO, SqlDbType.VarChar).Value = invoiceNumber;
                SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.UniqueIdentifier);
                return_value.Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                id = (Guid?)return_value.Value;
            }
            return id;
        }

        public static DataTable get(Guid ID)
        {
            return get(ID, null, true);
        }

        public static DataTable get(Guid? id, string invoiceNumber, bool includeCompleted)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("vendorinvoice_get", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = Tools.wrapNullable(id);
                cmd.Parameters.Add("@" + COL_DB_INVOICENO, SqlDbType.VarChar).Value = Tools.wrapNullable(invoiceNumber);
                cmd.Parameters.Add("@include_completed", SqlDbType.Bit).Value = includeCompleted;
                cmd.Parameters.Add("@status_completed", SqlDbType.TinyInt).Value = VendorInvoiceStatus.PaidFull;
                cmd.Parameters.Add("@status_cancelled", SqlDbType.TinyInt).Value = VendorInvoiceStatus.Cancelled;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }

            return Tools.parseEnum<VendorInvoiceStatus>(dataTable, COL_STATUSNAME, COL_DB_STATUSENUMID);
        }

        public static Guid add(string invoiceNo)
        {
            Guid id = Guid.NewGuid();
            try
            {
                using (SqlCommand cmd = new SqlCommand("vendorinvoice_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_INVOICENO, SqlDbType.VarChar).Value = invoiceNo;
                    cmd.Parameters.Add("@" + COL_DB_STATUSENUMID, SqlDbType.TinyInt).Value = VendorInvoiceStatus.New;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Item created");
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }

            return id;
        }

        public static void updateStatus(Guid id, VendorInvoiceStatus statusEnumID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("vendorinvoice_update_status", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_DB_STATUSENUMID, SqlDbType.TinyInt).Value = statusEnumID;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Status changed to: " + statusEnumID.ToString());
                }
            }
            catch (Exception ex) { Tools.showError(ex.Message); }
        }

        public static string update(Guid id, string invoiceNo, string taxNo, decimal taxDPP, int top, bool setorTunai, string notes)
        {
            try
            {
                VendorInvoice objOld = new VendorInvoice(id);

                //generate log description
                string logDescription = "";
                logDescription = ActivityLog.appendChange(logDescription, objOld.InvoiceNo, invoiceNo, "Invoice No: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.TaxNo, taxNo, "Tax No: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.TaxDPP, taxDPP, "Tax DPP: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.TOP, top, "TOP: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.SetorTunai, setorTunai, "Setor Tunai: '{0}' to '{1}'");
                logDescription = ActivityLog.appendChange(logDescription, objOld.Notes, notes, "Notes: '{0}' to '{1}'");

                if (string.IsNullOrEmpty(logDescription))
                {
                    return "No info to update";
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("vendorinvoice_update", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@" + COL_DB_ID, SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@" + COL_DB_INVOICENO, SqlDbType.VarChar).Value = invoiceNo;
                        cmd.Parameters.Add("@" + COL_DB_TAXNO, SqlDbType.VarChar).Value = taxNo;
                        cmd.Parameters.Add("@" + COL_DB_TAXDPP, SqlDbType.Decimal).Value = taxDPP;
                        cmd.Parameters.Add("@" + COL_DB_TOP, SqlDbType.Int).Value = top;
                        cmd.Parameters.Add("@" + COL_DB_SetorTunai, SqlDbType.Bit).Value = setorTunai;
                        cmd.Parameters.Add("@" + COL_DB_NOTES, SqlDbType.VarChar).Value = Tools.wrapNullable(notes);

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit(id, "Update: " + logDescription);
                    }
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static void populateDropDownList(System.Windows.Forms.ComboBox dropdownlist)
        {
            Tools.populateDropDownList(dropdownlist, get(null, null, false).DefaultView, COL_DB_INVOICENO, COL_DB_ID, false);
        }

        #endregion CLASS METHODS
        /*******************************************************************************************************/
    }
}
