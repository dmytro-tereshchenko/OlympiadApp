using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympiadLibrary.Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Index_FirstName",
                table: "Participants",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "Index_LastName",
                table: "Participants",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_FirstName",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "Index_LastName",
                table: "Participants");
        }
    }
}
