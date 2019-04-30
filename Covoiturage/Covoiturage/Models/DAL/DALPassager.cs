using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALPassager
    {
        private BddContext bdd;
        public DALPassager()
        {
            bdd = new BddContext();
        }

        public void RegisterPassager(Passager passager)
        {
            bdd.ListePassager.Add(passager);
            bdd.SaveChanges();
        }
    }
}