using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPointMasters.Infrastructure.Migrations
{
    public partial class DataSeededModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersMatches_Matches_MatchId",
                table: "PlayersMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersMatches_Players_PlayerId",
                table: "PlayersMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTournaments_Players_PlayerId",
                table: "PlayersTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTournaments_Tournaments_TournamentId",
                table: "PlayersTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Tiebreaks_TiebreakId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiebreaks_Sets_SetId",
                table: "Tiebreaks");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Matches_MatchId",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Tournaments_TournamentId",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentHost_HostClubId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tiebreaks_SetId",
                table: "Tiebreaks");

            migrationBuilder.DropIndex(
                name: "IX_Sets_TiebreakId",
                table: "Sets");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "TournamentHost",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Tournament host's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Tournament host's phone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Players",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Player's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Player's phone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Club",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Club's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Club's phone");

            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The current Article Comment's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The current Article Comment's Title"),
                    CommentDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false, comment: "The current Article Comment's Description"),
                    ArticleId = table.Column<int>(type: "int", nullable: false, comment: "The current Article's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Articles can be created by Tournament Hosts and commented by Players");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4319f732-1f7d-44e3-8b4b-7d698f7c44p6", 0, "f9962053-5cd8-4a3e-b589-8f1750305634", "player6@gmail.com", false, false, null, "player6@gmail.com", "dimitar_berdankov", "AQAAAAEAACcQAAAAECK1Mn2ZPXCEFtRzmDWHJw8lDC6gRjAz0WO/j5TwZ+L4XAZwGdoMhNceUeUHf4/FOg==", null, false, "0791bc05-6d0a-40d7-bd3d-985d027ef8d3", false, "Dimitar_Berdankov" },
                    { "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4", 0, "c21b3701-7178-4553-84d9-2b2c3d75333c", "player4@gmail.com", false, false, null, "player4@gmail.com", "daniil_kurian", "AQAAAAEAACcQAAAAEIIWHHS373KSt10N5565AeWC9qaguS6mt6B2yIqwFCAhE3HmmAYkXFTCMpi8pTcQzg==", null, false, "e2a7401a-e2e9-4d41-a5dc-c50d5c9f0349", false, "Daniil_Kurian" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "2a46645e-ca0a-451c-b416-7774e80db609", "hostuser@gmail.com", false, false, null, "hostuser@gmail.com", "ivan_pandeliev", "AQAAAAEAACcQAAAAEH0ZXSgVMdm5FIvHE97GwZBk5jVf6K2PJXMSGjyBT0R4YHp5TK0KPu3NOAtZQ/0UNQ==", null, false, "1f95c11a-bef5-49eb-b906-f1ce5a7e31fb", false, "Ivan_Pandeliev" },
                    { "9b9265e6-61b2-4b6f-af23-1e1af744b1p7", 0, "e0a5a91c-94a5-49f9-81ed-0ff5222014d4", "player7@gmail.com", false, false, null, "player7@gmail.com", "dimitar_randev", "AQAAAAEAACcQAAAAEBiCuP+ADOnP3cz2+B7JeSeI2zfMDxvlqIP9z0xhfkmxxC9hfUcTJphbdTzNyLILvA==", null, false, "7bd9db09-0b2a-41ea-b869-ddb1c1d5554f", false, "Dimitar_Randev" },
                    { "adb4186a-f51d-4969-aa0f-938a524128p5", 0, "16850aae-1362-4267-b085-5d8a10b19483", "player5@gmail.com", false, false, null, "player5@gmail.com", "rado_vladimirov", "AQAAAAEAACcQAAAAENZukN3EYBb4AYEIIGcXQQ8txeW1j2RyIIAQm2OFpW6UVQlSQ8j7N/IgjKHovN9qlQ==", null, false, "fabfabea-b69e-4d29-8d03-91db56e8a245", false, "Rado_Vladimirov" },
                    { "c45b149d-4c95-4742-b848-739af7b0bfp8", 0, "3f89e7b4-a7e6-443d-8e4e-e2f35bb22818", "player8@gmail.com", false, false, null, "player8@gmail.com", "rosen_markov", "AQAAAAEAACcQAAAAEJbR0HV9ILU8XgtNfkIZtabOMgx2BdiWawWq70lX1I+E6h8ucxDsDt82fiu7QkqrWw==", null, false, "96e22a7d-7fd6-4c71-bd23-17623e84be7a", false, "Rosen_Markov" },
                    { "dea12856-c198-4129-b3f3-b893d83950p1", 0, "f59fd059-8d87-41d7-b3b9-179fe1a5cde1", "player1@gmail.com", false, false, null, "player1@gmail.com", "samuel_lazarov", "AQAAAAEAACcQAAAAEDuq3B5OcurAgXr09fVOtEP4AXJXbOcTcW2XFpaxht3OTqguE3bI1bZ0MwQorUbWOg==", null, false, "7efa0808-c993-4e80-b636-5b366b6c112d", false, "Samuel_Lazarov" },
                    { "dea12856-c198-4129-b3f3-b893d83950p2", 0, "c3d16c91-bd55-4177-9767-dd1e9e609996", "player2@gmail.com", false, false, null, "player2@gmail.com", "sarkis_haralampiev", "AQAAAAEAACcQAAAAEDcw31i/eHjZDN42OY6jF/rczlV5pAXJSTZAH2ZYY70vNK022rgqoJEAIXo/zaVjTg==", null, false, "0292d4e5-68ec-4cc5-9117-e20f2dc1284e", false, "Sarkis_Haralampiev" },
                    { "f98e572e-f64b-40f5-a37f-783d2d1ff0p3", 0, "01c4a405-fe31-4f3a-a766-ef79ed5f6ced", "player3@gmail.com", false, false, null, "player3@gmail.com", "ivan_pritargov", "AQAAAAEAACcQAAAAEFF3altZJJbJu7LeMDX7MZwVj4S3k2c9iZfhJocps0uxZECR0jaR121YLr6XD0Owlg==", null, false, "4d3e0d45-1906-4f64-8184-844e176a9d90", false, "Ivan_Pritargov" }
                });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "Address", "CourtSurface", "ImageUrl", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "гр. Бургас, ул. \"Ремсова\" 9", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRrwrXYCDoRqOa8d0Gbp0sXwcdsnEaP7UMMLRLbktc5sw&s", "Тенис клуб \"Ника\" - Бургас", "087 957 8998" },
                    { 2, "гр. Пловдив, ул. „Ясна поляна“ 4 ( Стадион Пловдив )", 0, "https://clickandplay.bg/f/clubs/o/0/c9d5f8339205cc200c539915e90abc06.jpeg", "Тенис клуб \"Локомотив\" - Пловдив", "0887 500 577" },
                    { 3, "гр. Бургас, главен път Бургас-Сарафово зад Аутлет \"Пума\"", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMNT5XsqUtV2SbtWba-CRF3FdCytyOy7Nc6xDd-WZNBA&s", "Тенис клуб \"Авеню\" - Бургас", "0887 141 111" },
                    { 4, "гр. Варна, м.\"Салтанат\", Приморски парк", 2, "https://tennis.bg/uploaded/courts/26/25e4c446e9e415930c4b3b094efffcf5.jpg", "Тенис клуб \"Велто\" - Варна", "052 711 457" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "DatePublished", "HostUserId", "ImageUrl", "Title", "ViewsCount" },
                values: new object[,]
                {
                    { 1, "Между 29 април и 1 май на кортовете „Стад“ в Пловдив се проведе 20-ото юбилейно издание на турнира за аматьори и ветерани \"Зашо\". В надпреварата се включиха 120 мъже и 10 жени, като шампиони станаха Дани Куриян и Ели Андонова, след като победиха във финалите Тодор Митев и Стефка Бончева.\r\n\r\nВ мъжките двойки трофеят спечелиха Андрей Андреев и Иван Андреев.\r\n\r\nТурнирът се проведе на високо ниво, като дори краткият дъжд на Деня на труда не попречи на благополучното завършване.", new DateTime(2023, 3, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "https://www.tenniskafe.com/wp-content/uploads/2023/05/Zasho-muje-1200x630.jpg", "УСПЕШНО ЗАВЪРШИ ЮБИЛЕЙНОТО ИЗДАНИЕ НА ТУРНИРА „ЗАШО“", 353 },
                    { 2, "Един от най-мащабните тенис турнири за аматьори и любители в България - VSSport Open се завръща. Надпреварата ще се проведе за четвърта поредна година на кортовете на ТК \"Ника\" в бургаския квартал Сарафово. Най-добрите аматьорски състезатели в България и любители от цялата страна ще се включат в битката за титлите в двата формата. Тази година мероприятието ще се проведе между 10 и 12 май, като участниците ще бъдат разделени в два формата. В силния формат, организаторите отново очакват най-добрите аматьори в страната да се включат в битката и да се опитат да прекъснат хегемонията на трикратния победител Иван Притъргов. Двубоите ще започнат в петък, 10 май със срещи от груповата фаза при любителите. В събота започва битката в силния формат. \r\n\r\nОрганизаторите, които тази година си партнират с Община Бургас, в опит да направят турнира още по-добър обещават много изненади за участници и гости на турнира. След като през годините в турнира взеха участие интересни имена като Красимир Балъков, Георги Чиликов, Георги Сърмов, Крум Савов и др. се очаква и тази година в битката да се включат любопитни гости от цялата страна, както и няколко участници от други страни. \r\n\r\nСъстезателите ще бъдат разпределени в групи от по 4 състезатели, като най-добрите ще продължат в елиминационната фаза. \"Очаквам и тази година да оправдаем очакванията на участниците. Постарали сме се да осигурим прекрасни условия за всички и се надявам турнирът отново да се превърне в истински празник на тениса, но и на цял спортен Бургас. Интересът е огромен, като въпреки че не сме открили записването, вече има запитвания от много състезатели. Лично аз се надявам да продължим възходящата тенденция и турнирът да става все по-силен\", коментира един от организаторите Станко Минев.\r\n\r\nПрез следващите дни организаторите ще разкрият още подробности за турнира.", new DateTime(2024, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "https://vssportbg.com/image/cache/catalog/AA/bala-1200x628h.PNG.webp", "VSSport Open се завръща за четвърта поредна година", 1053 },
                    { 3, "По време на турнира, който продължи събота (24.09) и неделя (25.09), фирма Лидер предостави 7 броя от най-продаваните модели електрически велосипеди за Test Ride. Всеки от присъстващите (при желание) можеше да се възползва безплатно да покара висок клас велосипед след инструктаж от представител на фирма Лидер 96.\r\nБеше предвиден кетъринг от организаторите за двата дни за всички участници, като бяха предоставени и млечни продукти от Мандра Маноле.\r\n\r\nТопките за мачовете по време на турнира бяха осигурени от организаторите – тази година се заложи на топки Wilson Tour Premier All Court.\r\n\r\nСъбитието се проведе за 11-та поредна година – някои от участниците вече са редовни. Прогнозата за времето зарадва всички с много слънчеви лъчи.\r\n\r\n \r\n\r\nПобедители на игри сингъл мъже:\r\n\r\nТази година две от наградите за Сингъл Мъже пътуват към морето:\r\n\r\nПърво място Сингъл Мъже – Иван Притъргов от Бургас (редовен участник в турнира от 7 години)\r\n\r\nВторо място Сингъл Мъже – Християн Маноилов от Пазарджик\r\n\r\nТрето място Сингъл Мъже – Росен Марков от Бургас\r\n\r\nЧетвърто място сингъл – Димитър Авджиев (Стара Загора)\r\n\r\n \r\n\r\nПобедителите на игри двойки мъже:\r\n\r\nПърво място Двойки Мъже – Митко Костадинов и Васил Чушев (Казанлък)\r\n\r\nВторо място Двойки Мъже – Николай Мирчев и Михаил Мирчев (Пловдив)\r\n\r\n \r\n\r\nИван Притъргов, който спечели първо място на Сингъл Мъже тази година, е редовен участник в турнира от 7 години насам. През изминалата година на Leader Open 2021 Радослав Владимиров от София надигра Иван на финал Сингъл Мъже и стана първи – тази година двамата се срещнаха още на ¼ Финали и Иван продължи напред до първото място. Може би и жребият оказа влияние, защото Владимиров в събота имаше един от последните мачове за деня и не беше добре отпочинал.\r\n\r\nМачът за 3-то място беше доста оспорван – играха Росен Марков от Бургас и Димитър Авджиев от Стара Загора. Авджиев беше финалист 3-то място Сингъл Мъже на турнира миналата година. Тази година не му достигнаха силите за класиране в челната тройка, тъй като срещите в събота на 1/8 Финал продължиха до 23:00ч. на лампи – умората оказа влияние. Марков се наложи над Авджиев и се класира 3-то място Сингъл Мъже.\r\n\r\nТримата финалисти на Сингъл Мъже се сдобиха с чисто нови електро велосипеди от Лидер 96 ЕООД и парични награди от Университетска Болница „Пълмед“.\r\n\r\n\r\n\r\nОбщ брой записани участници за Сингъл Мъже – 67 участника / жребий в групи – 13 групи*4 и 3 групи*5 /\r\n\r\n\r\n\r\n\r\n\r\nМачът от финалния кръг двойки мъже беше между братя Мирчеви от Пловдив и двойката от Казанлък – Митко Костадинов и Васил Чушев. Беше оспорвана игра и докрая не беше ясно кой ще вземе първото място на двойки. Финалистите спечелиха фирмени колела Лидер (по 2 електрически велосипеда за двойка) и парични награди от Университетска Болница „Пълмед“.\r\n\r\n\r\n\r\nОбщ брой записани за Двойки Мъже – 22 двойки /от които 1 двойка беше дисквалифицирана/", new DateTime(2023, 9, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "https://tennis.leader96.com/wp-content/uploads/elementor/thumbs/IMG_20220925_161056-pvfh8bwcb23r7ekjwk5lkhjdly66l5emh6wqpj7lkw.jpg", "LEADER Open 2023 се проведе в Пловдив", 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Backhand", "BirthDate", "DominantHand", "FirstName", "Gender", "ImageUrl", "LastName", "Losses", "PhoneNumber", "PlayingStyle", "TennisRacket", "TournamentWins", "UserId", "Wins" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1989, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Samuel", 0, "https://division.albatros-tennis.com/products/202.jpg", "Lazarov", 3, "0898836929", 2, 0, 0, "dea12856-c198-4129-b3f3-b893d83950p1", 10 },
                    { 2, 1, new DateTime(1992, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sarkis", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Haralampiev", 2, "0888121314", 2, 1, 0, "dea12856-c198-4129-b3f3-b893d83950p2", 12 },
                    { 3, 1, new DateTime(1984, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ivan", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Pritargov", 6, "0884989898", 0, 3, 6, "f98e572e-f64b-40f5-a37f-783d2d1ff0p3", 75 },
                    { 4, 1, new DateTime(1988, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Daniil", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Kurian", 10, "0888777666", 1, 0, 1, "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4", 28 },
                    { 5, 0, new DateTime(1990, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Rado", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Vladimirov", 3, "0888777666", 2, 2, 4, "adb4186a-f51d-4969-aa0f-938a524128p5", 69 },
                    { 6, 1, new DateTime(2006, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Dimitar", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Berdankov", 5, "0877111333", 0, 0, 0, "4319f732-1f7d-44e3-8b4b-7d698f7c44p6", 14 },
                    { 7, 0, new DateTime(1974, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Dimitar", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Randev", 43, "0888777666", 1, 2, 2, "9b9265e6-61b2-4b6f-af23-1e1af744b1p7", 75 },
                    { 8, 1, new DateTime(1992, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Rosen", 0, "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg", "Markov", 13, "0892555333", 0, 3, 0, "c45b149d-4c95-4742-b848-739af7b0bfp8", 22 }
                });

            migrationBuilder.InsertData(
                table: "TournamentHost",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "0888111222", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Description", "EndDate", "Fee", "HostClubId", "Name", "StartDate", "TournamentBalls", "TournamentHostId" },
                values: new object[] { 1, "През 2024г. в памет на Захари Джевизов - Зашо отново се организира ежегоден тенис турнир за аматьори, любители и ветерани спрели участие преди 2000г. и не получаващи пари чрез тенис. Начало в 09.00 ч. на 27/04/2024г. до 28/04/2024г. на тенис кортове ”Стад”- Пловдив.", new DateTime(2024, 4, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), 30.00m, 2, "Тенис турнир \"ЗАШО\" 2024", new DateTime(2024, 4, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Description", "EndDate", "Fee", "HostClubId", "Name", "StartDate", "TournamentBalls", "TournamentHostId" },
                values: new object[] { 2, "Един от най-мащабните тенис турнири за аматьори и любители в България - VSSport Open се завръща. Надпреварата ще се проведе за четвърта поредна година на кортовете на ТК \"Ника\" в бургаския квартал Сарафово. Най-добрите аматьорски състезатели в България и любители от цялата страна ще се включат в битката за титлите в двата формата. Тази година мероприятието ще се проведе между 12 и 14 май, като участниците ще бъдат разделени в два формата. ", new DateTime(2024, 5, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, 1, "Тенис турнир \"VS-Sport\" 2024", new DateTime(2024, 5, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Description", "EndDate", "Fee", "HostClubId", "Name", "StartDate", "TournamentBalls", "TournamentHostId" },
                values: new object[] { 3, "Имаме удоволствието да ви поканим на ежегодния тенис турнир за любители Leader Open 2024. Събитието ще се проведе в рамките на два дни – 21 и 22 Септември на кортовете на Тенис Клуб „Авеню“ гр. Бургас. Турнирът включва два вида игри: мъже сингъл и мъже двойки. Записването за двойки ще бъде в събота, 21 Септември през деня на място или по телефона до 16:00ч. Крайна дата за регистрация и плащане за турнира е 17 Септември. Ако имате въпроси свързани с турнира, моля пишете ни на office@leader96.com ", new DateTime(2024, 9, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 40.00m, 3, "Тенис турнир \"Leader Open\" 2024", new DateTime(2024, 9, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "MatchRound", "PlayerOneId", "PlayerOneSetsWon", "PlayerTwoId", "PlayerTwoSetsWon", "TournamentId", "Winner" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 2, 2, 1, 1 },
                    { 2, 6, 3, 2, 4, 0, 2, 0 },
                    { 3, 4, 5, 0, 6, 2, 3, 1 },
                    { 4, 4, 7, 1, 8, 2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "HasTiebreak", "MatchId", "PlayerOneGamesWon", "PlayerTwoGamesWon", "TiebreakId" },
                values: new object[,]
                {
                    { 1, false, 1, 6, 4, null },
                    { 2, false, 1, 5, 7, null },
                    { 3, true, 1, 6, 7, 1 },
                    { 4, false, 2, 6, 3, null },
                    { 5, false, 2, 6, 4, null },
                    { 6, false, 3, 1, 6, null },
                    { 7, false, 3, 5, 7, null },
                    { 8, true, 4, 7, 6, 2 },
                    { 9, false, 4, 1, 6, null },
                    { 10, true, 4, 7, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tiebreaks",
                columns: new[] { "Id", "PlayerOnePoints", "PlayerTwoPoints", "SetId" },
                values: new object[] { 1, 6, 8, 3 });

            migrationBuilder.InsertData(
                table: "Tiebreaks",
                columns: new[] { "Id", "PlayerOnePoints", "PlayerTwoPoints", "SetId" },
                values: new object[] { 2, 7, 5, 8 });

            migrationBuilder.InsertData(
                table: "Tiebreaks",
                columns: new[] { "Id", "PlayerOnePoints", "PlayerTwoPoints", "SetId" },
                values: new object[] { 3, 7, 2, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentHostId",
                table: "Tournaments",
                column: "TournamentHostId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiebreaks_SetId",
                table: "Tiebreaks",
                column: "SetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_UserId",
                table: "ArticleComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersMatches_Matches_MatchId",
                table: "PlayersMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersMatches_Players_PlayerId",
                table: "PlayersMatches",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTournaments_Players_PlayerId",
                table: "PlayersTournaments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTournaments_Tournaments_TournamentId",
                table: "PlayersTournaments",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiebreaks_Sets_SetId",
                table: "Tiebreaks",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Matches_MatchId",
                table: "TournamentMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Tournaments_TournamentId",
                table: "TournamentMatches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentHost_TournamentHostId",
                table: "Tournaments",
                column: "TournamentHostId",
                principalTable: "TournamentHost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_PlayersMatches_Matches_MatchId",
                table: "PlayersMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersMatches_Players_PlayerId",
                table: "PlayersMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTournaments_Players_PlayerId",
                table: "PlayersTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersTournaments_Tournaments_TournamentId",
                table: "PlayersTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiebreaks_Sets_SetId",
                table: "Tiebreaks");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Matches_MatchId",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentMatches_Tournaments_TournamentId",
                table: "TournamentMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentHost_TournamentHostId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TournamentHostId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tiebreaks_SetId",
                table: "Tiebreaks");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tiebreaks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tiebreaks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tiebreaks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4319f732-1f7d-44e3-8b4b-7d698f7c44p6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adb4186a-f51d-4969-aa0f-938a524128p5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f98e572e-f64b-40f5-a37f-783d2d1ff0p3");

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b9265e6-61b2-4b6f-af23-1e1af744b1p7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c45b149d-4c95-4742-b848-739af7b0bfp8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d83950p2");

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TournamentHost",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "TournamentHost",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Tournament host's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Tournament host's phone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Players",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Player's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Player's phone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Club",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Club's phone",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Club's phone");

            migrationBuilder.CreateIndex(
                name: "IX_Tiebreaks_SetId",
                table: "Tiebreaks",
                column: "SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_TiebreakId",
                table: "Sets",
                column: "TiebreakId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersMatches_Matches_MatchId",
                table: "PlayersMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersMatches_Players_PlayerId",
                table: "PlayersMatches",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTournaments_Players_PlayerId",
                table: "PlayersTournaments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersTournaments_Tournaments_TournamentId",
                table: "PlayersTournaments",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Tiebreaks_TiebreakId",
                table: "Sets",
                column: "TiebreakId",
                principalTable: "Tiebreaks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiebreaks_Sets_SetId",
                table: "Tiebreaks",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Matches_MatchId",
                table: "TournamentMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentMatches_Tournaments_TournamentId",
                table: "TournamentMatches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentHost_HostClubId",
                table: "Tournaments",
                column: "HostClubId",
                principalTable: "TournamentHost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
