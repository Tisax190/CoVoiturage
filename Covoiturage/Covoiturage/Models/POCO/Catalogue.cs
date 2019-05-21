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
        public List<Trajet> trajets;

        private DALTrajet dalTrajet = new DALTrajet();

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
            dalTrajet.AddTrajet(t);
        }

        public void RemoveTrajet(Trajet t)
        {
            trajets.Remove(t);
            dalTrajet.AddTrajet(t);
        }

    }
}