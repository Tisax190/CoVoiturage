using Covoiturage.Models.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    [Table("Administrateur")]
    public class Administrateur : Utilisateur
    {
        public string Role { get; set; }

        public Tuple<List<Passager>, List<Conducteur>> FetchAllUser()
        {
            DALAdmin admin = new DALAdmin();
            return admin.FetchAllUser();
        }
        public string Ban(string pseudo, string type)
        {
            DALAdmin admin = new DALAdmin();
            return admin.BanUser(pseudo, type);
        }
        public Administrateur LoginAdmin(string pseudo, string mdp)
        {
            DALAdmin dal = new DALAdmin();
            DALUser dalUser = new DALUser();
            try
            {
                string salt = dalUser.GetSalt(pseudo, "admin");
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
    }
}