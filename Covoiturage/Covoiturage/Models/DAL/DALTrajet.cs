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
            t.PrixParPersonne = t.Distance * Constante.PrixParKm;
            bdd.ListeTrajet.Add(t);
            bdd.SaveChanges();
        }

        public Trajet GetTrajet(int Id)
        {
            return bdd.ListeTrajet.Where(t => t.Id == Id).FirstOrDefault();
        }

        public List<Trajet> SearchNewTrajets(int IdPassager)
        {
            return bdd.ListeTrajet.Where(t => !t.Passagers.Contains(bdd.ListePassager.Where(p=>p.Id == IdPassager).FirstOrDefault())).ToList();
        }

        public List<Trajet> GetTrajets(Conducteur conducteur)
        {
            Conducteur temp = bdd.ListeConducteur.Where(c => c.Id == conducteur.Id).FirstOrDefault();
            Trajet trajet = bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).FirstOrDefault();
            if (trajet == null) return null;
            return bdd.ListeTrajet.Where(t => t.Conducteur.Id == temp.Id).ToList();
        }

        public List<Trajet> GetReservations(Passager passager)
        {
            //pas testé
            //if (bdd.ListeTrajet.Where(t => t.Passagers.Contains(passager)).FirstOrDefault() == null) return null;
            return bdd.ListeTrajet.Where(t => t.Passagers.Contains(bdd.ListePassager.Where(p => p.Id == passager.Id).FirstOrDefault())).ToList();
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
            modif.PrixParPersonne = trajet.Distance * Constante.PrixParKm;
            modif.PlaceRestante = trajet.PlaceRestante;
            bdd.SaveChanges();
        }

        public void RemoveTrajet(Trajet trajet)
        {
            trajet = bdd.ListeTrajet.Where(t => t.Id == trajet.Id).FirstOrDefault();
            if ((trajet.Passagers == null || trajet.Passagers.Count == 0))
            {
                bdd.ListeTrajet.Remove(trajet);
                bdd.SaveChanges();
            }
        }

        public void AddPassager(Trajet trajet, Passager user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            Passager pass = bdd.ListePassager.Single(p => p.Id == user.Id);
            if (!modif.Passagers.Contains(pass) && modif.PlaceRestante > 0)
            {
                modif.Passagers.Add(pass);
                modif.PrixParPersonne = modif.PrixParPersonne / (modif.Passagers.Count());
                modif.PlaceRestante--;
                bdd.SaveChanges();
            }
        }

        public void RemovePassager(Trajet trajet, Passager user)
        {
            Trajet modif = bdd.ListeTrajet.Single(t => t.Id == trajet.Id);
            Passager pass = bdd.ListePassager.Single(p => p.Id == user.Id);
            if (modif.Passagers.Contains(pass))
            {
                modif.Passagers.Remove(pass);
                modif.PrixParPersonne = modif.Distance * Constante.PrixParKm;
                if (modif.Passagers.Count > 0) modif.PrixParPersonne /= (1 + modif.Passagers.Count());
                modif.PlaceRestante++;
                bdd.SaveChanges();
            }
        }
    }
}