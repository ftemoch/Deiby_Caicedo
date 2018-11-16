using ParcialFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ParcialFinal.Controllers
{
    public class BibliotecaController : Controller
    {
        
            private ApplicationDbContext _context;
            public BibliotecaController()
            {
                _context = new ApplicationDbContext();

            }
            protected override void Dispose(bool disposing)
            {
                _context.Dispose();
            }
            // GET: Clientes
            public ViewResult Lista()
            {
                // var clientes =GetClientes();
                var Bibliotecas = _context.Bibliotecas.ToList();
                return View(Bibliotecas);
            }
            
            public ActionResult Details(int id)
            {
                // var cliente= GetClientes().SingleOrDefault(c=> c.ID==id);
                var Bibliotecas = _context.Bibliotecas.SingleOrDefault(c => c.ID_Libro == id);
                if (Bibliotecas == null)

                    return HttpNotFound();
                return View(Bibliotecas);
            }
            
            //Crear vista para crear clientes
            public ActionResult Nueva()
            {
                var Bibliotecas = _context.Bibliotecas.ToList();
                var viewModel = new Biblioteca
                {

                };

                return View(viewModel);
            }


            //Metodo para encadenar la base de datos
            [HttpPost]

            public ActionResult Create(Biblioteca biblioteca)
            {
                if (biblioteca.ID_Libro == 0)
                    _context.Bibliotecas.Add(biblioteca);

                else
                {
                    var bibliotecaEnBd = _context.Bibliotecas.Single(c => c.ID_Libro == biblioteca.ID_Libro);
                bibliotecaEnBd.Titulo_Libro = biblioteca.Titulo_Libro;
                bibliotecaEnBd.Autor_Libro = biblioteca.Autor_Libro;
                bibliotecaEnBd.ISB_Libro = biblioteca.ISB_Libro;
             
                }
                
                // _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction("Lista", "Biblioteca");
            }
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblioteca biblioteca = _context.Bibliotecas.Find(ID);
            if (biblioteca == null)
            {
                return HttpNotFound();
            }
            return View(biblioteca);
        }
        [HttpPost]
        public ActionResult Edit(Biblioteca biblioteca)
        {
            _context.Entry(biblioteca).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Lista", "Biblioteca");
        }
        public ActionResult Eliminar(int id)
            {
                var bibliotecas = _context.Bibliotecas.SingleOrDefault(c => c.ID_Libro == id);
                if (bibliotecas == null)
                    return HttpNotFound();

                else
                {
                    _context.Bibliotecas.Remove(bibliotecas);

                    _context.SaveChanges();


                }
                return RedirectToAction("Lista", "Biblioteca");
            }
            private IEnumerable<Biblioteca> GetBiblioteca()
            {
                return new List<Biblioteca>
                {
                    // new Cliente {ID=1, Nombre="John Smith"},

                    //new Cliente {ID=2, Nombre="Mary Williams"}
                };
            }
        }
    }

