namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Admin.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static MatchPointMasters.Core.Constants.AdministratorConstants;

    public class AdminService : IAdminService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;
        private readonly ITournamentHostService tournamentHostService;
        private readonly IUserService userService;

        public AdminService(UserManager<ApplicationUser> _userManager, IRepository _repository, ITournamentHostService _tournamentHostService, IUserService _userService)
        {
            userManager = _userManager;
            repository = _repository;
            tournamentHostService = _tournamentHostService;
            userService = _userService;
        }


        public async Task<int> AddTournamentHostAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            TournamentHost tournamentHost = new TournamentHost()
            {
                UserId = user.Id,
            };

            await repository.AddAsync(tournamentHost);
            await repository.SaveChangesAsync();

            return tournamentHost.Id;
        }

        public async Task<UserServiceModel> RemoveTournamentHostAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            var deleteForm = new UserServiceModel()
            {
                Id = userId,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(userId).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return deleteForm;
        }

        public async Task<int> RemoveTournamentHostConfirmedAsync(string userId)
        {
            TournamentHost? tournamentHost = repository.All<TournamentHost>().FirstOrDefaultAsync(th => th.UserId == userId).Result;

            await repository.RemoveAsync<TournamentHost>(tournamentHost);
            await repository.SaveChangesAsync();

            return tournamentHost.Id;
        }

        public async Task<string> AddAdminAsync(string userId)
        {
            ApplicationUser user = userService.GetUserByIdAsync(userId).Result;

            await userManager.AddToRoleAsync(user, AdminRole);
            await repository.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserServiceModel> RemoveAdminAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            var removeForm = new UserServiceModel()
            {
                Id = userId,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(userId).Result,
                IsAdmin = userManager.IsInRoleAsync(user, AdminRole).Result
            };

            return removeForm;
        }

        public async Task<string> RemoveAdminConfirmedAsync(string userId)
        {
            ApplicationUser? user = repository.GetByIdAsync<ApplicationUser>(userId).Result;

            await userManager.RemoveFromRoleAsync(user, AdminRole);
            await repository.SaveChangesAsync();

            return userId;
        }
    }
}
