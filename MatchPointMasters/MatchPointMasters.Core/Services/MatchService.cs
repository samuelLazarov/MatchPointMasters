namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class MatchService : IMatchService
    {
        private readonly IRepository repository;

        public MatchService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<MatchQueryServiceModel> AllMatchesInTournamentAsync(
            int tournamentId,
            string? matchRound = null, 
            string? searchTerm = null,
            MatchStatus status = MatchStatus.All, 
            int currentPage = 1, 
            int matchesPerPage = 4)
        {
            var matchesToShow = repository.AllAsReadOnly<Match>()
                .Where(m => m.TournamentMatches.Any(tm => tm.TournamentId == tournamentId));

            if (matchRound != null)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.MatchRound.ToString() == matchRound);
            }
            
            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                
                
            }

            return new MatchQueryServiceModel()
            {

            };
        }

        public async Task<Match> FindMatchByIdAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public async Task<SetQueryServiceModel> GetAllSetsInMatchAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchDetailsViewModel> MatchDetailsAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MatchExistsAsync(int matchId)
        {
            return await repository.AllAsReadOnly<Match>()
                .AnyAsync(m => m.Id == matchId);
        }
    }
}
