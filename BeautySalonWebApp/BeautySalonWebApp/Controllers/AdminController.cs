using BeautySalonWebApp.Models;
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
        public ActionResult AdminManage(string search)
        {
           
            if (string.IsNullOrEmpty(search))
            {
                ViewData["AdminList"] = db.BS_Admin.Where(a => true).ToList<BS_Admin>();
            }
            else
            {
                ViewData["AdminList"] = db.BS_Admin.Where(a => a.AdminName.Contains(search)).ToList<BS_Admin>();
            }

            return View();
        }
        #endregion 
    }
}
