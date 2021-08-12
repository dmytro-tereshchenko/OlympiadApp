using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympiadLibrary.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Washington" },
                    { 2, "Rio de Janeiro" },
                    { 3, "London" },
                    { 4, "Berlin" },
                    { 5, "Beijing" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "Brazil" },
                    { 3, "UK" },
                    { 4, "German" },
                    { 5, "China" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSports",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Basketball" },
                    { 2, "Boxing" },
                    { 3, "Volleyball" },
                    { 4, "Bobsled" },
                    { 5, "Biathlon" }
                });

            migrationBuilder.InsertData(
                table: "Olimpiads",
                columns: new[] { "Year", "HostCountryId", "IsSummer" },
                values: new object[,]
                {
                    { (short)2020, 1, true },
                    { (short)2016, 2, true },
                    { (short)2012, 3, true },
                    { (short)2018, 4, false },
                    { (short)2014, 5, false }
                });

            migrationBuilder.InsertData(
                table: "CityOlympiad",
                columns: new[] { "CityId", "OlympiadYear" },
                values: new object[,]
                {
                    { 1, (short)2020 },
                    { 2, (short)2016 },
                    { 3, (short)2012 },
                    { 4, (short)2018 },
                    { 5, (short)2014 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CityOlympiad",
                keyColumns: new[] { "CityId", "OlympiadYear" },
                keyValues: new object[] { 1, (short)2020 });

            migrationBuilder.DeleteData(
                table: "CityOlympiad",
                keyColumns: new[] { "CityId", "OlympiadYear" },
                keyValues: new object[] { 2, (short)2016 });

            migrationBuilder.DeleteData(
                table: "CityOlympiad",
                keyColumns: new[] { "CityId", "OlympiadYear" },
                keyValues: new object[] { 3, (short)2012 });

            migrationBuilder.DeleteData(
                table: "CityOlympiad",
                keyColumns: new[] { "CityId", "OlympiadYear" },
                keyValues: new object[] { 4, (short)2018 });

            migrationBuilder.DeleteData(
                table: "CityOlympiad",
                keyColumns: new[] { "CityId", "OlympiadYear" },
                keyValues: new object[] { 5, (short)2014 });

            migrationBuilder.DeleteData(
                table: "TypeOfSports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeOfSports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeOfSports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeOfSports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeOfSports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Olimpiads",
                keyColumn: "Year",
                keyValue: (short)2012);

            migrationBuilder.DeleteData(
                table: "Olimpiads",
                keyColumn: "Year",
                keyValue: (short)2014);

            migrationBuilder.DeleteData(
                table: "Olimpiads",
                keyColumn: "Year",
                keyValue: (short)2016);

            migrationBuilder.DeleteData(
                table: "Olimpiads",
                keyColumn: "Year",
                keyValue: (short)2018);

            migrationBuilder.DeleteData(
                table: "Olimpiads",
                keyColumn: "Year",
                keyValue: (short)2020);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
