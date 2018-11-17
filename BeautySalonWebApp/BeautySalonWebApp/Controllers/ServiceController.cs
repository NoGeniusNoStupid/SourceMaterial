using BeautySalonWebApp.Models;
using BeautySalonWebApp.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class ServiceController : AdminBaseController
    {
      
        //
        // GET: /Service/

        public ActionResult Index(string search)
        {
            //分页设置
            int pageIndex = Request.QueryString["pageIndex"] != null ? int.Parse(Request.QueryString["pageIndex"]) : 1;
            int pageSize = 10;//页面记录数
            List<BS_Service> mlist = new List<BS_Service>();
            //查询记录
            if (string.IsNullOrEmpty(search))
            {
                mlist = db.BS_Service.Where(a => true).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Service>();
            }
            else
            {
                mlist = db.BS_Service.Where(a => a.Title.Contains(search)).OrderByDescending(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList<BS_Service>();
            }
            int listCount = db.BS_Service.Where(a => true).Count();
            //生成导航条
            string strBar = PageBarHelper.GetPagaBar(pageIndex, listCount, pageSize);

            ViewData["List"] = mlist;
            ViewData["Bar"] = strBar;

            return View();
        }

        //
        // GET: /Service/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Service/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        public ActionResult Create(BS_Service serviceInfo)
        {

            try
            {
                serviceInfo.AddTime = DateTime.Now;

                //上传图片
                if (Request.Files.Count > 0)
                {
                    serviceInfo.ServerPic = SaveImage(Request.Files["ServicePic"]);
                }
                //保存对象
                db.BS_Service.Add(serviceInfo);
                //跳转到管理界面
                return RedirectDialogToAction("Index", "Service", db.SaveChanges());
            }
            catch
            {
                return View();
            }  
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id)
        {
            var Info = db.BS_Service.FirstOrDefault(a => a.Id == id);
            return View(Info);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        public ActionResult Edit(BS_Service Info, string oldPic)
        {
            try
            {
                //图片处理
                if (Request.Files.Count > 0)
                {
                    Info.ServerPic = SaveImage(Request.Files["ServicePic"]);
                }
                if (string.IsNullOrEmpty(Info.ServerPic))
                    Info.ServerPic = oldPic;

                db.Entry(Info).State = EntityState.Modified;

                // TODO: Add update logic here
                return RedirectDialogToAction("Index", "Service", db.SaveChanges());
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var Info = db.BS_Service.FirstOrDefault(a => a.Id == id);

                //删除操作
                db.Entry(Info).State = System.Data.EntityState.Deleted;

                return RedirectDialogToAction("Index", "Service", db.SaveChanges());
            }
            catch
            {
                return View();
            }
        }
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
