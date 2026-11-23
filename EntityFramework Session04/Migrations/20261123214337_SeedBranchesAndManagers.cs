using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework_Session04.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchesAndManagers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "ALX-01", "45 Corniche Road, Alexandria", "Alexandria Branch", "0345550202" },
                    { "CAI-01", "12 Tahrir Square, Cairo", "Cairo Main Branch", "0225550101" },
                    { "GIZ-01", "7 Pyramids Street, Giza", "Giza Branch", "0235550303" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "CAI-01", "khaled.mansour@nationalbank.com", "Khaled Mansour", new DateOnly(2015, 3, 1), "01011111111" },
                    { 2, "ALX-01", "salma.hassan@nationalbank.com", "Salma Hassan", new DateOnly(2018, 7, 15), "01022222222" },
                    { 3, "GIZ-01", "omar.fathy@nationalbank.com", "Omar Fathy", new DateOnly(2020, 1, 10), "01033333333" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "ALX-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "CAI-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "GIZ-01");
        }
    }
}
