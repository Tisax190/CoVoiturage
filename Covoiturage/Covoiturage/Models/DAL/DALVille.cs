using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALVille
    {
        private BddContext bdd;
        public DALVille()
        {
            bdd = new BddContext();
        }

        public void RegisterVille(Ville ville)
        {
            bdd.ListeVille.Add(ville);
        }
    }
}