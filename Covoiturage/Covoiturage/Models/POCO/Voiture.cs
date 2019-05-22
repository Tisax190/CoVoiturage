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

        public void RemoveVoiture(Voiture voiture)
        {
            DALVoiture dal = new DALVoiture();
            dal.RemoveVoiture(voiture);
        }

        public void EditValue(Voiture voiture, Voiture session)
        {
            DALVoiture dalVoiture= new DALVoiture();
            dalVoiture.EditValue(voiture, session);
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