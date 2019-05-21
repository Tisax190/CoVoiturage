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

        public void ChangePlaque(string plaque, Voiture voiture)
        {
            Voiture modif = bdd.ListeVoiture.Where(v => v.Id == voiture.Id).FirstOrDefault();
            modif.Plaque = plaque;
            bdd.SaveChanges();
        }
    }
}