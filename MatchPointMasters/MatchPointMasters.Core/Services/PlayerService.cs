namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Player;
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
    }
}
