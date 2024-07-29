using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace P6_Binot_Jonathan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Systeme> Systemes { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<ProduitVersion> ProduitVersions { get; set; }
        public DbSet<ProduitSysteme> ProduitSystemes { get; set; }
        public DbSet<Problemes> Problemes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired();
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired();
            });

            modelBuilder.Entity<Systeme>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired();
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired();
            });

            modelBuilder.Entity<ProduitVersion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Produit)
                      .WithMany()
                      .HasForeignKey(e => e.IdProduit)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Version)
                      .WithMany()
                      .HasForeignKey(e => e.IdVersion)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProduitSysteme>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.ProduitVersion)
                      .WithMany()
                      .HasForeignKey(e => e.IdProduitVersion)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Systeme)
                      .WithMany()
                      .HasForeignKey(e => e.IdSysteme)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Problemes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Probleme).IsRequired();
                entity.HasOne(e => e.Produit)
                      .WithMany()
                      .HasForeignKey(e => e.IdProduit)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Version)
                      .WithMany()
                      .HasForeignKey(e => e.IdVersion)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Systeme)
                      .WithMany()
                      .HasForeignKey(e => e.IdSysteme)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Statut)
                      .WithMany()
                      .HasForeignKey(e => e.IdStatut)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed Data

            modelBuilder.Entity<Produit>().HasData(
                new Produit { Id = 1, Nom = "Trader en Herbe" },
                new Produit { Id = 2, Nom = "Maître des Investissements" },
                new Produit { Id = 3, Nom = "Planificateur d’Entraînement" },
                new Produit { Id = 4, Nom = "Planificateur d’Anxiété Sociale" }
            );

            modelBuilder.Entity<Version>().HasData(
                new Version { Id = 1, Nom = "1.0" },
                new Version { Id = 2, Nom = "1.1" },
                new Version { Id = 3, Nom = "1.2" },
                new Version { Id = 4, Nom = "1.3" },
                new Version { Id = 5, Nom = "2.0" },
                new Version { Id = 6, Nom = "2.1" }
            );

            modelBuilder.Entity<Systeme>().HasData(
                new Systeme { Id = 1, Nom = "Linux" },
                new Systeme { Id = 2, Nom = "MacOS" },
                new Systeme { Id = 3, Nom = "Windows" },
                new Systeme { Id = 4, Nom = "Android" },
                new Systeme { Id = 5, Nom = "iOS" },
                new Systeme { Id = 6, Nom = "Windows Mobile" }
            );

            modelBuilder.Entity<Statut>().HasData(
                new Statut { Id = 1, Nom = "Résolu" },
                new Statut { Id = 2, Nom = "En cours" }
            );

            modelBuilder.Entity<ProduitVersion>().HasData(
                new ProduitVersion { Id = 1, IdProduit = 1, IdVersion = 1 },
                new ProduitVersion { Id = 2, IdProduit = 1, IdVersion = 2 },
                new ProduitVersion { Id = 3, IdProduit = 1, IdVersion = 3 },
                new ProduitVersion { Id = 4, IdProduit = 1, IdVersion = 4 },
                new ProduitVersion { Id = 5, IdProduit = 2, IdVersion = 1 },
                new ProduitVersion { Id = 6, IdProduit = 2, IdVersion = 5 },
                new ProduitVersion { Id = 7, IdProduit = 2, IdVersion = 6 },
                new ProduitVersion { Id = 8, IdProduit = 3, IdVersion = 1 },
                new ProduitVersion { Id = 9, IdProduit = 3, IdVersion = 2 },
                new ProduitVersion { Id = 10, IdProduit = 3, IdVersion = 5 },
                new ProduitVersion { Id = 11, IdProduit = 4, IdVersion = 1 },
                new ProduitVersion { Id = 12, IdProduit = 4, IdVersion = 2 }
            );

            modelBuilder.Entity<ProduitSysteme>().HasData(
                // Trader en Herbe
                new ProduitSysteme { Id = 1, IdProduitVersion = 1, IdSysteme = 1 }, // 1.0 Linux
                new ProduitSysteme { Id = 2, IdProduitVersion = 1, IdSysteme = 3 }, // 1.0 Windows

                new ProduitSysteme { Id = 3, IdProduitVersion = 2, IdSysteme = 1 }, // 1.1 Linux
                new ProduitSysteme { Id = 4, IdProduitVersion = 2, IdSysteme = 2 }, // 1.1 MacOS
                new ProduitSysteme { Id = 5, IdProduitVersion = 2, IdSysteme = 3 }, // 1.1 Windows

                new ProduitSysteme { Id = 6, IdProduitVersion = 3, IdSysteme = 1 }, // 1.2 Linux
                new ProduitSysteme { Id = 7, IdProduitVersion = 3, IdSysteme = 2 }, // 1.2 MacOS
                new ProduitSysteme { Id = 8, IdProduitVersion = 3, IdSysteme = 3 }, // 1.2 Windows
                new ProduitSysteme { Id = 9, IdProduitVersion = 3, IdSysteme = 4 }, // 1.2 Android
                new ProduitSysteme { Id = 10, IdProduitVersion = 3, IdSysteme = 5 }, // 1.2 iOS
                new ProduitSysteme { Id = 11, IdProduitVersion = 3, IdSysteme = 6 }, // 1.2 Windows Mobile

                new ProduitSysteme { Id = 12, IdProduitVersion = 4, IdSysteme = 2 }, // 1.3 MacOS 
                new ProduitSysteme { Id = 13, IdProduitVersion = 4, IdSysteme = 3 }, // 1.3 Windows
                new ProduitSysteme { Id = 14, IdProduitVersion = 4, IdSysteme = 4 }, // 1.3 Android
                new ProduitSysteme { Id = 15, IdProduitVersion = 4, IdSysteme = 5 }, // 1.3 iOS

                // Maître des Investissements
                new ProduitSysteme { Id = 16, IdProduitVersion = 5, IdSysteme = 2 }, // 1.0 MacOS
                new ProduitSysteme { Id = 17, IdProduitVersion = 5, IdSysteme = 5 }, // 1.0 iOS

                new ProduitSysteme { Id = 18, IdProduitVersion = 6, IdSysteme = 2 }, // 2.0 MacOS
                new ProduitSysteme { Id = 19, IdProduitVersion = 6, IdSysteme = 4 }, // 2.0 Android
                new ProduitSysteme { Id = 20, IdProduitVersion = 6, IdSysteme = 5 }, // 2.0 iOS

                new ProduitSysteme { Id = 21, IdProduitVersion = 7, IdSysteme = 2 }, // 2.1 MacOS
                new ProduitSysteme { Id = 22, IdProduitVersion = 7, IdSysteme = 3 }, // 2.1 Windows
                new ProduitSysteme { Id = 23, IdProduitVersion = 7, IdSysteme = 4 }, // 2.1 Android
                new ProduitSysteme { Id = 24, IdProduitVersion = 7, IdSysteme = 5 }, // 2.1 iOS

                // Planificateur d’Entraînement
                new ProduitSysteme { Id = 25, IdProduitVersion = 8, IdSysteme = 1 }, // 1.0 Linux
                new ProduitSysteme { Id = 26, IdProduitVersion = 8, IdSysteme = 2 }, // 1.0 MacOS

                new ProduitSysteme { Id = 27, IdProduitVersion = 9, IdSysteme = 1 }, // 1.1 Linux
                new ProduitSysteme { Id = 28, IdProduitVersion = 9, IdSysteme = 2 }, // 1.1 MacOS
                new ProduitSysteme { Id = 29, IdProduitVersion = 9, IdSysteme = 3 }, // 1.1 Windows
                new ProduitSysteme { Id = 30, IdProduitVersion = 9, IdSysteme = 4 }, // 1.1 Android
                new ProduitSysteme { Id = 31, IdProduitVersion = 9, IdSysteme = 5 }, // 1.1 iOS
                new ProduitSysteme { Id = 32, IdProduitVersion = 9, IdSysteme = 6 }, // 1.1 Windows Mobile

                new ProduitSysteme { Id = 33, IdProduitVersion = 10, IdSysteme = 2 }, // 2.0 MacOS
                new ProduitSysteme { Id = 34, IdProduitVersion = 10, IdSysteme = 3 }, // 2.0 Windows
                new ProduitSysteme { Id = 35, IdProduitVersion = 10, IdSysteme = 4 }, // 2.0 Android
                new ProduitSysteme { Id = 36, IdProduitVersion = 10, IdSysteme = 5 }, // 2.0 iOS

                // Planificateur d’Anxiété Sociale
                new ProduitSysteme { Id = 37, IdProduitVersion = 11, IdSysteme = 2 }, // 1.0 MacOS
                new ProduitSysteme { Id = 38, IdProduitVersion = 11, IdSysteme = 3 }, // 1.0 Windows
                new ProduitSysteme { Id = 39, IdProduitVersion = 11, IdSysteme = 4 }, // 1.0 Android
                new ProduitSysteme { Id = 40, IdProduitVersion = 11, IdSysteme = 5 }, // 1.0 iOS

                new ProduitSysteme { Id = 41, IdProduitVersion = 12, IdSysteme = 2 }, // 1.1 MacOS
                new ProduitSysteme { Id = 42, IdProduitVersion = 12, IdSysteme = 3 }, // 1.1 Windows
                new ProduitSysteme { Id = 43, IdProduitVersion = 12, IdSysteme = 4 }, // 1.1 Android
                new ProduitSysteme { Id = 44, IdProduitVersion = 12, IdSysteme = 5 } // 1.1 iOS
            );
        }
    }
}