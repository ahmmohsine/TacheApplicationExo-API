using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TacheApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Taches",
                columns: new[] { "Id", "DateCreation", "Realisee", "Titre" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), true, "Mettre en place la Clean Architecture" },
                    { 2, new DateTime(2026, 9, 29, 14, 30, 0, 0, DateTimeKind.Unspecified), true, "Implémenter la configuration Fluent API pour Tache" }
                });

            migrationBuilder.InsertData(
                table: "Taches",
                columns: new[] { "Id", "DateCreation", "Titre" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 9, 30, 8, 15, 0, 0, DateTimeKind.Unspecified), "Tester l'endpoint PATCH /tache/cloture/{id}" },
                    { 4, new DateTime(2026, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Rédiger la documentation Swagger" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Taches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Taches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Taches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Taches",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
