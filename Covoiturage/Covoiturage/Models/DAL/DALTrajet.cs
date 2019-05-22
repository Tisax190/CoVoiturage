using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALTrajet
    {
        private BddContext bdd;
        public DALTrajet()
        {
            bdd = new BddContext();
        }

        public void AddTrajet(Trajet t)
        {
            bdd.ListeTrajet.Add(t);
            bdd.SaveChanges();
        }

        public List<Trajet> GetTrajets()
        {
            return bdd.ListeTrajet.ToList();
        }

        public List<Trajet> GetTrajets(Utilisateur user)
        {
            //testé et ok
            if (user is Conducteur)
            {
                Conducteur temp = bdd.ListeConducteur.Where(c => c.Id == user.Id).FirstOrDefault();
                Trajet trajet = bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).FirstOrDefault();
                if (trajet == null) return null;
                return bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).ToList();
            }
            //pas testé
            if (bdd.ListeTrajet.Where(t => t.Utilisateurs.Contains(user)).FirstOrDefault() == null) return null;
            return bdd.ListeTrajet.Where(t => t.Utilisateurs.Contains(user)).ToList();
        }

        public void RemoveTrajet(Trajet t)
        {
            bdd.ListeTrajet.Remove(t);
            bdd.SaveChanges();
        }

        public void AddUser(Trajet trajet, Utilisateur user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (!modif.Utilisateurs.Contains(user))
            {
                modif.Utilisateurs.Add(user);
                bdd.SaveChanges();
            }
        }

        public void RemoveUser(Trajet trajet, Utilisateur user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (modif.Utilisateurs.Contains(user))
            {
                modif.Utilisateurs.Remove(user);
                bdd.SaveChanges();
            }
        }
    }
}