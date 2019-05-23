using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;

namespace Covoiturage.Models.POCO
{
    public class Catalogue
    {
        private static Catalogue instance = null;
        public List<Trajet> trajets;

        public static Catalogue GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Catalogue();
                }
                return instance;
            }
        }

        public void Regen(int IdPassager)
        {
            Trajet trajet = new Trajet();
            trajets = trajet.SearchNewTrajets(IdPassager);
        }

    }
}