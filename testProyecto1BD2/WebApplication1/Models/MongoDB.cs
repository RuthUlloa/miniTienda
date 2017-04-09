
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

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

        public Producto getProducto(int Id)
        {

            var db = cliente.GetDatabase("miniTiendaDB");

            return db.GetCollection<Producto>("Inventario").Find(p => p.IDArticulo == Id).SingleOrDefault();
        }

        public bool insertarProducto(Producto nuevo)
        {
            try
            {
                var db = cliente.GetDatabase("miniTiendaDB");
                db.GetCollection<Producto>("Inventario").InsertOne(nuevo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}