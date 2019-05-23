using System;
using System.Collections.Generic;
using Covoiturage.Models.POCO;
using Covoiturage.ActionFilterAttributes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace Covoiturage.Controllers
{
    [ConducteurSessionCheck]
    public class ConducteurController : Controller
    {
        Conducteur conducteur;
        Catalogue catalogue = Catalogue.GetInstance;
        // GET: Conducteur
        public ActionResult Index()
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            ViewBag.Driver = conducteur.Login;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Home/Index");
        }

        public ActionResult EditDriver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditDriver(Conducteur driver)
        {
            ViewBag.EditTest = driver.EditValue(driver, Session["userLoggedDriver"] as Conducteur);
            return View();
        }

        public ActionResult ListeVoiture()
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            var voitures = conducteur.GetVoitures();
            ViewBag.DriversCars = voitures;
            return View();
        }
        
        [HttpPost]
        public ActionResult AddVoiture(Voiture v)
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;

            v.Proprietaire = new Conducteur
            {
                Id = conducteur.Id
            };
            try
            {
                v.RegisterVoiture();
                ViewBag.succes = "Ajout effectué";
                return Redirect("~/Conducteur/ListeVoiture");
            }
            catch
            {
                ViewBag.succes = "Ajout échoué";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddVoiture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditVoiture(Voiture voiture)
        {
            voiture.EditValue(voiture, Session["DriversCar"] as Voiture);
            return Redirect("~/Conducteur/ListeVoiture");
        }
        
        public ActionResult EditVoiture(int Id = 0)
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            if (Id<1)
            {
                return Redirect("~/Conducteur/ListeVoiture");
            }
            conducteur.Voitures = conducteur.GetVoitures();
            var temp = conducteur.GetVoiture(Id);
            temp.Proprietaire = conducteur;
            Session["DriversCar"] = temp;
            return View();
        }
        [HttpPost]
        public ActionResult RemoveVoiture(Voiture voiture)
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                voiture.RemoveVoiture(Session["DriversCar"] as Voiture);
                ViewBag.succes = "Suppression effectuée";
            }
            catch
            {
                ViewBag.succes = "Suppression échouée";
                return Redirect("~/Conducteur/ListeVoiture");
            }
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult RemoveVoiture()
        {
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult ListeTrajet()
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            Trajet trajet = new Trajet(); 
            ViewBag.TrajetsConducteur = trajet.GetTrajets(conducteur);
            return View();
        }

        [HttpPost]
        public ActionResult AddTrajet(string Date, Trajet trajet, int Depart, int Terminus , int Voiture)
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            Ville v = new Ville();
            trajet.Conducteur = conducteur.GetConducteur();
            trajet.DateVoyage = Date;
            trajet.VilleDepart = v.GetVille(Depart);
            trajet.VilleTerminus = v.GetVille(Terminus);
            trajet.PlaceRestante = conducteur.GetVoiture(Voiture).PlacesDisponible;
            trajet.AddTrajet();
            return Redirect("~/Conducteur/ListeTrajet");
        }

        public ActionResult AddTrajet()
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            Ville ville = new Ville();
            ViewBag.ListeVille = new SelectList(ville.GetAll(), "Id", null, 1);
            ViewBag.ListeVoiture = new SelectList(conducteur.GetVoitures(), "Id", null, 1);
            return View();
        }

        [HttpPost]
        public ActionResult EditTrajet(string Date, Trajet trajet, int Depart, int Terminus, int Voiture)
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            Ville v = new Ville();
            trajet.Conducteur = conducteur.GetConducteur();
            trajet.DateVoyage = Date.ToString();
            trajet.VilleDepart = v.GetVille(Depart);
            trajet.VilleTerminus = v.GetVille(Terminus);
            trajet.PlaceRestante = conducteur.GetVoiture(Voiture).PlacesDisponible;
            trajet.EditValue(trajet, Session["DriversTrip"] as Trajet);
            return Redirect("~/Conducteur/ListeTrajet");
        }

        public ActionResult EditTrajet(int Id = 0)
        {
            conducteur = Session["userLoggedDriver"] as Conducteur;
            if (Id < 0) return Redirect("~/Conducteur/Index");
            Trajet temp = new Trajet();
            Ville ville = new Ville();
            temp = temp.GetTrajet(Id);
            ViewBag.ListeVilleD = new SelectList(ville.GetAll(), "Id", null, temp.VilleDepart.Id);
            ViewBag.ListeVilleT = new SelectList(ville.GetAll(), "Id", null, temp.VilleTerminus.Id);
            ViewBag.ListeVoiture = new SelectList(conducteur.GetVoitures(), "Id", null, 1);
            Session["DriversTrip"] = temp;
            return View();
        }

        [HttpPost]
        public ActionResult RemoveTrajet(Trajet trajet)
        {
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                var temp = trajet;
                trajet.RemoveTrajet(Session["DriversTrip"] as Trajet);
                ViewBag.succes = "Suppression effectuée";
            }
            catch
            {
                ViewBag.succes = "Suppression échouée";
            }
            return Redirect("~/Conducteur/ListeTrajet");
        }

        public ActionResult RemoveTrajet()
        {
            return Redirect("~/Conducteur/ListeTrajet");
        }
    }

}