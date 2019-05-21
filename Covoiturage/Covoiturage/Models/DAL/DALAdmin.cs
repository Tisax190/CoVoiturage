﻿using Covoiturage.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.DAL
{
    public class DALAdmin
    {
        private BddContext bdd;
        public DALAdmin()
        {
            bdd = new BddContext();
        }
        public Tuple<List<Passager>,List<Conducteur>> FetchAllUser()
        {
            Tuple<List<Passager>, List<Conducteur>> tuple = new Tuple<List<Passager>, List<Conducteur>>(bdd.ListePassager.ToList(),bdd.ListeConducteur.ToList());
            return tuple;
        }
        public string BanUser(string pseudo,string type)
        {
            if(type == "driver")
            {
               Conducteur tmp = bdd.ListeConducteur.Where(x => x.Login == pseudo).FirstOrDefault();
                if (tmp == null)
                    return "Driver not found";
                tmp.IsBanned = true;
            }
            else if (type == "user")
            {
               Utilisateur tmp = bdd.ListePassager.Where(x => x.Login == pseudo).FirstOrDefault();
                if (tmp == null)
                    return "Driver not found";
                tmp.IsBanned = true;
            }
            bdd.SaveChanges();
            return "Ban ok";
            
        }
    }
}