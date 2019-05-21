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
        // GET: Conducteur
        public ActionResult Index()
        {
            try
            {
                conducteur = conducteur.GetConducteur((Conducteur)Session["userLoggedDriver"]);
                if (conducteur == null) Redirect("Home/Index");
            }
            catch
            {
                Redirect("Home/Index");
            }
            return View();
        }

        public ActionResult ListeVoiture()
        {
            try
            {
                conducteur = conducteur.GetConducteur((Conducteur)Session["userLoggedDriver"]);
                if (conducteur == null) Redirect("Home/Index");
            }
            catch
            {
                Redirect("Home/Index");
            }
            ViewBag.DriversCars = conducteur.Voitures;
            return View();
        }
        
        [HttpPost]
        public ActionResult AddVoiture(string plaque, string modele, int places)
        {
            try
            {
                conducteur = conducteur.GetConducteur((Conducteur)Session["userLoggedDriver"]);
                if (conducteur == null) Redirect("Home/Index");
            }
            catch
            {
                Redirect("Home/Index");
            }
            Voiture voiture = new Voiture();
            if(voiture.GetPlaque() == null)
            {
                voiture.Modele = modele;
                voiture.Plaque = plaque;
                voiture.PlacesDisponible = places;
                try
                {
                    voiture.RegisterVoiture();
                }
                catch
                {
                    ViewBag.succes = "Ajout échoué";
                }
            }
            return View();
        }

        public ActionResult AddVoiture()
        {
            return View();
        }
    }
}