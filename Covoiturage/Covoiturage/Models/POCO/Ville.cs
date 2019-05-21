using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Covoiturage.Models.DAL;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    public class Ville
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public string CP { get; set; }

        private DALVille dal = new DALVille();

        public void RegisterVille()
        {
            dal.RegisterVille(this);
        }
    }
}