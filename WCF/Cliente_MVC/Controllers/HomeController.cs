using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceReferencePersona.WCF_PersonaClient personasCliente = new ServiceReferencePersona.WCF_PersonaClient();

            return View(personasCliente.GetAll().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}