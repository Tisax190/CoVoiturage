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
        public string UnBan(string pseudo, string type)
        {
            DALAdmin admin = new DALAdmin();
            return admin.UnBanUser(pseudo, type);
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
        /*public void AdminSupprimerCommentaire(int id) Décommenter quand commentaire implémenté
        {
            DALAdmin dal = new DALAdmin();
            dal.AdminSupprimerCommentaire(id);
        }*/
        public void ForceDeleteTrajet(int id)
        {
            DALAdmin admin = new DALAdmin();
            admin.ForceDeleteTrajet(id);
        }
    }
}