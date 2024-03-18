using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddingFootballGamePlayFor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec532e8a-1d7d-41c7-a94b-55346b8be363", "AQAAAAEAACcQAAAAEBNgOoph0Ex271IrelIjC98YCXHk01953uDxX4ZXuxpdhAxI2VGpHnGG+9hes2/Ixw==", "698c5f2b-0a9d-4182-a4af-13641e4d0560" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ae72a01-2e1d-4909-a0b4-9c402e95e22c", "AQAAAAEAACcQAAAAENSrotUitdidhDblGj10CQarHjWZJrPv+jtgDS1Hm1FSnPeDMnH+C6T9BFYZGqCX4A==", "f469b5a8-30fe-4f3e-b6d7-69db75e2c43b" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 18, 16, 2, 36, 483, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "FootballGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayingFor",
                value: "Premier League Game");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59333232-960e-4819-beee-6f9ed8ad73d5", "AQAAAAEAACcQAAAAEF86Ov1cvtanR5dYqVbKLUtBAIXaEerIxruDlJYncyicYdEQlXeOqIyqVIueHx0duA==", "e612a1d2-528e-4841-907b-bbb369309ff6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13498c9-b9aa-4be0-b96b-a7b0ea8b64ec", "AQAAAAEAACcQAAAAELWDevOnf600toBayL7Yh/OKyfPV4JMvWB95dP8E6O7mEJorQXj85Ii37xQTUu2hNg==", "3df713ac-1fce-4ffd-8f86-cdd1fbb17a0e" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 15, 22, 42, 50, 803, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "FootballGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayingFor",
                value: "");
        }
    }
}
