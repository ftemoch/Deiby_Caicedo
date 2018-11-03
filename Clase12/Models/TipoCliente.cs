using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase12.Models
{
    public class TipoCliente
    {
        public byte Id { get; set; }
        public String Nombre { get; set; }
        public short costoSubcripcion { get; set; }
        public byte duracionSubEnMeses { get; set; }
        public byte porcDescuento { get; set; }
    }
}