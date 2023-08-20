using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Core.Usuario;

namespace TestTask.Features.Results.ViewModels
{
    public class ResultsViewModel
    {
        public UserContext User { get; set; }
        public ResultsViewModel()
        {
        }
        public ResultsViewModel(UserContext usuario)
        {
            User = usuario;
        }
    }
}