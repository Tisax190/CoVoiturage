using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
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
        public string DateVoyage { get; set; }
        public int Distance { get; set; }
        //Just in case
        //public string PlaqueVoiture { get; set; }
        public virtual List<Passager> Passagers { get; set; }
        public virtual Conducteur Conducteur { get; set; }
        public virtual Ville VilleDepart { get; set; }
        public int? VilleTerminusId { get; set; }
        public virtual Ville VilleTerminus { get; set; }
        //Si on a le temps
        //public List<Commentaire> Commentaire { get; set; }

        public void AddTrajet()
        {
            DALTrajet dalTrajet = new DALTrajet();
            dalTrajet.AddTrajet(this);
        }

        public void RemoveTrajet()
        {
            DALTrajet dalTrajet = new DALTrajet();
            dalTrajet.RemoveTrajet(this);
        }

        public void AddUser(Passager user, Trajet trajet)
        {
            DALTrajet dalTrajet = new DALTrajet();
            dalTrajet.AddUser(trajet, user);
        }

        public void RemoveUser(Passager user, Trajet trajet)
        {
            DALTrajet dalTrajet = new DALTrajet();
            dalTrajet.RemoveUser(trajet, user);
        }
    }
}