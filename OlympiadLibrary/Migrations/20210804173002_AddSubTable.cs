using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympiadLibrary.Migrations
{
    public partial class AddSubTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiad_Cities_CityId",
                table: "CityOlympiad");

            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiad_Olympiads_OlympiadYear",
                table: "CityOlympiad");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineParticipant_Disciplines_DisciplineId",
                table: "DisciplineParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineParticipant_Participants_ParticipantId",
                table: "DisciplineParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantTypeOfSport_Participants_ParticipantId",
                table: "ParticipantTypeOfSport");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantTypeOfSport_TypeOfSports_TypeOfSportId",
                table: "ParticipantTypeOfSport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantTypeOfSport",
                table: "ParticipantTypeOfSport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplineParticipant",
                table: "DisciplineParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityOlympiad",
                table: "CityOlympiad");

            migrationBuilder.RenameTable(
                name: "ParticipantTypeOfSport",
                newName: "ParticipantTypeOfSports");

            migrationBuilder.RenameTable(
                name: "DisciplineParticipant",
                newName: "DisciplineParticipants");

            migrationBuilder.RenameTable(
                name: "CityOlympiad",
                newName: "CityOlympiads");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantTypeOfSport_TypeOfSportId",
                table: "ParticipantTypeOfSports",
                newName: "IX_ParticipantTypeOfSports_TypeOfSportId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineParticipant_ParticipantId",
                table: "DisciplineParticipants",
                newName: "IX_DisciplineParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_CityOlympiad_OlympiadYear",
                table: "CityOlympiads",
                newName: "IX_CityOlympiads_OlympiadYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantTypeOfSports",
                table: "ParticipantTypeOfSports",
                columns: new[] { "ParticipantId", "TypeOfSportId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplineParticipants",
                table: "DisciplineParticipants",
                columns: new[] { "DisciplineId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityOlympiads",
                table: "CityOlympiads",
                columns: new[] { "CityId", "OlympiadYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiads_Cities_CityId",
                table: "CityOlympiads",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiads_Olympiads_OlympiadYear",
                table: "CityOlympiads",
                column: "OlympiadYear",
                principalTable: "Olympiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineParticipants_Disciplines_DisciplineId",
                table: "DisciplineParticipants",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineParticipants_Participants_ParticipantId",
                table: "DisciplineParticipants",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantTypeOfSports_Participants_ParticipantId",
                table: "ParticipantTypeOfSports",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantTypeOfSports_TypeOfSports_TypeOfSportId",
                table: "ParticipantTypeOfSports",
                column: "TypeOfSportId",
                principalTable: "TypeOfSports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiads_Cities_CityId",
                table: "CityOlympiads");

            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiads_Olympiads_OlympiadYear",
                table: "CityOlympiads");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineParticipants_Disciplines_DisciplineId",
                table: "DisciplineParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineParticipants_Participants_ParticipantId",
                table: "DisciplineParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantTypeOfSports_Participants_ParticipantId",
                table: "ParticipantTypeOfSports");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantTypeOfSports_TypeOfSports_TypeOfSportId",
                table: "ParticipantTypeOfSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantTypeOfSports",
                table: "ParticipantTypeOfSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplineParticipants",
                table: "DisciplineParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityOlympiads",
                table: "CityOlympiads");

            migrationBuilder.RenameTable(
                name: "ParticipantTypeOfSports",
                newName: "ParticipantTypeOfSport");

            migrationBuilder.RenameTable(
                name: "DisciplineParticipants",
                newName: "DisciplineParticipant");

            migrationBuilder.RenameTable(
                name: "CityOlympiads",
                newName: "CityOlympiad");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipantTypeOfSports_TypeOfSportId",
                table: "ParticipantTypeOfSport",
                newName: "IX_ParticipantTypeOfSport_TypeOfSportId");

            migrationBuilder.RenameIndex(
                name: "IX_DisciplineParticipants_ParticipantId",
                table: "DisciplineParticipant",
                newName: "IX_DisciplineParticipant_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_CityOlympiads_OlympiadYear",
                table: "CityOlympiad",
                newName: "IX_CityOlympiad_OlympiadYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantTypeOfSport",
                table: "ParticipantTypeOfSport",
                columns: new[] { "ParticipantId", "TypeOfSportId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplineParticipant",
                table: "DisciplineParticipant",
                columns: new[] { "DisciplineId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityOlympiad",
                table: "CityOlympiad",
                columns: new[] { "CityId", "OlympiadYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiad_Cities_CityId",
                table: "CityOlympiad",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiad_Olympiads_OlympiadYear",
                table: "CityOlympiad",
                column: "OlympiadYear",
                principalTable: "Olympiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineParticipant_Disciplines_DisciplineId",
                table: "DisciplineParticipant",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineParticipant_Participants_ParticipantId",
                table: "DisciplineParticipant",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantTypeOfSport_Participants_ParticipantId",
                table: "ParticipantTypeOfSport",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantTypeOfSport_TypeOfSports_TypeOfSportId",
                table: "ParticipantTypeOfSport",
                column: "TypeOfSportId",
                principalTable: "TypeOfSports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
