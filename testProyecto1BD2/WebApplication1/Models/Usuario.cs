using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient.Serialization;
using Neo4jClient.Execution;
using Neo4jClient.Gremlin;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public string nombreUsuario { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string contrasena { get; set; }

        public string correo { get; set; }

        public string tipoUsuario { get; set; }
    }
}