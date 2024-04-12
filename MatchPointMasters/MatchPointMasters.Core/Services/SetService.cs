
namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class SetService : ISetService
    {
        private readonly IRepository repository;

        public SetService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SetQueryServiceModel> AllAsync()
        {
            var currentSets = await repository.AllAsReadOnly<Set>()
                .Select(s => new SetServiceModel()
                {
                    Id = s.Id,
                    MatchId = s.MatchId,
                    PlayerOneGamesWon = s.PlayerOneGamesWon,
                    PlayerTwoGamesWon = s.PlayerTwoGamesWon,
                    HasTiebreak = s.HasTiebreak,
                    TiebreakId = s.TiebreakId,
                })
                .ToListAsync();

            return new SetQueryServiceModel()
            {
                TotalSetsCount = currentSets.Count,
                Sets = currentSets
            };
        }

        public async Task<Set> FindSetByIdAsync(int setId)
        {
            return await repository.AllAsReadOnly<Set>()
                .FirstOrDefaultAsync(s => s.Id == setId);
        }

        public async Task<bool> HasTiebreakAsync(int setId)
        {
            bool result = false;
            var currentSet = await repository.GetByIdAsync<Set>(setId);

            if (currentSet != null)
            {
                result = currentSet.TiebreakId != null;
            }

            return result;
        }

        public async Task<SetDetailsViewModel> SetDetailsAsync(int setId)
        {
            Set? currentSet = await repository.AllAsReadOnly<Set>()
                .FirstOrDefaultAsync(t => t.Id == setId);

            var currentTiebrakDetails = new SetDetailsViewModel()
            {
                Id = currentSet.Id,
                MatchId = currentSet.MatchId,
                PlayerOneGamesWon = currentSet.PlayerOneGamesWon,
                PlayerTwoGamesWon = currentSet.PlayerTwoGamesWon,
                HasTiebreak = currentSet.HasTiebreak,
                TiebreakId = currentSet.TiebreakId,
            };

            return currentTiebrakDetails;
        }

        public async Task<bool> SetExistsAsync(int setId)
        {
            return await repository.AllAsReadOnly<Set>()
                .AnyAsync(t => t.Id == setId);
        }
    }
}
