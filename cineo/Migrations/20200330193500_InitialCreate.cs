﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cineo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    SmallImage = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Production = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    ImdbScore = table.Column<double>(nullable: false),
                    MetacriticScore = table.Column<double>(nullable: false),
                    RottenTomatoesScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Permission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Movie = table.Column<int>(nullable: true),
                    Subtitles = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Hall = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seances_Movies_Movie",
                        column: x => x.Movie,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Movie = table.Column<int>(nullable: true),
                    Seance = table.Column<int>(nullable: true),
                    CinemaName = table.Column<string>(nullable: false),
                    MovieTitle = table.Column<string>(nullable: false),
                    BarcodeNumber = table.Column<long>(nullable: false),
                    TheaterNumber = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_Movie",
                        column: x => x.Movie,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Seances_Seance",
                        column: x => x.Seance,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_Movie",
                table: "Seances",
                column: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Movie",
                table: "Tickets",
                column: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Seance",
                table: "Tickets",
                column: "Seance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
