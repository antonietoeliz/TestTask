using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Features.Home.ViewModels
{
    public class TestsViewModel
    {
        public string Pregunta { get; set; }
        public int CantidadBotones { get; set; } = 3; 
        public int PorcentajeProgreso => CantidadBotones * 20; // Suponiendo que 5 botones aumentan el progreso en un 20%

        public void OnGet()
        {
            

        }
    }
}