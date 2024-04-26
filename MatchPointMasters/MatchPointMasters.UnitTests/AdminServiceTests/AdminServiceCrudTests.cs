using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Services;
using MatchPointMasters.Infrastructure.Data.Common;
using MatchPointMasters.Infrastructure.Data.Models.Roles;
using MatchPointMasters.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MatchPointMasters.UnitTests.AdminUserTests
{
    [TestFixture]
    public class AdminServiceCrudTests
    {
        //Db and services

        private MatchPointMastersDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private IAdminService adminService;
        private ITournamentHostService tournamentHostService;
        private IUserService userService;
        private IMatchService matchService;
        private ITournamentService tournamentService;
        private IPlayerService playerService;
        private ITiebreakService tiebreakService;
        private ISetService setService;

        //Collections
        private IEnumerable<ApplicationUser> users;

        //Users
        private ApplicationUser userOne;

        //Roles
        private TournamentHost tournamentHost;

        [SetUp]
        public async Task Setup()
        {
            userOne = new ApplicationUser()
            {
                Id = "TestIdOne",
                UserName = "nevena@gmail.com",
                NormalizedUserName = "NEVENA@GMAIL.COM",
                Email = "nevena@gmail.com",
                NormalizedEmail = "NEVENA@GMAIL.COM",
                FirstName = "Nevena",
                LastName = "Ilieva"
            };

            //Collections
            users = new List<ApplicationUser>() { userOne };

            //Database
            var options = new DbContextOptionsBuilder<MatchPointMastersDbContext>()
                .UseInMemoryDatabase(databaseName: "NovelNestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new MatchPointMastersDbContext(options);

            dbContext.AddRangeAsync(users);
            dbContext.AddAsync(tournamentHost);
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
            adminService = new AdminService(userManager, repository, tournamentHostService, userService);
        }

        [Test]
        public async Task AddTournamentHostAsync_AddsTournamentHostToDatabase()
        {
            // Act
            var tournamentHostId = await adminService.AddTournamentHostAsync(userOne.Id);

            // Assert
            var tournamentHost = await repository.GetByIdAsync<TournamentHost>(tournamentHostId);
            Assert.NotNull(tournamentHost);
            Assert.AreEqual(userOne.Id, tournamentHost.UserId);
        }
        [Test]
        public async Task RemoveTournamentHostAsync_ReturnsCorrectUserServiceModel()
        {
            // Arrange
            var userId = "testuser2";
            var user = new ApplicationUser { Id = userId, UserName = userId, Email = $"{userId}@example.com" };
            await userManager.CreateAsync(user, "Password123!");
            var tournamentHost = new TournamentHost { UserId = userId };
            await repository.AddAsync(tournamentHost);
            await repository.SaveChangesAsync();

            // Act
            var deleteForm = await adminService.RemoveTournamentHostAsync(userId);

            // Assert
            Assert.NotNull(deleteForm);
            Assert.AreEqual(userId, deleteForm.Id);
            Assert.AreEqual($"{user.FirstName} {user.LastName}", deleteForm.FullName);
            Assert.AreEqual(user.Email, deleteForm.Email);
            Assert.True(deleteForm.IsTournamentHost);
            Assert.False(deleteForm.IsAdmin);
        }
        [Test]
        public async Task RemoveTournamentHostConfirmedAsync_RemovesTournamentHostFromDatabase()
        {
            // Arrange
            var userId = "testuser3";
            var user = new ApplicationUser { Id = userId, UserName = userId, Email = $"{userId}@example.com" };
            await userManager.CreateAsync(user, "Password123!");
            var tournamentHost = new TournamentHost { UserId = userId };
            await repository.AddAsync(tournamentHost);
            await repository.SaveChangesAsync();

            // Act
            var tournamentHostId = await adminService.RemoveTournamentHostConfirmedAsync(userId);

            // Assert
            var deletedTournamentHost = await repository.GetByIdAsync<TournamentHost>(tournamentHostId);
            Assert.Null(deletedTournamentHost);
        }
        //[Test]
        //public async Task AddAdminAsync_AddsAdminRoleToUser()
        //{
        //    // Arrange
        //    var userId = "testuser4";
        //    var user = new ApplicationUser { Id = userId, UserName = userId, Email = $"{userId}@example.com" };
        //    await userManager.CreateAsync(user, "Password123!");

        //    // Act
        //    var adminId = await adminService.AddAdminAsync(userId);

        //    // Assert
        //    var adminUser = await userManager.FindByIdAsync(userId);
        //    Assert.True(await userManager.IsInRoleAsync(adminUser, "Admin"));
        //    Assert.AreEqual(user.Id, adminId);
        //}

        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }
    }
}
