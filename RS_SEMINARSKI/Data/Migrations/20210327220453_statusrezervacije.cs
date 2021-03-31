using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class statusrezervacije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusRezervacije",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "StatusRezervacijeID",
                table: "Rezervacije",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusRezervacije",
                columns: table => new
                {
                    StatusRezervacijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRezervacije", x => x.StatusRezervacijeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_StatusRezervacijeID",
                table: "Rezervacije",
                column: "StatusRezervacijeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_StatusRezervacije_StatusRezervacijeID",
                table: "Rezervacije",
                column: "StatusRezervacijeID",
                principalTable: "StatusRezervacije",
                principalColumn: "StatusRezervacijeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_StatusRezervacije_StatusRezervacijeID",
                table: "Rezervacije");

            migrationBuilder.DropTable(
                name: "StatusRezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_StatusRezervacijeID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "StatusRezervacijeID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<string>(
                name: "StatusRezervacije",
                table: "Rezervacije",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
