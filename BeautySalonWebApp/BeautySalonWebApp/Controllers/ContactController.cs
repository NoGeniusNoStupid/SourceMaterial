using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class ContactController : AdminBaseController
    {
     
        //
        // GET: /Contact/
        //加载页面
        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Contact> mlist = new List<BS_Contact>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Contact.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Contact>();
            }
            else
            {
                mlist = db.BS_Contact.Where(a => a.Phone.Contains(search) && a.Name.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Contact>();
            }
            int listCount = db.BS_Contact.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }
        //处理回访
        public ActionResult ContactDone(int id)
        {
            var Info = db.BS_Contact.FirstOrDefault(a => a.Id == id);

            if (Info.Reply == "未处理")
                Info.Reply = "已回访";
            else
                Info.Reply = "未处理";
            Info.ReplyTime = DateTime.Now;
            db.Entry(Info).State = System.Data.EntityState.Modified;

            return RedirectDialogToAction("Index", "Contact", db.SaveChanges());
        }
        public ActionResult Delete(int id)
        {
            var Info = db.BS_Contact.FirstOrDefault(a => a.Id == id);
            //删除操作
            db.Entry(Info).State = System.Data.EntityState.Deleted;

            return RedirectDialogToAction("Index", "Contact", db.SaveChanges());
        }
    }
}
