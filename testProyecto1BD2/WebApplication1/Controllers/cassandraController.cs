using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class cassandraController : Controller
    {
        private CassandraDB cassandra= new CassandraDB();
        // GET: cassandra
        public ActionResult Index()
        {
            return View(cassandra.getComentarios());
        }
    }
}