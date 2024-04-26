using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Services;
using MatchPointMasters.Infrastructure.Data.Common;
using MatchPointMasters.Infrastructure.Data.Models.Roles;
using MatchPointMasters.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MatchPointMasters.Infrastructure.Data.Enums.Tournament;
using MatchPointMasters.Infrastructure.ViewModels;
using MatchPointMasters.Infrastructure.Data.Models.Tournament;

namespace MatchPointMasters.UnitTests.ClubServiceTests
{
    [TestFixture]
    public class ClubServiceUnitTests
    {
        //Db and services

        private MatchPointMastersDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private ITournamentHostService tournamentHostService;
        private IUserService userService;
        private IMatchService matchService;
        private ITournamentService tournamentService;
        private IPlayerService playerService;
        private ITiebreakService tiebreakService;
        private ISetService setService;
        private IClubService clubService;

        [SetUp]
        public async Task Setup()
        {
            //Database
            var options = new DbContextOptionsBuilder<MatchPointMastersDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new MatchPointMastersDbContext(options);
            dbContext.SaveChanges();

            //UserStore
            var userStore = new UserStore<ApplicationUser>(dbContext);
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var optionsUserManager = Options.Create(new IdentityOptions());
            userManager = new UserManager<ApplicationUser>(userStore, optionsUserManager, passwordHasher, null, null, null, null, null, null);

            //Services
            repository = new Repository(dbContext);
            tiebreakService = new TiebreakService(repository);
            setService = new SetService(repository, tiebreakService);
            matchService = new MatchService(repository, userService, playerService, setService);
            tournamentHostService = new TournamentHostService(repository);
            userService = new UserService(userManager, repository, tournamentHostService);
            playerService = new PlayerService(repository);
            tournamentService = new TournamentService(repository, matchService, userManager, playerService, userService);
            clubService = new ClubService(dbContext);
        }

        [Test]
        public async Task AddAsync_AddsClubToDatabase()
        {
            // Arrange
            var model = new AddClubFormModel
            {
                Name = "Test Club",
                Address = "123 Test St",
                CourtSurface = CourtSurface.Hard,
                ImageUrl = "https://example.com/image.jpg",
                PhoneNumber = "555-555-5555"
            };

            // Act
            await clubService.AddAsync(model);

            // Assert
            var club = await dbContext.Clubs.FirstOrDefaultAsync();
            Assert.NotNull(club);
            Assert.AreEqual(model.Name, club.Name);
            Assert.AreEqual(model.Address, club.Address);
            Assert.AreEqual(model.CourtSurface, club.CourtSurface);
            Assert.AreEqual(model.ImageUrl, club.ImageUrl);
            Assert.AreEqual(model.PhoneNumber, club.PhoneNumber);
        }
        [Test]
        public async Task AllAsync_ReturnsAllClubs()
        {
            // Arrange
            var club1 = new Club
            {
                Name = "Test Club 1",
                Address = "123 Test St",
                CourtSurface = CourtSurface.Hard,
                ImageUrl = "https://example.com/image1.jpg",
                PhoneNumber = "555-555-5555"
            };
            var club2 = new Club
            {
                Name = "Test Club 2",
                Address = "456 Test St",
                CourtSurface = CourtSurface.Clay,
                ImageUrl = "https://example.com/image2.jpg",
                PhoneNumber = "555-555-5556"
            };
            dbContext.Add(club1);
            dbContext.Add(club2);
            await dbContext.SaveChangesAsync();

            // Act
            var allClubs = await clubService.AllAsync();

            // Assert
            Assert.AreEqual(2, allClubs.Count());
            Assert.AreEqual(club1.Id, allClubs.First().Id);
            Assert.AreEqual(club1.Name, allClubs.First().Name);
            Assert.AreEqual(club1.Address, allClubs.First().Address);
            Assert.AreEqual(club1.CourtSurface.ToString(), allClubs.First().CourtSurface);
            Assert.AreEqual(club1.ImageUrl, allClubs.First().ImageUrl);
            Assert.AreEqual(club1.PhoneNumber, allClubs.First().PhoneNumber);
            Assert.AreEqual(club2.Id, allClubs.Last().Id);
            Assert.AreEqual(club2.Name, allClubs.Last().Name);
            Assert.AreEqual(club2.Address, allClubs.Last().Address);
            Assert.AreEqual(club2.CourtSurface.ToString(), allClubs.Last().CourtSurface);
            Assert.AreEqual(club2.ImageUrl, allClubs.Last().ImageUrl);
            Assert.AreEqual(club2.PhoneNumber, allClubs.Last().PhoneNumber);
        }
        [Test]
        public async Task GetAllForTournament_ReturnsAllClubsForTournament()
        {
            // Arrange
            var club1 = new Club
            {
                Name = "Test Club 1",
                Address = "123 Test St",
                CourtSurface = CourtSurface.Hard,
                ImageUrl = "https://example.com/image1.jpg",
                PhoneNumber = "555-555-5555"
            };
            var club2 = new Club
            {
                Name = "Test Club 2",
                Address = "456 Test St",
                CourtSurface = CourtSurface.Clay,
                ImageUrl = "https://example.com/image2.jpg",
                PhoneNumber = "555-555-5556"
            };
            dbContext.Add(club1);
            dbContext.Add(club2);
            await dbContext.SaveChangesAsync();

            // Act
            var allClubsForTournament = await clubService.GetAllForTournament();

            // Assert
            Assert.AreEqual(2, allClubsForTournament.Count());
            Assert.AreEqual(club1.Id, allClubsForTournament.First().Id);
            Assert.AreEqual(club1.Name, allClubsForTournament.First().Name);
            Assert.AreEqual(club2.Id, allClubsForTournament.Last().Id);
            Assert.AreEqual(club2.Name, allClubsForTournament.Last().Name);
        }


        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }
    }
}
