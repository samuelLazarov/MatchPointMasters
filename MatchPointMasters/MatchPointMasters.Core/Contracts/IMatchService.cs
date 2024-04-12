namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Infrastructure.Data.Models.Match;

    public interface IMatchService
    {
        
        //Match
        Task<MatchQueryServiceModel> AllMatchesInTournamentAsync(
            int tournamentId,
            string? matchRound = null,
            string? searchTerm = null,
            MatchStatus status = MatchStatus.All,
            int currentPage = 1,
            int matchesPerPage = 4);
        Task<bool> MatchExistsAsync(int matchId);
        Task<Match> FindMatchByIdAsync(int matchId);
        Task<MatchDetailsViewModel> MatchDetailsAsync(int matchId);
        Task<SetQueryServiceModel> GetAllSetsInMatchAsync(int tourId);

    }
}
