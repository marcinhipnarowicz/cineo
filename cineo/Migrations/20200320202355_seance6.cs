using Microsoft.EntityFrameworkCore.Migrations;

namespace cineo.Migrations
{
    public partial class seance6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movie_Id",
                table: "Seances");

            migrationBuilder.AddColumn<int>(
                name: "Movie",
                table: "Seances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seances_Movie",
                table: "Seances",
                column: "Movie");

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Movies_Movie",
                table: "Seances",
                column: "Movie",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Movies_Movie",
                table: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Seances_Movie",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "Movie",
                table: "Seances");

            migrationBuilder.AddColumn<int>(
                name: "Movie_Id",
                table: "Seances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
