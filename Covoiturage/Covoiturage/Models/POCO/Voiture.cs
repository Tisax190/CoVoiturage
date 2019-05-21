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
        public int PlaceDisponible { get; set; }

        public void ChangePlaque(string newPlaque, Voiture voiture)
        {
            DALVoiture dalVoiture= new DALVoiture();
            dalVoiture.ChangePlaque(newPlaque, voiture);
        }
    }
}