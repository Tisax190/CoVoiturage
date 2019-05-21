using System;
using System.Collections.Generic;
using Covoiturage.Models.POCO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covoiturage.Controllers
{
    public class ConducteurController : Controller
    {
        Conducteur conducteur;
        //Vérifie si bien connecté
        private void Verif()
        {
            if (Session["userLoggedDriver"] == null || !(Session["userLoggedDriver"] is Conducteur)) Redirect("Home/Login");
            conducteur = conducteur.GetConducteur((Conducteur)Session["userLoggedDriver"]);
        }
        // GET: Conducteur
        public ActionResult Index()
        {
            Verif();
            return View();
        }

        public ActionResult ListeVoiture()
        {
            Verif();
            ViewData["DriversCars"] = conducteur.Voitures;
            return View();
        }
        
        public ActionResult AddVoiture(string plaque, string modele, int places)
        {
            Verif();
            
            return View();
        }
    }
}