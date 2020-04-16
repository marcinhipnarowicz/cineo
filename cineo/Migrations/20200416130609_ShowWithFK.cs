using Microsoft.EntityFrameworkCore.Migrations;

namespace cineo.Migrations
{
    public partial class ShowWithFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_Movie",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Rooms_Room",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_Movie",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_Room",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Movie",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_RoomId",
                table: "Shows",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Rooms_RoomId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_MovieId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_RoomId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Shows");

            migrationBuilder.AddColumn<int>(
                name: "Movie",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Room",
                table: "Shows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_Movie",
                table: "Shows",
                column: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_Room",
                table: "Shows",
                column: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_Movie",
                table: "Shows",
                column: "Movie",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Rooms_Room",
                table: "Shows",
                column: "Room",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
