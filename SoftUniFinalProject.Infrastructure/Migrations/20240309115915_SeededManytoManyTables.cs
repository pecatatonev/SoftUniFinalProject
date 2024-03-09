using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class SeededManytoManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1795d1f6-3cc1-4bfb-a390-73015e586dc8", "AQAAAAEAACcQAAAAEMad9kjIQg0emt5G9ZGSzTIuC8Xp34/QMRTSsCyj4uenpacUg5+1376hHVqPr1TZdw==", "bd696a20-2003-4215-8790-91767193c45d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24a4d207-a266-485f-ae69-c9067770773e", "AQAAAAEAACcQAAAAEIKOw8RDl5QBBSlHSiycTugjFsIOvpPXEcXcLj7O4Y7VUSR56rH/TmXRzlKbf6FTlg==", "44c281bc-60fe-47ff-aa32-8a43472ce66b" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 9, 16, 59, 15, 128, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.InsertData(
                table: "EventsParticipants",
                columns: new[] { "EventId", "UserId" },
                values: new object[] { 1, "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e" });

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOn",
                value: new DateTime(2004, 3, 9, 13, 59, 15, 121, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartOn",
                value: new DateTime(2001, 3, 9, 13, 59, 15, 121, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.InsertData(
                table: "TeamsSponsors",
                columns: new[] { "SponsorId", "TeamId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventsParticipants",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e" });

            migrationBuilder.DeleteData(
                table: "TeamsSponsors",
                keyColumns: new[] { "SponsorId", "TeamId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TeamsSponsors",
                keyColumns: new[] { "SponsorId", "TeamId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba2aa06d-153a-45e8-9a2b-8ee962dff092", "AQAAAAEAACcQAAAAEKC6T2Su8CWt2N4+KHgm/MlW9qhuoO+T1BW6Oj7RW+Xw8o1KYnefIIP21K4fnz7/EA==", "cf821a13-c3c7-426e-926e-93354de44d74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ef879a0-1250-4873-9724-0f6de3b1bc7a", "AQAAAAEAACcQAAAAEOLHeM8fs6Uc9xLkWHeGyJZlvQ30Acxc1vJLQlQ9q9W+9n8WzyY1NfgghMjK8bTByg==", "1b2d3a4a-b74a-4fd7-ba70-8ad9fab80dbc" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 9, 16, 25, 44, 806, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOn",
                value: new DateTime(2004, 3, 9, 13, 25, 44, 799, DateTimeKind.Local).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartOn",
                value: new DateTime(2001, 3, 9, 13, 25, 44, 799, DateTimeKind.Local).AddTicks(1573));
        }
    }
}
