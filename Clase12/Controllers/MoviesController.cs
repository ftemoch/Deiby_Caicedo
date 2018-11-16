using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clase12.Models;
using Clase12.ViewModels;

namespace Clase12.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //crea vista
        public ActionResult ListaPeliculas()
        {
            var genero = _context.Generos.ToList();
            var viewModel = new NewMovieViewModel
            {
                Generos = genero
            };

            return View(viewModel);
        }
        //Encadenar datos
        public ActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Peliculas", "Movies");
        }

        // GET: Clientes
        public ViewResult Peliculas()
        {
            // var clientes =GetClientes();
            var peliculas = _context.Movies.ToList();
            return View(peliculas);
        }

        public ActionResult Details(int id)
        {
            // var cliente= GetClientes().SingleOrDefault(c=> c.ID==id);
            var pelicula = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (pelicula == null)

                return HttpNotFound();
            return View(pelicula);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                // new Cliente {ID=1, Nombre="John Smith"},

                //new Cliente {ID=2, Nombre="Mary Williams"}
            };
        }
    }
}