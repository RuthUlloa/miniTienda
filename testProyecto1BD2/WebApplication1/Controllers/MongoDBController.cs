using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MongoDBController : Controller
    {
        private MongoDB Mongo = new MongoDB();
        // GET: MongoDB
        public ActionResult Index()
        {
            return View(Mongo.getProductos());
        }

        // GET: MongoDB/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MongoDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MongoDB/Create
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

        // GET: MongoDB/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MongoDB/Edit/5
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

        // GET: MongoDB/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MongoDB/Delete/5
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
