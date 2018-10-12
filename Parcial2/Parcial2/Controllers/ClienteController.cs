using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Random()
        {
            var Cliente = new Cliente()
            {
                Nombre = "Deiby"
                Apellido = "Caicedo"
                Sueldo = 800000
            };
            return View();
        }
    }
}