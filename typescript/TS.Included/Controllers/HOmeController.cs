using System.Web.Mvc;
using TS.Included.App_Start;

namespace TS.Included.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllUsers()
        {
            var result = Initializer.Init();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}