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
            return bdd.ListeTrajet.Where(t => t.UtilisateurId.Contains(user.Id)).ToList();
        }

        public void RemoveTrajet(Trajet t)
        {
            bdd.ListeTrajet.Remove(t);
            bdd.SaveChanges();
        }

        public void AddUser(Trajet trajet, Utilisateur user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (!modif.UtilisateurId.Contains(user.Id))
            {
                modif.UtilisateurId.Add(user.Id);
                bdd.SaveChanges();
            }
        }

        public void RemoveUser(Trajet trajet, Utilisateur user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (modif.UtilisateurId.Contains(user.Id))
            {
                modif.UtilisateurId.Remove(user.Id);
                //bdd.ListeTrajet.Find(trajet.Id) = modif;
                bdd.SaveChanges();
            }
        }
    }
}