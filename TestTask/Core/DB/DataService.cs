using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


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

        public void Eliminar<T>(string nombreColeccion, ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _BBDD.GetCollection<T>(nombreColeccion).DeleteOne(filter);
        }
    }
}