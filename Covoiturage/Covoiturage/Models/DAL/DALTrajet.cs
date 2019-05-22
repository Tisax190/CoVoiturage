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

        public Trajet GetTrajet(int Id)
        {
            return bdd.ListeTrajet.Where(t => t.Id == Id).FirstOrDefault();
        }

        public List<Trajet> GetTrajets()
        {
            return bdd.ListeTrajet.Select(t => t).ToList();
        }

        public List<Trajet> GetTrajets(Conducteur conducteur)
        {
            Conducteur temp = bdd.ListeConducteur.Where(c => c.Id == conducteur.Id).FirstOrDefault();
            Trajet trajet = bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).FirstOrDefault();
            if (trajet == null) return null;
            return bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).ToList();
        }

        public List<Trajet> GetTrajets(Utilisateur user)
        {
            //pas testé
            if (bdd.ListeTrajet.Where(t => t.Passagers.Contains(user)).FirstOrDefault() == null) return null;
            return bdd.ListeTrajet.Where(t => t.Passagers.Contains(user)).ToList();
        }

        public void EditValue(Trajet trajet, Trajet session)
        {
            var modif = bdd.ListeTrajet.Where(t => t.Id == session.Id).FirstOrDefault();
            var conducteur = bdd.ListeConducteur.Where(c => c.Id == trajet.Conducteur.Id).FirstOrDefault();
            modif.Conducteur = conducteur;
            var ville = bdd.ListeVille.Where(v => v.Id == trajet.VilleDepart.Id).FirstOrDefault();
            modif.VilleDepart = ville;
            ville = bdd.ListeVille.Where(v => v.Id == trajet.VilleTerminus.Id).FirstOrDefault();
            modif.VilleTerminus = ville;
            modif.DateVoyage = trajet.DateVoyage;
            modif.Distance = trajet.Distance;
            modif.PlaceRestante = trajet.PlaceRestante;
            bdd.SaveChanges();
        }

        public void RemoveTrajet(Trajet trajet)
        {
            trajet = bdd.ListeTrajet.Where(t => t.Id == trajet.Id).FirstOrDefault();
            bdd.ListeTrajet.Remove(trajet);
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