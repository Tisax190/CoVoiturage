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
                userTmp.Crypt();
                userTmp.RegisterUser();
            }
            else if(type == "user")
            {
                Passager userTmp = new Passager();
                userTmp.Login = user.Login;
                userTmp.Password = user.Password;
                userTmp.Mail = user.Mail;
                userTmp.Prenom = user.Prenom;
                userTmp.Nom = user.Nom;
                userTmp.Crypt();
                userTmp.RegisterUser();
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
            }
            /*HttpCookie cookie = new HttpCookie(login); a rajouter quand crypt fini ; doit contenir le salt
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookie);*/ 

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.logged = "non";
            return View();
        }

    }
}