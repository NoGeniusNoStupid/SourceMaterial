using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Data;
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
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);
            return View(userInfo);
        }
        public ActionResult Main()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);
            return View(userInfo);
        }
        public ActionResult Top()
        {
            return View();
        }
        public ActionResult Swich()
        {
            return View();
        }
        public ActionResult Bottom()
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

        //修改个人信息-页面展示
        public ActionResult UpdeteInfo()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);
            return View(userInfo);
        }
        //修改个人信息
        [HttpPost]
        public ActionResult UpdeteInfo(string Tel, string Email, string Age, string RealName)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);
            db.Entry(userInfo).State = EntityState.Modified;
            userInfo.Tel = Tel;
            userInfo.Email = Email;
            userInfo.Age = Age;
            userInfo.RealName = RealName;
            return RedirectDialogToAction("Main", "FrontVIP", db.SaveChanges());    
        }

        //修改密码-页面展示
        public ActionResult UpdetePassword()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);           
            return View(userInfo);
        }
        //修改密码
        [HttpPost]
        public ActionResult UpdetePassword(string Password)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == Id);
            userInfo.Password = Password;
            db.Entry(userInfo).State = EntityState.Modified;
            return RedirectDialogToAction("Main", "FrontVIP", db.SaveChanges());    
        }
        //留言管理
        public ActionResult ContactManage(string search)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Contact> mlist = new List<BS_Contact>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Contact.Where(a => a.UserId == Id).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Contact>();
            }
            else
            {
                mlist = db.BS_Contact.Where(a => a.UserId == Id && a.Message.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Contact>();
            }
            int listCount = db.BS_Contact.Where(a => a.UserId == Id).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();  
        }
        //订单管理
        public ActionResult OrderManage(string search)
        {
            int Id = Convert.ToInt32(Session["Id"]);

            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Order> mlist = new List<BS_Order>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Order.Where(a => a.UserId==Id).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Order>();
            }
            else
            {
                mlist = db.BS_Order.Where(a =>a.UserId==Id && a.Id.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Order>();
            }
            int listCount = db.BS_Order.Where(a => a.UserId == Id).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }
        //申请退货
        public ActionResult OutGoods(int id)
        {
            var orderDetail = db.BS_OrderDetail.FirstOrDefault(a => a.Id == id);
            orderDetail.Detail = "申请退货";
            return RedirectDialogToAction("OrderManage", "FrontVIP", db.SaveChanges());       
        }
        //预约管理
        public ActionResult AppointmentManage(string search)
        {
            int Id = Convert.ToInt32(Session["Id"]);
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Appointment> mlist = new List<BS_Appointment>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Appointment.Where(a => a.UserId == Id).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Appointment>();
            }
            else
            {
                mlist = db.BS_Appointment.Where(a => a.UserId == Id && a.BS_Service.Title.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Appointment>();
            }
            int listCount = db.BS_Appointment.Where(a => a.UserId == Id).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }
        //取消预约
        public ActionResult CancelAppointment(int id)
        {
            var Info = db.BS_Appointment.FirstOrDefault(a => a.Id == id);
            Info.State = "取消预约";
            return RedirectDialogToAction("AppointmentManage", "FrontVIP", db.SaveChanges());       
        }
    }
}
