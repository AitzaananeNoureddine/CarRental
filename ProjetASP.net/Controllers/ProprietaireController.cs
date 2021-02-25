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
        // GET: Proprietaire
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
            /*return Content(Session["UserId"].ToString());*/
        }
        public ActionResult Update_Proprietaire_Info()
        {
            return View();
        }
        public ActionResult reservation()
        {
            /*var query = from loc in db.Users
                        where loc.Role.Equals("Locataire")
                        join res in db.Reservations on loc.Id equals res.Locataire
                        join v in db.Voitures on res.Voiture equals v.Id
                        select new
                        {
                            VoitureNom = v.Nom,
                        }*/
            return View();
        }
        public ActionResult Liste_Voiture()
        {
            var query = (from v in db.Voitures
                         where v.Proprietaire.Equals(Convert.ToInt32(Session["UserId"]))
                         select v).ToList();
            ViewBag.voitures = query;
            return View();
        }
        public ActionResult Ajouter_voiture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajouter_Voiture(string Name, string Imm, string Color, int kilom, int modele, string transition, int price, HttpPostedFileBase image, string offre,string marque)
        {
            Voiture v = new Voiture()
            {
                Proprietaire = Convert.ToInt32(Session["UserId"]),
                Nom = Name,
                Immatriculation = Imm,
                Couleur = Color,
                Kilometrage = kilom,
                Modele = modele,
                Transition = transition,
                Prix = price,
                Image = image.FileName,
                Marque = marque,
            };
            
            if (offre.Equals("true")) v.Offre = 1;
            else v.Offre = 0;
            db.Voitures.InsertOnSubmit(v);
            db.SubmitChanges();
            ViewBag.msg = "Voiture ajoutée !";
            return View("Ajouter_voiture");
        }
        public ActionResult Update_voiture()
        {
            return View();
        }

    }
}