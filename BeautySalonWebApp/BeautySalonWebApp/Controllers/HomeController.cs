using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class HomeController : Controller
    {
        //首页
        public ActionResult Index()
        {
            return View();
        }
        //
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult VIPCentral()
        {
            return View();
        }
    }
}
