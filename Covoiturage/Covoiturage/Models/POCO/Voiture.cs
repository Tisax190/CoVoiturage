﻿namespace Covoiturage.Models.POCO
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Plaque { get; set; }
        public string Modele { get; set; }
        public int PlaceDisponible { get; set; }

        public void ChangePlaque()
        {

        }
    }
}