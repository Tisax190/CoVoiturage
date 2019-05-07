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
            DALUser dalUser = new DALUser();
            Utilisateur user = new Utilisateur();

            try
            {
                string salt = dalUser.GetSalt(pseudo, "driver");
                user.Password = mdp;
                user.Salt = salt;
                user.Login = pseudo;
                user.Crypt(salt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                return dal.Login(user.Login, user.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}