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

        private void Verif()
        {
            if (Session["userLoggedDriver"] == null || !(Session["userLoggedDriver"] is Passager)) Redirect("Home/Login");
        }
        // GET: Passager
        public ActionResult Index()
        {
            Verif();
            return View();
        }
    }
}