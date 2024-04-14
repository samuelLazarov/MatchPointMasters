namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {

        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> ExistByEmailAsync(string userEmail)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(u => u.Email.ToLower() == userEmail.ToLower());
        }

        public async Task<bool> ExistByIdAsync(string userId)
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
    }
}
