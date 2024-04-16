using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddingEventsCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3718c97b-13cc-4a12-b11c-a27bf55d426c", "GUEST123", "AQAAAAEAACcQAAAAECXOGxZtWT4eYcr7oFGlWVrMNBqV7ab6/5XXSk0bBksoh70PUTBZc05EO+Bwl8fYhg==", "aa34da78-12f4-4765-b7df-86b37a393c4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c58d049-4ef4-4d26-b328-8d1fc9ec384f", "HOST3663", "AQAAAAEAACcQAAAAEC5w/N/ViC94eu0ozaz56Hu9ThTSMOgDWhESWXiHiCQ7U4gWdrtkxOILWvg1DWn8ZA==", "5f074481-2dc1-4804-a699-0e4388ed0697" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 4, 16, 16, 58, 11, 842, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOn",
                value: new DateTime(2024, 4, 20, 17, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FootballGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartGame",
                value: new DateTime(2024, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new string[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins", new string[] { "LoginProvider", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8699873-fad8-4fd1-abc1-65f032850ce2", "guest123", "AQAAAAEAACcQAAAAEPR7B3Ca8dHwDNpJS6ayxX7ckqbXlVyvhITndaTEJOohaMljtl7W9LM93aCcav6aVA==", "d7dec1f4-a673-489f-9a85-213b45dfee17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e91216f3-06fc-4d8b-aef8-79416c8c7cbf", "host3663", "AQAAAAEAACcQAAAAEG1SK7frUpy/mc/ZEfLMtn1DPPaM0Qk7aPuyze71QTest9bgy+MpjXvOu0v2kRyR4w==", "4cf7003d-f825-4680-8324-c5db5a2fa439" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 4, 12, 18, 40, 32, 504, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartOn",
                value: new DateTime(2024, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FootballGames",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartGame",
                value: new DateTime(2024, 4, 14, 18, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
