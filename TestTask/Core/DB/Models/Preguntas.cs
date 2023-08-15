using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Core.DB.Models
{
    public class Preguntas
    {
        public Preguntas()
        {
            RespuestasPregunta = new List<Respuestas>();
        }
        [BsonId]
        public ObjectId Id { get; set; }

        public int Identificador { get; set; }

        public string Descripcion { get; set; }

        public List<Respuestas> RespuestasPregunta { get; set; }
    }
}