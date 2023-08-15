﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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
            TestsViewModel testSeleccionado = new TestsViewModel(Convert.ToInt32(modelo.Opcion));
            TempData["ModeloTest"] = testSeleccionado;
            return RedirectToAction("Tests",modelo);
        }

        public ActionResult Tests(TestsViewModel modelo)
        {
            if (modelo.TituloPregunta == null)
            {
                modelo = (TestsViewModel)TempData["ModeloTest"];
                TempData.Keep();
            }
            
            return View(modelo);
        }
        [HttpPost]
        public ActionResult TestSiguiente(FormCollection form)
        {
            var modelo = (TestsViewModel)TempData["ModeloTest"];
            TempData.Keep();
            var selectedOptions = form.GetValues("selectedOptions");
            var preguntaSiguiente=modelo.Pregunta();
            if (preguntaSiguiente == null) return RedirectToAction("Results");
            return RedirectToAction("Tests");
        }

        public ActionResult Results()
        {
            return View();
        }
    }
}