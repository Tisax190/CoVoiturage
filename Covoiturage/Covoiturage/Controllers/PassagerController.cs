using System;
using System.Collections.Generic;
using Covoiturage.Models.POCO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covoiturage.Controllers
{
    public class PassagerController : Controller
    {
        Passager passager;
        // GET: Passager
        public ActionResult Index()
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Home/Index");
        }

        public ActionResult CatalogueTrajet()
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            passager.catalogue.Regen(passager.Id);
            ViewBag.Catalogue = passager.catalogue.trajets;
            return View();
        }

        public ActionResult CheckReservation()
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            Trajet trajet = new Trajet();
            ViewBag.Reservation = trajet.GetReservations(passager);
            return View();
        }

        public ActionResult EditUser()
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
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
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            Trajet trajet = new Trajet();
            trajet = trajet.GetTrajet(Id);
            trajet.AddPassager(passager);
            return Redirect("~/Passager/CatalogueTrajet");
        }
        
        [HttpGet]
        public ActionResult Annulation(int Id)
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Passager = passager.Login;
            }
            catch
            {
                return Redirect("~/Passager/Index");
            }
            Trajet trajet = new Trajet();
            trajet = trajet.GetTrajet(Id);
            trajet.RemovePassager(passager);
            return Redirect("~/Passager/CheckReservation");
        }

    }
}