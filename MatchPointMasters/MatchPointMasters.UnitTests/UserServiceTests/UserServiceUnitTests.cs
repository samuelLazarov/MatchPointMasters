namespace MatchPointMasters.UnitTests.UserServiceTests
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Services;
    using MatchPointMasters.Infrastructure.Data;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    [TestFixture]
    public class UserServiceUnitTests
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

        //Collections
        private IEnumerable<ApplicationUser> users;

        //Users
        private ApplicationUser userOne;
        private ApplicationUser userTwo;
        private ApplicationUser userThree;
        private ApplicationUser userFour;

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
            userTwo = new ApplicationUser()
            {
                Id = "TestIdTwo",
                UserName = "boris@gmail.com",
                NormalizedUserName = "BORIS@GMAIL.COM",
                Email = "boris@gmail.com",
                NormalizedEmail = "BORIS@GMAIL.COM",
                FirstName = "Boris",
                LastName = "Vladov"
            };
            userThree = new ApplicationUser()
            {
                Id = "TestIdThree",
                UserName = "jessica@gmail.com",
                NormalizedUserName = "JESSICA@GMAIL.COM",
                Email = "jessica@gmail.com",
                NormalizedEmail = "JESSICA@GMAIL.COM",
                FirstName = "Jessica",
                LastName = "Alba"
            };
            userFour = new ApplicationUser()
            {
                Id = "TestIdFour",
                UserName = "irina@gmail.com",
                NormalizedUserName = "IRINA@GMAIL.COM",
                Email = "irina@gmail.com",
                NormalizedEmail = "IRINA@GMAIL.COM",
                FirstName = "Irina",
                LastName = "Shayk"
            };
            tournamentHost = new TournamentHost()
            {
                Id = 1,
                UserId = userTwo.Id
            };

            //Collections
            users = new List<ApplicationUser>() { userOne, userTwo, userThree, userFour };

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
        }

        [Test]
        public async Task UserFullNameAsync_Should_Return_Correct_FullName()
        {
            // Act
            var result = userService.UserFullNameAsync(userOne.Id).Result;

            //Assert
            Assert.AreEqual("Nevena Ilieva", result);
        }
        [Test]
        public async Task AllAsync_Returns_AllUsers_When_NoSearchTermProvided()
        {
            // Act
            var result = await userService.AllAsync("current_user_id");

            // Assert
            Assert.AreEqual(4, result.TotalUsersCount);
            Assert.AreEqual(4, result.Users.Count());
        }

        [Test]
        public async Task AllAsync_FiltersUsersBySearchTerm()
        {
            // Act
            var result = await userService.AllAsync("current_user_id", searchTerm: "Nevena");

            // Assert
            Assert.AreEqual(1, result.TotalUsersCount);
            Assert.AreEqual(1, result.Users.Count());
        }

        [Test]
        public async Task AllAsync_Returns_NoAdminUsers_When_AdminRoleSortingIsSpecified()
        {
            // Act
            var result = await userService.AllAsync("current_user_id", roleSorting: UserRoleStatus.Admin);

            // Assert
            Assert.Zero(result.Users.Count(u => u.IsAdmin)); // Assuming there are no admin users in the database
        }

        [Test]
        public async Task AllAsync_Returns_NoTournamentHostUsers_When_TournamentHostRoleSortingIsSpecified()
        {
            // Act
            var result = await userService.AllAsync("current_user_id", roleSorting: UserRoleStatus.TournamentHost);

            // Assert
            Assert.IsTrue(result.Users.Count(u => u.IsTournamentHost) == 1);
        }

        [Test]
        public async Task ExistsByEmailAsync_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var userEmail = "nevena@gmail.com";

            // Act
            var exists = await userService.ExistsByEmailAsync(userEmail);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByEmailAsync_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var userEmail = "nonexistent@example.com";

            // Act
            var exists = await userService.ExistsByEmailAsync(userEmail);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsByIdAsync_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var userId = "TestIdOne";

            // Act
            var exists = await userService.ExistsByIdAsync(userId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdAsync_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = "nonexistent_user_id";

            // Act
            var exists = await userService.ExistsByIdAsync(userId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetUserByEmailAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userEmail = "nevena@gmail.com";

            // Act
            var user = await userService.GetUserByEmailAsync(userEmail);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("Nevena", user.FirstName);
            Assert.AreEqual("Ilieva", user.LastName);
        }

        [Test]
        public async Task GetUserByEmailAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userEmail = "nonexistent@example.com";

            // Act
            var user = await userService.GetUserByEmailAsync(userEmail);

            // Assert
            Assert.IsNull(user);
        }

        [Test]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = "TestIdOne";

            // Act
            var user = await userService.GetUserByIdAsync(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("Nevena", user.FirstName);
            Assert.AreEqual("Ilieva", user.LastName);
        }

        [Test]
        public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = "nonexistent_user_id";

            // Act
            var user = await userService.GetUserByIdAsync(userId);

            // Assert
            Assert.IsNull(user);
        }

        [Test]
        public async Task GetUserByFullNameAsync_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userFullName = "nevena ilieva";

            // Act
            var user = await userService.GetUserByFullNameAsync(userFullName);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual("Nevena", user.FirstName);
            Assert.AreEqual("Ilieva", user.LastName);
        }

        [Test]
        public async Task GetUserByFullNameAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userFullName = "nonexistent user";

            // Act
            var user = await userService.GetUserByFullNameAsync(userFullName);

            // Assert
            Assert.IsNull(user);
        }

        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }
    }
}
