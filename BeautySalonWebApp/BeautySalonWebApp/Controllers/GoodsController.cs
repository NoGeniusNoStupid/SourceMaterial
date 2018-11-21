using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class GoodsController : BaseController
    {
        
        //
        // GET: /Goods/
        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 6;//页面记录数
            List<BS_Goods> mlist = new List<BS_Goods>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Goods.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Goods>();
            }
            else
            {
                mlist = db.BS_Goods.Where(a => a.GoodsName.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Goods>();
            }
            int listCount = db.BS_Goods.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetGoodsBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }
        /// <summary>
        /// 添加商品页面展示
        /// </summary>
        /// <returns></returns>

        public ActionResult Create()
        {
            return View();
        }

        //添加商品实现
        //
        // POST: /Goods/Create

        [HttpPost]
        public ActionResult Create(BS_Goods goodsIndo)
        {
            try
            {
                goodsIndo.AddTime = DateTime.Now;
                goodsIndo.GoodsType = goodsIndo.GoodsType.Trim();
                //上传图片
                if (Request.Files.Count > 0)
                {
                   goodsIndo.GoodsPic = SaveImage(Request.Files["GoodsPic"]);
                }
                //保存对象
                db.BS_Goods.Add(goodsIndo);
                //跳转到管理界面
                return RedirectDialogToAction("Index", "Goods", db.SaveChanges());
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Goods/Edit/5

        public ActionResult Edit(int id)
        {
            var goodInfo = db.BS_Goods.FirstOrDefault(a => a.Id == id);
            return View(goodInfo);
        }

        //
        // POST: /Goods/Edit/5

        [HttpPost]
        public ActionResult Edit(BS_Goods goodsIndo, string oldPic)
        {
            try
            {
                //图片处理
                if (Request.Files.Count > 0)
                {
                    goodsIndo.GoodsPic = SaveImage(Request.Files["GoodsPic"]);
                }
                if (string.IsNullOrEmpty(goodsIndo.GoodsPic))
                    goodsIndo.GoodsPic = oldPic;
              
                db.Entry(goodsIndo).State = EntityState.Modified;

                // TODO: Add update logic here
                return RedirectDialogToAction("Index", "Goods", db.SaveChanges());
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            var Info = db.BS_Goods.FirstOrDefault(a => a.Id == id);

          
            //删除操作
            db.Entry(Info).State = System.Data.EntityState.Deleted;

            return RedirectDialogToAction("Index", "Goods", db.SaveChanges());
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="postFile"></param>
        /// <returns>获取保存的路径</returns>
        public string SaveImage(HttpPostedFileBase postFile)
        {
            string result = "";
            HttpPostedFileBase imageName = postFile;// 从前台获取文件
            string file = imageName.FileName;
            string fileFormat = file.Split('.')[file.Split('.').Length - 1]; // 以“.”截取，获取“.”后面的文件后缀
            Regex imageFormat = new Regex(@"^(bmp)|(png)|(gif)|(jpg)|(jpeg)"); // 验证文件后缀的表达式（自己写的，不规范别介意哈）
            if (string.IsNullOrEmpty(file) || !imageFormat.IsMatch(fileFormat)) // 验证后缀，判断文件是否是所要上传的格式
            {
                return null;
            }
            else
            {
                string timeStamp = DateTime.Now.Ticks.ToString(); // 获取当前时间的string类型
                string firstFileName = timeStamp.Substring(0, timeStamp.Length - 4); // 通过截取获得文件名
                string imageStr = "File/"; // 获取保存图片的项目文件夹
                string uploadPath = Server.MapPath("~/" + imageStr); // 将项目路径与文件夹合并
                string pictureFormat = file.Split('.')[file.Split('.').Length - 1];// 设置文件格式
                string fileName = firstFileName + "." + fileFormat;// 设置完整（文件名+文件格式） 
                string saveFile = uploadPath + fileName;//文件路径
                imageName.SaveAs(saveFile);// 保存文件
                // 如果单单是上传，不用保存路径的话，下面这行代码就不需要写了！
                string image = "/File/" + fileName;// 设置数据库保存的路径
                return image;
            }
        }
    }
}
