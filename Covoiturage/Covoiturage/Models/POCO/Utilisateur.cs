using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Security.Cryptography;

namespace Covoiturage.Models.POCO
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Salt { get; set; }

        public void GenSalt()
        {
            RNGCryptoServiceProvider rngSp = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            rngSp.GetBytes(salt); // génération salt
            this.Salt = Convert.ToBase64String(salt);
        }
        public void Crypt()
        {
            GenSalt();
            string passwordSalt = this.Password + Salt;
            HashAlgorithm algorithm = new SHA1Managed();
            var passwordSaltByte = System.Text.Encoding.ASCII.GetBytes(passwordSalt);
            this.Password=Convert.ToBase64String(algorithm.ComputeHash(passwordSaltByte));
        }
        public void Crypt(string salt)
        {
            string passwordSalt = this.Password + salt;
            HashAlgorithm algorithm = new SHA1Managed();
            var passwordSaltByte = System.Text.Encoding.ASCII.GetBytes(passwordSalt);
            this.Password = Convert.ToBase64String(algorithm.ComputeHash(passwordSaltByte));
        }
    }
}