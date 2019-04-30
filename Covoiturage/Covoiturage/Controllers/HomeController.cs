using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covoiturage.Models.POCO;

namespace Covoiturage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
    }
}