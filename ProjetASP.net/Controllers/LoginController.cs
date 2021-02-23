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
        // GET: Login
        public ActionResult SignIn(string role)
        {
            ViewBag.role = role;
            return View();
        }
        public ActionResult Verify(string email,string password,string role)
        {
            password = System.Web.Helpers.Crypto.SHA1(password);
            var query = (from user in db.Users
                        where user.Email.Equals(email)
                        where user.Password.Equals(password)
                        where user.Role.Equals(role)
                        select user).FirstOrDefault();
            if(query != null)
            {
                return Content("successful");
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

        public ActionResult Register(string nom, string email, string password,String adresse, string telephone, string role,string status)
        {
            var query = (from u in db.Users
                         where u.Email.Equals(email)
                         select u).FirstOrDefault();
            if (query == null)
            {
                User user = new User()
                {
                    Name = nom,
                    Email = email,
                    Password = System.Web.Helpers.Crypto.SHA1(password),
                    Address = adresse,
                    Phone = telephone,
                    Role = role,
                    Status = status,
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
        public ActionResult RegisterAgency(string nomAgence,string email,string password,string adresse,string telephone,string role)
        {
            return Register(nomAgence,email,password,adresse,telephone,role,"Agence");
        }

        public ActionResult RegisterPrivate(string nom, string email, string password, string adresse, string telephone, string role)
        {
            return Register(nom, email, password, adresse, telephone, role,"Particulier");
        }

        public ActionResult RegisterLocataire(string nom, string email, string password, string telephone,string role)
        {
            return Register(nom, email, password,null, telephone, role,null);
        }
    }
}