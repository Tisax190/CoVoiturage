﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Covoiturage.Models.POCO;
using Covoiturage.Models.DAL;
using System.Security.Cryptography;

namespace Covoiturage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();

        }
        // Maybe do this in an other class inside a Business Layer?

        [HttpPost]
        public ActionResult Register(Utilisateur user, string type)
        {
            if(type=="driver")
            {
                Conducteur userTmp = new Conducteur();
                userTmp.Login = user.Login;
                userTmp.Password = user.Password;
                userTmp.Mail = user.Mail;
                userTmp.Prenom = user.Prenom;
                userTmp.Nom = user.Nom;
                userTmp.AnneeExperience = 1;
                userTmp.IsBanned = false;
                userTmp.Crypt();
                ViewBag.Register = userTmp.RegisterUser();
            }
            else if(type == "user")
            {
                Passager userTmp = new Passager();
                userTmp.Login = user.Login;
                userTmp.Password = user.Password;
                userTmp.Mail = user.Mail;
                userTmp.Prenom = user.Prenom;
                userTmp.Nom = user.Nom;
                userTmp.IsBanned = false;
                userTmp.Crypt();
                ViewBag.Register = userTmp.RegisterUser();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string login, string password,string type)
        {   
            if (type=="driver")
            {
                Conducteur cdt = new Conducteur();
                try
                {
                    cdt = cdt.LoginConducteur(login,password);
                    if(cdt.IsBanned)
                    {
                        return Redirect("~/Home/Ban");
                    }
                    Session["userLoggedDriver"] = cdt;
                    ViewBag.logged = cdt.Login;
                }
                catch
                {
                    ViewBag.logged = "non";
                    return View();
                }
                return Redirect("~/Conducteur/Index");
            }
            else if(type=="user")
            {
                Passager psg = new Passager();
                try
                {
                    psg=psg.LoginPassager(login, password);
                    if (psg.IsBanned)
                    {
                        return Redirect("~/Home/Ban");
                    }
                    Session["userLoggedUser"] = psg;
                    ViewBag.logged = psg.Login;
                }
                catch
                {
                    ViewBag.logged = "non";
                    return View();
                }
                return Redirect("~/Passager/Index");
            }
            else if (type == "admin")
            {
                Administrateur psg = new Administrateur();
                try
                {
                    psg = psg.LoginAdmin(login, password);
                    Session["userLoggedAdmin"] = psg;
                    ViewBag.logged = psg.Login;
                }
                catch
                {
                    ViewBag.logged = "non";
                    return View();
                }
                return Redirect("~/Admin/Administration");
            }
            /*HttpCookie cookie = new HttpCookie(login); a rajouter quand crypt fini ; doit contenir le salt
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(cookie);*/

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.logged = "non";
            return View();
        }
        public ActionResult Disconnect()
        {
            Session.Abandon();
            return View();
        }


    }
}