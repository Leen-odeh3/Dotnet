using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65074e92-b2bd-4fb7-b47e-712d0d3c0c79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52128ab-e746-490a-a916-2e4cdee0a5c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c834c945-1c48-4155-8edc-99d1af6d4c5d");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5a245ea-0d0a-401b-aee9-0876a56dd3f7", "1", "Admin", "Admin" },
                    { "bf84f34b-e8f3-449f-ad03-2e3261caa833", "3", "HR", "HR" },
                    { "ca81321e-ef89-4573-ac62-6ca4d27c475a", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5a245ea-0d0a-401b-aee9-0876a56dd3f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf84f34b-e8f3-449f-ad03-2e3261caa833");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca81321e-ef89-4573-ac62-6ca4d27c475a");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65074e92-b2bd-4fb7-b47e-712d0d3c0c79", "1", "Admin", "Admin" },
                    { "b52128ab-e746-490a-a916-2e4cdee0a5c2", "3", "HR", "HR" },
                    { "c834c945-1c48-4155-8edc-99d1af6d4c5d", "2", "User", "User" }
                });
        }
    }
}
