using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Core.DB.Models
{
    public class PreguntasRespuestas
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int IdentificadorPregunta { get; set; }
        public int IdentificadorRespuesta { get; set; }
    }
}