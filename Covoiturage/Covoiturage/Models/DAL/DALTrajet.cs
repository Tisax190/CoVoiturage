using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALTrajet : DALAbstract
    {
        public void AddTrajet(Trajet t)
        {
            var conducteur = bdd.ListeConducteur.Where(c => c.Id == t.Conducteur.Id).FirstOrDefault();
            t.Conducteur = conducteur;
            var ville = bdd.ListeVille.Where(v => v.Id == t.VilleDepart.Id).FirstOrDefault();
            t.VilleDepart = ville;
            ville = bdd.ListeVille.Where(v => v.Id == t.VilleTerminus.Id).FirstOrDefault();
            t.VilleTerminus = ville;
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
            if (bdd.ListeTrajet.Where(t => t.Passagers.Contains(user)).FirstOrDefault() == null) return null;
            return bdd.ListeTrajet.Where(t => t.Passagers.Contains(user)).ToList();
        }

        public void RemoveTrajet(Trajet t)
        {
            bdd.ListeTrajet.Remove(t);
            bdd.SaveChanges();
        }

        public void AddUser(Trajet trajet, Passager user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (!modif.Passagers.Contains(user))
            {
                modif.Passagers.Add(user);
                bdd.SaveChanges();
            }
        }

        public void RemoveUser(Trajet trajet, Passager user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            if (modif.Passagers.Contains(user))
            {
                modif.Passagers.Remove(user);
                bdd.SaveChanges();
            }
        }
    }
}