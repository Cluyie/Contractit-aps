using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElmålingsSystem.DAL.Migrations
{
    public partial class contractIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EjerKunder",
                columns: table => new
                {
                    KundeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CprNr = table.Column<int>(nullable: false),
                    ForNavn = table.Column<string>(nullable: true),
                    EfterNavn = table.Column<string>(nullable: true),
                    VejNavn = table.Column<string>(nullable: true),
                    HusNummer = table.Column<string>(nullable: true),
                    Etage = table.Column<string>(nullable: true),
                    Dør = table.Column<string>(nullable: true),
                    PostNummer = table.Column<int>(nullable: false),
                    ByNavn = table.Column<string>(nullable: true),
                    KommuneNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerKunder", x => x.KundeId);
                });

            migrationBuilder.CreateTable(
                name: "Installationer",
                columns: table => new
                {
                    InstallationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForventetÅrsforbrug = table.Column<double>(nullable: false),
                    AflæsningsFrekvens = table.Column<string>(nullable: true),
                    Aflæsningsform = table.Column<string>(nullable: true),
                    Afbrydelsesart = table.Column<string>(nullable: true),
                    Tilslutningstype = table.Column<string>(nullable: true),
                    EffektgrænseAmpere = table.Column<string>(nullable: true),
                    EffektgrænseKW = table.Column<string>(nullable: true),
                    VejNavn = table.Column<string>(nullable: true),
                    HusNummer = table.Column<string>(nullable: true),
                    Etage = table.Column<string>(nullable: true),
                    Dør = table.Column<string>(nullable: true),
                    PostNummer = table.Column<int>(nullable: false),
                    ByNavn = table.Column<string>(nullable: true),
                    LandeKode = table.Column<string>(nullable: true),
                    EjerKundeFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installationer", x => x.InstallationsId);
                    table.ForeignKey(
                        name: "FK_Installationer_EjerKunder_EjerKundeFK",
                        column: x => x.EjerKundeFK,
                        principalTable: "EjerKunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LejerKunder",
                columns: table => new
                {
                    KundeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CprNr = table.Column<int>(nullable: false),
                    ForNavn = table.Column<string>(nullable: true),
                    EfterNavn = table.Column<string>(nullable: true),
                    VejNavn = table.Column<string>(nullable: true),
                    HusNummer = table.Column<string>(nullable: true),
                    Etage = table.Column<string>(nullable: true),
                    Dør = table.Column<string>(nullable: true),
                    PostNummer = table.Column<int>(nullable: false),
                    ByNavn = table.Column<string>(nullable: true),
                    KommuneNavn = table.Column<string>(nullable: true),
                    InstallionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LejerKunder", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_LejerKunder_Installationer_InstallionFK",
                        column: x => x.InstallionFK,
                        principalTable: "Installationer",
                        principalColumn: "InstallationsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Måler",
                columns: table => new
                {
                    MålerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MåleromregningsFaktor = table.Column<double>(nullable: false),
                    MålerCifre = table.Column<string>(nullable: true),
                    Målertype = table.Column<string>(nullable: true),
                    Målingsenhed = table.Column<string>(nullable: true),
                    MålerBeskrivelse = table.Column<string>(nullable: true),
                    InstallionFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Måler", x => x.MålerId);
                    table.ForeignKey(
                        name: "FK_Måler_Installationer_InstallionFK",
                        column: x => x.InstallionFK,
                        principalTable: "Installationer",
                        principalColumn: "InstallationsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Måleværdier",
                columns: table => new
                {
                    MåleraflæsningId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AflæsningDatoTid = table.Column<DateTime>(nullable: false),
                    Tællerstand = table.Column<double>(nullable: false),
                    ForbrugKWH = table.Column<int>(nullable: false),
                    MålerFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Måleværdier", x => x.MåleraflæsningId);
                    table.ForeignKey(
                        name: "FK_Måleværdier_Måler_MålerFK",
                        column: x => x.MålerFK,
                        principalTable: "Måler",
                        principalColumn: "MålerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installationer_EjerKundeFK",
                table: "Installationer",
                column: "EjerKundeFK");

            migrationBuilder.CreateIndex(
                name: "IX_LejerKunder_InstallionFK",
                table: "LejerKunder",
                column: "InstallionFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Måler_InstallionFK",
                table: "Måler",
                column: "InstallionFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Måleværdier_MålerFK",
                table: "Måleværdier",
                column: "MålerFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LejerKunder");

            migrationBuilder.DropTable(
                name: "Måleværdier");

            migrationBuilder.DropTable(
                name: "Måler");

            migrationBuilder.DropTable(
                name: "Installationer");

            migrationBuilder.DropTable(
                name: "EjerKunder");
        }
    }
}
