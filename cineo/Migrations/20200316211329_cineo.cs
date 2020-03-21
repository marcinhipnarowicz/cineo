using Microsoft.EntityFrameworkCore.Migrations;

namespace cineo.Migrations
{
    public partial class cineo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(nullable: false),
                    MovieTitle = table.Column<string>(nullable: false),
                    BarcodeNumber = table.Column<long>(nullable: false),
                    TheaterNumber = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
