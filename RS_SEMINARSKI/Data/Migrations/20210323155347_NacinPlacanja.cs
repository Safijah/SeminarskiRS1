using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NacinPlacanja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NacinPlacanjaRacuna",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "NacinPlacanjaID",
                table: "Rezervacije",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    NacinPlacanjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NacinPlacanjaNaziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.NacinPlacanjaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_NacinPlacanjaID",
                table: "Rezervacije",
                column: "NacinPlacanjaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_NacinPlacanja_NacinPlacanjaID",
                table: "Rezervacije",
                column: "NacinPlacanjaID",
                principalTable: "NacinPlacanja",
                principalColumn: "NacinPlacanjaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_NacinPlacanja_NacinPlacanjaID",
                table: "Rezervacije");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_NacinPlacanjaID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "NacinPlacanjaID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<string>(
                name: "NacinPlacanjaRacuna",
                table: "Rezervacije",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
