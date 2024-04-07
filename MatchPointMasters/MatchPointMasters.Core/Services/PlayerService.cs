namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Player;
    using MatchPointMasters.Infrastructure.Data.Common;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;


        public PlayerService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<ICollection<PlayerServiceModel>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerMatches(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerServiceModel> GetPlayerTournaments(int id)
        {
            throw new NotImplementedException();
        }
    }
}
