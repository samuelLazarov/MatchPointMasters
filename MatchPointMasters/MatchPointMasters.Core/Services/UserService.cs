﻿namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Admin.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static MatchPointMasters.Core.Constants.AdministratorConstants;

    public class UserService : IUserService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;
        private readonly ITournamentHostService tournamentHostService;

        public UserService(UserManager<ApplicationUser> _userManager, IRepository _repository, ITournamentHostService _tournamentHostService)
        {
            userManager = _userManager;
            repository = _repository;
            tournamentHostService = _tournamentHostService;
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<UserQueryServiceModel> AllAsync(
            string currentUserId,
            string? searchTerm = null,
            UserRoleStatus roleSorting = UserRoleStatus.All,
            int currentPage = 1,
            int usersPerPage = 8)
        {
            var usersToShow = repository.AllAsReadOnly<ApplicationUser>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                usersToShow = usersToShow
                .Where(u => normalizedSearchTerm.Contains(u.FirstName.ToLower())
                || normalizedSearchTerm.Contains(u.LastName.ToLower())
                || normalizedSearchTerm.Contains(u.Email.ToLower())

                || u.FirstName.ToLower().Contains(normalizedSearchTerm)
                || u.LastName.ToLower().Contains(normalizedSearchTerm)
                || u.Email.ToLower().Contains(normalizedSearchTerm));
            }

            var currentUsers = usersToShow
                .Where(u => u.Email != "admin@gmail.com" && u.Id != currentUserId)
                .Select(u => new UserServiceModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(u.Id).Result,
                    IsAdmin = userManager.IsInRoleAsync(u, AdminRole).Result
                })
                .ToList();


            if (roleSorting == UserRoleStatus.TournamentHost)
            {
                currentUsers = currentUsers.Where(u => u.IsTournamentHost).ToList();
            }
            else if (roleSorting == UserRoleStatus.Admin)
            {
                currentUsers = currentUsers.Where(u => u.IsAdmin).ToList();
            }

            var users = currentUsers
                .Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage)
                .ToList();

            int totalUsers = currentUsers.Count();


            return new UserQueryServiceModel()
            {
                Users = users,
                TotalUsersCount = totalUsers
            };
        }

        public async Task<bool> ExistsByEmailAsync(string userEmail)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(u => u.Email.ToLower() == userEmail.ToLower());
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string userEmail)
        {
            return await repository.All<ApplicationUser>()
                .Where(u => u.Email.ToLower() == userEmail.ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await repository.GetByIdAsync<ApplicationUser>(userId);
        }

        public async Task<UserServiceModel> DetailsAsync(string userId)
        {
            ApplicationUser? currentUser = await repository.GetByIdAsync<ApplicationUser>(userId);

            var userDetails = new UserServiceModel()
            {
                Id = currentUser.Id,
                FullName = $"{currentUser.FirstName} {currentUser.LastName}",
                Email = currentUser.Email,
                IsTournamentHost = tournamentHostService.ExistsByUserIdAsync(currentUser.Id).Result,
                IsAdmin = userManager.IsInRoleAsync(currentUser, AdminRole).Result
            };

            return userDetails;
        }
    }
}
