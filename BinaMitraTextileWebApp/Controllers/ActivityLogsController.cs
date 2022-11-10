using BinaMitraTextileWebApp.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class ActivityLogsController : Controller
    {
        private readonly DBContext db = new DBContext();

        public static string editListStringFormat(string fieldName) { return fieldName + ": {0}"; }
        public static string editStringFormat(string fieldName) { return fieldName + ": '{0}' to '{1}'"; }
        public static string editStringFormat2(string fieldName) { return fieldName + ": '{0}'"; }
        public static string editStringFormat3(string fieldName) { return fieldName + ": '{1}'"; }
        public static string editIntFormat(string fieldName) { return fieldName + ": '{0:N0}' to '{1:N0}'"; }
        public static string editDateFormat(string fieldName) { return fieldName + ": '{0:dd/MM/yyyy}' to '{1:dd/MM/yyyy}'"; }
        public static string editTimeFormat(string fieldName) { return fieldName + ": '{0:HH:mm}' to '{1:HH:mm}'"; }
        public static string editDateTimeFormat(string fieldName) { return fieldName + ": '{0:dd/MM/yyyy HH:mm}' to '{1:dd/MM/yyyy HH:mm}'"; }
        public static string editDecimalFormat(string fieldName) { return fieldName + ": '{0:G29}' to '{1:G29}'"; }
        public static string editBooleanFormat(string fieldName) { return fieldName + ": {1}"; }

        /* DISPLAY LOG ****************************************************************************************************************************************/

        public JsonResult Ajax_GetLog(Guid ReferenceId)
        {
            string message = @"<div class='table-responsive'>
                                    <table class='table table-striped table-bordered'>
                                        <thead>
                                            <tr>
                                                <th style='width:150px'>Timestamp</th>
                                                <th>Description</th>
                                                <th>User</th>
                                            </tr>
                                        </thead>
                                        <tbody>";

            foreach (ActivityLogsModel item in get(ReferenceId))
            {
                message += string.Format(@"
                            <tr>
                                <td class='align-top'>{0:dd/MM/yy HH:mm}</td>
                                <td class='align-top'>{1}</td>
                                <td class='align-top'>{2}</td>
                            </tr>
                    ", item.Timestamp, item.Description.Replace(Environment.NewLine, "<BR>"), item.UserAccounts_Fullname);
            }

            message += "</tbody></table></div>";
            return Json(new { content = message }, JsonRequestBehavior.AllowGet);
        }

        /* ADD ************************************************************************************************************************************************/

        public static void AddEditLog(DBContext db, HttpSessionStateBase Session, Guid ReferenceId, string log) { Add(db, Session, ReferenceId, "UPDATE:<BR>" + log); }
        public static void AddCreateLog(DBContext db, HttpSessionStateBase Session, Guid ReferenceId) { Add(db, Session, ReferenceId, "Created"); }
        public static void Add(DBContext db, HttpSessionStateBase Session, Guid ReferenceId, string description)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "ActivityLogs",
                DBConnection.getSqlParameter(ActivityLogsModel.COL_Id.Name, Guid.NewGuid()),
                DBConnection.getSqlParameter(ActivityLogsModel.COL_Timestamp.Name, Helper.getCurrentDateTime()),
                DBConnection.getSqlParameter(ActivityLogsModel.COL_ReferenceId.Name, ReferenceId),
                DBConnection.getSqlParameter(ActivityLogsModel.COL_Description.Name, description),
                DBConnection.getSqlParameter(ActivityLogsModel.COL_UserAccounts_Id.Name, (Guid)UsersController.getUserId(Session))
            );
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public List<ActivityLogsModel> get(Guid ReferenceId)
        {
            return db.Database.SqlQuery<ActivityLogsModel>(@"
                        SELECT ActivityLogs.*,
                            Users.id AS UserAccounts_Id,
                            Users.username AS UserAccounts_Fullname
                        FROM ActivityLogs
                            LEFT JOIN Users ON Users.id = ActivityLogs.UserAccounts_Id
                        WHERE 1=1 
    						AND (@ReferenceId IS NULL OR ActivityLogs.ReferenceId = @ReferenceId)
						ORDER BY ActivityLogs.Timestamp DESC
                    ",
                    DBConnection.getSqlParameter(ActivityLogsModel.COL_ReferenceId.Name, ReferenceId)
                ).ToList();
        }

        /******************************************************************************************************************************************************/
    }
}