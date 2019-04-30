using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    public class Voiture
    {
        public string Plaque { get; set; }
        public string Modele { get; set; }
        public int PlaceDisponible { get; set; }

        public void ChangePlaque()
        {

        }
    }
}