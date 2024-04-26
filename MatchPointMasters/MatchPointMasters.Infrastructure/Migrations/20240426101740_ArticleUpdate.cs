using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    public partial class ArticleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_HostUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_HostUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "HostUserId",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f15b580-6c95-4127-9c1e-fbc5bc7e9609", "AQAAAAEAACcQAAAAEKVGgq7ubGrp0aATTLFm5wqSm6ygXNWLMkTrrIA3EkNJ/T2qMRiJ/4Uu8Y7LnhV84w==", "fcc48555-2505-4800-a53d-721bd5a64690" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89859292-8a56-4b0b-9c63-a7f1129d7751", "AQAAAAEAACcQAAAAEJrPCjTLP7YbD6KT4KnMBXT5qV4N24j4U7/+XoAQDMEKS3J8EPg76eJwjli1jx90Pg==", "d9c93698-5de1-4997-b798-b3af1edad2bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd3525ca-1438-44ef-b5a5-b222786ec891", "AQAAAAEAACcQAAAAEFfqxCqt3Uj07cPm5sMQj9HTj0oqVgQp22UU/ofTB3UU808h5SkGq3jnj8XR2XrUFg==", "f6b35d9c-2781-421e-9caf-b93252089583" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51eecbff-568d-4f1f-9dad-2b3652871430", "AQAAAAEAACcQAAAAEMy/E2wV8n8VR/9FIO3yFZw4fu8DISL1aeh9xfRK8ck77IiG37s23KDPuB9ftBclIQ==", "fabd842e-2910-4b7a-958d-ea17a35db0e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adb4186a-f51d-4969-aa0f-938a524128p5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d4b985d-34d2-4dd2-abbf-2a5a768684b1", "AQAAAAEAACcQAAAAEEAt8MLLG/sy2NWhNjchcKUAny57dlwbMdqstvu4uMjTZc6HAesPc0G9Gv49nVB6Jw==", "689bd705-f1ba-4722-996b-e52e04e3a7bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b125445-3eb2-4aa8-afb1-5cfa6787a2c4", "AQAAAAEAACcQAAAAEGNQlXwNtmfVQB0mFptc0RKua9Bu19U1JTFdvHxSK+17Hc8MAegj5Gp80hWs/IUpOg==", "0a22eda7-7f2c-44a5-9da2-543c87ed1b48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c45b149d-4c95-4742-b848-739af7b0bfp8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b22cd29-d8b2-47ee-b685-94dddc2db2e6", "AQAAAAEAACcQAAAAEOz1JPw+kjhn6IRYcjXDRZoO/XmiyMiuZjK8ZPthGb4dVI1xFY18+fPEJbkibtOiAw==", "a6414dc5-4d9a-4f23-be60-3bc75ccef71d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C9836E2F-52AD-4A3E-A92C-54CCE72D4C12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9759fee-7380-4376-9738-7865e33ce981", "AQAAAAEAACcQAAAAEHX9qPw1Hvpd7obKDmQR+OBRtFhbAilwiCFDr6zXdDYMwhEbPsKB1LcWp1V01qajTA==", "44a40121-a59c-441f-ba71-f0f6a7abe190" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74211ca3-d6f2-494c-80f9-82d3555664fe", "AQAAAAEAACcQAAAAELUVVL08IAA7sMB8rjmXXWOG8no4R4T4WVf3c1xVOvrKNiQQjevQEqYfPW/Me/YfrA==", "e2138bfb-a0bb-4ad3-9435-5fc3b55c07b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0251717c-c87d-49f1-b848-67bb5eb03e67", "AQAAAAEAACcQAAAAEACrKnhexICySMfzQBt3N8WWYid1WJzoO1JDClJ4zY2BQ+aeqQFYE1wJTct8X2QuAg==", "d609fb67-6321-4029-aefd-5985a91f1af0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ac738b9-c24a-4ad1-b3b7-aa07a45f24c7", "AQAAAAEAACcQAAAAEKW2N8JYRPb1bfymkKlZ0G9bD4HO2DAZxHyM0+gFu0/Wom90ustQBe1FV/eMpNIWzQ==", "6221b671-d5f6-47da-90e1-31b9ebc94494" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "The current author's identifier");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "HostUserId",
                value: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "HostUserId",
                value: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "HostUserId",
                value: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2771a9b-1d6e-42e6-b8fd-a5aa17cda498", "AQAAAAEAACcQAAAAEMdCPZzKu2EGZTh2XlIjjwCg0gynhxvn9n+ID4GvpW+PKIg6kNoyP7KbJtqYG1Y6cQ==", "fb99d9e9-1266-4b02-b3d5-df85d6e896f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27a902c6-da8a-4b71-85fc-cbaf11fe49f6", "AQAAAAEAACcQAAAAEA3+wa+M7IaGLwvHTEIEHJiyjlZI7INPxv25mOnxBGTM2JA5srBdGPwQVsH+iVKJ7g==", "35abaa4f-00f8-46b8-8ac9-a3e8ef881c2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2db7cd5-074b-4714-99a0-f3d2e896fa48", "AQAAAAEAACcQAAAAEFT0qCWEMqJNyG+mavz9QOKPMF7piZop1ZETCbXiQevHhvH0aHphUUJ4IVHW/y7bWw==", "2a800d5d-cabd-4122-ac25-2837bb470a4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c81ac862-a8e7-4f32-afc5-919a8dfa68bc", "AQAAAAEAACcQAAAAELvCkZV5zuSLseS1Cz1Rb0qhpfMdB1bHHK0rR0AeGTBF/Wl0FYTP8y+LlxsOEX3wYQ==", "cae4dd3a-8c92-45c1-8edf-a2f695bd9b43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adb4186a-f51d-4969-aa0f-938a524128p5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b300a51-dad5-410a-a062-00aefb3268fd", "AQAAAAEAACcQAAAAEM8ICSuAmoRpyhrSeDYxLXaokvLN0WGj2qGG1jhHxtpOfwOf8ECMt2dysmpMhy6mPg==", "69b1656c-d674-441e-8ffc-ec5a6c50db25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f14bf7-ffdd-47a4-90b3-f2309486fae9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d37e98a-8773-405d-b8cc-f000fc8a8cf4", "AQAAAAEAACcQAAAAENI1S0TyeIU/HEcKCzcCvLw0SkHKT3raEYURJqJURC5zQcup+DJWOEVslgVBG0j8oQ==", "452d6457-b2bf-41ac-8711-4674da7665ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c45b149d-4c95-4742-b848-739af7b0bfp8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76e8e6ee-69bd-4b03-ae5b-63d4b718721a", "AQAAAAEAACcQAAAAELh16W6K6UT3E2SKl8JFvf7Yh544mkinkEG+PmkTSTkyuJDrtsiciirN88Wv5CBh9A==", "0c86aba1-4725-4a81-8019-2b55f7d32d5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C9836E2F-52AD-4A3E-A92C-54CCE72D4C12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2492ae9-f1cb-4d2c-a776-ad470e100a75", "AQAAAAEAACcQAAAAEBlRiH1evZB7ZiUtXUoGMmhpSa5KayPASH+9ZDL84RtiyKDo/XqpCSSnigb8Qc6vzQ==", "0c198b8b-15e5-4f72-b293-9b13edb1b2e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37835ffe-031c-4736-becd-e48e50ce3bcb", "AQAAAAEAACcQAAAAEBztUHsPKdYnOc0yJCJyMC9LQF0LrOeKsJx72RkuVxXh0D5aCcZ9K2OPtJjjhC/Rnw==", "e18454c1-ff85-4816-b2cb-d66e89acd95d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d73c8fd6-75ae-4757-b4e7-e0c3d83e489d", "AQAAAAEAACcQAAAAEIG3QuAFn87YACALcLvbokcxW9WMrlrETou/yBFm0EoQs7feTXs2WBvqcHxduR6Q3g==", "62ef2c7f-b8c1-4327-bfbb-610ac9c80c22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "960c21ef-c9c2-4913-a680-9a9e5952b8de", "AQAAAAEAACcQAAAAEBe2e6GWOdTdwovyuXApvr+RXXBVzydmKlpRrCF8nBv5aYsbjkhimYAdpeI/AzsOdQ==", "ca84ef16-70ae-49d9-8ba8-b69cfe052fd7" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_HostUserId",
                table: "Articles",
                column: "HostUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_HostUserId",
                table: "Articles",
                column: "HostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
