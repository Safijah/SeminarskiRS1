using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class KreditnaKartica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KreditnaKarticaID",
                table: "Racuni",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KreditnaKartica",
                columns: table => new
                {
                    KreditnaKarticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKreditneKartice = table.Column<int>(nullable: false),
                    MjesecIstekaKartice = table.Column<int>(nullable: false),
                    GodinaIstekaKartice = table.Column<int>(nullable: false),
                    CVC = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: true),
                    KorisnikId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.KreditnaKarticaID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racuni_KreditnaKarticaID",
                table: "Racuni",
                column: "KreditnaKarticaID");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KorisnikId",
                table: "KreditnaKartica",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racuni_KreditnaKartica_KreditnaKarticaID",
                table: "Racuni",
                column: "KreditnaKarticaID",
                principalTable: "KreditnaKartica",
                principalColumn: "KreditnaKarticaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racuni_KreditnaKartica_KreditnaKarticaID",
                table: "Racuni");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropIndex(
                name: "IX_Racuni_KreditnaKarticaID",
                table: "Racuni");

            migrationBuilder.DropColumn(
                name: "KreditnaKarticaID",
                table: "Racuni");
        }
    }
}
