using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Empresa
    {

        public int IdEmpresa { get; set; }
        public String Descripcion { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public String Identificacion { get; set; }

        public String Telefono { get; set; }

        public String Contacto { get; set; }

        public bool Estado { get; set; }



    }
}