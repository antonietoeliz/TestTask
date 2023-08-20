using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Features.Admin.AdminPreguntas.ViewModels
{
    public class AdminPreguntasAccionesViewModel
    {
        public Preguntas PreguntaActual;
        private DataService _BBDD;
        public List<Preguntas> ListadoActual;

        public AdminPreguntasAccionesViewModel()
        {
            _BBDD = new DataService();
            PreguntaActual= new Preguntas();
            ListadoActual = new List<Preguntas>();


        }
        public AdminPreguntasAccionesViewModel(List<Preguntas> listado)
        {
            _BBDD = new DataService();
            PreguntaActual = new Preguntas();
            ListadoActual = listado;
        }

        public void CargarListado()
        {
            ListadoActual = _BBDD.ObtenerColeccion<Preguntas>("Preguntas");
        }
        public void Insertar(int identificador, string descripcion)
        {
            if (_BBDD.Existe<Preguntas>("Preguntas", identificador)) return;
            _BBDD.Insertar<Preguntas>("Preguntas", new Core.DB.Models.Preguntas { Identificador = identificador, Descripcion = descripcion });


        }
        public void Actualizar(string id, int identificador, string descripcion)
        {
            _BBDD.ActualizarExtendido<Preguntas>("Preguntas", id, identificador, descripcion);

        }
        public void Eliminar(ObjectId id)
        {
            _BBDD.Eliminar<Preguntas>("Preguntas", id);

        }
    }
}