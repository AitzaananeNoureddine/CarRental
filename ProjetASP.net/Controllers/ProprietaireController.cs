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
                         select v).ToList();
            ViewBag.voitures = query;
            return View();
        }
        public ActionResult Ajouter_voiture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajouter_Voiture(string Name, string Imm, string Color, int kilom, int modele, string transition, int price, HttpPostedFileBase image, string offre)
        {
            Voiture v = new Voiture()
            {
                Nom = Name,
                Immatriculation = Imm,
                Couleur = Color,
                Kilometrage = kilom,
                Modele = modele,
                Transition = transition,
                Prix = price,
            };
            if (offre.Equals("true")) v.Offre = 1;
            else v.Offre = 0;
            v.Image = new System.Data.Linq.Binary(new byte[image.ContentLength]);
            image.InputStream.Read(v.Image.ToArray(), 0, image.ContentLength);
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