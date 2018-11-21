using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class AdminBaseController : BaseController
    {
         //<summary>
         //执行控制器中的方法之前先执行该方法。
         //</summary>
         //<param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (Session["AdminId"] == null)
            {
                  string msg = "请先登录，再进行操作！";
                filterContext.Result = RedirectDialogToAction("AdminLogin", "Login", db.SaveChanges(), msg);             
            }
        }
    }
}
