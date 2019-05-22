using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    [Table("Voiture")]
    public class Voiture
    {
        public int Id { get; set; }
        public string Plaque { get; set; }
        public string Modele { get; set; }
        public int PlacesDisponible { get; set; }
        public virtual Conducteur Proprietaire { get; set; }

        public override string ToString()
        {
            return $"{Modele}  {Plaque}  {PlacesDisponible}";
        }

        public void RegisterVoiture()
        {
            using (DALVoiture v = new DALVoiture())
            {
                v.RegisterVoiture(this);
            }
        }

        public void RemoveVoiture(Voiture voiture)
        {
            using (DALVoiture v = new DALVoiture())
            {
                v.RemoveVoiture(voiture);
            }
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