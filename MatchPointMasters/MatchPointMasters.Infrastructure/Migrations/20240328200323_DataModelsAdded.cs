using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    public partial class DataModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current author's identifier"),
                    Title = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Article's Title"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, comment: "The current Article's Content"),
                    DatePublished = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date on which the current Article was posted"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The current Article's Image Url"),
                    ViewsCount = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Views Count")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_HostUserId",
                        column: x => x.HostUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Articles can be created by Tournament Hosts and commented by Players");

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Tennis Club's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current club's name"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Club's address"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Club's phone"),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Tennis club's image url"),
                    CourtSurface = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                },
                comment: "Tennis club hosting a tournament");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Player's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Player's First Name"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Player's Last Name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Player's phone"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DominantHand = table.Column<int>(type: "int", nullable: true, comment: "Player's dominant hand"),
                    Backhand = table.Column<int>(type: "int", nullable: true, comment: "Player's backhand style"),
                    PlayingStyle = table.Column<int>(type: "int", nullable: true, comment: "Player's style of play"),
                    TennisRacket = table.Column<int>(type: "int", nullable: true, comment: "Player's racket brand"),
                    Wins = table.Column<int>(type: "int", nullable: false, comment: "Player's wins counter"),
                    Losses = table.Column<int>(type: "int", nullable: false, comment: "Player's losses counter"),
                    TournamentWins = table.Column<int>(type: "int", nullable: true, comment: "Player's Tournament wins counter"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentHost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Tournament host's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Tournament host's phone"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentHost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentHost_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A user who will host a tournament");

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Tournament's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The current Tournament's Name"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Tournament description"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Tournament's start date and hour"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The current Tournament's end date and hour"),
                    HostClubId = table.Column<int>(type: "int", nullable: false, comment: "Host club's Identifier"),
                    TournamentHostId = table.Column<int>(type: "int", nullable: false, comment: "Tournament Host's Identifier"),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Tournament fee"),
                    TournamentBalls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Club_HostClubId",
                        column: x => x.HostClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_TournamentHost_HostClubId",
                        column: x => x.HostClubId,
                        principalTable: "TournamentHost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Match Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false, comment: "The current Tournament Identifier"),
                    MatchRound = table.Column<int>(type: "int", nullable: false, comment: "The current Match Round from Tournament"),
                    PlayerOneId = table.Column<int>(type: "int", nullable: false, comment: "The current Player One's Identifier"),
                    PlayerTwoId = table.Column<int>(type: "int", nullable: false, comment: "The current Player Two's Identifier"),
                    PlayerOneSetsWon = table.Column<int>(type: "int", nullable: false),
                    PlayerTwoSetsWon = table.Column<int>(type: "int", nullable: false),
                    Winner = table.Column<int>(type: "int", nullable: false, comment: "Indicates who wins the match")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Players_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Players_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tennis match between two players in a tournament");

            migrationBuilder.CreateTable(
                name: "PlayersTournaments",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false, comment: "The current Player's Identifier"),
                    TournamentId = table.Column<int>(type: "int", nullable: false, comment: "The current Tournament's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTournaments", x => new { x.PlayerId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_PlayersTournaments_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayersMatches",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false, comment: "The current Player's Identifier"),
                    MatchId = table.Column<int>(type: "int", nullable: false, comment: "The current Tennis Match Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersMatches", x => new { x.PlayerId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_PlayersMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersMatches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TournamentMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false, comment: "The current Tennis Match Identifier"),
                    TournamentId = table.Column<int>(type: "int", nullable: false, comment: "The current Tournament's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentMatches", x => new { x.TournamentId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Set's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false, comment: "Current Match Identifier"),
                    PlayerOneGamesWon = table.Column<int>(type: "int", nullable: false, comment: "Indicates number of games won by Player One in the current set"),
                    PlayerTwoGamesWon = table.Column<int>(type: "int", nullable: false, comment: "Indicates number of games won by Player Two in the current set"),
                    HasTiebreak = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates if current set is decided by tiebreak"),
                    TiebreakId = table.Column<int>(type: "int", nullable: true, comment: "The curent Tiebreak's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiebreaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerOnePoints = table.Column<int>(type: "int", nullable: false, comment: "Player One points"),
                    PlayerTwoPoints = table.Column<int>(type: "int", nullable: false, comment: "Player Two points"),
                    SetId = table.Column<int>(type: "int", nullable: false, comment: "Current Set Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiebreaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiebreaks_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "If a set must be decided by tiebreak");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_HostUserId",
                table: "Articles",
                column: "HostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersMatches_MatchId",
                table: "PlayersMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTournaments_TournamentId",
                table: "PlayersTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_MatchId",
                table: "Sets",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_TiebreakId",
                table: "Sets",
                column: "TiebreakId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiebreaks_SetId",
                table: "Tiebreaks",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentHost_UserId",
                table: "TournamentHost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentMatches_MatchId",
                table: "TournamentMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_HostClubId",
                table: "Tournaments",
                column: "HostClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Tiebreaks_TiebreakId",
                table: "Sets",
                column: "TiebreakId",
                principalTable: "Tiebreaks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Matches_MatchId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Tiebreaks_TiebreakId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "PlayersMatches");

            migrationBuilder.DropTable(
                name: "PlayersTournaments");

            migrationBuilder.DropTable(
                name: "TournamentMatches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "TournamentHost");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Tiebreaks");

            migrationBuilder.DropTable(
                name: "Sets");
        }
    }
}
