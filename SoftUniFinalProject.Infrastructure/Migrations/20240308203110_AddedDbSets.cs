using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniFinalProject.Infrastructure.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Event_EventId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_OrganiserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_FootballGame_FootballGameId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_AspNetUsers_UserId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGame_Team_AwayTeamId",
                table: "FootballGame");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGame_Team_HomeTeamId",
                table: "FootballGame");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSponsor_Sponsor_SponsorId",
                table: "TeamSponsor");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSponsor_Team_TeamId",
                table: "TeamSponsor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSponsor",
                table: "TeamSponsor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsor",
                table: "Sponsor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballGame",
                table: "FootballGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipant",
                table: "EventParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "TeamSponsor",
                newName: "TeamsSponsors");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Sponsor",
                newName: "Sponsors");

            migrationBuilder.RenameTable(
                name: "FootballGame",
                newName: "FootballGames");

            migrationBuilder.RenameTable(
                name: "EventParticipant",
                newName: "EventsParticipants");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSponsor_TeamId",
                table: "TeamsSponsors",
                newName: "IX_TeamsSponsors_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGame_HomeTeamId",
                table: "FootballGames",
                newName: "IX_FootballGames_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGame_AwayTeamId",
                table: "FootballGames",
                newName: "IX_FootballGames_AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipant_UserId",
                table: "EventsParticipants",
                newName: "IX_EventsParticipants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_OrganiserId",
                table: "Events",
                newName: "IX_Events_OrganiserId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_FootballGameId",
                table: "Events",
                newName: "IX_Events_FootballGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_EventId",
                table: "Comments",
                newName: "IX_Comments_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsSponsors",
                table: "TeamsSponsors",
                columns: new[] { "SponsorId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballGames",
                table: "FootballGames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsParticipants",
                table: "EventsParticipants",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_OrganiserId",
                table: "Events",
                column: "OrganiserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FootballGames_FootballGameId",
                table: "Events",
                column: "FootballGameId",
                principalTable: "FootballGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsParticipants_AspNetUsers_UserId",
                table: "EventsParticipants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsParticipants_Events_EventId",
                table: "EventsParticipants",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGames_Teams_AwayTeamId",
                table: "FootballGames",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGames_Teams_HomeTeamId",
                table: "FootballGames",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsSponsors_Sponsors_SponsorId",
                table: "TeamsSponsors",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsSponsors_Teams_TeamId",
                table: "TeamsSponsors",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_OrganiserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_FootballGames_FootballGameId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsParticipants_AspNetUsers_UserId",
                table: "EventsParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsParticipants_Events_EventId",
                table: "EventsParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Teams_AwayTeamId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballGames_Teams_HomeTeamId",
                table: "FootballGames");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsSponsors_Sponsors_SponsorId",
                table: "TeamsSponsors");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsSponsors_Teams_TeamId",
                table: "TeamsSponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsSponsors",
                table: "TeamsSponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FootballGames",
                table: "FootballGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsParticipants",
                table: "EventsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "TeamsSponsors",
                newName: "TeamSponsor");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Sponsors",
                newName: "Sponsor");

            migrationBuilder.RenameTable(
                name: "FootballGames",
                newName: "FootballGame");

            migrationBuilder.RenameTable(
                name: "EventsParticipants",
                newName: "EventParticipant");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsSponsors_TeamId",
                table: "TeamSponsor",
                newName: "IX_TeamSponsor_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGames_HomeTeamId",
                table: "FootballGame",
                newName: "IX_FootballGame_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_FootballGames_AwayTeamId",
                table: "FootballGame",
                newName: "IX_FootballGame_AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_EventsParticipants_UserId",
                table: "EventParticipant",
                newName: "IX_EventParticipant_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganiserId",
                table: "Event",
                newName: "IX_Event_OrganiserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_FootballGameId",
                table: "Event",
                newName: "IX_Event_FootballGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_EventId",
                table: "Comment",
                newName: "IX_Comment_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSponsor",
                table: "TeamSponsor",
                columns: new[] { "SponsorId", "TeamId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsor",
                table: "Sponsor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FootballGame",
                table: "FootballGame",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipant",
                table: "EventParticipant",
                columns: new[] { "EventId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Event_EventId",
                table: "Comment",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_OrganiserId",
                table: "Event",
                column: "OrganiserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_FootballGame_FootballGameId",
                table: "Event",
                column: "FootballGameId",
                principalTable: "FootballGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_AspNetUsers_UserId",
                table: "EventParticipant",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipant_Event_EventId",
                table: "EventParticipant",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGame_Team_AwayTeamId",
                table: "FootballGame",
                column: "AwayTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FootballGame_Team_HomeTeamId",
                table: "FootballGame",
                column: "HomeTeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSponsor_Sponsor_SponsorId",
                table: "TeamSponsor",
                column: "SponsorId",
                principalTable: "Sponsor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSponsor_Team_TeamId",
                table: "TeamSponsor",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
