using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // to cache
        // [OutputCache(Duration = 50)]
        // [OutputCache(Duration = 50)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}