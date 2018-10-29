﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase12.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        //[Required]
        //[StringLenth]
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        //public double Salario { get; set; }
        //public bool Activo { get; set; }

        public bool EstaInscritoRevista { get; set; }
        public TipoCliente tipoCliente { get; set; }
        public byte IdTipoCliente { get; set; }
    }

}