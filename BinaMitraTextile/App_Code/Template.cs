using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BinaMitraTextile.App_Code
{
    class Template
    {
        /*******************************************************************************************************/
        #region PUBLIC VARIABLES
        #endregion PUBLIC VARIABLES
        /*******************************************************************************************************/
        #region CLASS VARIABLES
        #endregion CLASS VARIABLES
        /*******************************************************************************************************/
        #region DATABASE COLUMNS

        public const string COL_DB_ID = "id";

        #endregion DATABASE COLUMNS
        /*******************************************************************************************************/
        #region CONSTRUCTORS
        #endregion CONSTRUCTORS
        /*******************************************************************************************************/
        #region DATABASE METHODS
        #endregion DATABASE METHODS
        /*******************************************************************************************************/
        #region DATABASE STATIC METHODS

        //public static DataTable getAll(DateTime? dateStart)
        //{
        //    DataTable dataTable = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(DBUtil.connectionString))
        //    using (SqlCommand cmd = new SqlCommand("sale_getall", conn))
        //    using (SqlDataAdapter adapter = new SqlDataAdapter())
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@date_start", SqlDbType.DateTime).Value = (object)dateStart ?? DBNull.Value;

        //        adapter.SelectCommand = cmd;
        //        adapter.Fill(dataTable);
        //    }

        //    return dataTable;
        //}

        #endregion DATABASE STATIC METHODS
        /*******************************************************************************************************/
        #region CLASS METHODS
        #endregion CLASS METHODS
        /*******************************************************************************************************/

    }
}
