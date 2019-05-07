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

        public byte[] GenSalt()
        {
            RNGCryptoServiceProvider rngSp = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            rngSp.GetBytes(salt); // génération salt
            return salt;
        }
    }
}