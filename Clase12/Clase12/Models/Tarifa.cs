using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase12.Models
{
    public class Tarifa
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public double Monto { get; set; }
        public double Descuento { get; set; }
        public String Fecha { get; set; }


    }
}