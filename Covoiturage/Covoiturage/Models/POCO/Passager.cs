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
        public Passager LoginPassager(string pseudo,string mdp)
        {
            DALPassager dal = new DALPassager();
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