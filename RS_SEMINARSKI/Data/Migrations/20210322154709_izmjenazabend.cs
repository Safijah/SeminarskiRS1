using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class izmjenazabend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "MuzikaID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "BendID",
                table: "Rezervacije",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_BendID",
                table: "Rezervacije",
                column: "BendID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Bendovi_BendID",
                table: "Rezervacije",
                column: "BendID",
                principalTable: "Bendovi",
                principalColumn: "BendID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Bendovi_BendID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_BendID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "BendID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "MuzikaID",
                table: "Rezervacije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_MuzikaID",
                table: "Rezervacije",
                column: "MuzikaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
