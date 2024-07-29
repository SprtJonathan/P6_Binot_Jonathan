using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P6_Binot_Jonathan.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDonneesTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_Produits_IdProduit",
                table: "Problemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_Systemes_IdSysteme",
                table: "Problemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_Versions_IdVersion",
                table: "Problemes");

            migrationBuilder.DropIndex(
                name: "IX_Problemes_IdProduit",
                table: "Problemes");

            migrationBuilder.DropIndex(
                name: "IX_Problemes_IdSysteme",
                table: "Problemes");

            migrationBuilder.DropColumn(
                name: "IdProduit",
                table: "Problemes");

            migrationBuilder.DropColumn(
                name: "IdSysteme",
                table: "Problemes");

            migrationBuilder.RenameColumn(
                name: "Problème",
                table: "Problemes",
                newName: "Probleme");

            migrationBuilder.RenameColumn(
                name: "IdVersion",
                table: "Problemes",
                newName: "IdProduitSysteme");

            migrationBuilder.RenameIndex(
                name: "IX_Problemes_IdVersion",
                table: "Problemes",
                newName: "IX_Problemes_IdProduitSysteme");

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Trader en Herbe" },
                    { 2, "Maître des Investissements" },
                    { 3, "Planificateur d’Entraînement" },
                    { 4, "Planificateur d’Anxiété Sociale" }
                });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Résolu" },
                    { 2, "En cours" }
                });

            migrationBuilder.InsertData(
                table: "Systemes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Linux" },
                    { 2, "MacOS" },
                    { 3, "Windows" },
                    { 4, "Android" },
                    { 5, "iOS" },
                    { 6, "Windows Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "1.0" },
                    { 2, "1.1" },
                    { 3, "1.2" },
                    { 4, "1.3" },
                    { 5, "2.0" },
                    { 6, "2.1" }
                });

            migrationBuilder.InsertData(
                table: "ProduitVersions",
                columns: new[] { "Id", "IdProduit", "IdVersion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 1 },
                    { 6, 2, 5 },
                    { 7, 2, 6 },
                    { 8, 3, 1 },
                    { 9, 3, 2 },
                    { 10, 3, 5 },
                    { 11, 4, 1 },
                    { 12, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProduitSystemes",
                columns: new[] { "Id", "IdProduitVersion", "IdSysteme" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 2, 3 },
                    { 6, 3, 1 },
                    { 7, 3, 2 },
                    { 8, 3, 3 },
                    { 9, 3, 4 },
                    { 10, 3, 5 },
                    { 11, 3, 6 },
                    { 12, 4, 2 },
                    { 13, 4, 3 },
                    { 14, 4, 4 },
                    { 15, 4, 5 },
                    { 16, 5, 2 },
                    { 17, 5, 5 },
                    { 18, 6, 2 },
                    { 19, 6, 4 },
                    { 20, 6, 5 },
                    { 21, 7, 2 },
                    { 22, 7, 3 },
                    { 23, 7, 4 },
                    { 24, 7, 5 },
                    { 25, 8, 1 },
                    { 26, 8, 2 },
                    { 27, 9, 1 },
                    { 28, 9, 2 },
                    { 29, 9, 3 },
                    { 30, 9, 4 },
                    { 31, 9, 5 },
                    { 32, 9, 6 },
                    { 33, 10, 2 },
                    { 34, 10, 3 },
                    { 35, 10, 4 },
                    { 36, 10, 5 },
                    { 37, 11, 2 },
                    { 38, 11, 3 },
                    { 39, 11, 4 },
                    { 40, 11, 5 },
                    { 41, 12, 2 },
                    { 42, 12, 3 },
                    { 43, 12, 4 },
                    { 44, 12, 5 }
                });

            migrationBuilder.InsertData(
                table: "Problemes",
                columns: new[] { "Id", "DateCreation", "DateResolution", "IdProduitSysteme", "IdStatut", "Probleme", "Resolution" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "L'application ne parvient pas à se connecter au serveur de trading en raison d'un certificat SSL non reconnu, le certificat a expiré et n’a pas été mis à jour.", "Le certificat a été renouvelé et la date d’échéance reportée pour couvrir la date en cours." },
                    { 2, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, "Les taux de change des devises ne se mettent pas à jour en temps réel.", "Révision de l'API de mise à jour des taux de change pour garantir la synchronisation en temps réel et ajout de fonctionnalités de mise en cache pour améliorer la performance." },
                    { 3, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1, "Les utilisateurs ne peuvent pas ajouter des actions à leur liste de favoris.", "Correction d'un bug dans la logique d'ajout aux favoris et mise à jour de l'interface utilisateur pour une meilleure expérience utilisateur." },
                    { 4, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, 2, "L'application se bloque lors de la tentative de consultation de l'historique des transactions.", null },
                    { 5, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 1, "Les graphiques des performances des investissements ne s'affichent pas correctement, les données sont mal alignées.", "Correction d'un bug dans la génération des graphiques et optimisation du rendu pour une meilleure précision des données affichées." },
                    { 6, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 19, 2, "Problème de démarrage de l'application sur certaines distributions Linux récentes.", null },
                    { 7, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 30, 2, "Erreur de connexion à la base de données sur certains appareils Android 12.", null },
                    { 8, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, 2, "Fonctionnalité de recherche ne renvoyant pas de résultats.", null },
                    { 9, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 1, "Crash de l'application lors de l'ouverture d'un fichier volumineux.", "Amélioration de la gestion de la mémoire pour permettre l'ouverture de fichiers volumineux." },
                    { 10, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 44, 2, "Problème d'affichage des caractères spéciaux dans l'interface utilisateur.", null },
                    { 11, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 1, "Erreur d'importation de données à partir d'un fichier CSV.", "Correction du parser CSV pour gérer correctement les délimiteurs et les caractères spéciaux." },
                    { 12, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 41, 2, "Notification d'erreur non claire lors de la saisie de données invalides.", null },
                    { 13, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 22, 1, "Problème de synchronisation des données entre l'application mobile et l'application de bureau.", "Amélioration de l'algorithme de synchronisation et correction des conflits de données." },
                    { 14, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 2, "Bug d'affichage des graphiques sur la version iOS 14.", null },
                    { 15, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 1, "Les rappels de séance d'entraînement ne fonctionnent pas de manière cohérente.", "Correction du module de rappels et ajout de tests pour vérifier leur fiabilité." },
                    { 16, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 40, 2, "Problèmes de performances lors du chargement des statistiques d'anxiété.", null },
                    { 17, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 1, "Erreur lors de la génération des rapports hebdomadaires.", "Correction de la logique de génération de rapports et mise à jour des dépendances." },
                    { 18, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 36, 2, "Synchronisation défectueuse avec l'application Apple Health.", null },
                    { 19, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, "Les utilisateurs ne reçoivent pas les notifications de suivi des activités.", "Mise à jour du module de notifications et ajout de tests pour vérifier leur bon fonctionnement." },
                    { 20, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, 2, "La fonction de calcul des rendements annuels ne donne pas les résultats attendus.", null },
                    { 21, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 1, "Les utilisateurs ne peuvent pas ajouter des séances d'entraînement personnalisées.", "Correction de la logique de sauvegarde des séances personnalisées et mise à jour de l'interface utilisateur pour améliorer l'expérience." },
                    { 22, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 37, 2, "Crash de l'application lors de la tentative d'ajout d'une nouvelle activité.", null },
                    { 23, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 23, 2, "L'application ne se met pas à jour automatiquement malgré l'activation de l'option.", null },
                    { 24, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 24, 2, "Les rapports financiers exportés en PDF sont corrompus et illisibles.", null },
                    { 25, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, "Les utilisateurs rencontrent des délais importants lors de la mise à jour des activités.", "Optimisation du code de mise à jour pour améliorer les performances et réduire les délais." },
                    { 26, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 1, "L'application ne sauvegarde pas les séances d'entraînement correctement sur certaines distributions Linux.", "Correction de la logique de gestion des fichiers de sauvegarde et ajout de tests de compatibilité pour différentes distributions Linux." }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_ProduitSystemes_IdProduitSysteme",
                table: "Problemes",
                column: "IdProduitSysteme",
                principalTable: "ProduitSystemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problemes_ProduitSystemes_IdProduitSysteme",
                table: "Problemes");

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProduitSystemes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProduitVersions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "Probleme",
                table: "Problemes",
                newName: "Problème");

            migrationBuilder.RenameColumn(
                name: "IdProduitSysteme",
                table: "Problemes",
                newName: "IdVersion");

            migrationBuilder.RenameIndex(
                name: "IX_Problemes_IdProduitSysteme",
                table: "Problemes",
                newName: "IX_Problemes_IdVersion");

            migrationBuilder.AddColumn<int>(
                name: "IdProduit",
                table: "Problemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSysteme",
                table: "Problemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdProduit",
                table: "Problemes",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdSysteme",
                table: "Problemes",
                column: "IdSysteme");

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_Produits_IdProduit",
                table: "Problemes",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_Systemes_IdSysteme",
                table: "Problemes",
                column: "IdSysteme",
                principalTable: "Systemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Problemes_Versions_IdVersion",
                table: "Problemes",
                column: "IdVersion",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
