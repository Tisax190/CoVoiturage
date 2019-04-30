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
    }
}