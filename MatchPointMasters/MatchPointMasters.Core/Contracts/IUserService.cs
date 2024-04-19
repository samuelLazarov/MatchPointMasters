namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Admin.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);
        Task<UserQueryServiceModel> AllAsync(
            string currentUserId,
            string? searchTerm = null,
            UserRoleStatus roleSorting = UserRoleStatus.All,
            int currentPage = 1,
            int usersPerPage = 8);
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> ExistsByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
        Task<UserServiceModel> DetailsAsync(string userId);
    }
}
