using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Stream imagen
        {
            get
            {
                
                using (imagen)
                {
                    var bytes = new byte[imagen.Length];
                    imagen.Read(bytes, 0, (int)imagen.Length);
                    return imagen;
                }
            }

            set
            {
                //convierte imagen en byte []
                //ImageConverter _imageConverter = new ImageConverter();
                //byte[] imagenByte = (byte[])_imageConverter.ConvertTo(imagen, typeof(byte[]));
                
                

                MongoClient Cliente = new MongoClient();

                var server = Cliente.GetServer();
                var db = server.GetDatabase("miniTiendaDB");
                var gridFsInfo = db.GridFS.Upload(value, nombreArticulo);
                var fileId = gridFsInfo.Id;
                //GridFSBucket fs = new GridFSBucket(db);

            }

        }
    }
}