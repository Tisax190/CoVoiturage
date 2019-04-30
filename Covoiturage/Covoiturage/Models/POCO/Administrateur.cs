using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covoiturage.Models.POCO
{
    public class Administrateur:Utilisateur
    {
        public string PseudoAdmin { get; set; }
    }
}