using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetASP.net.Controllers
{
    public class LoginController : Controller
    {
        private DataBaseDataContext db = new DataBaseDataContext();

        public ActionResult SignIn(string role)
        {
            ViewBag.role = role;
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string email, string password, string role)
        {
            password = System.Web.Helpers.Crypto.SHA1(password);
            var query = (from user in db.Users
                         where user.Email.Equals(email)
                         where user.Password.Equals(password)
                         where user.Role.Equals(role)
                         select user).FirstOrDefault();
            if (query != null)
            {
                Session["UserId"] = query.Id;
                Session["UserRole"] = query.Role;
                if (role.Equals("Proprietaire"))
                {
                    return RedirectToAction("Proprietaire_info", "Proprietaire");
                }
                else return Content("other role");
            }
            else
            {
                ViewBag.role = role;
                ViewBag.error = "Incorrect input !";
                return View("SignIn");
            }
        }

        public ActionResult SignUp(string role)
        {
            ViewBag.role = role;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string nom, string email, string password, String adresse, string telephone, string role, string status)
        {
            var query = (from u in db.Users
                         where u.Email.Equals(email)
                         select u).FirstOrDefault();
            if (query == null)
            {
                User user = new User()
                {
                    Name = nom.Trim(),
                    Email = email.Trim(),
                    Password = System.Web.Helpers.Crypto.SHA1(password).Trim(),
                    Address = adresse.Trim(),
                    Phone = telephone.Trim(),
                    Role = role.Trim(),
                    Status = status.Trim(),
                    Category = 0,
                };
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                return Content("Account registered");
            }
            else
            {
                ViewBag.role = role;
                ViewBag.error = "Email already in use";
                return View("SignUp");
            }
        }
        public ActionResult RegisterAgency(string nomAgence, string email, string password, string adresse, string telephone, string role)
        {
            return SignUp(nomAgence, email, password, adresse, telephone, role, "Agence");
        }

        public ActionResult RegisterPrivate(string nom, string email, string password, string adresse, string telephone, string role)
        {
            return SignUp(nom, email, password, adresse, telephone, role, "Particulier");
        }

        public ActionResult RegisterLocataire(string nom, string email, string password, string telephone, string role)
        {
            return SignUp(nom, email, password, null, telephone, role, null);
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            string r = Session["UserRole"].ToString();
            Session["UserRole"] = null;
            return RedirectToAction("SignIn",new { role = r });
        }
    }
}