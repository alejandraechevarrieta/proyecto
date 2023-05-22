using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Clima()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}