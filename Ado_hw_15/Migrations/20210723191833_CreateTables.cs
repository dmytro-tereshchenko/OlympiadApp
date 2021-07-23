using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ado_hw_15.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Olimpiads",
                columns: table => new
                {
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    IsSummer = table.Column<bool>(type: "bit", nullable: false),
                    HostCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olimpiads", x => x.Year);
                    table.ForeignKey(
                        name: "FK_Olimpiads_Countries_HostCountryId",
                        column: x => x.HostCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityOlympiad",
                columns: table => new
                {
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    OlympiadsYear = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityOlympiad", x => new { x.CitiesId, x.OlympiadsYear });
                    table.ForeignKey(
                        name: "FK_CityOlympiad_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityOlympiad_Olimpiads_OlympiadsYear",
                        column: x => x.OlympiadsYear,
                        principalTable: "Olimpiads",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfSportId = table.Column<int>(type: "int", nullable: false),
                    OlympiadId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Olimpiads_OlympiadId",
                        column: x => x.OlympiadId,
                        principalTable: "Olimpiads",
                        principalColumn: "Year",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_TypeOfSports_TypeOfSportId",
                        column: x => x.TypeOfSportId,
                        principalTable: "TypeOfSports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantTypeOfSport",
                columns: table => new
                {
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    TypeOfSportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantTypeOfSport", x => new { x.ParticipantsId, x.TypeOfSportsId });
                    table.ForeignKey(
                        name: "FK_ParticipantTypeOfSport_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantTypeOfSport_TypeOfSports_TypeOfSportsId",
                        column: x => x.TypeOfSportsId,
                        principalTable: "TypeOfSports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineParticipant",
                columns: table => new
                {
                    DisciplinesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineParticipant", x => new { x.DisciplinesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_DisciplineParticipant_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineParticipant_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultParticipants_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityOlympiad_OlympiadsYear",
                table: "CityOlympiad",
                column: "OlympiadsYear");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineParticipant_ParticipantsId",
                table: "DisciplineParticipant",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_OlympiadId",
                table: "Disciplines",
                column: "OlympiadId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TypeOfSportId",
                table: "Disciplines",
                column: "TypeOfSportId");

            migrationBuilder.CreateIndex(
                name: "IX_Olimpiads_HostCountryId",
                table: "Olimpiads",
                column: "HostCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CountryId",
                table: "Participants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantTypeOfSport_TypeOfSportsId",
                table: "ParticipantTypeOfSport",
                column: "TypeOfSportsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultParticipants_DisciplineId",
                table: "ResultParticipants",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultParticipants_ParticipantId",
                table: "ResultParticipants",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityOlympiad");

            migrationBuilder.DropTable(
                name: "DisciplineParticipant");

            migrationBuilder.DropTable(
                name: "ParticipantTypeOfSport");

            migrationBuilder.DropTable(
                name: "ResultParticipants");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Olimpiads");

            migrationBuilder.DropTable(
                name: "TypeOfSports");
        }
    }
}
