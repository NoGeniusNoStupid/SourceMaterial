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
    public class UserInfoController : AdminBaseController
    {
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();

        //
        // GET: /UserInfo/

        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 10;//页面记录数
            List<BS_UserInfo> mlist = new List<BS_UserInfo>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_UserInfo.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_UserInfo>();
            }
            else
            {
                mlist = db.BS_UserInfo.Where(a => a.RealName.Contains(search) || a.UserName.Contains(search) || a.Tel.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_UserInfo>();
            }
            int listCount = db.BS_UserInfo.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetPagaBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }

        //
        // GET: /UserInfo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UserInfo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserInfo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserInfo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserInfo/Delete/5

        public ActionResult Delete(int id)
        {
            var adminInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id);
            //删除操作
            db.Entry(adminInfo).State = System.Data.EntityState.Deleted;
            return RedirectDialogToAction("Index", "UserInfo", db.SaveChanges());
        }

        #region 锁定账号
        public ActionResult UserInfoLock(int id)
        {
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id);

            //锁定操作
            if (userInfo.Lock == "1")
                userInfo.Lock = "0";
            else
                userInfo.Lock = "1";
            db.Entry(userInfo).State = System.Data.EntityState.Modified;

            return RedirectDialogToAction("Index", "UserInfo", db.SaveChanges());
        }
        #endregion

        #region 密码重置
        public ActionResult UserInfoUpdatePwd(int id)
        {
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id);
            //密码重置
            userInfo.Password = "123456";
            db.Entry(userInfo).State = System.Data.EntityState.Modified;
            return RedirectDialogToAction("Index", "UserInfo", db.SaveChanges());
        }
        #endregion

        #region 账号充值
        public ActionResult AccountRecharge(int id)
        {
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id);
            return View(userInfo);
        }
        [HttpPost]
        public ActionResult AccountRecharge(int id,double money)
        {
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id);
            int old = Convert.ToInt32(userInfo.Money);
            userInfo.Money = (old + money).ToString();
            db.Entry(userInfo).State = EntityState.Modified;
            return RedirectDialogToAction("Index", "UserInfo", db.SaveChanges());
        }
        #endregion

       
    }
}
