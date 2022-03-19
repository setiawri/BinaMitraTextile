using System.Web.Mvc;

namespace BinaMitraTextileWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? rss)
        {
            ViewBag.RemoveDatatablesStateSave = rss;

            return RedirectToAction("Input", "InventoryChecks", new { rss = 1 });

            //return View();
        }

    }
}