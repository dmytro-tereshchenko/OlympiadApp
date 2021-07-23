using Microsoft.EntityFrameworkCore.Migrations;

namespace Ado_hw_15.Migrations
{
    public partial class CreateIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ResultParticipants_ParticipantId",
                table: "ResultParticipants",
                newName: "Index_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultParticipants_DisciplineId",
                table: "ResultParticipants",
                newName: "Index_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_CountryId",
                table: "Participants",
                newName: "Index_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Olimpiads_HostCountryId",
                table: "Olimpiads",
                newName: "Index_HostCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_TypeOfSportId",
                table: "Disciplines",
                newName: "Index_TypeOfSportId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_OlympiadId",
                table: "Disciplines",
                newName: "Index_OlympiadId");

            migrationBuilder.CreateIndex(
                name: "Index_Id5",
                table: "TypeOfSports",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Id4",
                table: "ResultParticipants",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_FirstName",
                table: "Participants",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "Index_Id3",
                table: "Participants",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_LastName",
                table: "Participants",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "Index_Year_Key",
                table: "Olimpiads",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Id2",
                table: "Disciplines",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Id1",
                table: "Countries",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Id",
                table: "Cities",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_Id5",
                table: "TypeOfSports");

            migrationBuilder.DropIndex(
                name: "Index_Id4",
                table: "ResultParticipants");

            migrationBuilder.DropIndex(
                name: "Index_FirstName",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "Index_Id3",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "Index_LastName",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "Index_Year_Key",
                table: "Olimpiads");

            migrationBuilder.DropIndex(
                name: "Index_Id2",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "Index_Id1",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "Index_Id",
                table: "Cities");

            migrationBuilder.RenameIndex(
                name: "Index_ParticipantId",
                table: "ResultParticipants",
                newName: "IX_ResultParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "Index_DisciplineId",
                table: "ResultParticipants",
                newName: "IX_ResultParticipants_DisciplineId");

            migrationBuilder.RenameIndex(
                name: "Index_CountryId",
                table: "Participants",
                newName: "IX_Participants_CountryId");

            migrationBuilder.RenameIndex(
                name: "Index_HostCountryId",
                table: "Olimpiads",
                newName: "IX_Olimpiads_HostCountryId");

            migrationBuilder.RenameIndex(
                name: "Index_TypeOfSportId",
                table: "Disciplines",
                newName: "IX_Disciplines_TypeOfSportId");

            migrationBuilder.RenameIndex(
                name: "Index_OlympiadId",
                table: "Disciplines",
                newName: "IX_Disciplines_OlympiadId");
        }
    }
}
