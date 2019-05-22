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
            if (Session["userLoggedUser"] == null || !(Session["userLoggedUser"] is Passager)) return false;
            return true;
        }
        // GET: Passager
        public ActionResult Index()
        {
            try
            {
                passager = Session["userLoggedUser"] as Passager;
                ViewBag.Driver = passager.Login;
            }
            catch
            {
                return Redirect("~/Home/Index");
            }
            return View();
        }
    }
}