namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Roles.QueryModels;
    using MatchPointMasters.Core.Models.Tournament.QueryModels;
    using MatchPointMasters.Core.Models.Tournament.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Tournament;

    public interface ITournamentService
    {

        //CRUD operations
        Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm);
        Task<TournamentEditViewModel> EditTournamentGetAsync(int tournamentId);
        Task<int> EditTournamentPostAsync(TournamentEditViewModel tournamentForm);
        Task<TournamentDeleteViewModel> DeleteTournamentAsync(int tournamentId);
        Task<int> DeleteTournamentConfirmedAsync(int tournamentId);
        Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId);
        Task<TournamentMatch> AddMatchToTournamentAsync(int matchId, int tournamentId);
        Task<TournamentMatchDeleteViewModel> RemoveMatchFromTournamentAsync(int matchId, int tournamentId);
        Task RemoveMatchFromTournamentConfirmedAsync(int matchId, int tournamentId);


        //Query operations
        Task<TournamentQueryServiceModel> AllAsync(
            string? searchTerm = null,
            TournamentSorting sorting = TournamentSorting.Newest,
            TournamentStatus status = TournamentStatus.All,
            int currentPage = 1,
            int tournamentsPerPage = 4
            );
        Task<bool> TournamentExistsByIdAsync(int tournamentId);
        Task<Tournament> FindTournamentByIdAsync(int tournamentId);
        Task<TournamentDetailsViewModel> DetailsAsync(int tournamentId);
        Task<PlayerQueryServiceModel> GetAllPlayersInTournamentAsync(int tournamentId);
        Task<MatchQueryServiceModel> GetAllMatchesInTournamentAsync(int tournamentId);
        Task<IEnumerable<TournamentIndexViewModel>> LastThreeTournamentsAsync();
    }
}