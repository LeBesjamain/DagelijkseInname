using System.Web.Mvc;

namespace DagelijkseInname.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}