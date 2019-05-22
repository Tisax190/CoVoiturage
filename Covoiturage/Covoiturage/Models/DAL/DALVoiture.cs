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
            voiture.Proprietaire = bdd.ListeConducteur.Where(c => c.Login == voiture.Proprietaire.Login && c.Password == voiture.Proprietaire.Password).FirstOrDefault();
            bdd.ListeVoiture.Add(voiture);
            bdd.SaveChanges();
        }

        public void RemoveVoiture(Voiture voiture)
        {
            voiture = bdd.ListeVoiture.Where(v => v.Id == voiture.Id).FirstOrDefault();
            bdd.ListeVoiture.Remove(voiture);
            bdd.SaveChanges();
        }

        public void ChangePlaque(string plaque, Voiture voiture)
        {
            Voiture modif = bdd.ListeVoiture.Where(v => v.Id == voiture.Id).FirstOrDefault();
            modif.Plaque = plaque;
            bdd.SaveChanges();
        }

        public string GetPlaque(Voiture voiture)
        {
            return bdd.ListeVoiture.Where(v => v.Id == voiture.Id).Select(v => v.Plaque).FirstOrDefault();
        }

        public int GetPlaces(Voiture voiture)
        {
            return bdd.ListeVoiture.Where(v => v.Id == voiture.Id).Select(v => v.PlacesDisponible).FirstOrDefault();
        }

        public Voiture GetVoiture(int Id)
        {
            return bdd.ListeVoiture.Where(v => v.Id == Id).FirstOrDefault();
        }

        public List<Voiture> GetVoitures(Conducteur c)
        {
            return bdd.ListeVoiture.Where(v => v.Proprietaire.Id == c.Id).ToList();
        }


    }
}