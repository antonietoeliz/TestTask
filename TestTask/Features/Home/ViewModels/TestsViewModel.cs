using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Features.Home.ViewModels
{
    public class TestsViewModel
    {
        private readonly DataService _conexion;
        public string TituloPregunta { get; set; }
        public int CantidadBotones { get; set; } = 3; 
        public int CantidadPaginas { get; set; } = 0;
        private Tests TestSeleccionado { get; set; }
        public Preguntas PreguntaActual { get; set; }
        public int PorcentajeProgreso { get; set; } = 0;

        public TestsViewModel()
        {
            TestSeleccionado = new Tests();
            PreguntaActual = new Preguntas();
            _conexion = new DataService();

        }
        public TestsViewModel(int testSeleccionado)
        {
            TestSeleccionado = new Tests();
            PreguntaActual = new Preguntas();
            _conexion = new DataService();

            CargarObjetos(testSeleccionado);
            Pregunta();
        }
        public void CargarObjetos(int testSeleccionado)
        {
            var listadoDePreguntasPorTest = _conexion.ObtenerTestPreguntas().Where(x => x.Test_Id == testSeleccionado);
            TestSeleccionado.Identificador = testSeleccionado;
            foreach (var preguntaTest in listadoDePreguntasPorTest)
            {
                var pregunta = _conexion.ObtenerPreguntas().Where(x => x.Identificador == preguntaTest.Pregunta_Id);
                foreach (var preg in pregunta)
                {
                    CantidadPaginas++;
                    Preguntas preguntaCorrespondiente = preg;
                    var preguntaRespuestas = _conexion.ObtenerPreguntasRespuestas().Where(x => x.Pregunta_Id == preguntaCorrespondiente.Identificador);

                    foreach (var respuestasPregunta in preguntaRespuestas)
                    {
                        preguntaCorrespondiente.RespuestasPregunta.Add(_conexion.ObtenerRespuestas().Where(x => x.Identificador == respuestasPregunta.Respuesta_Id).First());
                    }
                    TestSeleccionado.Preguntas.Add(preguntaCorrespondiente);
                }



            }
            CantidadPaginas = TestSeleccionado.Preguntas.Count();
        }
               
        public Preguntas Pregunta()
        {
            var preguntasCompletadas = CantidadPaginas - TestSeleccionado.Preguntas.Count();
            preguntasCompletadas++;
            PorcentajeProgreso = (preguntasCompletadas / CantidadPaginas) * 100;
            PreguntaActual = TestSeleccionado.Preguntas.FirstOrDefault();
            TestSeleccionado.Preguntas.Remove(PreguntaActual);
            return PreguntaActual;
        }


    }
}