using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e", 0, "ba2aa06d-153a-45e8-9a2b-8ee962dff092", "guest@football.com", false, false, null, "guest@football.com", "guest@football.com", "AQAAAAEAACcQAAAAEKC6T2Su8CWt2N4+KHgm/MlW9qhuoO+T1BW6Oj7RW+Xw8o1KYnefIIP21K4fnz7/EA==", null, false, "cf821a13-c3c7-426e-926e-93354de44d74", false, "guest@football.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6ef879a0-1250-4873-9724-0f6de3b1bc7a", "host@football.com", false, false, null, "host@football.com", "host@football.com", "AQAAAAEAACcQAAAAEOLHeM8fs6Uc9xLkWHeGyJZlvQ30Acxc1vJLQlQ9q9W+9n8WzyY1NfgghMjK8bTByg==", null, false, "1b2d3a4a-b74a-4fd7-ba70-8ad9fab80dbc", false, "host@football.com" }
                });

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "Id", "ImageUrl", "Name", "NetWorthInBillion", "StartOn" },
                values: new object[,]
                {
                    { 1, "https://cdn.britannica.com/94/193794-050-0FB7060D/Adidas-logo.jpg", "Addidas", 5, new DateTime(2004, 3, 9, 13, 25, 44, 799, DateTimeKind.Local).AddTicks(1568) },
                    { 2, "https://cdn.shopify.com/s/files/1/0558/6413/1764/files/Rewrite_Nike_Logo_Design_History_Evolution_0_1024x1024.jpg?v=1695304464", "Nike", 6, new DateTime(2001, 3, 9, 13, 25, 44, 799, DateTimeKind.Local).AddTicks(1573) }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ImageUrl", "ManagerName", "Name", "Nickname", "StadiumCapacity", "StadiumName", "YearCreated" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/en/thumb/7/7a/Manchester_United_FC_crest.svg/1200px-Manchester_United_FC_crest.svg.png", "Erik ten Hag", "Manchester United F.C", "Red Devils", 78000, "Old Trafford", new DateTime(1887, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "https://upload.wikimedia.org/wikipedia/en/thumb/0/0c/Liverpool_FC.svg/1200px-Liverpool_FC.svg.png", "Jurgen Kloop", "Liverpool F.C", "The Reds", 60730, "Anfield", new DateTime(1897, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FootballGames",
                columns: new[] { "Id", "AwayTeamId", "HomeTeamId", "PlayingFor", "RefereeName", "StartGame" },
                values: new object[] { 1, 2, 1, "", "Mike Dean", new DateTime(2024, 4, 14, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "FootballGameId", "Location", "Name", "OrganiserId", "StartOn" },
                values: new object[] { 1, "This is oldest and biggest derby in England Premier League", 1, "The Corner Cafe", "Biggest English Derby", "dea12856-c198-4129-b3f3-b893d8395082", new DateTime(2024, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "EventId", "PublicationTime", "Text", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 3, 9, 16, 25, 44, 806, DateTimeKind.Local).AddTicks(138), "I can't wait for that derby", "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sponsors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce - d726 - 4fc8 - 83d9 - d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "FootballGames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
