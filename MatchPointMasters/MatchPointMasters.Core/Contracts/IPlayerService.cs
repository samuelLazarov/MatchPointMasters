namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models;

    public interface IPlayerService
    {
        Task<ICollection<PlayerServiceModel>> GetAllPlayers();
        Task<PlayerServiceModel> GetPlayerById(string id);
        Task<PlayerServiceModel> GetPlayerMatches(string id);
        Task<PlayerServiceModel> GetPlayerTournaments(string id);
    }
}