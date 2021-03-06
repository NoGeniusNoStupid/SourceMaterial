﻿using BeautySalonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BeautySalonWebApp.Handel
{
    /// <summary>
    /// GoodsCarHandler 的摘要说明
    /// </summary>
    public class GoodsCarHandler : IHttpHandler, IRequiresSessionState
    {
        BeautySalonEntities db = (BeautySalonEntities)DBContextFactory.CreateDbContext();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id = Convert.ToInt32(context.Request["gid"]);

            if (context.Session["Id"] == null)
            { 
                context.Response.Write("请先登录，再进行操作！");
                return;
            }

            //获取用户登录信息
            int userId = Convert.ToInt32(context.Session["Id"]);

            //判断是否存在改商品
            var tempInfn = db.BS_GoodsCar.FirstOrDefault(a => a.GoodsId == id && a.UserId == userId);
            if (tempInfn == null)
            {
                BS_GoodsCar goodsCarInfo = new BS_GoodsCar();
                goodsCarInfo.UserId = userId;
                goodsCarInfo.GoodsId = id;
                goodsCarInfo.SeqNo = 1;
                goodsCarInfo.AddTime = DateTime.Now;
                db.BS_GoodsCar.Add(goodsCarInfo);            
            }
            else
            {
                tempInfn.SeqNo += 1;
                db.Entry(tempInfn).State = EntityState.Modified;
            }
            db.SaveChanges();
            context.Response.Write("ok");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}