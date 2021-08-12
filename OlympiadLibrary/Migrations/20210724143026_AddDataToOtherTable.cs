using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympiadLibrary.Migrations
{
    public partial class AddDataToOtherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DisciplineParticipant",
                columns: new[] { "DisciplineId", "ParticipantId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 8, 8 },
                    { 3, 9 },
                    { 9, 9 },
                    { 1, 10 },
                    { 4, 10 },
                    { 7, 10 },
                    { 2, 10 },
                    { 5, 10 },
                    { 8, 10 },
                    { 10, 11 },
                    { 12, 11 },
                    { 11, 12 },
                    { 13, 12 },
                    { 10, 13 },
                    { 12, 13 },
                    { 11, 14 },
                    { 13, 14 },
                    { 10, 16 },
                    { 12, 16 },
                    { 11, 16 },
                    { 13, 16 },
                    { 5, 8 },
                    { 2, 8 },
                    { 6, 9 },
                    { 4, 7 },
                    { 4, 1 },
                    { 7, 1 },
                    { 2, 2 },
                    { 5, 2 },
                    { 8, 2 },
                    { 3, 2 },
                    { 6, 2 },
                    { 7, 7 },
                    { 3, 3 },
                    { 6, 3 },
                    { 9, 3 },
                    { 9, 2 },
                    { 4, 4 },
                    { 1, 4 },
                    { 9, 6 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineParticipant",
                columns: new[] { "DisciplineId", "ParticipantId" },
                values: new object[,]
                {
                    { 3, 6 },
                    { 1, 7 },
                    { 5, 5 },
                    { 2, 5 },
                    { 7, 4 },
                    { 8, 5 }
                });

            migrationBuilder.InsertData(
                table: "ParticipantTypeOfSport",
                columns: new[] { "ParticipantId", "TypeOfSportId" },
                values: new object[,]
                {
                    { 10, 2 },
                    { 16, 5 },
                    { 16, 4 },
                    { 15, 4 },
                    { 14, 5 },
                    { 13, 4 },
                    { 12, 5 },
                    { 11, 4 },
                    { 9, 3 },
                    { 10, 1 },
                    { 7, 1 },
                    { 6, 3 },
                    { 5, 2 },
                    { 4, 1 },
                    { 3, 3 },
                    { 2, 3 },
                    { 2, 2 },
                    { 1, 1 },
                    { 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "ResultParticipants",
                columns: new[] { "Id", "DisciplineId", "ParticipantId", "Position" },
                values: new object[,]
                {
                    { 49, 13, 14, (short)2 },
                    { 35, 9, 6, (short)3 },
                    { 34, 9, 3, (short)2 },
                    { 33, 9, 2, (short)1 },
                    { 32, 8, 10, (short)4 },
                    { 28, 7, 10, (short)1 },
                    { 30, 8, 5, (short)1 },
                    { 29, 8, 2, (short)3 },
                    { 36, 9, 9, (short)4 },
                    { 31, 8, 8, (short)2 },
                    { 37, 10, 11, (short)1 },
                    { 41, 11, 12, (short)2 },
                    { 39, 10, 15, (short)3 },
                    { 40, 10, 16, (short)4 },
                    { 27, 7, 7, (short)3 },
                    { 42, 11, 14, (short)1 },
                    { 43, 11, 16, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "ResultParticipants",
                columns: new[] { "Id", "DisciplineId", "ParticipantId", "Position" },
                values: new object[,]
                {
                    { 44, 12, 11, (short)2 },
                    { 45, 12, 13, (short)4 },
                    { 46, 12, 15, (short)4 },
                    { 47, 12, 16, (short)3 },
                    { 48, 13, 12, (short)1 },
                    { 38, 10, 13, (short)2 },
                    { 26, 7, 4, (short)4 },
                    { 21, 6, 2, (short)2 },
                    { 24, 6, 9, (short)4 },
                    { 1, 1, 1, (short)1 },
                    { 2, 1, 4, (short)2 },
                    { 3, 1, 7, (short)4 },
                    { 4, 1, 10, (short)3 },
                    { 5, 2, 2, (short)2 },
                    { 6, 2, 5, (short)1 },
                    { 7, 2, 8, (short)4 },
                    { 8, 2, 10, (short)3 },
                    { 9, 3, 2, (short)3 },
                    { 10, 3, 3, (short)1 },
                    { 25, 7, 1, (short)2 },
                    { 11, 3, 6, (short)2 },
                    { 13, 4, 1, (short)1 },
                    { 14, 4, 4, (short)3 },
                    { 15, 4, 7, (short)4 },
                    { 16, 4, 10, (short)2 },
                    { 17, 5, 2, (short)1 },
                    { 18, 5, 5, (short)2 },
                    { 19, 5, 8, (short)4 },
                    { 20, 5, 10, (short)3 },
                    { 22, 6, 3, (short)1 },
                    { 23, 6, 6, (short)3 },
                    { 12, 3, 9, (short)4 },
                    { 50, 13, 16, (short)3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 10, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 11, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 11, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 12, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 12, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplineParticipant",
                keyColumns: new[] { "DisciplineId", "ParticipantId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "ParticipantTypeOfSport",
                keyColumns: new[] { "ParticipantId", "TypeOfSportId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ResultParticipants",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
