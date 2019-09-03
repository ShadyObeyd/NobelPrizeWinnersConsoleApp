using Microsoft.EntityFrameworkCore.Migrations;

namespace NobelPrizeWinners.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NobelPrizeWinners",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    FieldOrLanguage = table.Column<string>(nullable: true),
                    PrizeName = table.Column<string>(nullable: true),
                    Motivation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NobelPrizeWinners", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NobelPrizeWinners");
        }
    }
}
