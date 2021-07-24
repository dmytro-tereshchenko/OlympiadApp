using Microsoft.EntityFrameworkCore.Migrations;

namespace Ado_hw_15.Migrations
{
    public partial class ChangeNameOlympiads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiad_Olimpiads_OlympiadYear",
                table: "CityOlympiad");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadYear",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Olimpiads_Countries_HostCountryId",
                table: "Olimpiads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Olimpiads",
                table: "Olimpiads");

            migrationBuilder.RenameTable(
                name: "Olimpiads",
                newName: "Olympiads");

            migrationBuilder.RenameIndex(
                name: "IX_Olimpiads_HostCountryId",
                table: "Olympiads",
                newName: "IX_Olympiads_HostCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Olympiads",
                table: "Olympiads",
                column: "Year");

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiad_Olympiads_OlympiadYear",
                table: "CityOlympiad",
                column: "OlympiadYear",
                principalTable: "Olympiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Olympiads_OlympiadYear",
                table: "Disciplines",
                column: "OlympiadYear",
                principalTable: "Olympiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Olympiads_Countries_HostCountryId",
                table: "Olympiads",
                column: "HostCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityOlympiad_Olympiads_OlympiadYear",
                table: "CityOlympiad");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Olympiads_OlympiadYear",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Olympiads_Countries_HostCountryId",
                table: "Olympiads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Olympiads",
                table: "Olympiads");

            migrationBuilder.RenameTable(
                name: "Olympiads",
                newName: "Olimpiads");

            migrationBuilder.RenameIndex(
                name: "IX_Olympiads_HostCountryId",
                table: "Olimpiads",
                newName: "IX_Olimpiads_HostCountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Olimpiads",
                table: "Olimpiads",
                column: "Year");

            migrationBuilder.AddForeignKey(
                name: "FK_CityOlympiad_Olimpiads_OlympiadYear",
                table: "CityOlympiad",
                column: "OlympiadYear",
                principalTable: "Olimpiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadYear",
                table: "Disciplines",
                column: "OlympiadYear",
                principalTable: "Olimpiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Olimpiads_Countries_HostCountryId",
                table: "Olimpiads",
                column: "HostCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
