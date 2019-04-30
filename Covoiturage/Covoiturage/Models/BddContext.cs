using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Covoiturage.Models.POCO;

namespace Covoiturage.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Passager> ListePassager { get; set; }
        public DbSet<Administrateur> ListeAdmin { get; set; }
        public BddContext()
        {
            //Database.SetInitializer(new BddContextInitializer()); ajout en dur dans db
        }
        /*public class BddContextInitializer : DropCreateDatabaseIfModelChanges<BddContext>
        {
            protected override void Seed(BddContext context)
            {
                Medecins med = new Medecins { Nom = "Zaretti", Prenom = "Quentin", Specialisation = "Oui" };
                Villes vil = new Villes { NomVille = "Leernes", CodePostal = 6142 };
                Patients pat = new Patients { Nom = "Gregorczyk", Prenom = "Bryian", Jour = 2, Mois = 2, Annee = 1995, Medecins = med, Villes = vil };

                context.T_Villes.Add(vil);
                context.T_Medecins.Add(med);
                context.T_Patients.Add(pat);

                med = new Medecins { Nom = "Zaretti", Prenom = "Steve", Specialisation = "Non" };
                vil = new Villes { NomVille = "Mons", CodePostal = 7000 };
                pat = new Patients { Nom = "Tebbache", Prenom = "Khalid", Jour = 3, Mois = 7, Annee = 1998, Medecins = med, Villes = vil };

                context.T_Villes.Add(vil);
                context.T_Medecins.Add(med);
                context.T_Patients.Add(pat);
            }
        }*/
    }
}