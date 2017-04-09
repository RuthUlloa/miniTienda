using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Redis
    {
        private readonly ConnectionMultiplexer redisConnections;
        public Redis()
        {
            this.redisConnections = ConnectionMultiplexer.Connect("localhost");
        }
        public void agregarProducto<T>(string key, T objectToCache) where T : class
        {
            var db = this.redisConnections.GetDatabase();
            db.SetAdd(key, JsonConvert.SerializeObject(objectToCache
                        , Formatting.Indented
                        , new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        }));


        }


        public Array verProductos<T>(string key) where T : class
        {
            var db = this.redisConnections.GetDatabase();
            var redisObject2 = db.SetMembers(key);
            var elementos = Array.ConvertAll(redisObject2, item => (String)item);


            return elementos;
        }

        public void borrarProducto<T>(string key, T objectToCache)
        {
            var db = this.redisConnections.GetDatabase();
            var redisObject2 = db.SetRemove(key, JsonConvert.SerializeObject(objectToCache
                        , Formatting.Indented
                        , new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        }));
        }
    }
}