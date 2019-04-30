using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALVoiture
    {
        private BddContext bdd;
        public DALVoiture()
        {
            bdd = new BddContext();
        }

        public void RegisterVoiture(Voiture voiture)
        {
            bdd.ListeVoiture.Add(voiture);
        }
    }
}