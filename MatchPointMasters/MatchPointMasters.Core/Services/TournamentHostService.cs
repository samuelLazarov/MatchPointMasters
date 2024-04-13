namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;

    public class TournamentHostService : ITournamentHostService
    {
        public readonly IRepository repository;

        public TournamentHostService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<TournamentHost>()
                .AnyAsync(th => th.UserId == userId);
        }

        public async Task<int?> GetTournamentHostIdAsync(string userId)
        {
            return (await repository
                .AllAsReadOnly<TournamentHost>()
                .FirstOrDefaultAsync(th => th.UserId == userId))?.Id;

        }

       
    }
}
