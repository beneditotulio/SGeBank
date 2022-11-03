using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGeBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tua pagina de descricao da aplicacao.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tua pagina de contacto.";

            return View();
        }
    }
}