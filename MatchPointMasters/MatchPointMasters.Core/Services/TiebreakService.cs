
namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;

    public class TiebreakService : ITiebreakService
    {
        private readonly IRepository repository;


        public TiebreakService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<TiebreakQueryServiceModel> AllAsync()
        {
            var tiebreaks = await repository.AllAsReadOnly<Tiebreak>()
                .Select(t => new TiebreakServiceModel()
                {
                    Id = t.Id,
                    PlayerOnePoints = t.PlayerOnePoints,
                    PlayerTwoPoints = t.PlayerTwoPoints,
                    SetId = t.SetId,
                })
                .ToListAsync();

            return new TiebreakQueryServiceModel()
            {
                TotalTiebreaksCount = tiebreaks.Count,
                Tiebreaks = tiebreaks
            };
        }

        public async Task<Tiebreak?> FindTiebreakByIdAsync(int tiebreakId)
        {
            return await repository.AllAsReadOnly<Tiebreak>()
                .FirstOrDefaultAsync(t => t.Id == tiebreakId);
        }

        public async Task<TiebreakDetailsViewModel> TiebreakDetailsAsync(int tiebreakId)
        {
            Tiebreak? currentTiebreak = await repository.AllAsReadOnly<Tiebreak>()
                .FirstOrDefaultAsync(t => t.Id == tiebreakId);

            var currentTiebrakDetails = new TiebreakDetailsViewModel()
            {
                Id = currentTiebreak.Id,
                PlayerOnePoints = currentTiebreak.PlayerOnePoints,
                PlayerTwoPoints = currentTiebreak.PlayerTwoPoints,
            };

            return currentTiebrakDetails;
        }

        public async Task<bool> TiebreakExistsAsync(int tiebreakId)
        {
            return await repository.AllAsReadOnly<Tiebreak>()
                .AnyAsync(t => t.Id == tiebreakId);
        }
    }
}
