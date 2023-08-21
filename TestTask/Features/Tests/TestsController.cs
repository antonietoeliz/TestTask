using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TestTask.Core.Usuario;
using TestTask.Features.Tests.ViewModels;

namespace TestTask.Features.Tests
{
    [RoutePrefix("Tests")]
    public class TestsController : Controller
    {
        public TestsController()
        {

        }
        public ActionResult Tests(TestsViewModel modelo)
        {
            if (modelo.TituloPregunta == null)
            {
                modelo = (TestsViewModel)TempData["ModeloTest"];
                TempData.Keep();
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult TestSiguiente(FormCollection form)
        {
            var modelo = (TestsViewModel)TempData["ModeloTest"];
            TempData.Keep();
            var selectedOptions = form.AllKeys;
            if (selectedOptions.Length == 0) return RedirectToAction("Tests");

            var usuario = (UserContext)Session["Usuario"];
            usuario.NumeroPreguntas = modelo.CantidadPaginas;

            if (modelo.ComprobarRespuestasCorrectas(usuario.Nombre, selectedOptions))
            {
                usuario.NumeroRespuestasCorrectas++;
                Session["Usuario"] = usuario;
            }
            var preguntaSiguiente = modelo.Pregunta();
            if (preguntaSiguiente == null) return RedirectToAction("Results", "Results");
            return RedirectToAction("Tests");
        }

    }
}