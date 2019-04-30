using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    public class Ville
    {
        public int Id { get; set; }
        public string NomVille { get; set; }
        public string CP { get; set; }
    }
}