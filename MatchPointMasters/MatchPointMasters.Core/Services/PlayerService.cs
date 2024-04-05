namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService
    {
        public Task<ICollection<PlayerServiceModel>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerMatches(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerTournaments(string id)
        {
            throw new NotImplementedException();
        }
    }
}
