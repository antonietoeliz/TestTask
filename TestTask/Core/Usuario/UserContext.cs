using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB.Models;

namespace TestTask.Core.Usuario
{
    public class UserContext
    {
        public UserContext()
        {

        }
        public string Nombre { get; set; }
        public int NumeroRespuestasCorrectas { get; set; }
        public int NumeroPreguntas { get; set; }
        public int IdentificadorTest { get; set; }
    }
}