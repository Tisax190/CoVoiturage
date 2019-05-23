using Covoiturage.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    [Table("Passager")]
    public class Passager : Utilisateur
    {
        public List<Trajet> Trajets { get; set; }

        public string RegisterUser()
        {
            DALPassager dal = new DALPassager();
            return dal.RegisterPassager(this);
        }
        public Passager LoginPassager(string pseudo, string mdp)
        {
            DALPassager dal = new DALPassager();
            DALUser dalUser = new DALUser();
            try
            {
                string salt = dalUser.GetSalt(pseudo, "passager");
                this.Password = mdp;
                this.Salt = salt;
                this.Login = pseudo;
                this.Crypt(salt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                return dal.Login(this.Login, this.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EditValue(Passager driver, Passager session)
        {
            DALPassager dal = new DALPassager();
            return dal.EditValue(driver, session);
        }

    }
}