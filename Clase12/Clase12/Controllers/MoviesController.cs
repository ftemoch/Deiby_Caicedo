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

        // GET: Movie
        public ViewResult ListaMovies()
        {
            //var movies = GetMovies();
            var Movies = _context.Movies.ToList();
            return View(Movies);

        }
        public ActionResult Details(int id)
        {
            //var movies = GetMovies().SingleOrDefault(c => c.ID == id);
            var movies = _context.Movies.SingleOrDefault(c => c.ID == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                //new Movie {ID=1, Nombre= "Sherk III"},
                //new Movie {ID=2, Nombre= "American Pie"}
            };
        }
        public ActionResult Genero()
        {
            var tipoPelicula = _context.TipoPelicula.ToList();
            var viewModel = new NewPeliculaViewModel
            {
                TipoPeliculas = tipoPelicula
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("ListaMovies", "Movies");
        }
        public ActionResult Borrar(int id)
        {
            var movie = _context.Movies.Single(c => c.ID == id);

            if (movie == null)

                return HttpNotFound();
            else
            {

                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("ListaMovie", "Movies");
        }


    }
}