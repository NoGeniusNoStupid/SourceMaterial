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
    public class OrderController : AdminBaseController
    {
        //
        // GET: /Order/

        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Order> mlist = new List<BS_Order>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Order.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Order>();
            }
            else
            {
                mlist = db.BS_Order.Where(a => a.Id.Contains(search) && a.BS_UserInfo.UserName.Contains(search) && a.BS_UserInfo.RealName.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Order>();
            }
            int listCount = db.BS_Order.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }

        //
        // GET: /Order/Details/5
        //发货
        public ActionResult SendGoods(string id)
        {
            var orderInfo = db.BS_Order.FirstOrDefault(a => a.Id == id);
            if (orderInfo.State == "未发货")
            {
                orderInfo.State = "已发货";
            }
            else if (orderInfo.State == "已发货")
            {
                orderInfo.State = "确认送达";
            }
            db.Entry(orderInfo).State = EntityState.Modified;

            return RedirectDialogToAction("Index", "Order", db.SaveChanges());
        }

        //
        // GET: /Order/Delete/5
        //删除
        public ActionResult Delete(string id)
        {
            try
            {
                var orderInfo = db.BS_Order.FirstOrDefault(a => a.Id == id);
                //var detailList = orderInfo.BS_OrderDetail.ToList();
                //for (int i = 0; i < detailList.Count; i++)
                //{
                //    var detailInfo = detailList[i];
                //    db.Entry(detailInfo).State = EntityState.Deleted;
                //    //i--;
                //}
                db.Entry(orderInfo).State = EntityState.Deleted;
                return RedirectDialogToAction("Index", "Order", db.SaveChanges());
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        //退货
        public ActionResult OutGoods(int id)
        {
            var orderDetail = db.BS_OrderDetail.FirstOrDefault(a=>a.Id==id);
            orderDetail.Detail = "已退货";

            if (orderDetail.BS_Order.PayType == "余额支付")
            {
                double money=Convert.ToDouble(orderDetail.BS_Order.BS_UserInfo.Money);
                double price=Convert.ToDouble(Convert.ToDouble(orderDetail.BS_Goods.GoodsPrice)*orderDetail.Num);
                orderDetail.BS_Order.BS_UserInfo.Money = (money + price).ToString();
            }

            return RedirectDialogToAction("Index", "Order", db.SaveChanges());
        }
       
    }
}
