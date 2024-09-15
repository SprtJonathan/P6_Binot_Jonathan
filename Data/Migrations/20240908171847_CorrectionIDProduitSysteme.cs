using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P6_Binot_Jonathan.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionIDProduitSysteme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdProduitSysteme", "Resolution" },
                values: new object[] { 6, "Le certificat a été renouvelé et la date d’échéance reportée pour couvrir la date en cours. Afin d'éviter que ce problème ne se reproduise, prévoir une maintenance périodique pour mettre à jour le certificat SSL." });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdProduitSysteme",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdProduitSysteme",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdProduitSysteme",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IdProduitSysteme", "Probleme" },
                values: new object[] { 21, "Problème de démarrage de l'application sur la dernière version de MacOS." });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 8,
                column: "IdProduitSysteme",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 9,
                column: "IdProduitSysteme",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateResolution", "IdProduitSysteme" },
                values: new object[] { new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 21 });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 16,
                column: "IdProduitSysteme",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 19,
                column: "IdProduitSysteme",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 20,
                column: "IdProduitSysteme",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 22,
                column: "IdProduitSysteme",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 23,
                column: "IdProduitSysteme",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 25,
                column: "IdProduitSysteme",
                value: 42);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdProduitSysteme", "Resolution" },
                values: new object[] { 1, "Le certificat a été renouvelé et la date d’échéance reportée pour couvrir la date en cours." });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdProduitSysteme",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IdProduitSysteme",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IdProduitSysteme",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IdProduitSysteme", "Probleme" },
                values: new object[] { 19, "Problème de démarrage de l'application sur certaines distributions Linux récentes." });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 8,
                column: "IdProduitSysteme",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 9,
                column: "IdProduitSysteme",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateResolution", "IdProduitSysteme" },
                values: new object[] { null, 22 });

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 16,
                column: "IdProduitSysteme",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 19,
                column: "IdProduitSysteme",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 20,
                column: "IdProduitSysteme",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 22,
                column: "IdProduitSysteme",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 23,
                column: "IdProduitSysteme",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 25,
                column: "IdProduitSysteme",
                value: 44);
        }
    }
}
