namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Match.ViewModels;
    using MatchPointMasters.Core.Models.Set.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Models.Match;

    public interface IMatchService
    {

        //CRUD operations
        Task<int> AddMatchAsync(MatchAddViewModel matchForm);
        Task<MatchEditViewModel> EditMatchGetAsync(int matchId);
        Task<int> EditMatchPostAsync(MatchEditViewModel matchForm);
        Task<MatchDeleteViewModel> DeleteMatchAsync(int matchId);
        Task<int> DeleteMatchConfirmedAsync(int matchId);

        //Query operations
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
