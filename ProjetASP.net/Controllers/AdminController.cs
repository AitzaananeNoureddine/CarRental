using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Gestion_profil()
        {
            return View();
        }
        public ActionResult Gestion_Voiture()
        {
            return View();
        }
        public ActionResult Gestion_Resevation()
        {
            return View();
        }
        public ActionResult Gestion_message()
        {
            return View();
        }
    }
}