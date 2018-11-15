using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class HomeController : Controller
    {
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();

        //首页
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        //展示商品列表
        public ActionResult Goods()
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 10;//页面记录数
            List<BS_Goods> mlist = new List<BS_Goods>();
            //查询记录
           
            mlist = db.BS_Goods.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Goods>();
           
          
            int listCount = db.BS_Goods.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetPagaBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();   
        }

        /// <summary>
        /// 展示商品详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GoodsDetails(int id)
        {


            return View();
        }
        public ActionResult VIPCentral()
        {
            return View();
        }
    }
}
