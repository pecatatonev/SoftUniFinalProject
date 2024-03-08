using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Sponsor Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Sponsor Name"),
                    NetWorthInBillion = table.Column<int>(type: "int", nullable: false, comment: "Sponsor NetWorth"),
                    StartOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Logo of the sponsor")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Team Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false, comment: "Team Name"),
                    YearCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Year of creation"),
                    ManagerName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Manager of the team"),
                    StadiumName = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false, comment: "Team Stadium Name"),
                    Nickname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Team Nickname"),
                    StadiumCapacity = table.Column<int>(type: "int", nullable: false, comment: "Stadium Capacity"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Team logo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Football Game Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayingFor = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Reason for the game"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false, comment: "Football Game Home Team Identifier"),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false, comment: "Football Game Away Team Identifier"),
                    RefereeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Referee of the match name"),
                    StartGame = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start of the game")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballGame_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FootballGame_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamSponsor",
                columns: table => new
                {
                    SponsorId = table.Column<int>(type: "int", nullable: false, comment: "Team Sponsor Identifier"),
                    TeamId = table.Column<int>(type: "int", nullable: false, comment: "Team Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSponsor", x => new { x.SponsorId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamSponsor_Sponsor_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSponsor_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Event Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Event Name"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Event Description"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Event Location"),
                    StartOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start of the event"),
                    OrganiserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Organiser Identifier"),
                    FootballGameId = table.Column<int>(type: "int", nullable: false, comment: "Football game Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_FootballGame_FootballGameId",
                        column: x => x.FootballGameId,
                        principalTable: "FootballGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Text of the comment"),
                    PublicationTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The publication time of the comment"),
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Event Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Creator of the comment Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventParticipant",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipant", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventParticipant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipant_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EventId",
                table: "Comment",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_FootballGameId",
                table: "Event",
                column: "FootballGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_OrganiserId",
                table: "Event",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_UserId",
                table: "EventParticipant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_AwayTeamId",
                table: "FootballGame",
                column: "AwayTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballGame_HomeTeamId",
                table: "FootballGame",
                column: "HomeTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamSponsor_TeamId",
                table: "TeamSponsor",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "EventParticipant");

            migrationBuilder.DropTable(
                name: "TeamSponsor");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "FootballGame");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
