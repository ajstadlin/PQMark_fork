using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PQMark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");
            return View();
        }

        public ActionResult Home()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");
            return View();

        }


        public ActionResult SARFI()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PQEventMagnitudeDuration()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PQVoltage3D()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VoltageTHDFrequency()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}