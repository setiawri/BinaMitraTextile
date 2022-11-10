using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using LIBUtil;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp.Controllers
{
    public class MoneyAccountCategoriesController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, string FILTER_Keyword, int? FILTER_Active)
        {
            if (!UsersController.getUserAccess(Session).MoneyAccountCategories_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

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
            if (!UsersController.getUserAccess(Session).MoneyAccountCategories_Add)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyAccountCategoriesModel model, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(null, model.Name))
                    ModelState.AddModelError(MoneyAccountCategoriesModel.COL_Name.Name, $"{model.Name} sudah terdaftar");
                else
                {
                    add(model);
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
            if (!UsersController.getUserAccess(Session).MoneyAccountCategories_Edit)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (id == null)
                return RedirectToAction(nameof(Index));

            setViewBag(FILTER_Keyword, FILTER_Active);
            return View(get((Guid)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoneyAccountCategoriesModel modifiedModel, string FILTER_Keyword, int? FILTER_Active)
        {
            if (ModelState.IsValid)
            {
                if (isExists(modifiedModel.Id, modifiedModel.Name))
                    ModelState.AddModelError(MoneyAccountCategoriesModel.COL_Name.Name, $"{modifiedModel.Name} sudah terdaftar");
                else
                {
                    MoneyAccountCategoriesModel originalModel = get(modifiedModel.Id);

                    string log = string.Empty;
                    log = Helper.append(log, originalModel.Name, modifiedModel.Name, MoneyAccountCategoriesModel.COL_Name.LogDisplay);
                    log = Helper.append(log, originalModel.Notes, modifiedModel.Notes, MoneyAccountCategoriesModel.COL_Notes.LogDisplay);
                    log = Helper.append(log, originalModel.Active, modifiedModel.Active, MoneyAccountCategoriesModel.COL_Active.LogDisplay);

                    if (!string.IsNullOrEmpty(log))
                    {
                        update(modifiedModel, log);
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
            controller.ViewBag.MoneyAccountCategories = new SelectList(get(), MoneyAccountCategoriesModel.COL_Id.Name, MoneyAccountCategoriesModel.COL_Name.Name);
        }

        public void setViewBag(string FILTER_Keyword, int? FILTER_Active)
        {
            ViewBag.FILTER_Keyword = FILTER_Keyword;
            ViewBag.FILTER_Active = FILTER_Active;
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public bool isExists(Guid? Id, string Name)
        {
            return db.Database.SqlQuery<MoneyAccountCategoriesModel>(@"
                        SELECT MoneyAccountCategories.*
                        FROM MoneyAccountCategories
                        WHERE 1=1 
							AND (@Id IS NOT NULL OR MoneyAccountCategories.Name = @Name)
							AND (@Id IS NULL OR (MoneyAccountCategories.Name = @Name AND MoneyAccountCategories.Id <> @Id))
                    ",
                    DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Name.Name, Name)
                ).Count() > 0;
        }

        public List<MoneyAccountCategoriesModel> get(string FILTER_Keyword, int? FILTER_Active) { return get(null, FILTER_Active, FILTER_Keyword); }
        public MoneyAccountCategoriesModel get(Guid Id) { return get(Id, null, null).FirstOrDefault(); }
        public static List<MoneyAccountCategoriesModel> get() { return get(null, null, null); }
        public static List<MoneyAccountCategoriesModel> get(Guid? Id, int? FILTER_Active, string FILTER_Keyword)
        {
            return new DBContext().Database.SqlQuery<MoneyAccountCategoriesModel>(@"
                        SELECT MoneyAccountCategories.*
                        FROM MoneyAccountCategories
                        WHERE 1=1
							AND (@Id IS NULL OR MoneyAccountCategories.Id = @Id)
							AND (@Id IS NOT NULL OR (
                                (@Active IS NULL OR MoneyAccountCategories.Active = @Active)
    							AND (@FILTER_Keyword IS NULL OR (MoneyAccountCategories.Name LIKE '%'+@FILTER_Keyword+'%'))
                            ))
						ORDER BY MoneyAccountCategories.Name ASC
                    ",
                    DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Active.Name, FILTER_Active),
                    DBConnection.getSqlParameter("FILTER_Keyword", FILTER_Keyword)
                ).ToList();
        }

        public void add(MoneyAccountCategoriesModel model)
        {
            LIBWebMVC.WebDBConnection.Insert(db.Database, "MoneyAccountCategories",
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Notes.Name, model.Notes)
            );
        }

        public void update(MoneyAccountCategoriesModel model, string log)
        {
            LIBWebMVC.WebDBConnection.Update(db.Database, "MoneyAccountCategories",
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Id.Name, model.Id),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Name.Name, model.Name),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Active.Name, model.Active),
                DBConnection.getSqlParameter(MoneyAccountCategoriesModel.COL_Notes.Name, model.Notes)
            );
        }

        /******************************************************************************************************************************************************/
    }
}