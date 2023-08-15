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

        public int Test_Id{ get; set; }
        public int Pregunta_Id { get; set; }
    }
}