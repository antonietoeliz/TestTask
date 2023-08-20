using MongoDB.Bson;
using System.Collections.Generic;
using System.Web.Mvc;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;
using TestTask.Features.Admin.AdminTests.ViewModels;

namespace TestTask.Features.Admin.AdminTests
{
    public class AdminTestsController : Controller
    {
        private AdminTestAccionesViewModel ViewModel;
        public AdminTestsController()
        {
            ViewModel = new AdminTestAccionesViewModel(new List<TestTask.Core.DB.Models.Tests>());
            
        }
       
        public ActionResult Index()
        {
            ViewModel.CargarListado();
            return View(ViewModel);
        }
        [HttpGet]
        public ActionResult _Create()
        {
            
            return PartialView("_Create", ViewModel);
        }

        [HttpPost]
        public ActionResult _Create(string descripcion)
        {
            ViewModel.Insertar(descripcion);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult _Edit(string id)
        {
            ObjectId objectId = new ObjectId(id);
            ViewModel.TestActual = ViewModel.ListadoActual.Find(t => t.Id == objectId);
            return PartialView(ViewModel.TestActual);
        }

        [HttpPost]
        public ActionResult _Edit(string id,string descripcion)
        {
            ViewModel.Actualizar(id, descripcion);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult _Delete(string id)
        {
            ObjectId objectId = new ObjectId(id);
            ViewModel.TestActual = ViewModel.ListadoActual.Find(t => t.Id == objectId);
            return PartialView(ViewModel.TestActual);
        }

        [HttpPost]
        public ActionResult _DeletePost(string id)
        {
            ViewModel.Eliminar(new ObjectId(id));
            return RedirectToAction("Index");
        }
    }
}