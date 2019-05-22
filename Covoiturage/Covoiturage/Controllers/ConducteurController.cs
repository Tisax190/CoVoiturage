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
            conducteur.Voitures = conducteur.GetVoitures(conducteur);
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

            voiture.Modele = v.Modele;
            voiture.Plaque = v.Plaque;
            voiture.PlacesDisponible = v.PlacesDisponible;
            voiture.Proprietaire = conducteur.GetConducteur(conducteur);
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
            conducteur.Voitures = conducteur.GetVoitures(conducteur);
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
                voiture.RemoveVoiture();
                ViewBag.succes = "Suppression effectuée";
            }
            catch
            {
                ViewBag.succes = "Suppression échouée";
                return Redirect("~/Home/Index");
            }
            return View();
        }

    public ActionResult RemoveVoiture()
        {
            return Redirect("~/Conducteur/ListeVoiture");
        }

        public ActionResult Logout()
        {
            Session["userLoggedDriver"] = null;
            Session.Abandon();
            return Redirect("~/Home/Index");
        }
    }

}