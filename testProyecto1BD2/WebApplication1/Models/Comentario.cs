using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Comentario
    {
        public string id { get; set; }

        public string comentario { get; set; }

        public string id_producto { get; set; }

        public string id_usuario { get; set; }
    }
}