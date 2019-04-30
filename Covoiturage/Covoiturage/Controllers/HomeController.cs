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
                Conducteur userTmp = user as Conducteur;
                userTmp.RegisterUser();
            }
            else
            {

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();

        }

    }
}