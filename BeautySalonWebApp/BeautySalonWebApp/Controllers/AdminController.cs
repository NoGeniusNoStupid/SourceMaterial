using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{

    /// <summary>
    /// 表示后台管理
    /// </summary>
    public class AdminController : Controller
    {
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();

        #region 登陆后页面展示
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Left()
        {
            return View();
        }
        public ActionResult Swich()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Top()
        {
            return View();
        }
        public ActionResult Bottom()
        {
            return View();
        }
        #endregion

        #region  管理员操作
        /// <summary>
        /// 管理员列表页面
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ActionResult AdminManage(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 10;//页面记录数
            List<BS_Admin> mlist=new List<BS_Admin>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Admin.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Admin>();
            }
            else
            {
                mlist = db.BS_Admin.Where(a => a.AdminName.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Admin>();
            }
            int listCount = db.BS_Admin.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetPagaBar(pageIndex, listCount, pageSize);

            ViewData["AdminList"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAdminInfo(string AdminName, string AdminPassword)
        {
            BS_Admin adminInfo = new BS_Admin();
            adminInfo.AdminName = AdminName;
            adminInfo.AdminPassword = AdminPassword;
            adminInfo.LastTime = DateTime.Now;
            adminInfo.Lock = "0";
            adminInfo.LoginCount = "0";
            db.BS_Admin.Add(adminInfo);
            db.SaveChanges();
            return Content("ok");
        }
        #endregion 
    }
}
