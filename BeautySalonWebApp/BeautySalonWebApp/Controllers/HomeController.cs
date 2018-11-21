using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class HomeController : BaseController
    {
       

        //首页
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            List<BS_Goods> mGoodslist = new List<BS_Goods>();
            mGoodslist = db.BS_Goods.Where(a => true).OrderByDescending(a=>a.Id).Take(5).ToList();
            List<BS_Service> mServicelist = new List<BS_Service>();
            mServicelist = db.BS_Service.Where(a => true).OrderByDescending(a => a.Id).Take(3).ToList();
            ViewData["mGoodslist"] = mGoodslist;
            ViewData["mServicelist"] = mServicelist;
            return View();
        }

        #region 服务
        public ActionResult Service()
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 10;//页面记录数
            List<BS_Service> mlist = new List<BS_Service>();
            //查询记录

            mlist = db.BS_Service.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Service>();


            int listCount = db.BS_Service.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetPagaBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();   
        }

       
        #endregion

        #region 联系我们
        //展示页面
        public ActionResult Contact()
        {
            BS_UserInfo userInfo = new BS_UserInfo();

            if (Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"]);
                userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == id); 
            }

            return View(userInfo);
        }
        [HttpPost]
        //提交页面
        public ActionResult Contact(BS_Contact contactInfo)
        {
            //已登录，记录用户
            if (Session["Id"] != null)
                contactInfo.UserId = Convert.ToInt32(Session["Id"]);

            contactInfo.Reply = "未处理";
            contactInfo.AddTime = DateTime.Now;
            db.BS_Contact.Add(contactInfo);

            return RedirectDialogToAction("Contact", "Home", db.SaveChanges());
        }
        #endregion

        #region 商品
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
        
        /// 展示商品详细信息
        public ActionResult GoodsDetails(int id)
        {
            var goodsInfo = db.BS_Goods.FirstOrDefault(a => a.Id == id);

            return View(goodsInfo);
        }
        #endregion

        public ActionResult VIPCentral()
        {
            return View();
        }
    }
}
