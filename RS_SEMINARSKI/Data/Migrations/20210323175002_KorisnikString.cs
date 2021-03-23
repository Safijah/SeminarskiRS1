using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class KorisnikString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_AspNetUsers_KorisnikId",
                table: "KreditnaKartica");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.RenameColumn(
                name: "KorisnikId",
                table: "KreditnaKartica",
                newName: "KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_KreditnaKartica_KorisnikId",
                table: "KreditnaKartica",
                newName: "IX_KreditnaKartica_KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_AspNetUsers_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KreditnaKartica_AspNetUsers_KorisnikID",
                table: "KreditnaKartica");

            migrationBuilder.RenameColumn(
                name: "KorisnikID",
                table: "KreditnaKartica",
                newName: "KorisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_KreditnaKartica_KorisnikID",
                table: "KreditnaKartica",
                newName: "IX_KreditnaKartica_KorisnikId");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "KreditnaKartica",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KreditnaKartica_AspNetUsers_KorisnikId",
                table: "KreditnaKartica",
                column: "KorisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
