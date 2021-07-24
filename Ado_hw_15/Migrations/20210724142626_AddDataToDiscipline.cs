using Microsoft.EntityFrameworkCore.Migrations;

namespace Ado_hw_15.Migrations
{
    public partial class AddDataToDiscipline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "OlympiadYear", "TypeOfSportId" },
                values: new object[,]
                {
                    { 1, (short)2020, 1 },
                    { 2, (short)2020, 2 },
                    { 3, (short)2020, 3 },
                    { 4, (short)2016, 1 },
                    { 5, (short)2016, 2 },
                    { 6, (short)2016, 3 },
                    { 7, (short)2012, 1 },
                    { 8, (short)2012, 2 },
                    { 9, (short)2012, 3 },
                    { 10, (short)2018, 4 },
                    { 11, (short)2018, 5 },
                    { 12, (short)2014, 4 },
                    { 13, (short)2014, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
