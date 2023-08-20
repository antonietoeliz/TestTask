using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.DB;
using TestTask.Core.DB.Models;
using TestTask.Core.Usuario;

namespace TestTask.Features.Results.ViewModels
{
    public class ResultsViewModel
    {
        public UserContext User { get; set; }
        private DataService _BBDD { get; set; }
        public ResultsViewModel()
        {
        }
        public ResultsViewModel(UserContext usuario)
        {
            User = usuario;
            _BBDD=new DataService();
            _BBDD.Insertar<ResultadosUsuarios>("ResultadosUsuarios", new ResultadosUsuarios
            {
                NombreUsuario = usuario.Nombre,
                NumeroRespuestasCorrectas = usuario.NumeroRespuestasCorrectas,
                NumeroPreguntasTotales = usuario.NumeroPreguntas,
                FechaHoraFinalizacionTest = DateTime.Now
            });
        }
    }
}