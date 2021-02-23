using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{
    public class ProprietaireController : Controller
    {
        // GET: Proprietaire
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListProprietaire()
        {
            return View();
        }
        public ActionResult Proprietaire_Page(string id = "")
        {
            return View();
        }
        public ActionResult Proprietaire_Info()
        {
            return View();
        }
        public ActionResult Update_Proprietaire_Info()
        {
            return View();
        }
        public ActionResult reservation()
        {
            return View();
        }
        public ActionResult Liste_Voiture()
        {
            return View();
        }
        public ActionResult Ajouter_voiture()
        {
            return View();
        }
        public ActionResult Update_voiture()
        {
            return View();
        }

    }
}