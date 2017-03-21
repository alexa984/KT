

namespace IS.Web.Controllers
{
    using Data;
    using Data.Contracts;
    using System.Web.Mvc;
    using IS.Web.CustomHttps;

    [CustomHttps]

    public class HomeController : BaseController
    {
        public ActionResult Welcome()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}