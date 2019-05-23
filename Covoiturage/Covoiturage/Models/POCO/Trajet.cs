using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    [Table("Trajet")]
    public class Trajet
    {
        public int Id { get; set; }
        public int PlaceRestante { get; set; }
        public int PrixParPersonne { get; set; }
        public string DateVoyage { get; set; }
        public int Distance { get; set; }
        //Just in case
        //public string PlaqueVoiture { get; set; }
        public virtual List<Passager> Passagers { get; set; }
        public virtual Conducteur Conducteur { get; set; }
        public virtual Ville VilleDepart { get; set; }
        public virtual Ville VilleTerminus { get; set; }
        //Si on a le temps
        //public List<Commentaire> Commentaire { get; set; } 

        public void AddTrajet()
        {
            DALTrajet dal = new DALTrajet();
            dal.AddTrajet(this);
        }

        public void EditValue(Trajet trajet, Trajet session)
        {
            DALTrajet dal = new DALTrajet();
            dal.EditValue(trajet, session);
        }

        public void RemoveTrajet(Trajet trajet)
        {
            DALTrajet dal = new DALTrajet();
            dal.RemoveTrajet(trajet);
        }

        public Trajet GetTrajet(int Id)
        {
            DALTrajet dal = new DALTrajet();
            return dal.GetTrajet(Id);
        }

        public List<Trajet> SearchNewTrajets(int IdPassager)
        {
            DALTrajet dal = new DALTrajet();
            return dal.SearchNewTrajets(IdPassager);
        }

        public List<Trajet> GetReservations(Passager passager)
        {
            DALTrajet dal = new DALTrajet();
            return dal.GetReservations(passager);
        }

        public List<Trajet> GetTrajets(Conducteur c)
        {
            DALTrajet dal = new DALTrajet();
            return dal.GetTrajets(c);
        }

        public void AddPassager(Passager passager)
        {
            DALTrajet dal = new DALTrajet();
            dal.AddPassager(this, passager);
        }

        public void RemovePassager(Passager passager)
        {
            DALTrajet dal = new DALTrajet();
            dal.RemovePassager(this, passager);
        }

        public string DisplayForPassager()
        {
            string place;

            if (this.PlaceRestante > 0)
            {
                place = this.PlaceRestante.ToString();
            }
            else
            {
                place = "Complet";
            }

            return $"Conducteur : {this.Conducteur.Login} Départ: {this.VilleDepart} | Arrivée : {this.VilleTerminus} | Date : {this.DateVoyage} | Place(s) restante(s) : {place} ";
        }
    }
}