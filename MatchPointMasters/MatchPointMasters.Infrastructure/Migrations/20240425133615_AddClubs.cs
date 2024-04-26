using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    public partial class AddClubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Club_HostClubId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "Clubs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");           

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Clubs_HostClubId",
                table: "Tournaments",
                column: "HostClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Clubs_HostClubId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "Club");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Club_HostClubId",
                table: "Tournaments",
                column: "HostClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
