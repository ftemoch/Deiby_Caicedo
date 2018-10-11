using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var Movie = new Movie()
            {
                Nombre = "Friend request"
                //Crear View
            };
            return View(Movie);
        }
    }
}