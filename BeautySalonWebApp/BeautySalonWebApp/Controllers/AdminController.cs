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
    public class AdminController : AdminBaseController
    {
    

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

        #region 查询
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
        #endregion

        #region 添加
        /// <summary>
        /// 显示添加管理员界面
        /// </summary>
        /// <returns></returns>
         public ActionResult AddAdminInfo()
         {
             return View();
         }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
         public ActionResult AddAdminInfo(string AdminName, string AdminPassword, string Power)
        {
            BS_Admin adminInfo = new BS_Admin();
            adminInfo.AdminName = AdminName;
            adminInfo.AdminPassword = AdminPassword;
            adminInfo.LastTime = DateTime.Now;
            adminInfo.Lock = "0";
            adminInfo.LoginCount = "0";
            adminInfo.Power = Power;
            db.BS_Admin.Add(adminInfo);

            return RedirectDialogToAction("AdminManage", "Admin", db.SaveChanges());
        }
        /// <summary>
        /// 是否存在用户名
        /// </summary>
        /// <returns></returns>
        public ActionResult IsExistAdminName()
        {
            string adminName = Request["AdminName"];
            //判断用户名是否重复
            var tempInfo = db.BS_Admin.FirstOrDefault(a => a.AdminName == adminName);
            if (tempInfo != null)
                return Content("用户名已存在！");
            return Content("ok");
        }
        #endregion

        #region 详情
        public ActionResult EditInfo(int id)
        { 
            var adminInfo = db.BS_Admin.FirstOrDefault(a => a.Id == id);
            return View(adminInfo);
        }
        [HttpPost]
        public ActionResult EditInfo(int id, string Power)
        {
            //获取对象
            var adminInfo = db.BS_Admin.FirstOrDefault(a => a.Id == id);

            //更新操作
            adminInfo.Power = Power;
            db.Entry(adminInfo).State = System.Data.EntityState.Modified;

            return RedirectDialogToAction("AdminManage", "Admin", db.SaveChanges());
        }
        #endregion

        #region 删除
        public ActionResult DeleteInfo(int id)
        {
            var adminInfo = db.BS_Admin.FirstOrDefault(a => a.Id == id);

            //删除操作
            db.Entry(adminInfo).State = System.Data.EntityState.Deleted;
           

            return RedirectDialogToAction("AdminManage", "Admin", db.SaveChanges());
        }
        #endregion

        #region 锁定账号
        public ActionResult AdminLock(int id)
        {
            var adminInfo = db.BS_Admin.FirstOrDefault(a => a.Id == id);

            //锁定操作
            if (adminInfo.Lock == "1")
                adminInfo.Lock = "0";
            else
                adminInfo.Lock = "1";
            db.Entry(adminInfo).State = System.Data.EntityState.Modified;
          
            return RedirectDialogToAction("AdminManage", "Admin", db.SaveChanges());
        }
        #endregion

        #region 密码重置
        public ActionResult AdminUpdatePwd(int id)
        {
            var adminInfo = db.BS_Admin.FirstOrDefault(a => a.Id == id);

            //密码重置
            adminInfo.AdminPassword = "123456";

            db.Entry(adminInfo).State = System.Data.EntityState.Modified;

            return RedirectDialogToAction("AdminManage", "Admin", db.SaveChanges());
        }
        #endregion

        #endregion
    }
}
