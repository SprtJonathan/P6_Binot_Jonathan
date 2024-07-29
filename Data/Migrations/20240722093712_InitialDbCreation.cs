using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P6_Binot_Jonathan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Problemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdVersion = table.Column<int>(type: "int", nullable: false),
                    IdSysteme = table.Column<int>(type: "int", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateResolution = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdStatut = table.Column<int>(type: "int", nullable: false),
                    Problème = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Problemes_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Problemes_Statuts_IdStatut",
                        column: x => x.IdStatut,
                        principalTable: "Statuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Problemes_Systemes_IdSysteme",
                        column: x => x.IdSysteme,
                        principalTable: "Systemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Problemes_Versions_IdVersion",
                        column: x => x.IdVersion,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduitVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduit = table.Column<int>(type: "int", nullable: false),
                    IdVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduitVersions_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitVersions_Versions_IdVersion",
                        column: x => x.IdVersion,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduitSystemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduitVersion = table.Column<int>(type: "int", nullable: false),
                    IdSysteme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitSystemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProduitSystemes_ProduitVersions_IdProduitVersion",
                        column: x => x.IdProduitVersion,
                        principalTable: "ProduitVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitSystemes_Systemes_IdSysteme",
                        column: x => x.IdSysteme,
                        principalTable: "Systemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdProduit",
                table: "Problemes",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdStatut",
                table: "Problemes",
                column: "IdStatut");

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdSysteme",
                table: "Problemes",
                column: "IdSysteme");

            migrationBuilder.CreateIndex(
                name: "IX_Problemes_IdVersion",
                table: "Problemes",
                column: "IdVersion");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitSystemes_IdProduitVersion",
                table: "ProduitSystemes",
                column: "IdProduitVersion");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitSystemes_IdSysteme",
                table: "ProduitSystemes",
                column: "IdSysteme");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitVersions_IdProduit",
                table: "ProduitVersions",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitVersions_IdVersion",
                table: "ProduitVersions",
                column: "IdVersion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problemes");

            migrationBuilder.DropTable(
                name: "ProduitSystemes");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "ProduitVersions");

            migrationBuilder.DropTable(
                name: "Systemes");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Versions");
        }
    }
}
