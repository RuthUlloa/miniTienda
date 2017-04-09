using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;
using Cassandra.Mapping;

namespace WebApplication1.Models
{
    public class CassandraDB
    {
        private ICluster clusterDB;
        private static ISession _sesionDB;
        public ISession Session { get { return _sesionDB; } }
        //private IMapper mapperDB;

        public CassandraDB()
        {
            clusterDB = Cluster.Builder().AddContactPoint("localhost").WithPort(9042).Build();
            _sesionDB = clusterDB.Connect("minitiendadb");
        }

        public List<Comentario> getComentarios()
        {
            List<Comentario> resultado = new List<Comentario>();
            var filas = Session.Execute(@"SELECT * FROM ""comentarios"";");

            foreach (var fila in filas)
            {
                Comentario tempComentario = new Comentario();
                tempComentario.id = fila.GetValue<string>("id");
                tempComentario.id = fila.GetValue<string>("comentario");
            }

            return resultado;
        }

    }
}