using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace TestTask.Core.DB.Models
{
    public class Tests
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int Identificador { get; set; }

        public string Descripcion { get; set; }
    }
}