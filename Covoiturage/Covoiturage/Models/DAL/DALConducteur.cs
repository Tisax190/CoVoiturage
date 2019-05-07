using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALConducteur
    {
        private BddContext bdd;
        public DALConducteur()
        {
            bdd = new BddContext();
        }

        public void RegisterDriver(Conducteur driver)
        {
            bdd.ListeConducteur.Add(driver);
            bdd.SaveChanges();
        }
        public Conducteur Login(string pseudo, string mdp)
        {
            Conducteur loggedUser = bdd.ListeConducteur.Where(x => x.Password == mdp && x.Login == pseudo).FirstOrDefault();
            return loggedUser;
        }
    }
}