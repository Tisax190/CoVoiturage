using Covoiturage.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covoiturage.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Administration()
        {
            if(Session["UserLoggedAdmin"] as Administrateur == null)
            {
                return View("AccessDenied");
            }
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            Trajet traj = new Trajet();
            ViewBag.TrajetListe = traj.GetTrajets();
            return View();
        }
        [HttpPost]
        public ActionResult Ban(string pseudo, string type)
        {
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            ViewBag.Ban = admin.Ban(pseudo, type);
            Trajet traj = new Trajet();
            ViewBag.TrajetListe = traj.GetTrajets();
            return View("Administration");
        }
        [HttpPost]
        public ActionResult UnBan(string pseudo, string type)
        {
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            ViewBag.Ban = admin.UnBan(pseudo, type);
            Trajet traj = new Trajet();
            ViewBag.TrajetListe = traj.GetTrajets();
            return View("Administration");
        }
        [HttpPost]
        public ActionResult ForceDeleteTrajet(string trajet)
        {
            int tmp = Convert.ToInt32(trajet);
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            admin.ForceDeleteTrajet(tmp);
            Trajet traj = new Trajet();
            ViewBag.TrajetListe = traj.GetTrajets();
            return View("Administration");
        }
    }
}