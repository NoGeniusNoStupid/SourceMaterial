using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class AppointmentController : AdminBaseController
    {
        //
        // GET: /Appointment/

        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Appointment> mlist = new List<BS_Appointment>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Appointment.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Appointment>();
            }
            else
            {
                mlist = db.BS_Appointment.Where(a => a.BS_UserInfo.UserName.Contains(search) && a.BS_UserInfo.RealName.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Appointment>();
            }
            int listCount = db.BS_Appointment.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }

        //结算
        public ActionResult Settlement(int id)
        {
            var Info = db.BS_Appointment.FirstOrDefault(a => a.Id == id);

            double money=Convert.ToDouble(Info.BS_UserInfo.Money);
            double price= Convert.ToDouble(Info.BS_Service.Price);
            //看下余额够不够
            if (money < price)
            {
                //提升
                return RedirectDialogToAction("余额不足，请前往充值！");
            }
            else
                Info.BS_UserInfo.Money = (money - price).ToString();

            if (Info.State == "未完成")
                Info.State = "已完成";
            
          
            db.Entry(Info).State = System.Data.EntityState.Modified;

            return RedirectDialogToAction("Index", "Appointment", db.SaveChanges());
        }

        public ActionResult Delete(int id)
        {
            var Info = db.BS_Appointment.FirstOrDefault(a => a.Id == id);

            db.Entry(Info).State = System.Data.EntityState.Deleted;

            return RedirectDialogToAction("Index", "Appointment", db.SaveChanges());
        }
    }
}
