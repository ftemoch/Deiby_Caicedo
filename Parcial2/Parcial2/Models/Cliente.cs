using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public decimal sueldo { get; set; }
    }
}