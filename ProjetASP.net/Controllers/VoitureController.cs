using ProjetASP.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{
    public class VoitureController : Controller
    {
        private DataBaseDataContext db = new DataBaseDataContext();

        [HttpGet]
        public ActionResult Index(int? VoitureId)
        {
            if (VoitureId != null)
            {
                Voiture_info voiture = (from v in db.Voitures
                                        join p in db.Users on v.Proprietaire equals p.Id
                                        where v.Id == VoitureId
                                        select new Voiture_info { voiture = v, user = p }).FirstOrDefault();


                var listvoiture = from v in db.Voitures
                                  where v.Proprietaire == voiture.user.Id
                                  select new Voiture_info { voiture = v, user = voiture.user };

                ViewBag.info = voiture;
                ViewBag.list = listvoiture;
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult ListVoiture()
        {
            var listVoiture = from v in db.Voitures
                              join p in db.Users on v.Proprietaire equals p.Id
                              select new Voiture_info { voiture = v, user = p };
            return View(listVoiture.ToList());
        }
        [HttpPost]
        public ActionResult ListVoiture(string TextRecherche, string RecherchePar)
        {
            try
            {
                if (RecherchePar.Equals("Nom"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where v.Nom.Contains(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());
                }
                if (RecherchePar.Equals("Marque"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where v.Marque.Contains(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());
                }
                if (RecherchePar.Equals("Couleur"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where v.Couleur.Contains(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());
                }
                if (RecherchePar.Equals("Annee"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where v.Modele == Convert.ToInt32(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());

                }
                if (RecherchePar.Equals("Km"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where v.Kilometrage == Convert.ToInt32(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());
                }
                if (RecherchePar.Equals("Proprietaire"))
                {
                    var listVoiture = from v in db.Voitures
                                      join p in db.Users on v.Proprietaire equals p.Id
                                      where p.Name.Contains(TextRecherche)
                                      select new Voiture_info { voiture = v, user = p };

                    return View(listVoiture.ToList());
                }
            }
            catch (Exception) { }
            return View();
        }


        public ActionResult Reserver(int id)
        {
            Voiture voiture = (from v in db.Voitures
                               where v.Id == id
                               select v).FirstOrDefault();
            ViewBag.voiture = voiture;
            return View();
        }
    }
}


