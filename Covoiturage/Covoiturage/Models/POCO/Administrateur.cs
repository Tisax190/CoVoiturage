using Covoiturage.Models.DAL;
using System;
using System.Collections.Generic;

namespace Covoiturage.Models.POCO
{
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
    }
}