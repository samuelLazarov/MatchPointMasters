namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Player;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;

    public interface ITournamentService
    {
        Task<TournamentQueryServiceModel> AllAsync(
            string? searchTerm = null,
            TournamentSorting sorting = TournamentSorting.Newest,
            TournamentStatus status = TournamentStatus.All,
            int currentPage = 1,
            int tournamentsPerPage = 4
            );
        Task<bool> TournamentExistsAsync(int tournamentId);
        Task<Tournament> FindTournamentByIdAsync(int tournamentId);
        Task<TournamentDetailsViewModel> DetailsAsync(int tournamentId);
        Task<PlayerQueryServiceModel> GetAllPlayersInTournamentAsync(int tournamentId);
        Task<MatchQueryServiceModel> GetAllMatchesInTournamentAsync(int tournamentId);
    }
}