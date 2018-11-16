using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialFinal.Models
{
    public class Biblioteca
    {

        [Key] public int ID_Libro { get; set; }
        [Required]
        [StringLength(255)]

        public String Titulo_Libro { get; set; }
        public String Autor_Libro { get; set; }
        public int ISB_Libro { get; set; }
    }
}