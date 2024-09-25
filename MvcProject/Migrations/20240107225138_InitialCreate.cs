using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Verwijderd = table.Column<bool>(type: "bit", nullable: true),
                    Initialen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klas",
                columns: table => new
                {
                    KlasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verwijderd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klas", x => x.KlasId);
                });

            migrationBuilder.CreateTable(
                name: "Vak",
                columns: table => new
                {
                    VakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verwijderd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vak", x => x.VakId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Afwezigheid",
                columns: table => new
                {
                    AfwezigheidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afwezigheid", x => x.AfwezigheidId);
                    table.ForeignKey(
                        name: "FK_Afwezigheid_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Gebruiker_UserId",
                        column: x => x.UserId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Gebruiker_UserId",
                        column: x => x.UserId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Gebruiker_UserId",
                        column: x => x.UserId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Navorming",
                columns: table => new
                {
                    NavormingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartUur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindUur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kostprijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsGoedgekeurdDir = table.Column<bool>(type: "bit", nullable: true),
                    IsAfgewezen = table.Column<bool>(type: "bit", nullable: true),
                    OpmerkingAfgewezen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAfgewerkt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navorming", x => x.NavormingId);
                    table.ForeignKey(
                        name: "FK_Navorming_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Studiebezoek",
                columns: table => new
                {
                    StudiebezoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VakId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartUur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindUur = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AantalStudenten = table.Column<int>(type: "int", nullable: true),
                    KostprijsStudiebezoek = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    VervoerBus = table.Column<bool>(type: "bit", nullable: true),
                    VervoerTram = table.Column<bool>(type: "bit", nullable: true),
                    VervoerTrein = table.Column<bool>(type: "bit", nullable: true),
                    VervoerTeVoet = table.Column<bool>(type: "bit", nullable: true),
                    VervoerAuto = table.Column<bool>(type: "bit", nullable: true),
                    VervoerFiets = table.Column<bool>(type: "bit", nullable: true),
                    KostprijsVervoer = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    AfwezigeStudenten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opmerkingen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGoedgekeurdCo = table.Column<bool>(type: "bit", nullable: true),
                    IsGoedgekeurdDir = table.Column<bool>(type: "bit", nullable: true),
                    IsAfgewezen = table.Column<bool>(type: "bit", nullable: true),
                    OpmerkingAfgewezen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAfgewerkt = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studiebezoek", x => x.StudiebezoekId);
                    table.ForeignKey(
                        name: "FK_Studiebezoek_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studiebezoek_Vak_VakId",
                        column: x => x.VakId,
                        principalTable: "Vak",
                        principalColumn: "VakId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerRol",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerRol", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_GebruikerRol_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerRol_AspNetUserRoles_UserId_RoleId",
                        columns: x => new { x.UserId, x.RoleId },
                        principalTable: "AspNetUserRoles",
                        principalColumns: new[] { "UserId", "RoleId" });
                    table.ForeignKey(
                        name: "FK_GebruikerRol_Gebruiker_UserId",
                        column: x => x.UserId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerRol_Rol_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerNavorming",
                columns: table => new
                {
                    GebruikerNavormingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NavormingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerNavorming", x => x.GebruikerNavormingId);
                    table.ForeignKey(
                        name: "FK_GebruikerNavorming_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerNavorming_Navorming_NavormingId",
                        column: x => x.NavormingId,
                        principalTable: "Navorming",
                        principalColumn: "NavormingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Begeleiding",
                columns: table => new
                {
                    BegeleidingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudiebezoekId = table.Column<int>(type: "int", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Begeleiding", x => x.BegeleidingId);
                    table.ForeignKey(
                        name: "FK_Begeleiding_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Begeleiding_Studiebezoek_StudiebezoekId",
                        column: x => x.StudiebezoekId,
                        principalTable: "Studiebezoek",
                        principalColumn: "StudiebezoekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bijlage",
                columns: table => new
                {
                    BijlageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudiebezoekId = table.Column<int>(type: "int", nullable: false),
                    BestandsNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bijlage", x => x.BijlageId);
                    table.ForeignKey(
                        name: "FK_Bijlage_Studiebezoek_StudiebezoekId",
                        column: x => x.StudiebezoekId,
                        principalTable: "Studiebezoek",
                        principalColumn: "StudiebezoekId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotoAlbum",
                columns: table => new
                {
                    FotoAlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudiebezoekId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GebruikerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoAlbum", x => x.FotoAlbumId);
                    table.ForeignKey(
                        name: "FK_FotoAlbum_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FotoAlbum_Studiebezoek_StudiebezoekId",
                        column: x => x.StudiebezoekId,
                        principalTable: "Studiebezoek",
                        principalColumn: "StudiebezoekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlasStudiebezoek",
                columns: table => new
                {
                    KlasStudiebezoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlasId = table.Column<int>(type: "int", nullable: false),
                    StudiebezoekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlasStudiebezoek", x => x.KlasStudiebezoekId);
                    table.ForeignKey(
                        name: "FK_KlasStudiebezoek_Klas_KlasId",
                        column: x => x.KlasId,
                        principalTable: "Klas",
                        principalColumn: "KlasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KlasStudiebezoek_Studiebezoek_StudiebezoekId",
                        column: x => x.StudiebezoekId,
                        principalTable: "Studiebezoek",
                        principalColumn: "StudiebezoekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    FotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoAlbumId = table.Column<int>(type: "int", nullable: false),
                    NaamFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.FotoId);
                    table.ForeignKey(
                        name: "FK_Foto_FotoAlbum_FotoAlbumId",
                        column: x => x.FotoAlbumId,
                        principalTable: "FotoAlbum",
                        principalColumn: "FotoAlbumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afwezigheid_GebruikerId",
                table: "Afwezigheid",
                column: "GebruikerId");

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
                name: "IX_Begeleiding_GebruikerId",
                table: "Begeleiding",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Begeleiding_StudiebezoekId",
                table: "Begeleiding",
                column: "StudiebezoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Bijlage_StudiebezoekId",
                table: "Bijlage",
                column: "StudiebezoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_FotoAlbumId",
                table: "Foto",
                column: "FotoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoAlbum_GebruikerId",
                table: "FotoAlbum",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoAlbum_StudiebezoekId",
                table: "FotoAlbum",
                column: "StudiebezoekId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Gebruiker",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Gebruiker",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerNavorming_GebruikerId",
                table: "GebruikerNavorming",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerNavorming_NavormingId",
                table: "GebruikerNavorming",
                column: "NavormingId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerRol_RoleId",
                table: "GebruikerRol",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_KlasStudiebezoek_KlasId",
                table: "KlasStudiebezoek",
                column: "KlasId");

            migrationBuilder.CreateIndex(
                name: "IX_KlasStudiebezoek_StudiebezoekId",
                table: "KlasStudiebezoek",
                column: "StudiebezoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Navorming_GebruikerId",
                table: "Navorming",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiebezoek_GebruikerId",
                table: "Studiebezoek",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Studiebezoek_VakId",
                table: "Studiebezoek",
                column: "VakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afwezigheid");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Begeleiding");

            migrationBuilder.DropTable(
                name: "Bijlage");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "GebruikerNavorming");

            migrationBuilder.DropTable(
                name: "GebruikerRol");

            migrationBuilder.DropTable(
                name: "KlasStudiebezoek");

            migrationBuilder.DropTable(
                name: "FotoAlbum");

            migrationBuilder.DropTable(
                name: "Navorming");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Klas");

            migrationBuilder.DropTable(
                name: "Studiebezoek");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Gebruiker");

            migrationBuilder.DropTable(
                name: "Vak");
        }
    }
}
