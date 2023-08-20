using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Features.Admin.AdminRespuestas.ViewModels
{
    public class AdminRespuestasAccionesViewModel
    {
        public Respuestas PreguntaActual;
        private DataService _BBDD;
        public List<Respuestas> ListadoActual;

        public AdminRespuestasAccionesViewModel()
        {
            _BBDD = new DataService();
            PreguntaActual= new Respuestas();
            ListadoActual = new List<Respuestas>();


        }
        public AdminRespuestasAccionesViewModel(List<Respuestas> listado)
        {
            _BBDD = new DataService();
            PreguntaActual = new Respuestas();

            ListadoActual = listado;
        }

        public void CargarListado()
        {
            ListadoActual = _BBDD.ObtenerColeccion<Respuestas>("Respuestas");
        }
        public void Insertar(int identificador, string descripcion)
        {
            if (_BBDD.Existe<Respuestas>("Respuestas", identificador)) return;
            _BBDD.Insertar<Respuestas>("Respuestas", new Core.DB.Models.Respuestas { Identificador = identificador, Descripcion = descripcion });


        }
        public void Actualizar(string id, int identificador, string descripcion)
        {
            _BBDD.ActualizarExtendido<Respuestas>("Respuestas", id, identificador, descripcion);

        }
        public void Eliminar(ObjectId id)
        {
            _BBDD.Eliminar<Respuestas>("Respuestas", id);

        }
    }
}