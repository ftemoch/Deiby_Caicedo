using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clase12.Models;
using Clase12.ViewModels;

namespace Clase12.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;
            public ClienteController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cliente
        public ViewResult Lista()
        {
            //var clientes = GetClientes();
            var Clientes = _context.Clientes.ToList();
            return View(Clientes);

        }
        public ActionResult Details(int id)
        {
            //var clientes = GetClientes().SingleOrDefault(c => c.ID == id);
            var clientes = _context.Clientes.SingleOrDefault(c => c.ID == id);
            if (clientes == null)
                return HttpNotFound();
            return View(clientes);
        }
        private IEnumerable<Cliente> GetClientes()
        {
            return new List<Cliente> {
               // new Cliente {ID=1, Nombre= "jhon Smit"},
               // new Cliente {ID=2, Nombre= "Mary Willians"}
            };
        }

        public ActionResult Nueva()
        {
            var tipoClientes = _context.TipoCliente.ToList();
            var viewModel = new NewClienteViewModel
            {
                TipoClientes= tipoClientes
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Lista", "Cliente");
        }
    }

}


