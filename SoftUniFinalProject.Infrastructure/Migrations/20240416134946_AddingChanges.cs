using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddingChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e5d8868-3cd4-454c-ad7c-a30ab4777667", "AQAAAAEAACcQAAAAEFpwuRnXiCklmO0hkiuCbr1kg+acYuAK1U6Wd7urNTbKpDzyuv9BsIIKRaf3I/NjYQ==", "88796983-e4b6-4e9a-8c92-c71be1287cb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c080021-fdb2-49df-a82a-9b553a94fc75", "AQAAAAEAACcQAAAAEGTrsEvNYr2Kxlq09Q6yZiH83CuBQsVhVJwfFF1wwRtelymRGMjfEDkoicVa7gmbhg==", "d17348ff-e302-481f-9bfc-775693f502e5" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 4, 16, 19, 49, 46, 714, DateTimeKind.Local).AddTicks(5775));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3718c97b-13cc-4a12-b11c-a27bf55d426c", "AQAAAAEAACcQAAAAECXOGxZtWT4eYcr7oFGlWVrMNBqV7ab6/5XXSk0bBksoh70PUTBZc05EO+Bwl8fYhg==", "aa34da78-12f4-4765-b7df-86b37a393c4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c58d049-4ef4-4d26-b328-8d1fc9ec384f", "AQAAAAEAACcQAAAAEC5w/N/ViC94eu0ozaz56Hu9ThTSMOgDWhESWXiHiCQ7U4gWdrtkxOILWvg1DWn8ZA==", "5f074481-2dc1-4804-a699-0e4388ed0697" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 4, 16, 16, 58, 11, 842, DateTimeKind.Local).AddTicks(7742));
        }
    }
}
