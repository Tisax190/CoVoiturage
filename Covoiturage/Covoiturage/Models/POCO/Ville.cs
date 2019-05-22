using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    [Table("Ville")]
    public class Ville
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public string CP { get; set; }

        public override string ToString()
        {
            return $"{CP}  {NomVille}";
        }

        public void RegisterVille()
        {
            DALVille dal = new DALVille();
            dal.RegisterVille(this);
        }

        public Ville GetVille(int Id)
        {
            DALVille dal = new DALVille();
            return dal.GetVille(Id);
        }

        public List<Ville> GetAll()
        {
            DALVille dal = new DALVille();
            return dal.GetAll();
        }
    }
}