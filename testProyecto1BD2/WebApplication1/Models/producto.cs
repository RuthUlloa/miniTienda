using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Producto
    {
        public ObjectId Id { get; set; }

        public int IDArticulo { get; set; }

        public string nombreArticulo { get; set; }

        public string descripcion { get; set; }

    }
}