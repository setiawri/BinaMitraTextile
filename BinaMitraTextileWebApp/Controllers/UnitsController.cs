using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using BinaMitraTextileWebApp.Models;
using LIBUtil;

namespace BinaMitraTextileWebApp.Controllers
{
    public class UnitsController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* FILTER *********************************************************************************************************************************************/

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;
        }

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).Units_View)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                return View(get(FILTER_Keyword, FILTER_Active));
            }
        }

        [HttpPost]
        public ActionResult Index(string FILTER_Keyword, int? FILTER_Active)
        {
            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get(FILTER_Keyword, FILTER_Active));
        }

        /* CREATE *********************************************************************************************************************************************/

        public ActionResult Create(string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).Units_Add)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(new UnitsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitsModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.Name))
                    ModelState.AddModelError(UnitsModel.COL_Name.Name, $"{model.Name} exists. Please change.");
                else
                {
                    model.Id = Guid.NewGuid();
                    model.Active = true;
                    db.Units.Add(model);
                    db.SaveChanges();
                    ActivityLogsController.AddCreateLog(db, Session, model.Id);
                    return RedirectToAction(nameof(Index), new { id = model.Id, FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(model);
        }

        /* EDIT ***********************************************************************************************************************************************/

        public ActionResult Edit(Guid? id, string FILTER_Keyword, int? FILTER_Active)
        {
            //if (!UserAccountsController.getUserAccess(Session).Units_Edit)
            //    return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UnitsModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.Name))
                    ModelState.AddModelError(UnitsModel.COL_Name.Name, $"{modifiedModel.Name} exists. Please change.");
                else
                {
                    UnitsModel originalModel = db.Units.AsNoTracking().Where(x => x.Id == modifiedModel.Id).FirstOrDefault();

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, modifiedModel.Name, UnitsModel.COL_Name.LogDisplay);
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, UnitsModel.COL_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, UnitsModel.COL_Active.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                    {
                        db.Entry(modifiedModel).State = EntityState.Modified;
                        db.SaveChanges();
                        ActivityLogsController.AddEditLog(db, Session, modifiedModel.Id, log);
                    }

                    return RedirectToAction(nameof(Index), new { FILTER_Keyword = FILTER_Keyword, FILTER_Active = FILTER_Active });
                }
            }

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(modifiedModel);
        }

        /* METHODS ********************************************************************************************************************************************/

        public static void setDropDownListViewBag(ControllerBase controller)
        {
            controller.ViewBag.Units = new SelectList(get(), UnitsModel.COL_Id.Name, UnitsModel.COL_Name.Name);
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Name)
        {
            return LIBWebMVC.WebDBConnection.IsExist(db.Database, "Units",
                DBConnection.getSqlParameter(UnitsModel.COL_Id.Name, Id),
                DBConnection.getSqlParameter(UnitsModel.COL_Name.Name, Name)
            );
        }

        public static List<UnitsModel> get(int? FILTER_Active, string IdList) { return get(null, FILTER_Active, null, IdList); }
        public List<UnitsModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword, null); }
        public UnitsModel get(Guid Id) { return get(Id, null, null, null).FirstOrDefault(); }
        public static List<UnitsModel> get() { return get(null, null, null, null); }
        public static List<UnitsModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword, string IdList)
        {
            string IdListClause = "";
            if (!string.IsNullOrEmpty(IdList))
                IdListClause = string.Format(" AND Units.Id IN ({0}) ", LIBWebMVC.UtilWebMVC.convertToSqlIdList(IdList));

            string sql = string.Format(@"
                        SELECT Units.*
                        FROM Units
                        WHERE 1=1
							AND (@Id IS NULL OR Units.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR Units.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (Units.Name LIKE '%'+@FILTER_Keyword+'%'))
                                {0}
                            ))
						ORDER BY Units.Name ASC
                    ", IdListClause);

            return new DBContext().Database.SqlQuery<UnitsModel>(sql,
                    DBConnection.getSqlParameter(UnitsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(UnitsModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword),
                    DBConnection.getSqlParameter("IdList", IdList)
                ).ToList();
        }

        /******************************************************************************************************************************************************/
    }
}