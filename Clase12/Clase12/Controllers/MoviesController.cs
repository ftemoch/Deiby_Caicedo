using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        /*public ActionResult Genero()
        {
            var tipoPelicula = _context.TipoPelicula.ToList();
            var viewModel = new NewPeliculaViewModel
            {
                TipoPeliculas = tipoPelicula
            };

            return View(viewModel);
        }*/
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Nombre")]Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("ListaMovies", "Movies");
        }
        /*public ActionResult Borrar()
        {
            var tipoPeliculas = _context.TipoPelicula.ToList();
            var viewModel = new NewPeliculaViewModel
            {
                TipoPeliculas = tipoPeliculas
            };

            return View(viewModel);
        }*/
        public ActionResult Borrar(int? ID)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _context.Clientes.Find(ID);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [HttpPost, ActionName("Borrar")]
        public ActionResult DeleteConfirmed(int ID)
        {
            Movie movie = _context.Movies.Find(ID);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ListaMovies", "Movies");
        }
        /*public ActionResult Edit()
        {
            var tipoClientes = _context.TipoCliente.ToList();
            var viewModel = new NewClienteViewModel
            {
                TipoClientes = tipoClientes
            };

            return View(viewModel);
        }*/
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _context.Movies.Find(ID);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ListaMovies", "Movies");
        }

    }
}