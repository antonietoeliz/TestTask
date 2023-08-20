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
        private readonly DataService _dataService;
        private AdminTestAccionesViewModel ViewModel;
        public AdminTestsController(DataService dataService)
        {
            _dataService = new DataService();
            ViewModel = new AdminTestAccionesViewModel(new List<TestTask.Core.DB.Models.Tests>());
            
        }
        public AdminTestsController()
        {
            _dataService = new DataService();
            ViewModel = new AdminTestAccionesViewModel(new List<TestTask.Core.DB.Models.Tests>());
        }

        public ActionResult Index()
        {
            ViewModel.ListadoActual=_dataService.ObtenerColeccion<TestTask.Core.DB.Models.Tests>("Tests");
            return View(ViewModel);
        }
        [HttpGet]
        public ActionResult _Create()
        {
            var viewModel = new TestTask.Core.DB.Models.Tests();
            return PartialView("_Create", viewModel);
        }

        [HttpPost]
        public ActionResult _Create(TestTask.Core.DB.Models.Tests tests)
        {
            _dataService.Insertar("Tests", tests);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult _Edit(string id)
        {
            ObjectId objectId = new ObjectId(id);
            TestTask.Core.DB.Models.Tests test = ViewModel.ListadoActual.Find(t => t.Id == objectId);
            return PartialView(test);
        }

        [HttpPost]
        public ActionResult _Edit(TestTask.Core.DB.Models.Tests test)
        {
            _dataService.Actualizar("Tests", test.Id, test);
            return RedirectToAction("Index");
        }

        public ActionResult _Delete(string id)
        {
            ObjectId objectId = new ObjectId(id);
            TestTask.Core.DB.Models.Tests test = ViewModel.ListadoActual.Find(t => t.Id == objectId);
            return PartialView(test);
        }

        [HttpPost]
        public ActionResult _Delete(TestTask.Core.DB.Models.Tests test)
        {
            _dataService.Eliminar<TestTask.Core.DB.Models.Tests>("Tests", test.Id);
            return RedirectToAction("Index");
        }
    }
}