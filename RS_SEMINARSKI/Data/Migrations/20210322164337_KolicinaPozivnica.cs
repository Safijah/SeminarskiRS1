using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class KolicinaPozivnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KolicinaPozivnica",
                table: "Rezervacije",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KolicinaPozivnica",
                table: "Rezervacije");
        }
    }
}
