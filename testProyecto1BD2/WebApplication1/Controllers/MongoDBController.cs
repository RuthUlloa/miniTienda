using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
        public ActionResult Create( HttpPostedFileBase fileDir, Producto nuevo)
        {
            try
            {
                // TODO: Add insert logic here
                if (fileDir.ContentLength > 0)
                {
                    byte[] imagenByte = new byte[fileDir.ContentLength];
                    using (BinaryReader lector = new BinaryReader(fileDir.InputStream))
                    {
                        imagenByte = lector.ReadBytes((int)fileDir.ContentLength);
                    }

                    //string imagenString = Convert.ToBase64String(imagenByte);
                    
                    nuevo.imagen = fileDir.InputStream;
                Mongo.insertarProducto(nuevo);
                return RedirectToAction("Index");
                }
                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
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
