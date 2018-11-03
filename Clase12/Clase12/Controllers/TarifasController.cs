using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clase12.Models;

namespace Clase12.Controllers
{
    public class TarifasController : Controller
    {
        private ApplicationDbContext _context;
        public TarifasController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cliente
        public ViewResult ListaTarifa()
        {
            //var clientes = GetClientes();
            var Tarifa = _context.Tarifas.ToList();
            return View(Tarifa);

        }
        public ActionResult Details(int id)
        {
            //var clientes = GetClientes().SingleOrDefault(c => c.ID == id);
            var tarifas = _context.Tarifas.SingleOrDefault(c => c.ID == id);
            if (tarifas == null)
                return HttpNotFound();
            return View(tarifas);
        }
        private IEnumerable<Tarifa> GetTarifas()
        {
            return new List<Tarifa>
            {
                // new Cliente {ID=1, Nombre= "jhon Smit"},
                // new Cliente {ID=2, Nombre= "Mary Willians"}
            };
        }
        
        public ActionResult NuevaTarifa(Tarifa tarifa)
        {
            
            var tarifas = _context.Tarifas.ToList();
            var viewModel = new Tarifa
            {
              
            };


            return View(viewModel);
   
        }
        [HttpPost]
        public ActionResult Create(Tarifa tarifa)
        {
            if (tarifa.ID == 0)
                _context.Tarifas.Add(tarifa);
            else
            {
                var tarifaEnBd = _context.Tarifas.Single(c => c.ID == tarifa.ID);
                tarifaEnBd.Nombre = tarifa.Nombre;
                tarifaEnBd.Monto = tarifa.Monto;
                tarifaEnBd.Descuento = tarifa.Descuento;
                tarifaEnBd.Fecha = tarifa.Fecha;
            }
            _context.SaveChanges();
            return RedirectToAction("ListaTarifa", "Tarifas");
        }
        public ActionResult Borrar(int id)
        {
            var tarifa = _context.Tarifas.Single(c => c.ID == id);

            if (tarifa == null)

                return HttpNotFound();
            else
            {

                _context.Tarifas.Remove(tarifa);
                _context.SaveChanges();
            }

            return RedirectToAction("ListaTarifa", "Tarifas");
        }

        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = _context.Tarifas.Find(ID);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }
        [HttpPost]
        public ActionResult Edit(Tarifa tarifa)
        {
            _context.Entry(tarifa).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ListaTarifa", "Tarifas");
        }

    }
}

