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
        public ActionResult Left()
        {
            return View();
        }

        //弹窗功能实现
        public ActionResult AppointMent(int id)
        {
            BS_Service serviceInfo = db.BS_Service.FirstOrDefault(a => a.Id == id);
            int userId=  Convert.ToInt32(Session["Id"]);
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == userId);
            ViewData["Tel"] = userInfo.Tel;

            return View(serviceInfo);
        }
        //预约功能
        [HttpPost]
        public ActionResult AppointMent(int id, string Tel, string Time, string TimeSlot)
        {
            string msg = "";
            int userId = Convert.ToInt32(Session["Id"]);
            //检测是否重复预约
            BS_Appointment isExistInfo = db.BS_Appointment.ToList().FirstOrDefault(a => a.ServiceId == id && a.UserId == userId
             && a.Time==Convert.ToDateTime(Time) && a.TimeSlot == TimeSlot && a.State == "未完成");
            if(isExistInfo!=null)
            {
                msg = "该日期和时间段已经预约，无需重新预约！";
                return RedirectDialogToAction(-1, msg);
            }

            BS_Service serviceInfo = db.BS_Service.FirstOrDefault(a => a.Id == id);

            BS_Appointment appInfo = new BS_Appointment();
            appInfo.ServiceId = serviceInfo.Id;
            appInfo.UserId = Convert.ToInt32(Session["Id"]);
            appInfo.AddTime = DateTime.Now;
            appInfo.Tel = Tel;
            appInfo.Time =Convert.ToDateTime(Time);
            appInfo.TimeSlot = TimeSlot;
            appInfo.State = "未完成";
            db.BS_Appointment.Add(appInfo);
            return RedirectDialogToAction(db.SaveChanges());
        }



    }
}
