using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TestTask.Core.Usuario;
using TestTask.Features.Results.ViewModels;

namespace TestTask.Features.Results
{
    [RoutePrefix("Results")]
    public class ResultsController : Controller
    {
        public ResultsController()
        {

        }
        public ActionResult Results()
        {

            return View(new ResultsViewModel((UserContext)Session["Usuario"]));
        }
    }
}

