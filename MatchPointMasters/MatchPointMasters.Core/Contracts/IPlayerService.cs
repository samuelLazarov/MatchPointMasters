namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Player;

    public interface IPlayerService
    {
        Task<ICollection<PlayerServiceModel>> GetAllPlayers();
        Task<PlayerServiceModel> GetPlayerById(int id);
        Task<PlayerServiceModel> GetPlayerMatches(int id);
        Task<PlayerServiceModel> GetPlayerTournaments(int id);
    }
}