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
        private bool Verif()
        {
            if (Session["userLoggedDriver"] == null || !(Session["userLoggedDriver"] is Passager)) return false;
            return true;
        }
        // GET: Passager
        public ActionResult Index()
        {
            if (Verif()) Redirect("Home/Login");
            return View();
        }
    }
}