using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using TestTask.Core.Usuario;
using TestTask.Features.Admin.ViewModels;

namespace TestTask.Features.Admin
{
    [RoutePrefix("/")]
    public class AdminController : Controller
    {
        public AdminController()
        {

        }
        public ActionResult AdminView()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string password)
        {
            AdminViewModel viewModel = new AdminViewModel();
            if (viewModel.ComprobarContraseña(password))
            {
                return RedirectToAction("Index","AdminTests");
            }            
            else
            {
                ViewBag.ErrorMessage = "Contraseña incorrecta.";
                return View("AdminView");
            }
        }
       
    }
}