using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class MakingStadiumCapacityRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
