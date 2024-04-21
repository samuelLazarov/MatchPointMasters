namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Core.Models.Roles.ViewModels;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Models.Player;

    public interface IPlayerService
    {
        Task AddAsync(string userId, PlayerAddViewModel playerForm);
        Task<PlayerEditViewModel> EditGetAsync(int playerId);
        Task<int> EditPostAsync(PlayerEditViewModel playerForm);
        Task<PlayerQueryServiceModel> AllAsync(
            string? searchTerm = null,
            PlayerSorting sorting = PlayerSorting.All,
            int currentPage = 1,
            int playersPerPage = 8);
        Task<bool> PlayerExistsByIdAsync(int playerId);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
        Task<Player> FindPlayerByIdAsync(int playerId);
        Task<MatchQueryServiceModel> GetPlayerMatches(
            int playerId,
            MatchStatus status = MatchStatus.All,
            int currentPage = 1,
            int matchesPerPage = 8);
        Task<TournamentQueryServiceModel> GetPlayerTournaments(
            int playerId,
            TournamentSorting sorting = TournamentSorting.Newest,
            int currentPage = 1,
            int matchesPerPage = 8);
        
        Task<bool> PlayerIsInTournamentAsync(int playerId, int tournamentId);
        Task<int> AddPlayerToTournamentAsync(int playerId, int tournamentId);
    }
}