namespace MatchPointMasters.UnitTests
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;


    [TestFixture]
    internal class UserServiceUnitTests
    {

        //Db and services

        private MatchPointMastersDbContext dbContext;

        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private ITournamentHostService tournamentHostService;
        private IUserService userService;
        private ITournamentService tournamentService;

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
            //Users and Publishers
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
        }
    }
}
