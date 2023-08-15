using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Features.Home.ViewModels;

namespace TestTask.Features.Home
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        // GET: Home
        public ActionResult Index(HomeViewModel modelo)
        {
            return View(modelo);
        }
        public ActionResult Iniciar(HomeViewModel modelo)
        {
            var noHayErrores = modelo.sePuedeEnviar;
            if (!noHayErrores) {
                modelo.Notificacion = "Debe de introducir todos los campos";
                return View("Index", modelo);
            }
            TestsViewModel testSeleccionado = new TestsViewModel { Pregunta = "Pregunta 1", };
            return RedirectToAction("Tests");
        }

        public ActionResult Tests(TestsViewModel modelo)
        {
            return View(modelo);
        }

    }
}