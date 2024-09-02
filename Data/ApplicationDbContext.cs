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
                entity.HasOne(e => e.ProduitSysteme)
                      .WithMany()
                      .HasForeignKey(e => e.IdProduitSysteme)
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

            modelBuilder.Entity<Problemes>().HasData(
                new Problemes
                {
                    Id = 1,
                    IdProduitSysteme = 1, // Correspond à Trader en Herbe 1.2 sur Linux
                    DateCreation = new DateTime(2024, 4, 8),
                    DateResolution = new DateTime(2024, 4, 15),
                    IdStatut = 1,
                    Probleme = "L'application ne parvient pas à se connecter au serveur de trading en raison d'un certificat SSL non reconnu, le certificat a expiré et n’a pas été mis à jour.",
                    Resolution = "Le certificat a été renouvelé et la date d’échéance reportée pour couvrir la date en cours. Afin d'éviter que ce problème ne se reproduise, prévoir une maintenance périodique pour mettre à jour le certificat SSL."
                },
                new Problemes
                {
                    Id = 2,
                    IdProduitSysteme = 4, // Correspond à Trader en Herbe 1.1 sur Android
                    DateCreation = new DateTime(2024, 4, 20),
                    DateResolution = new DateTime(2024, 4, 25),
                    IdStatut = 1,
                    Probleme = "Les taux de change des devises ne se mettent pas à jour en temps réel.",
                    Resolution = "Révision de l'API de mise à jour des taux de change pour garantir la synchronisation en temps réel et ajout de fonctionnalités de mise en cache pour améliorer la performance."
                },
                new Problemes
                {
                    Id = 3,
                    IdProduitSysteme = 14, // Correspond à Trader en Herbe 1.3 sur iOS
                    DateCreation = new DateTime(2024, 5, 10),
                    DateResolution = new DateTime(2024, 5, 12),
                    IdStatut = 1,
                    Probleme = "Les utilisateurs ne peuvent pas ajouter des actions à leur liste de favoris.",
                    Resolution = "Correction d'un bug dans la logique d'ajout aux favoris et mise à jour de l'interface utilisateur pour une meilleure expérience utilisateur."
                },
                new Problemes
                {
                    Id = 4,
                    IdProduitSysteme = 6, // Correspond à Trader en Herbe 1.2 sur Android
                    DateCreation = new DateTime(2024, 11, 1),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "L'application se bloque lors de la tentative de consultation de l'historique des transactions.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 5,
                    IdProduitSysteme = 17, // Correspond à Maître des Investissements 1.0 sur Windows
                    DateCreation = new DateTime(2024, 5, 1),
                    DateResolution = new DateTime(2024, 5, 6),
                    IdStatut = 1,
                    Probleme = "Les graphiques des performances des investissements ne s'affichent pas correctement, les données sont mal alignées.",
                    Resolution = "Correction d'un bug dans la génération des graphiques et optimisation du rendu pour une meilleure précision des données affichées."
                },
                new Problemes
                {
                    Id = 6,
                    IdProduitSysteme = 19, // Correspond à Maître des Investissements 2.1 sur Linux
                    DateCreation = new DateTime(2024, 7, 15),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Problème de démarrage de l'application sur certaines distributions Linux récentes.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 7,
                    IdProduitSysteme = 30, // Correspond à Planificateur d’Entraînement 1.1 sur Android
                    DateCreation = new DateTime(2024, 6, 10),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Erreur de connexion à la base de données sur certains appareils Android 12.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 8,
                    IdProduitSysteme = 37, // Correspond à Planificateur d’Anxiété Sociale 1.0 sur Windows
                    DateCreation = new DateTime(2024, 7, 5),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Fonctionnalité de recherche ne renvoyant pas de résultats.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 9,
                    IdProduitSysteme = 35, // Correspond à Planificateur d’Entraînement 2.0 sur MacOS
                    DateCreation = new DateTime(2024, 7, 12),
                    DateResolution = new DateTime(2024, 7, 17),
                    IdStatut = 1,
                    Probleme = "Crash de l'application lors de l'ouverture d'un fichier volumineux.",
                    Resolution = "Amélioration de la gestion de la mémoire pour permettre l'ouverture de fichiers volumineux."
                },
                new Problemes
                {
                    Id = 10,
                    IdProduitSysteme = 44, // Correspond à Planificateur d’Anxiété Sociale 1.1 sur iOS
                    DateCreation = new DateTime(2024, 7, 20),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Problème d'affichage des caractères spéciaux dans l'interface utilisateur.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 11,
                    IdProduitSysteme = 29, // Correspond à Planificateur d’Entraînement 1.0 sur Android
                    DateCreation = new DateTime(2024, 8, 8),
                    DateResolution = new DateTime(2024, 8, 12),
                    IdStatut = 1,
                    Probleme = "Erreur d'importation de données à partir d'un fichier CSV.",
                    Resolution = "Correction du parser CSV pour gérer correctement les délimiteurs et les caractères spéciaux."
                },
                new Problemes
                {
                    Id = 12,
                    IdProduitSysteme = 41, // Correspond à Planificateur d’Anxiété Sociale 1.1 sur Linux
                    DateCreation = new DateTime(2024, 8, 15),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Notification d'erreur non claire lors de la saisie de données invalides.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 13,
                    IdProduitSysteme = 21, // Correspond à Maître des Investissements 2.1 sur MacOS
                    DateCreation = new DateTime(2024, 8, 20),
                    DateResolution = new DateTime(2024, 8, 25),
                    IdStatut = 1,
                    Probleme = "Problème de synchronisation des données entre l'application mobile et l'application de bureau.",
                    Resolution = "Amélioration de l'algorithme de synchronisation et correction des conflits de données."
                },
                new Problemes
                {
                    Id = 14,
                    IdProduitSysteme = 15, // Correspond à Trader en Herbe 1.3 sur iOS
                    DateCreation = new DateTime(2024, 8, 25),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Bug d'affichage des graphiques sur la version iOS 14.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 15,
                    IdProduitSysteme = 31, // Correspond à Planificateur d’Entraînement 1.1 sur Windows
                    DateCreation = new DateTime(2024, 9, 1),
                    DateResolution = new DateTime(2024, 9, 5),
                    IdStatut = 1,
                    Probleme = "Les rappels de séance d'entraînement ne fonctionnent pas de manière cohérente.",
                    Resolution = "Correction du module de rappels et ajout de tests pour vérifier leur fiabilité."
                },
                new Problemes
                {
                    Id = 16,
                    IdProduitSysteme = 40, // Correspond à Planificateur d’Anxiété Sociale 1.0 sur Android
                    DateCreation = new DateTime(2024, 9, 5),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Problèmes de performances lors du chargement des statistiques d'anxiété.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 17,
                    IdProduitSysteme = 21, // Correspond à Maître des Investissements 1.0 sur Linux
                    DateCreation = new DateTime(2024, 9, 10),
                    DateResolution = new DateTime(2024, 9, 15),
                    IdStatut = 1,
                    Probleme = "Erreur lors de la génération des rapports hebdomadaires.",
                    Resolution = "Correction de la logique de génération de rapports et mise à jour des dépendances."
                },
                new Problemes
                {
                    Id = 18,
                    IdProduitSysteme = 36, // Correspond à Planificateur d’Entraînement 2.0 sur iOS
                    DateCreation = new DateTime(2024, 9, 15),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Synchronisation défectueuse avec l'application Apple Health.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 19,
                    IdProduitSysteme = 44, // Correspond à Planificateur d’Anxiété Sociale 1.1 sur MacOS
                    DateCreation = new DateTime(2024, 9, 20),
                    DateResolution = new DateTime(2024, 9, 25),
                    IdStatut = 1,
                    Probleme = "Les utilisateurs ne reçoivent pas les notifications de suivi des activités.",
                    Resolution = "Mise à jour du module de notifications et ajout de tests pour vérifier leur bon fonctionnement."
                },
                new Problemes
                {
                    Id = 20,
                    IdProduitSysteme = 22, // Correspond à Maître des Investissements 2.1 sur Windows
                    DateCreation = new DateTime(2024, 9, 25),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "La fonction de calcul des rendements annuels ne donne pas les résultats attendus.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 21,
                    IdProduitSysteme = 34, // Correspond à Planificateur d’Entraînement 2.0 sur Windows
                    DateCreation = new DateTime(2024, 10, 30),
                    DateResolution = new DateTime(2024, 11, 5),
                    IdStatut = 1,
                    Probleme = "Les utilisateurs ne peuvent pas ajouter des séances d'entraînement personnalisées.",
                    Resolution = "Correction de la logique de sauvegarde des séances personnalisées et mise à jour de l'interface utilisateur pour améliorer l'expérience."
                },
                new Problemes
                {
                    Id = 22,
                    IdProduitSysteme = 37, // Correspond à Planificateur d’Anxiété Sociale 1.0 sur Windows
                    DateCreation = new DateTime(2024, 10, 5),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Crash de l'application lors de la tentative d'ajout d'une nouvelle activité.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 23,
                    IdProduitSysteme = 23, // Correspond à Maître des Investissements 2.0 sur Android
                    DateCreation = new DateTime(2024, 10, 10),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "L'application ne se met pas à jour automatiquement malgré l'activation de l'option.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 24,
                    IdProduitSysteme = 24, // Correspond à Maître des Investissements 2.1 sur iOS
                    DateCreation = new DateTime(2024, 10, 25),
                    DateResolution = null,
                    IdStatut = 2,
                    Probleme = "Les rapports financiers exportés en PDF sont corrompus et illisibles.",
                    Resolution = null
                },
                new Problemes
                {
                    Id = 25,
                    IdProduitSysteme = 44, // Correspond à Planificateur d’Anxiété Sociale 1.1 sur Windows
                    DateCreation = new DateTime(2024, 10, 20),
                    DateResolution = new DateTime(2024, 10, 25),
                    IdStatut = 1,
                    Probleme = "Les utilisateurs rencontrent des délais importants lors de la mise à jour des activités.",
                    Resolution = "Optimisation du code de mise à jour pour améliorer les performances et réduire les délais."
                },
                new Problemes
                {
                    Id = 26,
                    IdProduitSysteme = 27, // Correspond à Planificateur d’Entraînement 2.0 sur Linux
                    DateCreation = new DateTime(2024, 11, 2),
                    DateResolution = new DateTime(2024, 11, 6),
                    IdStatut = 1,
                    Probleme = "L'application ne sauvegarde pas les séances d'entraînement correctement sur certaines distributions Linux.",
                    Resolution = "Correction de la logique de gestion des fichiers de sauvegarde et ajout de tests de compatibilité pour différentes distributions Linux."
                }
            );
        }
    }
}