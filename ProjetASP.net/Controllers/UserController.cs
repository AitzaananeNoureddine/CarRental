using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("UserInfo");
        }
        public ActionResult UserInfo()
        {
            return View();
        }
        public ActionResult UpdateUserInfo()
        {
            return View();
        }
        public ActionResult Historique()
        {
            return View();
        }
    }
}

