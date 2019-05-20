using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALConducteur : IDisposable
    {
        private BddContext bdd;
        public DALConducteur()
        {
            bdd = new BddContext();
        }
        
        ~DALConducteur()
        {
            Dispose();
        }

        private bool Disposed = false;
        public void Dispose()
        {
            if (!Disposed)
            {
                GC.SuppressFinalize(this);
                Disposed = true;
            }
        }

        public string RegisterDriver(Conducteur driver)
        {
            if ((bdd.ListeConducteur.Where(x => x.Login == driver.Login).FirstOrDefault()) != null)
            {
                return "Pseudo déja utilisé";
            }
            bdd.ListeConducteur.Add(driver);
            bdd.SaveChanges();
            return "ok";
        }
        public Conducteur Login(string pseudo, string mdp)
        {
            Conducteur loggedUser = bdd.ListeConducteur.Where(x => x.Password == mdp && x.Login == pseudo).FirstOrDefault();
            return loggedUser;
        }
        public string EditValue(Conducteur driver,Conducteur session)
        {
            var tmp = bdd.ListeConducteur.Where(x => x.Id == session.Id).FirstOrDefault();
            tmp.Nom = driver.Nom;
            tmp.Prenom = driver.Prenom;
            tmp.Mail = driver.Mail; // faire le mdp
            session = tmp;
            bdd.SaveChanges();
            return "ok";
        }
    }
}