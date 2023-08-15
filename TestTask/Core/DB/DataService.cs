using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using TestTask.Core.DB.Models;

namespace TestTask.Core.DB
{
    public class DataService
    {
        private readonly IMongoDatabase _BBDD;

        public DataService(string cadenaConexion = "mongodb://localhost:27017")
        {
            var cliente = new MongoClient(cadenaConexion);
            _BBDD = cliente.GetDatabase("TestTask");
        }
        public List<Tests> ObtenerTests()
        {
            return _BBDD.GetCollection<Tests>("Tests").Find(_ => true).ToList();
        }
        public List<Preguntas> ObtenerPreguntas()
        {
            return _BBDD.GetCollection<Preguntas>("Preguntas").Find(_ => true).ToList();
        }
        public List<PreguntasRespuestas> ObtenerPreguntasRespuestas()
        {
            return _BBDD.GetCollection<PreguntasRespuestas>("PreguntasRespuestas").Find(_ => true).ToList();
        }
        public List<TestPreguntas> ObtenerTestPreguntas()
        {
            return _BBDD.GetCollection<TestPreguntas>("TestPreguntas").Find(_ => true).ToList();
        }
        public List<Respuestas> ObtenerRespuestas()
        {
            return _BBDD.GetCollection<Respuestas>("Respuestas").Find(_ => true).ToList();
        }
    }
}