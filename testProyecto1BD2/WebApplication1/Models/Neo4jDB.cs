using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Neo4jDB
    {

        private GraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "miniTienda");

        public List<Usuario> getUsuarios()
        {
            client.Connect();

            var db = client.Cypher.Match("(usuario:Usuario)").Return(usuario => usuario.As<Usuario>()).Results;

            return db.AsQueryable().ToList();

        }

        public Boolean logIn(String name, String pass)
        {
            client.Connect();

            var db = client.Cypher.Match("(usuario:Usuario)")
                .Where((Usuario usuario) => usuario.nombreUsuario == name)
                .AndWhere((Usuario usuario) => usuario.contrasena == pass)
                .Return(usuario => usuario.As<Usuario>())
                .Results;

            if (db.AsQueryable().ToList().Count == 1)
            {
                return true;
            }
            else
            {
                return false;

            }
            
        }

    }
}