using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class UpdatedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c8699873-fad8-4fd1-abc1-65f032850ce2", "Guest", "User", "guest123", "AQAAAAEAACcQAAAAEPR7B3Ca8dHwDNpJS6ayxX7ckqbXlVyvhITndaTEJOohaMljtl7W9LM93aCcav6aVA==", "d7dec1f4-a673-489f-9a85-213b45dfee17", "guest123" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e91216f3-06fc-4d8b-aef8-79416c8c7cbf", "Host", "User", "host3663", "AQAAAAEAACcQAAAAEG1SK7frUpy/mc/ZEfLMtn1DPPaM0Qk7aPuyze71QTest9bgy+MpjXvOu0v2kRyR4w==", "4cf7003d-f825-4680-8324-c5db5a2fa439", "host3663" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 4, 12, 18, 40, 32, 504, DateTimeKind.Local).AddTicks(3533));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ec532e8a-1d7d-41c7-a94b-55346b8be363", "guest@football.com", "AQAAAAEAACcQAAAAEBNgOoph0Ex271IrelIjC98YCXHk01953uDxX4ZXuxpdhAxI2VGpHnGG+9hes2/Ixw==", "698c5f2b-0a9d-4182-a4af-13641e4d0560", "guest@football.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8ae72a01-2e1d-4909-a0b4-9c402e95e22c", "host@football.com", "AQAAAAEAACcQAAAAENSrotUitdidhDblGj10CQarHjWZJrPv+jtgDS1Hm1FSnPeDMnH+C6T9BFYZGqCX4A==", "f469b5a8-30fe-4f3e-b6d7-69db75e2c43b", "host@football.com" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationTime",
                value: new DateTime(2024, 3, 18, 16, 2, 36, 483, DateTimeKind.Local).AddTicks(7462));
        }
    }
}
