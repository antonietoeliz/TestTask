using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Features.Admin.AdminTests.ViewModels
{
    public class AdminTestAccionesViewModel
    {
        public TestTask.Core.DB.Models.Tests TestActual;
        public List<TestTask.Core.DB.Models.Tests> ListadoActual;
        public AdminTestAccionesViewModel(List<Core.DB.Models.Tests> listado)
        {
            TestActual = new Core.DB.Models.Tests();
            ListadoActual = listado;
        } public AdminTestAccionesViewModel()
        {
            TestActual = new Core.DB.Models.Tests();
            ListadoActual = new List<Core.DB.Models.Tests>();
        }
    }
}