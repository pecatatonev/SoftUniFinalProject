using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class NicknameNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Teams",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                comment: "Team Nickname",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldComment: "Team Nickname");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "856ccdb0-0055-41f1-b12a-a86503542315", "AQAAAAEAACcQAAAAEOjBoZlGVlxF3f8E1ve//Dmso/eLKdC8iuu3wE1bpNKWutvDOWh62hkHE6CTyMnLyA==", "eb4a575b-bd45-4e20-9368-626bc1251215" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be818880-f62f-4ef5-ad1d-d9cb5496200b", "AQAAAAEAACcQAAAAEIz+WtXGdRw4znnlb4pmvP9XadN1T5qGn+QNzzofpqoWkXR341/m0laDrCuUnnpE+Q==", "fd87fdc0-b47c-4391-b49a-c2725eb09c07" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 14, 0, 8, 59, 900, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOn",
                value: new DateTime(2004, 3, 13, 21, 8, 59, 893, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartOn",
                value: new DateTime(2001, 3, 13, 21, 8, 59, 893, DateTimeKind.Local).AddTicks(2747));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nickname",
                table: "Teams",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                comment: "Team Nickname",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true,
                oldComment: "Team Nickname");

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
        }
    }
}
