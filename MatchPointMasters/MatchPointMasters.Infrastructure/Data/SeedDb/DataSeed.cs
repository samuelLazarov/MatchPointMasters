
namespace MatchPointMasters.Infrastructure.Data.SeedDb
{
    using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Article;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;
    using Microsoft.AspNetCore.Identity;
    using System.Globalization;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.PlayerConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.TournamentConstants;


    internal class DataSeed
    {

        //Constructor
        public DataSeed()
        {
            SeedUsers();
            SeedClubs();
            SeedTournaments();
            SeedTournamentHosts();
            SeedPlayers();
            SeedMatches();
            SeedArticles();
        }

        //Users
        public IdentityUser HostUser { get; set; } = null!;
        public IdentityUser Player1User { get; set; } = null!;
        public IdentityUser Player2User { get; set; } = null!;
        public IdentityUser Player3User { get; set; } = null!;
        public IdentityUser Player4User { get; set; } = null!;
        public IdentityUser Player5User { get; set; } = null!;
        public IdentityUser Player6User { get; set; } = null!;
        public IdentityUser Player7User { get; set; } = null!;
        public IdentityUser Player8User { get; set; } = null!;

        //Tennis clubs
        public Club TkNikaSarafovo { get; set; } = null!;
        public Club TkLokoPlovdiv { get; set; } = null!;
        public Club TkAvenue { get; set; } = null!;
        public Club TkVelto { get; set; } = null!;

        //Tennis tournaments
        public Tournament ZashoOpen { get; set; } = null!;
        public Tournament VSSportOpen { get; set; } = null!;
        public Tournament LeaderOpen { get; set; } = null!;

        //Tournament host
        public TournamentHost TournamentHost { get; set; } = null!;

        //Tennis players
        public Player Player1 { get; set; } = null!;
        public Player Player2 { get; set; } = null!;
        public Player Player3 { get; set; } = null!;
        public Player Player4 { get; set; } = null!;
        public Player Player5 { get; set; } = null!;
        public Player Player6 { get; set; } = null!;
        public Player Player7 { get; set; } = null!;
        public Player Player8 { get; set; } = null!;

        //Tennis matches
        public Match MatchP1P2 { get; set; } = null!;
        public Match MatchP3P4 { get; set; } = null!;
        public Match MatchP5P6 { get; set; } = null!;
        public Match MatchP7P8 { get; set; } = null!;


        //Articles
        public Article ArticleZashoOpen2024 { get; set; } = null!;
        public Article ArticleVSSportOpen2024 { get; set; } = null!;
        public Article ArticleLeaderOpen2024 { get; set; } = null!;


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            HostUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "Ivan_Pandeliev",
                NormalizedUserName = "ivan_pandeliev",
                Email = "hostuser@gmail.com",
                NormalizedEmail = "hostuser@gmail.com"
            };

            HostUser.PasswordHash = hasher.HashPassword(HostUser, "hostpass");

            Player1User = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d83950p1",
                UserName = "Samuel_Lazarov",
                NormalizedUserName = "samuel_lazarov",
                Email = "player1@gmail.com",
                NormalizedEmail = "player1@gmail.com"
            };

            Player1User.PasswordHash = hasher.HashPassword(Player1User, "player1pass");

            Player2User = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d83950p2",
                UserName = "Sarkis_Haralampiev",
                NormalizedUserName = "sarkis_haralampiev",
                Email = "player2@gmail.com",
                NormalizedEmail = "player2@gmail.com"
            };

            Player2User.PasswordHash = hasher.HashPassword(Player2User, "player2pass");

            Player3User = new IdentityUser()
            {
                Id = "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                UserName = "Ivan_Pritargov",
                NormalizedUserName = "ivan_pritargov",
                Email = "player3@gmail.com",
                NormalizedEmail = "player3@gmail.com"
            };

            Player3User.PasswordHash = hasher.HashPassword(Player3User, "player3pass");

            Player4User = new IdentityUser()
            {
                Id = "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                UserName = "Daniil_Kurian",
                NormalizedUserName = "daniil_kurian",
                Email = "player4@gmail.com",
                NormalizedEmail = "player4@gmail.com"
            };

            Player4User.PasswordHash = hasher.HashPassword(Player4User, "player4pass");

            Player5User = new IdentityUser()
            {
                Id = "adb4186a-f51d-4969-aa0f-938a524128p5",
                UserName = "Rado_Vladimirov",
                NormalizedUserName = "rado_vladimirov",
                Email = "player5@gmail.com",
                NormalizedEmail = "player5@gmail.com"
            };

            Player5User.PasswordHash = hasher.HashPassword(Player5User, "player5pass");

            Player6User = new IdentityUser()
            {
                Id = "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                UserName = "Dimitar_Berdankov",
                NormalizedUserName = "dimitar_berdankov",
                Email = "player6@gmail.com",
                NormalizedEmail = "player6@gmail.com"
            };

            Player6User.PasswordHash = hasher.HashPassword(Player6User, "player6pass");

            Player7User = new IdentityUser()
            {
                Id = "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                UserName = "Dimitar_Randev",
                NormalizedUserName = "dimitar_randev",
                Email = "player7@gmail.com",
                NormalizedEmail = "player7@gmail.com"
            };

            Player7User.PasswordHash = hasher.HashPassword(Player7User, "player7pass");

            Player8User = new IdentityUser()
            {
                Id = "c45b149d-4c95-4742-b848-739af7b0bfp8",
                UserName = "Rosen_Markov",
                NormalizedUserName = "rosen_markov",
                Email = "player8@gmail.com",
                NormalizedEmail = "player8@gmail.com"
            };

            Player8User.PasswordHash = hasher.HashPassword(Player8User, "player8pass");

        }

        private void SeedClubs()
        {
            TkNikaSarafovo = new Club()
            {
                Id = 1,
                Name = "Тенис клуб \"Ника\" - Бургас",
                Address = "гр. Бургас, ул. \"Ремсова\" 9",
                PhoneNumber = "087 957 8998",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRrwrXYCDoRqOa8d0Gbp0sXwcdsnEaP7UMMLRLbktc5sw&s",
                CourtSurface = CourtSurface.Clay
            };


            TkLokoPlovdiv = new Club()
            {
                Id = 2,
                Name = "Тенис клуб \"Локомотив\" - Пловдив",
                Address = "гр. Пловдив, ул. „Ясна поляна“ 4 ( Стадион Пловдив )",
                PhoneNumber = "0887 500 577",
                ImageUrl = "https://clickandplay.bg/f/clubs/o/0/c9d5f8339205cc200c539915e90abc06.jpeg",
                CourtSurface = CourtSurface.Clay,
            };

            TkAvenue = new Club()
            {
                Id = 3,
                Name = "Тенис клуб \"Авеню\" - Бургас",
                Address = "гр. Бургас, главен път Бургас-Сарафово зад Аутлет \"Пума\"",
                PhoneNumber = "+359 88 714 1111",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMNT5XsqUtV2SbtWba-CRF3FdCytyOy7Nc6xDd-WZNBA&s",
                CourtSurface = CourtSurface.Hard,
            };

            TkVelto = new Club()
            {
                Id = 4,
                Name = "Тенис клуб \"Велто\" - Варна",
                Address = "гр. Варна, м.\"Салтанат\", Приморски парк",
                PhoneNumber = "052 711 457",
                ImageUrl = "https://tennis.bg/uploaded/courts/26/25e4c446e9e415930c4b3b094efffcf5.jpg",
                CourtSurface = CourtSurface.Grass,
            };
        }

        private void SeedTournaments()
        {
            ZashoOpen = new Tournament()
            {
                Id = 1,
                Name = "Тенис турнир \"ЗАШО\" 2024",
                Description = "През 2024г. в памет на Захари Джевизов - Зашо отново се организира ежегоден тенис турнир за аматьори, любители и ветерани спрели участие преди 2000г. и не получаващи пари чрез тенис. Начало в 09.00 ч. на 27/04/2024г. до 28/04/2024г. на тенис кортове ”Стад”- Пловдив.",
                StartDate = DateTime.ParseExact("27/04/2024 09:00", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("28/04/2024 18:00", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                HostClubId = 2,
                TournamentHostId = 1,
                Fee = 30.00m,
                TournamentBalls = TennisBalls.HeadTourXT
            };

            VSSportOpen = new Tournament()
            {
                Id = 2,
                Name = "Тенис турнир \"VS-Sport\" 2024",
                Description = "Един от най-мащабните тенис турнири за аматьори и любители в България - VSSport Open се завръща. Надпреварата ще се проведе за четвърта поредна година на кортовете на ТК \"Ника\" в бургаския квартал Сарафово. Най-добрите аматьорски състезатели в България и любители от цялата страна ще се включат в битката за титлите в двата формата. Тази година мероприятието ще се проведе между 12 и 14 май, като участниците ще бъдат разделени в два формата. ",
                StartDate = DateTime.ParseExact("12/05/2024 08:30", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("14/05/2024 20:00", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                HostClubId = 1,
                TournamentHostId = 1,
                Fee = 50.00m,
                TournamentBalls = TennisBalls.WilsonTourPremier
            };

            LeaderOpen = new Tournament()
            {
                Id = 3,
                Name = "Тенис турнир \"Leader Open\" 2024",
                Description = "Имаме удоволствието да ви поканим на ежегодния тенис турнир за любители Leader Open 2024. Събитието ще се проведе в рамките на два дни – 21 и 22 Септември на кортовете на Тенис Клуб „Авеню“ гр. Бургас. Турнирът включва два вида игри: мъже сингъл и мъже двойки. Записването за двойки ще бъде в събота, 21 Септември през деня на място или по телефона до 16:00ч. Крайна дата за регистрация и плащане за турнира е 17 Септември. Ако имате въпроси свързани с турнира, моля пишете ни на office@leader96.com ",
                StartDate = DateTime.ParseExact("21/09/2024 09:00", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                EndDate = DateTime.ParseExact("22/09/2024 20:00", DateTimeTournamentFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                HostClubId = 3,
                TournamentHostId = 1,
                Fee = 40.00m,
                TournamentBalls = TennisBalls.DunlopFortAllCourt
            };

        }

        private void SeedTournamentHosts()
        {
            TournamentHost = new TournamentHost()
            {
                Id = 1,
                PhoneNumber = "0888111222",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };
        }

        private void SeedPlayers()
        {
            Player1 = new Player()
            {
                Id = 1,
                FirstName = "Samuel",
                LastName = "Lazarov",
                PhoneNumber = "0898836929",
                UserId = "dea12856-c198-4129-b3f3-b893d83950p1",
                BirthDate = DateTime.ParseExact("29/08/1989", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.OneHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Combined,
                TennisRacket = Enums.Player.TennisRacket.Wilson,
                Wins = 10,
                Losses = 3,
                TournamentWins = 0,
                ImageUrl = "https://division.albatros-tennis.com/products/202.jpg"

            };

            Player2 = new Player()
            {
                Id = 2,
                FirstName = "Sarkis",
                LastName = "Haralampiev",
                PhoneNumber = "0888121314",
                UserId = "dea12856-c198-4129-b3f3-b893d83950p2",
                BirthDate = DateTime.ParseExact("24/10/1992", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.TwoHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Combined,
                TennisRacket = Enums.Player.TennisRacket.Babolat,
                Wins = 12,
                Losses = 2,
                TournamentWins = 0,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player3 = new Player()
            {
                Id = 3,
                FirstName = "Ivan",
                LastName = "Pritargov",
                PhoneNumber = "0884989898",
                UserId = "f98e572e-f64b-40f5-a37f-783d2d1ff0p3",
                BirthDate = DateTime.ParseExact("24/10/1984", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.TwoHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Aggressive,
                TennisRacket = Enums.Player.TennisRacket.Yonex,
                Wins = 75,
                Losses = 6,
                TournamentWins = 6,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player4 = new Player()
            {
                Id = 4,
                FirstName = "Daniil",
                LastName = "Kurian",
                PhoneNumber = "0888777666",
                UserId = "4a08e50c-9f8d-4ac7-bbc1-05a7f0f146p4",
                BirthDate = DateTime.ParseExact("13/10/1988", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.TwoHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Defensive,
                TennisRacket = Enums.Player.TennisRacket.Wilson,
                Wins = 28,
                Losses = 10,
                TournamentWins = 1,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player5 = new Player()
            {
                Id = 5,
                FirstName = "Rado",
                LastName = "Vladimirov",
                PhoneNumber = "0888777666",
                UserId = "adb4186a-f51d-4969-aa0f-938a524128p5",
                BirthDate = DateTime.ParseExact("18/05/1990", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.OneHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Combined,
                TennisRacket = Enums.Player.TennisRacket.Head,
                Wins = 69,
                Losses = 3,
                TournamentWins = 4,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player6 = new Player()
            {
                Id = 6,
                FirstName = "Dimitar",
                LastName = "Berdankov",
                PhoneNumber = "0877111333",
                UserId = "4319f732-1f7d-44e3-8b4b-7d698f7c44p6",
                BirthDate = DateTime.ParseExact("27/02/2006", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.TwoHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Aggressive,
                TennisRacket = Enums.Player.TennisRacket.Wilson,
                Wins = 14,
                Losses = 5,
                TournamentWins = 0,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player7 = new Player()
            {
                Id = 7,
                FirstName = "Dimitar",
                LastName = "Randev",
                PhoneNumber = "0888777666",
                UserId = "9b9265e6-61b2-4b6f-af23-1e1af744b1p7",
                BirthDate = DateTime.ParseExact("14/11/1974", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Right,
                Backhand = Enums.Player.Backhand.OneHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Defensive,
                TennisRacket = Enums.Player.TennisRacket.Head,
                Wins = 75,
                Losses = 43,
                TournamentWins = 2,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };

            Player8 = new Player()
            {
                Id = 8,
                FirstName = "Rosen",
                LastName = "Markov",
                PhoneNumber = "0892555333",
                UserId = "c45b149d-4c95-4742-b848-739af7b0bfp8",
                BirthDate = DateTime.ParseExact("25/07/1992", DateTimeBirthdayFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                Gender = Enums.Player.Gender.Male,
                DominantHand = Enums.Player.DominantHand.Left,
                Backhand = Enums.Player.Backhand.TwoHanded,
                PlayingStyle = Enums.Player.PlayingStyle.Aggressive,
                TennisRacket = Enums.Player.TennisRacket.Yonex,
                Wins = 22,
                Losses = 13,
                TournamentWins = 0,
                ImageUrl = "https://static.vecteezy.com/system/resources/previews/009/292/244/non_2x/default-avatar-icon-of-social-media-user-vector.jpg"

            };
        }

        private void SeedMatches()
        {
            MatchP1P2 = new Match()
            {
                Id = 1,
                TournamentId = 1,
                MatchRound = Enums.Match.MatchRound.Semifinals,
                PlayerOneId = 1,
                PlayerTwoId = 2,
                PlayerOneSetsWon = 1,
                PlayerTwoSetsWon = 2,
                Winner = Enums.Match.Winner.PlayerTwo,
                Sets = new List<Set>()
                {
                    new Set()
                    {
                        Id = 1,
                        PlayerOneGamesWon = 6,
                        PlayerTwoGamesWon = 4,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 1
                    },

                    new Set()
                    {
                        Id = 2,
                        PlayerOneGamesWon = 5,
                        PlayerTwoGamesWon = 7,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 1
                    },

                    new Set()
                    {
                        Id = 3,
                        PlayerOneGamesWon = 6,
                        PlayerTwoGamesWon = 7,
                        HasTiebreak = true,
                        TiebreakId = 1,
                        Tiebreak = new Tiebreak()
                        {
                            Id= 1,
                            PlayerOnePoints = 6,
                            PlayerTwoPoints = 8,
                            SetId = 3
                        },
                        MatchId = 1
                    }
                }
            };

            MatchP3P4 = new Match()
            {
                Id = 2,
                TournamentId = 2,
                MatchRound = Enums.Match.MatchRound.Final,
                PlayerOneId = 3,
                PlayerTwoId = 4,
                PlayerOneSetsWon = 2,
                PlayerTwoSetsWon = 0,
                Winner = Enums.Match.Winner.PlayerOne,
                Sets = new List<Set>()
                {
                    new Set()
                    {
                        Id = 4,
                        PlayerOneGamesWon = 6,
                        PlayerTwoGamesWon = 3,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 2
                    },

                    new Set()
                    {
                        Id = 5,
                        PlayerOneGamesWon = 6,
                        PlayerTwoGamesWon = 4,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 2
                    }
                }
            };

            MatchP5P6 = new Match()
            {
                Id = 3,
                TournamentId = 3,
                MatchRound = Enums.Match.MatchRound.Quarterfinals,
                PlayerOneId = 5,
                PlayerTwoId = 6,
                PlayerOneSetsWon = 0,
                PlayerTwoSetsWon = 2,
                Winner = Enums.Match.Winner.PlayerTwo,
                Sets = new List<Set>()
                {
                    new Set()
                    {
                        Id = 6,
                        PlayerOneGamesWon = 1,
                        PlayerTwoGamesWon = 6,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 3
                    },

                    new Set()
                    {
                        Id = 7,
                        PlayerOneGamesWon = 5,
                        PlayerTwoGamesWon = 7,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 3
                    }
                }
            };

            MatchP7P8 = new Match()
            {
                Id = 4,
                TournamentId = 3,
                MatchRound = Enums.Match.MatchRound.Quarterfinals,
                PlayerOneId = 7,
                PlayerTwoId = 8,
                PlayerOneSetsWon = 1,
                PlayerTwoSetsWon = 2,
                Winner = Enums.Match.Winner.PlayerTwo,
                Sets = new List<Set>()
                {
                    new Set()
                    {
                        Id = 8,
                        PlayerOneGamesWon = 7,
                        PlayerTwoGamesWon = 6,
                        HasTiebreak = true,
                        TiebreakId = 2,
                        Tiebreak = new Tiebreak()
                        {
                            Id= 2,
                            PlayerOnePoints = 7,
                            PlayerTwoPoints = 5,
                            SetId = 8
                        },
                        MatchId = 4
                    },

                    new Set()
                    {
                        Id = 9,
                        PlayerOneGamesWon = 1,
                        PlayerTwoGamesWon = 6,
                        HasTiebreak = false,
                        TiebreakId = null,
                        Tiebreak = null,
                        MatchId = 4
                    },

                    new Set()
                    {
                        Id = 10,
                        PlayerOneGamesWon = 7,
                        PlayerTwoGamesWon = 6,
                        HasTiebreak = true,
                        TiebreakId = 3,
                        Tiebreak = new Tiebreak()
                        {
                            Id= 3,
                            PlayerOnePoints = 7,
                            PlayerTwoPoints = 2,
                            SetId = 10
                        },
                        MatchId = 4
                    }
                }
            };
        }

        //private void SeedMatches()
        //{
        //    MatchP1P2 = new Match()
        //    {
        //        Id = 1,
        //        TournamentId = 1,
        //        MatchRound = Enums.Match.MatchRound.Semifinals,
        //        PlayerOneId = 1,
        //        PlayerTwoId = 2,
        //        PlayerOneSetsWon = 1,
        //        PlayerTwoSetsWon = 2,
        //        Winner = Enums.Match.Winner.PlayerTwo
        //    };

        //    modelBuilder.Entity<Match>().HasData(MatchP1P2);

        //    var set1 = new Set()
        //    {
        //        Id = 1,
        //        PlayerOneGamesWon = 6,
        //        PlayerTwoGamesWon = 4,
        //        HasTiebreak = false,
        //        TiebreakId = null,
        //        Tiebreak = null,
        //        MatchId = 1
        //    };

        //    var set2 = new Set()
        //    {
        //        Id = 2,
        //        PlayerOneGamesWon = 5,
        //        PlayerTwoGamesWon = 7,
        //        HasTiebreak = false,
        //        TiebreakId = null,
        //        Tiebreak = null,
        //        MatchId = 1
        //    };

        //    modelBuilder.Entity<Set>().HasData(set1, set2);
        //}


        private void SeedArticles()
        {
            ArticleZashoOpen2024 = new Article()
            {
                Id = 1,
                HostUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Title = "УСПЕШНО ЗАВЪРШИ ЮБИЛЕЙНОТО ИЗДАНИЕ НА ТУРНИРА „ЗАШО“",
                Content = "Между 29 април и 1 май на кортовете „Стад“ в Пловдив се проведе 20-ото юбилейно издание на турнира за аматьори и ветерани \"Зашо\". В надпреварата се включиха 120 мъже и 10 жени, като шампиони станаха Дани Куриян и Ели Андонова, след като победиха във финалите Тодор Митев и Стефка Бончева.\r\n\r\nВ мъжките двойки трофеят спечелиха Андрей Андреев и Иван Андреев.\r\n\r\nТурнирът се проведе на високо ниво, като дори краткият дъжд на Деня на труда не попречи на благополучното завършване.",
                ImageUrl = "https://www.tenniskafe.com/wp-content/uploads/2023/05/Zasho-muje-1200x630.jpg",
                DatePublished = DateTime.ParseExact("14/03/2023 10:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 353
            };

            ArticleVSSportOpen2024 = new Article()
            {
                Id = 2,
                HostUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Title = "VSSport Open се завръща за четвърта поредна година",
                Content = "Един от най-мащабните тенис турнири за аматьори и любители в България - VSSport Open се завръща. Надпреварата ще се проведе за четвърта поредна година на кортовете на ТК \"Ника\" в бургаския квартал Сарафово. Най-добрите аматьорски състезатели в България и любители от цялата страна ще се включат в битката за титлите в двата формата. Тази година мероприятието ще се проведе между 10 и 12 май, като участниците ще бъдат разделени в два формата. В силния формат, организаторите отново очакват най-добрите аматьори в страната да се включат в битката и да се опитат да прекъснат хегемонията на трикратния победител Иван Притъргов. Двубоите ще започнат в петък, 10 май със срещи от груповата фаза при любителите. В събота започва битката в силния формат. \r\n\r\nОрганизаторите, които тази година си партнират с Община Бургас, в опит да направят турнира още по-добър обещават много изненади за участници и гости на турнира. След като през годините в турнира взеха участие интересни имена като Красимир Балъков, Георги Чиликов, Георги Сърмов, Крум Савов и др. се очаква и тази година в битката да се включат любопитни гости от цялата страна, както и няколко участници от други страни. \r\n\r\nСъстезателите ще бъдат разпределени в групи от по 4 състезатели, като най-добрите ще продължат в елиминационната фаза. \"Очаквам и тази година да оправдаем очакванията на участниците. Постарали сме се да осигурим прекрасни условия за всички и се надявам турнирът отново да се превърне в истински празник на тениса, но и на цял спортен Бургас. Интересът е огромен, като въпреки че не сме открили записването, вече има запитвания от много състезатели. Лично аз се надявам да продължим възходящата тенденция и турнирът да става все по-силен\", коментира един от организаторите Станко Минев.\r\n\r\nПрез следващите дни организаторите ще разкрият още подробности за турнира.",
                ImageUrl = "https://vssportbg.com/image/cache/catalog/AA/bala-1200x628h.PNG.webp",
                DatePublished = DateTime.ParseExact("22/03/2024 14:00", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 1053
            };

            ArticleLeaderOpen2024 = new Article()
            {
                Id = 3,
                HostUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Title = "LEADER Open 2023 се проведе в Пловдив",
                Content = "По време на турнира, който продължи събота (24.09) и неделя (25.09), фирма Лидер предостави 7 броя от най-продаваните модели електрически велосипеди за Test Ride. Всеки от присъстващите (при желание) можеше да се възползва безплатно да покара висок клас велосипед след инструктаж от представител на фирма Лидер 96.\r\nБеше предвиден кетъринг от организаторите за двата дни за всички участници, като бяха предоставени и млечни продукти от Мандра Маноле.\r\n\r\nТопките за мачовете по време на турнира бяха осигурени от организаторите – тази година се заложи на топки Wilson Tour Premier All Court.\r\n\r\nСъбитието се проведе за 11-та поредна година – някои от участниците вече са редовни. Прогнозата за времето зарадва всички с много слънчеви лъчи.\r\n\r\n \r\n\r\nПобедители на игри сингъл мъже:\r\n\r\nТази година две от наградите за Сингъл Мъже пътуват към морето:\r\n\r\nПърво място Сингъл Мъже – Иван Притъргов от Бургас (редовен участник в турнира от 7 години)\r\n\r\nВторо място Сингъл Мъже – Християн Маноилов от Пазарджик\r\n\r\nТрето място Сингъл Мъже – Росен Марков от Бургас\r\n\r\nЧетвърто място сингъл – Димитър Авджиев (Стара Загора)\r\n\r\n \r\n\r\nПобедителите на игри двойки мъже:\r\n\r\nПърво място Двойки Мъже – Митко Костадинов и Васил Чушев (Казанлък)\r\n\r\nВторо място Двойки Мъже – Николай Мирчев и Михаил Мирчев (Пловдив)\r\n\r\n \r\n\r\nИван Притъргов, който спечели първо място на Сингъл Мъже тази година, е редовен участник в турнира от 7 години насам. През изминалата година на Leader Open 2021 Радослав Владимиров от София надигра Иван на финал Сингъл Мъже и стана първи – тази година двамата се срещнаха още на ¼ Финали и Иван продължи напред до първото място. Може би и жребият оказа влияние, защото Владимиров в събота имаше един от последните мачове за деня и не беше добре отпочинал.\r\n\r\nМачът за 3-то място беше доста оспорван – играха Росен Марков от Бургас и Димитър Авджиев от Стара Загора. Авджиев беше финалист 3-то място Сингъл Мъже на турнира миналата година. Тази година не му достигнаха силите за класиране в челната тройка, тъй като срещите в събота на 1/8 Финал продължиха до 23:00ч. на лампи – умората оказа влияние. Марков се наложи над Авджиев и се класира 3-то място Сингъл Мъже.\r\n\r\nТримата финалисти на Сингъл Мъже се сдобиха с чисто нови електро велосипеди от Лидер 96 ЕООД и парични награди от Университетска Болница „Пълмед“.\r\n\r\n\r\n\r\nОбщ брой записани участници за Сингъл Мъже – 67 участника / жребий в групи – 13 групи*4 и 3 групи*5 /\r\n\r\n\r\n\r\n\r\n\r\nМачът от финалния кръг двойки мъже беше между братя Мирчеви от Пловдив и двойката от Казанлък – Митко Костадинов и Васил Чушев. Беше оспорвана игра и докрая не беше ясно кой ще вземе първото място на двойки. Финалистите спечелиха фирмени колела Лидер (по 2 електрически велосипеда за двойка) и парични награди от Университетска Болница „Пълмед“.\r\n\r\n\r\n\r\nОбщ брой записани за Двойки Мъже – 22 двойки /от които 1 двойка беше дисквалифицирана/",
                ImageUrl = "https://tennis.leader96.com/wp-content/uploads/elementor/thumbs/IMG_20220925_161056-pvfh8bwcb23r7ekjwk5lkhjdly66l5emh6wqpj7lkw.jpg",
                DatePublished = DateTime.ParseExact("28/09/2023 19:30", DateTimeArticleFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ViewsCount = 0
            };
        }
    }
}
