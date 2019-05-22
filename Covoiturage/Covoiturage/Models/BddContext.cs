using Covoiturage.Models.POCO;
using System.Data.Entity;

namespace Covoiturage.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Passager> ListePassager { get; set; }
        public DbSet<Administrateur> ListeAdmin { get; set; }
        public DbSet<Conducteur> ListeConducteur { get; set; }
        public DbSet<Trajet> ListeTrajet { get; set; }
        public DbSet<Ville> ListeVille { get; set; }
        public DbSet<Voiture> ListeVoiture { get; set; }
        public BddContext()
        {
            Database.SetInitializer(new BddContextInitializer());
        }
        public class BddContextInitializer : DropCreateDatabaseIfModelChanges<BddContext>
        {
            protected override void Seed(BddContext context)
            {
                Ville v1 = new Ville { NomVille = "Charleroi", CP = "6000", Id = 1 };
                context.ListeVille.Add(v1);
                Ville v2 = new Ville { NomVille = "Marcinelle", CP = "6001", Id = 2 };
                context.ListeVille.Add(v2);
                Ville v3 = new Ville { NomVille = "Jumet", CP = "6040", Id = 3 };
                context.ListeVille.Add(v3);
                Ville v4 = new Ville { NomVille = "Gosselies", CP = "6041", Id = 4 };
                context.ListeVille.Add(v4);
                Ville v5 = new Ville { NomVille = "Gilly", CP = "6060", Id = 5 };
                context.ListeVille.Add(v5);
                Ville v6 = new Ville { NomVille = "Mons", CP = "7000", Id = 6 };
                context.ListeVille.Add(v6);
            }
        }
    }
}