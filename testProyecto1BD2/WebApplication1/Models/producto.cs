using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Producto
    {
        public ObjectId Id { get; set; }

        public int IDArticulo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string nombreArticulo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public string descripcion { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public Stream imagen { get; set; }
        //{
        //    get
        //    {
        //        return imagen;
        //    }

        //    set
        //    {
        //        MongoClient Cliente = new MongoClient();

        //        var server = Cliente.GetServer();
        //        var db = server.GetDatabase("miniTiendaDB");
        //        var gridFsInfo = db.GridFS.Upload(value, nombreArticulo);
        //        var fileId = gridFsInfo.Id;


        //    }

        }

    }