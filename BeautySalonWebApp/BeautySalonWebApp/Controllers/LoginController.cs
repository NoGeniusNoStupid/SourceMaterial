﻿using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
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

        #region 前台登陆功能
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
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("验证码错误!!");
            }
            Session["validateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("验证码错误!!");
            }
            BS_UserInfo userInfo = db.BS_UserInfo.FirstOrDefault(a => a.UserName == UserName && a.Password == Password);
            if (userInfo==null)
                return Content("用户名或密码输入错误");
            Session["realName"] = userInfo.RealName;//用户真实姓名
            Session["Id"] = userInfo.Id;//用户id
            return Content("ok");
        }
        /// <summary>
        /// 显示验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowValidateCode()
        {
            ValidateCode vliateCode = new ValidateCode();
            string code = vliateCode.CreateValidateCode(4);//产生验证码
            Session["validateCode"] = code;
            byte[] buffer = vliateCode.CreateValidateGraphic(code);//将验证码画到画布上.
            return File(buffer, "image/jpeg");
        }
        #endregion

        #region 后台登陆功能
        /// <summary>
        /// 登陆页面展示
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminLogin()
        {
            return View();
        }
        #endregion 
    }
}