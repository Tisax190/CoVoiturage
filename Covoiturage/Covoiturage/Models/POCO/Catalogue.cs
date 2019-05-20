using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;

namespace Covoiturage.Models.POCO
{
    public class Catalogue
    {
        public static Catalogue instance = null;
        List<Trajet> trajets;
        public DALTrajet dalTrajet;

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

        public void Regen(Utilisateur user)
        {
            trajets = dalTrajet.GetTrajets(user);
        }

        public void AddTrajet(Trajet t)
        {
            trajets.Add(t);
        }

        public void RemoveTrajet(Trajet t)
        {
            trajets.Remove(t);
        }

    }
}