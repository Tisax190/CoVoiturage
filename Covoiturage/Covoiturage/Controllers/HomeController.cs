using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covoiturage.Models.POCO;
using Covoiturage.Models.DAL;

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

    }
}