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
    /// 表示注册的控制器
    /// </summary>
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult RegisterInfo (BS_UserInfo userInfo)
        {
            //判断一下是否存在
            BS_UserInfo isExistObject = db.BS_UserInfo.FirstOrDefault(a => a.UserName == userInfo.UserName);
            if (isExistObject != null)
                return Content("用户名已存在");
            //注册
            db.BS_UserInfo.Add(userInfo);
            db.SaveChanges();

            Session["realName"] = userInfo.RealName;//用户真实姓名
            Session["Id"] = userInfo.Id;//用户id

            return Content("ok");
            ////js提示
            //Response.Write("<script languge='javascript'>alert('注册成功');</script>");
            //return RedirectToAction("Index", "Home"); 
        }

        public ActionResult OutInfo()
        {
            Session["realName"] = null;//用户真实姓名
            Session["Id"] = null;//用户id
            return RedirectToAction("Index", "Home"); 
        }
    }
}
