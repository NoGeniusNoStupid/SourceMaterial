using System;
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
        /// 执行控制器中的方法之前先执行该方法。
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (Session["userInfo"] == null)
            {
                filterContext.Result = Redirect("/Login/Index");
            }
        }
    }
}
