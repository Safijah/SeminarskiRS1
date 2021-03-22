using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class rola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Cvijece_TipCvijeca_TipCvijecaID",
                table: "Cvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_Dekoracije_TipDekoracija_TipDekoracijeID",
                table: "Dekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidencije_Meniji_MeniID",
                table: "Evidencije");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidencije_Rezervacije_RezervacijaID",
                table: "Evidencije");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotografi_Fotografije_FotografijaID",
                table: "Fotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_KuharMeni_Kuhari_KuharID",
                table: "KuharMeni");

            migrationBuilder.DropForeignKey(
                name: "FK_KuharMeni_Meniji_MeniID",
                table: "KuharMeni");

            migrationBuilder.DropForeignKey(
                name: "FK_Meniji_TipMenija_TipMenijaID",
                table: "Meniji");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzikaBendovi_Bendovi_BendID",
                table: "MuzikaBendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzikaBendovi_Muzika_MuzikaID",
                table: "MuzikaBendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaCvijece_Cvijece_CvijeceID",
                table: "RezervacijaCvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaCvijece_Rezervacije_RezervacijaID",
                table: "RezervacijaCvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaDekoracije_Dekoracije_DekoracijaID",
                table: "RezervacijaDekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaDekoracije_Rezervacije_RezervacijaID",
                table: "RezervacijaDekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaFotografi_Fotografi_FotografID",
                table: "RezervacijaFotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaFotografi_Rezervacije_RezervacijaID",
                table: "RezervacijaFotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKorisnici_AspNetUsers_KorisnikID",
                table: "RezervacijaKorisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKorisnici_Rezervacije_RezervacijaID",
                table: "RezervacijaKorisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSale_Rezervacije_RezervacijaID",
                table: "RezervacijaSale");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSale_Sale_SalaID",
                table: "RezervacijaSale");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaKonobari_Konobari_KonobarID",
                table: "SalaKonobari");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaKonobari_Sale_SalaID",
                table: "SalaKonobari");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Meniji_MeniID",
                table: "Stavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_StavkaUlaz_StavkaUlazID",
                table: "Stavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Stolovi_Sale_SalaID",
                table: "Stolovi");

            migrationBuilder.AddColumn<int>(
                name: "RolaID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rola",
                columns: table => new
                {
                    RolaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rola", x => x.RolaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RolaID",
                table: "AspNetUsers",
                column: "RolaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rola_RolaID",
                table: "AspNetUsers",
                column: "RolaID",
                principalTable: "Rola",
                principalColumn: "RolaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cvijece_TipCvijeca_TipCvijecaID",
                table: "Cvijece",
                column: "TipCvijecaID",
                principalTable: "TipCvijeca",
                principalColumn: "TipCvijecaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dekoracije_TipDekoracija_TipDekoracijeID",
                table: "Dekoracije",
                column: "TipDekoracijeID",
                principalTable: "TipDekoracija",
                principalColumn: "TipDekoracijeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencije_Meniji_MeniID",
                table: "Evidencije",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencije_Rezervacije_RezervacijaID",
                table: "Evidencije",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografi_Fotografije_FotografijaID",
                table: "Fotografi",
                column: "FotografijaID",
                principalTable: "Fotografije",
                principalColumn: "FotografijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KuharMeni_Kuhari_KuharID",
                table: "KuharMeni",
                column: "KuharID",
                principalTable: "Kuhari",
                principalColumn: "KuharID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KuharMeni_Meniji_MeniID",
                table: "KuharMeni",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meniji_TipMenija_TipMenijaID",
                table: "Meniji",
                column: "TipMenijaID",
                principalTable: "TipMenija",
                principalColumn: "TipMenijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuzikaBendovi_Bendovi_BendID",
                table: "MuzikaBendovi",
                column: "BendID",
                principalTable: "Bendovi",
                principalColumn: "BendID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuzikaBendovi_Muzika_MuzikaID",
                table: "MuzikaBendovi",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaCvijece_Cvijece_CvijeceID",
                table: "RezervacijaCvijece",
                column: "CvijeceID",
                principalTable: "Cvijece",
                principalColumn: "CvijeceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaCvijece_Rezervacije_RezervacijaID",
                table: "RezervacijaCvijece",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaDekoracije_Dekoracije_DekoracijaID",
                table: "RezervacijaDekoracije",
                column: "DekoracijaID",
                principalTable: "Dekoracije",
                principalColumn: "DekoracijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaDekoracije_Rezervacije_RezervacijaID",
                table: "RezervacijaDekoracije",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaFotografi_Fotografi_FotografID",
                table: "RezervacijaFotografi",
                column: "FotografID",
                principalTable: "Fotografi",
                principalColumn: "FotografID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaFotografi_Rezervacije_RezervacijaID",
                table: "RezervacijaFotografi",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKorisnici_AspNetUsers_KorisnikID",
                table: "RezervacijaKorisnici",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKorisnici_Rezervacije_RezervacijaID",
                table: "RezervacijaKorisnici",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSale_Rezervacije_RezervacijaID",
                table: "RezervacijaSale",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSale_Sale_SalaID",
                table: "RezervacijaSale",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SalaKonobari_Konobari_KonobarID",
                table: "SalaKonobari",
                column: "KonobarID",
                principalTable: "Konobari",
                principalColumn: "KonobarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalaKonobari_Sale_SalaID",
                table: "SalaKonobari",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Meniji_MeniID",
                table: "Stavke",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_StavkaUlaz_StavkaUlazID",
                table: "Stavke",
                column: "StavkaUlazID",
                principalTable: "StavkaUlaz",
                principalColumn: "StavkaUlazID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stolovi_Sale_SalaID",
                table: "Stolovi",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rola_RolaID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Cvijece_TipCvijeca_TipCvijecaID",
                table: "Cvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_Dekoracije_TipDekoracija_TipDekoracijeID",
                table: "Dekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidencije_Meniji_MeniID",
                table: "Evidencije");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidencije_Rezervacije_RezervacijaID",
                table: "Evidencije");

            migrationBuilder.DropForeignKey(
                name: "FK_Fotografi_Fotografije_FotografijaID",
                table: "Fotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_KuharMeni_Kuhari_KuharID",
                table: "KuharMeni");

            migrationBuilder.DropForeignKey(
                name: "FK_KuharMeni_Meniji_MeniID",
                table: "KuharMeni");

            migrationBuilder.DropForeignKey(
                name: "FK_Meniji_TipMenija_TipMenijaID",
                table: "Meniji");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzikaBendovi_Bendovi_BendID",
                table: "MuzikaBendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzikaBendovi_Muzika_MuzikaID",
                table: "MuzikaBendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaCvijece_Cvijece_CvijeceID",
                table: "RezervacijaCvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaCvijece_Rezervacije_RezervacijaID",
                table: "RezervacijaCvijece");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaDekoracije_Dekoracije_DekoracijaID",
                table: "RezervacijaDekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaDekoracije_Rezervacije_RezervacijaID",
                table: "RezervacijaDekoracije");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaFotografi_Fotografi_FotografID",
                table: "RezervacijaFotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaFotografi_Rezervacije_RezervacijaID",
                table: "RezervacijaFotografi");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKorisnici_AspNetUsers_KorisnikID",
                table: "RezervacijaKorisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaKorisnici_Rezervacije_RezervacijaID",
                table: "RezervacijaKorisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSale_Rezervacije_RezervacijaID",
                table: "RezervacijaSale");

            migrationBuilder.DropForeignKey(
                name: "FK_RezervacijaSale_Sale_SalaID",
                table: "RezervacijaSale");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaKonobari_Konobari_KonobarID",
                table: "SalaKonobari");

            migrationBuilder.DropForeignKey(
                name: "FK_SalaKonobari_Sale_SalaID",
                table: "SalaKonobari");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Meniji_MeniID",
                table: "Stavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_StavkaUlaz_StavkaUlazID",
                table: "Stavke");

            migrationBuilder.DropForeignKey(
                name: "FK_Stolovi_Sale_SalaID",
                table: "Stolovi");

            migrationBuilder.DropTable(
                name: "Rola");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RolaID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RolaID",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cvijece_TipCvijeca_TipCvijecaID",
                table: "Cvijece",
                column: "TipCvijecaID",
                principalTable: "TipCvijeca",
                principalColumn: "TipCvijecaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dekoracije_TipDekoracija_TipDekoracijeID",
                table: "Dekoracije",
                column: "TipDekoracijeID",
                principalTable: "TipDekoracija",
                principalColumn: "TipDekoracijeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencije_Meniji_MeniID",
                table: "Evidencije",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencije_Rezervacije_RezervacijaID",
                table: "Evidencije",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotografi_Fotografije_FotografijaID",
                table: "Fotografi",
                column: "FotografijaID",
                principalTable: "Fotografije",
                principalColumn: "FotografijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_KuharMeni_Kuhari_KuharID",
                table: "KuharMeni",
                column: "KuharID",
                principalTable: "Kuhari",
                principalColumn: "KuharID");

            migrationBuilder.AddForeignKey(
                name: "FK_KuharMeni_Meniji_MeniID",
                table: "KuharMeni",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meniji_TipMenija_TipMenijaID",
                table: "Meniji",
                column: "TipMenijaID",
                principalTable: "TipMenija",
                principalColumn: "TipMenijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzikaBendovi_Bendovi_BendID",
                table: "MuzikaBendovi",
                column: "BendID",
                principalTable: "Bendovi",
                principalColumn: "BendID");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzikaBendovi_Muzika_MuzikaID",
                table: "MuzikaBendovi",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaCvijece_Cvijece_CvijeceID",
                table: "RezervacijaCvijece",
                column: "CvijeceID",
                principalTable: "Cvijece",
                principalColumn: "CvijeceID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaCvijece_Rezervacije_RezervacijaID",
                table: "RezervacijaCvijece",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaDekoracije_Dekoracije_DekoracijaID",
                table: "RezervacijaDekoracije",
                column: "DekoracijaID",
                principalTable: "Dekoracije",
                principalColumn: "DekoracijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaDekoracije_Rezervacije_RezervacijaID",
                table: "RezervacijaDekoracije",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaFotografi_Fotografi_FotografID",
                table: "RezervacijaFotografi",
                column: "FotografID",
                principalTable: "Fotografi",
                principalColumn: "FotografID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaFotografi_Rezervacije_RezervacijaID",
                table: "RezervacijaFotografi",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKorisnici_AspNetUsers_KorisnikID",
                table: "RezervacijaKorisnici",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaKorisnici_Rezervacije_RezervacijaID",
                table: "RezervacijaKorisnici",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSale_Rezervacije_RezervacijaID",
                table: "RezervacijaSale",
                column: "RezervacijaID",
                principalTable: "Rezervacije",
                principalColumn: "RezervacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RezervacijaSale_Sale_SalaID",
                table: "RezervacijaSale",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Muzika_MuzikaID",
                table: "Rezervacije",
                column: "MuzikaID",
                principalTable: "Muzika",
                principalColumn: "MuzikaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                table: "Rezervacije",
                column: "PozivnicaID",
                principalTable: "Pozivnice",
                principalColumn: "PozivnicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Racuni_RacunID",
                table: "Rezervacije",
                column: "RacunID",
                principalTable: "Racuni",
                principalColumn: "RacunID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaKonobari_Konobari_KonobarID",
                table: "SalaKonobari",
                column: "KonobarID",
                principalTable: "Konobari",
                principalColumn: "KonobarID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaKonobari_Sale_SalaID",
                table: "SalaKonobari",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Meniji_MeniID",
                table: "Stavke",
                column: "MeniID",
                principalTable: "Meniji",
                principalColumn: "MeniID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_StavkaUlaz_StavkaUlazID",
                table: "Stavke",
                column: "StavkaUlazID",
                principalTable: "StavkaUlaz",
                principalColumn: "StavkaUlazID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stolovi_Sale_SalaID",
                table: "Stolovi",
                column: "SalaID",
                principalTable: "Sale",
                principalColumn: "SalaID");
        }
    }
}
