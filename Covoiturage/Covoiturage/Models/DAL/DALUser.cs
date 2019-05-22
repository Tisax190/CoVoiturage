using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALUser : DALAbstract
    {
        public string GetSalt(string pseudo,string role)
        {
            if(role=="driver")
            {
                return bdd.ListeConducteur.Where(x => x.Login == pseudo).Select(x => x.Salt).FirstOrDefault();
            }
            else if(role == "admin")
            {
                return bdd.ListeAdmin.Where(x => x.Login == pseudo).Select(x => x.Salt).FirstOrDefault();
            }
            else
            {
                return bdd.ListePassager.Where(x => x.Login == pseudo).Select(x => x.Salt).FirstOrDefault();
            }
        }
    }
}