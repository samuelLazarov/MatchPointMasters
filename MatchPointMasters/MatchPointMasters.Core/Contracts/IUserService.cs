namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    public interface IUserService
    {
        Task<bool> ExistByIdAsync(string userId);
        Task<bool> ExistByEmailAsync(string userEmail);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string userEmail);
    }
}
