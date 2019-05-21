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
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }

        public ActionResult ListeVoiture()
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            ViewBag.DriversCars = conducteur.Voitures;
            return View();
        }
        
        [HttpPost]
        public ActionResult AddVoiture(Voiture v)
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            Voiture voiture = new Voiture();
            if(voiture.GetPlaque() == null)
            {
                voiture.Modele = v.Modele;
                voiture.Plaque = v.Plaque;
                voiture.PlacesDisponible = v.PlacesDisponible;
                voiture.Proprietaire = conducteur;
                try
                {
                    voiture.RegisterVoiture();
                    ViewBag.succes = "Ajout effectué";
                    return Redirect("~/Conducteur/ListeVoiture");
                }
                catch
                {
                    ViewBag.succes = "Ajout échoué";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddVoiture()
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
        
        public ActionResult EditVoiture(int Id)
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            ViewBag.Car = conducteur.Voitures.Where(v => v.Id == Id).FirstOrDefault();
            return View();
        }

        public ActionResult EditVoiture()
        {
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult Logout()
        {
            Session["userLoggedDriver"] = null;
            return Redirect("~/Home/Index");
        }
    }
}