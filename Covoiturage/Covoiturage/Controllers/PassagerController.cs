using System;
using System.Collections.Generic;
using Covoiturage.Models.POCO;
using Covoiturage.ActionFilterAttributes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covoiturage.Controllers
{
    [PassagerSessionCheck]
    public class PassagerController : Controller
    {
        Passager passager;
        // GET: Passager
        public ActionResult Index()
        {
            passager = Session["userLoggedUser"] as Passager;
            ViewBag.User = passager.Login;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Home/Index");
        }

        public ActionResult CatalogueTrajet()
        {
            passager = Session["userLoggedUser"] as Passager;
            passager.catalogue.Regen(passager.Id);
            ViewBag.Catalogue = passager.catalogue.trajets;
            return View();
        }

        public ActionResult CheckReservation()
        {
            passager = Session["userLoggedUser"] as Passager;
            Trajet trajet = new Trajet();
            ViewBag.Reservation = trajet.GetReservations(passager);
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(Passager passager)
        {
            ViewBag.EditTest = passager.EditValue(passager, Session["userLoggedUser"] as Passager);
            return View();
        }

        public ActionResult Reservation(int Id)
        {
            passager = Session["userLoggedUser"] as Passager;
            Trajet trajet = new Trajet();
            trajet = trajet.GetTrajet(Id);
            trajet.AddPassager(passager);
            return Redirect("~/Passager/CatalogueTrajet");
        }
        
        [HttpGet]
        public ActionResult Annulation(int Id)
        {
            passager = Session["userLoggedUser"] as Passager;
            Trajet trajet = new Trajet();
            trajet = trajet.GetTrajet(Id);
            trajet.RemovePassager(passager);
            return Redirect("~/Passager/CheckReservation");
        }

    }
}