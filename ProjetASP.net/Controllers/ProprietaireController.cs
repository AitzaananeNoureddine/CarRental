using ProjetASP.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{

    public class ProprietaireController : Controller
    {
        private DataBaseDataContext db = new DataBaseDataContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListProprietaire()
        {
            return View();
        }
        public ActionResult Proprietaire_Page(int? id)
        {
            if (id != null)
            {
                User prop = (from p in db.Users
                             where p.Id == id
                             select p).FirstOrDefault();
                var listvoiture = from v in db.Voitures
                                  where v.Proprietaire == prop.Id
                                  select new Voiture_info { voiture = v, user = prop };
                ViewBag.prop = prop;
                ViewBag.listVoiture_prop = listvoiture;

                return View();
            }
            return RedirectToAction("Index", "Home");
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