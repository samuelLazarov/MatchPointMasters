using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    public partial class SecondTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentHost_AspNetUsers_UserId",
                table: "TournamentHost");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentHost_TournamentHostId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentHost",
                table: "TournamentHost");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "TournamentHost",
                newName: "TournamentHosts");

            migrationBuilder.RenameColumn(
                name: "CommentTitle",
                table: "ArticleComments",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CommentDescription",
                table: "ArticleComments",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentHost_UserId",
                table: "TournamentHosts",
                newName: "IX_TournamentHosts_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Tournament's total capacity");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tournaments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "The current Event's Image Url");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentHosts",
                table: "TournamentHosts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 2, "user:fullname", "Ivan Pandeliev", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Samuel Lazarov", "dea12856-c198-4129-b3f3-b893d83950p1" },
                    { 4, "user:fullname", "Sarkis Haralampiev", "dea12856-c198-4129-b3f3-b893d83950p2" },
                    { 5, "user:fullname", "Ivan Pritargov", "f98e572e-f64b-40f5-a37f-783d2d1ff0p3" },
                    { 6, "user:fullname", "Daniil Kurian", "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4" },
                    { 7, "user:fullname", "Rado Vladimirov", "adb4186a-f51d-4969-aa0f-938a524128p5" },
                    { 8, "user:fullname", "Dimitar Berdankov", "4319f732-1f7d-44e3-8b4b-7d698f7c44p6" },
                    { 9, "user:fullname", "Dimitar Randev", "9b9265e6-61b2-4b6f-af23-1e1af744b1p7" },
                    { 10, "user:fullname", "Rosen Markov", "c45b149d-4c95-4742-b848-739af7b0bfp8" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92d179ff-309c-4873-a96a-5ba815c3b44e", "Dimitar", "Berdankov", "AQAAAAEAACcQAAAAEAIyodA/NXssH/lIkblUadWLE661EShQRle2oK7RizJkVDj9HhqKcODqzmPzIqceLQ==", "7ae48a19-0834-427c-a482-9bc3bc9e2d17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ced6b21-11c3-41f3-a38f-7c5d1860556c", "Daniil", "Kurian", "AQAAAAEAACcQAAAAEOtDPpI296YR7RqpdPmlEu+EfLNaM18gPapK4uuYJjLGgKpdB96PM/dy72VnnI2LzA==", "d40e6cf5-1b01-4562-bafb-a2f0621e6fcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef25861-c1f6-4a35-a34e-e93f865721a8", "Ivan", "Pandeliev", "AQAAAAEAACcQAAAAEPdd0o5CBvQgIius/iN60pR5/STJSpGLoHo1Xltpfq14+ok26SdWtcezXaXFvga/1A==", "02dbd689-5cbb-41f8-8a17-ad9b0cb18ee6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f73ea95-6177-4b41-9293-586f6a3daedb", "Dimitar", "Randev", "AQAAAAEAACcQAAAAEJs5UF2AV7xmhfTlh/h5089V9dJ+1zDTOGyFUZp6Iq/v6Dwz6rnrb17UfZu+SwrEqg==", "bd82143d-5b5f-4d5e-a539-b5b422523b35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adb4186a-f51d-4969-aa0f-938a524128p5",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33fc4602-d4db-4c43-9d79-2e63be15c48e", "Rado", "Vladimirov", "AQAAAAEAACcQAAAAELULDdtvHITmIbTXemJJ94bB9Kt9gQbfJzR7ZSTSJZpalX/p3a5kwt9UlPl2WRcgkg==", "74cf2090-94c6-49f5-8629-6935d22435ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c45b149d-4c95-4742-b848-739af7b0bfp8",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d07fbf0b-ff18-4873-ac2d-5cb45a06018c", "Rosen", "Markov", "AQAAAAEAACcQAAAAEBWRsNSBLyJs69lOFbw0kmTr7918UlgM9t+ZzRuSibWTvDGThNTSXNAFr+yceQKTuA==", "81f53e14-a456-471d-9095-ec773a085657" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p1",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3f06ae2-5e32-46c5-a707-8b4cc63cf813", "Samuel", "Lazarov", "AQAAAAEAACcQAAAAENdXJTUdffinY1b70Jco7fLDWhrjIaFvDJ/4ZbbKAhhzU2ABTn3VZYBhGs3MQ0ctCQ==", "7faeb975-8800-4824-aa2f-851ef9d594fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p2",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31dce8ef-9e5b-464d-8fd9-28ee4b6c1dbd", "Sarkis", "Haralampiev", "AQAAAAEAACcQAAAAEMuEGJTDbexjY7yQnhoDN3FCr/XAHKlhrlHwuQnu4LmMb83sE7aWYLYB/UlDoH0x1g==", "5c60888d-c96c-43cd-b607-369de29f36bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a061810-8a1f-4adc-ac94-da29ebd2da2a", "Ivan", "Pritargov", "AQAAAAEAACcQAAAAEL29pEEPbcv8hInhk1LWUGUZ1rf6hyOd2vUCz3XJDfjx1xHownbWl5vsHD6oeXkhRQ==", "777ae7c0-5b58-47b4-a295-ee06e368a2d9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c2f14bf7-ffdd-47a4-90b3-f2309486fae9", 0, "148ffabf-8efb-4c20-a3e3-c669be1811aa", "admin@gmail.com", false, "Admin", "Adminov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEH1jbq7AyLl7kL/iX/DM4S3FhMdy/l0d6V/ghrJJAUETkBgN0v6T0AXybCT+ZZLGPw==", null, false, "b4d5c071-49b6-4626-8ceb-d1fb6bd844d3", false, "admin@gmail.com" },
                    { "C9836E2F-52AD-4A3E-A92C-54CCE72D4C12", 0, "2a6b8704-8bc1-4305-8382-085b036534a7", "guest@gmail.com", false, "Guest", "Guestov", false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAEAACcQAAAAEKymE2RZVhaFrzYHoV+4wfPkIZETwCgSuaGVW0uk8kU0rsWi3m3LILZDXkM/CFm4/A==", null, false, "e359d53e-a4a4-4df1-a8d7-30e9b06e9c21", false, "guest@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "ImageUrl" },
                values: new object[] { 8, "https://t3.ftcdn.net/jpg/03/13/24/94/360_F_313249442_rVaztYCo9u5FOKtxWWGtKgw38AVvt7Qb.jpg" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capacity", "ImageUrl" },
                values: new object[] { 8, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8fpiUYEQEoUFiJwYQJ8382V2wnmam4k1233V8qVD4mg&s" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "ImageUrl" },
                values: new object[] { 8, "https://leader96.com/wp-content/uploads/2021/10/leader96_post_1-1000x550.jpg" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "user:fullname", "Admin Adminov", "c2f14bf7-ffdd-47a4-90b3-f2309486fae9" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 11, "user:fullname", "Guest Guestov", "C9836E2F-52AD-4A3E-A92C-54CCE72D4C12" });

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentHosts_AspNetUsers_UserId",
                table: "TournamentHosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentHosts_TournamentHostId",
                table: "Tournaments",
                column: "TournamentHostId",
                principalTable: "TournamentHosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TournamentHosts_AspNetUsers_UserId",
                table: "TournamentHosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentHosts_TournamentHostId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentHosts",
                table: "TournamentHosts");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C9836E2F-52AD-4A3E-A92C-54CCE72D4C12");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TournamentHosts",
                newName: "TournamentHost");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ArticleComments",
                newName: "CommentTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ArticleComments",
                newName: "CommentDescription");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentHosts_UserId",
                table: "TournamentHost",
                newName: "IX_TournamentHost_UserId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The current Player's First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The current Player's Last Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentHost",
                table: "TournamentHost",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9962053-5cd8-4a3e-b589-8f1750305634", "AQAAAAEAACcQAAAAECK1Mn2ZPXCEFtRzmDWHJw8lDC6gRjAz0WO/j5TwZ+L4XAZwGdoMhNceUeUHf4/FOg==", "0791bc05-6d0a-40d7-bd3d-985d027ef8d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c21b3701-7178-4553-84d9-2b2c3d75333c", "AQAAAAEAACcQAAAAEIIWHHS373KSt10N5565AeWC9qaguS6mt6B2yIqwFCAhE3HmmAYkXFTCMpi8pTcQzg==", "e2a7401a-e2e9-4d41-a5dc-c50d5c9f0349" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a46645e-ca0a-451c-b416-7774e80db609", "AQAAAAEAACcQAAAAEH0ZXSgVMdm5FIvHE97GwZBk5jVf6K2PJXMSGjyBT0R4YHp5TK0KPu3NOAtZQ/0UNQ==", "1f95c11a-bef5-49eb-b906-f1ce5a7e31fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0a5a91c-94a5-49f9-81ed-0ff5222014d4", "AQAAAAEAACcQAAAAEBiCuP+ADOnP3cz2+B7JeSeI2zfMDxvlqIP9z0xhfkmxxC9hfUcTJphbdTzNyLILvA==", "7bd9db09-0b2a-41ea-b869-ddb1c1d5554f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adb4186a-f51d-4969-aa0f-938a524128p5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16850aae-1362-4267-b085-5d8a10b19483", "AQAAAAEAACcQAAAAENZukN3EYBb4AYEIIGcXQQ8txeW1j2RyIIAQm2OFpW6UVQlSQ8j7N/IgjKHovN9qlQ==", "fabfabea-b69e-4d29-8d03-91db56e8a245" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c45b149d-4c95-4742-b848-739af7b0bfp8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f89e7b4-a7e6-443d-8e4e-e2f35bb22818", "AQAAAAEAACcQAAAAEJbR0HV9ILU8XgtNfkIZtabOMgx2BdiWawWq70lX1I+E6h8ucxDsDt82fiu7QkqrWw==", "96e22a7d-7fd6-4c71-bd23-17623e84be7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f59fd059-8d87-41d7-b3b9-179fe1a5cde1", "AQAAAAEAACcQAAAAEDuq3B5OcurAgXr09fVOtEP4AXJXbOcTcW2XFpaxht3OTqguE3bI1bZ0MwQorUbWOg==", "7efa0808-c993-4e80-b636-5b366b6c112d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3d16c91-bd55-4177-9767-dd1e9e609996", "AQAAAAEAACcQAAAAEDcw31i/eHjZDN42OY6jF/rczlV5pAXJSTZAH2ZYY70vNK022rgqoJEAIXo/zaVjTg==", "0292d4e5-68ec-4cc5-9117-e20f2dc1284e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01c4a405-fe31-4f3a-a766-ef79ed5f6ced", "AQAAAAEAACcQAAAAEFF3altZJJbJu7LeMDX7MZwVj4S3k2c9iZfhJocps0uxZECR0jaR121YLr6XD0Owlg==", "4d3e0d45-1906-4f64-8184-844e176a9d90" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Samuel", "Lazarov" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarkis", "Haralampiev" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Ivan", "Pritargov" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Daniil", "Kurian" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Rado", "Vladimirov" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Dimitar", "Berdankov" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Dimitar", "Randev" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Rosen", "Markov" });

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentHost_AspNetUsers_UserId",
                table: "TournamentHost",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentHost_TournamentHostId",
                table: "Tournaments",
                column: "TournamentHostId",
                principalTable: "TournamentHost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
