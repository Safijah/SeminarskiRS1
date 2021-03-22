using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije");

            migrationBuilder.AlterColumn<int>(
                name: "RacunID",
                table: "Rezervacije",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PozivnicaID",
                table: "Rezervacije",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MuzikaID",
                table: "Rezervacije",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije",
                column: "PozivnicaID",
                principalTable: "Pozivnice",
                principalColumn: "PozivnicaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije",
                column: "RacunID",
                principalTable: "Racuni",
                principalColumn: "RacunID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije");

            migrationBuilder.AlterColumn<int>(
                name: "RacunID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PozivnicaID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MuzikaID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije",
                column: "PozivnicaID",
                principalTable: "Pozivnice",
                principalColumn: "PozivnicaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije",
                column: "RacunID",
                principalTable: "Racuni",
                principalColumn: "RacunID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
