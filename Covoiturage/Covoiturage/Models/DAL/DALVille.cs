using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models.DAL
{
    public class DALVille : DALAbstract
    {
        public void RegisterVille(Ville ville)
        {
            bdd.ListeVille.Add(ville);
            bdd.SaveChanges();
        }

        public Ville GetVille(int Id)
        {
            return bdd.ListeVille.Where(v => v.Id == Id).FirstOrDefault();
        }

        public List<Ville> GetAll()
        {
            return bdd.ListeVille.Select(v => v).ToList();
        }
    }
}