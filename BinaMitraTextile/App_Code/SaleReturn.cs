using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile
{
    public class SaleReturn
    {
        /*******************************************************************************************************/
        #region CLASS VARIABLES

        public const string COL_ID = "id";
        public const string COL_BARCODE = "barcode";
        public const string COL_HEXBARCODE = "hexbarcode";
        public const string COL_PRICEPERUNIT = "price_per_unit";
        public const string COL_INVENTORYCODE = "inventory_code";
        public const string COL_Checked = "Checked";

        public const string COL_RETURNAMOUNT = "sale_amount";
        public const string COL_SALESMANID = "salesman_id";
        public const string COL_SALESMANNAME = "salesman_name";

        public Guid id;
        public DateTime time_stamp;
        public bool voided;
        public Guid user_id;
        public Guid customer_id;
        public string notes = "";
        public string barcode = "";
        private DataTable saleReturnItems;
        public string customer_info = "";

        public decimal ReturnAmount = 0;

        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region CONSTRUCTORS

        public SaleReturn(Guid ID)
        {
            id = ID;
            DataTable dt = getRow(ID);
            time_stamp = Convert.ToDateTime(dt.Rows[0]["time_stamp"]);
            voided = (Boolean)dt.Rows[0]["voided"];
            user_id = (Guid)dt.Rows[0]["user_id"];
            customer_id = (Guid)dt.Rows[0]["customer_id"];
            notes = dt.Rows[0]["notes"].ToString();
            customer_info = dt.Rows[0]["customer_info"].ToString();
            barcode = dt.Rows[0]["barcode"].ToString();

            //ReturnAmount = DBUtil.parseData<decimal>(dt.Rows[0], COL_RETURNAMOUNT);
        }

        public SaleReturn(string Notes, DataTable SaleReturnItems)
        {
            id = Guid.NewGuid();
            time_stamp = DateTime.Now;
            voided = false;
            user_id = GlobalData.UserAccount.id;
            notes = Notes;
            saleReturnItems = SaleReturnItems;
        }

        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region CLASS METHODS

        public static DataTable compileSummaryData(DataTable dt)
        {
            DataTable dtSummary = dt.Clone();
            Tools.setDataTablePrimaryKey(dtSummary, SaleItem.COL_INVENTORY_ID);

            DataRow tempRow;
            foreach (DataRow dr in dt.Rows)
            {
                if (dtSummary.Rows.Contains(dr[SaleItem.COL_INVENTORY_ID]))
                {
                    tempRow = dtSummary.Rows.Find(dr[SaleItem.COL_INVENTORY_ID]);
                    tempRow[SaleItem.COL_QTY] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_QTY]) + Tools.zeroNonNumericString(dr[SaleItem.COL_QTY]);
                    tempRow[SaleItem.COL_LENGTH] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_LENGTH]) + Tools.zeroNonNumericString(dr[SaleItem.COL_LENGTH]);
                    tempRow[SaleItem.COL_SUBTOTAL] = Tools.zeroNonNumericString(tempRow[SaleItem.COL_SUBTOTAL]) + Tools.zeroNonNumericString(dr[SaleItem.COL_SUBTOTAL]);
                    dtSummary.AcceptChanges();
                }
                else
                {
                    dtSummary.Rows.Add(dr.ItemArray);
                }
            }

            return dtSummary;
        }


        #endregion CLASS METHODS
        /*******************************************************************************************************/
        #region DATABASE METHODS

        public string submitNew()
        {
            try
            {
                //submit new sale record
                using (SqlCommand cmd = new SqlCommand("salereturn_new", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@time_stamp", SqlDbType.DateTime).Value = time_stamp;
                    cmd.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = user_id;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = notes;
                    SqlParameter return_value = cmd.Parameters.Add("@return_value", SqlDbType.Int);
                    return_value.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    barcode = Tools.getHex(Convert.ToInt32(return_value.Value), Settings.saleBarcodeLength);

                    //ActivityLog.submit(id, "New Sale Return added");
                }

                //mark sale items as returned
                foreach (DataRow row in saleReturnItems.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("saleitem_return", DBUtil.ActiveSqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = (Guid)row[SaleItem.COL_ID];
                        cmd.Parameters.Add("@return_id", SqlDbType.UniqueIdentifier).Value = id;

                        cmd.ExecuteNonQuery();

                        ActivityLog.submit((Guid)row[SaleItem.COL_ID], "Sale Item returned in sale return ID: " + id.ToString());
                        ActivityLog.submit((Guid)row[SaleItem.COL_INVENTORY_ITEM_ID], "Returned in sale return ID: " + barcode);
                    }
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        public static DataTable getRow(Guid ID)
        {
            return DBUtil.getRows("salereturn_get", ID);
        }

        public static DataTable getAll(DateTime? dateStart, DateTime? dateEnd, Guid? inventoryID, Guid? customerID, Guid? saleReturnID, bool onlyWithCommission)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand cmd = new SqlCommand("salereturn_getall", DBUtil.ActiveSqlConnection))
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;
                cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = (object)dateEnd ?? DBNull.Value;
                cmd.Parameters.Add("@inventory_item_id", SqlDbType.UniqueIdentifier).Value = (object)inventoryID ?? DBNull.Value;
                cmd.Parameters.Add("@customer_id", SqlDbType.UniqueIdentifier).Value = (object)customerID ?? DBNull.Value;
                cmd.Parameters.Add("@salereturn_id", SqlDbType.UniqueIdentifier).Value = (object)saleReturnID ?? DBNull.Value;
                if (onlyWithCommission) cmd.Parameters.Add("@" + SaleReturn.COL_SALESMANID, SqlDbType.UniqueIdentifier).Value = GlobalData.UserAccount.id;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);

                //Tools.addColumn<string>(dataTable, COL_HEXBARCODE, "");
                //foreach (DataRow dr in dataTable.Rows)
                //{
                //    dr[COL_HEXBARCODE] = Tools.getHex((int)dr[COL_BARCODE], Settings.saleBarcodeLength);
                //}
            }

            return dataTable;
        }

        public static string updateCheckedStatus(Guid id, bool value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SaleReturns_update_Checked", DBUtil.ActiveSqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@" + COL_ID, SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("@" + COL_Checked, SqlDbType.Bit).Value = value;

                    cmd.ExecuteNonQuery();

                    ActivityLog.submit(id, "Checked status changed to: " + value.ToString().ToLower());
                }
            }
            catch (Exception ex) { return ex.Message; }

            return string.Empty;
        }

        #endregion DATABASE METHODS
        /*******************************************************************************************************/

    }
}
