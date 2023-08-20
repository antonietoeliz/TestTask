using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;

namespace TestTask.Tests.Core
{
    [TestFixture]
    public class DataServiceTests
    {
        private DataService _dataService;
        private IMongoDatabase _testDatabase;

        [SetUp]
        public void Setup()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            _testDatabase = client.GetDatabase("TestTaskTestDatabase");

            _dataService = new DataService(connectionString);
        }

        [TearDown]
        public void TearDown()
        {
            _testDatabase.DropCollection("Preguntas");
            _testDatabase.DropCollection("Respuestas");
            _testDatabase.DropCollection("PreguntasRespuestas");
            _testDatabase.DropCollection("RespuestasUsuarios");
            _testDatabase.DropCollection("ResultadosUsuarios");
            _testDatabase.DropCollection("TestPreguntas");
            _testDatabase.DropCollection("Tests");
        }

        [Test]
        public void Insertar_DebeInsertarPregunta()
        {
            // Arrange
            var pregunta = new Preguntas
            {
                Identificador = 1,
                Descripcion = "¿Cuál es la capital de Francia?"
            };

            // Act
            _dataService.Insertar("Preguntas", pregunta);
            var coleccion = _dataService.ObtenerColeccion<Preguntas>("Preguntas");

            // Assert
            Assert.IsTrue(coleccion.Any(p => p.Identificador == pregunta.Identificador));
        }

        // Agregar más pruebas para otros métodos y clases

        [Test]
        public void Actualizar_DebeActualizarResultadoUsuario()
        {
            // Arrange
            var resultadoUsuario = new ResultadosUsuarios
            {
                NombreUsuario = "usuario123",
                NumeroRespuestasCorrectas = 5,
                NumeroPreguntasTotales = 10,
                FechaHoraFinalizacionTest = DateTime.Now
            };
            _dataService.Insertar("ResultadosUsuarios", resultadoUsuario);
            var coleccionAntes = _dataService.ObtenerColeccion<ResultadosUsuarios>("ResultadosUsuarios");
            var id = coleccionAntes.First().Id;

            // Act
            resultadoUsuario.NumeroRespuestasCorrectas = 6;
            _dataService.Actualizar("ResultadosUsuarios", id, resultadoUsuario);
            var coleccionDespues = _dataService.ObtenerColeccion<ResultadosUsuarios>("ResultadosUsuarios");

            // Assert
            var resultadoActualizado = coleccionDespues.SingleOrDefault(r => r.Id == id);
            Assert.NotNull(resultadoActualizado);
            Assert.AreEqual(resultadoUsuario.NumeroRespuestasCorrectas, resultadoActualizado.NumeroRespuestasCorrectas);
        }

        [Test]
        public void Insertar_DebeInsertarRespuesta()
        {
            // Arrange
            var respuesta = new Respuestas
            {
                Identificador = 1,
                Descripcion = "París",
                RespuestaCorrecta = true
            };

            // Act
            _dataService.Insertar("Respuestas", respuesta);
            var coleccion = _dataService.ObtenerColeccion<Respuestas>("Respuestas");

            // Assert
            Assert.IsTrue(coleccion.Contains(respuesta));
        }
        [Test]
        public void Actualizar_DebeActualizarRespuesta()
        {
            // Arrange
            var respuesta = new Respuestas
            {
                Identificador = 1,
                Descripcion = "París",
                RespuestaCorrecta = true
            };
            _dataService.Insertar("Respuestas", respuesta);
            var coleccionAntes = _dataService.ObtenerColeccion<Respuestas>("Respuestas");
            var id = coleccionAntes.First().Id;

            // Act
            respuesta.Descripcion = "Nueva descripción";
            _dataService.Actualizar("Respuestas", id, respuesta);
            var coleccionDespues = _dataService.ObtenerColeccion<Respuestas>("Respuestas");

            // Assert
            var respuestaActualizada = coleccionDespues.SingleOrDefault(r => r.Id == id);
            Assert.NotNull(respuestaActualizada);
            Assert.AreEqual(respuesta.Descripcion, respuestaActualizada.Descripcion);
        }

        [Test]
        public void Eliminar_DebeEliminarRespuesta()
        {
            // Arrange
            var respuesta = new Respuestas
            {
                Identificador = 1,
                Descripcion = "París",
                RespuestaCorrecta = true
            };
            _dataService.Insertar("Respuestas", respuesta);
            var coleccionAntes = _dataService.ObtenerColeccion<Respuestas>("Respuestas");
            var id = coleccionAntes.First().Id;

            // Act
            _dataService.Eliminar<Respuestas>("Respuestas", id);
            var coleccionDespues = _dataService.ObtenerColeccion<Respuestas>("Respuestas");

            // Assert
            Assert.True(coleccionAntes.Any(r => r.Identificador == respuesta.Identificador));
            Assert.False(coleccionDespues.Any(r => r.Identificador == respuesta.Identificador));
        }
    }
}
