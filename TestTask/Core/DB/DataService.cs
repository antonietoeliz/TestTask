using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;


namespace TestTask.Core.DB
{
    public class DataService
    {
        private readonly IMongoDatabase _BBDD;

        public DataService(string nombreConexion = "TestTaskBBDDLocal")
        {
            var cadenaConexion = ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString;
            var cliente = new MongoClient(cadenaConexion);
            _BBDD = cliente.GetDatabase("TestTask");
        }
        public List<T> ObtenerColeccion<T>(string nombreColeccion)
        {
            return _BBDD.GetCollection<T>(nombreColeccion).Find(_ => true).ToList();
        }
        public void Insertar<T>(string nombreColeccion, T objeto)
        {
            _BBDD.GetCollection<T>(nombreColeccion).InsertOne(objeto);
        }

        public void Actualizar<T>(string nombreColeccion, ObjectId id, T objeto)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _BBDD.GetCollection<T>(nombreColeccion).ReplaceOne(filter, objeto);
        }
        public void ActualizarExtendido<T>(string nombreColeccion, string id, int nuevoValorIdentificador, string nuevoValorDescripcion)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var update = Builders<T>.Update
                .Set("Identificador", nuevoValorIdentificador)
                .Set("Descripcion", nuevoValorDescripcion);

            _BBDD.GetCollection<T>(nombreColeccion).UpdateOne(filter, update);
        }
        public void Eliminar<T>(string nombreColeccion, ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _BBDD.GetCollection<T>(nombreColeccion).DeleteOne(filter);
        }
        public bool Existe<T>(string nombreColeccion, int id)
        {
            var filter = Builders<T>.Filter.Eq("Identificador", id);
            var resultado = _BBDD.GetCollection<T>(nombreColeccion).Find(filter).Any();
            return resultado;
        }
    }
}