using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddingIntYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearCreated",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StartOn",
                table: "Sponsors");

            migrationBuilder.AddColumn<int>(
                name: "YearOfCreation",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Creation year of the team");

            migrationBuilder.AddColumn<int>(
                name: "YearCreation",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Creation year of the Sponsor");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9596e8-20b0-4d42-a030-3e4f76e13934", "AQAAAAEAACcQAAAAEDF+RRW6yaH/27fIzBY3N5vrK7rTT/RfZ+ImCnWcrSlAfce5AKyDmvzgZg6lKXGzdQ==", "ff923984-ec0b-4d29-b5b9-affcb88e59a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17b497be-77d2-470c-9caa-2f48e2d8ed98", "AQAAAAEAACcQAAAAEFell7MJZ3lWGwLlNTTkgl/TDczqhyhHBTUNDecjbSjeZrTBDASr3cU/Gprvybj9BA==", "149bc95c-debb-4d46-98eb-ec5e204d2efa" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 15, 22, 7, 57, 555, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 1,
                column: "YearCreation",
                value: 1949);

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 2,
                column: "YearCreation",
                value: 1964);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "YearOfCreation",
                value: 1887);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "YearOfCreation",
                value: 1897);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearOfCreation",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "YearCreation",
                table: "Sponsors");

            migrationBuilder.AddColumn<DateTime>(
                name: "YearCreated",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Year of creation");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartOn",
                table: "Sponsors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of creation");

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

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "YearCreated",
                value: new DateTime(1887, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "YearCreated",
                value: new DateTime(1897, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
