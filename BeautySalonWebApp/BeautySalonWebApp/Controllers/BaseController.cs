﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    /// <summary>
    /// 表示控制器的基类 用于实现Session校验
    /// </summary>
    public class BaseController : Controller
    {

      
        /// <summary>
        /// 返回JS提示信息并跳转ViewResult
        /// </summary>
        ///  <remarks>
        /// 提示显示图标默认显示成功,不自动关闭
        /// </remarks>
        /// <param name="msg">提示消息</param>
        /// <param name="actionName">操作的名称</param>
        /// <param name="controllerName">控制器的名称</param>
        /// <param name="roteValues">路由的参数</param>
        /// <param name="msgStatus">提示显示图标（默认显示成功）</param>
        /// <param name="autoClose">是否自动关闭，1：是，0：否</param>
        /// <returns></returns>
        protected ActionResult RedirectDialogToAction(string actionName, string controllerName, int ros = -1, string msg = "", object roteValues = null)
        {
            if (string.IsNullOrEmpty(msg))
            {
                if (ros > 0)
                    msg = "操作成功";
                else
                    msg = "操作失败";
            }
            string url = Url.Action(actionName, controllerName, roteValues);
            string strTip=string.Empty;

            strTip = string.Format(@"<script languge='javascript'>alert('{0}');window.location='{1}'</script>", msg, url);
           
            Response.Write(strTip);
            return null;
        }


        protected ActionResult RedirectDialogToAction(string msg)
        {
            string strTip = string.Format(@"<script languge='javascript'>alert('{0}');</script>", msg); ;
            Response.Write(strTip);
            return null;
        }

        ///// <summary>
        ///// 执行控制器中的方法之前先执行该方法。
        ///// </summary>
        ///// <param name="filterContext"></param>
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    base.OnActionExecuted(filterContext);
        //    if (Session["userInfo"] == null)
        //    {
        //        filterContext.Result = Redirect("/Login/Index");
        //    }
        //}
    }
}
