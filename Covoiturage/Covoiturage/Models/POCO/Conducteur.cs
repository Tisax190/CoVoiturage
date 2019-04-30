using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;

namespace Covoiturage.Models.POCO
{
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