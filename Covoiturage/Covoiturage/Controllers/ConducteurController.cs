﻿using System;
using System.Collections.Generic;
using Covoiturage.Models.POCO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace Covoiturage.Controllers
{
    public class ConducteurController : Controller
    {
        Conducteur conducteur;
        Catalogue catalogue = Catalogue.GetInstance;
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
            try
            {
                conducteur = Session["userLoggedDriver"] as Conducteur;
                ViewBag.Driver = conducteur.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            var voitures = conducteur.GetVoitures();
            ViewBag.DriversCars = voitures;
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

        [HttpPost]
        public ActionResult EditVoiture(Voiture voiture)
        {
            voiture.EditValue(voiture, Session["DriversCar"] as Voiture);
            return Redirect("~/Conducteur/ListeVoiture");
        }
        
        public ActionResult EditVoiture(int Id = 0)
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
            if(Id<1)
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
                ViewBag.Driver = conducteur.Login;
                voiture.RemoveVoiture(Session["DriversCar"] as Voiture);
                ViewBag.succes = "Suppression effectuée";
            }
            catch
            {
                ViewBag.succes = "Suppression échouée";
                return Redirect("~/Conducteur/Index");
            }
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult RemoveVoiture()
        {
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Home/Index");
        }

        public ActionResult ListeTrajet()
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
            catalogue.Regen(conducteur);
            ViewBag.TrajetsConducteur = catalogue.trajets;
            return View();
        }

        [HttpPost]
        public ActionResult AddTrajet(string Date, Trajet trajet, int Depart, int Terminus , int Voiture)
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
            Ville v = new Ville();
            trajet.Conducteur = conducteur.GetConducteur();
            trajet.DateVoyage = Date.ToString();
            trajet.VilleDepart = v.GetVille(Depart);
            trajet.VilleTerminus = v.GetVille(Terminus);
            trajet.PlaceRestante = conducteur.GetVoiture(Voiture).PlacesDisponible;
            trajet.AddTrajet();
            return Redirect("~/Conducteur/ListeTrajet");
        }

        public ActionResult AddTrajet()
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
            Ville ville = new Ville();
            ViewBag.ListeVille = new SelectList(ville.GetAll(), "Id", null, 1);
            ViewBag.ListeVoiture = new SelectList(conducteur.GetVoitures(), "Id", null, 1);
            return View();
        }
    }

}