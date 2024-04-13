namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Infrastructure.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Match = Infrastructure.Data.Models.Match.Match;

    public class MatchService : IMatchService
    {
        private readonly IRepository repository;

        public MatchService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> AddMatchAsync(MatchAddViewModel matchForm)
        {
            Match match = new Match()
            {
                TournamentId = matchForm.TournamentId,
                MatchRound = matchForm.MatchRound,
                PlayerOneId = matchForm.PlayerOneId,
                PlayerTwoId = matchForm.PlayerTwoId,
                PlayerOneSetsWon = matchForm.PlayerOneSetsWon,
                PlayerTwoSetsWon = matchForm.PlayerTwoSetsWon,
                Winner = matchForm.Winner,
            };

            await repository.AddAsync(match);
            await repository.SaveChangesAsync();

            return match.Id;
        }

        public async Task<MatchEditViewModel> EditMatchGetAsync(int matchId)
        {
            var currentMatch = await repository.All<Match>()
                .FirstOrDefaultAsync(m => m.Id == matchId);

            var matchForm = new MatchEditViewModel()
            {
                Id = currentMatch.Id,
                TournamentId= currentMatch.TournamentId,
                MatchRound = currentMatch.MatchRound,
                PlayerOneId = currentMatch.PlayerOneId,
                PlayerTwoId= currentMatch.PlayerTwoId,
                PlayerOneSetsWon= currentMatch.PlayerOneSetsWon,
                PlayerTwoSetsWon= currentMatch.PlayerTwoSetsWon,
                Winner = currentMatch.Winner
            };

            return matchForm;

        }

        public async Task<int> EditMatchPostAsync(MatchEditViewModel matchForm)
        {
            var match = await repository.All<Match>()
                .Where(m => m.Id == matchForm.Id)
                .FirstOrDefaultAsync();

            match.TournamentId = matchForm.TournamentId;
            match.MatchRound = matchForm.MatchRound;
            match.PlayerOneId = matchForm.PlayerOneId;
            match.PlayerTwoId = matchForm.PlayerTwoId;
            match.PlayerOneSetsWon = matchForm.PlayerOneSetsWon;
            match.PlayerTwoSetsWon = matchForm.PlayerTwoSetsWon;
            match.Winner = matchForm.Winner;

            await repository.SaveChangesAsync();

            return match.Id;

        }

        public async Task<MatchDeleteViewModel> DeleteMatchAsync(int matchId)
        {
            var match = await repository
                .AllAsReadOnly<Match>().Where(m => m.Id == matchId)
                .FirstOrDefaultAsync();

            var deleteForm = new MatchDeleteViewModel()
            {
                PlayerOneId = match.PlayerOneId,
                PlayerTwoId = match.PlayerTwoId,
                MatchRound = match.MatchRound,
            };

            return deleteForm;
        }

        public async Task<int> DeleteMatchConfirmedAsync(int matchId)
        {
            var match = await repository
                .AllAsReadOnly<Match>()
                .Where(m => m.Id == matchId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync(match);
            await repository.SaveChangesAsync();

            return match.Id;
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



        public Task<SetQueryServiceModel> GetAllSetsInMatchAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchDetailsViewModel> MatchDetailsAsync(int matchId)
        {
            Match? currentMatch = await repository.AllAsReadOnly<Match>()
                .FirstOrDefaultAsync(m => m.Id == matchId);

            var currentMatchDetails = new MatchDetailsViewModel()
            {
                Id = currentMatch.Id,
                MatchRound = currentMatch.MatchRound,
                PlayerOneId = currentMatch.PlayerOneId,
                PlayerTwoId = currentMatch.PlayerTwoId,
                PlayerOneSetsWon = currentMatch.PlayerOneSetsWon,
                PlayerTwoSetsWon = currentMatch.PlayerTwoSetsWon,
                Winner = currentMatch.Winner,
            };

            return currentMatchDetails;
        }

        public async Task<bool> MatchExistsAsync(int matchId)
        {
            return await repository.AllAsReadOnly<Match>()
                .AnyAsync(m => m.Id == matchId);
        }

        public async Task<Match> FindMatchByIdAsync(int matchId)
        {
            return await repository.GetByIdAsync<Match>(matchId);
        }
    }
}
