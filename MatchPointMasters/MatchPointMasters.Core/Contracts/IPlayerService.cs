namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Player;

    public interface IPlayerService
    {
        //TODO
        Task<ICollection<PlayerQueryServiceModel>> GetAllPlayers();
        Task<PlayerServiceModel> GetPlayerById(string id);
        Task<PlayerServiceModel> GetPlayerMatches(int id);
        Task<PlayerServiceModel> GetPlayerTournaments(int id);
    }
}