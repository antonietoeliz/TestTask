using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using MongoDB.Bson;
using Microsoft.Ajax.Utilities;

namespace TestTask.Features.Admin.AdminTests.ViewModels
{
    public class AdminTestAccionesViewModel
    {
        private readonly DataService _dataService;
        public TestTask.Core.DB.Models.Tests TestActual;
        public List<TestTask.Core.DB.Models.Tests> ListadoActual;
        public AdminTestAccionesViewModel(List<Core.DB.Models.Tests> listado)
        {
            _dataService = new DataService();
            TestActual = new Core.DB.Models.Tests();
            ListadoActual = listado;
        }
        public AdminTestAccionesViewModel()
        {
            _dataService = new DataService();
            TestActual = new Core.DB.Models.Tests();
            ListadoActual = new List<Core.DB.Models.Tests>();
        }
        public void Insertar(int identificador, string descripcion)
        {
            if (_dataService.Existe<TestTask.Core.DB.Models.Tests>("Tests", identificador)) return;
            _dataService.Insertar<TestTask.Core.DB.Models.Tests>("Tests", new Core.DB.Models.Tests { Identificador = identificador, Descripcion = descripcion });


        }
        public void CargarListado()
        {
            ListadoActual = _dataService.ObtenerColeccion<TestTask.Core.DB.Models.Tests>("Tests");


        }
        public void Actualizar(string id, int identificador, string descripcion)
        {
            _dataService.ActualizarExtendido<TestTask.Core.DB.Models.Tests>("Tests", id, identificador, descripcion);


        }
        public void Eliminar(ObjectId id)
        {
            _dataService.Eliminar<TestTask.Core.DB.Models.Tests>("Tests", id);

        }
    }
}