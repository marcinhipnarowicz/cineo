using Microsoft.EntityFrameworkCore.Migrations;

namespace cineo.Migrations
{
    public partial class MovieCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmallImage",
                table: "Movies",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SmallImage",
                table: "Movies");
        }
    }
}
