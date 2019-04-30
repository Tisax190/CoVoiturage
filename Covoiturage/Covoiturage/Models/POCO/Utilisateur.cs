using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covoiturage.Models.POCO
{
    public class Utilisateur
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}