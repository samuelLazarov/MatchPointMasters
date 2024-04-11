namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;

    public interface ITournamentService
    {
        Task<ICollection<TournamentQueryServiceModel>> AllAsync(
            string? searchTerm = null,
            TournamentSorting sorting = TournamentSorting.Newest,
            TournamentStatus status = TournamentStatus.All,
            int currentPage = 1,
            int tournamentsPerPage = 4
            );
        Task<bool> TournamentExistsAsync(int tournamentId);
        Task<Tournament> FindTournamentByIdAsync(int tournamentId);
        Task<TournamentServiceModel> GetAllPlayersInTournament(int tourId);
        Task<TournamentServiceModel> GetAllMatchesInTournament(int tourId);
    }
}