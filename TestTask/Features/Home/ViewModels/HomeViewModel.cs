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
            _conexion =( conexion==null)?new DataService():conexion;
        }
        public string Nombre { get; set; }
        public List<Tests> Opcion { get; set; }
        public SelectList ListadoOpciones
        {
            get
            {
                List<Tests> tests = _conexion.ObtenerTests();
                return new SelectList(tests, "Identificador", "Descripcion");
            }
        }

        public bool sePuedeEnviar
        {
            get
            {
                if (String.IsNullOrEmpty(Nombre) || (Opcion.Count() == 0 || Opcion == null)) return false;
                return true;
            }
        }
        public string Notificacion { get; set; }

        
    }
}