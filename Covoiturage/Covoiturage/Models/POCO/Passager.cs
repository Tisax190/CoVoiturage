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
            DALUser dalUser = new DALUser();
            Utilisateur user = new Utilisateur();
            try
            {
                string salt=dalUser.GetSalt(pseudo,"passager");
                user.Password = mdp;
                user.Salt = salt;
                user.Login = pseudo;
                user.Crypt(salt);
                
            }
            catch(Exception ex)
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