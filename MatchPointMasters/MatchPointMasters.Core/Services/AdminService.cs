using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Admin;
using MatchPointMasters.Infrastructure.Data.Common;

namespace MatchPointMasters.Core.Services
{
    public class AdminService : IAdminService
    {

        private readonly IRepository repository;
        private readonly ITournamentHostService tournamentHostService;
        private readonly IUserService userService;
        
        public Task<int> AddAdminAsync(UserViewModel form)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddTournamentHostAsync(UserViewModel form)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> RemoveAdminAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAdminConfirmedAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRemoveViewModel> RemoveTournamentHostAsync(int tournamentHostId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveTournamentHostConfirmedAsync(int tournamentHostId)
        {
            throw new NotImplementedException();
        }
    }
}
