using Covoiturage.Models.DAL;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    [Table("Conducteur")]
    public class Conducteur : Utilisateur
    {
        public int AnneeExperience { get; set; }

        public string RegisterUser()
        {
            DALConducteur dal = new DALConducteur();
            return dal.RegisterDriver(this);
        }
        public Conducteur LoginConducteur(string pseudo, string mdp)
        {
            using (var dalUser = new DALUser())
            {
                try
                {
                    string salt = dalUser.GetSalt(pseudo, "driver");
                    Password = mdp;
                    Salt = salt;
                    Login = pseudo;
                    Crypt(salt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            using (var dal = new DALConducteur())
            {
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
        public string EditValue(Conducteur driver,Conducteur session)
        {
            DALConducteur dal = new DALConducteur();
            return dal.EditValue(driver,session);
        }
    }
}