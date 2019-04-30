using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALUser
    {
        private BddContext bdd;
        public DALUser()
        {
            bdd = new BddContext();
        }

        public void RegisterDriver(Conducteur driver)
        {
            bdd.ListeConducteur.Add(driver);   
        }
    }
}