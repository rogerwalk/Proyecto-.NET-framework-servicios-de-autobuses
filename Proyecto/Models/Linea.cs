using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;

namespace Proyecto.Models
{
    public class Linea
    {

        public int IdLinea { get; set; }
        public int IdEmpresa { get; set; }

        public String Descripcion { get; set; }
        public String CodigoCTP { get; set; }
        public char Provincia { get; set; }
        public String Canton { get; set; }
        public String Distrito { get; set; }

        public bool Estado { get; set; }


    }
}