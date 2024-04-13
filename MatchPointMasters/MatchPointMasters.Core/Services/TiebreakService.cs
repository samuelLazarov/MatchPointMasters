
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

        public async Task<int> AddTiebreakAsync(TiebreakAddViewModel tiebreakForm, int setId)
        {
            Tiebreak tiebreak = new Tiebreak()
            {
                PlayerOnePoints = tiebreakForm.PlayerOnePoints,
                PlayerTwoPoints = tiebreakForm.PlayerTwoPoints,
                SetId = setId
            };

            await repository.AddAsync(tiebreak);
            await repository.SaveChangesAsync();

            return tiebreak.Id;
        }

        public async Task<TiebreakEditViewModel> EditTiebreakGetAsync(int tiebreakId)
        {
            var currentTiebreak = await repository.All<Tiebreak>()
                .FirstOrDefaultAsync(t => t.Id == tiebreakId);

            var tiebreakForm = new TiebreakEditViewModel()
            {
                Id = currentTiebreak.Id,
                PlayerOnePoints = currentTiebreak.PlayerOnePoints,
                PlayerTwoPoints = currentTiebreak.PlayerTwoPoints,
            };

            return tiebreakForm;
        }

        public async Task<int> EditTiebreakPostAsync(TiebreakEditViewModel tiebreakForm)
        {
            var tiebreak = await repository.All<Tiebreak>()
                .Where(t => t.Id == tiebreakForm.Id)
                .FirstOrDefaultAsync();

            tiebreak.PlayerOnePoints = tiebreakForm.PlayerOnePoints;
            tiebreak.PlayerTwoPoints = tiebreakForm.PlayerTwoPoints;
            tiebreak.SetId = tiebreakForm.SetId;

            await repository.SaveChangesAsync();

            return tiebreak.Id;

        }

        public async Task<TiebreakDeleteViewModel> DeleteTiebreakAsync(int tiebreakId)
        {
            var tiebreak = await repository
                .AllAsReadOnly<Tiebreak>().Where(t => t.Id == tiebreakId)
                .FirstOrDefaultAsync();

            var deleteForm = new TiebreakDeleteViewModel()
            {
                Id = tiebreak.Id,
                PlayerOnePoints = tiebreak.PlayerOnePoints,
                PlayerTwoPoints = tiebreak.PlayerTwoPoints,
            };

            return deleteForm;
        }

        public async Task<int> DeleteTiebreakConfirmedAsync(int tiebreakId)
        {
            var tiebreak = await repository
                .AllAsReadOnly<Tiebreak>()
                .Where(t => t.Id == tiebreakId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync<Tiebreak>(tiebreak);
            await repository.SaveChangesAsync();

            return tiebreak.Id;
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


        public async Task<Tiebreak> FindTiebreakByIdAsync(int tiebreakId)
        {
            var currentTiebreak = await repository.AllAsReadOnly<Tiebreak>()
                .FirstOrDefaultAsync(t => t.Id == tiebreakId);
            if (currentTiebreak == null)
            {
                throw new Exception();
            }
            return currentTiebreak;
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
