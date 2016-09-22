using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PQMark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SARFI()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PQEventMagnitudeDuration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PQVoltage3D()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VoltageTHDFrequency()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}