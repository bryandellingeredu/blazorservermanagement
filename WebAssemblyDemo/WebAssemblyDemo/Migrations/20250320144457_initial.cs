﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAssemblyDemo.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "ServerId", "City", "IsOnline", "Name" },
                values: new object[,]
                {
                    { 1, "Toronto", false, "Server1" },
                    { 2, "Toronto", false, "Server2" },
                    { 3, "Toronto", false, "Server3" },
                    { 4, "Toronto", false, "Server4" },
                    { 5, "Montreal", true, "Server5" },
                    { 6, "Montreal", true, "Server6" },
                    { 7, "Montreal", true, "Server7" },
                    { 8, "Ottawa", true, "Server8" },
                    { 9, "Ottawa", true, "Server9" },
                    { 10, "Calgary", true, "Server10" },
                    { 11, "Calgary", true, "Server11" },
                    { 12, "Halifax", true, "Server12" },
                    { 13, "Halifax", true, "Server13" },
                    { 14, "Halifax", true, "Server14" },
                    { 15, "Halifax", true, "Server15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
