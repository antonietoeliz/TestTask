using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Core.DB.Models
{
    public class TestPreguntas
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int IdentificadorTest{ get; set; }
        public int IdentificadorPregunta { get; set; }
    }
}