namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;


        public PlayerService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<int> CreateAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PlayerQueryServiceModel>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerServiceModel> GetPlayerById(string playerid)
        {
            throw new NotImplementedException();

        }

        public async  Task<PlayerServiceModel> GetPlayerMatches(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerServiceModel> GetPlayerTournaments(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PlayerFullNameAsync(string userId)
        {
            string result = string.Empty;
            var player = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (player != null)
            {
                result = $"{player.FirstName} {player.LastName}";
            }
            return result;
        }

        public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        Task<PlayerQueryServiceModel> IPlayerService.GetAllPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
