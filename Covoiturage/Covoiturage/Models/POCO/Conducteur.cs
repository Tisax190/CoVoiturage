using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    [Table("Conducteur")]
    public class Conducteur : Utilisateur
    {
        public int AnneeExperience { get; set; }

        public void RegisterUser()
        {
            DALConducteur dal = new DALConducteur(); 
            dal.RegisterDriver(this);
        }
        public Conducteur LoginConducteur(string pseudo, string mdp)
        {
            DALConducteur dal = new DALConducteur();
            try
            {
                return dal.Login(pseudo, mdp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}