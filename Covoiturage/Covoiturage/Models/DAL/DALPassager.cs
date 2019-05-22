using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALPassager
    {
        private BddContext bdd;
        public DALPassager()
        {
            bdd = new BddContext();
        }
        public string RegisterPassager(Passager passager)
        {
            if((bdd.ListePassager.Where(x=>x.Login==passager.Login).FirstOrDefault())!=null)
            {
                return "Pseudo déja utilisé";
            }
            bdd.ListePassager.Add(passager);
            bdd.SaveChanges();
            return "ok";
        }
        public Passager Login(string pseudo,string mdp)
        {
            Passager loggedUser=bdd.ListePassager.Where(x => x.Password == mdp && x.Login == pseudo).FirstOrDefault();
            return loggedUser;
        }
        public string EditValue(Passager driver, Passager session)
        {
            var tmp = bdd.ListePassager.Where(x => x.Id == session.Id).FirstOrDefault();
            tmp.Nom = driver.Nom;
            tmp.Prenom = driver.Prenom;
            tmp.Mail = driver.Mail;
            session = tmp;
            bdd.SaveChanges();
            return "ok";
        }
    }
}