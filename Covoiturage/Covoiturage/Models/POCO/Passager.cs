using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;

namespace Covoiturage.Models.POCO
{
    public class Passager:Utilisateur
    {
        public void RegisterUser()
        {
            DALPassager dal = new DALPassager();
            dal.RegisterPassager(this);
        }
    }
}