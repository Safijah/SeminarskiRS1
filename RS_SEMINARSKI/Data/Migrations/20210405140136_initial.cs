using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bendovi",
                columns: table => new
                {
                    BendID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivBenda = table.Column<string>(nullable: true),
                    SatnicaSviranja = table.Column<float>(nullable: false),
                    OpisBenda = table.Column<string>(nullable: true),
                    PutanjaDoSlikeBenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bendovi", x => x.BendID);
                });

            migrationBuilder.CreateTable(
                name: "Fotografije",
                columns: table => new
                {
                    FotografijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivStilaFotografije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografije", x => x.FotografijaID);
                });

            migrationBuilder.CreateTable(
                name: "Konobari",
                columns: table => new
                {
                    KonobarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKonobara = table.Column<string>(nullable: true),
                    PrezimeKonobara = table.Column<string>(nullable: true),
                    PlataKonobara = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konobari", x => x.KonobarID);
                });

            migrationBuilder.CreateTable(
                name: "Kuhari",
                columns: table => new
                {
                    KuharID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKuhara = table.Column<string>(nullable: true),
                    PrezimeKuhara = table.Column<string>(nullable: true),
                    PlataKuhara = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuhari", x => x.KuharID);
                });

            migrationBuilder.CreateTable(
                name: "Muzika",
                columns: table => new
                {
                    MuzikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivZanra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzika", x => x.MuzikaID);
                });

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

            migrationBuilder.CreateTable(
                name: "Pozivnice",
                columns: table => new
                {
                    PozivnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CijenaPozivnice = table.Column<float>(nullable: false),
                    OpisPozivnice = table.Column<string>(nullable: true),
                    PutanjaDoSlikePozivnice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozivnice", x => x.PozivnicaID);
                });

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

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SalaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KapacitetSale = table.Column<int>(nullable: false),
                    OpisSale = table.Column<string>(nullable: true),
                    NazivSale = table.Column<string>(nullable: true),
                    CijenaIznajmljivanjaSale = table.Column<float>(nullable: false),
                    PutanjaDoSlikeSale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SalaID);
                });

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

            migrationBuilder.CreateTable(
                name: "StavkaUlaz",
                columns: table => new
                {
                    StavkaUlazID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaUlaz", x => x.StavkaUlazID);
                });

            migrationBuilder.CreateTable(
                name: "TipCvijeca",
                columns: table => new
                {
                    TipCvijecaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaCvijeca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipCvijeca", x => x.TipCvijecaID);
                });

            migrationBuilder.CreateTable(
                name: "TipDekoracija",
                columns: table => new
                {
                    TipDekoracijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaDekoracije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDekoracija", x => x.TipDekoracijeID);
                });

            migrationBuilder.CreateTable(
                name: "TipMenija",
                columns: table => new
                {
                    TipMenijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipaMenija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipMenija", x => x.TipMenijaID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Fotografi",
                columns: table => new
                {
                    FotografID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografijaID = table.Column<int>(nullable: false),
                    ImeFotografa = table.Column<string>(nullable: true),
                    PrezimeFotografa = table.Column<string>(nullable: true),
                    SatnicaSlikanja = table.Column<float>(nullable: false),
                    PutanjaDoSlikeFotografa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografi", x => x.FotografID);
                    table.ForeignKey(
                        name: "FK_Fotografi_Fotografije_FotografijaID",
                        column: x => x.FotografijaID,
                        principalTable: "Fotografije",
                        principalColumn: "FotografijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MuzikaBendovi",
                columns: table => new
                {
                    MuzikaBendID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuzikaID = table.Column<int>(nullable: false),
                    BendID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzikaBendovi", x => x.MuzikaBendID);
                    table.ForeignKey(
                        name: "FK_MuzikaBendovi_Bendovi_BendID",
                        column: x => x.BendID,
                        principalTable: "Bendovi",
                        principalColumn: "BendID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MuzikaBendovi_Muzika_MuzikaID",
                        column: x => x.MuzikaID,
                        principalTable: "Muzika",
                        principalColumn: "MuzikaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AdresaStanovanja = table.Column<string>(nullable: true),
                    ImeKorisnika = table.Column<string>(nullable: true),
                    PrezimeKorisnika = table.Column<string>(nullable: true),
                    RolaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Rola_RolaID",
                        column: x => x.RolaID,
                        principalTable: "Rola",
                        principalColumn: "RolaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SalaKonobari",
                columns: table => new
                {
                    SalaKonobarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(nullable: false),
                    KonobarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaKonobari", x => x.SalaKonobarID);
                    table.ForeignKey(
                        name: "FK_SalaKonobari_Konobari_KonobarID",
                        column: x => x.KonobarID,
                        principalTable: "Konobari",
                        principalColumn: "KonobarID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SalaKonobari_Sale_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sale",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Stolovi",
                columns: table => new
                {
                    StoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(nullable: false),
                    KapacitetStola = table.Column<int>(nullable: false),
                    OpisStola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stolovi", x => x.StoID);
                    table.ForeignKey(
                        name: "FK_Stolovi_Sale_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sale",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cvijece",
                columns: table => new
                {
                    CvijeceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipCvijecaID = table.Column<int>(nullable: false),
                    VrstaCvijeca = table.Column<string>(nullable: true),
                    CijenaCvijeca = table.Column<float>(nullable: false),
                    PutanjaDoSlikeCvijeca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvijece", x => x.CvijeceID);
                    table.ForeignKey(
                        name: "FK_Cvijece_TipCvijeca_TipCvijecaID",
                        column: x => x.TipCvijecaID,
                        principalTable: "TipCvijeca",
                        principalColumn: "TipCvijecaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dekoracije",
                columns: table => new
                {
                    DekoracijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipDekoracijeID = table.Column<int>(nullable: false),
                    VrstaDekoracije = table.Column<string>(nullable: true),
                    CijenaDekoracije = table.Column<float>(nullable: false),
                    PutanjaDoSlikeDekoracije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dekoracije", x => x.DekoracijaID);
                    table.ForeignKey(
                        name: "FK_Dekoracije_TipDekoracija_TipDekoracijeID",
                        column: x => x.TipDekoracijeID,
                        principalTable: "TipDekoracija",
                        principalColumn: "TipDekoracijeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Meniji",
                columns: table => new
                {
                    MeniID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipMenijaID = table.Column<int>(nullable: false),
                    PutanjaDoSlikeMenija = table.Column<string>(nullable: true),
                    NazivMenija = table.Column<string>(nullable: true),
                    CijenaMenija = table.Column<float>(nullable: false),
                    IzSkladista = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniji", x => x.MeniID);
                    table.ForeignKey(
                        name: "FK_Meniji_TipMenija_TipMenijaID",
                        column: x => x.TipMenijaID,
                        principalTable: "TipMenija",
                        principalColumn: "TipMenijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KreditnaKartica",
                columns: table => new
                {
                    KreditnaKarticaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojKreditneKartice = table.Column<string>(nullable: true),
                    MjesecIstekaKartice = table.Column<int>(nullable: false),
                    GodinaIstekaKartice = table.Column<int>(nullable: false),
                    CVC = table.Column<string>(nullable: true),
                    KorisnikID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KreditnaKartica", x => x.KreditnaKarticaID);
                    table.ForeignKey(
                        name: "FK_KreditnaKartica_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KuharMeni",
                columns: table => new
                {
                    MeniID = table.Column<int>(nullable: false),
                    KuharID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KuharMeni", x => new { x.MeniID, x.KuharID });
                    table.ForeignKey(
                        name: "FK_KuharMeni_Kuhari_KuharID",
                        column: x => x.KuharID,
                        principalTable: "Kuhari",
                        principalColumn: "KuharID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KuharMeni_Meniji_MeniID",
                        column: x => x.MeniID,
                        principalTable: "Meniji",
                        principalColumn: "MeniID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Stavke",
                columns: table => new
                {
                    StavkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeniID = table.Column<int>(nullable: false),
                    StavkaUlazID = table.Column<int>(nullable: false),
                    KolicinaNarucenog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke", x => x.StavkaID);
                    table.ForeignKey(
                        name: "FK_Stavke_Meniji_MeniID",
                        column: x => x.MeniID,
                        principalTable: "Meniji",
                        principalColumn: "MeniID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Stavke_StavkaUlaz_StavkaUlazID",
                        column: x => x.StavkaUlazID,
                        principalTable: "StavkaUlaz",
                        principalColumn: "StavkaUlazID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Racuni",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IznosRacuna = table.Column<float>(nullable: false),
                    KreditnaKarticaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuni", x => x.RacunID);
                    table.ForeignKey(
                        name: "FK_Racuni_KreditnaKartica_KreditnaKarticaID",
                        column: x => x.KreditnaKarticaID,
                        principalTable: "KreditnaKartica",
                        principalColumn: "KreditnaKarticaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BendID = table.Column<int>(nullable: true),
                    PozivnicaID = table.Column<int>(nullable: true),
                    DatumVjencanja = table.Column<DateTime>(nullable: false),
                    VremenskoTrajanjeVjencanja = table.Column<float>(nullable: false),
                    RacunID = table.Column<int>(nullable: true),
                    NacinPlacanjaID = table.Column<int>(nullable: true),
                    KolicinaPozivnica = table.Column<int>(nullable: false),
                    StatusRezervacijeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Bendovi_BendID",
                        column: x => x.BendID,
                        principalTable: "Bendovi",
                        principalColumn: "BendID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_NacinPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NacinPlacanja",
                        principalColumn: "NacinPlacanjaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Pozivnice_PozivnicaID",
                        column: x => x.PozivnicaID,
                        principalTable: "Pozivnice",
                        principalColumn: "PozivnicaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Racuni_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racuni",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_StatusRezervacije_StatusRezervacijeID",
                        column: x => x.StatusRezervacijeID,
                        principalTable: "StatusRezervacije",
                        principalColumn: "StatusRezervacijeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evidencije",
                columns: table => new
                {
                    EvidencijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervacijaID = table.Column<int>(nullable: false),
                    MeniID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencije", x => x.EvidencijaID);
                    table.ForeignKey(
                        name: "FK_Evidencije_Meniji_MeniID",
                        column: x => x.MeniID,
                        principalTable: "Meniji",
                        principalColumn: "MeniID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Evidencije_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaCvijece",
                columns: table => new
                {
                    CvijeceID = table.Column<int>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false),
                    KolicinaNarucenogCvijeca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaCvijece", x => new { x.CvijeceID, x.RezervacijaID });
                    table.ForeignKey(
                        name: "FK_RezervacijaCvijece_Cvijece_CvijeceID",
                        column: x => x.CvijeceID,
                        principalTable: "Cvijece",
                        principalColumn: "CvijeceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaCvijece_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaDekoracije",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false),
                    DekoracijaID = table.Column<int>(nullable: false),
                    KolicinaNarucenihDekoracija = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaDekoracije", x => new { x.RezervacijaID, x.DekoracijaID });
                    table.ForeignKey(
                        name: "FK_RezervacijaDekoracije_Dekoracije_DekoracijaID",
                        column: x => x.DekoracijaID,
                        principalTable: "Dekoracije",
                        principalColumn: "DekoracijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaDekoracije_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaFotografi",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false),
                    FotografID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaFotografi", x => new { x.RezervacijaID, x.FotografID });
                    table.ForeignKey(
                        name: "FK_RezervacijaFotografi_Fotografi_FotografID",
                        column: x => x.FotografID,
                        principalTable: "Fotografi",
                        principalColumn: "FotografID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaFotografi_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaKorisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<string>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaKorisnici", x => new { x.KorisnikID, x.RezervacijaID });
                    table.ForeignKey(
                        name: "FK_RezervacijaKorisnici_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaKorisnici_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaSale",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaSale", x => new { x.RezervacijaID, x.SalaID });
                    table.ForeignKey(
                        name: "FK_RezervacijaSale_Rezervacije_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RezervacijaSale_Sale_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sale",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RolaID",
                table: "AspNetUsers",
                column: "RolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cvijece_TipCvijecaID",
                table: "Cvijece",
                column: "TipCvijecaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dekoracije_TipDekoracijeID",
                table: "Dekoracije",
                column: "TipDekoracijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencije_MeniID",
                table: "Evidencije",
                column: "MeniID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencije_RezervacijaID",
                table: "Evidencije",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografi_FotografijaID",
                table: "Fotografi",
                column: "FotografijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KreditnaKartica_KorisnikID",
                table: "KreditnaKartica",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KuharMeni_KuharID",
                table: "KuharMeni",
                column: "KuharID");

            migrationBuilder.CreateIndex(
                name: "IX_Meniji_TipMenijaID",
                table: "Meniji",
                column: "TipMenijaID");

            migrationBuilder.CreateIndex(
                name: "IX_MuzikaBendovi_BendID",
                table: "MuzikaBendovi",
                column: "BendID");

            migrationBuilder.CreateIndex(
                name: "IX_MuzikaBendovi_MuzikaID",
                table: "MuzikaBendovi",
                column: "MuzikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racuni_KreditnaKarticaID",
                table: "Racuni",
                column: "KreditnaKarticaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaCvijece_RezervacijaID",
                table: "RezervacijaCvijece",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaDekoracije_DekoracijaID",
                table: "RezervacijaDekoracije",
                column: "DekoracijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaFotografi_FotografID",
                table: "RezervacijaFotografi",
                column: "FotografID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaKorisnici_RezervacijaID",
                table: "RezervacijaKorisnici",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaSale_SalaID",
                table: "RezervacijaSale",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_BendID",
                table: "Rezervacije",
                column: "BendID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_NacinPlacanjaID",
                table: "Rezervacije",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_PozivnicaID",
                table: "Rezervacije",
                column: "PozivnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_RacunID",
                table: "Rezervacije",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_StatusRezervacijeID",
                table: "Rezervacije",
                column: "StatusRezervacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaKonobari_KonobarID",
                table: "SalaKonobari",
                column: "KonobarID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaKonobari_SalaID",
                table: "SalaKonobari",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_MeniID",
                table: "Stavke",
                column: "MeniID");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_StavkaUlazID",
                table: "Stavke",
                column: "StavkaUlazID");

            migrationBuilder.CreateIndex(
                name: "IX_Stolovi_SalaID",
                table: "Stolovi",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Evidencije");

            migrationBuilder.DropTable(
                name: "KuharMeni");

            migrationBuilder.DropTable(
                name: "MuzikaBendovi");

            migrationBuilder.DropTable(
                name: "RezervacijaCvijece");

            migrationBuilder.DropTable(
                name: "RezervacijaDekoracije");

            migrationBuilder.DropTable(
                name: "RezervacijaFotografi");

            migrationBuilder.DropTable(
                name: "RezervacijaKorisnici");

            migrationBuilder.DropTable(
                name: "RezervacijaSale");

            migrationBuilder.DropTable(
                name: "SalaKonobari");

            migrationBuilder.DropTable(
                name: "Stavke");

            migrationBuilder.DropTable(
                name: "Stolovi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Kuhari");

            migrationBuilder.DropTable(
                name: "Muzika");

            migrationBuilder.DropTable(
                name: "Cvijece");

            migrationBuilder.DropTable(
                name: "Dekoracije");

            migrationBuilder.DropTable(
                name: "Fotografi");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Konobari");

            migrationBuilder.DropTable(
                name: "Meniji");

            migrationBuilder.DropTable(
                name: "StavkaUlaz");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "TipCvijeca");

            migrationBuilder.DropTable(
                name: "TipDekoracija");

            migrationBuilder.DropTable(
                name: "Fotografije");

            migrationBuilder.DropTable(
                name: "Bendovi");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Pozivnice");

            migrationBuilder.DropTable(
                name: "Racuni");

            migrationBuilder.DropTable(
                name: "StatusRezervacije");

            migrationBuilder.DropTable(
                name: "TipMenija");

            migrationBuilder.DropTable(
                name: "KreditnaKartica");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Rola");
        }
    }
}
