using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TestTask.Core.Usuario;
using TestTask.Features.Home.ViewModels;
using TestTask.Features.Tests.ViewModels;

namespace TestTask.Features.Home
{
    [RoutePrefix("/")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }
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
            TestsViewModel testSeleccionado = new TestsViewModel(Convert.ToInt32(modelo.Opcion));
            TempData["ModeloTest"] = testSeleccionado;
            Session["Usuario"] = new UserContext { Nombre = modelo.Nombre,IdentificadorTest= Convert.ToInt32(modelo.Opcion) };
            if (modelo.Nombre == "Admin") return RedirectToAction("AdminView", "Admin");
            return RedirectToAction("Tests","Tests",modelo);
        }
       
    }
}