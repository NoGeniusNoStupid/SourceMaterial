using BeautySalonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    /// <summary>
    /// 表示登陆的控制器
    /// </summary>
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginInfo(string UserName, string Password)
        {
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.UserName == UserName && a.Password == Password);
            if (userInfo==null)
                return Content("用户名或密码输入错误");
            Session["realName"] = userInfo.RealName;//用户真实姓名
            Session["Id"] = userInfo.Id;//用户id
            return Content("ok");
        }
    }
}
