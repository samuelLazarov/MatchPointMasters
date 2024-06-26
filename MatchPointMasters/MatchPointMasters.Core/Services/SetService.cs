﻿
namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Set.QueryModels;
    using MatchPointMasters.Core.Models.Set.ViewModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class SetService : ISetService
    {
        private readonly IRepository repository;
        private readonly ITiebreakService tiebreakService;

        public SetService(IRepository _repository, ITiebreakService _tiebreakService)

        {
            repository = _repository;
            tiebreakService = _tiebreakService;
        }

        public async Task<int> AddSetAsync(SetAddViewModel setForm, int matchId)
        {
            Set set = new Set()
            {
                MatchId = matchId,
                PlayerOneGamesWon = setForm.PlayerOneGamesWon,
                PlayerTwoGamesWon = setForm.PlayerTwoGamesWon,
                HasTiebreak = setForm.HasTiebreak,
                TiebreakId = setForm.TiebreakId,
            };

            await repository.AddAsync(set);
            await repository.SaveChangesAsync();

            return set.Id;
        }

        public async Task<SetEditViewModel> EditSetAsyncGetAsync(int setId)
        {
            var currentSet = await repository.All<Set>()
                .FirstOrDefaultAsync(s => s.Id == setId);

            var tiebreakForm = new SetEditViewModel()
            {
                PlayerOneGamesWon = currentSet.PlayerOneGamesWon,
                PlayerTwoGamesWon = currentSet.PlayerTwoGamesWon,
                HasTiebreak = currentSet.HasTiebreak,
            };

            return tiebreakForm;
        }

        public async Task<int> EditSetPostAsync(SetEditViewModel setForm)
        {
            var set = await repository.All<Set>()
                .Where(t => t.Id == setForm.Id)
                .FirstOrDefaultAsync();

            set.PlayerOneGamesWon = setForm.PlayerOneGamesWon;
            set.PlayerTwoGamesWon = setForm.PlayerTwoGamesWon;
            set.HasTiebreak = setForm.HasTiebreak;

            await repository.SaveChangesAsync();

            return set.Id;
        }

        public async Task<SetDeleteViewModel> DeleteSetAsync(int setId)
        {
            var set = await repository
                .AllAsReadOnly<Set>().Where(t => t.Id == setId)
                .FirstOrDefaultAsync();

            var deleteForm = new SetDeleteViewModel()
            {
                PlayerOneGamesWon = set.PlayerOneGamesWon,
                PlayerTwoGamesWon = set.PlayerTwoGamesWon,
            };

            return deleteForm;
        }

        public async Task<int> DeleteSetConfirmedAsync(int setId)
        {
            var set = await repository
                .AllAsReadOnly<Set>()
                .Where(t => t.Id == setId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync(set);
            await repository.SaveChangesAsync();

            return set.Id;
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
                MatchId = currentSet.MatchId,
                PlayerOneGamesWon = currentSet.PlayerOneGamesWon,
                PlayerTwoGamesWon = currentSet.PlayerTwoGamesWon,
                HasTiebreak = currentSet.HasTiebreak,
            };

            return currentTiebrakDetails;
        }

        public async Task<bool> SetExistsAsync(int setId)
        {
            return await repository.AllAsReadOnly<Set>()
                .AnyAsync(t => t.Id == setId);
        }

        //TODO - fill current set with properties
        public async Task<Set> AddTiebreakToSetAsync(int setId)
        {
            var currentSet = await repository.All<Set>()
                .Where(s => s.Id == setId && s.HasTiebreak == true)
                .FirstOrDefaultAsync();

            if (currentSet == null)
            {
                currentSet = new Set()
                {
                    Id = setId,
                };
                await repository.AddAsync(currentSet);
                await repository.SaveChangesAsync();
            }

            return currentSet;
        }
    }
}
