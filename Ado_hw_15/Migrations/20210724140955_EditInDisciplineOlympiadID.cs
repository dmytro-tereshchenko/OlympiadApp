using Microsoft.EntityFrameworkCore.Migrations;

namespace Ado_hw_15.Migrations
{
    public partial class EditInDisciplineOlympiadID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadId",
                table: "Disciplines");

            migrationBuilder.RenameColumn(
                name: "OlympiadId",
                table: "Disciplines",
                newName: "OlympiadYear");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_OlympiadId",
                table: "Disciplines",
                newName: "IX_Disciplines_OlympiadYear");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadYear",
                table: "Disciplines",
                column: "OlympiadYear",
                principalTable: "Olimpiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadYear",
                table: "Disciplines");

            migrationBuilder.RenameColumn(
                name: "OlympiadYear",
                table: "Disciplines",
                newName: "OlympiadId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_OlympiadYear",
                table: "Disciplines",
                newName: "IX_Disciplines_OlympiadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Olimpiads_OlympiadId",
                table: "Disciplines",
                column: "OlympiadId",
                principalTable: "Olimpiads",
                principalColumn: "Year",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
