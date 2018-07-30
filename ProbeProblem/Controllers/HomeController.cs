using System.Web.Mvc;

namespace ProbeProblem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
