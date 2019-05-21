using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Plaque { get; set; }
        public string Modele { get; set; }
        public int PlacesDisponible { get; set; }
        public Conducteur Proprietaire { get; set; }

        public void RegisterVoiture()
        {
            DALVoiture v = new DALVoiture();
            v.RegisterVoiture(this);
        }

        public void ChangePlaque(string newPlaque, Voiture voiture)
        {
            DALVoiture dalVoiture= new DALVoiture();
            dalVoiture.ChangePlaque(newPlaque, voiture);
        }

        public string GetPlaque()
        {
            DALVoiture dalVoiture = new DALVoiture();
            return dalVoiture.GetPlaque(this);
        }

        public int GetPlaces()
        {
            DALVoiture dalVoiture = new DALVoiture();
            return dalVoiture.GetPlaces(this);
        }
    }
}