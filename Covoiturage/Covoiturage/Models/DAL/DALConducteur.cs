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

        public void RegisterDriver(Conducteur driver)
        {
            bdd.ListeConducteur.Add(driver);
            bdd.SaveChanges();
        }
        public Conducteur Login(string pseudo, string mdp)
        {
            return bdd.ListeConducteur.Where(x => x.Password == mdp && x.Login == pseudo).FirstOrDefault();
        }

        public Conducteur Search(Conducteur conducteur)
        {
            return bdd.ListeConducteur.Where(x => x.Id == conducteur.Id).FirstOrDefault();
        }
    }
}