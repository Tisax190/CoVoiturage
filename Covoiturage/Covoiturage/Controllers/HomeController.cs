using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covoiturage.Models.POCO;
using Covoiturage.Models.DAL;
using System.Security.Cryptography;

namespace Covoiturage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(Utilisateur user, string type)
        {
            if(type=="driver")
            {
                Conducteur userTmp = new Conducteur();
                userTmp.Login = user.Login;
                userTmp.Password = user.Password;
                userTmp.Mail = user.Mail;
                userTmp.Prenom = user.Prenom;
                userTmp.Nom = user.Nom;
                userTmp.AnneeExperience = 1;
                userTmp.RegisterUser();
            }
            else if(type == "user")
            {
                Passager psgTmp = user as Passager;
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(string login, string password,string type)
        {
            /*Utilisateur userCrypt = new Utilisateur();
            var salt = userCrypt.GenSalt();
            string passwordSalt = password + (Convert.ToBase64String(salt));

            HashAlgorithm algorithm = new SHA1Managed();
            var passwordSaltByte = System.Text.Encoding.ASCII.GetBytes(passwordSalt);
            var crypted = Convert.ToBase64String(algorithm.ComputeHash(passwordSaltByte));*/
            
            if (type=="driver")
            {
                Conducteur cdt = new Conducteur();
                cdt = cdt.LoginConducteur(login,password);
                Session["userLoggedDriver"] = cdt;
                ViewBag.logged = cdt.Login;
            }
            else if(type=="user")
            {
                Passager psg = new Passager();
                psg=psg.LoginPassager(login, password);
                Session["userLoggedDriver"] = psg; // session ok
                ViewBag.logged = psg.Login;

                /*HttpCookie cookie = new HttpCookie(login);
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);*/
            }
            
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.logged = "non";
            return View();
        }

    }
}