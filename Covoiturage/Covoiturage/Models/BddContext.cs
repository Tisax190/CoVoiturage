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
        public DbSet<Conducteur> ListeConducteur { get; set; }
        public DbSet<Ville> ListeVille { get; set; }
        public DbSet<Voiture> ListeVoiture { get; set; }
        public BddContext()
        {
            Database.SetInitializer(new BddContextInitializer()); //ajout en dur dans db
        }
        public class BddContextInitializer : DropCreateDatabaseIfModelChanges<BddContext>
        {
            protected override void Seed(BddContext context)
            {
                Utilisateur user = new Utilisateur{ Login="Tisax190",Prenom="Quentin",Nom="Zaretti",Mail="Tisax1900@hotmail.fr",Password="1234" };
            }
        }
    }
}