
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class MongoDB
    {
        private MongoClient cliente = new MongoClient();

        public List<Producto> getProductos()
        {
            var db = cliente.GetDatabase("miniTiendaDB");

            return db.GetCollection<Producto>("Inventario").AsQueryable().ToList();
        }

       
    }
}