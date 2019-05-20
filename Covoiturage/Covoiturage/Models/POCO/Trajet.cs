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
        public int Id { get; set; } // AJOUTER ACCESSEUR POUR LE RESTE SINON MARCHE PO
        public int PlaceRestante;
        public int PrixParPersonne;
        public DateTime DateVoyage;
        public List<int> IDUsers;
        public int IDConducteur;
        //Si on a le temps
        //public List<Commentaire> commentaires;
    }
}