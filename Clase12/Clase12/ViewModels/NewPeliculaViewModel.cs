using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clase12.Models;

namespace Clase12.ViewModels
{
    public class NewPeliculaViewModel
    {
        public IEnumerable<TipoPelicula> Tipo { get; set; }
        public Movie Movie { get; set; }
        public List<TipoPelicula> TipoPeliculas { get; internal set; }
    }
}