using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    [Table("Trajet")]
    public class Trajet
    {
        public int Id { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixParPersonne { get; set; }
        public DateTime DateVoyage { get; set; }
        public int Distance { get; set; }
        //Just in case
        //public string PlaqueVoiture { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
        public Conducteur Conducteur { get; set; }
        public Ville VilleDepart { get; set; }
        public Ville VilleTerminus { get; set; }
        //Si on a le temps
        //public List<Commentaire> Commentaire { get; set; }
    }
}