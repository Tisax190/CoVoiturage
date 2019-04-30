using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    [Table("Passager")]
    public class Passager:Utilisateur
    {
        public void RegisterUser()
        {
            DALPassager dal = new DALPassager();
            dal.RegisterPassager(this);
        }
    }
}