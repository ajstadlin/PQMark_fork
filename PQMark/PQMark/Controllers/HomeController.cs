using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSF.Configuration;

namespace PQMark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");
            ViewBag.Logout = SetLogoutLink();
            return View();
        }

        public ActionResult Home()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");
            ViewBag.Logout = SetLogoutLink();

            return View();

        }


        public ActionResult SARFI()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your application description page.";
            ViewBag.Logout = SetLogoutLink();

            return View();
        }

        public ActionResult PQEventMagnitudeDuration()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";
            ViewBag.Logout = SetLogoutLink();


            return View();
        }

        public ActionResult PQVoltage3D()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";
            ViewBag.Logout = SetLogoutLink();

            return View();
        }

        public ActionResult VoltageTHDFrequency()
        {
            WebClient client = new WebClient();
            ViewBag.Footer = client.DownloadString("http://www.epri.com/general/sws_footer.html");

            ViewBag.Message = "Your contact page.";
            ViewBag.Logout = SetLogoutLink();

            return View();
        }

        private string SetLogoutLink()
        {
            // get the default logout url from the config file; this is for the production environment
            string logoutUrl = ConfigurationFile.Current.Settings["systemSettings"]["LogoutUrl"].Value;

            // get the logout url from config file if in DEV or TEST
            if (Request.Url.AbsoluteUri.ToLower().Contains("amidev"))
            {
                logoutUrl = ConfigurationFile.Current.Settings["systemSettings"]["LogoutUrl_EpriDev"].Value;
            }
            else if (Request.Url.AbsoluteUri.ToLower().Contains("amitest"))
            {
                logoutUrl = ConfigurationFile.Current.Settings["systemSettings"]["LogoutUrl_EpriTest"].Value;
            }

           return logoutUrl;
        }


    }
}