using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Features.Tests.ViewModels
{
    public class TestsViewModel
    {
        private readonly DataService _conexion;
        public string TituloPregunta { get; set; }
        public int CantidadBotones { get; set; } = 3;
        public int CantidadPaginas { get; set; } = 0;
        private TestTask.Core.DB.Models.Tests TestSeleccionado { get; set; }
        public Preguntas PreguntaActual { get; set; }
        public int PorcentajeProgreso { get; set; } = 0;

        public TestsViewModel()
        {
            TestSeleccionado = new Core.DB.Models.Tests();
            PreguntaActual = new Preguntas();
            _conexion = new DataService();

        }
        public TestsViewModel(int testSeleccionado)
        {
            TestSeleccionado = new Core.DB.Models.Tests();
            PreguntaActual = new Preguntas();
            _conexion = new DataService();

            CargarObjetos(testSeleccionado);
            Pregunta();
        }
        public void CargarObjetos(int testSeleccionado)
        {
            var listadoDePreguntasPorTest = _conexion.ObtenerColeccion<TestPreguntas>("TestPreguntas").Where(x => x.Test_Id == testSeleccionado);
            TestSeleccionado.Identificador = testSeleccionado;
            foreach (var preguntaTest in listadoDePreguntasPorTest)
            {
                var pregunta = _conexion.ObtenerColeccion<Preguntas>("Preguntas").Where(x => x.Identificador == preguntaTest.Pregunta_Id);
                foreach (var preg in pregunta)
                {
                    CantidadPaginas++;
                    Preguntas preguntaCorrespondiente = preg;
                    var preguntaRespuestas = _conexion.ObtenerColeccion<PreguntasRespuestas>("PreguntasRespuestas").Where(x => x.Pregunta_Id == preguntaCorrespondiente.Identificador);

                    foreach (var respuestasPregunta in preguntaRespuestas)
                    {
                        preguntaCorrespondiente.RespuestasPregunta.Add(_conexion.ObtenerColeccion<Respuestas>("Respuestas").Where(x => x.Identificador == respuestasPregunta.Respuesta_Id).First());
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

        public bool ComprobarRespuestasCorrectas(string[] respuestas)
        {
            if (respuestas == null) return false;
            var numeroRespuestasCorrectasPregunta = PreguntaActual.RespuestasPregunta.Where(x => x.RespuestaCorrecta==true).Count();
            if(respuestas.Length>numeroRespuestasCorrectasPregunta) return false;
            int contadorRespuestasCorrectas = 0;
            for (int i = 0; i < respuestas.Length; i++)
            {
                var consulta = _conexion.ObtenerColeccion<Respuestas>("Respuestas").Where(x => x.Identificador == Convert.ToInt32(respuestas[i])).First();
                if (consulta == null || !consulta.RespuestaCorrecta)
                {
                    continue;
                }
                contadorRespuestasCorrectas++;

            }
            if (contadorRespuestasCorrectas == numeroRespuestasCorrectasPregunta) return true;
            return false;
        }

    }
}