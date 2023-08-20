using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Core.DB.Models
{
    public class ResultadosUsuarios
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string NombreUsuario { get; set; }

        public int NumeroRespuestasCorrectas { get; set; }
        public int NumeroPreguntasTotales { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaHoraFinalizacionTest { get; set; }

    }
}