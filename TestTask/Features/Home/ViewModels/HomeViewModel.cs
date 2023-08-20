using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Features.Home.ViewModels
{

    public class HomeViewModel
    {
        private readonly DataService _conexion;

        public HomeViewModel()
        {
            _conexion = new DataService();
        }
        public HomeViewModel(DataService conexion)
        {
            _conexion = (conexion == null) ? new DataService() : conexion;
        }
        public string Nombre { get; set; }
        public string Opcion { get; set; }
        public SelectList ListadoOpciones
        {
            get
            {
                List<Core.DB.Models.Tests> tests = _conexion.ObtenerColeccion<Core.DB.Models.Tests>("Tests");
                return new SelectList(tests, "Identificador", "Descripcion");
            }
        }

        public bool sePuedeEnviar
        {
            get
            {
                if (String.IsNullOrEmpty(Nombre) || (Opcion == null)) return false;
                return true;
            }
        }
        public string Notificacion { get; set; }


    }
}