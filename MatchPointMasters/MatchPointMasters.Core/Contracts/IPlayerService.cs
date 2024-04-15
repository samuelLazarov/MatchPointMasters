namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Roles.QueryModels;

    public interface IPlayerService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<bool> UserWithPhoneNumberExistsAsync (string phoneNumber);
        Task<PlayerServiceModel> GetPlayerById(string userId);
        Task<int> CreateAsync(string userId);
        Task<PlayerQueryServiceModel> GetAllPlayers();
        Task<PlayerServiceModel> GetPlayerMatches(int id);
        Task<PlayerServiceModel> GetPlayerTournaments(int id);
    }
}