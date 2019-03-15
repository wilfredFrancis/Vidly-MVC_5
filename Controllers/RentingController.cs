using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly2.Controllers
{
    public class RentingController : Controller
    {
        // GET: Renting
        public ActionResult Index()
        {
            return View();
        }

        // GET: Renting/New
        public ActionResult New()
        {
            return View();
        }
    }
}