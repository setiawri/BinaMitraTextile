using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

using BinaMitraTextileWebApp.Models;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class InventoryChecksController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* FILTER *********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
        }

        /* INDEX **********************************************************************************************************************************************/

        // GET: StudentSchedules
        public ActionResult Input(int? rss, string FILTER_Keyword)
        {
            setViewBag(FILTER_Keyword);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                return View();
            }
        }

        // POST: StudentSchedules
        [HttpPost]
        public ActionResult Input(string FILTER_Keyword)
        {
            setViewBag(FILTER_Keyword);
            return View();
        }

        /* METHODS ********************************************************************************************************************************************/

        public async Task<JsonResult> Ajax_Add(string param)
        {
            string[] parameters = param.Split('|');
            string item_no = parameters[0];
            string barcode = parameters[1];
            string location = parameters[2];
            bool isScanner = Convert.ToBoolean(parameters[3]);
            string timestamp = parameters[4];
            bool rescanToday = Convert.ToBoolean(parameters[5]);

            string result = "";
            
            if (!isScanner)
                result += "<span class='text-danger font-weight-bold'>[MANUAL]</span> ";
            
            string errorMessage = await get(barcode, !isScanner, false, rescanToday, location);

            if (string.IsNullOrEmpty(errorMessage))
                result += "<span class='text-success font-weight-bold'>[OK]</span> ";
            else
                result += errorMessage;

            return Json(new { Message = "", 
                item_no = item_no, 
                error = !string.IsNullOrEmpty(errorMessage) || !isScanner, 
                timestamp = timestamp, 
                location = location,
                barcode = barcode,
                usingScanner = isScanner,
                result = result 
            });
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public async Task<string> get(string barcodeWithoutPrefix, bool isManualInput, bool ignoreSold, bool rescanToday, string itemLocation)
        {
            await Task.Delay(500);

            SqlQueryResult result = DBConnection.executeQuery(db.Database.Connection.ConnectionString, "inventoryitemcheck_new", true, 
                false, true, false, false, false,
                new SqlQueryParameter(InventoryChecksModel.COL_Id.Name, SqlDbType.UniqueIdentifier, Util.wrapNullable(Guid.NewGuid())),
                new SqlQueryParameter("BarcodeWithoutPrefix", SqlDbType.VarChar, Util.wrapNullable(barcodeWithoutPrefix)),
                new SqlQueryParameter("user_id", SqlDbType.UniqueIdentifier, Util.wrapNullable(UsersController.getUserId(Session))),
                new SqlQueryParameter("manual_input", SqlDbType.Bit, Util.wrapNullable(isManualInput)),
                new SqlQueryParameter("RescanToday", SqlDbType.Bit, Util.wrapNullable(rescanToday)),
                new SqlQueryParameter("IgnoreSold", SqlDbType.Bit, Util.wrapNullable(ignoreSold)),
                new SqlQueryParameter("ItemLocation", SqlDbType.VarChar, Util.wrapNullable(itemLocation))
            );

            int errorcode = result.ValueInt;
            if (errorcode > 0)
            {
                if (errorcode == 1)
                    return barcodeWithoutPrefix + " is not found in database";
                if (errorcode == 2)
                    return barcodeWithoutPrefix + " is already scanned today";
                if (errorcode == 3 && !ignoreSold)
                    return barcodeWithoutPrefix + " is already sold";
            }

            return string.Empty;
        }

        public void add(InventoryChecksModel model)
        {
            //LIBWebMVC.WebDBConnection.Insert(db.Database, "StudentSchedules",
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_Id.Name, model.Id),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_Tutor_UserAccounts_Id.Name, model.Tutor_UserAccounts_Id),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_Student_UserAccounts_Id.Name, model.Student_UserAccounts_Id),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_DayOfWeek.Name, model.DayOfWeek),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_StartTime.Name, model.StartTime),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_EndTime.Name, model.EndTime),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_SaleInvoiceItems_Id.Name, model.SaleInvoiceItems_Id),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_LessonLocation.Name, model.LessonLocation),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_Active.Name, model.Active),
            //    DBConnection.getSqlParameter(InventoryChecksModel.COL_Notes.Name, model.Notes)
            //);
            //ActivityLogsController.AddCreateLog(db, Session, model.Id);
            //db.SaveChanges();
        }

        /******************************************************************************************************************************************************/
    }
}