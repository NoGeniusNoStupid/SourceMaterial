using BeautySalonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class FrontVIPController : FrontBaseController
    {
        //
        // GET: /FrontVIP/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AppointMent()
        {
            return View();
        }
        public ActionResult AppointMent(int id)
        {
            string msg = "";
            if (Session["Id"] == null)
            {
                msg = "请先登录，再进行操作！";
                return RedirectDialogToAction("Service", "Home", db.SaveChanges(), msg);
            }
            
            BS_Service serviceInfo = db.BS_Service.FirstOrDefault(a => a.Id == id);
            BS_Appointment appInfo = new BS_Appointment();
            appInfo.ServiceId = serviceInfo.Id;
            appInfo.UserId = Convert.ToInt32(Session["Id"]);
            appInfo.AddTime = DateTime.Now;
           
            return RedirectDialogToAction("Service", "Home", db.SaveChanges(), msg);
        }
    }
}
