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
    public class GoodsCarController : FrontBaseController
    {
       
        //
        // GET: /GoodsCar/

        public ActionResult Index()
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 3;//页面记录数

            int userId =Convert.ToInt32(Session["Id"]);
            //获取分页记录
            var carInfo = db.BS_GoodsCar.Where(a => a.UserId == userId).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_GoodsCar>();
            //获取总记录
            var allGoodsCar = db.BS_GoodsCar.Where(a => a.UserId == userId);
            int listCount = allGoodsCar.Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);
            //计算总价
            double countPrice = 0;
            foreach (var item in allGoodsCar)
            {
                countPrice +=Convert.ToDouble(Convert.ToDouble(item.BS_Goods.GoodsPrice) * item.SeqNo);
            }

            ViewData["List"] = carInfo;
            ViewData["Bar"] = strBar;
            ViewData["countPrice"] = countPrice;
            return View();
        }

        //加入购物车
        public ActionResult Create()
        {
           
            //提示

            return Content("ok");
        }

        //删除
        public ActionResult Delete(int id)
        {
            var carInfo = db.BS_GoodsCar.FirstOrDefault(a => a.Id == id);
            db.Entry(carInfo).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //添加
        public ActionResult Add(int id)
        {
            var carInfo = db.BS_GoodsCar.FirstOrDefault(a => a.Id == id);
            carInfo.SeqNo += 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //减少
        public ActionResult Remove(int id)
        {
            var carInfo = db.BS_GoodsCar.FirstOrDefault(a => a.Id == id);
            if (carInfo.SeqNo > 1)
            { 
                carInfo.SeqNo -= 1;
                db.Entry(carInfo).State = EntityState.Modified;
            }
            else
                db.Entry(carInfo).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //提交订单
        public ActionResult SubmitOrder()
        {
            int userId = Convert.ToInt32(Session["Id"]);
            //获取购物车对象
            var allGoodsCar = db.BS_GoodsCar.Where(a => a.UserId == userId);
            //获取用户对象
            var userInfo = db.BS_UserInfo.FirstOrDefault(a => a.Id == userId);
    
            //计算总价
            double countPrice = 0;
            foreach (var item in allGoodsCar)
            {
                countPrice += Convert.ToDouble(Convert.ToDouble(item.BS_Goods.GoodsPrice) * item.SeqNo);
            }
            ViewData["countPrice"] = countPrice;
            return View(userInfo);
        }
        //确认订单
        public ActionResult ConfirmOrder(string Tel, string Address, string payType)
        {
            int userId = Convert.ToInt32(Session["Id"]);
            //获取购物车对象
            var allGoodsCar = db.BS_GoodsCar.Where(a => a.UserId == userId);
            double countPrice = 0;
            foreach (var item in allGoodsCar)
            {
                countPrice += Convert.ToDouble(Convert.ToDouble(item.BS_Goods.GoodsPrice) * item.SeqNo);
            }
            //创建订单对象
            BS_Order orderInfo = new BS_Order();
            orderInfo.Id = Guid.NewGuid().ToString("N");
            orderInfo.UserId = userId;
            orderInfo.PayType = payType;
            orderInfo.Money=countPrice.ToString();
            orderInfo.OperTime = DateTime.Now;
            orderInfo.Tel = Tel;
            orderInfo.Address = Address;
            //创建订单详细集合
            List<BS_OrderDetail> detailList = new List<BS_OrderDetail>();
            foreach (var item in allGoodsCar)
            {
                BS_OrderDetail detailInfo = new BS_OrderDetail();
                detailInfo.OrderId = orderInfo.Id;
                detailInfo.GoodsId = item.GoodsId;
                detailInfo.AddTime = item.AddTime;
                detailInfo.Num = item.SeqNo;
                detailList.Add(detailInfo);
            }
            orderInfo.BS_OrderDetail = detailList;
            db.BS_Order.Add(orderInfo);
            //清空购物车
            foreach (var item in allGoodsCar)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            string msg = string.Format("操作成功，您的订单号为：{0}", orderInfo.Id);
            return RedirectDialogToAction("Goods", "Home", db.SaveChanges(), msg, "");
        }
    }
}
