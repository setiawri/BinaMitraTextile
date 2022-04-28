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
            db.ActivityLogs.Add(new ActivityLogsModel
            {
                Id = Guid.NewGuid(),
                ReferenceId = ReferenceId,
                Timestamp = Helper.getCurrentDateTime(),
                Description = description,
                UserAccounts_Id = (Guid)UsersController.getUserId(Session),
                UserAccounts_Fullname = UsersController.getUserAccount(Session).username
            });
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
                        WHERE ActivityLogs.ReferenceId = @ReferenceId
						ORDER BY ActivityLogs.Timestamp DESC
                    ",
                    DBConnection.getSqlParameter(ActivityLogsModel.COL_ReferenceId.Name, ReferenceId)
                ).ToList();
        }

        /******************************************************************************************************************************************************/
    }
}