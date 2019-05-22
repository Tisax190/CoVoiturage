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
            return View();
        }
        [HttpPost]
        public ActionResult Ban(string pseudo, string type)
        {
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            ViewBag.Ban = admin.Ban(pseudo, type);
            return View("Administration");
        }
        [HttpPost]
        public ActionResult UnBan(string pseudo, string type)
        {
            Administrateur admin = new Administrateur();
            ViewBag.UserList = admin.FetchAllUser();
            ViewBag.Ban = admin.UnBan(pseudo, type);
            return View("Administration");
        }
    }
}