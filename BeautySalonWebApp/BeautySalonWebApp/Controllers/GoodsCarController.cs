using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalonWebApp.Controllers
{
    public class GoodsCarController : Controller
    {
        //
        // GET: /GoodsCar/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /GoodsCar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GoodsCar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GoodsCar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GoodsCar/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GoodsCar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GoodsCar/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GoodsCar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
