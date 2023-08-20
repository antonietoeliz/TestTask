using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Core.DB.Models
{
    public class RespuestasUsuarios
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string NombreUsuario { get; set; }
        public int Test_Id { get; set; }
        public int Pregunta_Id { get; set; }
        public int Respuesta_Id { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaHoraRespuesta { get; set; }
    }
}