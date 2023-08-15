using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new[]
            {
            "~/Features/{1}/{0}.cshtml",
            "~/Features/{1}/{0}.vbhtml",
            "~/Features/Shared/{0}.cshtml",
            "~/Features/Shared/{0}.vbhtml",
        };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new RazorView(controllerContext, partialPath, layoutPath: null, runViewStartPages: false, viewStartFileExtensions: FileExtensions, viewPageActivator: null);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new RazorView(controllerContext, viewPath, masterPath, runViewStartPages: true, viewStartFileExtensions: FileExtensions, viewPageActivator: null);
        }
    }
}